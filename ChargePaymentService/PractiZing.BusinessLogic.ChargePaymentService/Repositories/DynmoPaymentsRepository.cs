using AutoMapper;
using Newtonsoft.Json;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class DynmoPaymentsRepository : ModuleBaseRepository<DynmoPayments>, IDynmoPaymentsRepository
    {
        private IConfigERARemarkCodesRepository _configERARemarkCodesRepository;
        private readonly IMapper _mapper;
        private readonly RestApiCall _restApiCall;
        public DynmoPaymentsRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser,
                                      IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                      IConfigERARemarkCodesRepository configERARemarkCodesRepository,
                                      IMapper mapper)
                                      : base(errorCodes, dbContext, loggedUser)
        {
            this._configERARemarkCodesRepository = configERARemarkCodesRepository;
            this._mapper = mapper;
            _restApiCall = new RestApiCall();
        }

        
        public async Task<IDynmoPayments> AddNew(IDynmoPayments entity)
        {
            try
            {
                DynmoPayments tEntity = entity as DynmoPayments;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IDynmoPayments>> Get(IDynmoPaymentFilterDTO filter)
        {
            try
            {
                if (filter != null)
                {
                    filter.FromDate = (filter.FromDate != null || filter.FromDate != string.Empty) ? Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00") : filter.FromDate;
                    filter.ToDate = (filter.ToDate != null || filter.ToDate != string.Empty) ? Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59") : filter.ToDate;
                }

                var query = this.Connection
                              .From<DynmoPayments>();
                              

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IDynmoPaymentFilterDTO>.GetWhereClause(filter);

                // create where expression and concat with linq query where expression
                query.WhereExpression = "where " + whereExpression;

                var result = await this.Connection.SelectAsync<dynamic>(query);
                var dynmoResult = PractiZing.BusinessLogic.Common.Mapper<DynmoPayments>.MapList(result);

                var list= dynmoResult.Where(i=> i.AccountNumber != null && i.Phone!= "+15672978529");
                List<DynmoPayments> finalList = new List<DynmoPayments>();

                foreach (var item in list)
                {
                    if(!string.IsNullOrWhiteSpace(item.PaymentType))
                    {
                        if(item.PaymentType=="2")
                        {
                            if( string.IsNullOrWhiteSpace(item.TransactionId ) || string.IsNullOrWhiteSpace( item.PaymentConfirmationCode))
                            {
                                continue;
                            }
                        }
                    }

                    if(!string.IsNullOrWhiteSpace( item.TransactionDate))
                    {
                        item.TransactionDate = Convert.ToDateTime(item.TransactionDate).ToShortDateString();

                        string[] formats = {
            "yyyy-dd-MM",
            "yyyy/dd/MM",
            "dd/MMM/yyyy",
            "MMMM dd, yyyy"
        };

                        DateTime parsedDateTime;
                        if (DateTime.TryParseExact(item.DOB, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime))
                        {
                            item.DOB = parsedDateTime.ToShortDateString();
                        }
                        else
                        {
                            if(item.DOB!= "Invalid date")
                            item.DOB = Convert.ToDateTime(item.DOB).ToShortDateString();
                        }

                        //if(item.HistoryPaymentId!=null  && item.HistoryPaymentId != "TALBOT")
                        //{
                        //    item.TransactionDate = Convert.ToDateTime(item.TransactionDate.Substring(0, 15)).ToShortDateString();
                        //}
                        //else
                        //{
                        //    item.TransactionDate = Convert.ToDateTime(item.TransactionDate).ToShortDateString();
                        //}

                    }
                    finalList.Add(item);
                }
                return finalList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPortalPaymentEMRDTO>> GetUnMatchedPaymentsByBillingId(string billingId)
        {
            try
            {
                var list = await this.Connection.SelectAsync<DynmoPayments>(i=>i.EmrAccountNumber==billingId && i.IsImportInBilling==false);

                List<PortalPaymentEMRDTO> finalList = new List<PortalPaymentEMRDTO>();

                foreach (var item in list)
                {
                    if (!string.IsNullOrWhiteSpace(item.PaymentType))
                    {
                        if (item.PaymentType == "2")
                        {
                            if (string.IsNullOrWhiteSpace(item.TransactionId) || string.IsNullOrWhiteSpace(item.PaymentConfirmationCode))
                            {
                                continue;
                            }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(item.TransactionDate))
                    {
                        item.TransactionDate = Convert.ToDateTime(item.TransactionDate).ToShortDateString();
                    }

                    PortalPaymentEMRDTO portalPaymentEMRDTO = new PortalPaymentEMRDTO();
                    portalPaymentEMRDTO.Amount = Convert.ToDecimal(item.Amount);
                    portalPaymentEMRDTO.CreatedDate = item.CreatedDate;
                    portalPaymentEMRDTO.DosDate = item.DosDate;


                    string paymentMethod = "";

                    if (item.PaymentMethod == "1")
                        paymentMethod = "Copay";
                    else if (item.PaymentMethod == "2")
                        paymentMethod = "Patient Balance";                    

                    portalPaymentEMRDTO.PaymentMethod = paymentMethod;


                    string paymentType = "";

                    if (item.PaymentType == "1")
                        paymentType = "Cash";
                    else if (item.PaymentType == "2")
                        paymentType = "Credit Card";
                    else if (item.PaymentType == "3")
                        paymentType = "Credit Square";

                    portalPaymentEMRDTO.PaymentType = paymentType;

                    portalPaymentEMRDTO.Status = "UnMatched";

                    finalList.Add(portalPaymentEMRDTO);
                }
                return finalList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IDynmoPayments> Get(int id)
        {
            return await this.Connection.SingleAsync<DynmoPayments>(i => i.Id==id);
        }

        public async Task<IDynmoPayments> GetByPortalPaymentId(int portalPaymentId)
        {
            return await this.Connection.SingleAsync<DynmoPayments>(i => i.PortalPaymentId == portalPaymentId);
        }

        public async Task<bool> SendToEMR()
        {
            var lst= await this.Connection.SelectAsync<DynmoPayments>(i=>i.IsSendToEMR==null);


            return true;
        }

        public async Task<bool> SendOnlinePaymentData(List<IDynmoPayments> lst)
        {
            string val = await GetEMRToken();

            string emrUrl = this.LoggedUser.EMRURL;// + "PatientStickyNote/AddAdjustmentNotes";

            string jsondata = JsonConvert.SerializeObject(lst);
            HttpResponseMessage response = null;
            response = await _restApiCall.PostAsync(jsondata, "Need API from Nikunj--PatientStickyNote/AddAdjustmentNotes", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                await UpdateAfterSentToEMR(lst);
            }

            return true;
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

        public async Task<bool> UpdateAfterSentToEMR(List<IDynmoPayments> lst)
        {
            try
            {
                foreach (var item in lst)
                {
                    DynmoPayments tEntity = item as DynmoPayments;                    
                    tEntity.IsSendToEMR = true;                    
                    var query = this.Connection.From<DynmoPayments>()
                                .Update(u => new
                                {
                                    u.IsSendToEMR
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


        public async Task<int> Update(int dynmoPaymentid,string serviceProvider)
        {
            try
            {
                DynmoPayments tEntity = await this.Get(dynmoPaymentid) as DynmoPayments;
                tEntity.BillingServiceProvider = serviceProvider;
                tEntity.IsImportInBilling = true;
                tEntity.NotificationDate = DateTime.Now;
                tEntity.IsBadRecord = false;
                var query = this.Connection.From<DynmoPayments>()
                            .Update(u => new
                            {
                                u.IsImportInBilling,
                                u.BillingServiceProvider,
                                u.NotificationDate,
                                u.IsBadRecord
                            })
                            .Where(i => i.Id== dynmoPaymentid);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(int dynmoPaymentid, string serviceProvider, int? portalPaymentId)
        {
            try
            {
                DynmoPayments tEntity = await this.Get(dynmoPaymentid) as DynmoPayments;
                tEntity.BillingServiceProvider = serviceProvider;
                tEntity.IsImportInBilling = true;
                tEntity.NotificationDate = DateTime.Now;
                tEntity.IsBadRecord = false;
                tEntity.PortalPaymentId = portalPaymentId;
                var query = this.Connection.From<DynmoPayments>()
                            .Update(u => new
                            {
                                u.IsImportInBilling,
                                u.BillingServiceProvider,
                                u.NotificationDate,
                                u.IsBadRecord,
                                u.PortalPaymentId
                            })
                            .Where(i => i.Id == dynmoPaymentid);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateFromCatalystRCM(List<int> dynmoPaymentids)
        {
            try
            {
                foreach (var item in dynmoPaymentids)
                {
                    DynmoPayments tEntity = await this.Get(item) as DynmoPayments;
                    if (tEntity != null)
                    {
                        tEntity.BillingServiceProvider = "CatalystRCM";
                        tEntity.IsImportInBilling = true;
                        tEntity.NotificationDate = DateTime.Now;

                        var query = this.Connection.From<DynmoPayments>()
                                    .Update(u => new
                                    {
                                        u.IsImportInBilling,
                                        u.BillingServiceProvider,
                                        u.NotificationDate
                                    })
                                    .Where(i => i.Id == item);

                        await base.UpdateOnlyAsync(tEntity, query);
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateBadRecordFromCatalystRCM(List<int> dynmoPaymentids)
        {
            try
            {
                foreach (var item in dynmoPaymentids)
                {
                    DynmoPayments tEntity = await this.Get(item) as DynmoPayments;
                    if (tEntity != null)
                    {
                        tEntity.BillingServiceProvider = "CatalystRCM";
                        tEntity.IsBadRecordFromCatalystRCM = true;
                        tEntity.NotificationDate = DateTime.Now;

                        var query = this.Connection.From<DynmoPayments>()
                                    .Update(u => new
                                    {
                                        u.IsBadRecordFromCatalystRCM,
                                        u.BillingServiceProvider,
                                        u.NotificationDate
                                    })
                                    .Where(i => i.Id == item);

                        await base.UpdateOnlyAsync(tEntity, query);
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(int dynmoPaymentid, string serviceProvider,string errorMessage)
        {
            try
            {
                DynmoPayments tEntity = await this.Get(dynmoPaymentid) as DynmoPayments;
                tEntity.BillingServiceProvider = serviceProvider;
                tEntity.ErrorMessage = errorMessage;
                tEntity.NotificationDate = DateTime.Now;

                var query = this.Connection.From<DynmoPayments>()
                            .Update(u => new
                            {
                                u.ErrorMessage,
                                u.BillingServiceProvider,
                                u.NotificationDate
                            })
                            .Where(i => i.Id == dynmoPaymentid);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateException(int dynmoPaymentid, string errorMessage)
        {
            try
            {
                DynmoPayments tEntity = await this.Get(dynmoPaymentid) as DynmoPayments;
                
                tEntity.ErrorMessage = errorMessage;
                tEntity.NotificationDate = DateTime.Now;
                tEntity.IsBadRecord = true;
                var query = this.Connection.From<DynmoPayments>()
                            .Update(u => new
                            {
                                u.ErrorMessage    ,
                                u.NotificationDate,
                                u.IsBadRecord
                            })
                            .Where(i => i.Id == dynmoPaymentid);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTable> GetDynmoPaymentsForCatalystRCM()
        {
            try
            {

                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "usp_GetDynmoPaymentsForCatalystRCM";// '"+date +"'";,
                cmd.CommandType = CommandType.StoredProcedure;
                
                con.Open();
                var data = this.ExecuteDataSet(cmd);

                con.Close();
                cmd.Dispose();

                return data.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            using (var sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(ds);
            }

            return ds;
        }

        public async Task<int> Update(IDynmoPayments entity)
        {
            try
            {
                DynmoPayments tEntity = entity as DynmoPayments;

                /*Check user wants to make this Provider as a Default Provider.
                  In that case first check, there is already exist default Provider. if yes, then make previous Provider to No Default Provider
                  then update the given Provider as a Default Provider.*/
                tEntity.EmrAccountNumber = tEntity.AccountNumber;

              var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<DynmoPayments>()
                                       .Update(x => new
                                       {
                                           x.DOB,
                                           x.AccountNumber,
                                           x.PaymentMethod,
                                           x.EmrAccountNumber
                                       })
                                       .Where(i => i.Id==tEntity.Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> MoveInPortalPayment(int id)
        {
            try
            {
                var objDynmo = await this.Get(id);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
