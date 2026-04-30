using Newtonsoft.Json;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PaymentAdjustmentNotesRepository : ModuleBaseRepository<PaymentAdjustmentNotes>, IPaymentAdjustmentNotesRepository
    {
        private readonly RestApiCall _restApiCall;
        public PaymentAdjustmentNotesRepository(ValidationErrorCodes errorCodes,
                                   DataBaseContext dbContext,
                                   ILoginUser loggedUser)
                                   : base(errorCodes, dbContext, loggedUser)
        {
            _restApiCall = new RestApiCall();
        }

        public async Task<IPaymentAdjustmentNotes> AddNew(IPaymentAdjustmentNotes entity)
        {
            try
            {
                PaymentAdjustmentNotes tEntity = entity as PaymentAdjustmentNotes;                

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);
                await this.DeleteAll(tEntity.ChargeId.Value);
                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteAll(int chargeId)
        {
            try
            {
                var itemList = await this.Connection.SelectAsync<PaymentAdjustmentNotes>(i => i.ChargeId == chargeId);
                foreach (var item in itemList)
                {
                    await this.Connection.DeleteAsync<PaymentAdjustmentNotes>(i => i.Id == item.Id);
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendNotesToEMR()
        {
            var query = this.Connection.From<PaymentAdjustmentNotes>().
                Join<PaymentAdjustmentNotes, PaymentCharge>((i, j) => i.PaymentChargeId == j.Id, NoLockTableHint.NoLock)
                .Join<PaymentCharge, ChargeViewDTO>((i, j) => i.ChargeId == j.Id, NoLockTableHint.NoLock)
                .Join<ChargeViewDTO, Patient>((i, j) => i.PatientCaseId == j.DefaultCaseId, NoLockTableHint.NoLock)
                .Select<PaymentAdjustmentNotes, Patient, ChargeViewDTO>((x, y,z) => new
                {
                   x.Id,
                   x.ReasonCode,
                   x.Note,
                   x.CreatedDate,
                    BillingId=y.BillingID,
                    AccessionNumber=z.AccessionNumber
                }).Where<PaymentAdjustmentNotes>(i=>i.IsSendAck==false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PaymentAdjustmentNotes>.MapList(queryResult);
            if(result!=null && result.Count()>0)
            {
                List<EMRPatientAdjustmentNotes> LsteMRPatientAdjustmentNotes = new List<EMRPatientAdjustmentNotes>();
                foreach (var item in result)
                {
                    EMRPatientAdjustmentNotes eMRPatientAdjustmentNotes = new EMRPatientAdjustmentNotes();
                    eMRPatientAdjustmentNotes.CreatedDate = item.CreatedDate.ToShortDateString();
                    eMRPatientAdjustmentNotes.EncounterId = item.AccessionNumber;
                    eMRPatientAdjustmentNotes.Notes = item.Note;
                    eMRPatientAdjustmentNotes.PatientId = item.BillingId;
                    eMRPatientAdjustmentNotes.ReasonCode = item.ReasonCode;
                    LsteMRPatientAdjustmentNotes.Add(eMRPatientAdjustmentNotes);
                }
                if(LsteMRPatientAdjustmentNotes.Count()>0)
                await SendNotesData(LsteMRPatientAdjustmentNotes,result.ToList());
            }

            return true;
        }

        public async Task<bool> SendNotesData(List<EMRPatientAdjustmentNotes> lst,List<PaymentAdjustmentNotes> noteList)
        {
            string val = await GetEMRToken();

            string emrUrl = this.LoggedUser.EMRURL;// + "PatientStickyNote/AddAdjustmentNotes";

            EMRPatientAdjustmentNotesRoot eMRPatientAdjustmentNotesRoot = new EMRPatientAdjustmentNotesRoot();
            eMRPatientAdjustmentNotesRoot.lst = lst.Take(1).ToList();
            //LabAuthResponseDTO obj = new LabAuthResponseDTO();
            //obj.Ids = lst;

            string jsondata = JsonConvert.SerializeObject(lst.Take(1));
            HttpResponseMessage response = null;
            response = await _restApiCall.PostAsync(jsondata, "PatientStickyNote/AddAdjustmentNotes", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                await UpdateAfterSentToEMR(noteList);
            }

            return true;
        }

        public async Task<bool> UpdateAfterSentToEMR(IEnumerable<IPaymentAdjustmentNotes> lst)
        {
            try
            {
                foreach (var item in lst)
                {
                    PaymentAdjustmentNotes tEntity = item as PaymentAdjustmentNotes;
                    
                    tEntity.IsSendAck = true;
                    var query = this.Connection.From<PaymentAdjustmentNotes>()
                                .Update(u => new
                                {
                                    u.IsSendAck
                                })
                                .Where(i => i.Id == item.Id);

                    await base.UpdateOnlyAsync(tEntity, query);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        string token = "";
        public async Task<string> GetEMRToken()
        {
            string tokenValue = "";

            //string emrUrl = this.LoggedUser.EMRURL + "BillingAuth/GetToken";
            string emrUrl = this.LoggedUser.EMRURL + "BillingAuth";
            //string emrUrl = "https://atc-dev-api.atcemr.com/api/BillingAuth";

            string username = this.LoggedUser.EMRUserName;
            string password = this.LoggedUser.EMRPassword;
            var response = await _restApiCall.PostWithHeaderAsync(username, password, "", "", emrUrl, "");
            //var response = await _restApiCall.GetAsync("", emrUrl, "");

            if (response.IsSuccessStatusCode)
            {
                var token_get = response.Content.ReadAsStringAsync().Result;
                //this.token = token_get.Substring(1, token_get.Length - 2);
                this.token = token_get;
                return tokenValue;
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();

            }

            return string.Empty;
        }

        public class EMRPatientAdjustmentNotes
        {
            public string PatientId { get; set; }
            public string ReasonCode { get; set; }
            public string Notes { get; set; }
            public string CreatedDate { get; set; }
            public string EncounterId { get; set; }
        }

        public class EMRPatientAdjustmentNotesRoot
        {
            public EMRPatientAdjustmentNotesRoot()
            {
                lst = new List<EMRPatientAdjustmentNotes>();
            }

            public List<EMRPatientAdjustmentNotes> lst { get; set; }
        }
    }
}
