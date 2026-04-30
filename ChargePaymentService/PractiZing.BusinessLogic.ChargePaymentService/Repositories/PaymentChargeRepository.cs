using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.ERAService.Tables;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.ReportService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PaymentChargeRepository : ModuleBaseRepository<PaymentCharge>, IPaymentChargeRepository
    {

        private IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private IPaymentRemarkCodeRepository _paymentRemarkCodeRepository;

        public PaymentChargeRepository(ValidationErrorCodes errorCodes,
                                       DataBaseContext dbContext,
                                       ILoginUser loggedUser,
                                       IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                       IPaymentRemarkCodeRepository paymentRemarkCodeRepository)
                                       : base(errorCodes, dbContext, loggedUser)
        {
            this._paymentAdjustmentRepository = paymentAdjustmentRepository;
            this._paymentRemarkCodeRepository = paymentRemarkCodeRepository;
        }

        public async Task<IPaymentCharge> Get(Guid uid)
        {
            return await this.Connection.SingleAsync<PaymentCharge>(i => i.UId == uid);
        }

        public async Task<IEnumerable<int>> GetChargeIdsByReasonCodes(string codes)
        {
            try
            {
                var paymentIds = await this._paymentAdjustmentRepository.GetByCodes(codes);
                //var ids = adjustments.Select(i => i.PaymentChargeId).Distinct();
                // var paymentCharges = await this.Connection.SelectAsync<PaymentCharge>(i => ids.Contains(i.Id));
                //var chargeIds = paymentCharges.Count() == 0 ? new List<int>() : paymentCharges.Select(i => i.ChargeId).Distinct().ToList();

                var query = this.Connection.From<PaymentCharge>()
                            .Select<PaymentCharge>((pc) => new
                            {
                                pc
                            })
                            .Where<PaymentCharge>(i => paymentIds.Contains(i.Id));

                query.SelectExpression = query.SelectExpression + query.FromExpression + " Where Id  In (" + string.Join(',', paymentIds) + ")";

                var queryResult = await this.Connection.QueryAsync<PaymentCharge>(query.SelectExpression);
                return queryResult.Select(i => i.ChargeId).ToList();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// get payment charge by using charge id and payment id where is committed = true.
        /// is committed means payment confirmed by user.
        /// </summary>
        /// <param name="chargeId"></param>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public async Task<IPaymentCharge> GetByChargeId(int chargeId, int paymentId)
        {
            try
            {
                var query = this.Connection.From<PaymentCharge>()
                        .LeftJoin<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Payment, Voucher>((p, v) => p.VoucherId == v.Id && v.IsCommitted == true, NoLockTableHint.NoLock)
                        .SelectDistinct<PaymentCharge, Voucher>((pc, v) => new
                        {
                            pc,
                            IsCommitted = v.IsCommitted
                        })
                        .Where<PaymentCharge>((i => i.ChargeId == chargeId && i.PaymentId == paymentId));

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<PaymentCharge>.Map(queryResult);

                return result;
                //return await this.Connection.SingleAsync<PaymentCharge>(i => i.ChargeId == chargeId && i.PaymentId == paymentId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPaymentCharge>> GetByChargeId(int chargeId)
        {
            return await this.Connection.SelectAsync<PaymentCharge>(i => i.ChargeId == chargeId);
        }

        public async Task<IEnumerable<IPaymentCharge>> GetPaymentsByChargeId(int chargeId)
        {

            var query = this.Connection.From<PaymentCharge>()
                        .LeftJoin<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Payment, Voucher>((p, v) => p.VoucherId == v.Id && v.IsCommitted == true, NoLockTableHint.NoLock)
                        .LeftJoin<Payment, InsuranceCompany>((p, ins) => p.PatientInsuranceCompanyId == ins.Id, NoLockTableHint.NoLock)
                        .SelectDistinct<PaymentCharge, Voucher,Payment,InsuranceCompany>((pc, v,p,ins) => new
                        {
                            pc,
                            PaidDate = v.EffectiveDate,
                            InsuranceCompanyId=p.PatientInsuranceCompanyId,
                            InsuranceCompanyCode=ins.CompanyCode,
                            TempCompanyCode=ins.TempCompanyCode

                        })
                        .Where<PaymentCharge>((i => i.ChargeId == chargeId));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var payments = Mapper<PaymentCharge>.MapList(queryResult);

            //var payments= await this.Connection.SelectAsync<PaymentCharge>(i => i.ChargeId == chargeId);



            var adjustments = await _paymentAdjustmentRepository.GetByPaymentChargeId(payments.Select(i => i.Id));

            foreach (var item in payments)
            {
                var paymentAdjustments = adjustments.Where(i => i.PaymentChargeId == item.Id);
                item.PaymentAdjustments = paymentAdjustments == null ? new List<PaymentAdjustment>() : paymentAdjustments;

                item.IsDenial = item.PaymentAdjustments.Where(i => i.IsDenial == true).Count() > 0 ? true : false;
            }

            return payments;
        }

        /// <summary>
        /// get payment charge by using charge ids.
        /// </summary>
        /// <param name="chargeIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPaymentCharge>> GetByChargeId(IEnumerable<int> chargeIds)
        {
            var query = this.Connection.From<PaymentCharge>()
                        .LeftJoin<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Payment, Voucher>((p, v) => p.VoucherId == v.Id, NoLockTableHint.NoLock)
                        .SelectDistinct<PaymentCharge, Voucher, Payment>((pc, v, p) => new
                        {
                            pc,
                            IsCommitted = v.IsCommitted,
                            IsReversed = p.IsReversed
                        })
                        .Where<PaymentCharge>((i => chargeIds.Contains(i.ChargeId)));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<PaymentCharge>.MapList(queryResult);

            return result;
        }

        /// <summary>
        /// method for biiling history.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPaymentCharge>> Get(IPaymentBillingHistoryFilter filter, long patientId)
        {
            List<PaymentCharge> payments = new List<PaymentCharge>();

            //ispayment flag means if ispayment = true then we need to find payments on charge with its full details for payments grid on billing history
            if (filter.isPayment)
            {
                var query = this.Connection.From<PaymentCharge>()
                                 .Join<PaymentCharge, ChargeViewDTO>((p, c) => p.ChargeId == c.Id,NoLockTableHint.NoLock)
                                 //.Join<ChargeViewDTO, Invoice>((p, c) => p.InvoiceId == c.Id)
                                 .Join<PaymentCharge, Payment>((pc, c) => pc.PaymentId == c.Id, NoLockTableHint.NoLock)
                                 .Join<Payment, Voucher>((p, v) => p.VoucherId == v.Id, NoLockTableHint.NoLock)
                                 .SelectDistinct<PaymentCharge, ChargeViewDTO, Payment, Voucher>((pc, x, p, v) => new
                                 {
                                     PaidDate = pc.ModifiedDate,
                                     ChargeUId = x.UId,
                                     DOS = x.BillFromDate,
                                     Mod1 = x.Mod1,
                                     Id = pc.Id,
                                     Amount = x.Amount,
                                     TotalPaidAmount = pc.PaidAmount,
                                     CoPay = x.CoPay,
                                     Deductible = x.Deductible,
                                     CoIns = x.CoIns,
                                     CPTCode = x.CPTCode,
                                     TotalAdjustment = x.TotalAdjustment,
                                     InvoiceId = x.InvoiceId,
                                     DueByFlagCD = x.DueByFlagCD,
                                     AccessionNumber = x.AccessionNumber,
                                     VoucherUId = v.UId,
                                     PaymentUId = p.UId,
                                     ClaimId = x.ClaimId,
                                     PatientCaseId = x.PatientCaseId,
                                     VoucherNo = v.VoucherNo,
                                     BonusAmount = x.BonusAmount,
                                     UId = pc.UId,
                                     IsReversed = p.IsReversed,
                                     IsCommitted = p.IsCommitted,
                                     IsSelfPayment=v.IsSelfPayment,
                                     PaymentId=pc.PaymentId
                                 })
                                 .Where<ChargeViewDTO, Payment>((i, p) => i.PracticeId == LoggedUser.PracticeId && p.PatientId == patientId);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IPaymentBillingHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                try
                {
                    payments = Mapper<PaymentCharge>.MapList(queryResult).ToList();
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
            else
            {
                //is payment = false then get all payments inside chargeids
                var query = this.Connection.From<PaymentCharge>()
                                .Join<PaymentCharge, Charges>((p, c) => p.ChargeId == c.Id && c.IsDeleted == false, NoLockTableHint.NoLock)
                                .Join<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id, NoLockTableHint.NoLock)
                                .Join<Payment, Voucher>((p, v) => p.VoucherId == v.Id, NoLockTableHint.NoLock)
                                .SelectDistinct<PaymentCharge, Charges, Payment, Voucher>((pc, c, p, v) => new
                                {
                                    pc,
                                    ChargeUId = c.UId,
                                    VoucherNo = v.VoucherNo,
                                    BonusAmount = c.BonusAmount,
                                    IsReversed = p.IsReversed,
                                    IsSelfPayment = v.IsSelfPayment
                                })
                                 .Where<Charges, PaymentCharge, Payment>((i, pc, p) => i.PracticeId == LoggedUser.PracticeId && filter.ChargeIds.Contains(pc.ChargeId) && p.PatientId == patientId);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                payments = Mapper<PaymentCharge>.MapList(queryResult).ToList();
            }

            //get arrays of payment ids.
            int[] Ids = payments.Select(i => i.Id).ToArray();
            // get adjustments inside payment ids.
            var paymentAdjustment = await this._paymentAdjustmentRepository.GetByPaymentChargeId(Ids);
            // get remark codes inside payment ids.
            var remarkCode = await this._paymentRemarkCodeRepository.Get(Ids);

            foreach (var item in payments)
            {
                // payment adjustment where is accounted = true. is acc. means those are countable from admin side.
                item.TotalAdjustment = paymentAdjustment.Where(i => i.PaymentChargeId == item.Id && i.IsAccounted == true && i.IsDenial == false).Sum(i => i.Amount);
                item.DueAmount = (item.Amount - (item.TotalPaidAmount + item.TotalAdjustment));
                // item.DueAmount = item.IsReversed ? (item.Amount - ((item.TotalPaidAmount * -1) + (item.TotalAdjustment * -1))) : (item.Amount - (item.TotalPaidAmount + item.TotalAdjustment));
                item.ReasonCode = paymentAdjustment.Where(i => i.PaymentChargeId == item.Id).Count() > 0 ? string.Join(",", (paymentAdjustment.Where(i => i.PaymentChargeId == item.Id)).Select(i => i.ReasonCode)) : "";
                item.PRAdjustmentAmount = paymentAdjustment.Where(i => i.PaymentChargeId == item.Id && i.IsAccounted == false).Sum(i => i.Amount);
                // is denial means user create a denial payment with 0 paid amount.
                item.IsDenial = paymentAdjustment.Where(i => i.PaymentChargeId == item.Id && i.IsDenial == true).Count() > 0 ? true : false;
                item.DenialAmount = paymentAdjustment.Where(i => i.PaymentChargeId == item.Id && i.IsDenial == true).Sum(i => i.Amount);
            }

            payments = payments.OrderByDescending(i => i.PaidDate).ToList();
            return payments;
        }

        public async Task<IEnumerable<IPaymentCharge>> GetByChargeIds(IEnumerable<int> chargeIds)
        {
            try
            {
                var result = await this.Connection.SelectAsync<PaymentCharge>(i => chargeIds.Contains(i.ChargeId));

                foreach (var item in result)
                {
                    item.PatientName = "Payment";
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPaymentCharge> GetById(int id)
        {
            return await this.Connection.SingleAsync<PaymentCharge>(i => i.Id == id);
        }

        public async Task<IEnumerable<IPaymentCharge>> GetById(IEnumerable<int> ids)
        {
            return await this.Connection.SelectAsync<PaymentCharge>(i => ids.Contains(i.Id));
        }

        public async Task<IEnumerable<IPaymentCharge>> GetByPaymentId(int paymentId)
        {
            return await this.Connection.SelectAsync<PaymentCharge>(i => i.PaymentId == paymentId);
        }

        public async Task<IEnumerable<IPaymentCharge>> GetByPaymentId(IEnumerable<int> paymentIds)
        {
            //if (paymentIds.Count() > 2000)
            //{
            //    var query = this.Connection.From<PaymentCharge>()
            //               .LeftJoin<PaymentCharge, ERAClaim>((pc, p) => pc.PaymentId.ToString() == p.PaymentUID, NoLockTableHint.NoLock)                           
            //              .Select<PaymentCharge,ERAClaim>((pc,erc) => new
            //              {
            //                  pc,
            //                  PatientAccountNumber=erc.PatientControlNumber
            //              })
            //              .Where<PaymentCharge>(i => paymentIds.Contains(i.PaymentId));

            //    query.SelectExpression = query.SelectExpression + query.FromExpression + " Where PaymentId  In (" + string.Join(',', paymentIds) + ")";

            //    var queryResult = await this.Connection.QueryAsync<PaymentCharge>(query.SelectExpression);
            //    return queryResult;
            //}

            var query = this.Connection.From<PaymentCharge>()
                           .LeftJoin<PaymentCharge, ERAClaim>((pc, p) => pc.PaymentId.ToString() == p.PaymentUID, NoLockTableHint.NoLock)
                          .Select<PaymentCharge, ERAClaim>((pc, erc) => new
                          {
                              pc,
                              PatientAccountNumber = erc.PatientControlNumber
                          })
                          .Where<PaymentCharge>(i => paymentIds.Contains(i.PaymentId));

            //query.SelectExpression = query.SelectExpression + query.FromExpression + " Where PaymentId  In (" + string.Join(',', paymentIds) + ")";

            //var queryResult = await this.Connection.SelectAsync<PaymentCharge>(query);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var paymentChargeResult = Mapper<PaymentCharge>.MapList(queryResult);
            return paymentChargeResult;

            // return await this.Connection.SelectAsync<PaymentCharge>(i => paymentIds.Contains(i.PaymentId));
        }

        public async Task<IEnumerable<IPaymentCharge>> GetByPaymentId(int paymentId, int chargeId)
        {
            return await this.Connection.SelectAsync<PaymentCharge>(i => i.PaymentId == paymentId && i.ChargeId == chargeId);
        }

        /// <summary>
        /// get method to get payment charges with its adjust. and remark codes and calculated amounts (check below code). 
        /// </summary>
        /// <param name="paymentIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPaymentChargeDTO>> GetPaymentCharge(IEnumerable<int> paymentIds)
        {
            var query = this.Connection.From<PaymentCharge>()
                        .Join<PaymentCharge, Charges>((pc, c) => pc.ChargeId == c.Id, NoLockTableHint.NoLock)
                        .Join<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id && p.PaymentSourceCD.ToLower() != PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString().ToLower(), NoLockTableHint.NoLock)
                        .SelectDistinct<PaymentCharge, Charges, Payment>((pc, c, p) => new
                        {
                            DOS = c.BillFromDate,
                            CPTCode = c.CPTCode,
                            ChargeNumber = c.ChargeNo,
                            Mod = c.Mod1,
                            ChargeAmount = c.Amount,
                            IsReversed = p.IsReversed,
                            NonAccAdjustment = p.NonAccAdjustment,
                            PaidAmount = pc.PaidAmount,//Sql.As(p.IsReversed?(-1* pc.PaidAmount): pc.PaidAmount, "PaidAmount"),
                            PaymentId = p.Id,
                            PaymentChargeId = pc.Id,
                            Quantity = c.Qty
                        })
                        .Where(i => paymentIds.Contains(i.PaymentId));

            var paymentChargeResult = await this.Connection.SelectAsync<PaymentChargeDTO>(query);

            int[] paymentChargeIds = paymentChargeResult.Select(i => i.PaymentChargeId).ToArray();
            var paymentAdjustments = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds);

            paymentChargeResult.ToList().ForEach((paymentCharge) =>
            {
                var paymentAdjustmentData = paymentAdjustments.Where(i => i.PaymentChargeId == paymentCharge.PaymentChargeId);
                paymentCharge.BonusAmount = paymentAdjustmentData.Where(i => i.IsAccounted == false && i.IsBonus == true && (i.ReasonCode.ToLower() != "pr1" && i.ReasonCode.ToLower() != "pr2" && i.ReasonCode.ToLower() != "pr3")).Sum(i => i.Amount);
                // sum of adjsutment where code is copay or coinsurance
                paymentCharge.PatientResponsibility = paymentAdjustmentData.Where(i => (i.ReasonCode.ToLower() == "pr1" || i.ReasonCode.ToLower() == "pr2" || i.ReasonCode.ToLower() == "pr3")).Sum(i => i.Amount);
                // sum of adjsutments
                paymentCharge.TotalAdjustmentAmount = paymentAdjustmentData.Where(i => i.IsAccounted == true).Sum(i => i.Amount);
                //paymentCharge.ReasonCode = paymentAdjustmentData.Count() > 0 ? string.Join(',', (paymentAdjustmentData.Where(i => i.IsAccounted == true)).Select(i => i.ReasonCode)) : "";
                paymentCharge.ReasonCode = paymentAdjustmentData.Count() > 0 ? string.Join(',', (paymentAdjustmentData).Select(i => i.ReasonCode)) : "";
                // sum of adjsutment which are unaccountable
                paymentCharge.NonAccAdjustment = paymentAdjustmentData.Where(i => i.IsAccounted == false && i.IsBonus == false && (i.ReasonCode.ToLower() != "pr1" && i.ReasonCode.ToLower() != "pr2" && i.ReasonCode.ToLower() != "pr3")).Sum(i => i.Amount);
            });

            return paymentChargeResult;
        }

        public async Task<IEnumerable<IPaymentChargeForACKDTO>> GetBulkPaymentChargeForACK(IEnumerable<int> paymentIds)
        {
            List<string> ignoreCases = new List<string>() { "", "-", "." };

            var query = this.Connection.From<ChargeViewDTO>()
                             .Join<ChargeViewDTO, ChargeStat>((a,b)=>a.Id==b.Id,NoLockTableHint.NoLock)
                             .Join<ChargeViewDTO,PaymentCharge >((c, pc) => pc.ChargeId == c.Id, NoLockTableHint.NoLock)
                             .Join<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id , NoLockTableHint.NoLock)                            
                             .SelectDistinct<ChargeViewDTO, ChargeStat,Payment,PaymentCharge>((ct,cs,p,pc) => new
                             {                                 
                                 PaymentId = p.Id,
                                 PaymentChargeId = pc.Id,
                                 AccessionNumber=ct.AccessionNumber,
                                 HasDenial=cs.HasDenial,
                                 DueAmount=ct.DueAmount,
                                 TotalPaidAmount=ct.PaidAmount,
                                 TotalAdjustment=ct.TotalAdjustment,
                                 DueBy= ct.DueByFlagCD
                             })
                             .Where<Payment, ChargeViewDTO>((i,j) => paymentIds.Contains(i.Id) && !ignoreCases.Contains(j.AccessionNumber));
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var paymentChargeResult = Mapper<PaymentChargeForACKDTO>.MapList(queryResult);

            return paymentChargeResult;
        }

        public async Task<IEnumerable<IPaymentChargeDTO>> GetBulkPaymentCharge(IEnumerable<int> paymentIds)
        {
            try
            {
                var query = this.Connection.From<PaymentCharge>()
                             .Join<PaymentCharge, Charges>((pc, c) => pc.ChargeId == c.Id, NoLockTableHint.NoLock)
                             .Join<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id && p.PaymentSourceCD.ToLower() != PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString().ToLower(), NoLockTableHint.NoLock)
                             .LeftJoin<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId && pa.IsBonus == true, NoLockTableHint.NoLock)
                             .SelectDistinct<PaymentCharge, Charges, Payment, PaymentAdjustment>((pc, c, p, pa) => new
                             {
                                 //DOS = i.BillFromDate,
                                 //CPTCode = c.CPTCode,
                                 //ChargeNumber = c.ChargeNo,
                                 //Mod = c.Mod1,
                                 ChargeAmount = c.Amount,
                                 IsReversed = p.IsReversed,
                                 BonusAmount = pa.Amount,
                                 NonAccAdjustment = p.NonAccAdjustment,
                                 PaidAmount = pc.PaidAmount,
                                 PaymentId = p.Id,
                                 PaymentChargeId = pc.Id,
                                 Quantity = c.Qty
                             })
                             .Where(i => paymentIds.Contains(i.PaymentId));

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var paymentChargeResult = Mapper<PaymentChargeDTO>.MapList(queryResult);

                var result = (
                from meta in paymentChargeResult
                group meta by new
                {                    
                    meta.ChargeAmount,
                    meta.IsReversed,
                    meta.NonAccAdjustment,
                    meta.PaidAmount,
                    meta.PaymentId,
                    meta.PaymentChargeId,
                    meta.Quantity                    
                } into t
                select new PaymentChargeDTO
                {
                    ChargeAmount = t.Key.ChargeAmount,
                    IsReversed = t.Key.IsReversed,
                    NonAccAdjustment = t.Key.NonAccAdjustment,
                    PaidAmount = t.Key.PaidAmount,
                    PaymentId = t.Key.PaymentId,
                    PaymentChargeId = t.Key.PaymentChargeId,
                    Quantity = t.Key.Quantity,
                    BonusAmount=t.Sum(x=>x.BonusAmount)
                }).ToList();

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPaymentChargeDTO>> GetPaymentCharge(int paymentId)
        {
            var query = this.Connection.From<PaymentCharge>()
                        .Join<PaymentCharge, Charges>((pc, c) => pc.ChargeId == c.Id, NoLockTableHint.NoLock)
                        .Join<PaymentCharge, Payment>((pc, p) => pc.PaymentId == p.Id && p.PaymentSourceCD.ToLower() != PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString().ToLower(), NoLockTableHint.NoLock)
                        //.Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id, NoLockTableHint.NoLock)
                        .Join<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId)
                        .SelectDistinct<PaymentCharge, Charges/*, Invoice*/, Payment, PaymentAdjustment>((pc, c/*, i*/, p, pa) => new
                        {
                            //DOS = i.BillFromDate,
                            CPTCode = c.CPTCode,
                            ChargeNumber = c.ChargeNo,
                            Mod = c.Mod1,
                            ChargeAmount = c.Amount,
                            IsReversed = p.IsReversed,
                            NonAccAdjustment = p.NonAccAdjustment,
                            PaidAmount = pc.PaidAmount,
                            PaymentId = p.Id,
                            PaymentChargeId = pc.Id,
                            Quantity = c.Qty
                        })
                        .Where(i => i.PaymentId == paymentId);

            var paymentChargeResult = await this.Connection.SelectAsync<PaymentChargeDTO>(query);
            //var paymentChargeResult = Mapper<PaymentChargeDTO>.MapList(queryResult);

            int[] paymentChargeIds = paymentChargeResult.Select(i => i.PaymentChargeId).ToArray();
            var paymentAdjustments = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds);

            paymentChargeResult.ToList().ForEach((paymentCharge) =>
            {
                var paymentAdjustmentData = paymentAdjustments.Where(i => i.PaymentChargeId == paymentCharge.PaymentChargeId);
                paymentCharge.BonusAmount = paymentAdjustmentData.Where(i => i.IsAccounted == false && i.IsBonus == true && (i.ReasonCode.ToLower() != "pr1" && i.ReasonCode.ToLower() != "pr2" && i.ReasonCode.ToLower() != "pr3")).Sum(i => i.Amount);
                // sum of adjsutment where code is copay or coinsurance
                paymentCharge.PatientResponsibility = paymentAdjustmentData.Where(i => (i.ReasonCode.ToLower() == "pr1" || i.ReasonCode.ToLower() == "pr2" || i.ReasonCode.ToLower() == "pr3")).Sum(i => i.Amount);
                // sum of adjsutments
                paymentCharge.TotalAdjustmentAmount = paymentAdjustmentData.Where(i => i.IsAccounted == true).Sum(i => i.Amount);
                paymentCharge.ReasonCode = paymentAdjustmentData.Count() > 0 ? string.Join(',', (paymentAdjustmentData.Where(i => i.IsAccounted == true)).Select(i => i.ReasonCode)) : "";
                // sum of adjsutment which are unaccountable
                paymentCharge.NonAccAdjustment = paymentAdjustmentData.Where(i => i.IsAccounted == false && i.IsBonus == false && (i.ReasonCode.ToLower() != "pr1" && i.ReasonCode.ToLower() != "pr2" && i.ReasonCode.ToLower() != "pr3")).Sum(i => i.Amount);
            });

            //var paymentChargeData = await base.ExecuteStoredProcedureAsync<PaymentChargeDTO>("usp_PaymentChargeByPaymentId", string.Join(',', paymentIds));
            return paymentChargeResult;
        }

        public async Task<IPaymentCharge> AddNew(IPaymentCharge entity)
        {
            try
            {
                PaymentCharge tEntity = entity as PaymentCharge;

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

        public async Task<bool> AddBulkAdjustmentPayment(IEnumerable<IPaymentCharge> paymentCharges, bool isRemarkCode, int patientId)
        {
            try
            {
                foreach (var item in paymentCharges)
                {
                    var paymentCharge = await this.AddNew(item);


                    if (!isRemarkCode)
                    {
                        item.PaymentAdjustments.ToList().ForEach((res) =>
                        {
                            res.PaymentChargeId = paymentCharge.Id;
                            res.ChargeId = paymentCharge.ChargeId;
                        });

                        var adjustmentAdd = await this._paymentAdjustmentRepository.AddNew(item.PaymentAdjustments.FirstOrDefault());

                    }
                    else
                    {
                        item.PaymentRemarkCodes.ToList().ForEach((res) =>
                        {
                            res.PaymentChargeId = paymentCharge.Id;
                        });

                        await this._paymentRemarkCodeRepository.AddNew(item.PaymentRemarkCodes.FirstOrDefault());
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddOrUpdate(IEnumerable<IPaymentCharge> entities)
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

        public async Task AddAll(IEnumerable<IPaymentCharge> entities)
        {
            try
            {
                List<PaymentCharge> paymentChargesList = new List<PaymentCharge>();
                entities.ToList().ForEach((res) =>
                {
                    PaymentCharge paymentCharge = res as PaymentCharge;
                    paymentChargesList.Add(paymentCharge);
                });

                await base.AddAllAsync(paymentChargesList);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPaymentCharge> Update(IPaymentCharge entity)
        {
            try
            {
                PaymentCharge tEntity = entity as PaymentCharge;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<PaymentCharge>()
                                           .Update(x => new
                                           {
                                               x.PaidAmount,
                                               x.ModifiedBy,
                                               x.ModifiedDate
                                           })
                                           .Where(i => i.UId == entity.UId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// delete method to delete payment charge according to payment ids
        /// </summary>
        /// <param name="paymentIds"></param>
        /// <returns></returns>
        public async Task<int> DeleteByPaymentId(IEnumerable<int> paymentIds)
        {
            try
            {
                return await this.Connection.DeleteAsync<PaymentCharge>(i => paymentIds.Contains(i.PaymentId));
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByPaymentChargeId(int paymentChargeId)
        {
            try
            {
                return await this.Connection.DeleteAsync<PaymentCharge>(i => i.Id == paymentChargeId);
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
                var paymentChargeData = await this.Connection.SelectAsync<PaymentCharge>(i => i.ChargeId == chargeId);
                int[] ids = paymentChargeData.Select(i => i.Id).ToArray();

                await this._paymentAdjustmentRepository.DeleteById(ids);
                await this._paymentRemarkCodeRepository.Delete(ids);

                return await this.Connection.DeleteAsync<PaymentCharge>(i => i.ChargeId == chargeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateFSCharge]));
        }

        public async Task ThrowPaymentExistsWithThisChargeError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PaymentExistsWithThisCharge]));
        }

        public async Task<bool> AddBalanceAdjustmentPayment(IEnumerable<IPaymentCharge> paymentCharges)
        {
            try
            {
                foreach (var item in paymentCharges)
                {
                    var paymentCharge = await this.AddNew(item);


                    if (item.PaymentAdjustments != null && item.PaymentAdjustments.Count() > 0)
                    {
                        item.PaymentAdjustments.ToList().ForEach((res) =>
                        {
                            res.PaymentChargeId = paymentCharge.Id;
                            res.ChargeId = paymentCharge.ChargeId;
                        });

                        var adjustmentAdd = await this._paymentAdjustmentRepository.AddNew(item.PaymentAdjustments.FirstOrDefault());

                    }

                    if (item.PaymentRemarkCodes != null && item.PaymentRemarkCodes.Count() > 0)
                    {
                        item.PaymentRemarkCodes.ToList().ForEach((res) =>
                        {
                            res.PaymentChargeId = paymentCharge.Id;
                        });

                        await this._paymentRemarkCodeRepository.AddNew(item.PaymentRemarkCodes.FirstOrDefault());
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
