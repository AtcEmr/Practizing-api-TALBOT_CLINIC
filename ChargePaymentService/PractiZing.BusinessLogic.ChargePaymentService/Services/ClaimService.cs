using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Common;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using System.Text.RegularExpressions;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.BatchPaymentService;
using PractiZing.DataAccess.Common;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Enums.ChargePaymentEnums;

using Microsoft.Extensions.Logging;

using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.DataAccess.BatchPaymentService.Tables;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.DataAccess.PatientService.Model;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class ClaimService : IClaimService
    {
        private readonly char[] unnecessaryPhoneCharacters = { ' ', '(', ')', '-' };

        private List<ClaimCharge> claimCharges = new List<ClaimCharge>();
        private List<ClaimTotal> claimsTotal = new List<ClaimTotal>();
        private readonly IClearingHouseRepository _clearingHouseRepository;
        private readonly ITransactionProvider _transactionProvider;
        private readonly IChargeInvoiceService _chargeInvoiceService;

        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IPatientCaseRepository _patientCaseRepository;
        private readonly IConfigInsuranceFormTypeRepository _configInsuranceFormTypeRepository;
        private readonly IConfigHCFAFormFieldRepository _configHCFAFormFieldRepository;
        private readonly IClaimConfigRepository _claimConfigRepository;
        private readonly IConfigIdTypeRepository _configIdTypeRepository;
        private readonly IClaimChargeRepository _claimChargeRepository;
        private readonly IClaimTotalRepository _claimTotalRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IInsurancePolicyHolderRepository _insurancePolicyHolderRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IConfigInsuranceCompanyTypeRepository _configInsuranceCompanyTypeRepository;
        private readonly IReferringDoctorRepository _referringDoctorRepository;
        private readonly IPatientAuthorizationNumberRepository _patientAuthorizationRepository;
        private readonly IFacilityIdentityRepository _facilityIdentityRepository;
        private readonly IClaimRepository _claimRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IProviderIdentityRepository _providerIdentityRepository;
        private readonly IClaimBatchRepository _claimBatchRepository;
        private readonly IAppSettingRepository _appSettingRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPracticeRepository _practiceRepository;
        private readonly IActionNoteRepository _actionNoteRepository;
        private readonly IChargesRepository _chargesRepository;
        private readonly IPaymentChargeRepository _paymentChargeRepository;
        private readonly IChargesReportDataRepository _chargesReportDataRepository;
        private readonly IProviderFacilityValidtionRepository _providerFacilityValidtionRepository;


        private string Reserved24NPI;
        private int Level;
        private int cliaNumber;
        private string Frequency;
        private decimal? AmountBilled;
        private bool? AnotherPlan;

        private string Reserved10;
        private DateTime? SignDate;
        private short? ReferringPhysicianNumber;
        private string OriginalReferenceNumber;
        private string PhysicianSignature;
        private int relationShip = 0;
        private int _blueCross = 2;
        private IInsurancePolicy _insurancePolicy;
        private IInsuranceCompany _insuranceCompany;
        private IInvoice _invoice;
        private IPatientCase _patientCase;
        private IPatient _patient;
        private IInsurancePolicy _primaryInsurancePolicy;
        private IInsurancePolicy _secondaryInsurancePolicy;
        private IInsurancePolicy _secondary2InsurancePolicy;
        private IEnumerable<IInsurancePolicy> _insurancePolicies;
        private IInsuranceCompany _primaryInsuranceCompany;
        private IInsuranceCompany _secondaryInsuranceCompany;
        private IInsuranceCompany _secondary2InsuranceCompany;
        private IInsurancePolicyHolder _primaryInsurancePolicyHolder;
        private IInsurancePolicyHolder _secondaryInsurancePolicyHolder;
        private IInsurancePolicyHolder _secondary2InsurancePolicyHolder;
        private IProvider _provider;
        private IFacility _facility;
        private IConfigHCFAFormField _secondaryConfigHCFAFormFields;
        private IConfigHCFAFormField _primaryConfigHCFAFormFields;
        private IFacilityIdentity _identifier;
        private IInsurancePolicyHolder _insurancePolicyHolder;
        private IReferringDoctor _referringDoctor;
        private IPatientAuthorizationNumber _patientAuthorization;
        private IConfigInsuranceFormType _primaryConfigInsuranceFormType;
        private IAppSetting _configAppSettingClaimFormType;
        private IEnumerable<IAppSetting> _configAppSettingPracticeGenConfig;
        private IPractice _practice;
        private MyConfiguration _myConfiguration;
        private string _accessionNo = string.Empty;
        private string _patientName = string.Empty;
        private int _federalTaxId = Convert.ToInt32(Base.Enums.ChargePaymentEnums.ClaimEnum.FederalTaxId);
        private int _taxonomyId = 14;
        private bool isReferringLab = false;
        private string customAuthorizationNo = string.Empty;
        private ILogger _logger;

        public ClaimService(ITransactionProvider transactionProvider,
            IChargeInvoiceService chargeInvoiceService,
            IInsurancePolicyRepository insurancePolicyRepository,
            IInsuranceCompanyRepository insuranceCompanyRepository,
            IPatientCaseRepository patientCaseRepository,
            IConfigInsuranceFormTypeRepository configInsuranceFormTypeRepository,
            IPatientRepository patientRepository,
            IInsurancePolicyHolderRepository insurancePolicyHolderRepository,
            IFacilityRepository facilityRepository,
            IConfigInsuranceCompanyTypeRepository configInsuranceCompanyTypeRepository,
            IReferringDoctorRepository referringDoctorRepository,
            IPatientAuthorizationNumberRepository patientAuthorizationNumberRepository,
            IFacilityIdentityRepository facilityIdentityRepository,
            IClaimRepository claimRepository,
            IProviderRepository providerRepository,
            IProviderIdentityRepository providerIdentityRepository,
            IConfigHCFAFormFieldRepository configHCFAFormFieldRepository,
            IClaimConfigRepository claimConfigRepository,
            IConfigIdTypeRepository configIdTypeRepository,
            IClaimChargeRepository claimChargeRepository,
            IClaimTotalRepository claimTotalRepository,
            IClaimBatchRepository claimBatchRepository,
            IAppSettingRepository appSettingRepository,
            MyConfiguration myConfiguration,
            IInvoiceRepository invoiceRepository,
            IPracticeRepository practiceRepository,
            ILoggerFactory loggerFactory,
            IActionNoteRepository actionNoteRepository,
            IChargesRepository chargesRepository,
            IPaymentChargeRepository paymentChargeRepository,
            IClearingHouseRepository clearingHouseRepository,
            IChargesReportDataRepository chargesReportDataRepository     ,
            IProviderFacilityValidtionRepository providerFacilityValidtionRepository
            )
        {
            this._providerFacilityValidtionRepository = providerFacilityValidtionRepository;
            this._chargesReportDataRepository = chargesReportDataRepository;
            this._clearingHouseRepository = clearingHouseRepository;
            _paymentChargeRepository = paymentChargeRepository;
            _transactionProvider = transactionProvider;
            _chargeInvoiceService = chargeInvoiceService;
            _insurancePolicyRepository = insurancePolicyRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _patientCaseRepository = patientCaseRepository;
            _configInsuranceFormTypeRepository = configInsuranceFormTypeRepository;
            _patientRepository = patientRepository;
            _insurancePolicyHolderRepository = insurancePolicyHolderRepository;
            _facilityRepository = facilityRepository;
            _configInsuranceCompanyTypeRepository = configInsuranceCompanyTypeRepository;
            _referringDoctorRepository = referringDoctorRepository;
            _patientAuthorizationRepository = patientAuthorizationNumberRepository;
            _facilityIdentityRepository = facilityIdentityRepository;
            _claimRepository = claimRepository;
            _providerRepository = providerRepository;
            _providerIdentityRepository = providerIdentityRepository;
            _configHCFAFormFieldRepository = configHCFAFormFieldRepository;
            _claimConfigRepository = claimConfigRepository;
            _configIdTypeRepository = configIdTypeRepository;
            _claimChargeRepository = claimChargeRepository;
            _claimTotalRepository = claimTotalRepository;
            _claimBatchRepository = claimBatchRepository;
            _appSettingRepository = appSettingRepository;
            _myConfiguration = myConfiguration;
            _invoiceRepository = invoiceRepository;
            _practiceRepository = practiceRepository;
            _logger = loggerFactory.CreateLogger<ClaimService>();
            this._actionNoteRepository = actionNoteRepository;
            this._chargesRepository = chargesRepository;
        }

        public async Task ExportClaim(int id)
        {
            var claim = await this._claimRepository.Get(id);

        }

        /// <summary>
        /// claim creation start
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IClaim> CreateClaim(IAddClaimInfoDTO entity)
        {
            try
            {
                var patientCase = await this._patientCaseRepository.GetByUId(entity.PatientCaseUId);
                _logger.LogInformation($"{patientCase.UId.ToString()} 1");

                var invoice = await this._invoiceRepository.GetByUId(entity.InvoiceUId);

                var claimDate = new DateTime(invoice.BillFromDate.Year, invoice.BillFromDate.Month, invoice.BillFromDate.Day);
                var todayDate= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                var diffOfDates = todayDate - claimDate;
                if(diffOfDates.Days<0)
                {
                    await this._invoiceRepository.ThrowFurtureClaimError(); 
                }

                
                entity.InvoiceId = invoice == null ? 0 : invoice.Id;
                //var ichargeBatch = await this._cha
                //invoice.ChargeBatchUId = invoice == null ? 0 : invoice.ChargeBatchId;
                _logger.LogInformation($"{entity.InvoiceUId.ToString()} 2");
                entity.PatientCaseId = patientCase == null ? 0 : patientCase.Id;

                /*fetch invoice, charges and diagonsis by given patientCaseId and invoiceId*/
                _invoice = await this._chargeInvoiceService.GetByInvoice(entity.PatientCaseId, entity.InvoiceId);

                if(_invoice.ReviewNeeded.HasValue)
                    if(_invoice.ReviewNeeded.Value)
                        await this._invoiceRepository.ThrowReviewNeededError();

                if (_invoice.IsBillable.HasValue)
                    if (!_invoice.IsBillable.Value)
                        await this._invoiceRepository.ThrowIsBillableError();

                if (_invoice.ChargeList != null && _invoice.ChargeList.Count() > 0)
                {
                    var chargeZero = _invoice.ChargeList.FirstOrDefault(i => i.Amount <= 0);
                    if (chargeZero != null)
                    {
                        await this._invoiceRepository.UpdateReviewNeeded(_invoice.UId, true, "Amount must be greater than 0 (ZERO).");
                        await ChargeZeroValidation(chargeZero.CPTCode);
                    }                    
                }


                var billingFacility = await this._facilityRepository.GetById(_invoice.BillFacilityId.Value);
                //if(billingFacility.IsMentalFacility.HasValue && billingFacility.IsMentalFacility.Value)
                //{
                //    // mental health
                //    var validateIcds = _invoice.InvDiagnosisLst.Where(i => i.IcdType == 1);
                //    if(validateIcds.Count()!=_invoice.InvDiagnosisLst.Count())
                //    {
                //        await this._facilityRepository.ThrowError();
                //    }
                //}else
                //{
                //    // substance 
                //    var validateIcds = _invoice.InvDiagnosisLst.Where(i => i.IcdType == 2);
                //    if (validateIcds.Count() != _invoice.InvDiagnosisLst.Count())
                //    {
                //        await this._facilityRepository.ThrowError();
                //    }
                //}

                if(_invoice.SupervisingProviderId.HasValue)
                {
                    if(_invoice.SupervisingProviderId.Value==_invoice.PerformingProviderId)
                    {
                        await this._providerRepository.ThrowError();
                    }
                }

                if (_invoice.IspmgEncounter.HasValue && _invoice.IspmgEncounter.Value)
                {
                    //foreach (var item in _invoice.ChargeList)
                    //{
                    //    if (item.Icd1Type.HasValue && item.Icd1Type.Value > 0)
                    //    {
                    //        if (item.Icd1Type != 1)
                    //        {
                    //            await this._facilityRepository.ThrowError(item.CPTCode);
                    //        }
                    //    }
                    //}
                }
                else
                {

                    var privoderFacilityValidationList = await this._providerFacilityValidtionRepository.GetAll();
                    var proivderFacVal = privoderFacilityValidationList.FirstOrDefault(i => i.ProviderId == _invoice.ChargeList.FirstOrDefault().PerformingProviderId && i.FacilityId == _invoice.ChargeList.FirstOrDefault().PerformingFacilityId);

                    if(proivderFacVal==null)
                    {
                        if (billingFacility.IsMentalFacility.HasValue && billingFacility.IsMentalFacility.Value)
                        {
                            // mental health
                            foreach (var item in _invoice.ChargeList)
                            {
                                if (item.Icd1Type.HasValue && item.Icd1Type.Value > 0)
                                {
                                    if (item.Icd1Type != 1)
                                    {
                                        await this._facilityRepository.ThrowError(item.CPTCode);
                                    }
                                }
                            }
                        }
                        else
                        {
                            // substance 
                            foreach (var item in _invoice.ChargeList)
                            {
                                if (item.Icd1Type.HasValue && item.Icd1Type.Value > 0)
                                {
                                    if (item.Icd1Type != 2)
                                    {
                                        await this._facilityRepository.ThrowError(item.CPTCode);
                                    }
                                }
                            }
                        }
                    }
                }

                

                /*fetch PatientCase to get PatientId by given patientCaseId*/
                _patientCase = await this._patientCaseRepository.GetPatientCase(entity.PatientCaseId);
                
                /*fetch PatientCase to get PatientId by given patientCaseId*/
                Level = await GetClaimInsuranceLevel(entity,entity.PatientCaseId, entity.InvoiceId, entity.InsuranceLevel,entity.InsurancePolicyUId);
                
                /*get Patient */
                _patient = await this._patientRepository.GetById((int)_patientCase.PatientId);
                

                /*get HCFA Configuration from appsetting*/
                _configAppSettingClaimFormType = await this._appSettingRepository.GetAppSettingClaimType();

                

                /*get Practice General Configuration from appsetting*/
                _configAppSettingPracticeGenConfig = await this._appSettingRepository.GetAppSettingPracticeConfig();
                //_logger.LogInformation(_configAppSettingPracticeGenConfig.FirstOrDefault().ExternalTableUId.ToString());

                var _configIdTypes = await this._configIdTypeRepository.GetAll();
                var configIdType = _configIdTypes.FirstOrDefault(i => i.Name.Contains("CLIA Number"));

                cliaNumber = configIdType.Id;
                _logger.LogInformation($"{cliaNumber.ToString()} 8");
                var claim = await MakeClaim(entity);
                //run scrub
                await this._claimBatchRepository.RunScrub(claim.Id);

                return claim;
            }
            catch
            {
                throw;
            }
        }

        private async Task ChargeZeroValidation(string cptCode)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult("Amount must be greater than 0 (ZERO) for : " + cptCode));

            await this._claimRepository.ThrowError(errors);

        }

        private async Task HAndTCodeValidation(string errorMessage)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(errorMessage));

            await this._claimRepository.ThrowError(errors);

        }

        private async Task<int> GetClaimInsuranceLevel(IAddClaimInfoDTO entity,int patientCaseId, int invoiceId, int insuranceLevel,Guid? policyUId=null)
        {
            try
            {
                if(policyUId== Guid.Empty)
                {
                    policyUId = null;
                }

                var _invoice = await this._chargeInvoiceService.GetByInvoice(patientCaseId, invoiceId);

                /*Get insurance policies which is active in billfromDate*/
                _insurancePolicies = (await this._insurancePolicyRepository.GetActivePolicies(patientCaseId, _invoice.BillFromDate));

                /*Filter insurance policy according to level, level may be primary or secondary*/
                if(policyUId.HasValue)
                _insurancePolicy = _insurancePolicies.FirstOrDefault(i => i.UId== policyUId);
                else
                    _insurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == insuranceLevel);

                if (_insurancePolicy != null)
                {

                    if (!string.IsNullOrWhiteSpace(_insurancePolicy.MedicaidId))
                    {
                        if (_insurancePolicy.MedicaidId == "0")
                        {
                            await this._insurancePolicyRepository.ValidateMedicaidZEROInsurancePolicy();
                        }
                    }

                    if (_insurancePolicy.InsuranceCompanyCode == "SelfP")
                    {
                        await this._insurancePolicyRepository.ValidateSelfPInsurancePolicy();
                    }

                    if (_insurancePolicy.InsuranceCompanyTypeId.ToString() == "0")
                    {
                        //await this._insurancePolicyRepository.ValidateInsuranceCompanyType();
                    }
                    if(insuranceLevel==1)
                    {
                        var thRecord = _invoice.ChargeList.FirstOrDefault(i => i.CPTCode.ToLower().StartsWith("t") || i.CPTCode.ToLower().StartsWith("h"));
                        if (thRecord != null)
                        {
                            if (_insurancePolicy.InsuranceCompanyTypeId != 4 && _insurancePolicy.InsuranceCompanyTypeId != 11)
                            {
                                var secondaryPolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2);//await this._insurancePolicyRepository.GetSecondayPolicy(_invoice.PatientCaseId, _invoice.BillFromDate);
                                if (secondaryPolicy==null)
                                {
                                    await this._invoiceRepository.UpdateReviewNeeded(_invoice.UId, true, "Patient does not has Secondary Policy");
                                    await HAndTCodeValidation("Patient does not has Seconday Policy");
                                }
                                if (secondaryPolicy != null)
                                {
                                    if (secondaryPolicy.InsuranceCompanyTypeId != 4 && secondaryPolicy.InsuranceCompanyTypeId != 11)
                                    {
                                        await this._invoiceRepository.UpdateReviewNeeded(_invoice.UId, true, "Patient does not has Secondary Plan as Medicaid or HMO");
                                        await HAndTCodeValidation("Patient does not has Secondary Plan as Medicaid or HMO");
                                    }                                        
                                }
                                _insurancePolicy = _insurancePolicies.FirstOrDefault(i => i.UId == secondaryPolicy.UId);
                                entity.InsurancePolicyUId = secondaryPolicy.UId;
                            }
                        }

                        
                        if (_insurancePolicy.InsuranceCompanyTypeId.Value != 4)
                        {
                            List<string> nonMedQualification = new List<string>() { "MD", "CNP", "LISW", "PA", "LICDC", "LPCC", "MD-PSYCH" };

                            var providerQual = await this._providerRepository.GetByIdWithQualification(_invoice.PerformingProviderId.Value);
                            if(providerQual!=null)
                            {
                                var existQual = nonMedQualification.FirstOrDefault(i => i.ToString() == providerQual.ProfessionalAbbreviation);
                                if (existQual == null)
                                {
                                    var providerQualSud = await this._providerRepository.GetByIdWithQualificationSUD(_invoice.PerformingProviderId.Value);
                                    if(providerQualSud!=null)
                                    {
                                        existQual = nonMedQualification.FirstOrDefault(i => i.ToString() == providerQualSud.ProfessionalAbbreviation);
                                        if (existQual == null)
                                        {
                                            await this._invoiceRepository.UpdateReviewNeeded(_invoice.UId, true, "Provider Qualication (" + providerQual.ProfessionalAbbreviation + ") does not match with [MD,CNP,LISW,PA,LICDC,LPCC] for none Medicaid claims.");
                                            await this._claimRepository.ThrowProviderQualificationError(providerQual.ProfessionalAbbreviation);
                                        }
                                    }
                                    else
                                    {
                                        await this._invoiceRepository.UpdateReviewNeeded(_invoice.UId, true, "Provider Qualication (" + providerQual.ProfessionalAbbreviation + ") does not match with [MD,CNP,LISW,PA,LICDC,LPCC] for none Medicaid claims.");
                                        await this._claimRepository.ThrowProviderQualificationError(providerQual.ProfessionalAbbreviation);
                                    }
                                }
                            }                            
                        }
                    }


                    if (!string.IsNullOrWhiteSpace(_insurancePolicy.MedicaidId))
                    {
                        if(_insurancePolicy.InsuranceCompanyCode=="41988")
                        {
                            if(_insurancePolicy.PolicyNumber==_insurancePolicy.MedicaidId)
                            {
                                //Stop validtion on 02072022 by Rohit
                                //await this._insurancePolicyRepository.ValidateMedicaidInsurancePolicy();                                
                            }
                        }
                    }

                    //if (_insurancePolicy.InsuranceCompanyCode == "00834" && !string.IsNullOrEmpty(_insurancePolicy.PolicyNumber)) // for ANTHEM insurance company
                    //{
                    //    string p2wText = _insurancePolicy.PolicyNumber.Substring(0, 3);
                    //    if (p2wText.ToLower() != "p2w")
                    //    {
                    //        var pNumber = _insurancePolicy.PolicyNumber.Substring(0, 3);
                    //        var isMatched = Regex.IsMatch(pNumber, @"^[a-zA-Z]+$");
                    //        if (isMatched == false)
                    //        {
                    //            string errorMessage = "ANTHEM policy# " + _insurancePolicy.PolicyNumber + " must start with 3 letter alpha prefix like JRI or MZO or YRN etc.";
                    //            await this._invoiceRepository.UpdateReviewNeeded(_invoice.UId, true, errorMessage);
                    //            await this._insurancePolicyRepository.ValidateAnthemInsurancePolicy();
                    //        }
                    //    }
                    //}

                    /*Fetch insurance policy holder by PolicyHolderId (PHID)*/
                    _insurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(_insurancePolicy.PHID);

                    /*fetch insurance company for given insurance policy*/
                    _insuranceCompany = await this._insuranceCompanyRepository.GetById(_insurancePolicy.InsuranceCompanyID);
                }
                /*if not insurance policy active and exist for given level and billfromDate it will throw exception.
                 Insurance policy does not exist.*/
                else
                    await this._insurancePolicyRepository.ValidateInsurancePolicy();

                return insuranceLevel;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        private IAddClaimInfoDTO _entity;
        public async Task<IClaim> MakeClaim(IAddClaimInfoDTO entity)
        {
            try
            {
                this._entity = entity;
                Claim claim = new Claim();
                //await this.InitializeInsuranceRecord(claim);
                /*set fields which are passing from UI to make claim*/
                claim.InsLevel = Convert.ToInt16(entity.InsuranceLevel);
                claim.Box10Value = string.IsNullOrEmpty(entity.Box10) ? entity.Box7 : entity.Box10;
                claim.RESERVED19 = string.IsNullOrEmpty(entity.Box19) ? entity.Box80 : entity.Box19;
                claim.OriginalReferenceNumber = entity.OriginalReferenceNumber;
                claim.MedicaidResubmissionCode = entity.MedicadeResubmissionCode;
                claim.PatientSignatureDate = entity.PatientSignatureDate;
                claim.Frequency = Convert.ToInt16(entity.Frequency);

                DateTime? signDate = Convert.ToDateTime(claim.PatientSignatureDate);
                claim.PatientSignatureOnFile = !signDate.HasValue ? "" : "Signature on File";

                /*initialize box32 values in claim*/
                await InitializeBox32Facility(claim);


                await FillClaim(claim);
                return claim;
            }
            catch
            {
                throw;
            }
        }

        private async Task<bool> InitializeInsuranceRecord(Claim claim)
        {

            if (_insuranceCompany != null)
            {
                if (_insuranceCompany.CompanyTypeId == _blueCross)
                {
                    short? performingLocationId = _invoice.ChargeList.FirstOrDefault().PerformingFacilityId;

                    var facility = await this._facilityRepository.GetById(performingLocationId.Value);

                    if (!facility.state.Equals(_insuranceCompany.CompanyState))
                    {
                        var _blueCrossInsCompany = await this._insuranceCompanyRepository.GetByState(facility.state);
                        if (_blueCrossInsCompany != null)
                            _insuranceCompany = _blueCrossInsCompany;
                    }

                }
            }
            return true;
        }

        private async Task InitializeBox32Facility(Claim claim)
        {
            try
            {
                /*Check practice general configuration exist in appsetting*/
                if (_configAppSettingPracticeGenConfig.Count() > 0)
                {
                    var res = _configAppSettingPracticeGenConfig.FirstOrDefault(i => i.SettingCD == "Box32FacilityId");
                    if (res != null && res.SettingValue != "0")
                    {
                        /*Fetch facility for settingValue for Box32FacilityId*/
                        var facility = await this._facilityRepository.GetById(Convert.ToInt16(res.SettingValue));
                        if (facility != null)
                        {
                            claim.Box32FacilityId = facility.Id;
                            claim.Box32FacilityAddress1 = facility.Address1;
                            claim.Box32FacilityAddress2 = facility.Address2;
                            claim.Box32FacilityCity = facility.city;
                            claim.Box32FacilityState = facility.state;
                            claim.Box32FacilityZip = facility.ZipCode;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task<bool> FillClaim(Claim claim)
        {
            try
            {
                /*fetch primary insurance policy*/
                //_primaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 1);
                if(this._entity.InsurancePolicyUId==Guid.Empty)
                {
                    _primaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == _entity.InsuranceLevel);
                }
                else
                {
                    _primaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.UId==this._entity.InsurancePolicyUId);
                }
                
                if (_primaryInsurancePolicy != null)
                {
                    /*get primary insurance company for primary policy of patient*/
                    _primaryInsuranceCompany = await this._insuranceCompanyRepository.GetById(_primaryInsurancePolicy.InsuranceCompanyID);

                    /*get primary insurance policy holder for primary policy of patient*/
                    _primaryInsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(_primaryInsurancePolicy.PHID);

                    if ((_primaryInsurancePolicyHolder.PHRel == string.Empty) || (_primaryInsurancePolicyHolder.DOB == null && _primaryInsurancePolicyHolder.FirstName == string.Empty))
                        await this._insurancePolicyHolderRepository.ThrowError();

                    // validating primary Insurance Policy Holder policy details
                    await _insurancePolicyHolderRepository.ValidateInsPolicyHolderAddress(Enum.GetName(typeof(InsuranceLevel), InsuranceLevel.Primary), _primaryInsurancePolicyHolder.Address1, _primaryInsurancePolicyHolder.State, _primaryInsurancePolicyHolder.City, _primaryInsurancePolicyHolder.Zip);

                    _primaryConfigHCFAFormFields = await this._claimConfigRepository.Get(_primaryInsuranceCompany.CompanyTypeId, _primaryInsuranceCompany.UId.ToString(), null);
                }
                /*Get previous claim for given invoiceId and insurance level. if claim already exist for given invoiceId and insurancelevel
                 then claim will be update. In case if claim has been batched and sent then claim will be create new otherwise claim will be
                 update.*/
                var previousClaim = await this._claimRepository.GetByInvoice(_invoice.Id, Convert.ToInt32(claim.InsLevel));
                foreach (var item in previousClaim)
                {
                    if (item.SentDate == null)
                    {
                        /*set claimId to update claim. if claim is already exist.*/
                        claim.Id = item.Id;
                        claim.ClaimBatchId = item.ClaimBatchId;
                    }
                }
                this.claimCharges = new List<ClaimCharge>();
                this.claimsTotal = new List<ClaimTotal>();

                await InitializeClaim(claim);

                var cliaNumberErrorMessage = await FillChargeTotals(claim);

                claim.CurrentIllnesDate = _invoice.IllnessDate;
                claim.OtherIllnesDate = _invoice.IllnessSimDate;
                claim.UnableToWorkFrom = _invoice.DisabilityFrom;
                claim.UnableToWorkTo = _invoice.DisabilityTo;
                //claim.HospitalizationFrom = _invoice.HospitalizedFrom;
                //20 March 2021, this is for Residential only we are setting admission date as current illness date
                claim.CurrentIllnesDate = _invoice.HospitalizedFrom;

                claim.HospitalizationTo = _invoice.HospitalizedTo;
                claim.AccessionNumber = _invoice.AccessionNumber;

                claim.FacilityId = _invoice.FacilityId.ToString();

                List<string> diagnosis = (_invoice.InvDiagnosisLst.Select(s => s.ICDCode)).ToList();

                List<string> uniques = diagnosis.ToArray().Distinct().Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                string newStr = string.Join(",", uniques);

                claim.DiagnosisCodes = newStr;
                if (!string.IsNullOrEmpty(claim.FillingCode) && claim.FillingCode.Length > 2)
                    claim.FillingCode = claim.FillingCode.Substring(0, 2);
                if (!string.IsNullOrEmpty(claim.OtherInsFillingCode) && claim.OtherInsFillingCode.Length > 2)
                    claim.OtherInsFillingCode = claim.OtherInsFillingCode.Substring(0, 2);
                claim.Status = ClaimStatusEnum.CREATED.ToString();

                var result = await this._claimRepository.AddNew(claim);


                _practice = await this._practiceRepository.Get(result.PracticeId);
                claim.PatientAccountNumber = _practice.PracticeCodeCLM + _patient.Id.ToString() + "-" + result.Id.ToString();
                claim.Id = result.Id;

                await this._claimRepository.UpdateEntity(claim);
                claim = result as Claim;
                claim.IsUpdated = claim.IsUpdated ?? false;
                await this._claimChargeRepository.DeleteByClaimId(result.Id);
                await this._claimTotalRepository.DeleteByClaimId(result.Id);
                foreach (var item in this.claimCharges.Distinct())
                {
                    item.ClaimId = result.Id;

                    await this._claimChargeRepository.AddNew(item);
                }

                foreach (var item in claimsTotal)
                {
                    item.ClaimId = result.Id;
                    item.PriorAuthorizationNumber = _invoice.AuthorizationNumber;

                    if (string.IsNullOrWhiteSpace(item.PriorAuthorizationNumber))
                    {
                        var priorAuth = await this._patientAuthorizationRepository.GetByInsurancePolicyId(_insurancePolicy.Id);
                        if (priorAuth != null)
                        {
                            if (_invoice.BillFromDate >= priorAuth.EffectiveDate && _invoice.BillFromDate <= priorAuth.ExpirationDate)
                            {
                                item.PriorAuthorizationNumber = priorAuth.AuthorizationNumber;
                            }
                        }
                    }


                    await this._claimTotalRepository.AddNew(item);
                }


                _invoice.ClaimId = result.Id;
                await this._invoiceRepository.UpdateClaimId(_invoice);
                this.claimCharges = new List<ClaimCharge>();
                claimsTotal = new List<ClaimTotal>();
                return true;
            }
            catch
            {
                throw;
            }
        }

        //private void CompleteClaim(IClaim claim)
        //{
        //    //claim.ClaimBatchId = -(claim.ClearingHouseId.Value);
        //}

        private async Task InitializeClaim(Claim claim)
        {
            try
            {
                claim.ClaimDate = DateTime.Now;

                claim.InvoiceId = _invoice.Id;
                //claim.Frequency = Convert.ToInt16(FrequencyEnum.Original);

                claim.FillingCode = _primaryConfigHCFAFormFields.FilingCode;
                // JC_TODO: should it be if primary or secondary is medicare?
                //if (Level > 1 && _insuranceCompany.CompanyName.Equals("Medicare"))
                //    claim.InsuranceType = Convert.ToString(_insurancePolicy.MedicareSecondary);

                /*set claim type by HCFA configuration*/
                switch (_primaryConfigHCFAFormFields.ClaimType)
                {
                    case "None":
                        claim.ClaimType = (int)AddClaimImfoEnum.None;
                        break;

                    case "Medicaid":
                        claim.ClaimType = (int)AddClaimImfoEnum.Medicaid;
                        break;
                    case "Medicare":
                        claim.ClaimType = (int)AddClaimImfoEnum.Medicare;
                        break;
                    case "ChampVa":
                        claim.ClaimType = (int)AddClaimImfoEnum.ChampVa;
                        break;
                    case "FecaBlackLung":
                        claim.ClaimType = (int)AddClaimImfoEnum.FecaBlackLung;
                        break;
                    case "GroupHealthPlan":
                        claim.ClaimType = (int)AddClaimImfoEnum.GroupHealthPlan;
                        break;
                    case "Tricare":
                        claim.ClaimType = (int)AddClaimImfoEnum.Tricare;
                        break;
                    case "Other":
                        claim.ClaimType = (int)AddClaimImfoEnum.Other;
                        break;
                    default:
                        claim.ClaimType = (int)AddClaimImfoEnum.Other;
                        break;

                }

                //claim.ClaimType = Convert.ToInt16(_primaryConfigHCFAFormFields.ClaimType);
                await this.FillDefaultFacility(claim);

                /*insert patient info into claim object*/
                await FillPatientData(claim);

              await  FillInsuranceAddress(claim);
                if (_invoice.AuthorizationNumberId != null && _invoice.AuthorizationNumberId.Value > 0)
                    _patientAuthorization = await this._patientAuthorizationRepository.Get(_invoice.AuthorizationNumberId.Value);
                await FillPrimaryInsuredAcceptAssignment(claim);
                await FillPerformingLocation(claim);
                if (_invoice.BillFacilityId != null)
                {
                    await FillFacilityId(_invoice.BillFacilityId.Value, claim);
                    await FillPOSCode(_invoice.BillFacilityId.Value, claim);
                    await FillFederalTaxIDNo(_invoice.BillFacilityId.Value, claim);
                    await FillTaxonomy(_invoice.BillFacilityId.Value, claim);
                }
                await FillDoctorInfo(claim);

                await FillSecondary(claim);

                await FillOthers2(claim);

                if (_primaryConfigHCFAFormFields.Box11dBlank.HasValue && _primaryConfigHCFAFormFields.Box11dBlank.Value)
                    claim.HasAnotherPlan = false;
                await FillReserved10(_invoice.BillProviderId);
                await FillReferringDoctor(claim);

                claim.FromDate = _invoice.BillFromDate;
                claim.ToDate = _invoice.BillToDate;
                //FillBox24();
                if (_invoice.AuthorizationNumberId != null && _invoice.AuthorizationNumberId > 0 && _patientAuthorization != null)
                {
                    claim.PriorAuthorizationNumber = _patientAuthorization.AuthorizationNumber;
                }
                

                claim.AccAuto = _invoice.AccAuto;
                claim.AccEmploy = _invoice.AccEmploy;
                claim.AccOther = _invoice.AccOther;
                claim.AccState = _invoice.AccState;

                var clearingHouse = await this._clearingHouseRepository.GetById(claim.ClearingHouseId.Value);
                if (clearingHouse != null)
                {
                    claim.TransactionNumber = clearingHouse.TransactionNumber + 1;
                    clearingHouse.TransactionNumber = claim.TransactionNumber;
                    await this._clearingHouseRepository.UpdateTransactionNumber(clearingHouse);
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task FillPOSCode(short facilityId, Claim claim)
        {
            try
            {
                /*insert pos code*/
                var result = await this._facilityRepository.GetById(facilityId);
                if (result != null)
                    claim.POSCode = result.POSCode;
            }
            catch
            {
                throw;
            }
        }

        private async Task FillPatientData(Claim claim)
        {
            try
            {
                /*set patient info*/
                claim.PatientName = (_patient.LastName + ',' + _patient.FirstName + _patient.MI).Length > 27 ? (_patient.LastName + ',' + _patient.FirstName + _patient.MI).Substring(0, 27) : _patient.LastName + ',' + _patient.FirstName + _patient.MI;
                claim.PatientDOB = _patient.DOB;
                claim.PatientStreet = _patient.Address1 + " " + _patient.Address2;
                if (!string.IsNullOrEmpty(claim.PatientStreet))
                    claim.PatientStreet = claim.PatientStreet.Length > 27 ? claim.PatientStreet.Substring(0, 27) : claim.PatientStreet;
                claim.PatientState = _patient.State;
                claim.PatientCity = _patient.City;
                claim.PatientZip = _patient.ZipCode;

                await _patientRepository.ValidatePatientAddress(_patient.Address1, claim.PatientState, claim.PatientCity, claim.PatientZip);

                claim.PatientPhone = _patient.PhoneNumber;
                //claim.PatientPhone = GetAreaContactInfo(_patient.PhoneNumber, false);
                claim.PatientAreaCode = null;
                //claim.PatientAreaCode = GetAreaContactInfo(_patient.PhoneNumber, true);
                claim.PatientFirstName = _patient.FirstName.Length > 49 ? _patient.FirstName.Substring(0, 49) : _patient.FirstName;
                claim.PatientLastName = _patient.LastName.Length > 49 ? _patient.LastName.Substring(0, 49) : _patient.LastName;
                claim.PatientMiddleName = _patient.MI;
                claim.PatientGender = _patient.Sex;


                relationShip = _primaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self) ? Convert.ToInt32(RelationshipEnum.Self)
                    : (_primaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Spouse) ? Convert.ToInt32(RelationshipEnum.Spouse)
                    : (_primaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Child) ? Convert.ToInt32(RelationshipEnum.Child)
                    : Convert.ToInt32(RelationshipEnum.Other)));
                
                claim.PolicyHolderRelation = Convert.ToInt16(relationShip);                
            }
            catch
            {
                throw;
            }
        }

        private async Task FillPerformingLocation(Claim claim)
        {
            try
            {
                /*set performing Detail into claim object*/
                var firstCharge = _invoice.ChargeList.FirstOrDefault();
                if (firstCharge != null)
                {
                    var facility = await this._facilityRepository.GetById(Convert.ToInt16(firstCharge.PerformingFacilityId));
                    if (facility != null)
                    {
                        var facilityIdentity = await this._facilityIdentityRepository.GetIdentity(facility.Id, 1);
                        //var providerIdentity = await this._providerIdentityRepository.GetProviderIdentity(firstCharge.PerformingProviderId.Value, 1, claim.FromDate);

                        //claim.PerformingDoctorName = facility.Name;
                        //claim.PerformingDoctorAddressLine1 = facility.Address1;
                        //claim.PerformingDoctorAddressLine2 = facility.Address2;
                        //claim.PerformingDoctorCity = facility.city;
                        //claim.PerformingDoctorState = facility.state;
                        //claim.PerformingDoctorZip = facility.ZipCode;
                        //claim.PerformingDoctorPhone = facility.Phone;



                        claim.PerformingLocationName = facility.Name;
                        claim.PerformingLocationAddressLine1 = facility.Address1;
                        claim.PerformingLocationAddressLine2 = facility.Address2;
                        claim.PerformingLocationCity = facility.city;
                        claim.PerformingLocationState = facility.state;
                        claim.PerformingLocationZIP= facility.ZipCode;
                        claim.PerformingLocationPhone = facility.Phone;


                        if (facilityIdentity != null)
                            claim.PerformingFacilityNPI = facilityIdentity.Identifier;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task FillFederalTaxIDNo(short facilityId, Claim claim)
        {
            try
            {
                /*set FederalTaxIDNumber into claim object*/
                _identifier = await GetFacilityId(facilityId, _federalTaxId);

                if (_identifier != null)
                    claim.FederalTaxIDNumber = _identifier.Identifier;
            }
            catch
            {
                throw;
            }

        }

        private async Task FillTaxonomy(short facilityId, Claim claim)
        {
            try
            {
                /*set taxonomyCode into claim object*/
                var taxonomy = Convert.ToInt32(_primaryConfigHCFAFormFields.GRP);
                if (taxonomy > 0)
                {
                    _identifier = await GetFacilityId(facilityId, _taxonomyId);
                    if (_identifier != null)
                        claim.TaxonomyCode = _identifier.Identifier;
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task FillInsuranceAddress(Claim claim)
        {
            /*Set insurance info into claim object*/
            claim.InsuranceCompanyId = (int)_insurancePolicy.InsuranceCompanyID;
                        
            //if (this._invoice.BillFromDate>Convert.ToDateTime("1 Feb 2023"))
            //{
            //    claim.InsuranceCompanyCode = _insuranceCompany.CompanyCode;                
            //}
            //else
            //{
            //    claim.InsuranceCompanyCode = !string.IsNullOrWhiteSpace(_insuranceCompany.TempCompanyCode) ? _insuranceCompany.TempCompanyCode : _insuranceCompany.CompanyCode;
            //}

            claim.InsuranceCompanyCode = !string.IsNullOrWhiteSpace(_insuranceCompany.TempCompanyCode) ? _insuranceCompany.TempCompanyCode : _insuranceCompany.CompanyCode;
            claim.PolicyGroupNumber = _insurancePolicy.GroupNumber;
            claim.PolicyGroupName = _insurancePolicy.GroupName;
            claim.CarrierTypeId = _insuranceCompany.CompanyTypeId;
            if (claim.CarrierTypeId == 4)
            {
                claim.PolicyHolderRelation = 1;
            }
            claim.PayerName = _primaryInsuranceCompany.CompanyName;
            claim.IsRefProviderAndRendProviderSame = _insuranceCompany.IsRefProviderAndRendProviderSame == null ? false : _insuranceCompany.IsRefProviderAndRendProviderSame;
            claim.IsLoop2420ARequired = _insuranceCompany.IsLoop2420ARequired== null ? false : _insuranceCompany.IsLoop2420ARequired;
            claim.PatientCaseId = Convert.ToInt16(_invoice.PatientCaseId);
            claim.CaseTypeId = Convert.ToInt16(_patientCase.CaseTypeId);
            claim.FormTypeId = _insuranceCompany.FormTypeId;
            claim.CaseIdNumber = _patientCase.CaseIdNumber;
            claim.ClaimToAddress1 = _insuranceCompany.CompanyName.Length > 34 ? _insuranceCompany.CompanyName.Substring(0, 34) : _insuranceCompany.CompanyName;
            claim.ClaimToAddress2 = (_insuranceCompany.CompanyAddress1 + _insuranceCompany.CompanyAddress2).Length > 30 ? (_insuranceCompany.CompanyAddress1 + _insuranceCompany.CompanyAddress2).Substring(0, 29) : _insuranceCompany.CompanyAddress1 + _insuranceCompany.CompanyAddress2;
            claim.ClaimToCity = _insuranceCompany.CompanyCity.Length > 29 ? _insuranceCompany.CompanyCity.Substring(0, 29) : _insuranceCompany.CompanyCity;
            claim.ClaimToState = _insuranceCompany.CompanyState.Length > 14 ? _insuranceCompany.CompanyState.Substring(0, 14) : _insuranceCompany.CompanyState;
            claim.ClaimToZip = _insuranceCompany.CompanyZip;
            claim.ClearingHouseId = _insuranceCompany.ClearingHouseId;

            claim.MedicaidClearingHouseId = null;
            claim.MedicaidPayerId = null;
            claim.MedicaidPayerReceiverId = null;


            var clearingHouse = await this._clearingHouseRepository.GetById(claim.ClearingHouseId.Value);

            if (_insuranceCompany.MedicaidClearingHouseId.HasValue)
            {
                if (clearingHouse.IsOhioMedicaid.HasValue && clearingHouse.IsOhioMedicaid.Value)
                {
                    claim.MedicaidClearingHouseId = _insuranceCompany.MedicaidClearingHouseId;
                    claim.ClearingHouseId = (short)_insuranceCompany.MedicaidClearingHouseId.Value;
                }
            }
            if (!string.IsNullOrWhiteSpace(_insuranceCompany.MedicaidPayerId))
            {
                if (clearingHouse.IsOhioMedicaid.HasValue && clearingHouse.IsOhioMedicaid.Value)
                    claim.MedicaidPayerId = _insuranceCompany.MedicaidPayerId;
            }
            if (!string.IsNullOrWhiteSpace(_insuranceCompany.MedicaidPayerReceiverId))
            {
                if (clearingHouse.IsOhioMedicaid.HasValue && clearingHouse.IsOhioMedicaid.Value)
                    claim.MedicaidPayerReceiverId = _insuranceCompany.MedicaidPayerReceiverId;
            }

            if (_insuranceCompany.TransmitClaims)
            {
                claim.CanBeSentElectronically = "E";
                claim.ShouldBePrinted = string.Empty;
            }
            else
            {
                claim.ShouldBePrinted = "P";
                claim.CanBeSentElectronically = string.Empty;
            }
        }

        private async Task FillDefaultFacility(Claim claim)
        {
            try
            {
                /*fetch default facility of practice*/
                var defaultFacility = await this._facilityRepository.GetDefaultFacility();

                if (defaultFacility != null) /*set billTypeCode*/
                    claim.BillTypeCode = Convert.ToString(defaultFacility.Id) + Convert.ToString(defaultFacility.FacilitySubTypeId) + Convert.ToString(claim.Frequency);
            }
            catch
            {
                throw;
            }
        }

        private async Task FillPrimaryInsuredAcceptAssignment(Claim claim)
        {
            try
            {
                /*filter primary insurance policy from all active policy of patient during billfromdate*/
                //_primaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 1);
                if(_entity.InsurancePolicyUId==Guid.Empty)
                {
                    _primaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == _entity.InsuranceLevel);
                }else
                    _primaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.UId == _entity.InsurancePolicyUId);


                /*Get primary insurance company*/
                _primaryInsuranceCompany = await this._insuranceCompanyRepository.GetById(_primaryInsurancePolicy.InsuranceCompanyID);

                /*Get primary insurance policy holder*/
                _primaryInsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(_primaryInsurancePolicy.PHID);

                /*Set policy no*/
                if (_primaryConfigHCFAFormFields.Box1aBlank.HasValue && _primaryConfigHCFAFormFields.Box1aBlank.Value)
                    claim.PolicyNo = "";
                else
                {
                    if(_primaryInsurancePolicy.InsuranceCompanyName.ToLower().Contains("paramount"))
                    {

                        if (this._invoice.BillFromDate > Convert.ToDateTime("1 Feb 2023"))
                        {
                            if(_primaryInsurancePolicy.InsuranceCompanyTypeId==4)
                            {
                                if (_primaryInsurancePolicy.MedicaidId != null)
                                    claim.PolicyNo = _primaryInsurancePolicy.MedicaidId.Length > 27 ? _primaryInsurancePolicy.MedicaidId.Substring(0, 27) : _primaryInsurancePolicy.MedicaidId;
                            }
                            else
                            {
                                claim.PolicyNo = _primaryInsurancePolicy.PolicyNumber.Length > 27 ? _primaryInsurancePolicy.PolicyNumber.Substring(0, 27) : _primaryInsurancePolicy.PolicyNumber;
                            }
                            
                        }
                        else
                        {
                            claim.PolicyNo = _primaryInsurancePolicy.PolicyNumber.Length > 27 ? _primaryInsurancePolicy.PolicyNumber.Substring(0, 27) : _primaryInsurancePolicy.PolicyNumber;
                        }
                    }
                    else
                    {
                        if(!string.IsNullOrWhiteSpace(_primaryInsurancePolicy.MedicaidId))
                        {
                            claim.PolicyNo = _primaryInsurancePolicy.MedicaidId.Length > 27 ? _primaryInsurancePolicy.MedicaidId.Substring(0, 27) : _primaryInsurancePolicy.MedicaidId;
                            if(claim.PolicyNo.Length<12)
                            {
                                await this._invoiceRepository.UpdateReviewNeeded(_invoice.UId, true, "Medicaid Policy Number should not be less than 12 characters");
                                await this._claimRepository.ThrowMedicaidPolicyLengthError();
                            }

                        }
                        else
                        {
                            claim.PolicyNo = _primaryInsurancePolicy.PolicyNumber.Length > 27 ? _primaryInsurancePolicy.PolicyNumber.Substring(0, 27) : _primaryInsurancePolicy.PolicyNumber;
                        }
                    }
                }
                    


                //if (!_primaryConfigHCFAFormFields.MedicareSecondaryPayer)
                {
                    /*Set policy holder group no*/
                    if (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.None) || _primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherGroupID))
                        claim.PolicyHolderGroupNo = "None";
                    else
                        claim.PolicyHolderGroupNo = _primaryInsurancePolicy.GroupNumber;


                    if (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.None))
                    {
                        claim.PolicyHolderEmpl = _primaryInsurancePolicyHolder.LastName + "," + _primaryInsurancePolicyHolder.FirstName;
                    }
                    claim.PolicyInsurancePlanName = _primaryInsurancePolicy.PlanType;



                    if (_primaryConfigHCFAFormFields.Box11cPayorID.HasValue && _primaryConfigHCFAFormFields.Box11cPayorID.Value && !string.IsNullOrWhiteSpace(_primaryInsuranceCompany.CompanyCode))
                        claim.PolicyInsurancePlanName = _primaryInsuranceCompany.CompanyCode;

                    if (_primaryConfigHCFAFormFields.Box9a == Convert.ToString(HCFA.Box9aValues.PrimaryInsured))
                    {
                        var strPrefix = "";
                        if (_primaryConfigHCFAFormFields.Box9aPrefix != "")
                            strPrefix += " ";

                        claim.OtherPolicyHolderGroupNo = strPrefix + (_primaryInsurancePolicy.PolicyNumber);
                    }
                }

                FillInsuredsInfo(true, claim);
                claim.AcceptAssignment = _primaryInsurancePolicy.AcceptAssignment;
                claim.PolicyHolderSignature = _primaryInsurancePolicy.PHSignatureOnFile ? "Signature on File" : "";

                claim.InsuranceSignatureOnFile = claim.PolicyHolderSignature;
            }
            catch
            {
                throw;
            }
        }

        private void FillInsuredsInfo(bool blnMedicareSecondaryPayer, Claim claim)
        {
            // Box 4 and 7 on HCFA form
            /*set policy holder info into claim object*/

            claim.PolicyHolderName = _primaryInsurancePolicyHolder.LastName + ", " + _primaryInsurancePolicyHolder.FirstName;
            claim.PolicyHolderStreet = _primaryInsurancePolicyHolder.Address1 + " " + _primaryInsurancePolicyHolder.Address2;
            claim.PolicyHolderStreet = claim.PolicyHolderStreet.Length > 27 ? claim.PolicyHolderStreet.Substring(0, 27) : claim.PolicyHolderStreet;
            if (!string.IsNullOrEmpty(_primaryInsurancePolicyHolder.Address1))
                claim.PolicyHolderAddress1 = _primaryInsurancePolicyHolder.Address1.Length > 27 ? _primaryInsurancePolicyHolder.Address1.Substring(0, 27) : _primaryInsurancePolicyHolder.Address1;
            if (!string.IsNullOrEmpty(_primaryInsurancePolicyHolder.Address2))
                claim.PolicyHolderAddress2 = _primaryInsurancePolicyHolder.Address2.Length > 27 ? _primaryInsurancePolicyHolder.Address2.Substring(0, 27) : _primaryInsurancePolicyHolder.Address2;

            //if (claim.PolicyHolderStreet.Length > 27)
            //    claim.PolicyHolderStreet = claim.PolicyHolderStreet.Substring(0, 27);
            claim.PolicyHolderAddress1 = _primaryInsurancePolicyHolder.Address1 == null ? "" : _primaryInsurancePolicyHolder.Address1.Length > 27 ? _primaryInsurancePolicyHolder.Address1.Substring(0, 27) : _primaryInsurancePolicyHolder.Address1;
            claim.PolicyHolderAddress2 = _primaryInsurancePolicyHolder.Address2 == null ? "" : _primaryInsurancePolicyHolder.Address2.Length > 27 ? _primaryInsurancePolicyHolder.Address2.Substring(0, 27) : _primaryInsurancePolicyHolder.Address2;


            //if (this._invoice.BillFromDate > Convert.ToDateTime("1 Feb 2023"))
            //{
            //    claim.OtherCompanyCode = _primaryInsuranceCompany.CompanyCode;                
            //}
            //else
            //{
            //    claim.OtherCompanyCode = !string.IsNullOrWhiteSpace(_primaryInsuranceCompany.TempCompanyCode) ? _primaryInsuranceCompany.TempCompanyCode : _primaryInsuranceCompany.CompanyCode;
            //}

            claim.OtherCompanyCode = !string.IsNullOrWhiteSpace(_primaryInsuranceCompany.TempCompanyCode) ? _primaryInsuranceCompany.TempCompanyCode : _primaryInsuranceCompany.CompanyCode;


            claim.PolicyHolderCity = _primaryInsurancePolicyHolder.City;
            claim.PolicyHolderState = _primaryInsurancePolicyHolder.State;
            claim.PolicyHolderZip = _primaryInsurancePolicyHolder.Zip;
            claim.PolicyHolderPhone = _primaryInsurancePolicyHolder.HomePhone;
            claim.PolicyHolderAreaCode = null;
            //claim.PolicyHolderAreaCode = GetAreaContactInfo(_primaryInsurancePolicyHolder.HomePhone, true);
            claim.PolicyHolderGroupNo = _primaryInsurancePolicy.GroupNumber;
            claim.PolicyHolderDOB = _primaryInsurancePolicyHolder.DOB;
            if (_primaryInsurancePolicyHolder.Sex == "M")
                claim.PolicyHolderSex = 0;
            if (_primaryInsurancePolicyHolder.Sex == "F")
                claim.PolicyHolderSex = 1;

        }

        /// <summary>
        ///set reserved10  
        /// </summary>
        /// <param name="billingProviderId"></param>
        /// <returns></returns>
        private async Task FillReserved10(short? billingProviderId)
        {
            try
            {
                StringBuilder hcfaReserved10 = new StringBuilder(_primaryConfigHCFAFormFields.Reserved10);

                if (!string.IsNullOrEmpty(_primaryConfigHCFAFormFields.Res10Provider) && billingProviderId > 0)
                {
                    var providerIdentity = await this._providerIdentityRepository.GetProviderIdentity(_invoice.BillProviderId.Value, Convert.ToInt32(_primaryConfigHCFAFormFields.Res10Provider), null, "Res10Provider");
                    if (providerIdentity != null)
                        hcfaReserved10.Replace("%P", providerIdentity.Identifier);
                }
                if (_secondary2InsuranceCompany != null)
                    hcfaReserved10.Replace("%I", _secondary2InsurancePolicy.PolicyNumber);
                else if (_secondaryInsuranceCompany != null)
                    hcfaReserved10.Replace("%I", _secondaryInsurancePolicy.PolicyNumber);                
                else
                    hcfaReserved10.Replace("%I", "");
                hcfaReserved10.Replace("%J", _primaryInsurancePolicy.PolicyNumber);

                Reserved10 = hcfaReserved10.ToString();
            }
            catch
            {
                throw;
            }
        }

        private async Task FillFacilityId(short intFacilityId, Claim claim)
        {
            try
            {
                /*set facility identifier in billingFacilityId of claim object*/
                _primaryConfigHCFAFormFields.FacilityNum = string.IsNullOrEmpty(_primaryConfigHCFAFormFields.FacilityNum) ? "1" : _primaryConfigHCFAFormFields.FacilityNum;

                _identifier = await GetFacilityId(intFacilityId, Convert.ToInt32(_primaryConfigHCFAFormFields.FacilityNum));

                var strEs = _primaryConfigHCFAFormFields.Box33bSpace.Value ? " " : "";
                if (_identifier != null)
                    claim.BillingFacilityId = strEs + _identifier.Identifier;
            }
            catch
            {
                throw;
            }
        }

        private async Task<IFacilityIdentity> GetFacilityId(short facilityId, int? facilityIdType)
        {
            try
            {
                /*Get facility identifier for given facilityId and facilityTypeId*/
                var result = await this._facilityIdentityRepository.GetIdentity(facilityId, facilityIdType);

                return result;
            }
            catch
            {
                throw;
            }
        }

        private async Task<string> FillChargeTotals(Claim claim)
        {
            try
            {
                bool isMedicareRange = false;
                short intPageNumber = 1; /*Initialize page number it would be start from 1*/
                int intServicesCount = 0;
                int intMaximumNumberOfPages = 0;
                decimal decTotalAmountBilled = 0.0M;
                bool blnHasLab = false;
                short? billingProvider;
                string cliaNumberErrorMessage = "";
                int maxCount = 0;
                customAuthorizationNo = string.Empty;
                IEnumerable<IConfigInsuranceCompanyType> configInsuranceCompanyTypes = null;
                var intNumberOfCharges = _invoice.ChargeList.Count(); /*No of charges*/
                IChargeTotal chargeTotal = new ChargeTotal();

                /*if no charges it will return without make claim*/
                if (intNumberOfCharges == 0)
                {
                    return cliaNumberErrorMessage;

                }

                _primaryConfigInsuranceFormType = await this._configInsuranceFormTypeRepository.Get((short)_primaryInsuranceCompany.FormTypeId);
                /*set max no of charges will print on one page of claim pdf. whenever practice is for CMS1500
                 only 6 charges can print on single page of claim pdf. if practice is for UB04 then 22 charges can print on single page.*/
                claim.MaxServices = _primaryConfigInsuranceFormType.MaxServices;

                if (_configAppSettingClaimFormType.SettingValue == "UB04")
                    claim.MaxServices = 22;
                else
                    claim.MaxServices = 6;

                /*total billl amount for given invoice which is going to make claim*/
                claim.TotalBilled = (float)_invoice.ChargeList.Sum(i => i.Amount);

                /*calculate max no of pages to print for claim pdf*/
                intMaximumNumberOfPages = (intNumberOfCharges + claim.MaxServices.Value - 1) / claim.MaxServices.Value;

                billingProvider = _invoice.BillProviderId;

                foreach (var charge in _invoice.ChargeList.Distinct())
                {
                    /*claim would be made for only those charges which are due by Insurance not patient*/
                    if (charge.BillToInsurance == true)
                    {
                        // blnHasLab = (charge.ToS = "05")
                        if (Regex.IsMatch(charge.CPTCode, "^[0-9 ]+$"))
                        {
                            var intCode = Convert.ToInt32(charge.CPTCode);
                            if (intCode >= 80047 && intCode <= 89398)
                            {
                                isMedicareRange = true;
                                configInsuranceCompanyTypes = await this._configInsuranceCompanyTypeRepository.GetAll();
                            }
                        }

                        if (charge.CPTCode.StartsWith("G"))
                        {
                            isMedicareRange = true;
                            configInsuranceCompanyTypes = await this._configInsuranceCompanyTypeRepository.GetAll();
                        }

                        if ((charge.Mod1 == "90" || charge.Mod2 == "90" || charge.Mod3 == "90" || charge.Mod4 == "90") && _invoice.BillFacilityId != charge.PerformingFacilityId)
                        {
                            isReferringLab = true;
                        }
                        await FillChargeInfo(charge, _invoice, chargeTotal, intPageNumber);

                        intServicesCount += 1;

                        if (intServicesCount == claim.MaxServices || intServicesCount == intNumberOfCharges)
                        {
                            var charges = _invoice.ChargeList;
                            if (maxCount == 0)
                            {
                                charges = _invoice.ChargeList.Take(claim.MaxServices.Value);
                            }
                            else
                            {
                                var restData = _invoice.ChargeList.Skip(maxCount);
                                charges = restData.Take(claim.MaxServices.Value);

                            }
                            chargeTotal.TotalCharges = charges.Sum(i => i.Amount);

                            await FillServiceTotals(decTotalAmountBilled, chargeTotal, intPageNumber, blnHasLab, billingProvider, claim);



                            intServicesCount = 0;
                            blnHasLab = false;
                            intPageNumber += 1;
                            //chargeTotals.Initialize();
                            chargeTotal = new ChargeTotal();
                            maxCount += claim.MaxServices.Value;
                        }
                    }
                }

                if (intServicesCount > 0)
                {
                    /*Calculate sum of total charges for given invoice*/
                    chargeTotal.TotalCharges = _invoice.ChargeList.Sum(i => i.Amount);
                    if (maxCount != 0)
                    {
                        var restData = _invoice.ChargeList.Skip(maxCount);
                        var charges = restData.Take(claim.MaxServices.Value);
                        /*Calculate sum of total charges of rest charges which are not included in ChargeTotal for given invoice*/
                        chargeTotal.TotalCharges = charges.Sum(i => i.Amount);
                    }
                    if ((_invoice.ChargeList.FirstOrDefault(i => i.Mod1 == "90" || i.Mod2 == "90" || i.Mod3 == "90" || i.Mod4 == "90") != null && _invoice.ChargeList.FirstOrDefault(i => i.PerformingFacilityId != _invoice.BillFacilityId) != null))
                    {
                        isReferringLab = true;
                    }

                    await FillServiceTotals(decTotalAmountBilled, chargeTotal, intPageNumber, blnHasLab, billingProvider, claim);
                }

                AmountBilled = decTotalAmountBilled;



                if (configInsuranceCompanyTypes != null && configInsuranceCompanyTypes.Count() > 0)
                {
                    //var companyType = configInsuranceCompanyTypes.FirstOrDefault(i => i.CompanyType.Contains("Medicare"));
                    //if (isMedicareRange && companyType != null && claim.CarrierTypeId == companyType.Id)
                    if (isMedicareRange)
                    {
                        if (_primaryConfigHCFAFormFields.Box23 == cliaNumber.ToString())
                            claim.IsCliaNumber = true;
                    }
                }

                if (claim.IsCliaNumber == true)
                {
                    var identifier = await GetFacilityId(_invoice.ChargeList.FirstOrDefault().PerformingFacilityId.Value, cliaNumber);
                    if (identifier != null)
                    {
                        //foreach (var item in claimsTotal)
                        //{
                        //    item.PriorAuthorizationNumber = identifier.Identifier;
                        //}
                        customAuthorizationNo = identifier.Identifier;
                    }
                }
                if (isReferringLab)
                {
                    var res = await GetFacilityId(_invoice.ChargeList.FirstOrDefault().PerformingFacilityId.Value, cliaNumber);
                    claim.ReferCliaNumber = res.Identifier;
                }
                else
                    claim.ReferCliaNumber = null;

                var cliaCpts = new string[] { "82075", "81025" };

                var cliaCptCodes = this._invoice.ChargeList.FirstOrDefault(i => cliaCpts.Contains(i.CPTCode));
                if(cliaCptCodes!=null)
                {
                    var res = await GetFacilityId(_invoice.ChargeList.FirstOrDefault().PerformingFacilityId.Value, cliaNumber);
                    if(res!=null)
                    {
                        claim.ReferCliaNumber = res.Identifier;
                        if (!string.IsNullOrWhiteSpace(claim.ReferCliaNumber))
                            claim.IsCliaNumber = true;
                    }
                }


                return cliaNumberErrorMessage;
            }
            catch
            {
                throw;
            }
        }

        private async Task FillChargeInfo(ICharges charge, IInvoice invoice,
                                        IChargeTotal chargeTotal, short intPageNumber)
        {
            try
            {
                DateTime? minFromDate = DateTime.MinValue;
                DateTime? maxToDate = DateTime.MaxValue;
                ClaimCharge claimCharge = new ClaimCharge();
                short facilityId = 0;
                claimCharge.ChargeId = charge.Id;
                claimCharge.PageNumber = intPageNumber;

                //_invoice.BillFacilityId
                if (charge.Mod1 == "90" || charge.Mod2 == "90" || charge.Mod3 == "90" || charge.Mod4 == "90")
                {
                    var defaultFacility = await this._facilityRepository.GetDefaultFacility();
                    if (defaultFacility != null)
                        facilityId = defaultFacility.Id;
                    else
                        facilityId = _invoice.BillFacilityId.Value;

                    if (charge.PerformingFacilityId != facilityId)
                    {
                        var facilityIdentity = await this._facilityIdentityRepository.GetIdentity(charge.PerformingFacilityId.Value, cliaNumber);
                        claimCharge.ChargeId = charge.Id;                        
                        claimCharge.CliaNumber = facilityIdentity.Identifier;
                    }
                }
                claimCharge.Mod1 = charge.Mod1;
                claimCharge.Mod2 = charge.Mod2;
                claimCharge.Mod3 = charge.Mod3;
                claimCharge.Mod4 = charge.Mod4;
                this.claimCharges.Add(claimCharge);

                var array = new[] { charge.ICD1, charge.ICD2, charge.ICD3, charge.ICD4 };

                if (minFromDate > charge.BillFromDate)
                    minFromDate = charge.BillFromDate;

                if (maxToDate < charge.BillToDate)
                    maxToDate = charge.BillToDate;

                /*add total charges and discounts*/
                chargeTotal.TotalCharges += charge.Amount;
                chargeTotal.TotalDiscounts += charge.Discount;
            }
            catch
            {
                throw;
            }
        }

        private async Task FillBillingProviderFacility(Claim claim, short facilityId)
        {
            try
            {
                /*add provider's facility*/
                var facility = await this._facilityRepository.GetById(facilityId);
                claim.BillingProviderFacilityName = facility == null ? "" : facility.Name;
            }
            catch
            {
                throw;
            }
        }

        private async Task FillDoctorInfo(Claim claim)
        {
            try
            {
                /*set billing doctor name by billingProvider*/
                _provider = await this._providerRepository.GetById(_invoice.BillProviderId.Value);
                claim.BillingDoctorName = _provider.FullName;
                claim.BillingDoctorFirstName = _provider.FirstName;
                claim.BillingDoctorLastName = _provider.LastName;
                claim.BillingDoctorMiddleName = _provider.Middle;
                var performingProvider = await this._providerRepository.GetById(_invoice.PerformingProviderId.Value);

                claim.PerformingDoctorId = performingProvider.Id;

                claim.PerformingDoctorName = performingProvider.FullName.Length>30? performingProvider.FullName.Substring(0,29): performingProvider.FullName;
                claim.PerformingDoctorAddressLine1 = performingProvider.Address1;
                claim.PerformingDoctorAddressLine2 = performingProvider.Address2;
                claim.PerformingDoctorCity = performingProvider.City;
                claim.PerformingDoctorState = performingProvider.State;
                claim.PerformingDoctorZip = performingProvider.ZipCode;
                claim.PerformingDoctorFirstName = performingProvider.FirstName;
                claim.PerformingDoctorLastName = performingProvider.LastName;
                claim.PerformingDoctorMiddleName = !string.IsNullOrWhiteSpace(performingProvider.Middle) ? performingProvider.Middle : "";

                var performingNpi=await this._providerIdentityRepository.GetNPIByProviderId(performingProvider.UId);
                if(performingNpi!=null)
                {
                    if(performingNpi.Identifier== "XXXXXXXXXX")
                    {
                        await this._claimRepository.ThrowDummyProviderError();
                    }

                    claim.PerformingDoctorNPI = performingNpi.Identifier;
                }
                var billingFacility = await this._facilityRepository.GetById(_invoice.BillFacilityId.Value);
                
                if(this._insuranceCompany.IsProviderTaxonomyNeeded.HasValue && this._insuranceCompany.IsProviderTaxonomyNeeded.Value)
                {
                    var performingTaxonomy = await this._providerIdentityRepository.GetProviderTaxonomyByProviderUId(performingProvider.UId, billingFacility);
                    if (performingTaxonomy != null)
                    {
                        claim.PerformingProviderTaxonomy = performingTaxonomy.Identifier;
                    }
                }
                else
                {
                    claim.PerformingProviderTaxonomy = "";
                }


                claim.IsLoop2310DRequired = performingProvider.IsBillUnderSupervisor!=null? performingProvider.IsBillUnderSupervisor:false;
                if (_invoice.BillProviderId.HasValue)
                {
                    claim.BillingDoctorName = _provider.FullName;
                    claim.BillingFacilityNPI = _identifier.Identifier;
                }

                //var firstCharge = _invoice.ChargeList.FirstOrDefault();
                //if (firstCharge != null)
                //{
                //    var performingLocationId = firstCharge.PerformingFacilityId;
                var provider = await this._providerRepository.GetById(_invoice.BillProviderId.Value);
                await FillBillingProviderFacility(claim, provider.FacilityId);
                //}
                await GetFacilityInfoAndFillBillingLines(claim);

                //Commented code on 18 march 2021
                /*set phsician signature Max length 21 */
                //if (_primaryConfigHCFAFormFields.Box31Clinic.HasValue && _primaryConfigHCFAFormFields.Box31Clinic.Value)
                //{
                //    if (_facility.Name.Length > 21)
                //        claim.PhysicianSignature = _facility.Name.Substring(0, 21);
                //    else
                //        claim.PhysicianSignature = _facility.Name;
                //}
                //else
                //{
                //    if (claim.BillingDoctorName.Length > 21)
                //        claim.PhysicianSignature = _provider.FullNameForClaim.Substring(0, 21);                    
                //    else
                //        claim.PhysicianSignature = _provider.FullNameForClaim;                    
                //}
                //Commented code on 18 march 2021

                //Commented write for above commented code on 18 march 2021
                if (claim.PerformingDoctorName.Length > 21)
                    claim.PhysicianSignature = performingProvider.FullNameForClaim.Substring(0, 21);
                else
                    claim.PhysicianSignature = performingProvider.FullNameForClaim;
                //Commented write for above commented code on 18 march 2021


                claim.PhysicianSignature = claim.PhysicianSignature;
                if (claim.PhysicianSignature.Length > 21)
                    claim.PhysicianSignature = claim.PhysicianSignature.Substring(0, 21);

                var billingDoctorId = _invoice.BillProviderId.Value;

                /*set billing facility NPI by provider identity*/
                var providerIdentity = await this._providerIdentityRepository.GetProviderIdentity(_invoice.BillProviderId.Value, Convert.ToInt16(_primaryConfigHCFAFormFields.PIN), null, "PIN");
                if (providerIdentity != null)
                    claim.BillingFacilityNPI = providerIdentity.Identifier;
                else
                {
                    providerIdentity = await this._providerIdentityRepository.GetProviderIdentity(_invoice.BillProviderId.Value, 1, null, string.Empty);

                    claim.BillingFacilityNPI = providerIdentity.Identifier;
                }

                await FillReserved24(billingDoctorId, claim);

                SetReserved24Npi(claim);
                providerIdentity = await this._providerIdentityRepository.GetProviderIdentity(_invoice.BillProviderId.Value, Convert.ToInt32(_primaryConfigHCFAFormFields.GRP), null, string.Empty);

                if (providerIdentity != null && providerIdentity.Identifier != "")
                {

                    var configIdType = await this._configIdTypeRepository.GetById(Convert.ToInt16(_primaryConfigHCFAFormFields.GRP));
                    //var configIdType = await this._configIdTypeRepository.GetById(14);
                    claim.BillingDoctorIDPrefix = configIdType == null ? "" : configIdType.Prefix;
                    claim.BillingFacilityIDQualifier = configIdType == null ? "" : configIdType.Prefix;
                    //Group = providerIdentity.Identifier;
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task GetFacilityInfoAndFillBillingLines(Claim claim)
        {
            try
            {
                /*set billing doctor address info*/
                _provider = await this._providerRepository.GetById(_invoice.BillProviderId.Value);
                _facility = await this._facilityRepository.GetById(_invoice.BillFacilityId.Value);
                //claim.BillingDoctorPhone = GetAreaContactInfo(_facility.Phone, false);
                claim.BillingDoctorPhone = _facility.Phone;
                claim.BillingDoctorAreaCode = GetAreaContactInfo(_facility.Phone, true);
                claim.BillingDoctorCity = string.IsNullOrEmpty(_provider.City) ? _facility.city : _provider.City;
                claim.BillingDoctorState = string.IsNullOrEmpty(_provider.State) ? _facility.state : _provider.State;
                claim.BillingDoctorAddressLine1 = string.IsNullOrEmpty(_provider.Address1) ? _facility.Address1 : _provider.Address1;
                claim.BillingDoctorAddressLine2 = string.IsNullOrEmpty(_provider.Address1) ? _facility.Address2 : _provider.Address2;
                claim.BillingDoctorZip = string.IsNullOrEmpty(_provider.ZipCode) ? _facility.ZipCode : _provider.ZipCode;
                claim.BillingDoctorFax = _facility.Fax;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ReviewNeeded(List<Guid> guids,bool flagYN,string reviewComments)
        {
            try
            {
                int count = 0;

                List<IValidationCodeResult> ValidationCodeResults = new List<IValidationCodeResult>();
                List<IValidationResult> validationResults = new List<IValidationResult>();

                /*create multiple claim by invoice GUID*/
                var list = guids.Distinct();

                foreach (var item in list)
                {
                    await this._invoiceRepository.UpdateReviewNeeded(item, flagYN, reviewComments);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> RebillDenialChargesWherePrimaryPolicyChanged()
        {

            var list = await this._chargesReportDataRepository.GetDenialChargesForRebillWherePrimaryPolicyChanged();
            list = list.Where(i => !i.CptCode.ToLower().StartsWith("h"));
            list = list.Where(i => !i.CptCode.ToLower().StartsWith("t"));

            List<Guid> invoiceIds = list.Select(i => Guid.Parse(i.InvoiceUId)).ToList();

            await MakeClaim(invoiceIds);

            return true;
        }

        public async Task<bool> RebillDenialChargesWherePayerChanged()
        {
            var list = await this._chargesReportDataRepository.GetChargesForMakeClaims_BilledVsCurrentIns();

            List<Guid> invoiceIds = list.Select(i => Guid.Parse(i.InvoiceUId)).Distinct().ToList();

            await MakeClaim(invoiceIds);

            return true;
        }

        public async Task<bool> PrimaryClaimAutomation()
        {
            var list = await this._chargesRepository.GetAllForMakeClaims();

            List<Guid> invoiceIds = list.Select(i => i.InvoiceUId).Distinct().Take(20).ToList();

            await MakeClaim(invoiceIds);

            return true;
        }

        public async Task<bool> MakeClaim(List<Guid> guids)
        {
            try
            {
                int count = 0;
                List<IValidationCodeResult> ValidationCodeResults = new List<IValidationCodeResult>();
                List<IValidationResult> validationResults = new List<IValidationResult>();

                /*create multiple claim by invoice GUID*/
                var list = guids.Distinct();

                foreach (var item in list)
                {
                    try
                    {
                        count++;
                        var invoice = await this._invoiceRepository.GetByUId(item);
                        var patientCase = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                        _accessionNo = invoice.AccessionNumber;
                        if (invoice != null)
                        {
                            AddClaimInfoDTO addClaimInfoDTO = new AddClaimInfoDTO();
                            addClaimInfoDTO.InvoiceId = invoice.Id;
                            addClaimInfoDTO.PatientCaseId = invoice.PatientCaseId;
                            addClaimInfoDTO.InvoiceUId = invoice.UId;
                            addClaimInfoDTO.PatientCaseUId = patientCase.UId;
                            addClaimInfoDTO.InsuranceLevel = 1;
                            addClaimInfoDTO.Frequency = "1";
                            addClaimInfoDTO.Box10 = string.Empty;
                            addClaimInfoDTO.Box19 = string.Empty;
                            addClaimInfoDTO.Box7 = string.Empty;
                            addClaimInfoDTO.Box80 = string.Empty;
                            addClaimInfoDTO.PatientSignatureDate = DateTime.Now;
                            addClaimInfoDTO.OriginalReferenceNumber = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;

                            /*create claim for single invoice*/
                            await this.CreateClaim(addClaimInfoDTO);
                            if (guids.Distinct().Count() == count)
                                throw new EntityException("errors");
                            _accessionNo = string.Empty;
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

                        if (guids.Distinct().Count() == count && validationResults.Count() > 0)
                        {
                            await this._claimRepository.ThrowError(validationResults);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (guids.Distinct().Count() == count)
                            throw ex;
                    }

                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> MakeClaimForRatherThanSelf(List<Guid> guids)
        {
            try
            {
                int count = 0;
                List<IValidationCodeResult> ValidationCodeResults = new List<IValidationCodeResult>();
                List<IValidationResult> validationResults = new List<IValidationResult>();

                /*create multiple claim by invoice GUID*/
                var list = guids.Distinct();

                foreach (var item in list)
                {
                    string transactionId = this._transactionProvider.StartTransaction(true);
                    try
                    {
                        count++;
                        var invoice = await this._invoiceRepository.GetByUId(item);
                        await this._chargesRepository.UpdateDueByFromSelfRatherThan(invoice.Id);
                        var patientCase = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                        _accessionNo = invoice.AccessionNumber;
                        if (invoice != null)
                        {
                            AddClaimInfoDTO addClaimInfoDTO = new AddClaimInfoDTO();
                            addClaimInfoDTO.InvoiceId = invoice.Id;
                            addClaimInfoDTO.PatientCaseId = invoice.PatientCaseId;
                            addClaimInfoDTO.InvoiceUId = invoice.UId;
                            addClaimInfoDTO.PatientCaseUId = patientCase.UId;
                            addClaimInfoDTO.InsuranceLevel = 1;
                            addClaimInfoDTO.Frequency = "1";
                            addClaimInfoDTO.Box10 = string.Empty;
                            addClaimInfoDTO.Box19 = string.Empty;
                            addClaimInfoDTO.Box7 = string.Empty;
                            addClaimInfoDTO.Box80 = string.Empty;
                            addClaimInfoDTO.PatientSignatureDate = DateTime.Now;
                            addClaimInfoDTO.OriginalReferenceNumber = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;

                            /*create claim for single invoice*/
                            await this.CreateClaim(addClaimInfoDTO);
                            
                            _accessionNo = string.Empty;
                        }
                        this._transactionProvider.CommitTransaction(transactionId);
                    }
                    catch (EntityException ex)
                    {
                        this._transactionProvider.RollbackTransaction(transactionId);
                        if (ex != null && ex.ValidationCodeResult != null && ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors.Count() > 0)
                            foreach (var content in ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors)
                            {
                                content.ErrorMessage += $" for Accession No - {_accessionNo} ";
                                validationResults.Add(content);
                            }

                        if (guids.Distinct().Count() == count && validationResults.Count() > 0)
                        {
                            await this._claimRepository.ThrowError(validationResults);
                        }
                    }
                    catch (Exception ex)
                    {
                        this._transactionProvider.RollbackTransaction(transactionId);
                        if (guids.Distinct().Count() == count)
                            throw ex;
                    }

                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> MakePrimaryClaimWithSecondary(List<Guid> guids)
        {
            try
            {
                int count = 0;
                List<IValidationCodeResult> ValidationCodeResults = new List<IValidationCodeResult>();
                List<IValidationResult> validationResults = new List<IValidationResult>();

                /*create multiple claim by invoice GUID*/
                var list = guids.Distinct();

                foreach (var item in list)
                {
                    try
                    {
                        count++;
                        var invoice = await this._invoiceRepository.GetByUId(item);
                        var patientCase = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                        _accessionNo = invoice.AccessionNumber;
                        var secondaryPolicy= await this._insurancePolicyRepository.GetSecondayPolicy(invoice.PatientCaseId, invoice.BillFromDate);
                        if(secondaryPolicy==null)
                        {
                            continue;
                        }

                        if (invoice != null)
                        {
                            AddClaimInfoDTO addClaimInfoDTO = new AddClaimInfoDTO();
                            addClaimInfoDTO.InvoiceId = invoice.Id;
                            addClaimInfoDTO.PatientCaseId = invoice.PatientCaseId;
                            addClaimInfoDTO.InvoiceUId = invoice.UId;
                            addClaimInfoDTO.PatientCaseUId = patientCase.UId;
                            addClaimInfoDTO.InsuranceLevel = 1;
                            addClaimInfoDTO.Frequency = "1";
                            addClaimInfoDTO.Box10 = string.Empty;
                            addClaimInfoDTO.Box19 = string.Empty;
                            addClaimInfoDTO.Box7 = string.Empty;
                            addClaimInfoDTO.Box80 = string.Empty;
                            addClaimInfoDTO.PatientSignatureDate = DateTime.Now;
                            addClaimInfoDTO.OriginalReferenceNumber = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;
                            addClaimInfoDTO.InsurancePolicyUId = secondaryPolicy.UId;
                            /*create claim for single invoice*/
                            await this.CreateClaim(addClaimInfoDTO);
                            if (guids.Distinct().Count() == count)
                                throw new EntityException("errors");
                            _accessionNo = string.Empty;
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

                        if (guids.Distinct().Count() == count && validationResults.Count() > 0)
                        {
                            await this._claimRepository.ThrowError(validationResults);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (guids.Distinct().Count() == count)
                            throw ex;
                    }

                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> MakeCorrectedClaim(List<int> claimIds)
        {
            try
            {
                int count = 0;
                List<IValidationCodeResult> ValidationCodeResults = new List<IValidationCodeResult>();
                List<IValidationResult> validationResults = new List<IValidationResult>();

                /*create multiple claim by invoice GUID*/
                

                foreach (var item in claimIds)
                {
                    try
                    {
                        count++;

                        var claim = await this._claimRepository.Get(item);
                        if(string.IsNullOrWhiteSpace(claim.PatientControlNumber))
                        {
                            continue;
                        }

                        var invoice = await this._invoiceRepository.GetById(claim.InvoiceId);
                        var patientCase = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                        _accessionNo = invoice.AccessionNumber;
                        if (invoice != null)
                        {
                            AddClaimInfoDTO addClaimInfoDTO = new AddClaimInfoDTO();
                            addClaimInfoDTO.InvoiceId = invoice.Id;
                            addClaimInfoDTO.PatientCaseId = invoice.PatientCaseId;
                            addClaimInfoDTO.InvoiceUId = invoice.UId;
                            addClaimInfoDTO.PatientCaseUId = patientCase.UId;
                            addClaimInfoDTO.InsuranceLevel = 1;
                            addClaimInfoDTO.Frequency = "7";
                            addClaimInfoDTO.Box10 = string.Empty;
                            addClaimInfoDTO.Box19 = string.Empty;
                            addClaimInfoDTO.Box7 = string.Empty;
                            addClaimInfoDTO.Box80 = string.Empty;
                            addClaimInfoDTO.PatientSignatureDate = DateTime.Now;
                            addClaimInfoDTO.OriginalReferenceNumber = claim.PatientControlNumber;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;

                            /*create claim for single invoice*/
                            await this.CreateClaim(addClaimInfoDTO);                            
                            _accessionNo = string.Empty;
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
                        

                    }
                    catch (Exception ex)
                    {
                        
                    }

                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> MakeClaim_Secondary()
        {
            try
            {
                IEnumerable<IInvoice> guids= await this._chargesRepository.GetDataForSecondaryClaims();
                    
                int count = 0;
                List<IValidationCodeResult> ValidationCodeResults = new List<IValidationCodeResult>();
                List<IValidationResult> validationResults = new List<IValidationResult>();

                /*create multiple claim by invoice GUID*/
                var list = guids.Distinct();

                foreach (var invoice in list)
                {
                    try
                    {
                        count++;

                        if(invoice.PrimaryPayerCode=="15202")
                        {
                            continue;
                        }
                        
                        var patientCase = await this._patientCaseRepository.GetById(invoice.PatientCaseId);
                        _accessionNo = invoice.AccessionNumber;
                        if (invoice != null)
                        {
                            AddClaimInfoDTO addClaimInfoDTO = new AddClaimInfoDTO();
                            addClaimInfoDTO.InvoiceId = invoice.Id;
                            addClaimInfoDTO.PatientCaseId = invoice.PatientCaseId;
                            addClaimInfoDTO.InvoiceUId = invoice.UId;
                            addClaimInfoDTO.PatientCaseUId = patientCase.UId;
                            addClaimInfoDTO.InsuranceLevel = 2;
                            addClaimInfoDTO.Frequency = "1";
                            addClaimInfoDTO.Box10 = string.Empty;
                            addClaimInfoDTO.Box19 = string.Empty;
                            addClaimInfoDTO.Box7 = string.Empty;
                            addClaimInfoDTO.Box80 = string.Empty;
                            addClaimInfoDTO.PatientSignatureDate = DateTime.Now;
                            addClaimInfoDTO.OriginalReferenceNumber = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;
                            addClaimInfoDTO.MedicadeResubmissionCode = string.Empty;

                            /*create claim for single invoice*/
                            await this.CreateClaim(addClaimInfoDTO);
                            if (guids.Distinct().Count() == count)
                                throw new EntityException("errors");
                            _accessionNo = string.Empty;
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

                        if (guids.Distinct().Count() == count && validationResults.Count() > 0)
                        {
                            await this._claimRepository.ThrowError(validationResults);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (guids.Distinct().Count() == count)
                            throw ex;
                    }

                }
                return true;
            }
            catch
            {
                throw;
            }
        }


        private async Task FillReferringDoctor(Claim claim)
        {
            try
            {
                /*set referring doctor*/
                var refPhysSet = _invoice.RefDoctorId.HasValue;
                var supervisingPhysSet = _invoice.SupervisingProviderId.HasValue;
                claim.IsLoop2420E = _primaryConfigHCFAFormFields.IsLoop2420E;

                claim.IsLoop2420DRequired = _primaryConfigHCFAFormFields.IsLoop2420D;

                if (_invoice.SupervisingProviderId.HasValue)
                {
                    var supervisionProvider = await this._providerRepository.GetById(_invoice.SupervisingProviderId.Value);
                    claim.SupervisingPhysID = _invoice.SupervisingProviderId;
                    if (supervisionProvider != null)
                    {
                        var supervisionNpi = await this._providerIdentityRepository.GetNPIByProviderId(supervisionProvider.UId);
                        claim.SupervisionDoctorFirstName = supervisionProvider.FirstName;
                        claim.SupervisionDoctorLastName = supervisionProvider.LastName;
                        claim.SupervisionDoctorMiddleName = supervisionProvider.Middle != null ? supervisionProvider.Middle : "";
                        claim.SupervisionDoctorPrefix = supervisionProvider.Prefix != null ? supervisionProvider.Prefix : "";
                        claim.SupervisionDoctorSuffix = supervisionProvider.Suffix != null ? supervisionProvider.Suffix : "";
                        claim.SupervisionDoctorNPI = supervisionNpi != null ? supervisionNpi.Identifier : "";
                    }
                }

                if (_invoice.OrderringProviderId.HasValue)
                {
                    var orderringProviderId = await this._providerRepository.GetById(_invoice.OrderringProviderId.Value);
                    claim.OrderingProviderId = _invoice.SupervisingProviderId;
                    if (orderringProviderId != null)
                    {
                        var orderringProviderNPI = await this._providerIdentityRepository.GetNPIByProviderId(orderringProviderId.UId);
                        claim.OrderingDoctorFirstName = orderringProviderId.FirstName;
                        claim.OrderingDoctorLastName = orderringProviderId.LastName;
                        claim.OrderingDoctorMiddleName = orderringProviderId.Middle != null ? orderringProviderId.Middle : "";
                        claim.OrderingDoctorPrefix = orderringProviderId.Prefix != null ? orderringProviderId.Prefix : "";
                        claim.OrderingDoctorSuffix = orderringProviderId.Suffix != null ? orderringProviderId.Suffix : "";
                        claim.OrderingDoctorNPI = orderringProviderNPI != null ? orderringProviderNPI.Identifier : "";
                    }
                }

                //if(claim.IsLoop2420DRequired.HasValue )
                //{
                //    if(claim.IsLoop2420DRequired.Value)
                //    {
                //        if (_configAppSettingPracticeGenConfig.Count() > 0)
                //        {
                //            var res = _configAppSettingPracticeGenConfig.FirstOrDefault(i => i.SettingCD == "BeaconSupervisionprovider");
                //            if (res != null && res.SettingValue != "0")
                //            {
                //                var supervisionProvider = await this._providerRepository.GetById(Convert.ToInt16(res.SettingValue));
                //                claim.SupervisingPhysID = _invoice.SupervisingProviderId;
                //                if (supervisionProvider != null)
                //                {
                //                    var supervisionNpi = await this._providerIdentityRepository.GetNPIByProviderId(supervisionProvider.UId);
                //                    claim.SupervisionDoctorFirstName = supervisionProvider.FirstName;
                //                    claim.SupervisionDoctorLastName = supervisionProvider.LastName;
                //                    claim.SupervisionDoctorMiddleName = supervisionProvider.Middle != null ? supervisionProvider.Middle : "";
                //                    claim.SupervisionDoctorPrefix = supervisionProvider.Prefix != null ? supervisionProvider.Prefix : "";
                //                    claim.SupervisionDoctorSuffix = supervisionProvider.Suffix != null ? supervisionProvider.Suffix : "";
                //                    claim.SupervisionDoctorNPI = supervisionNpi != null ? supervisionNpi.Identifier : "";
                //                }
                //            }
                //        }
                //    }
                //}

                if (refPhysSet && !_primaryConfigHCFAFormFields.OverrideBox17.Value && _invoice.RefDoctorId > 0)
                {
                    ReferringPhysicianNumber = _invoice.RefDoctorId;

                    _referringDoctor = await this._referringDoctorRepository.GetById(Convert.ToInt16(_invoice.RefDoctorId));
                    if (_referringDoctor != null)
                    {
                        claim.ReferringPhyId = _invoice.RefDoctorId;

                        //claim.ReferringPhyName = _referringDoctor.FullName;
                        claim.ReferringPhyName = _referringDoctor.FullName.Length > 27 ? _referringDoctor.FullName.Substring(0, 27) : _referringDoctor.FullName;
                        claim.ReferringPhysicianNpi = _referringDoctor.NPI;
                        claim.ReferringPhyFirstName = _referringDoctor.FirstName;
                        claim.ReferringPhyLastName = _referringDoctor.LastName;
                        claim.ReferringPhyMI = _referringDoctor.Middle;
                        claim.ReferringPhySuffix = _referringDoctor.Suffix;
                    }
                    else
                    {
                        ReferringPhysicianNumber = null;
                        claim.ReferringPhyId = null;
                        claim.ReferringPhyName = "";
                        claim.ReferringPhyFirstName = "";
                        claim.ReferringPhyLastName = "";
                        claim.ReferringPhyId = null;
                    }


                }
                else
                {
                    claim.ReferringPhyName = "";
                    claim.ReferringPhyFirstName = "";
                    claim.ReferringPhyLastName = "";
                    claim.ReferringPhyId = null;

                }

                if (_primaryConfigHCFAFormFields.AuthNum.HasValue && _invoice.AuthorizationNumberId.HasValue)
                {

                    claim.PhysicianIdOrAuthNo = _patientAuthorization == null ? null : _patientAuthorization.AuthorizationNumber;
                    //claim.PhysicianIdOrAuthNo = _invoice.AuthorizationNumberId.ToString();
                    claim.BillingDoctorIDPrefix = "G1";

                }

                claim.ShowCPTDescripton = _primaryConfigHCFAFormFields.ShowCPTDesc.Value;


                if (claim.ShowCPTDescripton.Value)
                    claim.FLAGS = 1;
                else
                    claim.FLAGS = 0;
            }
            catch
            {
                throw;
            }

        }

        private void SetReserved24Npi(Claim claim)
        {
            if (_primaryConfigHCFAFormFields.GroupNPI.HasValue && _primaryConfigHCFAFormFields.GroupNPI.Value)
            {
                claim.GroupNPI = claim.PerformingFacilityNPI;
            }
            //Reserved24NPI = "";
            //if (_primaryConfigHCFAFormFields.GroupNPI.HasValue && _primaryConfigHCFAFormFields.GroupNPI.Value)
            //    //Reserved24NPI = GroupNPI;

                //else if ((_primaryConfigHCFAFormFields.NPIAlways.Value ||
                //    (_primaryConfigHCFAFormFields.Box31Clinic.Value && claim.BillingFacilityNPI != NPI)))
                //    //Reserved24NPI = NPI;
        }

        private async Task FillSecondary(Claim claim)
        {
            try
            {
                int primaryVsSecondaryLevel = 0;

                if(this._entity.InsurancePolicyUId==Guid.Empty)
                {
                    if (_entity.InsuranceLevel == 1 && _insurancePolicies.Any(i => i.InsuranceLevel == 2))
                    {
                        primaryVsSecondaryLevel = 2;
                    }
                    else if (_entity.InsuranceLevel == 2 && _insurancePolicies.Any(i => i.InsuranceLevel == 1))
                    {
                        primaryVsSecondaryLevel = 1;
                    }
                    else if (_entity.InsuranceLevel == 3 && _insurancePolicies.Any(i => i.InsuranceLevel == 1))
                    {
                        primaryVsSecondaryLevel = 1;
                    }
                    else
                    {
                        return;
                    }
                }    
                else
                {
                    if (_primaryInsurancePolicy.InsuranceLevel == 1 && _insurancePolicies.Any(i => i.InsuranceLevel == 2))
                    {
                        primaryVsSecondaryLevel = 2;
                    }
                    else if (_primaryInsurancePolicy.InsuranceLevel == 2 && _insurancePolicies.Any(i => i.InsuranceLevel == 1))
                    {
                        primaryVsSecondaryLevel = 1;
                    }
                    else if (_primaryInsurancePolicy.InsuranceLevel == 3 && _insurancePolicies.Any(i => i.InsuranceLevel == 1))
                    {
                        primaryVsSecondaryLevel = 1;
                    }
                    else
                    {
                        return;
                    }
                }

                /*fill secondary insurance policy info into claim object*/
                var strBox9AOtherInsuredsPolicyOrGroupNumber = "";
                _secondaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == primaryVsSecondaryLevel);

                if (_secondaryInsurancePolicy == null || !CheckForMedigap())
                {
                    /* We can't do anything if we don't have any further insurances*/
                    AnotherPlan = false;
                    if (_primaryConfigHCFAFormFields.NASecondary.HasValue
                        && _primaryConfigHCFAFormFields.NASecondary.Value)
                    {
                        claim.OtherPolicyHolderName = "NA";
                        claim.OtherPolicyHolderGroupNo = "NA";
                        claim.OtherPolicyHolderDOB = Convert.ToDateTime("01/01/1900");
                        claim.OtherPolicyHolderEmpl = "NA";
                        claim.OtherPolicyInsurancePlanName = "NA";
                    }
                }

                _secondaryInsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(_secondaryInsurancePolicy.PHID);
                if (_secondaryInsurancePolicyHolder.PHRel == string.Empty)
                    await this._insurancePolicyHolderRepository.ThrowError();

                // validating secondary Insurance Policy Holder address details
                await _insurancePolicyHolderRepository.ValidateInsPolicyHolderAddress(Enum.GetName(typeof(InsuranceLevel), InsuranceLevel.Secondary), _secondaryInsurancePolicyHolder.Address1, _secondaryInsurancePolicyHolder.State, _secondaryInsurancePolicyHolder.City, _secondaryInsurancePolicyHolder.Zip);


                _secondaryInsuranceCompany = await this._insuranceCompanyRepository.GetById(_secondaryInsurancePolicy.InsuranceCompanyID);

                var _secondaryInsuranceCompanyType = await this._configInsuranceCompanyTypeRepository.Get(Convert.ToInt16(_secondaryInsuranceCompany.CompanyTypeId));
                _secondaryConfigHCFAFormFields = await this._claimConfigRepository.Get(Convert.ToInt32(_secondaryInsuranceCompany.CompanyTypeId), null, _secondaryInsuranceCompany.Id);

                claim.OtherInsCompanyId = _secondaryInsuranceCompany.Id;
                //claim.OtherInsType = _secondaryInsuranceCompany.CompanyTypeId.ToString();

                if (_secondaryConfigHCFAFormFields != null)
                    claim.OtherInsFillingCode = _secondaryConfigHCFAFormFields.FilingCode;
                if (_secondaryConfigHCFAFormFields != null)
                    claim.OtherInsFillingCode = _secondaryConfigHCFAFormFields.FilingCode;

                if (_secondaryInsuranceCompanyType.CompanyType.Contains("Medicare")
                    && Convert.ToInt16(_secondaryInsurancePolicy.MedicareSecondary) > 0)
                    claim.OtherInsType = Convert.ToString(_secondaryInsurancePolicy.MedicareSecondary);


                claim.OtherInsCompanyId = _secondaryInsuranceCompany.Id;
                // relationShip = _secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self) ? Convert.ToInt32(RelationshipEnum.Self)
                //: (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Spouse) ? Convert.ToInt32(RelationshipEnum.Spouse)
                //: (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Child) ? Convert.ToInt32(RelationshipEnum.Child)
                //: Convert.ToInt32(RelationshipEnum.Other)));

                relationShip = _secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self) ? Convert.ToInt32(RelationshipEnum.Self)
               : (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Spouse) ? Convert.ToInt32(RelationshipEnum.Spouse)
               : (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Child) ? Convert.ToInt32(RelationshipEnum.Child)
               : (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Dependent) ? Convert.ToInt32(RelationshipEnum.Dependent)
               : (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Student) ? Convert.ToInt32(RelationshipEnum.Student)
               : Convert.ToInt32(RelationshipEnum.Other)))));

                claim.OtherPolicyHolderRelation = Convert.ToInt16(relationShip);

                if (_secondaryInsurancePolicy != null && _primaryConfigHCFAFormFields.MSP.Value)
                    FillMedicareSecondaryPayer(claim);
                else
                {
                    claim.HasAnotherPlan = true;
                    if (_primaryConfigHCFAFormFields.Box9a != Convert.ToString(HCFA.Box9aValues.PrimaryInsured)
                        && !_primaryConfigHCFAFormFields.Blank9abcd.Value)
                    {
                        if (_secondaryInsurancePolicy.Medigap && _primaryConfigHCFAFormFields.Box9a == Convert.ToString(HCFA.Box9aValues.Medigap))
                        {

                            strBox9AOtherInsuredsPolicyOrGroupNumber = "";
                            if (!strBox9AOtherInsuredsPolicyOrGroupNumber.Contains("MEDIGAP", StringComparison.CurrentCultureIgnoreCase))
                                strBox9AOtherInsuredsPolicyOrGroupNumber = "MEDIGAP " + strBox9AOtherInsuredsPolicyOrGroupNumber;
                        }

                        if (_primaryConfigHCFAFormFields.Box9aPrefix != "")
                            claim.OtherPolicyHolderGroupNo = _primaryConfigHCFAFormFields.Box9aPrefix + " " + strBox9AOtherInsuredsPolicyOrGroupNumber;
                        else
                            claim.OtherPolicyHolderGroupNo = strBox9AOtherInsuredsPolicyOrGroupNumber;
                    }

                    //claim.OtherPolicyNo = _secondaryInsurancePolicy.PolicyNumber;
                    if (_secondaryInsurancePolicy.InsuranceCompanyName.ToLower().Contains("paramount"))
                    {
                        //claim.OtherPolicyNo = _secondaryInsurancePolicy.PolicyNumber.Length > 27 ? _secondaryInsurancePolicy.PolicyNumber.Substring(0, 27) : _secondaryInsurancePolicy.PolicyNumber;
                        if (this._invoice.BillFromDate > Convert.ToDateTime("1 Feb 2023"))
                        {
                            if (_secondaryInsurancePolicy.MedicaidId != null)
                                claim.OtherPolicyNo = _secondaryInsurancePolicy.MedicaidId.Length > 27 ? _secondaryInsurancePolicy.MedicaidId.Substring(0, 27) : _secondaryInsurancePolicy.MedicaidId;
                        }
                        else
                        {
                            claim.OtherPolicyNo = _secondaryInsurancePolicy.PolicyNumber.Length > 27 ? _secondaryInsurancePolicy.PolicyNumber.Substring(0, 27) : _secondaryInsurancePolicy.PolicyNumber;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(_secondaryInsurancePolicy.MedicaidId))
                        {
                            claim.OtherPolicyNo = _secondaryInsurancePolicy.MedicaidId.Length > 27 ? _secondaryInsurancePolicy.MedicaidId.Substring(0, 27) : _secondaryInsurancePolicy.MedicaidId;
                        }
                        else
                        {
                            claim.OtherPolicyNo = _secondaryInsurancePolicy.PolicyNumber.Length > 27 ? _secondaryInsurancePolicy.PolicyNumber.Substring(0, 27) : _secondaryInsurancePolicy.PolicyNumber;
                        }
                    }

                    //  if (!_primaryConfigHCFAFormFields.Blank9abcd.Value)
                    {
                        if (_primaryConfigHCFAFormFields.Box9dPayorId.Value && _secondaryInsuranceCompany.CompanyCode != "")
                            claim.OtherPolicyInsurancePlanName = _secondaryInsuranceCompany.CompanyCode;
                        else
                        {
                            // this be secondary insurance company address
                            if (_primaryConfigHCFAFormFields.Box9cAddress.Value)
                                claim.OtherPolicyHolderEmpl = _secondaryInsuranceCompany.CompanyAddress1 + " " + _secondaryInsuranceCompany.CompanyState + " " + (_secondaryInsuranceCompany.CompanyZip);

                            else
                                claim.OtherPolicyHolderEmpl = _secondaryInsurancePolicyHolder.OrganizationName;
                            claim.OtherPolicyInsurancePlanName = _secondaryInsurancePolicy.GroupName; // JC_TODO: was "plan name"
                        }
                    }

                    // -disabled this condition by manoj - 04-03-2020  not sure what is that  - if (!_primaryConfigHCFAFormFields.Blank9abcd.Value)
                    {
                        // get policy holder for secondary insurance policy

                        if (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self)
                            && _primaryConfigHCFAFormFields.Box9Same == true)
                            claim.OtherPolicyHolderName = "SAME";
                        else
                            claim.OtherPolicyHolderName = _secondaryInsurancePolicyHolder.LastName + ", " + _secondaryInsurancePolicyHolder.FirstName;



                        claim.OtherPolicyHolderStreet = _secondaryInsurancePolicyHolder.Address1 + " " + _secondaryInsurancePolicyHolder.Address2;
                        claim.OtherPolicyHolderStreet = claim.OtherPolicyHolderStreet.Length > 27 ? claim.OtherPolicyHolderStreet.Substring(0, 27) : claim.OtherPolicyHolderStreet;
                        claim.OtherPolicyHolderCity = _secondaryInsurancePolicyHolder.City;
                        claim.OtherPolicyHolderState = _secondaryInsurancePolicyHolder.State;
                        claim.OtherPolicyHolderZip = _secondaryInsurancePolicyHolder.Zip;

                        if (_secondaryInsurancePolicyHolder.Sex == "M")
                            claim.OtherPolicyHolderSex = 0;
                        if (_secondaryInsurancePolicyHolder.Sex == "F")
                            claim.OtherPolicyHolderSex = 1;

                        if (_secondaryInsurancePolicyHolder.DOB > DateTime.MinValue)
                            claim.OtherPolicyHolderDOB = _secondaryInsurancePolicyHolder.DOB;
                    }

                    /* not sure about below condition - commented by manoj - Apr-3-2020 
                    if (_secondaryInsurancePolicy != null
                        && (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherGroupID)
                        || _primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherInsuranceID)))
                    {
                        if (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherGroupID))
                            claim.PolicyHolderGroupNo = _secondaryInsurancePolicy.GroupNumber;
                        else
                            claim.PolicyHolderGroupNo = _secondaryInsurancePolicy.PolicyNumber;
                        claim.PolicyHolderEmpl = _secondaryInsurancePolicyHolder.OrganizationName;
                        claim.PolicyInsurancePlanName = _secondaryInsurancePolicy.PlanType;
                        claim.PolicyHolderSex = claim.OtherPolicyHolderSex;
                        claim.PolicyHolderDOB = claim.OtherPolicyHolderDOB;
                    }
                    */
                }

                claim.OtherPayerName = _secondaryInsuranceCompany.CompanyName;

                //if (this._invoice.BillFromDate > Convert.ToDateTime("1 Feb 2023"))
                //{
                //    claim.OtherCompanyCode = _secondaryInsuranceCompany.CompanyCode;
                    
                //}
                //else
                //{
                //    claim.OtherCompanyCode = !string.IsNullOrWhiteSpace(_secondaryInsuranceCompany.TempCompanyCode) ? _secondaryInsuranceCompany.TempCompanyCode : _secondaryInsuranceCompany.CompanyCode;
                //}

                claim.OtherCompanyCode = !string.IsNullOrWhiteSpace(_secondaryInsuranceCompany.TempCompanyCode) ? _secondaryInsuranceCompany.TempCompanyCode : _secondaryInsuranceCompany.CompanyCode;

                if (claim.InsLevel==2)
                {                    
                    foreach (var charge in this._invoice.ChargeList)
                    {
                        var paymentCharges = await this._paymentChargeRepository.GetPaymentsByChargeId(charge.Id);
                        if(paymentCharges.Count()>0 && paymentCharges!=null)
                        {
                            var previousPrimaryClaim = await this._claimRepository.GetByInvoiceIdByINSLevel(_invoice.Id, 1);
                            IPaymentCharge payerPayment = null;
                            if (this._invoice.BillFromDate > Convert.ToDateTime("1 Feb 2023"))
                            {
                                payerPayment = paymentCharges.FirstOrDefault(i => i.InsuranceCompanyCode == previousPrimaryClaim.InsuranceCompanyCode);
                            }
                            else
                            {
                                payerPayment = paymentCharges.FirstOrDefault(i =>  i.TempCompanyCode == previousPrimaryClaim.InsuranceCompanyCode);
                                if(payerPayment==null)
                                    payerPayment = paymentCharges.FirstOrDefault(i => i.InsuranceCompanyCode == previousPrimaryClaim.InsuranceCompanyCode);
                            }
                                

                            if (payerPayment == null)
                            {
                                //throw new Exception("Primary payment posted with another payer please correct.");
                                await this._claimRepository.ThrowPrimaryPaymentPostedWithWrongPayer();
                            }
                        }
                        else
                        {
                            //throw new Exception("There is no primary payment for sending with Secondary.");
                            await this._claimRepository.ThrowNoPaymentErrorForSecondary();
                        }
                        
                    }
                }
                

                claim.OtherPolicyHolderSignature = _secondaryInsurancePolicy.PHSignatureOnFile ? "Signature on File" : "";

                DateTime? signDate = Convert.ToDateTime(claim.PatientSignatureDate);
                claim.OtherPatientSignatureOnFile = !signDate.HasValue ? "" : "Signature on File";
            }
            catch
            {
                throw;
            }
        }


        private async Task FillOthers2(Claim claim)
        {
            try
            {
                int primaryVsSecondaryLevel = 0;
                if (_entity.InsuranceLevel == 3 && _insurancePolicies.Any(i => i.InsuranceLevel == 2))
                {
                    primaryVsSecondaryLevel = 2;
                }
                else
                {
                    return;
                }

                /*fill secondary insurance policy info into claim object*/
                var strBox9AOtherInsuredsPolicyOrGroupNumber = "";
                _secondary2InsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == primaryVsSecondaryLevel);

                if (_secondary2InsurancePolicy == null || !CheckForMedigap())
                {
                    /* We can't do anything if we don't have any further insurances*/
                    AnotherPlan = false;
                    if (_primaryConfigHCFAFormFields.NASecondary.HasValue
                        && _primaryConfigHCFAFormFields.NASecondary.Value)
                    {
                        claim.Other2PolicyHolderName = "NA";
                        claim.Other2PolicyHolderGroupNo = "NA";
                        claim.Other2PolicyHolderDOB = Convert.ToDateTime("01/01/1900");
                        claim.Other2PolicyHolderEmpl = "NA";
                        claim.Other2PolicyInsurancePlanName = "NA";
                    }
                }

                _secondary2InsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(_secondary2InsurancePolicy.PHID);
                if (_secondary2InsurancePolicyHolder.PHRel == string.Empty)
                    await this._insurancePolicyHolderRepository.ThrowError();

                // validating secondary Insurance Policy Holder address details
                await _insurancePolicyHolderRepository.ValidateInsPolicyHolderAddress(Enum.GetName(typeof(InsuranceLevel), InsuranceLevel.Secondary), _secondary2InsurancePolicyHolder.Address1, _secondary2InsurancePolicyHolder.State, _secondary2InsurancePolicyHolder.City, _secondary2InsurancePolicyHolder.Zip);


                _secondary2InsuranceCompany = await this._insuranceCompanyRepository.GetById(_secondary2InsurancePolicy.InsuranceCompanyID);

                var _secondaryInsuranceCompanyType = await this._configInsuranceCompanyTypeRepository.Get(Convert.ToInt16(_secondary2InsuranceCompany.CompanyTypeId));
                _secondaryConfigHCFAFormFields = await this._claimConfigRepository.Get(Convert.ToInt32(_secondary2InsuranceCompany.CompanyTypeId), null, _secondary2InsuranceCompany.Id);

                claim.Other2InsCompanyId = _secondary2InsuranceCompany.Id;
                //claim.OtherInsType = _secondaryInsuranceCompany.CompanyTypeId.ToString();

                if (_secondaryConfigHCFAFormFields != null)
                    claim.Other2InsFillingCode = _secondaryConfigHCFAFormFields.FilingCode;
                if (_secondaryConfigHCFAFormFields != null)
                    claim.Other2InsFillingCode = _secondaryConfigHCFAFormFields.FilingCode;

                if (_secondaryInsuranceCompanyType.CompanyType.Contains("Medicare")
                    && Convert.ToInt16(_secondary2InsurancePolicy.MedicareSecondary) > 0)
                    claim.Other2InsType = Convert.ToString(_secondary2InsurancePolicy.MedicareSecondary);


                claim.Other2InsCompanyId = _secondary2InsuranceCompany.Id;
                relationShip = _secondary2InsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self) ? Convert.ToInt32(RelationshipEnum.Self)
               : (_secondary2InsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Spouse) ? Convert.ToInt32(RelationshipEnum.Spouse)
               : (_secondary2InsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Child) ? Convert.ToInt32(RelationshipEnum.Child)
               : Convert.ToInt32(RelationshipEnum.Other)));

                claim.Other2PolicyHolderRelation = Convert.ToInt16(relationShip);

                if (_secondary2InsurancePolicy != null && _primaryConfigHCFAFormFields.MSP.Value)
                    FillMedicareSecondaryPayer(claim);
                else
                {
                    claim.HasAnotherPlan = true;
                    if (_primaryConfigHCFAFormFields.Box9a != Convert.ToString(HCFA.Box9aValues.PrimaryInsured)
                        && !_primaryConfigHCFAFormFields.Blank9abcd.Value)
                    {
                        if (_secondary2InsurancePolicy.Medigap && _primaryConfigHCFAFormFields.Box9a == Convert.ToString(HCFA.Box9aValues.Medigap))
                        {

                            strBox9AOtherInsuredsPolicyOrGroupNumber = "";
                            if (!strBox9AOtherInsuredsPolicyOrGroupNumber.Contains("MEDIGAP", StringComparison.CurrentCultureIgnoreCase))
                                strBox9AOtherInsuredsPolicyOrGroupNumber = "MEDIGAP " + strBox9AOtherInsuredsPolicyOrGroupNumber;
                        }

                        if (_primaryConfigHCFAFormFields.Box9aPrefix != "")
                            claim.Other2PolicyHolderGroupNo = _primaryConfigHCFAFormFields.Box9aPrefix + " " + strBox9AOtherInsuredsPolicyOrGroupNumber;
                        else
                            claim.Other2PolicyHolderGroupNo = strBox9AOtherInsuredsPolicyOrGroupNumber;
                    }

                    //claim.Other2PolicyNo = _secondary2InsurancePolicy.PolicyNumber;
                    if (_secondary2InsurancePolicy.InsuranceCompanyName.ToLower().Contains("paramount"))
                    {
                        //claim.Other2PolicyNo = _secondary2InsurancePolicy.PolicyNumber.Length > 27 ? _secondary2InsurancePolicy.PolicyNumber.Substring(0, 27) : _secondary2InsurancePolicy.PolicyNumber;
                        if (this._invoice.BillFromDate > Convert.ToDateTime("1 Feb 2023"))
                        {
                            if (_secondary2InsurancePolicy.MedicaidId != null)
                                claim.Other2PolicyNo = _secondary2InsurancePolicy.MedicaidId.Length > 27 ? _secondary2InsurancePolicy.MedicaidId.Substring(0, 27) : _secondary2InsurancePolicy.MedicaidId;
                        }
                        else
                        {
                            claim.Other2PolicyNo = _secondary2InsurancePolicy.PolicyNumber.Length > 27 ? _secondary2InsurancePolicy.PolicyNumber.Substring(0, 27) : _secondary2InsurancePolicy.PolicyNumber;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(_secondary2InsurancePolicy.MedicaidId))
                        {
                            claim.Other2PolicyNo = _secondary2InsurancePolicy.MedicaidId.Length > 27 ? _secondary2InsurancePolicy.MedicaidId.Substring(0, 27) : _secondary2InsurancePolicy.MedicaidId;
                        }
                        else
                        {
                            claim.Other2PolicyNo = _secondary2InsurancePolicy.PolicyNumber.Length > 27 ? _secondary2InsurancePolicy.PolicyNumber.Substring(0, 27) : _secondary2InsurancePolicy.PolicyNumber;
                        }
                    }


                    //  if (!_primaryConfigHCFAFormFields.Blank9abcd.Value)
                    {
                        if (_primaryConfigHCFAFormFields.Box9dPayorId.Value && _secondary2InsuranceCompany.CompanyCode != "")
                            claim.Other2PolicyInsurancePlanName = _secondary2InsuranceCompany.CompanyCode;
                        else
                        {
                            // this be secondary insurance company address
                            if (_primaryConfigHCFAFormFields.Box9cAddress.Value)
                                claim.Other2PolicyHolderEmpl = _secondary2InsuranceCompany.CompanyAddress1 + " " + _secondary2InsuranceCompany.CompanyState + " " + (_secondary2InsuranceCompany.CompanyZip);

                            else
                                claim.OtherPolicyHolderEmpl = _secondary2InsurancePolicyHolder.OrganizationName;
                            claim.Other2PolicyInsurancePlanName = _secondary2InsurancePolicy.GroupName; // JC_TODO: was "plan name"
                        }
                    }

                    // -disabled this condition by manoj - 04-03-2020  not sure what is that  - if (!_primaryConfigHCFAFormFields.Blank9abcd.Value)
                    {
                        // get policy holder for secondary insurance policy

                        if (_secondary2InsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self)
                            && _primaryConfigHCFAFormFields.Box9Same == true)
                            claim.Other2PolicyHolderName = "SAME";
                        else
                            claim.Other2PolicyHolderName = _secondary2InsurancePolicyHolder.LastName + ", " + _secondary2InsurancePolicyHolder.FirstName;



                        claim.Other2PolicyHolderStreet = _secondary2InsurancePolicyHolder.Address1 + " " + _secondary2InsurancePolicyHolder.Address2;
                        claim.Other2PolicyHolderStreet = claim.Other2PolicyHolderStreet.Length > 27 ? claim.Other2PolicyHolderStreet.Substring(0, 27) : claim.Other2PolicyHolderStreet;
                        claim.Other2PolicyHolderCity = _secondary2InsurancePolicyHolder.City;
                        claim.Other2PolicyHolderState = _secondary2InsurancePolicyHolder.State;
                        claim.Other2PolicyHolderZip = _secondary2InsurancePolicyHolder.Zip;

                        if (_secondary2InsurancePolicyHolder.Sex == "M")
                            claim.Other2PolicyHolderSex = 0;
                        if (_secondary2InsurancePolicyHolder.Sex == "F")
                            claim.Other2PolicyHolderSex = 1;

                        if (_secondary2InsurancePolicyHolder.DOB > DateTime.MinValue)
                            claim.Other2PolicyHolderDOB = _secondary2InsurancePolicyHolder.DOB;
                    }

                    /* not sure about below condition - commented by manoj - Apr-3-2020 
                    if (_secondaryInsurancePolicy != null
                        && (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherGroupID)
                        || _primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherInsuranceID)))
                    {
                        if (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherGroupID))
                            claim.PolicyHolderGroupNo = _secondaryInsurancePolicy.GroupNumber;
                        else
                            claim.PolicyHolderGroupNo = _secondaryInsurancePolicy.PolicyNumber;
                        claim.PolicyHolderEmpl = _secondaryInsurancePolicyHolder.OrganizationName;
                        claim.PolicyInsurancePlanName = _secondaryInsurancePolicy.PlanType;
                        claim.PolicyHolderSex = claim.OtherPolicyHolderSex;
                        claim.PolicyHolderDOB = claim.OtherPolicyHolderDOB;
                    }
                    */
                }

                claim.Other2PayerName = _secondary2InsuranceCompany.CompanyName;

                //if (this._invoice.BillFromDate > Convert.ToDateTime("1 Feb 2023"))
                //{
                //    claim.Other2CompanyCode = _secondary2InsuranceCompany.CompanyCode;

                //}
                //else
                //{
                //    claim.Other2CompanyCode = !string.IsNullOrWhiteSpace(_secondary2InsuranceCompany.TempCompanyCode) ? _secondary2InsuranceCompany.TempCompanyCode : _secondary2InsuranceCompany.CompanyCode;
                //}

                claim.Other2CompanyCode = !string.IsNullOrWhiteSpace(_secondary2InsuranceCompany.TempCompanyCode) ? _secondary2InsuranceCompany.TempCompanyCode : _secondary2InsuranceCompany.CompanyCode;

                claim.Other2PolicyHolderSignature = _secondary2InsurancePolicy.PHSignatureOnFile ? "Signature on File" : "";

                DateTime? signDate = Convert.ToDateTime(claim.PatientSignatureDate);
                claim.Other2PatientSignatureOnFile = !signDate.HasValue ? "" : "Signature on File";
            }
            catch
            {
                throw;
            }
        }

        //private async Task FillSecondary(Claim claim)
        //{
        //    try
        //    {
        //        /*fill secondary insurance policy info into claim object*/
        //        var strBox9AOtherInsuredsPolicyOrGroupNumber = "";

        //        _secondaryInsurancePolicy = _insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2);


        //        if (_secondaryInsurancePolicy != null && CheckForMedigap())
        //        {
        //            _secondaryInsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(_secondaryInsurancePolicy.PHID);
        //            if (_secondaryInsurancePolicyHolder.PHRel == string.Empty)
        //                await this._insurancePolicyHolderRepository.ThrowError();

        //            // validating secondary Insurance Policy Holder address details
        //            await _insurancePolicyHolderRepository.ValidateInsPolicyHolderAddress(Enum.GetName(typeof(InsuranceLevel), InsuranceLevel.Secondary), _secondaryInsurancePolicyHolder.Address1, _secondaryInsurancePolicyHolder.State, _secondaryInsurancePolicyHolder.City, _secondaryInsurancePolicyHolder.Zip);


        //            _secondaryInsuranceCompany = await this._insuranceCompanyRepository.GetById(_secondaryInsurancePolicy.InsuranceCompanyID);

        //            var _secondaryInsuranceCompanyType = await this._configInsuranceCompanyTypeRepository.Get(Convert.ToInt16(_secondaryInsuranceCompany.CompanyTypeId));
        //            _secondaryConfigHCFAFormFields = await this._claimConfigRepository.Get(Convert.ToInt32(_secondaryInsuranceCompany.CompanyTypeId), null, _secondaryInsuranceCompany.Id);

        //            claim.OtherInsCompanyId = _secondaryInsuranceCompany.Id;
        //            claim.OtherInsType = _secondaryInsuranceCompany.CompanyTypeId.ToString();

        //            if (_secondaryConfigHCFAFormFields != null)
        //                claim.OtherInsFillingCode = _secondaryConfigHCFAFormFields.FilingCode;
        //            if (_secondaryConfigHCFAFormFields != null)
        //                claim.OtherInsFillingCode = _secondaryConfigHCFAFormFields.FilingCode;

        //            if (_secondaryInsuranceCompanyType.CompanyType.Contains("Medicare")
        //                && Convert.ToInt16(_secondaryInsurancePolicy.MedicareSecondary) > 0)
        //                claim.OtherInsType = Convert.ToString(_secondaryInsurancePolicy.MedicareSecondary);


        //            claim.OtherInsCompanyId = _secondaryInsuranceCompany.Id;
        //            relationShip = _secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self) ? Convert.ToInt32(RelationshipEnum.Self)
        //           : (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Spouse) ? Convert.ToInt32(RelationshipEnum.Spouse)
        //           : (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Child) ? Convert.ToInt32(RelationshipEnum.Child)
        //           : Convert.ToInt32(RelationshipEnum.Other)));

        //            claim.OtherPolicyHolderRelation = Convert.ToInt16(relationShip);

        //            if (_secondaryInsurancePolicy != null && _primaryConfigHCFAFormFields.MSP.Value)
        //                FillMedicareSecondaryPayer(claim);
        //            else
        //            {
        //                claim.HasAnotherPlan = true;
        //                if (_primaryConfigHCFAFormFields.Box9a != Convert.ToString(HCFA.Box9aValues.PrimaryInsured)
        //                    && !_primaryConfigHCFAFormFields.Blank9abcd.Value)
        //                {
        //                    if (_secondaryInsurancePolicy.Medigap && _primaryConfigHCFAFormFields.Box9a == Convert.ToString(HCFA.Box9aValues.Medigap))
        //                    {

        //                        strBox9AOtherInsuredsPolicyOrGroupNumber = "";
        //                        if (!strBox9AOtherInsuredsPolicyOrGroupNumber.Contains("MEDIGAP", StringComparison.CurrentCultureIgnoreCase))
        //                            strBox9AOtherInsuredsPolicyOrGroupNumber = "MEDIGAP " + strBox9AOtherInsuredsPolicyOrGroupNumber;
        //                    }
        //                    else
        //                    //switch (_primaryConfigHCFAFormFields.Box9a)
        //                    //{
        //                    //    case (int)HCFA.Box9aValues.InsuredID:
        //                    //        strBox9AOtherInsuredsPolicyOrGroupNumber = _secondaryInsurancePolicy.PolicyNumber;
        //                    //        break;

        //                    //    case (int)HCFA.Box9aValues.GroupNumber:
        //                    //        strBox9AOtherInsuredsPolicyOrGroupNumber = _secondaryInsurancePolicy.PolicyNumber;
        //                    //        break;
        //                    //    case (int)HCFA.Box9aValues.Medigap:
        //                    //        strBox9AOtherInsuredsPolicyOrGroupNumber = _secondaryInsurancePolicy.PolicyNumber;
        //                    //        break;

        //                    //}

        //                    if (_primaryConfigHCFAFormFields.Box9aPrefix != "")
        //                        claim.OtherPolicyHolderGroupNo = _primaryConfigHCFAFormFields.Box9aPrefix + " " + strBox9AOtherInsuredsPolicyOrGroupNumber;
        //                    else
        //                        claim.OtherPolicyHolderGroupNo = strBox9AOtherInsuredsPolicyOrGroupNumber;
        //                }
        //                claim.OtherPolicyNo = _secondaryInsurancePolicy.PolicyNumber;

        //                if (!_primaryConfigHCFAFormFields.Blank9abcd.Value)
        //                {
        //                    if (_primaryConfigHCFAFormFields.Box9dPayorId.Value && _secondaryInsuranceCompany.CompanyCode != "")
        //                        claim.OtherPolicyInsurancePlanName = _secondaryInsuranceCompany.CompanyCode;
        //                    else
        //                    {
        //                        // this be secondary insurance company address
        //                        if (_primaryConfigHCFAFormFields.Box9cAddress.Value)
        //                            claim.OtherPolicyHolderEmpl = _secondaryInsuranceCompany.CompanyAddress1 + " " + _secondaryInsuranceCompany.CompanyState + " " + (_secondaryInsuranceCompany.CompanyZip);

        //                        else
        //                            claim.OtherPolicyHolderEmpl = _secondaryInsurancePolicyHolder.OrganizationName;
        //                        claim.OtherPolicyInsurancePlanName = _secondaryInsurancePolicy.GroupName; // JC_TODO: was "plan name"
        //                    }
        //                }
        //                if (!_primaryConfigHCFAFormFields.Blank9abcd.Value)
        //                {
        //                    // get policy holder for secondary insurance policy

        //                    if (_secondaryInsurancePolicy.PHRelationshipToPatient == Convert.ToString(RelationshipEnum.Self)
        //                        && _primaryConfigHCFAFormFields.Box9Same == true)
        //                        claim.OtherPolicyHolderName = "SAME";
        //                    else
        //                        claim.OtherPolicyHolderName = _secondaryInsurancePolicyHolder.LastName + ", " + _secondaryInsurancePolicyHolder.FirstName;


        //                    claim.OtherPolicyHolderStreet = _secondaryInsurancePolicyHolder.Address1 + " " + _secondaryInsurancePolicyHolder.Address2;
        //                    claim.OtherPolicyHolderStreet = claim.OtherPolicyHolderStreet.Length > 27 ? claim.OtherPolicyHolderStreet.Substring(0, 27) : claim.OtherPolicyHolderStreet;
        //                    claim.OtherPolicyHolderCity = _secondaryInsurancePolicyHolder.City;
        //                    claim.OtherPolicyHolderState = _secondaryInsurancePolicyHolder.State;
        //                    claim.OtherPolicyHolderZip = _secondaryInsurancePolicyHolder.Zip;

        //                    if (_secondaryInsurancePolicyHolder.Sex == "M")
        //                        claim.OtherPolicyHolderSex = 0;
        //                    if (_secondaryInsurancePolicyHolder.Sex == "F")
        //                        claim.OtherPolicyHolderSex = 1;

        //                    if (_secondaryInsurancePolicyHolder.DOB > DateTime.MinValue)
        //                        claim.OtherPolicyHolderDOB = _secondaryInsurancePolicyHolder.DOB;
        //                }
        //                if (_secondaryInsurancePolicy != null
        //                    && (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherGroupID)
        //                    || _primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherInsuranceID)))
        //                {
        //                    if (_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.OtherGroupID))
        //                        claim.PolicyHolderGroupNo = _secondaryInsurancePolicy.GroupNumber;
        //                    else
        //                        claim.PolicyHolderGroupNo = _secondaryInsurancePolicy.PolicyNumber;
        //                    claim.PolicyHolderEmpl = _secondaryInsurancePolicyHolder.OrganizationName;
        //                    claim.PolicyInsurancePlanName = _secondaryInsurancePolicy.PlanType;
        //                    claim.PolicyHolderSex = claim.OtherPolicyHolderSex;
        //                    claim.PolicyHolderDOB = claim.OtherPolicyHolderDOB;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            AnotherPlan = false;
        //            if (_primaryConfigHCFAFormFields.NASecondary.HasValue
        //                && _primaryConfigHCFAFormFields.NASecondary.Value)
        //            {
        //                claim.OtherPolicyHolderName = "NA";
        //                claim.OtherPolicyHolderGroupNo = "NA";
        //                claim.OtherPolicyHolderDOB = Convert.ToDateTime("01/01/1900");
        //                claim.OtherPolicyHolderEmpl = "NA";
        //                claim.OtherPolicyInsurancePlanName = "NA";
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        private bool CheckForMedigap()
        {
            if (_primaryConfigHCFAFormFields.MedigapOnly.HasValue
                && _primaryConfigHCFAFormFields.MedigapOnly.Value)
                return _secondaryInsurancePolicy.Medigap;
            else
                return false;
        }

        private async Task FillReserved24(short billingDoctorId, Claim claim)
        {
            try
            {
                string idValue = "";
                var providerIdType = _primaryConfigHCFAFormFields.Box24 ?? 1;
                var result = await this._providerIdentityRepository.GetProviderIdentity(_invoice.BillProviderId.Value, providerIdType, null, string.Empty);
                if (result != null)
                    idValue = result.Identifier;

                if (_primaryConfigHCFAFormFields.NumberOnly.HasValue && _primaryConfigHCFAFormFields.NumberOnly.Value)
                    idValue = idValue.Replace("\\D", "");
                else
                    idValue = Regex.Replace(idValue, "[- ]", "");

                claim.PhysicianIdOrAuthNo = idValue;
                if (providerIdType > 0)
                {
                    var configIdType = await this._configIdTypeRepository.GetById(providerIdType);
                    if (configIdType != null)
                    {
                        claim.BillingDoctorIDPrefix = configIdType.Prefix;
                        claim.BillingFacilityIDQualifier = configIdType.Prefix;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void FillMedicareSecondaryPayer(Claim claim)
        {
            if (_secondaryInsurancePolicy != null && _primaryConfigHCFAFormFields.MSP.Value)
                claim.HasAnotherPlan = true;
            if (Level == 1)
            {
                if (_primaryInsurancePolicy.PHRelationshipToPatient == RelationshipEnum.Self.ToString())
                    claim.PolicyHolderName = "SAME";
                else
                {
                    claim.PolicyHolderName = _insurancePolicy.PHLastName + ", " + _insurancePolicy.PHFirstName;
                    if (_primaryConfigHCFAFormFields.MSP.Value || !((_primaryConfigHCFAFormFields.Box11 == Convert.ToString(HCFA.Box11Values.None))
                        && _primaryConfigHCFAFormFields.Blank11abc.Value))
                    {
                        if (_insurancePolicyHolder.Sex == "M")
                            claim.PolicyHolderSex = 0;
                        if (_insurancePolicyHolder.Sex == "F")
                            claim.PolicyHolderSex = 1;
                        claim.PolicyHolderDOB = Convert.ToDateTime(_insurancePolicyHolder.DOB);
                    }
                }
                claim.PolicyHolderCity = _insurancePolicyHolder.City;
                claim.PolicyHolderState = _insurancePolicyHolder.State;
                claim.PolicyHolderZip = _insurancePolicyHolder.Zip;

                if (_insurancePolicyHolder.HomePhone != null)
                    claim.PolicyHolderPhone = _insurancePolicyHolder.HomePhone.ToString();

                claim.PolicyHolderGroupNo = _insurancePolicy.PolicyNumber;
                claim.PolicyHolderEmpl = _insurancePolicyHolder.FirstName;
                claim.PolicyInsurancePlanName = _insurancePolicy.PlanType;
            }
        }

        private async Task FillServiceTotals(decimal decTotalAmountBilled, IChargeTotal chargeTotal,
                                             short intPageNumber, bool blnHasLab,
                                             short? billingProvider, Claim claim, Charges charge = null)
        {
            try
            {
                decimal decBalanceDue = 0.0M;
                int intFlags = 0;
                decimal decLabCharges = 0.0M;
                string strReserved19 = string.Empty;
                string strMedicaidResubmissionCode = string.Empty;

                short intNumKind = 0;
                string strPriorAuthorizationNumber = string.Empty;
                decimal decTotalPaid = 0.0M;
                ClaimTotal claimTotal = new ClaimTotal();

                decTotalAmountBilled += chargeTotal.TotalCharges;
                if (_primaryConfigHCFAFormFields.AmtPaid != Convert.ToInt32(HCFA.Box29AmtPaidValues.Blank))
                    decTotalPaid = chargeTotal.TotalPaid;
                if (!_primaryConfigHCFAFormFields.BlankBalance.Value)
                    decBalanceDue = chargeTotal.TotalCharges - chargeTotal.TotalPaid - chargeTotal.TotalWriteOff;


                strPriorAuthorizationNumber = await SetPriorAuthorization(blnHasLab, billingProvider, intNumKind, strPriorAuthorizationNumber, claim, charge);
                claim.PriorAuthorizationNumber = strPriorAuthorizationNumber;
                if (_primaryConfigHCFAFormFields.HideDecimalPt.Value)
                    intFlags = 1;

                //chargeTotal.TotalCharges = Convert.ToDecimal(string.Format("{0:0.00}", chargeTotal.TotalCharges));

                claimTotal.TotalCharges = chargeTotal.TotalCharges;
                claimTotal.ClaimId = 0;
                claimTotal.PageNumber = intPageNumber;
                claimTotal.LabCharges = decLabCharges;
                claimTotal.AmountPaid = decTotalPaid;
                claimTotal.BalanceDue = decBalanceDue;
                claimTotal.OutsideLab = blnHasLab;
                claimTotal.Reserved19 = strReserved19;
                claimTotal.MedicaidResubmissionCode = claim.MedicaidResubmissionCode;
                claimTotal.OriginalReferenceNumber = claim.OriginalReferenceNumber;
                claimTotal.NumKind = intNumKind;
                claimTotal.PriorAuthorizationNumber = strPriorAuthorizationNumber;
                claimTotal.Flags = (int)intFlags;
                claimsTotal.Add(claimTotal);
            }
            catch
            {
                throw;
            }
        }

        public bool SetAdditionalClaimInformationForInsuranceAnalysis()
        {
            bool blnUserCancelled = false;
            Frequency = FrequencyEnum.Original.ToString();
            Reserved10 = "";
            SignDate = DateTime.Now;
            OriginalReferenceNumber = "";

            return blnUserCancelled;
        }

        private async Task<string> SetPriorAuthorization(bool blnHasLab, short? billingProvider, short intNumKind, string strPriorAuthorizationNumber, Claim claim, ICharges charge = null)
        {
            try
            {
                /*set prior authorization number*/
                if (blnHasLab || _primaryConfigHCFAFormFields.LabOnly == false)
                {
                    intNumKind = -1;

                    var providerIdentity = await this._providerIdentityRepository.GetProviderIdentity(_invoice.BillProviderId.Value, Convert.ToInt32(_primaryConfigHCFAFormFields.Box23), null, string.Empty);
                    /*set prior AuthorizationNumber claim is making for CMS1500. it would be set from provider identity
                     if claim is for UB04. it would be set from Facility clia number. */
                    if (_configAppSettingClaimFormType.SettingValue.ToLower() == "CMS1500".ToLower())
                    {
                        if (providerIdentity != null)
                        {
                            strPriorAuthorizationNumber = providerIdentity.Identifier;
                        }
                    }
                    else
                    {
                        if (_invoice.ChargeList.FirstOrDefault() != null)
                        {
                            var identifier = await GetFacilityId(_invoice.ChargeList.FirstOrDefault().PerformingFacilityId.Value, cliaNumber);
                            if (identifier != null)
                                strPriorAuthorizationNumber = identifier.Identifier;

                        }
                    }
                }
                else if (_configAppSettingClaimFormType.SettingValue.ToLower() == "UB04".ToLower())
                {
                    if (_invoice.ChargeList.FirstOrDefault() != null)
                    {


                        var identifier = await GetFacilityId(_invoice.ChargeList.FirstOrDefault().PerformingFacilityId.Value, cliaNumber);
                        if (identifier != null)
                            strPriorAuthorizationNumber = identifier.Identifier;

                    }
                }

                if (isReferringLab)
                {
                    var res = await GetFacilityId(_invoice.BillFacilityId.Value, cliaNumber);
                    claim.ReferCliaNumber = res.Identifier;

                }
                else
                    claim.ReferCliaNumber = null;
                return strPriorAuthorizationNumber;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// GetAreaCodeByPhoneNumber
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="isArea"></param>
        /// <returns>returnCodeorPhoneNumber</returns>
        private string GetAreaContactInfo(string phoneNumber, bool isArea)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
                if (!isArea)
                    return new string(phoneNumber.Trim(unnecessaryPhoneCharacters).Take(3).ToArray());
                else
                    return new string(phoneNumber.Trim(unnecessaryPhoneCharacters).Skip(3).ToArray());
            else
                return null;
        }

        public async Task<int> CreateBatchAuto(string uids)
        {
            var list = uids.Split(',');
            var splitUIds = list.Select(Guid.Parse).ToList();
            var result = await this._claimRepository.Get(splitUIds);

            var transactionNumbers = result.Where(i => i.TransactionNumber.HasValue && !string.IsNullOrWhiteSpace(i.TransactionNumber.Value.ToString()));
            var distinctTransactionNumbers = transactionNumbers.Select(i => i.TransactionNumber).Distinct();
            if (transactionNumbers.Count() != distinctTransactionNumbers.Count())
            {
                throw new Exception("There are duplicate claims with selected rows, please deselect the same or contact to admin.");
            }


            List<string> medicaidClaims = result.Where(i => i.CarrierTypeId == 4).Select(i => i.UId.ToString()).ToList();
            if(medicaidClaims.Count()>0)
            {
                await CreateBatchMadicaid(medicaidClaims);
            }

            List<string> nonMedicaidClaims = result.Where(i => i.CarrierTypeId != 4).Select(i => i.UId.ToString()).ToList();
            if (nonMedicaidClaims.Count() > 0)
            {
                await CreateBatchNonMedicaid(nonMedicaidClaims);
            }

            return 1;
        }

        public async Task<int> CreateBatchMadicaid(List<string> medicaidClaims)
        {
            try
            {
                //var list = uids.Split(',');
                var splitUIds = medicaidClaims.Select(Guid.Parse).ToList();
                var result = await this._claimRepository.Get(splitUIds);

                int[] insCompanyIds = result.Select(i => i.InsuranceCompanyId).Distinct().ToArray();

                foreach (var insuranceCompanyId in insCompanyIds)
                {
                    int?[] performingProviders = result.Where(i => i.InsuranceCompanyId == insuranceCompanyId).Select(i => i.PerformingDoctorId).Distinct().ToArray();
                    foreach (var provider in performingProviders)
                    {
                        int[] claimIds = result.Where(i => i.InsuranceCompanyId == insuranceCompanyId && i.PerformingDoctorId== provider).Select(i => i.Id).ToArray();
                        IEnumerable<ICharges> claimCharges = await this._claimChargeRepository.GetByClaim(claimIds);

                        var results = result.Where(i => i.InsuranceCompanyId == insuranceCompanyId && i.PerformingDoctorId == provider).Select(x => new
                        {
                            x.ClearingHouseId,
                            x.TotalBilled,
                            x.CreatedDate
                        }).GroupBy(i => new
                        {
                            i.ClearingHouseId
                        }).Select(i => new ClaimBatch
                        {
                            ClearingHouseId = i.Key.ClearingHouseId,
                            Total = Convert.ToDecimal(i.Sum(y => y.TotalBilled)),
                            FromDate = i.Min(y => y.CreatedDate),
                            ToDate = i.Max(y => y.CreatedDate),
                            ClaimCount = i.Count()
                            //ClearingHouseId = i.Key.ClearingHouseId,
                            //TotalBilled = i.Sum(j => j.TotalBilled),
                            //Count = i.Count(),

                        });

                        var newRecord = await this._claimBatchRepository.AddNew(results, provider, insuranceCompanyId);

                        string claimTempIds = "";
                        foreach (var item in claimIds)
                        {
                            var claimViceCharges = claimCharges.Where(i => i.ClaimId == item && i.IsDeleted==false);
                            // int[] ChargesIds = claimViceCharges.Select(i => i.ChargeId).ToArray();
                            if(claimViceCharges.Count()==0)
                            {
                                claimTempIds += item.ToString();
                                continue;
                            }                            

                            await this._actionNoteRepository.CreateObject(0, claimViceCharges, item, "Batch added (#" + newRecord.FirstOrDefault().Id + ") ");
                        }

                        foreach (var item in newRecord)
                        {
                            var records = result.Where(i => i.ClearingHouseId == item.ClearingHouseId && i.InsuranceCompanyId == insuranceCompanyId && i.PerformingDoctorId == provider);
                            await this._claimRepository.Update(records, item.Id);
                        }
                    }                    
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CreateBatchNonMedicaid(List<string> nonmedicaidClaims)
        {
            try
            {
                //var list = uids.Split(',');
                var splitUIds = nonmedicaidClaims.Select(Guid.Parse).ToList();
                var result = await this._claimRepository.Get(splitUIds);

                //int[] insCompanyIds = result.Select(i => i.InsuranceCompanyId).Distinct().ToArray();
                //if(insCompanyIds.Count()>1)
                //{
                //    await this._claimRepository.ThrowClaimBatchInsuranceCompany();
                //}

                int[] claimIds = result.Select(i => i.Id).ToArray();
                IEnumerable<ICharges> claimCharges = await this._claimChargeRepository.GetByClaim(claimIds);

                var results = result.Select(x => new
                {
                    x.ClearingHouseId,
                    x.TotalBilled,
                    x.CreatedDate
                }).GroupBy(i => new
                {
                    i.ClearingHouseId
                }).Select(i => new ClaimBatch
                {
                    ClearingHouseId = i.Key.ClearingHouseId,
                    Total = Convert.ToDecimal(i.Sum(y => y.TotalBilled)),
                    FromDate = i.Min(y => y.CreatedDate),
                    ToDate = i.Max(y => y.CreatedDate),
                    ClaimCount = i.Count()
                    //ClearingHouseId = i.Key.ClearingHouseId,
                    //TotalBilled = i.Sum(j => j.TotalBilled),
                    //Count = i.Count(),

                });

                var newRecord = await this._claimBatchRepository.AddNew(results);

                foreach (var item in claimIds)
                {
                    var claimViceCharges = claimCharges.Where(i => i.ClaimId == item);
                    // int[] ChargesIds = claimViceCharges.Select(i => i.ChargeId).ToArray();

                    await this._actionNoteRepository.CreateObject(0, claimViceCharges, item, "Batch added (#" + newRecord.FirstOrDefault().Id + ") ");
                }

                foreach (var item in newRecord)
                {
                    var records = result.Where(i => i.ClearingHouseId == item.ClearingHouseId);
                    await this._claimRepository.Update(records, item.Id);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CreateBatch(string uids)
        {
            try
            {
                var list = uids.Split(',');
                var splitUIds = list.Select(Guid.Parse).ToList();
                var result = await this._claimRepository.Get(splitUIds);

                //int[] insCompanyIds = result.Select(i => i.InsuranceCompanyId).Distinct().ToArray();
                //if(insCompanyIds.Count()>1)
                //{
                //    await this._claimRepository.ThrowClaimBatchInsuranceCompany();
                //}

                int[] claimIds = result.Select(i => i.Id).ToArray();
                IEnumerable<ICharges> claimCharges = await this._claimChargeRepository.GetByClaim(claimIds);

                var results = result.Select(x => new
                {
                    x.ClearingHouseId,
                    x.TotalBilled,
                    x.CreatedDate
                }).GroupBy(i => new
                {
                    i.ClearingHouseId
                }).Select(i => new ClaimBatch
                {
                    ClearingHouseId = i.Key.ClearingHouseId,
                    Total = Convert.ToDecimal(i.Sum(y => y.TotalBilled)),
                    FromDate = i.Min(y => y.CreatedDate),
                    ToDate = i.Max(y => y.CreatedDate),
                    ClaimCount = i.Count()
                    //ClearingHouseId = i.Key.ClearingHouseId,
                    //TotalBilled = i.Sum(j => j.TotalBilled),
                    //Count = i.Count(),

                });

                var newRecord = await this._claimBatchRepository.AddNew(results);

                foreach (var item in claimIds)
                {
                    var claimViceCharges = claimCharges.Where(i => i.ClaimId == item);
                    // int[] ChargesIds = claimViceCharges.Select(i => i.ChargeId).ToArray();

                    await this._actionNoteRepository.CreateObject(0, claimViceCharges, item, "Batch added (#" + newRecord.FirstOrDefault().Id + ") ");
                }

                foreach (var item in newRecord)
                {
                    var records = result.Where(i => i.ClearingHouseId == item.ClearingHouseId);
                    await this._claimRepository.Update(records, item.Id);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete claim by claimUId
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public async Task<int> Delete(Guid uId)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var _claim = await this._claimRepository.GetByUID(uId);
                if(_claim.SentDate.HasValue)
                {
                    await this._claimRepository.ClaimIsInUse();
                }

                /*claim can be delete only if claim is not batched and not sent*/
                //if (_claim.ClaimBatchId == null && _claim.SentDate == null)
                //{
                int[] claimIds = { _claim.Id };
                IEnumerable<ICharges> claimCharges = await this._claimChargeRepository.GetByClaim(claimIds);
                await this._claimChargeRepository.DeleteByClaimId(_claim.Id);
                await this._claimTotalRepository.DeleteByClaimId(_claim.Id);

                // int[] ChargesIds = claimCharges.Select(i => i.ChargeId).ToArray();
                await this._actionNoteRepository.CreateObject(_claim.PatientCaseId, claimCharges, _claim.Id, "Claim deleted (#" + _claim.Id + ") ");
                int[] claimId = { _claim.Id };
                await this._actionNoteRepository.UpdateClaim(claimId);

                

                var _claimData = await this._claimRepository.GetByInvoiceIdNoDeleteClaims(_claim.InvoiceId,_claim.Id);

                var _invoice = await this._invoiceRepository.GetById(_claim.InvoiceId);
                if (_invoice != null)
                {
                    _invoice.ClaimId = _claimData == null ? null : (int?)_claimData.Id;
                    await this._invoiceRepository.UpdateClaimId(_invoice);
                }

                await this._claimRepository.Delete(_claim.Id);


                //}
                ///*throw exception if claim is in use.*/
                //else
                //    await this._claimRepository.ClaimIsInUse();
                this._transactionProvider.CommitTransaction(transactionId);
                return 1;

            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> UnBatchClaim(IClaim entity)
        {
            try
            {
                int? claimBatchId = entity.ClaimBatchId;
                await this._claimRepository.UnBatchClaim(entity);

                var claims = await this._claimRepository.GetClaims(claimBatchId.Value);
                if (claims.Count() == 0)
                    await this._claimBatchRepository.Delete(claimBatchId.Value);
                else
                    await this._claimBatchRepository.UpdateClaimCountByid(claimBatchId.Value, claims.Count());

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UnBatchClaims(Guid claimBatchUId)
        {
            try
            {
                await this._claimRepository.UnBatchClaims(claimBatchUId);

                var claims = await this._claimRepository.GetByBatchUId(claimBatchUId);
                if (claims.Count() == 0)
                    await this._claimBatchRepository.Delete(claimBatchUId);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaimAckDTO>> GetForACK()
        {
            var list= await this._claimRepository.GetForACK();

            list = list.Where(i => !string.IsNullOrWhiteSpace(i.AccessionNumber));

            int[] claimIds = list.Select(i => i.Id).Distinct().ToArray();

            if(claimIds.Count()==0)
            {
                return null;
            }
            IEnumerable<ICharges> charges = await this._claimChargeRepository.GetByClaim(claimIds);


            List<IEMRChargeStatus> lstEmrStatus = new List<IEMRChargeStatus>();
            foreach (var item in list)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(item.AccessionNumber))
                    {
                        await this._claimRepository.UpdateClaimAfterNotifyRevdx(item.Id);
                        continue;
                    }
                    if (item.AccessionNumber.Contains("-"))
                    {
                        await this._claimRepository.UpdateClaimAfterNotifyRevdx(item.Id);
                        continue;
                    }
                    if (item.AccessionNumber.Contains("."))
                    {
                        await this._claimRepository.UpdateClaimAfterNotifyRevdx(item.Id);
                        continue;
                    }
                    EMRChargeStatus obj = new EMRChargeStatus();
                    obj.BillingId = Convert.ToInt32(item.AccessionNumber);
                    obj.ChargeId = item.InvoiceId;
                    //obj.ClaimAmount = item.TotalBilled;
                    obj.ClaimAmount = (double)charges.Where(i => i.ClaimId == item.Id).Sum(i => i.Amount);
                    obj.ClaimId = item.Id;
                    obj.ClaimSentDate = item.SentDate;
                    lstEmrStatus.Add(obj);
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
            if(list.Count()>0)
            {
                await this._patientRepository.SendClaimSentAcknowledgementToEMR(lstEmrStatus);
                await this.UpdateClaimsListAfterNotifyToEMR(lstEmrStatus);
            }            

            return null;
        }

        public async Task<int> UpdateClaimAfterNotifyRevdx(long id)
        {
            return await this._claimRepository.UpdateClaimAfterNotifyRevdx(id);
        }

        private async Task<bool> UpdateClaimsListAfterNotifyToEMR(IEnumerable<IEMRChargeStatus> lst)
        {

            foreach (EMRChargeStatus item in lst)
            {
                await this._claimRepository.UpdateClaimAfterNotifyRevdx(item.ClaimId.Value);
            }
            return true;
        }

        public async Task<int> CreateBatchAutomtion()
        {
            var clearingHouses = await this._clearingHouseRepository.Get();
            foreach (var item in clearingHouses.Where(i => i.Id != 2))
            {
                var result = await this._claimRepository.GetClaimsForAutomation(item.Id);

                List<string> medicaidClaims = result.Where(i => i.CarrierTypeId == 4).Select(i => i.UId.ToString()).ToList();
                if (medicaidClaims.Count() > 0)
                {
                    await CreateBatchMadicaid(medicaidClaims);
                }

                List<string> nonMedicaidClaims = result.Where(i => i.CarrierTypeId != 4).Select(i => i.UId.ToString()).ToList();
                if (nonMedicaidClaims.Count() > 0)
                {
                    await CreateBatchNonMedicaid(nonMedicaidClaims);
                }
            }

            return 1;
        }

        public async Task<int> RunBatchScrubForAutomtion(int clearingHouseId)
        {
            var claimBatchs=await this._claimBatchRepository.GetClaimBatchForAutoRunScrub(clearingHouseId);
            foreach (var item in claimBatchs)
            {
                try
                {
                    await this._claimBatchRepository.RunScrub("", item.UId.ToString(), "", "");
                }
                catch (Exception)
                {

                    
                }                
            }

            return 1;
        }


    }
}
