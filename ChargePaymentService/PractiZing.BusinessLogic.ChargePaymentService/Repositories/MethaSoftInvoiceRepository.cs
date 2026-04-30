using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using System.Net.Http;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class MethaSoftInvoiceRepository : ModuleBaseRepository<MethaSoftInvoice>, IMethaSoftInvoiceRepository
    {

        private readonly RestApiCall _restApiCall;
        public MethaSoftInvoiceRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _restApiCall = new RestApiCall();
        }

        public async Task<IMethaSoftInvoice> AddNew(IMethaSoftInvoice entity)
        {
            try
            {
                string errorMessage = "";
                MethaSoftInvoice tEntity = entity as MethaSoftInvoice;
                tEntity.CreatedDate = DateTime.Now;
                if (string.IsNullOrEmpty(tEntity.CptCode))
                {
                    errorMessage += "Cpt Code is Missing";
                }
                if (string.IsNullOrEmpty(tEntity.IcdCodes))
                {
                    errorMessage += "Icd Code is Missing";
                }
                if (!string.IsNullOrEmpty(tEntity.IcdCodes))
                {
                    if (tEntity.IcdCodes == "0")
                        errorMessage += "Icd Code is Wrong.";
                }
                if (string.IsNullOrEmpty(tEntity.ProviderNPI))
                {
                    errorMessage += "Provider NPI is Missing";
                }
                tEntity.ErrorMessage = errorMessage;
                tEntity.POS = "11";

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        private async Task Update(List<MethaSoftInvoiceForEMRDTO> list)
        {
            try
            {

                foreach (var item in list)
                {
                    MethaSoftInvoice tEntity = await this.GetById(item.BillingMethaSoftInvocieId);
                    tEntity.SentDateToEMR = DateTime.Now;
                    tEntity.IsSentToEMR = true;
                    var updateOnlyFields = this.Connection
                                           .From<MethaSoftInvoice>()
                                           .Update(x => new
                                           {
                                               x.SentDateToEMR,
                                               x.IsSentToEMR
                                           })
                                           .Where(i => i.Id==tEntity.Id);
                    await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                }                
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendDataToEMR()
        {

            //await this.CreateAccessionWiseCptCodes();

            var list = await this.Connection.SelectAsync<MethaSoftInvoice>(i => i.IsSentToEMR == false && (i.IsDeleted==null || i.IsDeleted==false ));
            List<MethaSoftInvoiceForEMRDTO> methaSoftInvoiceForEMRDTOs = new List<MethaSoftInvoiceForEMRDTO>();
            foreach (var item in list)
            {
                MethaSoftInvoiceForEMRDTO methaSoftInvoiceForEMRDTO = new MethaSoftInvoiceForEMRDTO();
                methaSoftInvoiceForEMRDTO.BillingMethaSoftInvocieId = item.Id;
                methaSoftInvoiceForEMRDTO.CptCode = item.CptCode;
                methaSoftInvoiceForEMRDTO.DOSDate = item.DosDate;
                methaSoftInvoiceForEMRDTO.ErrorMessage = item.ErrorMessage;
                methaSoftInvoiceForEMRDTO.IcdCode = item.IcdCodes;
                methaSoftInvoiceForEMRDTO.PatientId = item.EMRPatientId;
                methaSoftInvoiceForEMRDTO.POS = item.POS;
                methaSoftInvoiceForEMRDTO.ProviderNPI = item.ProviderNPI;
                methaSoftInvoiceForEMRDTO.ProviderFirstName = item.ProviderFirstName;
                methaSoftInvoiceForEMRDTO.ProviderLastName = item.ProviderLastName;
                methaSoftInvoiceForEMRDTOs.Add(methaSoftInvoiceForEMRDTO);
            }
            if (methaSoftInvoiceForEMRDTOs.Count > 0)
            {
                string token = await GetEMRToken();

                string emrUrl = this.LoggedUser.EMRURL + "MethasoftEncounterInfo/AddMultiple";

                string jsondata = JsonConvert.SerializeObject(methaSoftInvoiceForEMRDTOs);

                HttpResponseMessage response = await _restApiCall.PostAsync(jsondata, "", emrUrl, token);
                if (response.IsSuccessStatusCode)
                {
                    await this.Update(methaSoftInvoiceForEMRDTOs);
                }
            }

            return true;
        }

        public async Task<string> GetEMRToken()
        {
            string tokenValue = "";

            string emrUrl = this.LoggedUser.EMRURL + "BillingAuth";            

            string username = this.LoggedUser.EMRUserName;
            string password = this.LoggedUser.EMRPassword;
            var response = await _restApiCall.PostWithHeaderAsync(username, password, "", "", emrUrl, "");
            //var response = await _restApiCall.GetAsync("", emrUrl, "");

            if (response.IsSuccessStatusCode)
            {
                var token_get = response.Content.ReadAsStringAsync().Result;
                tokenValue = token_get;                
                return tokenValue;
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();

            }

            return tokenValue;
        }

        private async Task<int> CreateAccessionWiseCptCodes()
        {

            try
            {
                string command = "usp_MethaSoft_CreateAccession";
                var result = await base.ExecuteStoredProcedureAsync<dynamic>(command);

                return 0;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
