using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PortalPaymentRepository : ModuleBaseRepository<PortalPayment>, IPortalPaymentRepository
    {
        IPatientRepository _patientRepository;
        IPracticeCentralPracticeRepository _practiceCentralPracticeRepository;
        ILoginUser _loggedUser;
        public PortalPaymentRepository(ValidationErrorCodes errorCodes,
                                       DataBaseContext dbContext,
                                       ILoginUser loggedUser,
                                       IPatientRepository patientRepository, IPracticeCentralPracticeRepository practiceCentralPracticeRepository) : base(errorCodes, dbContext, loggedUser)
        {
            this._patientRepository = patientRepository;
            this._practiceCentralPracticeRepository = practiceCentralPracticeRepository;
            this._loggedUser = loggedUser;
        }

        public async Task<int> Update(Guid portalPaymentUId)
        {
            try
            {
                PortalPayment tEntity = await this.Get(portalPaymentUId) as PortalPayment;
                tEntity.IsCommitted = true;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var query = this.Connection.From<PortalPayment>()
                            .Update(u => new
                            {
                                u.IsCommitted
                            })
                            .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPaymentUId);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowRefundException(string errorMessage)
        {
            await this.ThrowEntityException(new ValidationCodeResult(errorMessage));
        }

        public async Task<int> UpdateRefundAmount(Guid portalPaymentUId, decimal refundAmount)
        {
            try
            {
                PortalPayment tEntity = await this.Get(portalPaymentUId) as PortalPayment;
                //tEntity.IsCommitted = true;
                tEntity.RefundAmount = refundAmount;
                tEntity.IsRefundNeeded = refundAmount>0? true:false;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var query = this.Connection.From<PortalPayment>()
                            .Update(u => new
                            {
                                u.RefundAmount,
                                u.IsRefundNeeded
                            })
                            .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPaymentUId);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateLabAmount(Guid portalPaymentUId, decimal labAmount, int? labPortalPaymentId)
        {
            try
            {
                PortalPayment tEntity = await this.Get(portalPaymentUId) as PortalPayment;
                //tEntity.IsCommitted = true;
                tEntity.LabAmount = (tEntity.LabAmount.HasValue && tEntity.LabAmount.Value>0)? (tEntity.LabAmount+labAmount): labAmount;
                tEntity.Amount = tEntity.Amount- labAmount;
                tEntity.LabPortalPaymentId = labPortalPaymentId;
                tEntity.ModifiedBy = this.LoggedUser.UserName;
                tEntity.ModifiedDate = DateTime.Now;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var query = this.Connection.From<PortalPayment>()
                            .Update(u => new
                            {
                                u.LabAmount,
                                u.LabPortalPaymentId,
                                u.Amount,
                                u.ModifiedBy,
                                u.ModifiedDate
                            })
                            .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPaymentUId);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateRefundMade(Guid portalPaymentUId)
        {
            try
            {
                PortalPayment tEntity = await this.Get(portalPaymentUId) as PortalPayment;
                tEntity.IsCommitted = true;
                tEntity.HasRefund = true;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var query = this.Connection.From<PortalPayment>()
                            .Update(u => new
                            {
                                u.IsCommitted,
                                u.HasRefund
                            })
                            .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPaymentUId);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPortalPayment> Get(Guid uId)
        {
            return await this.Connection.SingleAsync<PortalPayment>(i => i.UId == uId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> MarkPaymentIdAsDeleted(IEnumerable<int> paymentIds)
        {
            try
            {
                foreach (var item in paymentIds)
                {
                    var portalPaymentChild = await this.Connection.SingleAsync<PortalPaymentChild>(i=>i.PaymentId==item);
                    if(portalPaymentChild!=null)
                    {
                        var portalPayment = await this.Connection.SingleAsync<PortalPayment>(i => i.Id == portalPaymentChild.PortalPaymentId);

                        decimal refundAmount = 0;
                        decimal paidAmount = await GetPaidAmount(item);
                        if(paidAmount>0)
                        {
                            if(portalPayment.Amount>paidAmount)
                            {
                                refundAmount += paidAmount;
                            }
                            if(portalPayment.RefundAmount==refundAmount)
                            {
                                portalPayment.RefundAmount = 0;
                            }
                        }

                        if (portalPayment != null)
                        {
                            portalPayment.PaymentId = null;
                            portalPayment.IsCommitted = false;
                            portalPayment.RefundAmount = refundAmount;
                            portalPayment.IsRefundNeeded = false;

                            var query = this.Connection.From<PortalPayment>()
                                .Update(u => new
                                {
                                    u.PaymentId,
                                    u.IsCommitted,
                                    u.RefundAmount,
                                    u.IsRefundNeeded
                                })
                                .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPayment.UId);
                            return await base.UpdateOnlyAsync(portalPayment, query);
                        }
                    }                    
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> MarkPaymentIdAsDeleted(IEnumerable<int> paymentIds,decimal paidAmount)
        {
            try
            {
                foreach (var item in paymentIds)
                {
                    var portalPaymentChild = await this.Connection.SingleAsync<PortalPaymentChild>(i => i.PaymentId == item);
                    if (portalPaymentChild != null)
                    {
                        var portalPayment = await this.Connection.SingleAsync<PortalPayment>(i => i.Id == portalPaymentChild.PortalPaymentId);

                        decimal refundAmount = 0;
                        //decimal paidAmount = await GetPaidAmount(item);
                        if (paidAmount > 0)
                        {
                            refundAmount= portalPayment.RefundAmount;

                            if (portalPayment.Amount > paidAmount)
                            {
                                refundAmount += paidAmount;
                            }
                            if (portalPayment.Amount == refundAmount)
                            {
                                refundAmount = 0;
                            }
                        }

                        if (portalPayment != null)
                        {
                            portalPayment.PaymentId = null;
                            portalPayment.IsCommitted = false;
                            portalPayment.RefundAmount = refundAmount;
                            portalPayment.IsRefundNeeded = false;

                            var query = this.Connection.From<PortalPayment>()
                                .Update(u => new
                                {
                                    u.PaymentId,
                                    u.IsCommitted,
                                    u.RefundAmount,
                                    u.IsRefundNeeded
                                })
                                .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPayment.UId);
                            return await base.UpdateOnlyAsync(portalPayment, query);
                        }
                    }
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPortalPayment>> Get(int patientId)
        {
            var query = this.Connection.From<PortalPayment>()
                        .LeftJoin<PortalPayment, DynmoPayments>((p, d) => p.Id == d.PortalPaymentId)
                        .Join<PortalPayment, Payment>((p, d) => p.PaymentId == d.Id)
                        .Select<PortalPayment, DynmoPayments>((i, j) => new
                        {
                            i,
                            j.PaymentType,
                            j.PaymentMethod
                        })
                        .Where<PortalPayment, DynmoPayments>((i, j) => i.PatientId == patientId && i.PracticeId == LoggedUser.PracticeId && i.IsCommitted == true 
                        && i.IsDeleted!= true);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);

            return (Common.Mapper<PortalPayment>.MapList(queryResult));


            //return await this.Connection.SelectAsync<PortalPayment>(i => i.PatientId == patientId && i.PracticeId == LoggedUser.PracticeId && i.IsCommitted == true);
        }

        public async Task<IEnumerable<IPortalPayment>> Get(IPortalPaymentFilterDTO filter)
        {
            try
            {

                if (filter != null)
                {
                    filter.FromDate = (filter.FromDate != null || filter.FromDate != string.Empty) ? Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00") : filter.FromDate;
                    filter.ToDate = (filter.ToDate != null || filter.ToDate != string.Empty) ? Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59") : filter.ToDate;
                }

                var query = this.Connection
                              .From<PortalPayment>()
                              .Join<PortalPayment, Patient>((pp, p) => pp.PatientId == p.Id,NoLockTableHint.NoLock)
                              .LeftJoin<PortalPayment, DynmoPayments>((p, d) => p.Id == d.PortalPaymentId, NoLockTableHint.NoLock)
                              .Select<PortalPayment, Patient, DynmoPayments>((pp, pt, dp) => new
                              {
                                  pp,
                                  PatientUId = pt.UId,
                                  FirstName = pt.FirstName,
                                  LastName = pt.LastName,
                                  MobileNumber = pt.MobilePhoneNumber,
                                  dp.PaymentType,
                                  dp.PaymentMethod,
                                  BillingId=pt.BillingID
                              })
                              .Where<Patient, PortalPayment>((i,j) => i.PracticeId == LoggedUser.PracticeId && j.IsDeleted==false);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IPortalPaymentFilterDTO>.GetWhereClause(filter);

                if (filter.IsRefundedRecord == "1")
                {
                    whereExpression = "IsRefundNeeded=1 and HasRefund=0";
                }
                //whereExpression = "IsRefundNeeded=1 and HasRefund=0";

                // create where expression and concat with linq query where expression
                query.WhereExpression = string.IsNullOrEmpty(whereExpression) ? query.WhereExpression : query.WhereExpression + " AND " + whereExpression;

                var result = await this.Connection.SelectAsync<dynamic>(query);
                var patientResult = PractiZing.BusinessLogic.Common.Mapper<PortalPayment>.MapList(result);

                //foreach (var item in patientResult)
                //{
                //    if (!item.LabAmount.HasValue)
                //    {
                //        item.LabAmount = 0;
                //    }

                //    var paymentList = await this._patientRepository.GetChargesForPortalPayment(item.UId);
                //    if (paymentList.Count() > 0)
                //    {
                //        item.PostedAmount = paymentList.Sum(i => i.PaidAmount);
                //    }
                //    else
                //    {
                //        item.PostedAmount = 0;
                //    }
                //}

                return patientResult.Where(i=>i.Amount>0);
            }
            catch
            {
                throw;
            }
        }


        public async Task<IEnumerable<IPortalPaymentEMRDTO>> GetUnPostedPaymentByPatientId(string billingId)
        {
            try
            {

                var query = this.Connection
                              .From<PortalPayment>()
                              .Join<PortalPayment, Patient>((pp, p) => pp.PatientId == p.Id)
                              .LeftJoin<PortalPayment, DynmoPayments>((p, d) => p.Id == d.PortalPaymentId)
                              .Select<PortalPayment, Patient, DynmoPayments>((pp, pt, dp) => new
                              {
                                  pp.Amount,
                                  dp.CreatedDate,
                                  dp.DosDate,
                                  dp.PaymentMethod,
                                  dp.PaymentType,
                                  pp.RefundAmount
                              })
                              .Where<PortalPayment,Patient>((i,p) => p.PracticeId == LoggedUser.PracticeId && p.BillingID== billingId
                              && i.IsCommitted==false && i.IsDeleted !=true);

                var result = await this.Connection.SelectAsync<dynamic>(query);
                var list = PractiZing.BusinessLogic.Common.Mapper<PortalPaymentEMRDTO>.MapList(result);

                

                foreach (var item in list)
                {                    
                    string paymentMethod = "";

                    if (item.PaymentMethod == "1")
                        paymentMethod = "Copay";
                    else if (item.PaymentMethod == "2")
                        paymentMethod = "Patient Balance";

                    item.PaymentMethod = paymentMethod;

                    string paymentType = "";

                    if (item.PaymentType == "1")
                        paymentType = "Cash";
                    else if (item.PaymentType == "2")
                        paymentType = "Credit Card";
                    else if (item.PaymentType == "3")
                        paymentType = "Credit Square";

                    item.PaymentType = paymentType;
                    item.Status = "UnPosted";
                }
                return list;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPayment(int paymentId)
        {
            var query = this.Connection.From<ChargesReportData>().
                Join<ChargesReportData, PaymentCharge>((i, j) => i.ChargeId == j.ChargeId,NoLockTableHint.NoLock).
                Join<PaymentCharge, Payment>((i, j) => i.PaymentId == j.Id, NoLockTableHint.NoLock)
                .SelectDistinct<ChargesReportData, PaymentCharge>((i, j) => new
                {
                    i.AccessionNumber,
                    i.DosDate,
                    i.CptCode,
                    i.ChargeAmount,
                    i.PerforingProviderName,
                    j.PaidAmount,
                    j.ModifiedBy,
                    j.ModifiedDate
                }
            ).Where<PaymentCharge>(i => i.PaymentId == paymentId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Common.Mapper<PortalPaymentChargesDTO>.MapList(queryResult);

            return result.OrderBy(i => i.DOSDate);
        }

        private async Task<decimal> GetPaidAmount(int paymentId)
        {
            var query = this.Connection.From<ChargesReportData>().
                Join<ChargesReportData, PaymentCharge>((i, j) => i.ChargeId == j.ChargeId, NoLockTableHint.NoLock).
                Join<PaymentCharge, Payment>((i, j) => i.PaymentId == j.Id, NoLockTableHint.NoLock)
                .SelectDistinct<ChargesReportData, PaymentCharge>((i, j) => new
                {   
                    j.PaidAmount
                }
            ).Where<PaymentCharge>(i => i.PaymentId == paymentId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Common.Mapper<PortalPaymentChargesDTO>.MapList(queryResult);

            return result.Sum(i=>i.PaidAmount);
        }

        public async Task<StripeRequestOptions> GetStripeRequestOptionsForPractice(string practiceCode)
        {

            var practice = await this._practiceCentralPracticeRepository.GetPracticeByPracticeCode(practiceCode);
            var stripeRequestOptions = new StripeRequestOptions()
            {
                ApiKey = practice.StripeKey,
            };
            return stripeRequestOptions;
        }

        public async Task<StripeRefund> RefundCharge(IPortalPayment entity, decimal amount, string reasons)
        {
            try
            {
                string chargeid = entity.ChargeId;
                // need to do dynamic LoggedUser.PracticeCode
                //if( string.IsNullOrWhiteSpace( this._loggedUser.StripePracticeName))
                //{
                //    return null;
                //}
                var requestOptions = await this.GetStripeRequestOptionsForPractice("lucidpay");

                // we can get the payment from chargeId
                var service = new StripeChargeService();
                var obj = service.Get(chargeid, requestOptions);

                var refundcharge = new StripeRefundCreateOptions();
                refundcharge.Amount = Convert.ToInt32(amount * 100);
                refundcharge.Reason = StripeRefundReasons.RequestedByCustomer;
                refundcharge.Metadata = new Dictionary<string, string>() { { "customer_reason", reasons } };
                StripeRefundService stripeRefundService = new StripeRefundService();
                StripeRefund stripeRefund = stripeRefundService.Create(chargeid, refundcharge, requestOptions);

                return stripeRefund;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IPortalPayment> AddNew(IPortalPayment entity)
        {
            try
            {
                PortalPayment tEntity = entity as PortalPayment;

                if (entity.PatientId <= 0)
                {
                    var patientData = await this._patientRepository.Get(tEntity.PatientUId);
                    tEntity.PatientId = patientData.Id;
                    tEntity.CreatedDate = DateTime.Now;
                }
                else
                {
                    //need to check with valid data and need to update the cardid
                    //var requestOptions = await this.GetStripeRequestOptionsForPractice("lucidpay");
                    //var service = new StripeChargeService();
                    //var obj = service.Get(entity.ChargeId, requestOptions);
                }

                tEntity.PracticeId = LoggedUser.PracticeId;

                tEntity.IsCommitted = false;
                if (tEntity.IsRefund.HasValue && tEntity.IsRefund.Value)
                {
                    tEntity.IsCommitted = true;
                }
                tEntity.HasRefund = false;
                tEntity.IsRefundNeeded = false;
                tEntity.IsDeleted = false;

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

        public async Task<StripeRefund> RefundChargeByChargeId(string chargeid, string reasons)
        {
            try
            {
                var requestOptions = await this.GetStripeRequestOptionsForPractice("lucidpay");

                // we can get the payment from chargeId
                var service = new StripeChargeService();
                var obj = service.Get(chargeid, requestOptions);

                var refundcharge = new StripeRefundCreateOptions();
                refundcharge.Amount = obj.Amount; //Convert.ToInt32(amount * 100);
                refundcharge.Reason = StripeRefundReasons.RequestedByCustomer;
                refundcharge.Metadata = new Dictionary<string, string>() { { "customer_reason", reasons } };
                StripeRefundService stripeRefundService = new StripeRefundService();
                StripeRefund stripeRefund = stripeRefundService.Create(chargeid, refundcharge, requestOptions);

                return stripeRefund;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdatePaymentId(Guid portalPaymentUId, int paymentId,decimal totalPaidAmount=0)
        {
            try
            {
                PortalPayment tEntity = await this.Get(portalPaymentUId) as PortalPayment;
                tEntity.PaymentId = paymentId;
                if (totalPaidAmount == tEntity.Amount)
                {
                    tEntity.IsCommitted = true;
                    tEntity.IsRefundNeeded = false;
                    tEntity.RefundAmount = 0;
                }                    
                else
                {
                    tEntity.IsRefundNeeded = true;
                    tEntity.RefundAmount = tEntity.Amount - totalPaidAmount;
                }
                    

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var query = this.Connection.From<PortalPayment>()
                            .Update(u => new
                            {
                                u.PaymentId, 
                                u.IsCommitted,
                                u.IsRefundNeeded,
                                u.RefundAmount
                            })
                            .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPaymentUId);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdatePaymentId(Guid portalPaymentUId, int paymentId,bool isCommitted)
        {
            try
            {
                PortalPayment tEntity = await this.Get(portalPaymentUId) as PortalPayment;
                tEntity.PaymentId = paymentId;
                tEntity.IsCommitted = isCommitted;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var query = this.Connection.From<PortalPayment>()
                            .Update(u => new
                            {
                                u.PaymentId,
                                u.IsCommitted
                            })
                            .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == portalPaymentUId);

                return await base.UpdateOnlyAsync(tEntity, query);
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowAmountNotEqual()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CardPayemntValidation]));
        }

        public async Task ThrowPostPaymentGreaterValidation()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PostPaymentGreaterValidation]));
        }

        public async Task ThrowPaymentAmountGreaterThanActualOnline()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.OnlinePayemntCanNotEceedAcutal]));
        }

        public async Task ThrowZeroPostedPayment()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AvoidPostedZeroPayment]));
        }

        //public async Task ThrowAmountNotEqual()
        //{
        //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CardPayemntValidation]));
        //}

        public async Task ThrowAmountNotEqualThenOnlySelectSignlePayment()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CardPayemntValidationForSingleSelection]));
        }

        public async Task<int> UpdateIsCommmited(IEnumerable<int> ids)
        {
            try
            {
                foreach (var item in ids)
                {
                    PortalPayment tEntity = await this.GetById(item) as PortalPayment;
                    tEntity.IsCommitted = true;

                    var errors = await this.ValidateEntityToUpdate(tEntity);
                    if (errors.Count() > 0)
                        await this.ThrowEntityException(errors);

                    var query = this.Connection.From<PortalPayment>()
                                .Update(u => new
                                {
                                    u.IsCommitted
                                })
                                .Where(i => i.PracticeId == LoggedUser.PracticeId && i.Id == item);

                     await base.UpdateOnlyAsync(tEntity, query);
                }

                return 0;
                
            }
            catch
            {
                throw;
            }
        }
    }
}

