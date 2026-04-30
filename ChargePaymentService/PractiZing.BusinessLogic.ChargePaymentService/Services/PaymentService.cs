using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.Base.View.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class PaymentService : IPaymentService
    {
        private IVoucherRepository _voucherRepository;
        private IPaymentRepository _paymentRepository;
        private IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private IPaymentChargeRepository _paymentChargeRepository;
        private IPaymentBatchRepository _paymentBatchRepository;
        private readonly ITransactionProvider _transactionProvider;
        private IChargesRepository _chargesRepository;
        private IChargeBatchRepository _chargeBatchRepository;
        private IInsurancePolicyRepository _insurancePolicyRepository;
        private IPaymentRemarkCodeRepository _paymentRemarkCodeRepository;
        private IAttFileRepository _attFileRepository;
        private IPatientRepository _patientRepository;
        private IPatientCaseRepository _patientCaseRepository;
        private IInvoiceRepository _invoiceRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IDepositTypeRepository _depositTypeRepository;
        private ILogger _logger;
        private IDefaultReasonCodeRepository _defaultReasonCodeRepository;
        private IConfigERARemarkCodesRepository _configERARemarkCodesRepository;
        private IActionNoteRepository _actionNoteRepository;
        private IPlaidPaymentRepository _plaidPaymentRepository;
        IChargeInWriteOffRepository _chargeInWriteOffRepository;
        private readonly IChargesReportDataRepository _chargesReportDataRepository;
        private readonly IClaimRepository _claimRepository;
        private readonly IPortalPaymentRepository _portalPaymentRepository;
        private readonly IPortalPaymentChildRepository _portalPaymentChildRepository;
        private readonly IWriteOffTHCodeRepository _writeOffTHCodeRepository;
        private readonly IUserRepository _userRepository;


        public PaymentService(IVoucherRepository voucherRepository,
                              IPaymentRepository paymentRepository,
                              IPaymentChargeRepository paymentChargeRepository,
                              IPaymentBatchRepository paymentBatchRepository,
                              IPaymentAdjustmentRepository paymentAdjustmentRepository,
                              IChargesRepository chargesRepository,
                              IInsurancePolicyRepository insurancePolicyRepository,
                              IChargeBatchRepository chargeBatchRepository,
                              IPaymentRemarkCodeRepository paymentRemarkCodeRepository,
                              ITransactionProvider transactionProvider,
                              IAttFileRepository attFileRepository,
                              IPatientRepository patientRepository,
                              IInvoiceRepository invoiceRepository,
                              IPatientCaseRepository patientCaseRepository,
                              IInsuranceCompanyRepository insuranceCompanyRepository,
                              IDepositTypeRepository depositTypeRepository,
                              IDefaultReasonCodeRepository defaultReasonCodeRepository,
                              IConfigERARemarkCodesRepository configERARemarkCodesRepository,
                              IActionNoteRepository actionNoteRepository,
                              ILogger<IPaymentService> logger,
                              IPlaidPaymentRepository plaidPaymentRepository,
                              IChargeInWriteOffRepository chargeInWriteOffRepository,
                              IChargesReportDataRepository chargesReportDataRepository,
                              IClaimRepository claimRepository,
                              IPortalPaymentRepository portalPaymentRepository,
                              IPortalPaymentChildRepository portalPaymentChildRepository,
                              IWriteOffTHCodeRepository writeOffTHCodeRepository,
                              IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._writeOffTHCodeRepository = writeOffTHCodeRepository;
            this._portalPaymentChildRepository = portalPaymentChildRepository;
            this._portalPaymentRepository = portalPaymentRepository;
            this._claimRepository = claimRepository;
            this._chargesReportDataRepository = chargesReportDataRepository;
            this._chargeInWriteOffRepository = chargeInWriteOffRepository;
            this._voucherRepository = voucherRepository;
            this._paymentRepository = paymentRepository;
            this._paymentChargeRepository = paymentChargeRepository;
            this._paymentBatchRepository = paymentBatchRepository;
            this._paymentRemarkCodeRepository = paymentRemarkCodeRepository;
            this._paymentAdjustmentRepository = paymentAdjustmentRepository;
            this._transactionProvider = transactionProvider;
            this._chargesRepository = chargesRepository;
            this._insurancePolicyRepository = insurancePolicyRepository;
            this._patientRepository = patientRepository;
            this._chargeBatchRepository = chargeBatchRepository;
            this._attFileRepository = attFileRepository;
            this._invoiceRepository = invoiceRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._logger = logger;
            this._patientCaseRepository = patientCaseRepository;
            this._depositTypeRepository = depositTypeRepository;
            this._defaultReasonCodeRepository = defaultReasonCodeRepository;
            this._configERARemarkCodesRepository = configERARemarkCodesRepository;
            this._actionNoteRepository = actionNoteRepository;
            this._plaidPaymentRepository = plaidPaymentRepository;
        }

        public async Task<int> AddNewPayment(IVoucher entity)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                entity.PaymentSourceCD = Enum.GetName(typeof(PaymentSourceTypeEnum), PaymentSourceTypeEnum.MANUAL_PAYMENT);

                //add new voucher with is committed true;
                var getResult = await this._voucherRepository.AddNew(entity);
                // add new payment's
                var payment = await this._paymentRepository.AddOrUpdate(entity.Payments);

                this._transactionProvider.CommitTransaction(transactionId);
                return payment;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<IVoucher> AddNewVoucher(IVoucher entity, IEnumerable<IFormFile> formFiles)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                entity.VoucherNo = await this._voucherRepository.CreateVoucherNo();
                entity.PaymentSourceCD = Enum.GetName(typeof(PaymentSourceTypeEnum), PaymentSourceTypeEnum.MANUAL_PAYMENT);
                entity.DepositTypeId = entity.DepositTypeUId == Guid.Empty ? (short)0 : (short)(await this._depositTypeRepository.GetByUId(entity.DepositTypeUId)).Id;
                entity.Description = entity.InsuranceCompanyId == null ? string.Empty : DateTime.Now.ToShortDateString().Replace("/", "-") + (await this._insuranceCompanyRepository.GetById(entity.InsuranceCompanyId)).CompanyName;
                var voucher = await this._voucherRepository.AddNew(entity);

                // save attachments
                foreach (var formFile in formFiles)
                {
                    var addAttachment = await this._attFileRepository.CreateAttachments(formFile, voucher.Id, AttTableConstant.Voucher, formFile.FileName);
                    var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.Voucher);
                }

                this._transactionProvider.CommitTransaction(transactionId);
                return voucher;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        /// <summary>
        /// method to get payment batch with vouchers inside it.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IPaymentBatch>> Get()
        {
            var paymentBatch = await this._paymentBatchRepository.Get();
            var voucherData = await this._voucherRepository.GetByBatchId(paymentBatch.Select(i => i.Id).ToArray<int>());

            foreach (var item in paymentBatch)
                item.Vouchers = voucherData.Where(i => i.PaymentBatchId == item.Id);

            return paymentBatch;
        }

        public async Task<IEnumerable<IPayment>> GetByVoucher(string voucherUId, string patientUId)
        {
            var voucherId = voucherUId == null ? 0 : (await this._voucherRepository.GetByUId(Guid.Parse(voucherUId))).Id;
            return await this._paymentRepository.GetByVoucher(voucherId, patientUId);
        }

        public async Task<int> AddUpdateBulkPayment(IEnumerable<IPaymentBatchDTO> paymentDTO)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            _logger.LogInformation("Start Transaction with Id - " + transactionId);

            try
            {

                //var paymentBatchId = entities.Select(i => i.Voucher).FirstOrDefault().PaymentBatchId;
                //_logger.LogInformation("Get Batch For Checking IsSystem Tag - " + paymentBatchId);
                //var paymentBatchData = await this._paymentBatchRepository.GetById(paymentBatchId);

                //if (paymentBatchData == null)
                //    _logger.LogInformation("No Payment Batch Found - " + paymentBatchId);

                //var isSystem = paymentBatchData == null ? false : paymentBatchData.IsSystem;
                var voucherObject = paymentDTO.Select(i => i.Voucher).FirstOrDefault();

                var getResult = voucherObject.Id == 0 ? await this._voucherRepository.AddNew(voucherObject)
                                : voucherObject.PaymentSourceCD == PaymentSourceTypeEnum.ERA_PAYMENT.ToString()
                                ? await this._voucherRepository.UpdateVoucherFromERA(voucherObject)
                                : await this._voucherRepository.GetByUId(voucherObject.UId);

                _logger.LogInformation("Voucher Add or Get Voucher if voucher already exist with Id - " + getResult.UId);

                bool isNewPayment = paymentDTO.FirstOrDefault().IsNewPayment;
                _logger.LogInformation("If it is a new payment case" + isNewPayment);

                IPayment payment = null;
                List<ICharges> charge = new List<ICharges>();
                //List<IPaymentBatchDTO> paymentDTO = new List<IPaymentBatchDTO>();

                //paymentDTO.AddRange(entities);

                // paymentDTO = (await this.CreateGroupBy(entities)).ToList();
                _logger.LogInformation("convert payment batch method into group by to normal object 'paymentDTO' ");

                paymentDTO.ToList().ForEach((res) =>
                {
                    charge.AddRange(res.Charges);
                    res.IsNewPayment = false;
                });

                charge.ToList().ForEach(res =>
                {
                    res.TotalAdjustment = res.Adjustments.ToList().Where(i => i.IsAccounted == true && i.IsBonus == false).Sum(i => i.AdjustmentAmount);
                    res.NonAccPaid = res.Adjustments.Where(i => i.IsAccounted == false && i.IsBonus == false).Sum(i => i.AdjustmentAmount);
                });

                bool newPayment = isNewPayment;


                var patient = await this._patientRepository.GetByUId(paymentDTO.FirstOrDefault().PatientUId);
                
                if(isNewPayment)
                {
                    var duplicatePayments = await this._paymentRepository.ValidateDuplicatePayments(getResult.Id, patient.Id, charge, paymentDTO.FirstOrDefault().IsReversed, paymentDTO.FirstOrDefault().PayorControl);
                    if (duplicatePayments.Count() > 0)
                    {
                        throw new Exception("Payment already exists with this checknumber");
                    }
                }
                
                foreach (var entity in paymentDTO)
                {
                    try
                    {

                        if (entity.Charges.Count() == 0)
                        {
                            continue;
                        }
                        

                        entity.PatientUId = patient.UId;

                        _logger.LogInformation("Get Deposit Insurance Details - " + entity.DepositInsuranceCompanyUId);
                        var insuranceDepositData = await this._insuranceCompanyRepository.GetByUId(entity.DepositInsuranceCompanyUId);
                        _logger.LogInformation("Get Patient Insurance Details - " + entity.PatientInsuranceCompanyUId);
                        var insurancePatientData = await this._insuranceCompanyRepository.GetByUId(entity.PatientInsuranceCompanyUId);

                        int insurancePatient = 0;
                        int insuranceDeposit = 0;

                        if (insuranceDepositData != null)
                            insuranceDeposit = insuranceDepositData.Id;
                        if (insurancePatientData != null)
                            insurancePatient = insurancePatientData.Id ;

                        _logger.LogInformation("Get Patient Payment Details with deposit Id - " + getResult.Id + "and patientId - " + patient.Id);
                        var getPaymentData = await this._paymentRepository.GetByVoucher(getResult.Id, patient.UId.ToString());

                        _logger.LogInformation("Total payment row get - " + getPaymentData.Count());
                        if (getPaymentData.Count() == 0 || isNewPayment == true)
                        {
                            _logger.LogInformation("If zero then insert new payment");
                            payment = await this.AddObjectAsync(getResult, patient.Id, charge, paymentDTO.FirstOrDefault().IsReversed, entity,insurancePatient, insuranceDeposit, voucherObject.PaymentSourceCD.ToString());
                            _logger.LogInformation("new payment inserted - " + payment.UId);
                            await this.AddUpdatePaymentChargeObjectAsync(entity.Charges, payment, voucherObject.PaymentSourceCD, voucherObject);
                            isNewPayment = false;
                        }
                        else if (isNewPayment == false && getPaymentData.Count() > 0)
                        {
                            _logger.LogInformation("payment's update");
                            int paymentId = newPayment ? payment.Id : (await this._paymentRepository.GetByUId(entity.PaymentUId)).Id;
                            var item = getPaymentData.Where(i => i.Id == paymentId).FirstOrDefault();
                            item.Amount = paymentDTO.FirstOrDefault().IsReversed ? charge.Sum(i => i.PaidAmount) * -1 : charge.Sum(i => i.PaidAmount);
                            item.Adjustment = paymentDTO.FirstOrDefault().IsReversed ? (int)charge.Sum(i => i.TotalAdjustment) * -1 : (int)charge.Sum(i => i.TotalAdjustment);
                            item.IsReversed = paymentDTO.FirstOrDefault().IsReversed;
                            item.PayorControl = entity.PayorControl;
                            item.PatientInsuranceCompanyId = entity.PatientInsuranceCompanyUId == null ? 0 : insurancePatientData == null ? 0 : insurancePatientData.Id;
                            item.DepositInsuranceCompanyId = entity.PatientInsuranceCompanyUId == null ? 0 : insuranceDepositData == null ? 0 : insuranceDepositData.Id;

                            _logger.LogInformation("payment's object created and ready to update");
                            await this._paymentRepository.Update(item);
                            _logger.LogInformation("payment's object updated");

                            _logger.LogInformation("and then goes into a method called (AddUpdatePaymentChargeObjectAsync) which will update or add adjustment' charges and remark codes inside it.");
                            await this.AddUpdatePaymentChargeObjectAsync(entity.Charges, item, voucherObject.PaymentSourceCD, voucherObject);
                            _logger.LogInformation("successfully updated");
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }

                //_logger.LogInformation("if deposited created from desktop screen then update is committed = true");
                //if (voucherObject.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower())
                //    await this._voucherRepository.UpdateCommitedTransaction(voucherObject.UId);

                _logger.LogInformation("successfully updated");
                this._transactionProvider.CommitTransaction(transactionId);

                return payment == null ? 0 : payment.Id;
            }
            catch
            {
                _logger.LogInformation("Exception in add update payment's");
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<IPayment> AddObjectAsync(IVoucher voucher, int patientId, List<ICharges> chargesList, bool isReversed, IPaymentBatchDTO paymentBatch, int patientInsuranceCompanyId, int depositInsuranceCompanyId, string paymentSourceCD)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                _logger.LogInformation("create new object of payment");
                Payment payment = new Payment();

                payment.Id = 0;
                payment.IsCommitted = voucher.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower() ? true : false;
                payment.NonAccAdjustment = 0;
                payment.PatientId = patientId;
                payment.TransactionNo = await this._voucherRepository.CreateTransactionNo();
                payment.VoucherId = voucher.Id;
                payment.Adjustment = (int)chargesList.Sum(i => i.TotalAdjustment);
                payment.Amount = voucher.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.ERA_PAYMENT.ToString().ToLower() ? isReversed ? paymentBatch.TotalPaidAmount * -1 : paymentBatch.TotalPaidAmount : isReversed ? chargesList.Sum(i => i.PaidAmount) * -1 : chargesList.Sum(i => i.PaidAmount);
                payment.IsReversed = isReversed;
                payment.PaymentSourceCD = paymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower() ? PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString() : PaymentSourceTypeEnum.ERA_PAYMENT.ToString();
                payment.PatientInsuranceCompanyId = patientInsuranceCompanyId;
                payment.DepositInsuranceCompanyId = depositInsuranceCompanyId;
                payment.NonAccAdjustment = (int)chargesList.Sum(i => i.NonAccPaid);
                payment.PayorControl = paymentBatch.PayorControl;

                var paymentReturn = await this._paymentRepository.AddNew(payment);
                this._transactionProvider.CommitTransaction(transactionId);

                return paymentReturn;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<IPaymentCharge> AddUpdatePaymentChargeObjectAsync(IEnumerable<ICharges> charges, IPayment payment, string paymentSourceCD, IVoucher voucher)
        {
           // var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                PaymentCharge paymentC = new PaymentCharge();
                IPaymentCharge returnResult = null;

                //charges = charges.Where(i => i.PaidAmount != 0 || i.Adjustments.Sum(a => a.AdjustmentAmount) > 0 || i.Adjustments.Count(a => a.IsDenial) > 0);
                var tempcharges = charges.Where(i => i.PaidAmount != 0 || i.Adjustments.Sum(a => a.AdjustmentAmount) > 0 || i.Adjustments.Count(a => a.IsDenial) > 0);
                if (tempcharges.Count() == 0)
                {
                    var paymentCharge = (await this._paymentChargeRepository.GetByPaymentId(payment.Id, charges.FirstOrDefault().Id)).FirstOrDefault();
                    if (paymentCharge != null)
                    {
                        await this._paymentChargeRepository.DeleteByPaymentChargeId(paymentCharge.Id);
                        //this._transactionProvider.CommitTransaction(transactionId);
                    }
                    return null;
                }

                foreach (var item in tempcharges)
                {
                    int isDenial = item.Adjustments.Where(i => i.IsDenial == true).Count();

                    if (paymentSourceCD.ToLower() != PaymentSourceTypeEnum.ERA_PAYMENT.ToString().ToLower())
                    {
                        if(!voucher.IsSelfPayment)
                        {
                            if(payment.IsReversed==false)
                                await this.UpdateChargeWithIsDenialCase(isDenial, item, paymentSourceCD,payment);
                            else
                                await this.UpdateChargeWithIsDenialCaseForReversePayment(isDenial, item, paymentSourceCD, payment);
                        }                        
                    }
                        

                    var paymentCharge = (await this._paymentChargeRepository.GetByPaymentId(payment.Id, item.Id)).FirstOrDefault();

                    if (item.PaidAmount != 0 || isDenial != 0 || item.Adjustments.Sum(i => i.AdjustmentAmount) > 0)
                    {
                        if (paymentCharge != null)
                        {
                            paymentCharge.PaidAmount = isDenial > 0 ? 0 : payment.IsReversed ? item.PaidAmount < 0 ? item.PaidAmount : item.PaidAmount * -1 : item.PaidAmount;
                            //paymentCharge.PaidAmount = isDenial > 0 ? 0 : paymentCharge.PaidAmount;
                            returnResult = await this._paymentChargeRepository.Update(paymentCharge);
                            await this._actionNoteRepository.AddPaymentNote(payment.PatientId, item.Id, "Payment (#" + voucher.ReferenceNo + ") of $" + (paymentCharge.PaidAmount + item.Adjustments.Sum(i => i.AdjustmentAmount)) + " paid with this charge.");
                            int[] paymentChargeId = { paymentCharge.Id };
                            await this._paymentRemarkCodeRepository.Delete(paymentChargeId);
                            await this._paymentRemarkCodeRepository.AddAll(item.RemarkCodeIds, paymentCharge.Id);
                        }
                        else
                        {
                            paymentC.Id = 0;
                            paymentC.PaidAmount = isDenial > 0 ? 0 : payment.IsReversed ? item.PaidAmount * -1 : item.PaidAmount;
                            //paymentC.PaidAmount = isDenial > 0 ? 0 : paymentC.PaidAmount;
                            paymentC.PaymentId = payment.Id;
                            paymentC.ChargeId = item.Id;

                            returnResult = await this._paymentChargeRepository.AddNew(paymentC);
                            await this._actionNoteRepository.AddPaymentNote(payment.PatientId, item.Id, "Payment (#" + voucher.ReferenceNo + ") of $" + (paymentC.PaidAmount + item.Adjustments.Sum(i => i.AdjustmentAmount)) + " paid with this charge.");

                            await this._paymentRemarkCodeRepository.AddAll(item.RemarkCodeIds, returnResult.Id);
                        }

                        await this.AddUpdateAdjustmentObject(item.Adjustments, returnResult, payment, true,paymentSourceCD);
                    }

                    if (returnResult == null)
                        await this.AddUpdateAdjustmentObject(item.Adjustments, paymentCharge, payment, false, paymentSourceCD);
                }


                //this._transactionProvider.CommitTransaction(transactionId);
                return returnResult;
            }
            catch
            {
               // this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<int> UpdateChargeWithIsDenialCase(int isDenial, ICharges item, string paymentSourceCD, IPayment payment)
        {
            //var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var chargeData = await this._chargesRepository.GetById(item.Id);

                if (paymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower() && isDenial == 0 && chargeData.DueByFlagCD != DrugFlagTypeEnum.PATIENT.ToString() && ((item.PaidAmount > 0) || (item.PaidAmount == 0 &&
                    item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR1.ToString() || i.Code == AdjustmentCodes.PR2.ToString() || i.Code == AdjustmentCodes.PR3.ToString() || i.Code == AdjustmentCodes.Bonus.ToString()).Sum(i => i.AdjustmentAmount) > 0)))
                {
                    var insurancePolicyData = await this._insurancePolicyRepository.GetById(chargeData.PatientCaseId);

                    insurancePolicyData = insurancePolicyData.Where(i => i.PatientCaseId == chargeData.PatientCaseId
                    && (i.PlanEffectiveDate.HasValue
                            && i.PlanEffectiveDate.Value.Date <= chargeData.BillFromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= chargeData.BillFromDate.Date))).ToList();

                    if (insurancePolicyData.Count() > 0)
                    {
                        var insuranceLevel = insurancePolicyData.Select(i => i.InsuranceLevel).Distinct();
                        if(payment.IsReversed==false)
                        {
                            chargeData.DueByFlagCD = chargeData.DueAmount == 0 ? "Patient" : await this.SetDueBy(insuranceLevel.ToArray(), item.DueByFlagCD.ToLower());
                            chargeData.BillToPatient = chargeData.DueByFlagCD.ToLower() == "patient" ? true : false;
                            chargeData.BillToInsurance = chargeData.DueByFlagCD.ToLower() == "patient" ? false : true;
                        }
                        else
                        {
                            if(!string.IsNullOrWhiteSpace(payment.PayorControl))
                            {
                                var claim = await this._claimRepository.GetByPatientControlNumber(payment.PayorControl);
                                if(claim!=null)
                                {
                                    if (claim.InsLevel == 1)
                                        chargeData.DueByFlagCD = "Primary";
                                    if (claim.InsLevel == 2)
                                        chargeData.DueByFlagCD = "Secondary";

                                    //chargeData.DueByFlagCD = chargeData.DueAmount == 0 ? "Patient" : await this.SetDueBy(insuranceLevel.ToArray(), item.DueByFlagCD.ToLower());
                                    chargeData.BillToPatient = chargeData.DueByFlagCD.ToLower() == "patient" ? true : false;
                                    chargeData.BillToInsurance = chargeData.DueByFlagCD.ToLower() == "patient" ? false : true;
                                }
                            }
                        }
                        

                        chargeData.AllowedAmount = item.AllowedAmount;
                        chargeData.Deductible = item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR1.ToString()).Count() > 0 ? item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR1.ToString()).FirstOrDefault().AdjustmentAmount : 0;
                        chargeData.CoIns = item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR2.ToString()).Count() > 0 ? item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR2.ToString()).FirstOrDefault().AdjustmentAmount : 0;
                        chargeData.CoPay = item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR3.ToString()).Count() > 0 ? item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR3.ToString()).FirstOrDefault().AdjustmentAmount : 0;
                        chargeData.BonusAmount = item.Adjustments.Where(i => i.IsBonus == true) != null ? chargeData.BonusAmount == null ? 0 + item.Adjustments.Where(i => i.IsBonus == true).Sum(i=>i.AdjustmentAmount) : chargeData.BonusAmount + item.Adjustments.Where(i => i.IsBonus == true).Sum(i => i.AdjustmentAmount) : 0;
                        chargeData.ShiftDate = DateTime.Now;
                        return await this._chargesRepository.UpdateWithShiftDate(chargeData);
                    }
                }
                else
                {
                    if (item.AllowedAmount > 0)
                    {
                        chargeData.AllowedAmount = item.AllowedAmount;
                        return await this._chargesRepository.UpdateAllowedAmount(chargeData);
                    }
                }

                //var returnObject = await this._chargesRepository.UpdateWithShiftDate(item);
                //this._transactionProvider.CommitTransaction(transactionId);

                return 1;
            }
            catch
            {
               // this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<int> UpdateChargeWithIsDenialCaseForReversePayment(int isDenial, ICharges item, string paymentSourceCD, IPayment payment)
        {
            //var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var chargeData = await this._chargesRepository.GetById(item.Id);

                if (paymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower() && isDenial == 0 && chargeData.DueByFlagCD != DrugFlagTypeEnum.PATIENT.ToString() && ((item.PaidAmount != 0) || (item.PaidAmount == 0 &&
                    item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR1.ToString() || i.Code == AdjustmentCodes.PR2.ToString() || i.Code == AdjustmentCodes.PR3.ToString() || i.Code == AdjustmentCodes.Bonus.ToString()).Sum(i => i.AdjustmentAmount) > 0)))
                {
                    var insurancePolicyData = await this._insurancePolicyRepository.GetById(chargeData.PatientCaseId);

                    insurancePolicyData = insurancePolicyData.Where(i => i.PatientCaseId == chargeData.PatientCaseId
                    && (i.PlanEffectiveDate.HasValue
                            && i.PlanEffectiveDate.Value.Date <= chargeData.BillFromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= chargeData.BillFromDate.Date))).ToList();

                    if (insurancePolicyData.Count() > 0)
                    {
                        var insuranceLevel = insurancePolicyData.Select(i => i.InsuranceLevel).Distinct();
                        if (payment.IsReversed == false)
                        {
                            chargeData.DueByFlagCD = chargeData.DueAmount == 0 ? "Patient" : await this.SetDueBy(insuranceLevel.ToArray(), item.DueByFlagCD.ToLower());
                            chargeData.BillToPatient = chargeData.DueByFlagCD.ToLower() == "patient" ? true : false;
                            chargeData.BillToInsurance = chargeData.DueByFlagCD.ToLower() == "patient" ? false : true;
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(payment.PayorControl))
                            {
                                var claim = await this._claimRepository.GetByPatientControlNumber(payment.PayorControl);
                                if (claim != null)
                                {
                                    if (claim.InsLevel == 1)
                                        chargeData.DueByFlagCD = "Primary";
                                    if (claim.InsLevel == 2)
                                        chargeData.DueByFlagCD = "Secondary";

                                    //chargeData.DueByFlagCD = chargeData.DueAmount == 0 ? "Patient" : await this.SetDueBy(insuranceLevel.ToArray(), item.DueByFlagCD.ToLower());
                                    chargeData.BillToPatient = chargeData.DueByFlagCD.ToLower() == "patient" ? true : false;
                                    chargeData.BillToInsurance = chargeData.DueByFlagCD.ToLower() == "patient" ? false : true;
                                }
                            }
                        }


                        chargeData.AllowedAmount = item.AllowedAmount;
                        chargeData.Deductible = item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR1.ToString()).Count() > 0 ? item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR1.ToString()).FirstOrDefault().AdjustmentAmount : 0;
                        chargeData.CoIns = item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR2.ToString()).Count() > 0 ? item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR2.ToString()).FirstOrDefault().AdjustmentAmount : 0;
                        chargeData.CoPay = item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR3.ToString()).Count() > 0 ? item.Adjustments.Where(i => i.Code == AdjustmentCodes.PR3.ToString()).FirstOrDefault().AdjustmentAmount : 0;
                        chargeData.BonusAmount = item.Adjustments.Where(i => i.IsBonus == true) != null ? chargeData.BonusAmount == null ? 0 + item.Adjustments.Where(i => i.IsBonus == true).Sum(i => i.AdjustmentAmount) : chargeData.BonusAmount + item.Adjustments.Where(i => i.IsBonus == true).Sum(i => i.AdjustmentAmount) : 0;
                        chargeData.ShiftDate = DateTime.Now;
                        return await this._chargesRepository.UpdateWithShiftDate(chargeData);
                    }
                }
                else
                {
                    if (item.AllowedAmount > 0)
                    {
                        chargeData.AllowedAmount = item.AllowedAmount;
                        return await this._chargesRepository.UpdateAllowedAmount(chargeData);
                    }
                }

                //var returnObject = await this._chargesRepository.UpdateWithShiftDate(item);
                //this._transactionProvider.CommitTransaction(transactionId);

                return 1;
            }
            catch
            {
                // this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<int> UpdateIsCommitted(IEnumerable<ICharges> charges)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                int[] patientCaseId = charges.Select(i => i.PatientCaseId).ToArray();
                var insurancePolicyData = await this._insurancePolicyRepository.GetByCaseId(patientCaseId.Distinct());

                foreach (var chargeData in charges)
                {
                    var insurancePolicy = insurancePolicyData.Where(i => i.PatientCaseId == chargeData.PatientCaseId
                    &&(i.PlanEffectiveDate.HasValue
                            && i.PlanEffectiveDate.Value.Date <= chargeData.BillFromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= chargeData.BillFromDate.Date))).ToList();
                    if (insurancePolicy.Count() > 0)
                    {
                        var insuranceLevel = insurancePolicy.Select(i => i.InsuranceLevel).Distinct();
                        chargeData.DueByFlagCD = chargeData.DueAmount == 0 ? "" : await this.SetDueBy(insuranceLevel.ToArray(), chargeData.DueByFlagCD.ToLower());
                        chargeData.BillToPatient = chargeData.DueByFlagCD.ToLower() == "patient" ? true : false;
                        chargeData.BillToInsurance = chargeData.DueByFlagCD.ToLower() == "patient" ? false : true;
                        chargeData.ShiftDate = DateTime.Now;
                        await this._chargesRepository.UpdateWithShiftDate(chargeData);
                    }
                }

                this._transactionProvider.CommitTransaction(transactionId);
                return 0;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<int> UpdateIsCommittedForReversePayment(IEnumerable<ICharges> charges)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                int[] patientCaseId = charges.Select(i => i.PatientCaseId).ToArray();
                var claims = await this._claimRepository.GetClaimsForReversePayment(charges.Where(i=>!string.IsNullOrWhiteSpace(i.PatientAccountNumber)).Select(i => i.PatientAccountNumber));

                foreach (var chargeData in charges)
                {
                    var findClaim = claims.FirstOrDefault(i => i.PatientAccountNumber == chargeData.PatientAccountNumber);
                    if(findClaim!=null)
                    {
                        if (findClaim.InsLevel == 1)
                            chargeData.DueByFlagCD = "Primary";
                        if (findClaim.InsLevel == 2)
                            chargeData.DueByFlagCD = "Secondary";
                        chargeData.BillToPatient = chargeData.DueByFlagCD.ToLower() == "patient" ? true : false;
                        chargeData.BillToInsurance = chargeData.DueByFlagCD.ToLower() == "patient" ? false : true;
                        chargeData.ShiftDate = DateTime.Now;
                        await this._chargesRepository.UpdateWithShiftDate(chargeData);
                    }
                }
                this._transactionProvider.CommitTransaction(transactionId);
                return 0;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<string> SetDueBy(int[] insuranceLevel, string dueByFlagCD)
        {
            string dueBy = "";
            switch (dueByFlagCD.ToLower())
            {
                case "primary":
                    if (insuranceLevel.Count() > 1)
                        dueBy = "Secondary";
                    else
                        dueBy = "Patient";
                    break;
                case "secondary":
                    if (insuranceLevel.Count() > 2)
                        dueBy = "Tertiary";
                    else
                        dueBy = "Patient";
                    break;
                case "Tertiary":
                    if (insuranceLevel.Count() > 3)
                        dueBy = "Fourth";
                    else
                        dueBy = "Patient";
                    break;
                default:
                    dueBy = "Patient";
                    break;
            }

            return dueBy;
        }

        private async Task AddUpdateAdjustmentObject(IEnumerable<IDefaultReasonCode> defaultAdjustmentsCodes, IPaymentCharge paymentCharge, IPayment payment, bool isSave, string paymentSourceCD="")
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                int paymentChargeUId = isSave ? paymentCharge.Id : defaultAdjustmentsCodes.FirstOrDefault().PaymentChargeId;
                var paymentAdjustmentData = await this.GetByPaymentChargeUId(paymentChargeUId, isSave);

                foreach (var item in defaultAdjustmentsCodes)
                {
                    //if (item.AdjustmentAmount > 0 || item.IsDenial)
                    //{
                    var adjustmentData = paymentAdjustmentData.Where(i => i.ReasonCode == item.Code).FirstOrDefault();

                    if (adjustmentData == null)
                    {
                        if (item.AdjustmentAmount > 0 || item.IsDenial)
                        {
                            item.AdjustmentAmount = payment.IsReversed ? item.AdjustmentAmount * -1 : item.AdjustmentAmount;
                            var getAdjustmentObject = await this.CreateAdjustmentObject(item, paymentCharge.Id);
                            getAdjustmentObject.ChargeId = paymentCharge.ChargeId;
                            getAdjustmentObject.PaymentSourceCD = paymentSourceCD;
                            await this._paymentAdjustmentRepository.AddNew(getAdjustmentObject);
                        }
                    }
                    else
                    {

                        List<string> lst = new List<string>() { "PR2", "PR1", "PR3", "Bonus" };

                        adjustmentData.Amount = payment.IsReversed ? item.AdjustmentAmount < 0 ? item.AdjustmentAmount : item.AdjustmentAmount * -1 : item.AdjustmentAmount;

                        var record = lst.FirstOrDefault(i => i.ToString()== adjustmentData.ReasonCode);
                        if(record==null)
                        {
                            adjustmentData.IsAccounted = item.IsDenial ? false : true;
                        }
                        
                        adjustmentData.IsDenial = item.IsDenial;
                        adjustmentData.IsBonus = item.IsBonus;

                        await this._paymentAdjustmentRepository.Update(adjustmentData);
                    }
                    //}
                    //else if (isSave)
                    //{
                    //    var adjustmentData = paymentAdjustmentData.Where(i => i.ReasonCode == item.Code).FirstOrDefault();
                    //    if (adjustmentData != null)
                    //    {
                    //        adjustmentData.Amount = item.AdjustmentAmount;
                    //        adjustmentData.IsAccounted = item.IsDenial ? false : true;
                    //        adjustmentData.IsDenial = item.IsDenial;

                    //        await this._paymentAdjustmentRepository.Update(adjustmentData);
                    //    }
                    //}
                }

                this._transactionProvider.CommitTransaction(transactionId);
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<IPaymentAdjustment> CreateAdjustmentObject(IDefaultReasonCode item, int paymentChargeId)
        {
            var defaultReasonCode = await this._defaultReasonCodeRepository.GetAll();
            PaymentAdjustment paymentAdjustment = new PaymentAdjustment();
            paymentAdjustment.Amount = item.AdjustmentAmount;
            paymentAdjustment.Id = 0;
            paymentAdjustment.IsDenial = defaultReasonCode.Where(i => i.Code == item.Code && i.IsFixed == true).FirstOrDefault() == null ? item.IsDenial : false;
            paymentAdjustment.ReasonCode = item.Code;
            paymentAdjustment.PaymentChargeId = paymentChargeId;
            paymentAdjustment.IsBonus = item.IsBonus;
            paymentAdjustment.IsAccounted = item.IsDenial ? false : defaultReasonCode.Where(i => i.Code == item.Code && i.IsFixed == true).FirstOrDefault() == null ? item.IsAccounted : defaultReasonCode.Where(i => i.Code == item.Code).FirstOrDefault().IsAccounted;

            return paymentAdjustment;
        }

        private async Task<IEnumerable<IPaymentBatchDTO>> CreateGroupBy(IEnumerable<IPaymentBatchDTO> entities)
        {
            List<IPaymentBatchDTO> paymentDTO = new List<IPaymentBatchDTO>();

            var groupByBatch = entities.GroupBy(i => i.BatchNo);

            foreach (var batches in groupByBatch)
            {
                foreach (var item in batches)
                {
                    var paymentRow = paymentDTO.Where(i => i.BatchNo == item.BatchNo).FirstOrDefault();
                    if (paymentRow == null)
                    {
                        paymentDTO.Add(item);
                    }
                    else
                    {
                        var charges = paymentRow.Charges.ToList();
                        charges.AddRange(item.Charges);
                        paymentRow.Charges = charges;
                    }
                }
            }

            return paymentDTO;
        }

        public async Task<int> Delete(Guid Id)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {

                Guid[] arrPaymentIds = { Id };
                var paymentData = await this._paymentRepository.GetByUId(Id);
                int[] paymentIds = { paymentData.Id };
                // var voucherData = await this._paymentRepository.GetByVoucherId(paymentData.VoucherId);
                var voucher = await this._voucherRepository.Get(paymentData.VoucherId);

                var paymentChargeData = await this._paymentChargeRepository.GetByPaymentId(paymentIds);
                var paymentChargeIds = (paymentChargeData).Select(i => i.Id);
                var chargeIds = (paymentChargeData).Select(i => i.ChargeId);
                var paymentAdjustments = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds);

                

                foreach (var item in chargeIds)
                {
                    var paymentAmount = paymentChargeData.Where(i => i.ChargeId == item).Sum(i => i.PaidAmount);
                    var Ids = paymentChargeData.Where(i => i.ChargeId == item).Select(i => i.Id);
                    var adjustment = paymentAdjustments.Where(i => Ids.Contains(i.PaymentChargeId)).Sum(i => i.Amount);
                    decimal amount = paymentAmount + adjustment;
                    amount = (decimal)System.Math.Round(amount, 2);
                    await this._actionNoteRepository.AddPaymentNote(paymentData.PatientId, item, "Payment (#" + voucher.ReferenceNo + ") of $" + (amount) + " deleted with this charge.");
                }

                await this._paymentAdjustmentRepository.DeleteById(paymentChargeIds);
                await this._paymentRemarkCodeRepository.Delete(paymentChargeIds);
                //var charge = (await this._paymentChargeRepository.GetById(paymentChargeIds)).Select(i => i.ChargeId);
                //var charges = await this.CreateObject(charge);

                //foreach (var item in charges)
                //    await this._chargesRepository.Update(item);

                await this._paymentChargeRepository.DeleteByPaymentId(paymentIds);

                await this._portalPaymentRepository.MarkPaymentIdAsDeleted(paymentIds);

                await this._portalPaymentChildRepository.Delete(paymentIds.FirstOrDefault());

                await this._paymentRepository.Delete(arrPaymentIds);

                this._transactionProvider.CommitTransaction(transactionId);
                //if (voucherData.Count() == 1)
                //    await this._voucherRepository.Delete(paymentData.VoucherId);

                return 1;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> DeleteChargePayment(Guid Id)
        {
            
            try
            {
                Guid[] arrPaymentIds = { Id };
                var paymentchargeData = await this._paymentChargeRepository.Get(Id);
                if(paymentchargeData==null)
                {
                    return 0;
                }
                int[] paymentChargeIds = { paymentchargeData.Id };

                var payment = await this._paymentRepository.GetById(paymentchargeData.PaymentId);
                if(payment.PaymentSourceCD==PaymentSourceTypeEnum.CARD_PAYMENT.ToString())
                {
                   return await this.DeleteCreditCardChargePayment(payment.Id);
                }
                var voucher = await this._voucherRepository.Get(payment.VoucherId);
                var paymentAdjustments = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentchargeData.Id);

                var amount = (decimal)System.Math.Round(paymentAdjustments.Sum(i => i.Amount) + paymentchargeData.Amount, 2);
                await this._actionNoteRepository.AddPaymentNote(payment.PatientId, paymentchargeData.ChargeId, "Payment (#" + voucher.ReferenceNo + ") of $" + amount + " deleted with this charge.");

                var paymentId = paymentchargeData.PaymentId;
                await this._paymentAdjustmentRepository.DeleteById(paymentChargeIds);
                await this._paymentRemarkCodeRepository.Delete(paymentChargeIds);
                //var charge = (await this._paymentChargeRepository.GetById(paymentChargeIds)).Select(i => i.ChargeId);
                //var charges = await this.CreateObject(charge);

                //foreach (var item in charges)
                //    await this._chargesRepository.Update(item);

                await this._paymentChargeRepository.DeleteByPaymentChargeId(paymentChargeIds.FirstOrDefault());

                var paymentExists = await this._paymentChargeRepository.GetByPaymentId(paymentId);
                if (paymentExists == null || paymentExists.Count() == 0)
                {
                    int[] paymentIds = { paymentId };

                    await this._portalPaymentRepository.MarkPaymentIdAsDeleted(paymentIds);

                    await this._portalPaymentChildRepository.Delete(paymentIds.FirstOrDefault());

                    await this._paymentRepository.Delete(paymentId);
                }
                    
                
                return 1;
            }
            catch
            {
                
                throw;
            }
        }

        private async Task<int> DeleteCreditCardChargePayment(int paymentId)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var paymentcharges = await this._paymentChargeRepository.GetByPaymentId(paymentId);
                var paidAmount = paymentcharges.Sum(i => i.PaidAmount);
                int[] paymentIds = { paymentId };

                await this._portalPaymentRepository.MarkPaymentIdAsDeleted(paymentIds, paidAmount);

                foreach (var paymentchargeData in paymentcharges)
                {                    
                    int[] paymentChargeIds = { paymentchargeData.Id };

                    var payment = await this._paymentRepository.GetById(paymentchargeData.PaymentId);

                    var voucher = await this._voucherRepository.Get(payment.VoucherId);
                    var paymentAdjustments = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentchargeData.Id);

                    var amount = (decimal)System.Math.Round(paymentAdjustments.Sum(i => i.Amount) + paymentchargeData.Amount, 2);
                    await this._actionNoteRepository.AddPaymentNote(payment.PatientId, paymentchargeData.ChargeId, "Payment (#" + voucher.ReferenceNo + ") of $" + amount + " deleted with this charge.");

                    //var paymentId = paymentchargeData.PaymentId;
                    await this._paymentAdjustmentRepository.DeleteById(paymentChargeIds);
                    await this._paymentRemarkCodeRepository.Delete(paymentChargeIds);

                    await this._paymentChargeRepository.DeleteByPaymentChargeId(paymentChargeIds.FirstOrDefault());
                }

                

                await this._portalPaymentChildRepository.Delete(paymentIds.FirstOrDefault());

                await this._paymentRepository.Delete(paymentId);

                this._transactionProvider.CommitTransaction(transactionId);

                return 1;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<IEnumerable<ICharges>> CreateObject(IEnumerable<int> ChargeIds)
        {
            List<Charges> list = new List<Charges>();
            foreach (var item in ChargeIds)
            {
                Charges charges = await this._chargesRepository.GetById(item) as Charges;
                charges.Id = item;
                charges.AllowedAmount = 0;
                charges.CoIns = 0;
                charges.CoPay = 0;
                charges.Deductible = 0;

                list.Add(charges);
            }

            return list;
        }

        public async Task<int> DeleteVoucher(Guid UId)
        {

            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var voucherData = await this._voucherRepository.GetByUId(UId);
                voucherData.Id = voucherData == null ? 0 : voucherData.Id;
                var paymentData = await this._paymentRepository.GetByVoucherId(voucherData.Id);
                List<int> paymentId = new List<int>();
                paymentId.AddRange(paymentData.Select(i => i.Id));

                var paymentChargeData = await this._paymentChargeRepository.GetByPaymentId(paymentId);
                var paymentChargeIds = (paymentChargeData).Select(i => i.Id);
                var paymentAdjustData = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds);

                foreach (var item in paymentData)
                {
                    var paymentCharge = paymentChargeData.Where(i => i.PaymentId == item.Id);

                    foreach (var chargeId in paymentCharge)
                    {
                        decimal amount = paymentAdjustData.Where(i => i.PaymentChargeId == chargeId.Id).Sum(i => i.Amount);
                        amount = (decimal)System.Math.Round(amount, 2);
                        await this._actionNoteRepository.AddPaymentNote(item.PatientId, chargeId.ChargeId, "Payment (#" + voucherData.ReferenceNo + ") of $" + amount + " deleted with this charge.");
                    }
                }

                await this._paymentAdjustmentRepository.DeleteById(paymentChargeIds);
                await this._paymentRemarkCodeRepository.Delete(paymentChargeIds);
                await this._paymentChargeRepository.DeleteByPaymentId(paymentId);

                await this._portalPaymentRepository.MarkPaymentIdAsDeleted(paymentId);

                await this._portalPaymentChildRepository.Delete(paymentId.FirstOrDefault());

                await this._paymentRepository.Delete(paymentData.Select(i => i.UId));
                await this._voucherRepository.Delete(UId);

                this._transactionProvider.CommitTransaction(transactionId);
                return 1;

            }
            catch (Exception ex)
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
            
        }

        public async Task<IEnumerable<IBulkPaymentScreenDTO>> GetBulkPayment(IBulkPaymentFilter filter)
        {
            try
            {
                if (filter.DepositTypeUIds != null && filter.DepositTypeUIds != "null")
                {
                    string[] uids = filter.DepositTypeUIds.Split(',').ToArray<string>();
                    List<Guid> depositTypeUIds = new List<Guid>();
                    uids.ToList().ForEach((res) =>
                    {
                        if (res != "0")
                            depositTypeUIds.Add(new Guid(res));
                    });

                    var depositType = await this._depositTypeRepository.GetByUId(depositTypeUIds);
                    filter.DepositTypeIds = depositType == null ? string.Empty : string.Join(',', depositType.Select(i => i.Id));
                }

                filter.BatchFromDate = Convert.ToDateTime(filter.FromDate).Date.ToString("yyyy-MM-dd 00:00:00");
                filter.BatchToDate = Convert.ToDateTime(filter.ToDate).Date.ToString("yyyy-MM-dd 23:59:59");
                filter.FromDate = Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00");
                filter.ToDate = Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59");

                var voucherData = await this._voucherRepository.GetVoucher(filter);

                int[] batchIds = voucherData.Select(i => i.PaymentBatchId).ToArray();
                var batchData = await this._paymentBatchRepository.GetBatch(filter, batchIds);

                batchData.ToList().ForEach((item) =>
                {
                    if (filter.DifferenceId != null && filter.DifferenceId != 0)
                        item.Vouchers = filter.DifferenceId == 1 ? voucherData.Where(i => i.PaymentBatchId == item.PaymentBatchId && i.DifferenceAmount != 0) : voucherData.Where(i => i.PaymentBatchId == item.PaymentBatchId && i.DifferenceAmount == 0);
                    else
                        item.Vouchers = voucherData.Where(i => i.PaymentBatchId == item.PaymentBatchId);

                    item.DepositAmount = item.Vouchers.Sum(i => i.DepositAmount);
                    item.PostedAmount = item.Vouchers.Sum(i => i.PostedAmount);
                    item.DifferenceAmount = item.BatchAmount - item.PostedAmount;
                });

                return batchData;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IVoucherViewDTO>> GetBulkVouchers(IVoucherViewFilter filter)
        {
            filter.FromDate = Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00");
            filter.ToDate = Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59");

            return  await this._paymentBatchRepository.GetBulkVouchers(filter);
        }

        private IEnumerable<IBulkPaymentScreenDTO> FindDistinct(List<IBulkPaymentScreenDTO> fullList, List<IBulkPaymentScreenDTO> lessList)
        {
            foreach (var item in fullList)
            {
                var findData = lessList.Find(i => i.PaymentBatchId == item.PaymentBatchId);
                if (findData == null)
                {
                    lessList.Add(item);
                }
            }

            return lessList;
        }

        public async Task<int> DeleteByBatchUId(Guid batchUId, bool IsDelete)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var paymentBatch = await this._paymentBatchRepository.Get(batchUId);
                if (IsDelete)
                {
                    var voucherData = await this._voucherRepository.GetByBatchId(paymentBatch.Id);
                    if (voucherData.Count() > 0)
                        await this._paymentBatchRepository.ThrowError();

                    return await this._paymentBatchRepository.Delete(batchUId);
                }

                var voucherUId = (await this._voucherRepository.GetByBatchId(paymentBatch.Id)).Select(i => i.UId);

                foreach (var item in voucherUId)
                    await this.DeleteVoucher(item);

                this._transactionProvider.CommitTransaction(transactionId);

                return await this._paymentBatchRepository.Delete(batchUId);

            }
            catch (Exception ex)
            {
                this._transactionProvider.RollbackTransaction(transactionId);

                throw;
            }
           
        }

        public async Task<IBatchListDTO> GetBatches(IBatchFilter filter)
        {
            filter.InsuranceCompanyId = (filter.InsuranceCompanyUId == "undefined" || filter.InsuranceCompanyUId == "null" || filter.InsuranceCompanyUId == null) ? 0 : (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(filter.InsuranceCompanyUId))).Id;

            filter.FromDate = filter.FromDate == null ? null : Convert.ToDateTime(filter.FromDate).Date.ToString("yyyy-MM-dd");
            filter.ToDate = filter.ToDate == null ? null : Convert.ToDateTime(filter.ToDate).Date.ToString("yyyy-MM-dd");

            BatchListDTO batchListDTO = new BatchListDTO();
            batchListDTO.ChargeBatch = await this._chargeBatchRepository.GetChargeGrid(filter);
            batchListDTO.PaymentBatch = await this._paymentBatchRepository.GetPaymentBatchGrid(filter);

            return batchListDTO;
        }

        public async Task<IVoucher> Update(IVoucher entity, IEnumerable<IFormFile> formFiles)
        {
            var voucher = await this._voucherRepository.Update(entity);

            //var attachmentVoucher = await this._attFileRepository.GetByTableId(voucher.Id, AttTableConstant.Voucher);
            //int[] attachmentIds = attachmentVoucher.Select(i => i.Id).ToArray();
            //await this._attFileRepository.Delete(attachmentIds);

            foreach (var formFile in formFiles)
            {
                var addAttachment = await this._attFileRepository.CreateAttachments(formFile, voucher.Id, AttTableConstant.Voucher, formFile.FileName);
                var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.Voucher);
            }

            return voucher;
        }

        public async Task<bool> CommitPayments(Guid? voucherUId, Guid? paymentUId)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                

                if (voucherUId != null && paymentUId == null)
                {
                    var voucherData = await this._voucherRepository.GetByUId(voucherUId.Value);
                    var paymentData = await this._paymentRepository.GetByVoucherId(voucherData.Id);
                    IEnumerable<int> paymentIds = paymentData.Select(i => i.Id);
                    await this._paymentRepository.UpdateCommitedTransaction(paymentIds);
                    await this._voucherRepository.UpdateCommitedTransaction(voucherUId.Value);
                    await this.ChangeDueByForReversePayment(voucherData, null);
                    await this.ChangeDueBy(voucherData, null);                    
                }
                else
                {
                    var paymentData = await this._paymentRepository.GetByUId(paymentUId.Value);
                    var payments = await this._paymentRepository.GetByVoucherId(paymentData.VoucherId);
                    if (payments.Count() > 1)
                    {
                        await this._paymentRepository.UpdateCommitedTransaction(paymentUId, null);
                        await this.ChangeDueByForReversePayment(null, paymentData);
                        await this.ChangeDueBy(null, paymentData);
                    }
                    else
                    {
                        await this._paymentRepository.UpdateCommitedTransaction(paymentUId, null);
                        var voucherGet = await this._voucherRepository.Get(paymentData.VoucherId);
                        await this._voucherRepository.UpdateCommitedTransaction(voucherGet.UId);
                        await this.ChangeDueByForReversePayment(voucherGet, null);
                        await this.ChangeDueBy(voucherGet, null);
                    }
                }
                this._transactionProvider.CommitTransaction(transactionId);
                return true;
            }
            catch (Exception ex)
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }

            
        }

        private async Task<int> ChangeDueBy(IVoucher voucherEntity, IPayment paymentEntity)
        {
            try
            {
                var paymentData = paymentEntity == null ? await this._paymentRepository.GetByVoucherId(voucherEntity.Id) : await this._paymentRepository.GetByVoucherId(paymentEntity.VoucherId);
                int[] paymentIds = paymentData.Where(i=>i.IsReversed==false).Select(i => i.Id).ToArray();
                //int[] paymentIds = paymentData.Select(i => i.Id).ToArray();

                List<List<int>> tempPaymentIds = new List<List<int>>();
                if (paymentIds.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempPaymentIds = CollectionChunksHelper.Chunk(paymentIds, 2000);
                }

                List<IPaymentCharge> paymentChargesData = new List<IPaymentCharge>();
                foreach (var item in tempPaymentIds)
                {
                    paymentChargesData.AddRange(await this._paymentChargeRepository.GetByPaymentId(item));
                }

                //var paymentChargesData = await this._paymentChargeRepository.GetByPaymentId(paymentIds);
                var chargeIds = (paymentChargesData).Select(i => i.ChargeId).Distinct();
                var paymentChargeIds = (paymentChargesData).Select(i => i.Id).Distinct();

                List<List<int>> tempPaymentChargeIds = new List<List<int>>();
                if (paymentChargeIds.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempPaymentChargeIds = CollectionChunksHelper.Chunk(paymentChargeIds, 2000);
                }

                List<IPaymentAdjustment> paymentAdjustmentData = new List<IPaymentAdjustment>();
                foreach (var item in tempPaymentChargeIds)
                {
                    paymentAdjustmentData.AddRange(await this._paymentAdjustmentRepository.GetByPaymentChargeId(item));
                }

                //var paymentAdjustmentData = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds);
                //var chargeData = await this._chargesRepository.GetByIds(chargeIds);

                List<List<int>> tempChargeIds = new List<List<int>>();
                if (chargeIds.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempChargeIds = CollectionChunksHelper.Chunk(chargeIds, 2000);
                }

                List<ICharges> chargeData = new List<ICharges>();
                foreach (var item in tempChargeIds)
                {
                    chargeData.AddRange(await this._chargesRepository.GetByIds(item));
                }


                int count = 0;
                chargeData.ToList().ForEach(res =>
                {
                    res.PaymentCharges = paymentChargesData.Where(i => i.ChargeId == res.Id);
                    int[] paymentCharges = res.PaymentCharges.Select(i => i.Id).ToArray();
                    var paymentAdjustments = paymentAdjustmentData.Where(i => paymentCharges.Contains(i.PaymentChargeId));

                    int isDenial = paymentAdjustments.Count(i => i.IsDenial == true);

                    if (isDenial == 0 && ((res.PaidAmount > 0) || (res.PaidAmount == 0 &&
                    paymentAdjustments.Where(i => i.ReasonCode == "PR1" || i.ReasonCode == "PR2" || i.ReasonCode == "PR3").Sum(i => i.Amount) > 0)) &&
                    (res.DueByFlagCD != DrugFlagTypeEnum.PATIENT.ToString() && res.DueByFlagCD != string.Empty))
                        res.IsChargeDeleted = true;

                    res.Deductible = paymentAdjustments.Where(i => i.ReasonCode == "PR1").Count() > 0 ? paymentAdjustments.Where(i => i.ReasonCode == "PR1").FirstOrDefault().Amount : 0;
                    res.CoIns = paymentAdjustments.Where(i => i.ReasonCode == "PR2").Count() > 0 ? paymentAdjustments.Where(i => i.ReasonCode == "PR2").FirstOrDefault().Amount : 0;
                    res.CoPay = paymentAdjustments.Where(i => i.ReasonCode == "PR3").Count() > 0 ? paymentAdjustments.Where(i => i.ReasonCode == "PR3").FirstOrDefault().Amount : 0;
                    res.BonusAmount = paymentAdjustments.Where(i => i.IsBonus == true).Count() > 0 ? res.BonusAmount == null ? 0 + paymentAdjustments.Where(i => i.IsBonus == true).Sum(i=>i.Amount) : res.BonusAmount + paymentAdjustments.Where(i => i.IsBonus == true).Sum(i => i.Amount) : 0;
                    res.BillToPatient = (res.DueByFlagCD.ToLower() == "patient" || res.DueByFlagCD.ToLower() == string.Empty) ? true : res.BillToPatient;
                    res.BillToInsurance = (res.DueByFlagCD.ToLower() == "patient" || res.DueByFlagCD.ToLower() == string.Empty) ? false : res.BillToInsurance;
                });

                chargeData = (chargeData.Where(i => i.IsChargeDeleted == true)).ToList();
                await this.UpdateIsCommitted(chargeData);

                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<int> ChangeDueByForReversePayment(IVoucher voucherEntity, IPayment paymentEntity)
        {
            try
            {
                var paymentData = paymentEntity == null ? await this._paymentRepository.GetByVoucherIdForReversePayment(voucherEntity.Id) : await this._paymentRepository.GetByVoucherIdForReversePayment(paymentEntity.VoucherId);
                int[] paymentIds = paymentData.Where(i=>i.IsReversed==true).Select(i => i.Id).ToArray();

                List<List<int>> tempPaymentIds = new List<List<int>>();
                if (paymentIds.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempPaymentIds = CollectionChunksHelper.Chunk(paymentIds, 2000);
                }

                List<IPaymentCharge> paymentChargesData = new List<IPaymentCharge>();
                foreach (var item in tempPaymentIds)
                {
                    paymentChargesData.AddRange(await this._paymentChargeRepository.GetByPaymentId(item));
                }

                //var paymentChargesData = await this._paymentChargeRepository.GetByPaymentId(paymentIds);
                var chargeIds = (paymentChargesData).Select(i => i.ChargeId).Distinct();
                var paymentChargeIds = (paymentChargesData).Select(i => i.Id).Distinct();

                List<List<int>> tempPaymentChargeIds = new List<List<int>>();
                if (paymentChargeIds.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempPaymentChargeIds = CollectionChunksHelper.Chunk(paymentChargeIds, 2000);
                }

                List<IPaymentAdjustment> paymentAdjustmentData = new List<IPaymentAdjustment>();
                foreach (var item in tempPaymentChargeIds)
                {
                    paymentAdjustmentData.AddRange(await this._paymentAdjustmentRepository.GetByPaymentChargeId(item));
                }

                //var paymentAdjustmentData = await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds);
                //var chargeData = await this._chargesRepository.GetByIds(chargeIds);

                List<List<int>> tempChargeIds = new List<List<int>>();
                if (chargeIds.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempChargeIds = CollectionChunksHelper.Chunk(chargeIds, 2000);
                }

                List<ICharges> chargeData = new List<ICharges>();
                foreach (var item in tempChargeIds)
                {
                    chargeData.AddRange(await this._chargesRepository.GetByIds(item));
                }


                int count = 0;
                chargeData.ToList().ForEach(res =>
                {
                    res.PaymentCharges = paymentChargesData.Where(i => i.ChargeId == res.Id);
                    if(res.PaymentCharges.Sum(i=>i.PaidAmount)!=0)
                    {
                        if(res.PaymentCharges.FirstOrDefault().PatientAccountNumber!=null)
                        {
                            res.PatientAccountNumber = res.PaymentCharges.FirstOrDefault().PatientAccountNumber;

                            res.IsChargeDeleted = true;
                        }                        
                    }
                });

                chargeData = (chargeData.Where(i => i.IsChargeDeleted == true)).ToList();
                await this.UpdateIsCommittedForReversePayment(chargeData);
                
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       

        public async Task<IEnumerable<IDefaultReasonCode>> IniIChargeAdjustment(IEnumerable<IPaymentAdjustment> chargeAdjustments)
        {
            List<DefaultReasonCode> defaultAdjustmentData = new List<DefaultReasonCode>();

            foreach (var item in chargeAdjustments)
            {
                DefaultReasonCode adjustment = new DefaultReasonCode();
                var returnResult = defaultAdjustmentData.Find(i => i.Code == item.ReasonCode);

                if (returnResult != null)
                {
                    returnResult.AdjustmentAmount = item.Amount;
                    returnResult.IsDenial = item.IsDenial;
                    returnResult.IsAccounted = item.IsAccounted;
                    returnResult.PaymentChargeId = item.PaymentChargeId;
                }
                else
                {
                    adjustment.Id = item.Id;
                    adjustment.AdjustmentAmount = item.Amount;
                    adjustment.Code = item.ReasonCode;
                    adjustment.DisplayName = item.ReasonCode;
                    adjustment.IsFixed = false;
                    adjustment.PaymentChargeId = item.PaymentChargeId;
                    adjustment.Uid = item.UId;
                    adjustment.IsAccounted = item.IsAccounted;
                    adjustment.IsDenial = item.IsDenial;

                    defaultAdjustmentData.Add(adjustment);
                }
            }

            return defaultAdjustmentData;
        }

        public async Task<IPayment> Get(Guid uid)
        {
            return await this._paymentRepository.GetByUId(uid);
        }

        public async Task<IEnumerable<IPaymentCharge>> GetByPaymentUId(string paymentUId)
        {
            var payment = await this._paymentRepository.GetByUId(Guid.Parse(paymentUId));
            var paymentId = payment == null ? 0 : payment.Id;
            return await this._paymentChargeRepository.GetByPaymentId(paymentId);
        }

        public async Task<IEnumerable<IPaymentAdjustment>> GetByPaymentChargeUId(int paymentChargeId, bool isSave)
        {
            //IPaymentCharge paymentCharge = null;
            //int paymentChargeId = 0;
            //if (isSave)
            //{
            //    paymentCharge = await this._paymentChargeRepository.Get(Guid.Parse(paymentChargeUId));
            //    paymentChargeId = paymentCharge == null ? 0 : paymentCharge.Id;
            //}
            //else
            //{
            //var paymentCharge = await this._paymentChargeRepository.GetById(paymentChargeId);
            //paymentChargeId = paymentCharge == null ? 0 : paymentCharge.Id;
            //}

            return await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeId);
        }

        public async Task<bool> AddBulkAdjustment(Guid invoiceUId, string adjustmentCode, bool isRemarkCode)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var invoice = await this._invoiceRepository.GetByUId(invoiceUId);
                if (invoice != null)
                {
                    var insuranceData = await this._insurancePolicyRepository.GetActivePolicies(invoice.PatientCaseId, invoice.BillFromDate);
                    var activeInsurance = insuranceData.FirstOrDefault();

                    var patient = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                    long patientId = patient == null ? 0 : patient.PatientId;

                    var paymentBatchData = await this._paymentBatchRepository.GetForBulkAdjustment();
                    if (paymentBatchData == null)
                    {
                        PaymentBatch paymentBatch = new PaymentBatch();
                        paymentBatch.Id = 0;
                        paymentBatch.IsSystem = true;
                        paymentBatch.RecordCount = 0;
                        paymentBatch.Amount = 0;
                        paymentBatch.BatchAmount = 0;

                        paymentBatchData = await this._paymentBatchRepository.AddNew(paymentBatch);
                    }

                    int[] invoiceIds = { invoice.Id };
                    var charges = await this._chargesRepository.Get(invoiceIds);

                    var voucher = await this._voucherRepository.GetForBalanceAdjustment(PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString());
                    if (voucher == null)
                    {
                        voucher = await this._voucherRepository.AddNewBulkAdjsutment(await this.CreateVoucherObject(activeInsurance.InsuranceCompanyID, (int)patientId, paymentBatchData.Id), false);
                    }

                    decimal adjustmentAmount = isRemarkCode ? 0 : charges.Sum(i => i.Amount);
                    var payment = await this._paymentRepository.AddNewBulkPayment(await this.CreatePaymentObject(voucher.Id, (int)patientId, activeInsurance.InsuranceCompanyID, adjustmentAmount));

                    var getPaymentChargeList = await this.CreateArrayOfObjectForPayment(payment.Id, charges, adjustmentCode, isRemarkCode);
                    await this._paymentChargeRepository.AddBulkAdjustmentPayment(getPaymentChargeList, isRemarkCode, payment.PatientId);

                    if (!isRemarkCode)
                    {
                        int[] chargeId = charges.Select(i => i.Id).ToArray();

                        foreach (var item in chargeId)
                        {
                            var paymentAdjustment = getPaymentChargeList.FirstOrDefault(i => i.ChargeId == item).PaymentAdjustments.FirstOrDefault().Amount;
                            paymentAdjustment = (decimal)System.Math.Round(paymentAdjustment, 2);
                            await this._actionNoteRepository.AddPaymentNote((int)patientId, item, "Payment (#" + voucher.ReferenceNo + ") of $" + paymentAdjustment + " paid with this charge.");
                        }

                        //int[] chargeIds = charges.Select(i => i.Id).ToArray();
                        //await this._chargesRepository.UpdateDueBy(chargeIds);
                    }
                }
                this._transactionProvider.CommitTransaction(transactionId);
                return true;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task<IVoucher> CreateVoucherObject(int? insuranceId, int? patientId, int? paymentBatchId, bool isBalanceAdjustment = false)
        {
            Voucher voucher = new Voucher();
            voucher.Amount = 0;
            voucher.DepositTypeId = (int)DepositTypeEnum.ClinicEFT;
            voucher.Description = insuranceId == null ? null : DateTime.Now.ToShortDateString().Replace("/", "-") + (await this._insuranceCompanyRepository.GetById(insuranceId)).CompanyName;
            voucher.EffectiveDate = DateTime.Now.Date;
            voucher.InsuranceCompanyId = insuranceId;
            voucher.IsCommitted = true;
            voucher.IsSelfPayment = false;
            voucher.PatientId = patientId;
            voucher.PaymentBatchId = paymentBatchId == null ? 0 : paymentBatchId.Value;
            if (isBalanceAdjustment)
            {
                voucher.PaymentSourceCD = PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString();
            }
            else
            {
                voucher.PaymentSourceCD = PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString();
            }
            voucher.VoucherNo = await this._voucherRepository.CreateVoucherNo();
            voucher.VoucherTypeCD = PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString();
            var insuranceCompanyName = voucher.InsuranceCompanyId.HasValue ? (await this._insuranceCompanyRepository.GetById(voucher.InsuranceCompanyId.Value)).CompanyName : null;
            voucher.InsuranceCompanyName = insuranceCompanyName;
            voucher.ReferenceDate = DateTime.Now.Date;
            voucher.ReferenceNo = "";

            return voucher;
        }

        private async Task<IPayment> CreatePaymentObject(int voucherId, int patientId, int? insuranceId, decimal adjustmentAmount, bool isBalanceAdjustment = false)
        {
            Payment payment = new Payment();
            payment.Amount = 0;
            payment.VoucherId = voucherId;
            payment.TransactionNo = await this._voucherRepository.CreateTransactionNo();
            payment.PatientId = patientId;
            payment.IsCommitted = true;
            payment.Amount = 0;
            payment.Adjustment = adjustmentAmount;
            payment.NonAccAdjustment = 0;
            payment.IsReversed = false;
            if (isBalanceAdjustment)
            {
                payment.PaymentSourceCD = PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString();
            }
            else
            {
                payment.PaymentSourceCD = PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString();
            }
            payment.DepositInsuranceCompanyId = insuranceId;
            payment.PatientInsuranceCompanyId = insuranceId.Value;
            payment.PayorControl = null;

            return payment;
        }

        private async Task<IEnumerable<IPaymentCharge>> CreateArrayOfObjectForPayment(int paymentId, IEnumerable<ICharges> charges, string code, bool isRemarkCode)
        {
            List<IPaymentCharge> paymentCharges = new List<IPaymentCharge>();
            IPaymentCharge paymentCharge = null;
            List<IPaymentAdjustment> adjustments = new List<IPaymentAdjustment>();
            List<IPaymentRemarkCode> remarkCodes = new List<IPaymentRemarkCode>();
            var paymentData = await this._paymentRepository.GetById(paymentId);

            if (isRemarkCode)
            {
                int Id = Convert.ToInt32(code);
                var remarkCode = await this._configERARemarkCodesRepository.Get(Id);
                code = remarkCode == null ? code : remarkCode.RemarkQualifier + ',' + remarkCode.RemarkCode;
            }

            foreach (var res in charges)
            {
                adjustments = new List<IPaymentAdjustment>();
                remarkCodes = new List<IPaymentRemarkCode>();
                paymentCharge = new PaymentCharge();
                paymentCharge.ChargeId = res.Id;
                paymentCharge.PaymentId = paymentId;
                paymentCharge.PaidAmount = 0;

                if (!isRemarkCode)
                {
                    var paymentAdjustment = await this.CreateObjectAdjustment(code, res.Amount);
                    adjustments.Add(paymentAdjustment);
                    paymentCharge.PaymentAdjustments = adjustments;
                }
                else
                {
                    var paymentRemarkCode = await this.CreateObjectRemarkCodes(code);
                    remarkCodes.Add(paymentRemarkCode);
                    paymentCharge.PaymentRemarkCodes = remarkCodes;
                }

                paymentCharges.Add(paymentCharge);
            }

            return paymentCharges;
        }

        private async Task<IPaymentAdjustment> CreateObjectAdjustment(string code, decimal amount)
        {
            IPaymentAdjustment paymentAdjustment = new PaymentAdjustment();
            paymentAdjustment.Amount = amount;
            paymentAdjustment.IsAccounted = true;
            paymentAdjustment.IsDenial = false;
            paymentAdjustment.ReasonCode = code;

            return paymentAdjustment;
        }

        private async Task<IPaymentRemarkCode> CreateObjectRemarkCodes(string code)
        {
            var remarkCode = code.Split(',');
            IPaymentRemarkCode paymentRemarkCode = new PaymentRemarkCode();
            paymentRemarkCode.RemarkCode = remarkCode[1];
            paymentRemarkCode.RemarkQualifier = remarkCode[0];

            return paymentRemarkCode;
        }

        public async Task<bool> WriteOffOldAdjustment(string dosDate)
        {
            var list = await this._chargesReportDataRepository.GetChargesForWriteOffLessThanGivingDates(Convert.ToDateTime(dosDate));
            var charges = await this._chargesRepository.GetChargesForBulkAdjustments(list.Select(i=> new Guid(i.InvoiceUId)).ToList());

            var distinctInvoiceUids = charges.Where(i=>i.DueAmount>0).Select(i => i.InvoiceUId).Distinct();
            foreach (var item in distinctInvoiceUids)
            {
                try
                {
                    var invoiceCharges = charges.Where(i => i.InvoiceUId == item && i.DueAmount>0);
                    await this.AddBalanceAdjustment_OldCharges(item, "WO2022", "", invoiceCharges);
                }
                catch (Exception ex)
                {

                }                
            }

            return true;
        }

        public async Task<bool> WriteOffDueByPatientCharges(string dosDate)
        {
            var list = await this._chargesReportDataRepository.GetOldPatientDueCharges(Convert.ToDateTime(dosDate));
            var charges = await this._chargesRepository.GetChargesForBulkAdjustments(list.Select(i => new Guid(i.InvoiceUId)).ToList());

            var distinctInvoiceUids = charges.Where(i => i.DueAmount > 0).Select(i => i.InvoiceUId).Distinct();
            foreach (var item in distinctInvoiceUids)
            {
                try
                {
                    var invoiceCharges = charges.Where(i => i.InvoiceUId == item && i.DueAmount > 0 && i.DueByFlagCD.ToLower() == "patient");
                    await this.AddBalanceAdjustment_OldCharges(item, "Maddy", "", invoiceCharges);
                }
                catch (Exception ex)
                {

                }
            }

            return true;
        }

        public async Task<bool> WriteOffCharges(string dosDate,string adjustmentCode, string postAdjustmentCode)
        {
            var list = await this._chargesReportDataRepository.GetChargesForWriteOff(Convert.ToDateTime(dosDate),adjustmentCode);
            var charges = await this._chargesRepository.GetChargesForBulkAdjustments(list.Select(i => new Guid(i.InvoiceUId)).ToList());

            var distinctInvoiceUids = charges.Where(i => i.DueAmount > 0).Select(i => i.InvoiceUId).Distinct();
            foreach (var item in distinctInvoiceUids)
            {
                try
                {
                    var invoiceCharges = charges.Where(i => i.InvoiceUId == item);
                    await this.AddBalanceAdjustment_OldCharges(item, postAdjustmentCode, "", invoiceCharges);
                }
                catch (Exception ex)
                {

                }
            }

            return true;
        }

        public async Task<bool> AddBalanceAdjustment(Guid invoiceUId, string adjustmentCode, string remarkCode,IEnumerable<ICharges> charges)
        {
            try
            {
                charges = charges.Where(i => i.DueAmount > 0);
                if(charges.Count()==0)
                {
                    throw new Exception("There are no charge for adjust the balance.");
                }

                var invoice = await this._invoiceRepository.GetByUId(invoiceUId);
                if (invoice != null)
                {
                    var insuranceData = await this._insurancePolicyRepository.GetActivePolicies(invoice.PatientCaseId, invoice.BillFromDate);
                    var activeInsurance = insuranceData.FirstOrDefault();

                    var patient = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                    long patientId = patient == null ? 0 : patient.PatientId;

                    IPaymentBatch paymentBatchData = null;
                    var voucher = await this._voucherRepository.GetForBalanceAdjustment(PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString());
                    if(voucher==null)
                    {
                        paymentBatchData = await this._paymentBatchRepository.GetForBulkAdjustment();
                        if (paymentBatchData == null)
                        {
                            PaymentBatch paymentBatch = new PaymentBatch();
                            paymentBatch.Id = 0;
                            paymentBatch.IsSystem = true;
                            paymentBatch.RecordCount = 0;
                            paymentBatch.Amount = 0;
                            paymentBatch.BatchAmount = 0;

                            paymentBatchData = await this._paymentBatchRepository.AddNew(paymentBatch);
                        }
                    }
                    else
                    {
                        paymentBatchData = await this._paymentBatchRepository.GetById(voucher.PaymentBatchId);
                    }

                    List<Guid> invoiceIds = new List<Guid>();
                    invoiceIds.Add(invoice.UId);
                    //var charges = await this._chargesRepository.GetChargesForBulkAdjustments(invoiceIds);

                    //var voucher = await this._voucherRepository.GetForBalanceAdjustment(PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString());
                    if (voucher == null)
                    {
                        voucher = await this._voucherRepository.AddNewBulkAdjsutment(await this.CreateVoucherObject(activeInsurance.InsuranceCompanyID, (int)patientId, paymentBatchData.Id, true), false);
                    }

                    decimal adjustmentAmount = charges.Sum(i => i.Amount);
                    var payment = await this._paymentRepository.AddNewBulkPayment(await this.CreatePaymentObject(voucher.Id, (int)patientId, activeInsurance.InsuranceCompanyID, adjustmentAmount, true));

                    var getPaymentChargeList = await this.CreateArrayOfObjectForPaymentForBalanceAdjustment(payment.Id, charges, adjustmentCode, remarkCode);

                    await this._paymentChargeRepository.AddBalanceAdjustmentPayment(getPaymentChargeList);

                    int[] chargeId = charges.Select(i => i.Id).ToArray();

                    foreach (var item in chargeId)
                    {
                        var paymentAdjustment = getPaymentChargeList.FirstOrDefault(i => i.ChargeId == item).PaymentAdjustments.FirstOrDefault().Amount;
                        paymentAdjustment = (decimal)System.Math.Round(paymentAdjustment, 2);
                        await this._actionNoteRepository.AddPaymentNote((int)patientId, item, "Payment (#" + voucher.ReferenceNo + ") of $" + paymentAdjustment + " paid with this charge.");
                    }

                    //int[] chargeIds = charges.Select(i => i.Id).ToArray();
                    //await this._chargesRepository.UpdateDueBy(chargeIds);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddBalanceAdjustmentFromUI(IBalanceAdjustmentModel balanceAdjustmentModel)
        {
            try
            {
                string _accessionNo = "";
                List<IValidationResult> validationResults = new List<IValidationResult>();
                var patient = await this._patientRepository.GetByUId(balanceAdjustmentModel.PatientUId);
                var invoiceUidList = balanceAdjustmentModel.InvCharges.Select(i=>i.InvoiceUId).Distinct();

                int count = 0;

                foreach (var invoiceUId in invoiceUidList)
                {
                    try
                    {
                        _accessionNo = "";
                        count++;
                        var invoice = await this._invoiceRepository.GetByUId(invoiceUId);
                        _accessionNo = invoice.AccessionNumber;
                        if (invoice != null)
                        {
                            _accessionNo = invoice.AccessionNumber;
                            int insuranceCompanyId = 0;
                            

                            var insuranceData = await this._insurancePolicyRepository.GetActivePoliciesForAdjustClaims(invoice.PatientCaseId, invoice.BillFromDate);
                            var activeInsurance = insuranceData.FirstOrDefault();
                            if(activeInsurance==null)
                            {
                                insuranceData = await this._insurancePolicyRepository.GetActivePolicies_OldCharges(invoice.PatientCaseId, invoice.BillFromDate);
                                activeInsurance = insuranceData.FirstOrDefault();
                                if (activeInsurance == null)
                                {
                                    var lastClaim = await this._claimRepository.GetByInvoiceIdForAdjustment(invoice.Id);
                                    if (lastClaim != null)
                                    {
                                        insuranceCompanyId = lastClaim.InsuranceCompanyId;
                                    }
                                    else
                                    {
                                        var comp = await this._insuranceCompanyRepository.GetSelfPayPayer();
                                        if (comp != null)
                                            insuranceCompanyId = comp.Id;
                                    }
                                }
                            }
                            else
                            {
                                insuranceCompanyId = activeInsurance.InsuranceCompanyID.Value;
                            }

                            int patientId = patient == null ? 0 : patient.Id;

                            IPaymentBatch paymentBatchData = null;
                            var voucher = await this._voucherRepository.GetForBulkAdjustment_PatientWise(PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString(),
                                insuranceCompanyId, patientId);
                            if (voucher == null)
                            {
                                paymentBatchData = await this._paymentBatchRepository.GetForBulkAdjustment();
                                if (paymentBatchData == null)
                                {
                                    PaymentBatch paymentBatch = new PaymentBatch();
                                    paymentBatch.Id = 0;
                                    paymentBatch.IsSystem = true;
                                    paymentBatch.RecordCount = 0;
                                    paymentBatch.Amount = 0;
                                    paymentBatch.BatchAmount = 0;

                                    paymentBatchData = await this._paymentBatchRepository.AddNew(paymentBatch);
                                }
                            }
                            else
                            {
                                paymentBatchData = await this._paymentBatchRepository.GetById(voucher.PaymentBatchId);
                            }

                            List<Guid> invoiceIds = new List<Guid>();
                            invoiceIds.Add(invoice.UId);
                            //var charges = await this._chargesRepository.GetChargesForBulkAdjustments(invoiceIds);
                            var charges = balanceAdjustmentModel.InvCharges.Where(i=>i.InvoiceUId== invoiceUId);
                            decimal adjustmentAmount = charges.Sum(i => i.PostedAmount);
                            if (adjustmentAmount == 0)
                            {
                                continue;
                            }
                            //var voucher = await this._voucherRepository.GetForBalanceAdjustment(PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString());
                            if (voucher == null)
                            {
                                voucher = await this._voucherRepository.AddNewBulkAdjsutment(await this.CreateVoucherObject(insuranceCompanyId, (int)patientId, paymentBatchData.Id, true), false);
                            }


                            var payment = await this._paymentRepository.AddNewBulkPayment(await this.CreatePaymentObject(voucher.Id, (int)patientId, insuranceCompanyId, adjustmentAmount, true));

                            var getPaymentChargeList = await this.CreateArrayOfObjectForPaymentForBalanceAdjustmentNew(payment.Id, charges, balanceAdjustmentModel.AdjustmentType, balanceAdjustmentModel.ReasonCode);

                            await this._paymentChargeRepository.AddBalanceAdjustmentPayment(getPaymentChargeList);

                            int[] chargeId = charges.Select(i => i.Id).ToArray();

                            foreach (var item in chargeId)
                            {
                                var paymentAdjustment = getPaymentChargeList.FirstOrDefault(i => i.ChargeId == item).PaymentAdjustments.FirstOrDefault().Amount;
                                paymentAdjustment = (decimal)System.Math.Round(paymentAdjustment, 2);
                                await this._actionNoteRepository.AddPaymentNote((int)patientId, item, "Payment (#" + voucher.ReferenceNo + ") of $" + paymentAdjustment + " paid with this charge.");
                            }

                            //int[] chargeIds = charges.Select(i => i.Id).ToArray();
                            //await this._chargesRepository.UpdateDueBy(chargeIds);
                        }
                    }
                    catch (EntityException ex)
                    {
                        if (ex != null && ex.ValidationCodeResult != null && ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors.Count() > 0)
                            foreach (var content in ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors)
                            {
                                content.ErrorMessage += $" for Accession No - {_accessionNo} ";
                                validationResults.Add(content);
                            }

                        if (invoiceUidList.Distinct().Count() == count && validationResults.Count() > 0)
                        {
                            await this._claimRepository.ThrowError(validationResults);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                if (validationResults.Count() > 0)
                {
                    await this._claimRepository.ThrowError(validationResults);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddBalanceAdjustment_OldCharges(Guid invoiceUId, string adjustmentCode, string remarkCode, IEnumerable<ICharges> charges)
        {
            try
            {
                charges = charges.Where(i => i.DueAmount > 0);
                if (charges.Count() == 0)
                {
                    throw new Exception("There are no charge for adjust the balance.");
                }

                var invoice = await this._invoiceRepository.GetByUId(invoiceUId);
                if (invoice != null)
                {
                    int insuranceCompanyId = 0;
                    var insuranceData = await this._insurancePolicyRepository.GetActivePoliciesForAdjustClaims(invoice.PatientCaseId, invoice.BillFromDate);
                    var activeInsurance = insuranceData.FirstOrDefault();
                    if (activeInsurance == null)
                    {
                        insuranceData = await this._insurancePolicyRepository.GetActivePolicies_OldCharges(invoice.PatientCaseId, invoice.BillFromDate);
                        activeInsurance = insuranceData.FirstOrDefault();
                        if (activeInsurance == null)
                        {
                            var lastClaim = await this._claimRepository.GetByInvoiceIdForAdjustment(invoice.Id);
                            if (lastClaim != null)
                            {
                                insuranceCompanyId = lastClaim.InsuranceCompanyId;
                            }
                            else
                            {
                                var comp = await this._insuranceCompanyRepository.GetSelfPayPayer();
                                if (comp != null)
                                    insuranceCompanyId = comp.Id;
                            }
                        }
                    }
                    else
                    {
                        insuranceCompanyId = activeInsurance.InsuranceCompanyID.Value;
                    }



                   

                    var patient = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                    long patientId = patient == null ? 0 : patient.PatientId;

                    IPaymentBatch paymentBatchData = null;
                    var voucher = await this._voucherRepository.GetForBalanceAdjustment(PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString());
                    if (voucher == null)
                    {
                        paymentBatchData = await this._paymentBatchRepository.GetForBulkAdjustment();
                        if (paymentBatchData == null)
                        {
                            PaymentBatch paymentBatch = new PaymentBatch();
                            paymentBatch.Id = 0;
                            paymentBatch.IsSystem = true;
                            paymentBatch.RecordCount = 0;
                            paymentBatch.Amount = 0;
                            paymentBatch.BatchAmount = 0;

                            paymentBatchData = await this._paymentBatchRepository.AddNew(paymentBatch);
                        }
                    }
                    else
                    {
                        paymentBatchData = await this._paymentBatchRepository.GetById(voucher.PaymentBatchId);
                    }

                    List<Guid> invoiceIds = new List<Guid>();
                    invoiceIds.Add(invoice.UId);
                    //var charges = await this._chargesRepository.GetChargesForBulkAdjustments(invoiceIds);

                    //var voucher = await this._voucherRepository.GetForBalanceAdjustment(PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString());
                    if (voucher == null)
                    {
                        voucher = await this._voucherRepository.AddNewBulkAdjsutment(await this.CreateVoucherObject(insuranceCompanyId, (int)patientId, paymentBatchData.Id, true), false);
                    }

                    decimal adjustmentAmount = charges.Sum(i => i.DueAmount);
                    var payment = await this._paymentRepository.AddNewBulkPayment(await this.CreatePaymentObject(voucher.Id, (int)patientId, insuranceCompanyId, adjustmentAmount, true));

                    var getPaymentChargeList = await this.CreateArrayOfObjectForPaymentForBalanceAdjustment(payment.Id, charges, adjustmentCode, remarkCode);

                    await this._paymentChargeRepository.AddBalanceAdjustmentPayment(getPaymentChargeList);

                    int[] chargeId = charges.Select(i => i.Id).ToArray();

                    foreach (var item in chargeId)
                    {
                        var paymentAdjustment = getPaymentChargeList.FirstOrDefault(i => i.ChargeId == item).PaymentAdjustments.FirstOrDefault().Amount;
                        paymentAdjustment = (decimal)System.Math.Round(paymentAdjustment, 2);
                        await this._actionNoteRepository.AddPaymentNote((int)patientId, item, "Payment (#" + voucher.ReferenceNo + ") of $" + paymentAdjustment + " paid with this charge.");
                    }

                    //int[] chargeIds = charges.Select(i => i.Id).ToArray();
                    //await this._chargesRepository.UpdateDueBy(chargeIds);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private async Task<IEnumerable<IPaymentCharge>> CreateArrayOfObjectForPaymentForBalanceAdjustment(int paymentId, IEnumerable<ICharges> charges, string adjustmentcode, string remarkCode)
        {
            List<IPaymentCharge> paymentCharges = new List<IPaymentCharge>();
            IPaymentCharge paymentCharge = null;
            List<IPaymentAdjustment> adjustments = new List<IPaymentAdjustment>();
            List<IPaymentRemarkCode> remarkCodes = new List<IPaymentRemarkCode>();
            var paymentData = await this._paymentRepository.GetById(paymentId);
            string adjutmentRemarkCode = "";

            if (!string.IsNullOrWhiteSpace(remarkCode))
            {
                int Id = Convert.ToInt32(remarkCode);
                var item = await this._configERARemarkCodesRepository.Get(Id);
                adjutmentRemarkCode = item == null ? adjutmentRemarkCode : item.RemarkQualifier + ',' + item.RemarkCode;
            }

            foreach (var res in charges)
            {
                adjustments = new List<IPaymentAdjustment>();
                remarkCodes = new List<IPaymentRemarkCode>();
                paymentCharge = new PaymentCharge();
                paymentCharge.ChargeId = res.Id;
                paymentCharge.PaymentId = paymentId;
                paymentCharge.PaidAmount = 0;

                if (!string.IsNullOrWhiteSpace(adjustmentcode))
                {
                    var paymentAdjustment = await this.CreateObjectAdjustment(adjustmentcode, res.DueAmount);
                    adjustments.Add(paymentAdjustment);
                    paymentCharge.PaymentAdjustments = adjustments;
                }

                if (!string.IsNullOrWhiteSpace(adjutmentRemarkCode))
                {
                    var paymentRemarkCode = await this.CreateObjectRemarkCodes(adjutmentRemarkCode);
                    remarkCodes.Add(paymentRemarkCode);
                    paymentCharge.PaymentRemarkCodes = remarkCodes;
                }

                paymentCharges.Add(paymentCharge);
            }

            return paymentCharges;
        }

        private async Task<IEnumerable<IPaymentCharge>> CreateArrayOfObjectForPaymentForBalanceAdjustmentNew(int paymentId, IEnumerable<IPostedBalanceCharges> charges, string adjustmentcode, string remarkCode)
        {
            List<IPaymentCharge> paymentCharges = new List<IPaymentCharge>();
            IPaymentCharge paymentCharge = null;
            List<IPaymentAdjustment> adjustments = new List<IPaymentAdjustment>();
            List<IPaymentRemarkCode> remarkCodes = new List<IPaymentRemarkCode>();
            var paymentData = await this._paymentRepository.GetById(paymentId);
            string adjutmentRemarkCode = "";

            if (!string.IsNullOrWhiteSpace(remarkCode))
            {
                int Id = Convert.ToInt32(remarkCode);
                var item = await this._configERARemarkCodesRepository.Get(Id);
                adjutmentRemarkCode = item == null ? adjutmentRemarkCode : item.RemarkQualifier + ',' + item.RemarkCode;
            }

            foreach (var res in charges)
            {
                adjustments = new List<IPaymentAdjustment>();
                remarkCodes = new List<IPaymentRemarkCode>();
                paymentCharge = new PaymentCharge();
                paymentCharge.ChargeId = res.Id;
                paymentCharge.PaymentId = paymentId;
                paymentCharge.PaidAmount = 0;

                if (!string.IsNullOrWhiteSpace(adjustmentcode))
                {
                    var paymentAdjustment = await this.CreateObjectAdjustment(adjustmentcode, res.PostedAmount);
                    adjustments.Add(paymentAdjustment);
                    paymentCharge.PaymentAdjustments = adjustments;
                }

                if (!string.IsNullOrWhiteSpace(adjutmentRemarkCode))
                {
                    var paymentRemarkCode = await this.CreateObjectRemarkCodes(adjutmentRemarkCode);
                    remarkCodes.Add(paymentRemarkCode);
                    paymentCharge.PaymentRemarkCodes = remarkCodes;
                }

                paymentCharges.Add(paymentCharge);
            }

            return paymentCharges;
        }

        public async Task<int> CompareVoucherWithBank()
        {
            var vouchers = await this._voucherRepository.GetVouchersForBankMatched();
            var plaidPayments = await this._plaidPaymentRepository.GetAllPlaidPayments();

            await UpdatePlaidPayments(vouchers.Where(i => i.Practice == "LAB"), plaidPayments.Where(i => i.VoucherId == null && i.MatchedSource==null),"LAB");

            plaidPayments = await this._plaidPaymentRepository.GetAllPlaidPayments();
            await UpdatePlaidPayments(vouchers.Where(i => i.Practice == "CLINIC"), plaidPayments.Where(i => i.VoucherId == null && i.MatchedSource == null), "CLINIC");

            plaidPayments = await this._plaidPaymentRepository.GetAllPlaidPayments();
            await UpdatePlaidPayments(vouchers.Where(i => i.Practice == "RES"), plaidPayments.Where(i => i.VoucherId == null && i.MatchedSource == null), "RES");


            return 0;
        }

        private async Task UpdatePlaidPayments(IEnumerable<IVoucherPlaidDTO> vouchers, IEnumerable<IPlaidPayment> plaidPayments,string practice)
        {
            List<int> plaidPaymentIds = new List<int>();
            List<VoucherPlaidUpdateDTO> matchedvouchersIds = new List<VoucherPlaidUpdateDTO>();
            List<VoucherPlaidUpdateDTO> notMatchedvouchersIds = new List<VoucherPlaidUpdateDTO>();

            foreach (var item in vouchers)
            {
                var plaidRecord = plaidPayments.FirstOrDefault(i => Convert.ToDateTime(i.PaymentDate) == item.EffectiveDate && i.Amount == -item.Amount);
                if (plaidRecord != null)
                {
                    VoucherPlaidUpdateDTO voucherPlaidUpdateDTO = new VoucherPlaidUpdateDTO();
                    voucherPlaidUpdateDTO.VoucherId = item.Id;
                    voucherPlaidUpdateDTO.PlaidPaymentId = plaidRecord.Id;
                    matchedvouchersIds.Add(voucherPlaidUpdateDTO);
                }
                else
                {
                    VoucherPlaidUpdateDTO voucherPlaidUpdateDTO = new VoucherPlaidUpdateDTO();
                    voucherPlaidUpdateDTO.VoucherId = item.Id;
                    voucherPlaidUpdateDTO.PlaidPaymentId = 0;
                    notMatchedvouchersIds.Add(voucherPlaidUpdateDTO);                    
                }
            }

            



            if (matchedvouchersIds.Count > 0)
            {
                string matchedXml = await this.GetXml(matchedvouchersIds);
                await this._voucherRepository.UpdatePlaidMatched(matchedXml, true, practice);
            }
            if (notMatchedvouchersIds.Count > 0)
            {
                string nonmatchedXml = await this.GetXml(notMatchedvouchersIds);
                await this._voucherRepository.UpdatePlaidMatched(nonmatchedXml, false, practice);
            }
        }

        private async Task<string> GetXml(List<VoucherPlaidUpdateDTO> voucherPlaidUpdateDTOs)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<VoucherPlaidUpdateDTO>));
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, voucherPlaidUpdateDTOs);
                    xml = sww.ToString(); // Your XML
                }
            }

            return xml;
        }
        
        public async Task<bool> PostWriteOffForAdjusments()
        {
            var invoiceList = await this._paymentRepository.GetWriteOffForAdjusments();
            foreach (var item in invoiceList)
            {
                try
                {
                    var charges = await this._chargesRepository.GetChargesForBulkAdjustments(new List<Guid>() { Guid.Parse(item.InvoiceUId) });
                    await this.AddBalanceAdjustment(Guid.Parse(item.InvoiceUId), item.WriteOffRequestReasonCode, "", charges);
                    await this._chargeInWriteOffRepository.UpdateEntityAsPosted(item.ChargeInWriteOffId);
                }
                catch (Exception ex )
                {

                }
            }
            return true;
        }

        public async Task<bool> WriteOffHandTCharges()
        {
            var list = await this._chargesReportDataRepository.WriteOffHandTCharges();
            var charges = await this._chargesRepository.GetChargesForBulkAdjustmentsNew(list.Select(i => new Guid(i.InvoiceUId)).Distinct().ToList());

            List<WriteOffTHCode> lstHTCodes = new List<WriteOffTHCode>();

            var distinctInvoiceUids = charges.Where(i => i.DueAmount > 0).Select(i => i.InvoiceUId);
            foreach (var item in distinctInvoiceUids)
            {
                try
                {
                    var chargeReport = charges.FirstOrDefault(i => i.InvoiceUId == item);                    
                    if(lstHTCodes.FirstOrDefault(i=>i.InvoiceId== chargeReport.InvoiceId)==null)
                    {
                        WriteOffTHCode writeOffTHCode = new WriteOffTHCode();
                        writeOffTHCode.InvoiceId = chargeReport.InvoiceId;
                        writeOffTHCode.CreatedDate = DateTime.Now;
                        writeOffTHCode.IsAckNeeded = true;
                        lstHTCodes.Add(writeOffTHCode);
                    }

                    var invoiceCharges = charges.Where(i => i.InvoiceUId == item && (i.CPTCode.StartsWith("H") || i.CPTCode.StartsWith("T")));
                    await this.AddBalanceAdjustment_OldCharges(item, "COHMO", "", invoiceCharges);
                }
                catch (Exception ex)
                {

                }
            }
            if(lstHTCodes.Count>0)
            {
                await this._writeOffTHCodeRepository.AddNew(lstHTCodes);
            }

            return true;
        }

        public async Task<bool> WriteOffAdjusmentCharges(IBulkAdjustmentFROMUIModel balanceAdjustmentModel)
        {
            if(balanceAdjustmentModel.AdjustmentCode=="rohit")
            {
                throw new Exception("Please use incignito window or refresh your browser");
            }

            var user =await this._userRepository.GetCurrentUser();
            if(string.IsNullOrWhiteSpace(user.PIN))
            {
                await this._userRepository.ThrowPinEmptyError();
            }
            if(user.PIN!=balanceAdjustmentModel.ManagerPin)
            {
                await this._userRepository.ThrowPinNotMatchedError();
            }

            //var list = await this._chargesReportDataRepository.WriteOffHandTCharges();
            var charges = await this._chargesRepository.GetChargesForBulkAdjustmentsNew(balanceAdjustmentModel.UIds.Select(Guid.Parse).ToList());


            List<WriteOffTHCode> lstHTCodes = new List<WriteOffTHCode>();

            var distinctInvoiceUids = charges.Where(i => i.DueAmount > 0).Select(i => i.InvoiceUId);
            foreach (var item in distinctInvoiceUids)
            {
                try
                {
                    var chargeReport = charges.FirstOrDefault(i => i.InvoiceUId == item);
                    if (lstHTCodes.FirstOrDefault(i => i.InvoiceId == chargeReport.InvoiceId) == null)
                    {
                        WriteOffTHCode writeOffTHCode = new WriteOffTHCode();
                        writeOffTHCode.InvoiceId = chargeReport.InvoiceId;
                        writeOffTHCode.CreatedDate = DateTime.Now;
                        lstHTCodes.Add(writeOffTHCode);
                    }

                    var invoiceCharges = charges.Where(i => i.InvoiceUId == item);
                    await this.AddBalanceAdjustment_OldCharges(item, balanceAdjustmentModel.AdjustmentCode, "", invoiceCharges);
                }
                catch (Exception ex)
                {

                }
            }
            if (lstHTCodes.Count > 0)
            {
                await this._writeOffTHCodeRepository.AddNew(lstHTCodes);
            }

            return true;
        }
    }
}
