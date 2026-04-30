using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class ERAPaymentService : IERAPaymentService
    {

        private readonly IChargesRepository _chargesRepository;
        private readonly IPaymentBatchRepository _paymentBatchRepository;
        private readonly IPaymentChargeRepository _paymentChargeRepository;
        private readonly IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        public readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IPaymentRemarkCodeRepository _paymentRemarkCodeRepository;
        private readonly IERARootRepository _iERARootRepository;
        private readonly IERAClaimRepository _iERAClaimRepository;
        private readonly IERAClaimChargeRemarkRepository _iERAClaimChargeRemarkRepository;
        private readonly IERAClaimChargePaymentRepository _iERAClaimChargePaymentRepository;
        private readonly IERAClaimChargeAdjustmentRepository _iERAClaimChargeAdjustmentRepository;
        private readonly IPaymentService _paymentService;
        private readonly IPatientCaseRepository _patientCaseRepository;

        public object Paymentbatch { get; private set; }

        public ERAPaymentService(IERARootRepository iERARootRepository,
                                 IERAClaimRepository iERAClaimRepository,
                                 IERAClaimChargeRemarkRepository iERAClaimChargeRemarkRepository,
                                 IERAClaimChargePaymentRepository iERAClaimChargePaymentRepository,
                                 IERAClaimChargeAdjustmentRepository iERAClaimChargeAdjustmentRepository,
                                 IChargesRepository chargesRepository,
                                 IPaymentBatchRepository paymentBatchRepository,
                                 IPaymentChargeRepository paymentChargeRepository,
                                 IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                 IVoucherRepository voucherRepository,
                                 IPaymentRepository paymentRepository,
                                 IPatientRepository patientRepository,
                                 IInsurancePolicyRepository insurancePolicyRepository,
                                 IInsuranceCompanyRepository insuranceCompanyRepository,
                                 IPaymentRemarkCodeRepository paymentRemarkCodeRepository,
                                 IPaymentService paymentService,
                                 IPatientCaseRepository patientCaseRepository)
        {
            this._iERARootRepository = iERARootRepository;
            this._iERAClaimRepository = iERAClaimRepository;
            this._iERAClaimChargePaymentRepository = iERAClaimChargePaymentRepository;
            this._iERAClaimChargeAdjustmentRepository = iERAClaimChargeAdjustmentRepository;
            this._iERAClaimChargeRemarkRepository = iERAClaimChargeRemarkRepository;
            _chargesRepository = chargesRepository;
            this._paymentBatchRepository = paymentBatchRepository;
            this._voucherRepository = voucherRepository;
            this._paymentRepository = paymentRepository;
            _insurancePolicyRepository = insurancePolicyRepository;
            _paymentAdjustmentRepository = paymentAdjustmentRepository;
            _paymentChargeRepository = paymentChargeRepository;
            this._patientRepository = patientRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            this._paymentRemarkCodeRepository = paymentRemarkCodeRepository;
            this._paymentService = paymentService;
            this._patientCaseRepository = patientCaseRepository;
        }

        public async Task AddPaymentFromERA(long eraRootId)
        {
            IPaymentBatch paymentBatch = null;
            var eraData = await this._iERARootRepository.GetbyId(eraRootId);
            paymentBatch = await this._paymentBatchRepository.GetForERA();

            if (paymentBatch == null)
            {
                paymentBatch = await this.AddNewPaymentBatchFromERA(eraData);
            }
            else
            {
                paymentBatch.BatchAmount = paymentBatch.BatchAmount + eraData.EraPayment;
                paymentBatch = await this._paymentBatchRepository.Update(paymentBatch, null);
            }

            var eraClaims = await this._iERAClaimRepository.GetbyERARootId(eraData.Id);
            await this.AddNewVoucherFromERA(eraClaims, eraData, paymentBatch);
        }

        private async Task<IPaymentBatch> AddNewPaymentBatchFromERA(IERARoot entity)
        {
            PaymentBatch paymentBatchEntity = new PaymentBatch();
            paymentBatchEntity.Id = 0;
            paymentBatchEntity.BatchAmount = entity.EraPayment;
            paymentBatchEntity.RecordCount = 0;
            paymentBatchEntity.IsSystem = true;

            return await this._paymentBatchRepository.AddNew(paymentBatchEntity, null);
        }

        private async Task<IEnumerable<IVoucher>> AddNewVoucherFromERA(IEnumerable<IERAClaim> eRAClaims, IERARoot eRARoot, IPaymentBatch paymentBatch)
        {
            List<IVoucher> vouchers = new List<IVoucher>();
            IEnumerable<int> patientCaseIds = null;

            long[] claimIds = eRAClaims.Select(i => i.Id).ToArray();
            var eraClaimCharges = await this._iERAClaimChargePaymentRepository.GetByClaimId(claimIds);
            var eraClaimAdjustments = await this._iERAClaimChargeAdjustmentRepository.Get(eraClaimCharges.Select(i => i.Id).ToArray());

            foreach (var item in eRAClaims)
            {
                var patientId = item.PatientControlNumber.Split("-")[0].Substring(2)[1];
                var patientData = await this._patientRepository.GetById(patientId);
                if (patientData != null)
                {
                    int[] patientIds = { patientId };
                    patientCaseIds = (await this._patientCaseRepository.GetPatient(patientIds.ToList())).Select(i => i.Id);
                }
                else
                {
                    await this._patientRepository.ThrowError(patientData);
                }

                var policyData = await this._insurancePolicyRepository.GetByPolicyNumber(item.PolicyNumber, patientCaseIds);
                var voucherData = await this._voucherRepository.Get();

                var checkNumber = voucherData.Where(i => i.ReferenceNo == eRARoot.CheckNumber).FirstOrDefault();
                if (checkNumber != null)
                {
                    vouchers.Add(checkNumber);
                }

                if (policyData != null && checkNumber == null)
                {
                    Voucher voucher = new Voucher();
                    voucher.Amount = item.ClaimPaymentAmount;
                    voucher.DepositTypeId = (int)DepositTypeEnum.ClinicEFT;
                    voucher.Description = "ERA_Payment";
                    DateTime date = DateTime.ParseExact(eRARoot.PaymentEffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    voucher.EffectiveDate = eRARoot.PaymentEffectiveDate == null ? DateTime.Now : date;
                    voucher.InsuranceCompanyId = policyData != null ? policyData.InsuranceCompanyID : null;
                    voucher.IsCommitted = false;
                    voucher.IsSelfPayment = false;
                    voucher.PatientId = null;
                    voucher.PaymentBatchId = paymentBatch.Id;
                    voucher.PaymentSourceCD = PaymentSourceTypeEnum.ERA_PAYMENT.ToString();
                    voucher.ReferenceDate = DateTime.Now.Date;
                    voucher.ReferenceNo = eRARoot.CheckNumber;
                    voucher.VoucherTypeCD = VoucherTypeEnum.PAYMENT.ToString();
                    voucher.VoucherNo = voucherData.Count() == 0 ? 0 : voucherData.Max(i => i.VoucherNo) + 1;

                    var result = await this._voucherRepository.AddNew(voucher);
                    vouchers.Add(result);

                    await this.AddNewPaymentFromERA(eraClaimCharges, eRAClaims, result, eraClaimAdjustments, policyData.InsuranceCompanyID.Value);
                }
                else
                {
                    item.ErrorLog = "No Insurance company exist's with this policy number" + item.PolicyNumber;
                    await this._iERAClaimRepository.Update(item);

                    return null;
                }
            }

            return vouchers;
        }

        private async Task<IEnumerable<IPaymentCharge>> AddNewPaymentFromERA(IEnumerable<IERAClaimChargePayment> chargePayments, IEnumerable<IERAClaim> eRAClaims, IVoucher voucher, IEnumerable<IERAClaimChargeAdjustment> eRAClaimChargeAdjustments, int companyId)
        {
            var eRARemarkCodes = await this._iERAClaimChargeRemarkRepository.Get(chargePayments.Select(i => i.Id).ToArray());

            List<IPaymentCharge> paymentChs = new List<IPaymentCharge>();
            foreach (var item in eRAClaims)
            {
                long[] claimChargeId = chargePayments.Where(i => i.ERAClaimID == item.Id).Select(i => i.Id).ToArray();
                Payment payment = new Payment();
                payment.Amount = chargePayments.Count() == 0 ? 0 : chargePayments.Where(i => i.ERAClaimID == item.Id).Sum(i => i.Amount);
                payment.Adjustment = eRAClaimChargeAdjustments.Count() == 0 ? 0 : eRAClaimChargeAdjustments.Where(i => claimChargeId.Contains(i.ERAClaimChargePaymentId)).Sum(i => i.Amount);
                payment.DepositInsuranceCompanyId = voucher.InsuranceCompanyId != null ? voucher.InsuranceCompanyId : null;
                payment.IsCommitted = false;
                payment.IsReversed = false; // need to confirm
                payment.NonAccAdjustment = eRAClaimChargeAdjustments.Count() == 0 ? 0 : (int)eRAClaimChargeAdjustments.Where(i => claimChargeId.Contains(i.ERAClaimChargePaymentId)).Where(i => i.CASCode != "DED" && i.CASCode == "CoPay" && i.CASCode == "CoIns").Sum(i => i.Amount);
                payment.PatientId = item.PatientControlNumber.Split("-")[0].Substring(2)[1];
                payment.PatientInsuranceCompanyId = companyId;
                payment.PaymentSourceCD = PaymentSourceTypeEnum.ERA_PAYMENT.ToString();
                payment.PayorControl = item.PatientControlNumber;
                payment.VoucherId = voucher.Id;

                var paymentSave = await this._paymentRepository.AddNew(payment);
                await this.AddNewPaymentCharges(paymentSave, eRARemarkCodes, chargePayments, eRAClaimChargeAdjustments);
            }

            return paymentChs;
        }

        private async Task AddNewPaymentCharges(IPayment payment, IEnumerable<IERAClaimChargeRemark> chargeRemarks, IEnumerable<IERAClaimChargePayment> eRAClaimChargePayments, IEnumerable<IERAClaimChargeAdjustment> eRAClaimChargeAdjustments)
        {
            IPaymentCharge paymentChargeNew = null;
            foreach (var item in eRAClaimChargePayments)
            {
                var charge = await this._chargesRepository.Get((int)item.ChgNo, item.ChargeAmount);

                PaymentCharge paymentCharge = new PaymentCharge();
                paymentCharge.Id = 0;
                paymentCharge.PaymentId = payment.Id;
                paymentCharge.PaidAmount = item.Amount;
                paymentCharge.ChargeId = charge != null ? charge.Id : await this._iERAClaimChargePaymentRepository.Update(item);

                paymentChargeNew = charge == null ? null : await this._paymentChargeRepository.AddNew(paymentCharge);

                if (paymentChargeNew != null)
                {
                    await this.AddNewAdjustment(paymentChargeNew, eRAClaimChargeAdjustments.Where(i => i.ERAClaimChargePaymentId == item.Id));
                    await this.AddNewRemarkCodes(paymentChargeNew, chargeRemarks.Where(i => i.ERAClaimChargePaymentId == item.Id));
                }
            }


        }

        private async Task AddNewAdjustment(IPaymentCharge paymentCharge, IEnumerable<IERAClaimChargeAdjustment> eRAClaimChargeAdjustments)
        {
            foreach (var item in eRAClaimChargeAdjustments)
            {
                PaymentAdjustment paymentAdjustment = new PaymentAdjustment();
                paymentAdjustment.Amount = item.Amount;
                if ((item.CASCode + item.AdjustmentReasonCode) == "CoPay" || (item.CASCode + item.AdjustmentReasonCode) == "CoIns" || (item.CASCode + item.AdjustmentReasonCode) == "DED")
                    paymentAdjustment.IsAccounted = false;
                else
                    paymentAdjustment.IsAccounted = true;
                paymentAdjustment.IsDenial = false;
                paymentAdjustment.PaymentChargeId = paymentCharge.Id;
                paymentAdjustment.ReasonCode = item.CASCode + item.AdjustmentReasonCode;
                paymentAdjustment.ChargeId = paymentCharge.ChargeId;
                var paymentNewAdjustments = await this._paymentAdjustmentRepository.AddNew(paymentAdjustment);
            }
        }

        private async Task AddNewRemarkCodes(IPaymentCharge paymentCharge, IEnumerable<IERAClaimChargeRemark> eRAClaimChargeRemarks)
        {
            List<PaymentRemarkCode> remarkCode = new List<PaymentRemarkCode>();
            foreach (var item in eRAClaimChargeRemarks)
            {
                PaymentRemarkCode paymentRmarkCode = new PaymentRemarkCode();
                paymentRmarkCode.PaymentChargeId = paymentCharge.Id;
                paymentRmarkCode.RemarkCode = item.RemarkCode;

                remarkCode.Add(paymentRmarkCode);
            }

            await this._paymentRemarkCodeRepository.AddAll(remarkCode);
        }

        private async Task<IEnumerable<IDefaultReasonCode>> CreateListOfAdjustments(IEnumerable<IERAClaimChargeAdjustment> eRAClaimChargeAdjustments)
        {
            List<DefaultReasonCode> defaultReasonList = new List<DefaultReasonCode>();
            string[] isDenialAdjustmentCodes = { "pr1", "2", "3", "oa23" };
            string[] isAccountedAdjustmentCodes = { "pi200", "pi27", "pi227", "pi31" };

            foreach (var item in eRAClaimChargeAdjustments)
            {
                DefaultReasonCode defaultReason = new DefaultReasonCode();
                defaultReason.Id = 0;
                if (isAccountedAdjustmentCodes.Contains((item.CASCode + item.AdjustmentReasonCode).ToLower()))
                    defaultReason.IsAccounted = true;
                else
                    defaultReason.IsAccounted = false;
                defaultReason.AdjustmentAmount = item.Amount;
                defaultReason.Code = (item.CASCode + item.AdjustmentReasonCode);
                defaultReason.DisplayName = (item.CASCode + item.AdjustmentReasonCode);
                if (isDenialAdjustmentCodes.Contains((item.CASCode + item.AdjustmentReasonCode).ToLower()))
                    defaultReason.IsDenial = true;
                else
                    defaultReason.IsDenial = false;
                defaultReason.IsFixed = false;
                defaultReason.IsSystem = true;
                defaultReason.PaymentChargeId = 0;

                defaultReasonList.Add(defaultReason);
            }

            return defaultReasonList;
        }

        private async Task<IEnumerable<IPaymentRemarkCode>> CreateListOfRemarkCodes(IEnumerable<IERAClaimChargeRemark> eRAClaimChargeRemark)
        {
            List<PaymentRemarkCode> paymentRemarkCodeList = new List<PaymentRemarkCode>();

            foreach (var item in eRAClaimChargeRemark)
            {
                PaymentRemarkCode paymentRemarkCode = new PaymentRemarkCode();
                paymentRemarkCode.Id = 0;
                paymentRemarkCode.PaymentChargeId = 0;
                paymentRemarkCode.RemarkCode = item.RemarkCode;

                paymentRemarkCodeList.Add(paymentRemarkCode);
            }

            return paymentRemarkCodeList;
        }

        private async Task<IEnumerable<ICharges>> GetCharges(IEnumerable<int> chargeNo, IEnumerable<int> patientCaseIds)
        {
            return await this._chargesRepository.GetNumber(chargeNo, patientCaseIds);
        }

        public async Task<IPaymentBatchDTO> CreatePaymentObject(long eraRootId)
        {
            IPaymentBatch paymentBatch = null;
            PaymentBatchDTO paymentBatchDTO = new PaymentBatchDTO();
            List<PaymentBatchDTO> paymentBatchDTOList = new List<PaymentBatchDTO>();

            var eraData = await this._iERARootRepository.GetbyId(eraRootId);
            paymentBatch = await this._paymentBatchRepository.GetForERA();

            if (paymentBatch == null)
            {
                paymentBatch = await this.AddNewPaymentBatchFromERA(eraData);
            }
            else
            {
                paymentBatch.BatchAmount = paymentBatch.BatchAmount + eraData.EraPayment;
                paymentBatch = await this._paymentBatchRepository.Update(paymentBatch, null);
            }

            var eraClaims = await this._iERAClaimRepository.GetbyERARootId(eraData.Id);

            long[] claimIds = eraClaims.Select(i => i.Id).ToArray();
            var eraClaimCharges = await this._iERAClaimChargePaymentRepository.GetByClaimId(claimIds);
            var eraClaimAdjustments = await this._iERAClaimChargeAdjustmentRepository.Get(eraClaimCharges.Select(i => i.Id).ToArray());

            foreach (var item in eraClaims)
            {
                IEnumerable<int> patientCaseIds = null;

                var patientId = item.PatientControlNumber.Split("-")[0].Substring(2)[1];
                var patientData = await this._patientRepository.GetById(patientId);
                if (patientData != null)
                {
                    int[] patientIds = { patientId };
                    patientCaseIds = (await this._patientCaseRepository.GetPatient(patientIds.ToList())).Select(i => i.Id);
                }
                else
                {
                    await this._patientRepository.ThrowError(patientData);
                }

                var policyData = await this._insurancePolicyRepository.GetByPolicyNumber(item.PolicyNumber, patientCaseIds);
                if (policyData == null)
                {
                    item.ErrorLog = "No Insurance company exist's with this policy number" + item.PolicyNumber;
                    await this._iERAClaimRepository.Update(item);

                    return null;
                }

                paymentBatchDTO.IsNewPayment = true;
                paymentBatchDTO.IsReversed = false;
                // paymentBatchDTO.PatientInsuranceCompanyId = policyData != null ? policyData.InsuranceCompanyID : null;
                // paymentBatchDTO.DepositInsuranceCompanyId = policyData != null ? policyData.InsuranceCompanyID : null;
                paymentBatchDTO.PatientUId = patientData.UId;
                paymentBatchDTO.Voucher = await this.AddNewVoucher(item, eraData, paymentBatch, policyData);

                var claimCharges = eraClaimCharges.Where(i => i.ERAClaimID == item.Id);
                int[] chgNO = claimCharges.Count() > 0 ? claimCharges.Select(res => Convert.ToInt32(res.ChgNo)).ToArray() : new int[] { };
                paymentBatchDTO.Charges = await this.GetCharges(chgNO, patientCaseIds);

                foreach (var eraCharges in eraClaimCharges)
                {
                    var charges = paymentBatchDTO.Charges.Where(i => i.ChargeNo == eraCharges.ChgNo).FirstOrDefault();
                    charges.Adjustments = (await this.CreateListOfAdjustments(eraClaimAdjustments.Where(i => i.ERAClaimChargePaymentId == eraCharges.Id)));
                    long[] ids = { eraCharges.Id };
                    var remarkCodes = await this._iERAClaimChargeRemarkRepository.Get(ids);
                    charges.RemarkCodes = string.Join(',', remarkCodes.Select(i => i.RemarkCode));
                }

                paymentBatchDTOList.Add(paymentBatchDTO);
                paymentBatchDTO = new PaymentBatchDTO();
            }

            await this._paymentService.AddUpdateBulkPayment(paymentBatchDTOList);
            return paymentBatchDTO;
        }

        private async Task<IVoucher> AddNewVoucher(IERAClaim eRAClaims, IERARoot eRARoot, IPaymentBatch paymentBatch, IInsurancePolicy policyData)
        {
            try
            {
                IVoucher result = null;
                // long[] claimIds = { eRAClaims.Id };
                //var eraClaimCharges = await this._iERAClaimChargePaymentRepository.GetByClaimId(claimIds);
                //var eraClaimAdjustments = await this._iERAClaimChargeAdjustmentRepository.Get(eraClaimCharges.Select(i => i.Id).ToArray());

                //var voucherData = await this._voucherRepository.Get();

                if (policyData != null)
                {
                    Voucher voucher = new Voucher();
                    voucher.Amount = eRAClaims.ClaimPaymentAmount;
                    voucher.DepositTypeId = (int)DepositTypeEnum.ClinicEFT;
                    voucher.Description = "ERA_Payment";
                    DateTime date = DateTime.ParseExact(eRARoot.PaymentEffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    voucher.EffectiveDate = eRARoot.PaymentEffectiveDate == null ? DateTime.Now : date;
                    voucher.InsuranceCompanyId = policyData != null ? policyData.InsuranceCompanyID : null;
                    voucher.IsCommitted = false;
                    voucher.IsSelfPayment = false;
                    voucher.PatientId = null;
                    voucher.PaymentBatchId = paymentBatch.Id;
                    voucher.PaymentSourceCD = PaymentSourceTypeEnum.ERA_PAYMENT.ToString();
                    voucher.ReferenceDate = DateTime.Now.Date;
                    voucher.ReferenceNo = eRARoot.CheckNumber;
                    voucher.VoucherTypeCD = VoucherTypeEnum.PAYMENT.ToString();
                    voucher.VoucherNo = await this._voucherRepository.CreateVoucherNo();

                    //result = await this._voucherRepository.AddNew(voucher);
                    return voucher;
                }
                else
                {
                    eRAClaims.ErrorLog = "No Insurance company exist's with this company name =" + eRARoot.InsuranceCompanyName;
                    await this._iERAClaimRepository.Update(eRAClaims);

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPaymentBatchDTO> AddPaymentFromERA(IERARoot entity)
        {
            IPaymentBatch paymentBatch = null;
            PaymentBatchDTO paymentBatchDTO = new PaymentBatchDTO();
            List<PaymentBatchDTO> paymentBatchDTOList = new List<PaymentBatchDTO>();

            // SetupLog
            paymentBatch = await this._paymentBatchRepository.GetForERA();

            if (paymentBatch == null)
            {
                paymentBatch = await this.AddNewPaymentBatchFromERA(entity);
            }
            else
            {
                paymentBatch.BatchAmount = paymentBatch.BatchAmount + entity.EraPayment;
                paymentBatch = await this._paymentBatchRepository.Update(paymentBatch, null);
            }

            var eraClaims = entity.Claims.Where(i => i.ERARootID == entity.Id);
            long[] claimIds = eraClaims.Select(i => i.Id).ToArray();
            IEnumerable<int> patientCaseIds = null;

            foreach (var item in eraClaims)
            {
                var patientId = item.PatientControlNumber.Split("-")[0].Substring(2)[1];
                var patientData = await this._patientRepository.GetById(patientId);
                if (patientData != null)
                {
                    int[] patientIds = { patientId };
                    patientCaseIds = (await this._patientCaseRepository.GetPatient(patientIds.ToList())).Select(i => i.Id);
                }
                else
                {
                    await this._patientRepository.ThrowError(patientData);
                }

                var eraClaimCharges = item.Payments.Where(i => i.ERAClaimID == item.Id);
                foreach (var paymentCharge in eraClaimCharges)
                {
                    var eraClaimAdjustments = paymentCharge.Adjustments.Where(i => i.ERAClaimChargePaymentId == paymentCharge.Id);
                }

                var policyData = await this._insurancePolicyRepository.GetByPolicyNumber(item.PolicyNumber, patientCaseIds);
                if (policyData == null)
                {
                    item.ErrorLog = "No Insurance company exist's with this policy number" + item.PolicyNumber;
                    await this._iERAClaimRepository.Update(item);

                    return null;
                }

                paymentBatchDTO.IsNewPayment = true;
                paymentBatchDTO.IsReversed = false;
                //    paymentBatchDTO.PatientInsuranceCompanyId = policyData != null ? policyData.InsuranceCompanyID : null;
                //    paymentBatchDTO.DepositInsuranceCompanyId = policyData != null ? policyData.InsuranceCompanyID : null;
                paymentBatchDTO.PatientUId = patientData.UId;
                paymentBatchDTO.Voucher = await this.AddNewVoucher(item, entity, paymentBatch, policyData);

                var claimCharges = eraClaimCharges.Where(i => i.ERAClaimID == item.Id);
                int[] chgNO = claimCharges.Count() > 0 ? claimCharges.Select(res => Convert.ToInt32(res.ChgNo)).ToArray() : new int[] { };
                paymentBatchDTO.Charges = await this.GetCharges(chgNO, patientCaseIds);

                foreach (var eraCharges in claimCharges)
                {
                    var charges = paymentBatchDTO.Charges.Where(i => i.ChargeNo == eraCharges.ChgNo).FirstOrDefault();
                    charges.Adjustments = (await this.CreateListOfAdjustments(eraCharges.Adjustments));
                    long[] ids = { eraCharges.Id };
                    var remarkCodes = eraCharges.Remarks.Where(i => i.ERAClaimChargePaymentId == eraCharges.Id);
                    charges.RemarkCodes = string.Join(',', remarkCodes.Select(i => i.RemarkCode));
                }

                paymentBatchDTOList.Add(paymentBatchDTO);
                paymentBatchDTO = new PaymentBatchDTO();
            }

            await this._paymentService.AddUpdateBulkPayment(paymentBatchDTOList);
            return paymentBatchDTO;
        }
    }
}
