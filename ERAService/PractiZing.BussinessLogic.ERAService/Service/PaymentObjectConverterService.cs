using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Enums.ERAService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.Base.Service.ERAService;
using PractiZing.BussinessLogic.ERAService.Converter;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.ERAService.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PractiZing.BussinessLogic.ERAService.Service
{
    public interface IPaymentObjectConverterService
    {
        Task<string> CreateObject(object entity);
        Task<bool> SendRequestOnERAService(int claimId);
        Task<bool> SendRequestOnERAServiceWithPolicy(int claimId, string policyNumber);
    }

    public class PaymentObjectConverterService : IPaymentObjectConverterService
    {
        private readonly ILogger _logger;
        private readonly IERARootService _eRARootService;
        private readonly IPaymentBatchRepository _paymentBatchRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IERAClaimRepository _iERAClaimRepository;
        public readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        private readonly IPatientCaseRepository _patientCaseRepository;
        private readonly IVoucherConverter _voucherConverter;
        private readonly IChargesRepository _chargesRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPaymentBatchConverter _paymentBatchConverter;
        private readonly IERARootRepository _eRARootRepository;
        private readonly IERAClaimChargeAdjustmentConverter _eRAClaimChargeAdjustmentConverter;
        private readonly IPaymentService _paymentService;
        private readonly IDefaultReasonCodeRepository _defaultReasonCodeRepository;
        private readonly IConfigERARemarkCodesRepository _configERARemarkCodesRepository;
        private readonly IERARequestService _eRARequestService;
        private readonly IClaimRepository _claimRepository;

        public PaymentObjectConverterService(IERARootService eRARootService,
                                             IPaymentBatchRepository paymentBatchRepository,
                                             ILogger<PaymentObjectConverterService> logger,
                                             IERAClaimRepository iERAClaimRepository,
                                             IInsuranceCompanyRepository insuranceCompanyRepository,
                                             IInsurancePolicyRepository insurancePolicyRepository,
                                             IPatientCaseRepository patientCaseRepository,
                                             IVoucherConverter voucherConverter,
                                             IChargesRepository chargesRepository,
                                             IPaymentRepository paymentRepository,
                                             IPatientRepository patientRepository,
                                             IPaymentBatchConverter paymentBatchConverter,
                                             IERARootRepository eRARootRepository,
                                             IERAClaimChargeAdjustmentConverter eRAClaimChargeAdjustmentConverter,
                                             IDefaultReasonCodeRepository defaultReasonCodeRepository,
                                             IPaymentService paymentService,
                                             IConfigERARemarkCodesRepository configERARemarkCodesRepository,
                                             IERARequestService eRARequestService,
                                             IClaimRepository claimRepository)
        {
            this._claimRepository = claimRepository;
            this._logger = logger;
            this._eRARootService = eRARootService;
            this._paymentBatchRepository = paymentBatchRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._insurancePolicyRepository = insurancePolicyRepository;
            this._patientCaseRepository = patientCaseRepository;
            this._voucherConverter = voucherConverter;
            this._chargesRepository = chargesRepository;
            this._patientRepository = patientRepository;
            this._paymentBatchConverter = paymentBatchConverter;
            this._iERAClaimRepository = iERAClaimRepository;
            this._eRARootRepository = eRARootRepository;
            this._defaultReasonCodeRepository = defaultReasonCodeRepository;
            this._eRAClaimChargeAdjustmentConverter = eRAClaimChargeAdjustmentConverter;
            this._paymentService = paymentService;
            this._eRARequestService = eRARequestService;
            this._paymentRepository = paymentRepository;
            this._configERARemarkCodesRepository = configERARemarkCodesRepository;
        }

        public async Task<string> CreateObject(object claim)
        {
            try
            {
                List<IValidationResult> error = new List<IValidationResult>();
                IVoucher voucher = null;
                int paymentId = 0;

                if (claim == null)
                {
                    _logger.LogInformation("object is coming null");
                    throw new Exception("object is coming null");
                }

                IERAClaim eraClaim = JsonConvert.DeserializeObject<ERAClaim>(claim.ToString());
                if (eraClaim == null)
                {
                    _logger.LogInformation("object not Deserialized into ERACliam Object");
                    throw new Exception("object not Deserialized into ERACliam Object");
                }

                if(eraClaim.PatientControlNumber== "WPA9192-2148")
                {

                }

                eraClaim.PaymentUID = eraClaim.PaymentUID == null ? "" : eraClaim.PaymentUID.ToString();

                if (eraClaim.StatusId == (int)StatusEnum.Processed || (eraClaim.StatusId == (int)StatusEnum.SendingData && eraClaim.PaymentUID.ToString() != ""))
                {
                    _logger.LogInformation("getting payment batch id by using payment guid. id status is already processed.");
                    long paymentUid = Convert.ToInt32(eraClaim.PaymentUID);
                    var paymentData = await this._paymentRepository.GetById(paymentUid);

                    if (paymentData == null)
                        throw new Exception("not getting paymentData using payment uid. Someone have deleted this payment. so, please remove payment id from Era Cliam table.");

                    voucher = await this._voucherConverter.Get(paymentData.VoucherId);

                    if (voucher == null)
                        throw new Exception("not getting voucher using VoucherId.");

                    try
                    {
                        await this._paymentService.Delete(paymentData.UId);
                    }
                    catch
                    {
                        throw new Exception("not deleted payment using uid.");
                    }
                }

                IPaymentBatch paymentBatch = null;
                PaymentBatchDTO paymentBatchDTO = new PaymentBatchDTO();
                List<PaymentBatchDTO> paymentBatchDTOList = new List<PaymentBatchDTO>();

                _logger.LogInformation("Start to create object");

                var eraRoot = eraClaim.ERARoot;
                if (eraRoot == null)
                {
                    _logger.LogInformation("eraRoot is null.");
                    var errors = await this._eRARootRepository.ThrowError(eraRoot);
                    error.AddRange(errors.ToList());
                }

                //var voucherData = await this._voucherConverter.GetByCheckNumber(eraRoot.CheckNumber);
                //if(voucherData != null)
                //{
                //    _logger.LogInformation("check number already exists with this practice.");
                //    throw new Exception("check number already exists with this practice.");
                //}

                if (eraClaim.StatusId == (int)StatusEnum.Processed && voucher.PaymentBatchId != 0)
                {
                    _logger.LogInformation("Getting Payment Batch If we have processed a already processed claim.");
                    _logger.LogInformation("By using payment payment Uid which we are saving in ERA claim table.");
                    paymentBatch = await this._paymentBatchRepository.GetById(voucher.PaymentBatchId);
                    if (paymentBatch == null)
                    {
                        paymentBatch = await this._paymentBatchRepository.GetForERA();
                    }
                        //throw new Exception("not getting payment batch object by using payment Id");
                }
                else
                {
                    var voucherDetail = await this._voucherConverter.GetByCheckNumber(eraRoot.CheckNumber);
                    paymentBatch = voucherDetail == null ? await this._paymentBatchRepository.GetForERA() : await this._paymentBatchRepository.GetById(voucherDetail.PaymentBatchId);
                }

                _logger.LogInformation("getting payment batch");

                if (paymentBatch == null)
                {
                    _logger.LogInformation("If payment batch is null then create new batch otherwise");
                    paymentBatch = await this.AddNewPaymentBatchFromERA(eraRoot);
                    eraClaim.PaymentBatchUId = paymentBatch.UId;
                }
                else
                {
                    _logger.LogInformation("otherwise payment batch object => " + paymentBatch + "is updating amount");
                    var voucherByNumber = await this._voucherConverter.GetByCheckNumber(eraRoot.CheckNumber);
                    if (voucherByNumber == null)
                    {
                        paymentBatch.BatchAmount = paymentBatch.BatchAmount + eraClaim.ERARoot.EraPayment;
                        paymentBatch.Amount = paymentBatch.BatchAmount + eraClaim.ERARoot.EraPayment;
                        paymentBatch = await this._paymentBatchRepository.Update(paymentBatch, null);
                    }
                }

                _logger.LogInformation("after payment batch. we are fetching eraclaims array for creating voucher and payments ");

                _logger.LogInformation("after payment batch. we are fetching claims array according to eraRoot");

                var eraClaimCharges = eraClaim.Payments.Where(i => i.ERAClaimID == eraClaim.Id);
                _logger.LogInformation("we are fetching claimsCharges array according to claim Id");

                var patientId = eraClaim.PatientControlNumber.Split("-")[0].Substring(3).ToString();

                _logger.LogInformation("check patient exists with this patient id or not.");
                int alphabhetsCount = Regex.Matches(patientId, @"[a-zA-Z@#$%&*+\-_(),+':;?.,![]\s\\/]").Count;
                if (alphabhetsCount > 0)
                {
                    _logger.LogInformation("Invalid Patient - " + patientId);
                    throw new Exception("Invalid Patient - " + patientId);
                }
                



                var patientData = await this._patientRepository.GetById(Convert.ToInt32(patientId));
                IEnumerable<int> patientCaseIds = null;

                if (patientData != null)
                {
                    int[] patientIds = { int.Parse(patientId) };
                    patientCaseIds = (await this._patientCaseRepository.GetPatient(patientIds.ToList())).Select(i => i.Id);
                    _logger.LogInformation("patient exists with patient id - " + patientId);
                }

                else
                {
                    _logger.LogInformation("patient doesn't exists with patient id -" + patientId);
                    throw new Exception("patient doesn't exists with patient id -" + patientId);
                }

                if (eraClaim.PolicyNumber == null || eraClaim.PolicyNumber == "")
                {
                    _logger.LogInformation("eraClaim policy number is null.");
                    throw new Exception("eraClaim policy number is null.");
                }

                //_logger.LogInformation("check insurance company exists with this policy number or not.");
                //var policyData = await this._insurancePolicyRepository.GetByPolicyNumber(eraClaim.PolicyNumber, patientCaseIds);
                //if (policyData == null)
                //{
                //    _logger.LogInformation("if insurance company doesn't exists with this policy number. then error log update in payment table and error will throw on era service.");
                //    throw new Exception("Insurance policy does not exist with policy number -" + eraClaim.PolicyNumber);
                //}

                //if (policyData.InsuranceCompanyID == null)
                //{
                //    _logger.LogInformation("policyData.InsuranceCompanyID is null.");
                //    throw new Exception("policyData.InsuranceCompanyID is null.");
                //}

                //int insuranceLevel = policyData.InsuranceLevel;

                var actualClaim = await this._claimRepository.GetClaimByPatientAccountNumber(eraClaim.PatientControlNumber);

                short? insuranceLevel = actualClaim.InsLevel;

                if (eraRoot.InsuranceCompanyName == null || eraRoot.InsuranceCompanyName == "")
                {
                    _logger.LogInformation("InsuranceCompanyName is null.");
                    throw new Exception("InsuranceCompanyName is null.");
                }

                var insuranceCompany = await this._insuranceCompanyRepository.GetById(actualClaim.InsuranceCompanyId);
                if (insuranceCompany == null)
                {
                    _logger.LogInformation("InsuranceCompany Data is null.");
                    throw new Exception("InsuranceCompany Data is null.");
                }

                //var depositInsuranceCompany = await this._insuranceCompanyRepository.GetInsuranceCompany(null, insuranceCompany.CompanyName);
                //if (depositInsuranceCompany == null)
                //{
                //    _logger.LogInformation("Deposit InsuranceCompany Data is null.");
                //    throw new Exception("Deposit InsuranceCompany Data is null.");
                //}

                _logger.LogInformation("insurance company exists with this policy number.");

                paymentBatchDTO.IsNewPayment = true;
                paymentBatchDTO.IsReversed = false;

                if (eraClaim.ClaimPaymentAmount < 0)
                {
                    paymentBatchDTO.IsReversed = true;
                }
                else
                {
                    paymentBatchDTO.IsReversed = false;
                }

                if (eraClaim.ClaimStatusCode.HasValue)
                {
                    if (eraClaim.ClaimStatusCode == 22)
                    {
                        paymentBatchDTO.IsReversed = true;
                    }
                }

                // paymentBatchDTO.PatientInsuranceCompanyId = policyData.InsuranceCompanyID;
                paymentBatchDTO.PatientInsuranceCompanyUId = insuranceCompany == null ? new Guid() : insuranceCompany.UId;
                //  paymentBatchDTO.DepositInsuranceCompanyId = depositInsuranceCompany == null ? 0 : depositInsuranceCompany.Id;
                paymentBatchDTO.DepositInsuranceCompanyUId = insuranceCompany == null ? new Guid() : insuranceCompany.UId;
                paymentBatchDTO.PatientUId = patientData.UId;
                paymentBatchDTO.TotalPaidAmount = eraClaim.ClaimPaymentAmount;
                //   paymentBatchDTO.PatientId = int.Parse(patientId);
                //eraRoot.InsuranceCompanyName = insuranceCompany == null ? string.Empty : insuranceCompany.CompanyName;
                var claimCharges = eraClaimCharges.Where(i => i.ERAClaimID == eraClaim.Id);

                paymentBatchDTO.Voucher = await this._voucherConverter.IniIVoucher(eraClaim, eraRoot, paymentBatch, insuranceCompany);
                paymentBatchDTO.PayorControl = eraClaim.PayerClaimControlNumber;

                _logger.LogInformation("get claim charge data according to claim id.");

                int[] chgNO = claimCharges.Count() > 0 ? claimCharges.Select(res => (int)(res.ChgNo)).ToArray() : new int[] { };

                _logger.LogInformation("get charge data according to charge no." + chgNO);
                paymentBatchDTO.Charges = await this.GetCharges(chgNO, patientCaseIds);

                int[] chargeNoExists = paymentBatchDTO.Charges.Select(i => i.ChargeNo).ToArray();
                error.AddRange(await this._chargesRepository.ThrowErrors(chgNO, chargeNoExists));
                var chNo = chgNO.Except<int>(chargeNoExists);

                _logger.LogInformation("Charges not Found With Charge No. - " + string.Join(',', chargeNoExists));

                _logger.LogInformation("no of charge number getting - " + chgNO.Count());
                _logger.LogInformation("no of charges found according to charge no's - " + paymentBatchDTO.Charges.Count());

                foreach (var item in paymentBatchDTO.Charges)
                {
                    item.PaidAmount = claimCharges.Where(i => i.ChgNo == item.ChargeNo).Sum(i => i.Amount);
                }

                var defaultCode = await this._defaultReasonCodeRepository.GetAll();

                if (paymentBatchDTO.Charges.Count() > 0)
                {
                    foreach (var eraCharges in claimCharges)
                    {
                        _logger.LogInformation("add adjustments and remark codes in charges list according to charge no");

                        _logger.LogInformation("paymentBatchDTO.Charges: " + paymentBatchDTO.Charges.Count().ToString());

                        var charges = paymentBatchDTO.Charges.Where(i => i.ChargeNo == eraCharges.ChgNo).FirstOrDefault();
                        if (charges != null)
                        {
                            _logger.LogInformation("line 323");
                            charges.Adjustments = (await this._eRAClaimChargeAdjustmentConverter.IniIChargeAdjustment(eraCharges.Adjustments, eraCharges.Amount, defaultCode));

                            //if insurance levele greater than 1 -- Means not the primary then we need to set adjustment as nonaccountable
                            if(insuranceLevel>1)
                            {
                                foreach (var item in charges.Adjustments)
                                {
                                    item.IsAccounted = false;
                                }
                            }

                            _logger.LogInformation("line 325");
                            _logger.LogInformation("no of adjustment's with charge no " + eraCharges.ChgNo + "are " + charges.Adjustments.Count());
                            long[] ids = { eraCharges.Id };

                            var remarkCodes = eraCharges.Remarks.Where(i => i.ERAClaimChargePaymentId == eraCharges.Id);
                            charges.RemarkCodes = string.Join(',', remarkCodes.Select(i => i.RemarkCode));
                            var selectedRemarkCodes = await this._configERARemarkCodesRepository.Get(charges.RemarkCodes);
                            List<int> codeIds = new List<int>();

                            remarkCodes.ToList().ForEach((res) =>
                            {
                                var remarkCodeId = selectedRemarkCodes.FirstOrDefault(i => i.FullCode == res.QualifierCode + ' ' + res.RemarkCode);
                                if (remarkCodeId != null)
                                    codeIds.Add(remarkCodeId.Id);
                            });

                            charges.RemarkCodeIds = string.Join(',', codeIds);
                            _logger.LogInformation("no of remark codes with charge no " + eraCharges.ChgNo + "are " + charges.RemarkCodes.Count());
                        }
                    }
                }

                if (error.Count > 0)
                {
                    await this.SendRequestOnERAService((int)eraClaim.Id, "Patient does not have charges.");
                }

                //await this._eRARootRepository.ThrowError(error);
                paymentBatchDTOList.Add(paymentBatchDTO);
                int count = paymentBatchDTO.Charges.Count();

                paymentBatchDTO = new PaymentBatchDTO();

                if (count > 0)
                    paymentId = await this._paymentService.AddUpdateBulkPayment(paymentBatchDTOList);

                count = 0;
                return paymentId.ToString();
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Exception CreateObject - " + ex.StackTrace);
                throw ex;
            }
        }

        private async Task<IEnumerable<ICharges>> GetCharges(IEnumerable<int> chargeNo, IEnumerable<int> patientCaseIds)
        {
            return await this._chargesRepository.GetNumber(chargeNo, patientCaseIds);
        }

        private async Task<IPaymentBatch> AddNewPaymentBatchFromERA(IERARoot entity)
        {
            var paymentBatch = await this._paymentBatchConverter.IniIPaymentBatch(entity);
            return await this._paymentBatchRepository.AddNewEraBatch(paymentBatch, null);
        }

        public async Task<bool> SendRequestOnERAService(int claimId)
        {
            var practiceCode = this._eRARootRepository.LoggedUserPracticeCode();
            var responseString = await this._eRARequestService.ERARequest("/api/ERAClaimProcess/UpdateById/" + claimId + "/" + practiceCode, null);
            return responseString != null ? true : false;
        }

        public async Task<bool> SendRequestOnERAServiceWithPolicy(int claimId, string policyNumber)
        {
            var practiceCode = this._eRARootRepository.LoggedUserPracticeCode();
            var responseString = await this._eRARequestService.ERARequest("/api/ERAClaimProcess/UpdateByIdWithPolicy/" + claimId + "/" + policyNumber + "/" + practiceCode, null);
            return responseString != null ? true : false;
        }

        public async Task<bool> SendRequestOnERAService(int claimId, string errorMessage)
        {
            var practiceCode = this._eRARootRepository.LoggedUserPracticeCode();
            var responseString = await this._eRARequestService.ERARequest("/api/ERAClaimProcess/UpdateAfterError/" + claimId + "/" + errorMessage + "/" + practiceCode, null);
            return responseString != null ? true : false;
        }
    }
}
