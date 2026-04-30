using AutoMapper;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.ERAService.Tables;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PaymentRepository : ModuleBaseRepository<Payment>, IPaymentRepository
    {

        private IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private IPaymentChargeRepository _paymentChargeRepository;
        private IPatientRepository _patientRepository;
        private IDepositTypeRepository _depositTypeRepository;
        //private IVoucherRepository _voucherRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IMapper _mapper;

        public PaymentRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                 IPaymentChargeRepository paymentChargeRepository,
                                 IPatientRepository patientRepository,
                                 IDepositTypeRepository depositTypeRepository,
                                 IInsuranceCompanyRepository insuranceCompanyRepository,
                                 IMapper mapper)
                                 : base(errorCodes, dbContext, loggedUser)
        {
            this._paymentAdjustmentRepository = paymentAdjustmentRepository;
            this._paymentChargeRepository = paymentChargeRepository;
            this._patientRepository = patientRepository;
            this._depositTypeRepository = depositTypeRepository;
            // this._voucherRepository = voucherRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// get method by patient id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPayment>> Get(int patientId)
        {
            return await this.Connection.SelectAsync<Payment>(i => i.PatientId == patientId);
        }

        public async Task ThrowError(int count)
        {
            if (count > 0)
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PaymentExist]));
        }

        /// <summary>
        /// method to add new payment
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IPayment> AddNew(IPayment entity)
        {
            try
            {
                Payment tEntity = entity as Payment;

                // add or update method for payment charge. this method add or update charge payment
                await this._paymentChargeRepository.AddOrUpdate(entity.PaymentCharges);

                // add or update method for payment adjustment. this method add or update charge payment adjustment
                await this._paymentAdjustmentRepository.AddOrUpdate(entity.PaymentAdjustments);

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                if(tEntity.Amount<0)
                {
                    tEntity.IsReversed = true;
                }

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPayment> AddNewBulkPayment(IPayment entity)
        {
            try
            {
                Payment tEntity = entity as Payment;

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

        public async Task<int> AddOrUpdate(IEnumerable<IPayment> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (entity.Id != 0)
                        await this.Update(entity);
                    else
                        await this.AddNew(entity);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(IEnumerable<Guid> paymentIds)
        {
            try
            {
                foreach (var item in paymentIds)
                {
                    await this.UpdateDeleteCommets(item);
                }
                return await this.Connection.DeleteAsync<Payment>(i => paymentIds.Contains(i.UId));
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int paymentId)
        {
            try
            {
                await this.UpdateDeleteCommets(paymentId);
                return await this.Connection.DeleteAsync<Payment>(i => i.Id == paymentId);
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> UpdateDeleteCommets(Guid Id)
        {
            try
            {
                Payment tEntity = await this.GetByUId(Id) as Payment;
                tEntity.DeleteComments = "Payment Deleted by : "+ this.LoggedUser.UserName;
                tEntity.ModifiedDate = DateTime.Now;
                tEntity.ModifiedBy = this.LoggedUser.UserName;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Payment>()
                                           .Update(x => new
                                           {
                                               x.DeleteComments,
                                               x.ModifiedBy,
                                               x.ModifiedDate
                                           })
                                           .Where<Payment>(i => i.UId == Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> UpdateDeleteCommets(int Id)
        {
            try
            {
                Payment tEntity = await this.GetById(Id) as Payment;
                tEntity.DeleteComments = "Payment Deleted by : " + this.LoggedUser.UserName;
                tEntity.ModifiedDate = DateTime.Now;
                tEntity.ModifiedBy = this.LoggedUser.UserName;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Payment>()
                                           .Update(x => new
                                           {
                                               x.DeleteComments,
                                               x.ModifiedBy,
                                               x.ModifiedDate
                                           })
                                           .Where<Payment>(i => i.Id == Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }


        public async Task<IPayment> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<Payment>(i => i.UId == UId);
        }

        public async Task<IPayment> GetById(long Id)
        {
            return await this.Connection.SingleAsync<Payment>(i => i.Id == Id);
        }

        private async Task<IEnumerable<IPayment>> GetByIds(IEnumerable<long> Ids)
        {
            return await this.Connection.SelectAsync<Payment>(i => Ids.Contains(i.Id));
        }

        public async Task<IEnumerable<IPayment>> GetPaymetnsForACK()
        {
            //return await this.Connection.SelectAsync<Payment>(i => i.IsSendAck==null && i.IsCommitted==true);

            var query = this.Connection.From<Payment>()
                       .Join<Payment, Voucher>((p, pai) => p.VoucherId == pai.Id)                       
                       .Select<Payment>((pay) => new
                       {
                           pay                           
                       })
                       .Where<Payment,Voucher>((i,v) => i.IsSendAck == null && v.IsCommitted == true);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Payment>.MapList(queryResult);
            return result;
        }

        public async Task<IEnumerable<IReversePaymentReportDTO>> GetReversPayments()
        {
            var query = this.Connection.From<ChargesReportData>()                
                .Select<ChargesReportData>((crd)=>new                
                {
                    crd.ChargeAmount,
                    crd.ChargeId,
                    crd.PatientId,
                    crd.BillingID,
                    crd.FirstName,
                    crd.LastName,
                    Provider=crd.PerforingProviderName,
                    crd.DosDate,
                    crd.CptCode,
                    TakeBackAmount=crd.DueAmount,                    
                    crd.DueAmount,
                    AdjustCode=crd.ReasonCode1,
                    AdjustReason=crd.AdjustmentCode,
                    //RemarkCode= crd.,                    
                    ActualPayment=crd.Payment,
                    InsuranceCompany=crd.PrimaryInsuranceCompanyName,
                    AccessionNumber=crd.AccessionNumber,
                    crd.PatientUId,
                    AdjustmentAmount=crd.Adjustment,
                    crd.DueBy,
                    crd.PaymentPostDate,
                    crd.RemitDate
                }).Where<ChargesReportData>(i=>i.DueAmount<0 && i.Deleted.ToLower()=="no");

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ReversePaymentReportDTO>.MapList(queryResult);

            return result.OrderBy(i=>i.PatientId);
        }

        public async Task<IEnumerable<IReversePaymentReportDTO>> GetReversPayments_BACKUP()
        {
            var query = this.Connection.From<PaymentCharge>()
                .Join<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id)
                .Join<PaymentCharge, ChargesReportData>((pc, c) => pc.ChargeId == c.ChargeId)
                .Join<Payment, Voucher>((pc, v) => pc.VoucherId == v.Id)
                .LeftJoin<Payment, InsuranceCompany>((pc, v) => pc.PatientInsuranceCompanyId == v.Id)
                .LeftJoin<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId)
                .LeftJoin<PaymentCharge, PaymentRemarkCode>((pc, prc) => pc.Id == prc.PaymentChargeId)
                .LeftJoin<PaymentRemarkCode, ConfigERARemarkCodes>((prc, cerc) => prc.RemarkCode == cerc.RemarkCode)
                .LeftJoin<PaymentAdjustment, ConfigAdjustmentReasonCode>((pa, carc) => pa.ReasonCode == (carc.GroupCode + carc.Code))
                .Select<PaymentCharge, ChargesReportData, Voucher, PaymentAdjustment, ConfigAdjustmentReasonCode, ConfigERARemarkCodes, InsuranceCompany>((pc, crd, vc, pa, carc, cec, ins) => new
                //.Select<PaymentCharge, ChargesReportData, Voucher, PaymentAdjustment>((pc, crd, vc, pa) => new
                {
                    crd.ChargeAmount,
                    crd.ChargeId,
                    crd.PatientId,
                    crd.BillingID,
                    crd.FirstName,
                    crd.LastName,
                    Provider = crd.PerforingProviderName,
                    crd.DosDate,
                    crd.CptCode,
                    TakeBackAmount = pc.PaidAmount,
                    PaymentDate = pc.ModifiedDate,
                    CheckNumber = vc.ReferenceNo,
                    crd.DueAmount,
                    AdjustCode = pa.ReasonCode,
                    AdjustReason = carc.Description,
                    RemarkCode = cec.RemarkCode,
                    RemarkMessage = cec.RemarkMessage,
                    ActualPayment = crd.Payment,
                    InsuranceCompany = ins.CompanyName,
                    AccessionNumber = crd.AccessionNumber,
                    crd.PatientUId
                }).Where<Payment, PaymentCharge>((i, j) => i.IsReversed == true && j.PaidAmount < 0);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ReversePaymentReportDTO>.MapList(queryResult);

            return result.OrderBy(i => i.PatientId);
        }

        /// <summary>
        /// get payment's by voucher id and patient id
        /// </summary>
        /// <param name="voucherId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPayment>> GetByVoucher(int voucherId, string patientUId)
        {
            var patientId = patientUId == string.Empty ? 0 : (await this._patientRepository.GetByUId(Guid.Parse(patientUId))).Id;

            var query = this.Connection.From<Payment>()
                        .LeftJoin<Payment, Patient>((p, pai) => p.PatientId == pai.Id)
                        .LeftJoin<Payment, InsuranceCompany>((p, i) => p.DepositInsuranceCompanyId != null && p.DepositInsuranceCompanyId == i.Id, this.Connection.JoinAlias("DepositInsuranceCompany"))
                        .LeftJoin<Payment, InsuranceCompany>((p, i) => p.PatientInsuranceCompanyId == i.Id, this.Connection.JoinAlias("PatientInsuranceCompany"))
                        .SelectDistinct<Payment, InsuranceCompany, Patient>((pay, ins, pat) => new
                        {
                            pay,
                            DepositInsuranceCompanyUId = Sql.JoinAlias(ins.UId, "DepositInsuranceCompany"),
                            PatientInsuranceCompanyUId = Sql.JoinAlias(ins.UId, "PatientInsuranceCompany"),
                            FirstName = pat.FirstName,
                            LastName = pat.LastName
                        })
                        .Where<Payment>(i => i.VoucherId == voucherId && (patientId == 0 || i.PatientId == patientId));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Payment>.MapList(queryResult);
            //var patientId = patientUId == string.Empty ? 0 : (await this._patientRepository.GetByUId(Guid.Parse(patientUId))).Id;

            //var result = await this.Connection.SelectAsync<Payment>(i => i.VoucherId == voucherId && (patientId == 0 || i.PatientId == patientId));

            //List<int> ids = new List<int>();
            //ids.AddRange(result.Select(i => i.PatientInsuranceCompanyId));
            //ids.AddRange(result.Where(j => j.DepositInsuranceCompanyId != null).Select(i => i.DepositInsuranceCompanyId.Value));

            //var insuranceCompanies = await this._insuranceCompanyRepository.GetById(ids);

            //int[] patientIds = result.Select(i => i.PatientId).ToArray();
            //var patientData = await this._patientRepository.GetByIds(patientIds);
            //foreach (var item in result)
            //{
            //    // this method get patient detail and add into payment model.
            //    var _patient = patientData.Where(i => i.Id == item.PatientId).FirstOrDefault();
            //    if (_patient != null)
            //    {
            //        item.DepositInsuranceCompanyUId = insuranceCompanies.FirstOrDefault(i => i.Id == item.DepositInsuranceCompanyId)?.UId;
            //        item.PatientInsuranceCompanyUId = insuranceCompanies.FirstOrDefault(i => i.Id == item.PatientInsuranceCompanyId) != null ?
            //                                insuranceCompanies.FirstOrDefault(i => i.Id == item.PatientInsuranceCompanyId).UId : new Guid();
            //        item.FirstName = _patient.FirstName;
            //        item.LastName = _patient.LastName;
            //    }
            //}

            return result;
        }

        /// <summary>
        /// get payment's by voucher id and patient id
        /// </summary>
        /// <param name="voucherId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPaymentCharge>> ValidateDuplicatePayments(int voucherId, int patientId, List<ICharges> charges,bool IsReversePayment,string payerControlNumber)
        {
            List<string> chargeIds = new List<string>();
            foreach (var item in charges)
            {
                if (item.PaidAmount > 0)
                    chargeIds.Add(item.Id.ToString());
            }
            
            var query = this.Connection.From<PaymentCharge>()
                        .Join<PaymentCharge, Payment>((pc, p) => p.Id == pc.PaymentId)
                        .Join<Payment, Voucher>((p, v) => p.VoucherId==v.Id)                        
                        .Select<PaymentCharge>((x) => new
                        {
                            x
                        })
                        .Where<Payment,Voucher,PaymentCharge>((p,v,c) =>p.PatientId==patientId && v.Id==voucherId && p.PayorControl== payerControlNumber && p.IsReversed==IsReversePayment && chargeIds.Contains(c.ChargeId.ToString()));
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PaymentCharge>.MapList(queryResult);            

            return result;
        }

        /// <summary>
        /// get payment's by voucher id and patient id
        /// </summary>
        /// <param name="voucherId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPayment>> Get(IEnumerable<int> voucherIds, string patientUId)
        {
            var patientId = patientUId == string.Empty ? 0 : (await this._patientRepository.GetByUId(Guid.Parse(patientUId))).Id;

            var query = this.Connection.From<Payment>()
                        .LeftJoin<Payment, Patient>((p, pai) => p.PatientId == pai.Id)
                        .LeftJoin<Payment, InsuranceCompany>((p, i) => p.DepositInsuranceCompanyId != null && p.DepositInsuranceCompanyId == i.Id, this.Connection.JoinAlias("DepositInsuranceCompany"))
                        .LeftJoin<Payment, InsuranceCompany>((p, i) => p.PatientInsuranceCompanyId == i.Id, this.Connection.JoinAlias("PatientInsuranceCompany"))
                        .SelectDistinct<Payment, InsuranceCompany, Patient>((pay, ins, pat) => new
                        {
                            pay,
                            DepositInsuranceCompanyUId = Sql.JoinAlias(ins.UId, "DepositInsuranceCompany"),
                            PatientInsuranceCompanyUId = Sql.JoinAlias(ins.UId, "PatientInsuranceCompany"),
                            FirstName = pat.FirstName,
                            LastName = pat.LastName
                        })
                        .Where<Payment>(i => voucherIds.Contains(i.VoucherId) && (patientId == 0 || i.PatientId == patientId)); ;

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Payment>.MapList(queryResult);
            //var result = await this.Connection.SelectAsync<Payment>(i => voucherIds.Contains(i.VoucherId) && (patientId == 0 || i.PatientId == patientId));

            //List<int> ids = new List<int>();
            //ids.AddRange(result.Select(i => i.PatientInsuranceCompanyId));
            //ids.AddRange(result.Where(j => j.DepositInsuranceCompanyId != null).Select(i => i.DepositInsuranceCompanyId.Value));

            //var insuranceCompanies = await this._insuranceCompanyRepository.GetById(ids.Distinct());

            //int[] patientIds = result.Select(i => i.PatientId).ToArray();
            //var patientData = await this._patientRepository.GetByIds(patientIds);

            //foreach (var item in result)
            //{
            //    item.DepositInsuranceCompanyUId = insuranceCompanies.FirstOrDefault(i => i.Id == item.DepositInsuranceCompanyId)?.UId;
            //    item.PatientInsuranceCompanyUId = insuranceCompanies.FirstOrDefault(i => i.Id == item.PatientInsuranceCompanyId) != null ?
            //                            insuranceCompanies.FirstOrDefault(i => i.Id == item.PatientInsuranceCompanyId).UId : new Guid();

            //    // this method get patient detail and add into payment model.
            //    var _patient = patientData.Where(i => i.Id == item.PatientId).FirstOrDefault();
            //    if (_patient != null)
            //    {
            //        item.FirstName = _patient.FirstName;
            //        item.LastName = _patient.LastName;
            //    }
            //}

            return result;
        }

        public async Task<IEnumerable<IPayment>> GetByVoucherIdForReversePayment(int voucherId)
        {
            var query = this.Connection.From<Payment>()
                        .LeftJoin<Payment, ERAClaim>((p, erc) => p.Id.ToString() == erc.PaymentUID)                        
                        .SelectDistinct<Payment, ERAClaim>((pay, erc) => new
                        {
                            pay,
                            erc.PatientControlNumber
                        })
                        .Where<Payment>(i=>i.VoucherId==voucherId && i.IsReversed==true); 

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Payment>.MapList(queryResult);
            

            return result;
        }

        public async Task<IEnumerable<IPayment>> GetByVoucherId(int voucherId)
        {
            return await this.Connection.SelectAsync<Payment>(i => i.VoucherId == voucherId);
        }

        public async Task<int> Update(IPayment entity)
        {
            try
            {
                Payment tEntity = entity as Payment;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Payment>()
                                           .Update(x => new
                                           {
                                               x
                                           })
                                           .Where(i => i.VoucherId == entity.VoucherId && i.UId == entity.UId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdatePaidAmount(Guid Id)
        {
            try
            {
                Payment tEntity = await this.GetByUId(Id) as Payment;
                tEntity.Amount = 0;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Payment>()
                                           .Update(x => new
                                           {
                                               x.Amount
                                           })
                                           .Where<Payment>(i => i.UId == Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateSentAckToEMR(int Id)
        {
            try
            {
                Payment tEntity = await this.GetById(Id) as Payment;
                tEntity.IsSendAck = true;
                
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Payment>()
                                           .Update(x => new
                                           {
                                               x.IsSendAck
                                           })
                                           .Where<Payment>(i => i.Id == Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get payments with its payments on charges, adjustments and remark codes.
        /// </summary>
        /// <param name="voucherIds"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPaymentDTO>> GetPayment(IEnumerable<int> voucherIds, IBulkPaymentFilter filter)
        {
            var query = this.Connection.From<Payment>()
                        .Join<Payment, Voucher>((p, v) => p.VoucherId == v.Id/* && voucherIds.Contains(p.VoucherId)*/ && v.PaymentSourceCD != PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString().ToLower(), NoLockTableHint.NoLock)
                        .LeftJoin<Payment, Patient>((p, pt) => p.PatientId == pt.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Patient, PatientCase>((p, pc) => p.DefaultCaseId == pc.Id, NoLockTableHint.NoLock)
                       .SelectDistinct<Payment, Voucher, Patient, PatientCase>((p, v, pt, pc) => new
                       {
                           PatientName = pt.FirstName,
                           PatientId = pt.Id,
                           NonAccAdjustment = p.NonAccAdjustment,
                           VoucherId = v.Id,
                           PaymentId = p.Id,
                           PaidAmount = p.Amount,
                           IsReversed = p.IsReversed,
                           PaymentGUId = p.UId,
                           IsCommitted = p.IsCommitted,
                           VoucherUId = v.UId,
                           PatientUId = pt.UId,
                           PatientCaseUId = pc.UId,
                           CreatedDate = p.CreatedDate
                       })
                       .Where<Payment>(i => voucherIds.Contains(i.VoucherId));

            //map filter param into payment filter model
            var resultFilter = _mapper.Map<PaymentFilter>(filter);
            resultFilter.IsCommitted = resultFilter.IsCommitted == "null" ? null : resultFilter.IsCommitted;
            resultFilter.PaymentSourceCD = resultFilter.PaymentSourceCD == "null" ? null : resultFilter.PaymentSourceCD;

            string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
            string countExpression = query.ToCountStatement();
            string whereExpression = await WhereClauseProvider<IPaymentFilter>.GetWhereClause(resultFilter);

            // create where expression and concat with linq query where expression
            query.WhereExpression = string.IsNullOrEmpty(whereExpression) ? query.WhereExpression : query.WhereExpression + " AND " + whereExpression;

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PaymentDTO>.MapList(queryResult);

            // get payment ids and get all payment's with its adjsutment's and remark codes
            int[] paymentIds = result.Select(i => i.PaymentId).ToArray();
            var paymentResult = await this._paymentChargeRepository.GetPaymentCharge(paymentIds);

            // start for loop to calculate all amount's 
            result.ToList().ForEach((item) =>
            {
                var paymentAmount = paymentResult.Where(i => i.PaymentId == item.PaymentId);
                item.BonusAmount = paymentAmount.Sum(i => i.BonusAmount);
                // this is used to insert payments according to its payment id.
                item.ChargeDTOs = paymentAmount;
                // adjsutments sum where codes are copay and coinsurance
                item.PatientResponsibility = paymentAmount.Sum(i => i.PatientResponsibility);
                // total sum of charge amount
                item.TotalChargeAmount = paymentAmount.Sum(i => i.ChargeAmount);
                // total sum of credit amount i.e where payment is reversed == false
                // reversed payment means correct the payment had done by mistake previously. by doing the payment with minus amount.
                item.TotalCrChargeAmount = paymentAmount.Sum(i => i.CrChargeAmount);
                // total sum of credit amount i.e where payment is reversed == true.
                // reversed payment means correct the payment had done by mistake previously. by doing the payment with minus.
                item.TotalDrChargeAmount = paymentAmount.Sum(i => i.DrChargeAmount);
                // total accountable adjustment amount.
                item.TotalAdjustmentAmount = paymentAmount.Sum(i => i.TotalAdjustmentAmount);
                // total unaccountable adjustment amount.
                item.NonAccAdjustment = paymentAmount.Sum(i => i.NonAccAdjustment);
                // difference amount = charge amount - total reversed credit amount + adjsutment amount - total dr reversed amount
                item.DifferenceAmount = item.TotalChargeAmount - ((item.TotalCrChargeAmount + item.TotalAdjustmentAmount + item.PatientResponsibility) - item.TotalDrChargeAmount) - item.NonAccAdjustment;
            });

            return result;
        }

        public async Task<IEnumerable<IPaymentDTO>> GetBulkPaymentPayment(IEnumerable<int> voucherIds, IBulkPaymentFilter filter)
        {
            var query = this.Connection.From<Payment>()
                        .Join<Payment, Voucher>((p, v) => p.VoucherId == v.Id && v.PaymentSourceCD != PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString().ToLower(), NoLockTableHint.NoLock)
                        .LeftJoin<Payment, PaymentCharge>((p, pc) => p.Id == pc.PaymentId, NoLockTableHint.NoLock)
                        .LeftJoin<PaymentCharge, Charges>((pc, c) => pc.ChargeId == c.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Payment, Patient>((p, pt) => p.PatientId == pt.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Patient, PatientCase>((p, pc) => p.DefaultCaseId == pc.Id, NoLockTableHint.NoLock)
                       .SelectDistinct<Payment, Voucher, Patient, PatientCase, PaymentCharge>((p, v, pt, pc,pch) => new
                       {
                           //PatientName = pt.FirstName,
                           //PatientId = pt.Id,
                           //NonAccAdjustment = p.NonAccAdjustment,
                           VoucherId = v.Id,
                           PaymentId = p.Id,
                           PaidAmount = pch.PaidAmount,//Sql.As(p.IsReversed? (-1* p.Amount):p.Amount, "PaidAmount"),
                           IsReversed = p.IsReversed,
                           PaymentGUId = p.UId,
                           //IsCommitted = p.IsCommitted,
                           VoucherUId = v.UId,
                           //PatientUId = pt.UId,
                           //PatientCaseUId = pc.UId,
                           //CreatedDate = p.CreatedDate
                           pch.Id
                       })
                       .Where<Payment, Charges>((p, c) => voucherIds.Contains(p.VoucherId) && c.IsDeleted==false);
            //.Where<Payment, Charges>((p, c) => voucherIds.Contains(p.VoucherId) && c.IsDeleted == false);

            //map filter param into payment filter model
            var resultFilter = _mapper.Map<PaymentFilter>(filter);
            resultFilter.IsCommitted = resultFilter.IsCommitted == "null" ? null : resultFilter.IsCommitted;
            resultFilter.PaymentSourceCD = resultFilter.PaymentSourceCD == "null" ? null : resultFilter.PaymentSourceCD;

            string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
            string countExpression = query.ToCountStatement();
            string whereExpression = await WhereClauseProvider<IPaymentFilter>.GetWhereClause(resultFilter);

            // create where expression and concat with linq query where expression
            query.WhereExpression = string.IsNullOrEmpty(whereExpression) ? query.WhereExpression : query.WhereExpression + " AND " + whereExpression;

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PaymentDTO>.MapList(queryResult);

            // get payment ids and get all payment's with its adjsutment's and remark codes
            IEnumerable<int> paymentIds = result.Select(i => i.PaymentId);
            List<List<int>> tempPaymentIds = new List<List<int>>();

            if (paymentIds.Count() > 0)
            {
                //Chunks a collection into smaller lists of a specified size.
                tempPaymentIds = CollectionChunksHelper.Chunk(paymentIds, 2000);
            }

            List<PaymentChargeDTO> resultPaymentCharges = new List<PaymentChargeDTO>();

            foreach (var item in tempPaymentIds)
            {
                paymentIds = item;
                var tempPaymentCharges = await this._paymentChargeRepository.GetBulkPaymentCharge(paymentIds) as List<PaymentChargeDTO>;
                resultPaymentCharges.AddRange(tempPaymentCharges);
            }

            // start for loop to calculate all amount's 
            result.ToList().ForEach((item) =>
            {
                var paymentAmount= resultPaymentCharges.Where(i => i.PaymentId == item.PaymentId);
                item.BonusAmount = paymentAmount.Sum(i => i.BonusAmount);
                // this is used to insert payments according to its payment id.
                //item.ChargeDTOs = paymentAmount;
                // adjsutments sum where codes are copay and coinsurance
                //item.PatientResponsibility = paymentAmount.Sum(i => i.PatientResponsibility);
                // total sum of charge amount
                //item.TotalChargeAmount = paymentAmount.Sum(i => i.ChargeAmount);
                // total sum of credit amount i.e where payment is reversed == false
                // reversed payment means correct the payment had done by mistake previously. by doing the payment with minus amount.
                item.TotalCrChargeAmount = paymentAmount.Sum(i => i.CrChargeAmount);
                // total sum of credit amount i.e where payment is reversed == true.
                // reversed payment means correct the payment had done by mistake previously. by doing the payment with minus.
                item.TotalDrChargeAmount = paymentAmount.Sum(i => i.DrChargeAmount);
                // total accountable adjustment amount.
                //item.TotalAdjustmentAmount = paymentAmount.Sum(i => i.TotalAdjustmentAmount);
                // total unaccountable adjustment amount.
                //item.NonAccAdjustment = paymentAmount.Sum(i => i.NonAccAdjustment);
                // difference amount = charge amount - total reversed credit amount + adjsutment amount - total dr reversed amount
                //item.DifferenceAmount = item.TotalChargeAmount - ((item.TotalCrChargeAmount + item.TotalAdjustmentAmount + item.PatientResponsibility) - item.TotalDrChargeAmount) - item.NonAccAdjustment;
            });

            return result;
        }

        public async Task<IEnumerable<IPaymentDTO>> GetPayment(IBulkPaymentFilter filter)
        {
            var query = this.Connection.From<Payment>()
                        .Join<Payment, Voucher>((p, v) => p.VoucherId == v.Id/* && voucherIds.Contains(p.VoucherId)*/ && v.PaymentSourceCD != PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString().ToLower(), NoLockTableHint.NoLock)
                        .LeftJoin<Payment, PaymentCharge>((p, pc) => p.Id == pc.PaymentId, NoLockTableHint.NoLock)
                        .LeftJoin<PaymentCharge, Charges>((pc, c) => pc.ChargeId == c.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Payment, Patient>((p, pt) => p.PatientId == pt.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Patient, PatientCase>((p, pc) => p.DefaultCaseId == pc.Id, NoLockTableHint.NoLock)                        
                       .SelectDistinct<Payment, Voucher, Patient, PatientCase>((p, v, pt, pc) => new
                       {
                           PatientName = pt.FirstName,
                           PatientId = pt.Id,
                           NonAccAdjustment = p.NonAccAdjustment,
                           VoucherId = v.Id,
                           PaymentId = p.Id,
                           PaidAmount = p.Amount,//Sql.As((p.IsReversed ? (-1 * p.Amount) : p.Amount), "PaidAmount"),
                           IsReversed = p.IsReversed,
                           PaymentGUId = p.UId,
                           IsCommitted = p.IsCommitted,
                           VoucherUId = v.UId,
                           PatientUId = pt.UId,
                           PatientCaseUId = pc.UId,
                           CreatedDate = p.CreatedDate
                       })
                       .Where<Payment, Voucher, Charges>((p, v, c) => v.UId == filter.VoucherUId && c.IsDeleted == false);

            //map filter param into payment filter model
            var resultFilter = _mapper.Map<PaymentFilter>(filter);
            resultFilter.IsCommitted = resultFilter.IsCommitted == "null" ? null : resultFilter.IsCommitted;
            resultFilter.PaymentSourceCD = resultFilter.PaymentSourceCD == "null" ? null : resultFilter.PaymentSourceCD;

            string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
            string countExpression = query.ToCountStatement();
            string whereExpression = await WhereClauseProvider<IPaymentFilter>.GetWhereClause(resultFilter);

            // create where expression and concat with linq query where expression
            query.WhereExpression = string.IsNullOrEmpty(whereExpression) ? query.WhereExpression : query.WhereExpression + " AND " + whereExpression;

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PaymentDTO>.MapList(queryResult);

            // get payment ids and get all payment's with its adjsutment's and remark codes
            int[] paymentIds = result.Select(i => i.PaymentId).ToArray();
            var paymentResult = await this._paymentChargeRepository.GetPaymentCharge(paymentIds);

            // start for loop to calculate all amount's 
            result.ToList().ForEach((payment) =>
            {
                var paymentData = paymentResult.Where(i => i.PaymentId == payment.PaymentId);
                payment.BonusAmount = paymentData.Sum(i => i.BonusAmount);
                // this is used to insert payments according to its payment id.
                payment.ChargeDTOs = paymentData;
                // adjsutments sum where codes are copay and coinsurance
                payment.PatientResponsibility = paymentData.Sum(i => i.PatientResponsibility);
                // total sum of charge amount
                payment.TotalChargeAmount = paymentData.Sum(i => i.ChargeAmount);
                // total sum of credit amount i.e where payment is reversed == false
                // reversed payment means correct the payment had done by mistake previously. by doing the payment with minus amount.
                payment.TotalCrChargeAmount = paymentData.Sum(i => i.CrChargeAmount);
                // total sum of credit amount i.e where payment is reversed == true.
                // reversed payment means correct the payment had done by mistake previously. by doing the payment with minus.
                payment.TotalDrChargeAmount = paymentData.Sum(i => i.DrChargeAmount);
                // total accountable adjustment amount.
                payment.TotalAdjustmentAmount = paymentData.Sum(i => i.TotalAdjustmentAmount);
                // total unaccountable adjustment amount.
                payment.NonAccAdjustment = paymentData.Sum(i => i.NonAccAdjustment);
                // difference amount = charge amount - total reversed credit amount + adjsutment amount - total dr reversed amount
                payment.DifferenceAmount = payment.TotalChargeAmount - ((payment.TotalCrChargeAmount + payment.TotalAdjustmentAmount + payment.PatientResponsibility) + payment.TotalDrChargeAmount) - payment.NonAccAdjustment;
            });

            return result;
        }

        public async Task<IEnumerable<IPayment>> GetTotalPayments(IEnumerable<int> voucherIds)
        {
            return await this.Connection.SelectAsync<Payment>(i => voucherIds.Contains(i.VoucherId));
        }

        /// <summary>
        /// method to update is committed flag
        /// </summary>
        /// <param name="paymentGuid"></param>
        /// <param name="voucherId"></param>
        /// <returns></returns>
        public async Task<IPayment> UpdateCommitedTransaction(Guid? paymentGuid, int? voucherId)
        {
            try
            {
                // find payment by using payment guid.
                Payment tEntity = await this.Connection.SingleAsync<Payment>(i => i.UId == paymentGuid);
                if (tEntity == null)
                {
                    // throw error if voucher does n't exists with its voucher guid.
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[Convert.ToInt32(EnumErrorCode.VoucherNotExists), voucherId]));
                }

                tEntity.IsCommitted = true;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Payment>()
                                           .Update(x => new
                                           {
                                               x.IsCommitted
                                           });

                // this condition is used if payment id is null it means this will update payment's iscommitted acc. to voucher id otherwise this will update payment's iscommitted one by one using payment guid. 
                if (paymentGuid != null)
                    updateOnlyFields = updateOnlyFields.Where(i => i.UId == paymentGuid);
                if (voucherId != null)
                    updateOnlyFields = updateOnlyFields.Where(i => i.VoucherId == voucherId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateCommitedTransaction(IEnumerable<int> paymentGuid)
        {
            try
            {
                List<List<int>> tempPaymentIds = new List<List<int>>();
                if (paymentGuid.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempPaymentIds = CollectionChunksHelper.Chunk(paymentGuid, 2000);
                }
                foreach (var item in tempPaymentIds)
                {
                    // find payment by using payment guid.
                    Payment tEntity = new Payment();
                    tEntity.IsCommitted = true;

                    var errors = await this.ValidateEntityToUpdate(tEntity);
                    if (errors.Count() > 0)
                        await this.ThrowEntityException(errors);

                    var updateOnlyFields = this.Connection
                                               .From<Payment>()
                                               .Update(x => new
                                               {
                                                   x.IsCommitted
                                               });

                    // this condition is used if payment id is null it means this will update payment's iscommitted acc. to voucher id otherwise this will update payment's iscommitted one by one using payment guid. 
                    updateOnlyFields = updateOnlyFields.Where(i => item.Contains(i.Id));

                    var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);                    

                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByChargeId(int chargeId)
        {
            try
            {
                var paymentCharge = await this._paymentChargeRepository.GetByChargeId(chargeId);
                int[] paymentIds = paymentCharge.Select(i => i.PaymentId).ToArray();
                var paymentData = await this._paymentChargeRepository.GetByPaymentId(paymentIds);

                foreach (var item in paymentCharge)
                {
                    var payments = paymentData.Where(i => i.PaymentId == item.PaymentId);
                    if (payments.Count() == 1)
                    {
                        await this._paymentChargeRepository.DeleteByChargeId(chargeId);
                        await this.Delete(item.PaymentId);
                    }
                    else if (payments.Count() > 1)
                    {
                        await this._paymentChargeRepository.DeleteByChargeId(chargeId);
                    }
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DataTable> GetExcelForInsuranceWisePaymentReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "usp_GetInsurancewisePaymentReport"; // '"+date +"'";,
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.AddParam("FromDate", fromDate, ParameterDirection.Input, DbType.DateTime);
                cmd.AddParam("ToDate", toDate, ParameterDirection.Input, DbType.DateTime);

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

        public async Task<IEnumerable<IChargesReportData>> GetWriteOffForAdjusments()
        {

            //var query = this.Connection.From<Voucher>()
            //           .Join<Voucher, PaymentBatch>((v, pb) => v.PaymentBatchId == pb.Id, NoLockTableHint.NoLock)
            //           .LeftJoin<Voucher, Patient>((v, pb) => v.PatientId == pb.Id && v.IsSelfPayment == true, NoLockTableHint.NoLock)
            //           .LeftJoin<Patient, PatientCase>((p, pb) => p.DefaultCaseId == pb.Id, NoLockTableHint.NoLock)
            //           .LeftJoin<Voucher, InsuranceCompany>((v, ic) => v.InsuranceCompanyId == ic.Id && v.IsSelfPayment == false, NoLockTableHint.NoLock)

            var writeOfflstQuery = this.Connection.From<ChargeInWriteOff>().Select<ChargeInWriteOff>((p) => new { p.ChargeId }).Where(i => i.StatusId == 2 && i.IsPosted == false);
            var dynamics = await this.Connection.SelectAsync<dynamic>(writeOfflstQuery);
            var chargeIdsList = Mapper<ChargeInWriteOff>.MapList(dynamics).ToList();
            IEnumerable<string> chargeIds = chargeIdsList.Select(i => i.ChargeId.ToString());

            IEnumerable<IChargesReportData> lst = await this.Connection.SelectAsync<ChargesReportData>(i => chargeIds.Contains(i.ChargeId.ToString()));

            var query = this.Connection.From<ChargesReportData>().
                Join<ChargesReportData, ChargeInWriteOff>((i, j) => i.ChargeId == j.ChargeId)
                .SelectDistinct<ChargesReportData, ChargeInWriteOff>((i, j) => new
                {
                    i.InvoiceUId,
                    i.PatientUId,
                    WriteOffRequestReasonCode = j.ReasonCode,
                    ChargeInWriteOffId = j.Id
                }
            ).Where<ChargeInWriteOff>(i =>i.StatusId==2 && i.IsPosted==false );

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ChargesReportData>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPayment(int paymentId)
        {
            var query = this.Connection.From<ChargeViewDTO>().
                Join<ChargeViewDTO, PaymentCharge>((i, j) => i.Id == j.ChargeId,NoLockTableHint.NoLock).
                Join<PaymentCharge, Payment>((i, j) => i.PaymentId == j.Id, NoLockTableHint.NoLock)
                .SelectDistinct<ChargeViewDTO, PaymentCharge>((i, j) => new
                {
                    i.AccessionNumber,
                    DosDate = i.BillFromDate,
                    CptCode = i.CPTCode,
                    ChargeAmount = i.Amount,
                    j.PaidAmount,
                    j.ModifiedBy,
                    j.ModifiedDate
                }
            ).Where<PaymentCharge>(i => i.PaymentId== paymentId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PortalPaymentChargesDTO>.MapList(queryResult);

            return result.OrderBy(i => i.DOSDate);
        }

        public async Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPaymentNew(List<int> paymentIds)
        {
            var query = this.Connection.From<ChargeViewDTO>().
                Join<ChargeViewDTO, PaymentCharge>((i, j) => i.Id == j.ChargeId, NoLockTableHint.NoLock).
                Join<PaymentCharge, Payment>((i, j) => i.PaymentId == j.Id, NoLockTableHint.NoLock).
                Join<PaymentCharge, PortalPaymentChild>((i, j) => i.PaymentId == j.PaymentId, NoLockTableHint.NoLock)
                .SelectDistinct<ChargeViewDTO, PaymentCharge, PortalPaymentChild>((i, j,k ) => new
                {
                    i.AccessionNumber,
                    DosDate=i.BillFromDate,
                    CptCode=i.CPTCode,
                    ChargeAmount=i.Amount,
                    //i.PerforingProviderName,
                    j.PaidAmount,
                    j.ModifiedBy,
                    j.ModifiedDate,
                    k.PortalPaymentId
                }
            ).Where<PaymentCharge>(i => paymentIds.Contains(i.PaymentId));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PortalPaymentChargesDTO>.MapList(queryResult);

            return result.OrderBy(i => i.DOSDate);
        }
    }
}
