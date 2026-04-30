using AutoMapper;
using Microsoft.Extensions.Logging;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.CommonEntites;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Model;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class ChargeInvoiceService : IChargeInvoiceService
    {
        private readonly ITransactionProvider _transactionProvider;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        private readonly IChargesRepository _chargesRepository;
        private readonly IInvDiagnosisRepository _invDiagnosisRepository;
        private readonly IDefaultReasonCodeRepository _defaultReasonCodeRepository;
        private readonly IChargeBatchRepository _chargeBatchRepository;
        private readonly IPaymentChargeRepository _paymentChargeRepository;
        private readonly IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        private readonly IPatientCaseRepository _patientCaseRepository;
        private readonly ICPTCodeRepository _cPTCodeRepository;
        public readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IDrugChargeRepository _drugChargeRepository;
        private readonly IConfigDrugClassRepository _configDrugClassRepository;
        private readonly IPaymentRemarkCodeRepository _paymentRemarkCodeRepository;
        private readonly IFeeScheduleService _feeScheduleService;
        private readonly IClaimChargeRepository _claimChargeRepository;
        private readonly IPatientStatementRepository _patientStatementRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IReferringDoctorRepository _referringDoctorRepository;
        private readonly ICPTModifierRepository _cPTModifierRepository;
        private readonly IICDCodeRepository _iCDCodeRepository;
        private readonly IPatientAuthorizationNumberRepository _patientAuthorizationNumberRepository;
        private readonly INDCRepository _nDCRepository;
        private readonly IFSChargeRepository _fsChargeRepository;
        private readonly IFeeScheduleRepository _feeScheduleRepository;
        private readonly IClaimTotalRepository _claimTotalRepository;
        private readonly IClaimRepository _claimRepository;
        private readonly IConfigERARemarkCodesRepository _configERARemarkCodesRepository;
        private readonly IActionNoteRepository _actionNoteRepository;
        private readonly IChargeScrubRepository _chargeScrubRepository;
        private readonly IProviderIdentityRepository _providerIdentityRepository;
        private readonly IEncounterRulesRepository _encounterRulesRepository;
        private readonly IEncounterRulesAllowedPOSRepository _encounterRulesAllowedPOSRepository;
        private readonly IEncounterRulesAllowedCPTRepository _encounterRulesAllowedCPTRepository;
        private readonly IChargeInWriteOffRepository _chargeInWriteOffRepository;
        private readonly IERAClaimRepository _iERAClaimRepository;
        private readonly IPracticeRepository _practiceRepository;
        private readonly IProviderFacilityValidtionRepository _providerFacilityValidtionRepository;

        private readonly IDynmoPaymentsRepository _dynmoPaymentsRepository;

        private readonly IPortalPaymentRepository _portalPaymentRepository;

        private readonly ILogger _logger;

        public ChargeInvoiceService(ITransactionProvider transactionProvider,
                                    IInvoiceRepository invoiceRepository,
                                    IChargesRepository chargesRepository,
                                    IInvDiagnosisRepository invDiagnosisRepository,
                                    IDefaultReasonCodeRepository defaultReasonCodeRepository,
                                    IChargeBatchRepository chargeBatchRepository,
                                    IVoucherRepository voucherRepository,
                                    IPaymentRepository paymentRepository,
                                    IInsurancePolicyRepository insurancePolicyRepository,
                                    IPaymentChargeRepository paymentChargeRepository,
                                    IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                    IPatientCaseRepository patientCaseRepository,
                                    IPatientRepository patientRepository,
                                    IInsuranceCompanyRepository insuranceCompanyRepository,
                                    ICPTCodeRepository cPTCodeRepository,
                                    IDrugChargeRepository drugChargeRepository,
                                    IConfigDrugClassRepository configDrugClassRepository,
                                    IPaymentRemarkCodeRepository paymentRemarkCodeRepository,
                                    IFeeScheduleService feeScheduleService,
                                    IClaimChargeRepository claimChargeRepository,
                                    IFacilityRepository facilityRepository,
                                    IReferringDoctorRepository referringDoctorRepository,
                                    IProviderRepository providerRepository,
                                    ICPTModifierRepository cPTModifierRepository,
                                    IPatientStatementRepository patientStatementRepository,
                                    INDCRepository nDCRepository,
                                    IPatientAuthorizationNumberRepository patientAuthorizationNumberRepository,
                                    IMapper mapper,
                                    IICDCodeRepository iCDCodeRepository,
                                    IFSChargeRepository fsChargeRepository,
                                    IFeeScheduleRepository feeScheduleRepository,
                                    IClaimTotalRepository claimTotalRepository,
                                    IClaimRepository claimRepository,
                                    IConfigERARemarkCodesRepository configERARemarkCodesRepository,
                                    IActionNoteRepository actionNoteRepository,
                                    ILogger<ChargeInvoiceService> logger,
                                    IChargeScrubRepository chargeScrubRepository,
                                    IProviderIdentityRepository providerIdentityRepository,
                                    IEncounterRulesAllowedPOSRepository encounterRulesAllowedPOSRepository,
                                    IEncounterRulesRepository encounterRulesRepository,
                                    IEncounterRulesAllowedCPTRepository encounterRulesAllowedCPTRepository,
                                    IChargeInWriteOffRepository chargeInWriteOffRepository,
                                    IERAClaimRepository iERAClaimRepository,
                                    IPracticeRepository practiceRepository,
                                    IProviderFacilityValidtionRepository providerFacilityValidtionRepository,
                                    IDynmoPaymentsRepository dynmoPaymentsRepository,
                                    IPortalPaymentRepository portalPaymentRepository
                                    )
        {
            this._portalPaymentRepository = portalPaymentRepository;
            this._dynmoPaymentsRepository = dynmoPaymentsRepository;
            this._providerFacilityValidtionRepository = providerFacilityValidtionRepository;
            this._practiceRepository = practiceRepository;
            this._chargeInWriteOffRepository = chargeInWriteOffRepository;
            this._encounterRulesAllowedCPTRepository = encounterRulesAllowedCPTRepository;
            this._encounterRulesAllowedPOSRepository = encounterRulesAllowedPOSRepository;
            this._encounterRulesRepository = encounterRulesRepository;
            this._providerIdentityRepository = providerIdentityRepository;
            _mapper = mapper;
            _transactionProvider = transactionProvider;
            _invoiceRepository = invoiceRepository;
            _chargesRepository = chargesRepository;
            _invDiagnosisRepository = invDiagnosisRepository;
            _defaultReasonCodeRepository = defaultReasonCodeRepository;
            this._chargeBatchRepository = chargeBatchRepository;
            this._voucherRepository = voucherRepository;
            this._paymentRepository = paymentRepository;
            _insurancePolicyRepository = insurancePolicyRepository;
            _paymentAdjustmentRepository = paymentAdjustmentRepository;
            _paymentChargeRepository = paymentChargeRepository;
            this._patientCaseRepository = patientCaseRepository;
            this._patientRepository = patientRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            this._cPTCodeRepository = cPTCodeRepository;
            this._drugChargeRepository = drugChargeRepository;
            this._configDrugClassRepository = configDrugClassRepository;
            this._paymentRemarkCodeRepository = paymentRemarkCodeRepository;
            _feeScheduleService = feeScheduleService;
            _claimChargeRepository = claimChargeRepository;
            _patientStatementRepository = patientStatementRepository;
            _facilityRepository = facilityRepository;
            _cPTModifierRepository = cPTModifierRepository;
            _providerRepository = providerRepository;
            _referringDoctorRepository = referringDoctorRepository;
            _iCDCodeRepository = iCDCodeRepository;
            _nDCRepository = nDCRepository;
            this._patientAuthorizationNumberRepository = patientAuthorizationNumberRepository;
            this._fsChargeRepository = fsChargeRepository;
            this._feeScheduleRepository = feeScheduleRepository;
            this._claimTotalRepository = claimTotalRepository;
            this._claimRepository = claimRepository;
            this._configERARemarkCodesRepository = configERARemarkCodesRepository;
            this._actionNoteRepository = actionNoteRepository;
            this._logger = logger;
            this._chargeScrubRepository = chargeScrubRepository;
            this._iERAClaimRepository = iERAClaimRepository;
        }

        /// <summary>
        /// add invoice with it's diagnosis and Charge
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IInvoice> AddNew(IInvoice entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                Invoice invoice = entity as Invoice;
                

                var encounterScrub = await ValidateEncounterRules(invoice);

                List<IInsurancePolicy> policies = new List<IInsurancePolicy>();
                /*Batch - each batch generated on daily basis
                find which one batch is going on current date*/
                var currentBatch = await this._chargeBatchRepository.GetByUId(invoice.ChargeBatchUId.ToString());
                if (currentBatch == null)
                    currentBatch = await this._chargeBatchRepository.GetCurrentBatch();
                invoice.ChargeBatchId = currentBatch == null ? 0 : currentBatch.Id;
                invoice.ChargeBatchUId = currentBatch == null ? new Guid() : currentBatch.UId;
                var patientCase = await this._patientCaseRepository.GetByUId(invoice.PatientCaseUId);
                invoice.PatientCaseId = patientCase == null ? 0 : patientCase.Id;

                //fetching facility data by Uid
                var facilityData = await this._facilityRepository.GetByUId(invoice.BillFacilityUId.Value);
                invoice.BillFacilityId = facilityData == null ? 0 : (short?)facilityData.Id;
                invoice.FacilityId = facilityData == null ? 0 : (short?)facilityData.Id;

                //fetching provider data by Uid
                var providerData = await this._providerRepository.GetByUId(invoice.BillProviderUId.Value);
                invoice.BillProviderId = providerData == null ? 0 : (short?)providerData.Id;
                if (invoice.PerformingProviderUId.HasValue) { 
                var performingPData = await this._providerRepository.GetByUId(invoice.PerformingProviderUId.Value);
                invoice.PerformingProviderId = performingPData == null ? 0 : (short?)performingPData.Id;
                }

                //invoice.SupervisingProviderId = providerData == null ? 0 : (short?)providerData.Id;
                if (invoice.SupervisingProviderUId.HasValue)
                {
                    var supervisingProvider = await this._providerRepository.GetByUId(invoice.SupervisingProviderUId.Value);
                    invoice.SupervisingProviderId = supervisingProvider == null ? null : (short?)supervisingProvider.Id;
                }
                if (invoice.OrderringProviderUId.HasValue)
                {
                    var orderringProvider = await this._providerRepository.GetByUId(invoice.OrderringProviderUId.Value);
                    invoice.OrderringProviderId = orderringProvider == null ? null : (short?)orderringProvider.Id;
                }

                if (invoice.AuxillaryProviderUId.HasValue)
                {
                    var auxillaryProvider = await this._providerRepository.GetByUId(invoice.AuxillaryProviderUId.Value);
                    invoice.AuxillaryProviderId = auxillaryProvider == null ? null : (short?)auxillaryProvider.Id;
                }


                invoice.ServiceCircumstanceId = (invoice.ServiceCircumstanceId == 0 ? null : invoice.ServiceCircumstanceId);

                //fetching ref doctor data by Uid
                invoice.RefDoctorUId = invoice.RefDoctorUId == null ? new Guid() : invoice.RefDoctorUId;
                var refDoctorData = await this._referringDoctorRepository.GetByUId(invoice.RefDoctorUId.Value);
                invoice.RefDoctorId = refDoctorData == null ? null : (short?)refDoctorData.Id;

                invoice.FacilityId = invoice.FacilityId ?? invoice.BillFacilityId;

                invoice.AuthorizationNumberUId = invoice.AuthorizationNumberUId == null ? new Guid() : invoice.AuthorizationNumberUId;
                var authorizationNumberUIdData = await this._patientAuthorizationNumberRepository.GetByUId(invoice.AuthorizationNumberUId.Value);
                invoice.AuthorizationNumberId = authorizationNumberUIdData == null ? 0 : (short?)authorizationNumberUIdData.Id;
                invoice.IsBillable = (invoice.IsBillable == null ? false : invoice.IsBillable);
                /*add information of invoice*/

                

                List<ICharges> drugCharge = new List<ICharges>();

                var patientPolicies = await this._insurancePolicyRepository.GetPoliciesForClaim(invoice.PatientCaseId, invoice.BillFromDate);
                IInsurancePolicy primaryPolicy = null;
                IInsurancePolicy medicaidPolicy = null;
                if (patientPolicies!=null && patientPolicies.Count()>0)
                {
                    primaryPolicy = patientPolicies.FirstOrDefault(i => i.InsuranceLevel == 1);
                    medicaidPolicy = patientPolicies.FirstOrDefault(i => i.InsuranceCompanyTypeId == 4);
                }

                invoice.IsCombinedGCode = false;
                if (primaryPolicy.IsGCodeAccepted && medicaidPolicy==null)
                {                    
                    invoice.IsCombinedGCode = true;
                }
                

                if(invoice.IsFromHl7==true)
                {
                    if (invoice.AuthorizationNumberId == 0)
                    {
                        var priorAuth = await this._patientAuthorizationNumberRepository.GetByInsurancePolicyId(primaryPolicy.Id);
                        if (priorAuth != null)
                        {
                            if (invoice.BillFromDate >= priorAuth.EffectiveDate && invoice.BillFromDate <= priorAuth.ExpirationDate)
                            {
                                invoice.AuthorizationNumberId = priorAuth.Id;
                                invoice.AuthorizationNumberUId = priorAuth.UId;
                            }
                        }
                    }
                }

                var result = await this._invoiceRepository.AddNew(invoice);

                bool jCodeExits = false;
                
                foreach (var item in invoice.ChargeList)
                {
                    item.PerformingProviderUId = invoice.PerformingProviderUId;

                    if (item.CPTCode.StartsWith("J"))
                    {
                        if (string.IsNullOrWhiteSpace(item.NDCCode))
                        {
                            //List<string> payerNames = new List<string>() { "87726", "88337", "25463", "00834", "02937", "SKOH5", "SKOH2", "31114" };
                            List<string> payerNames = new List<string>() { "87726", "88337", "25463", "02937" };

                            INDC ndc = null;
                            var matchedPayer = payerNames.FirstOrDefault(i => i.ToLower().ToString() == primaryPolicy.InsuranceCompanyCode.ToLower());

                            if (matchedPayer!=null)
                            {
                                ndc = await this._nDCRepository.GetByCptCode("J0574");
                            }
                            else
                            {
                                ndc = await this._nDCRepository.GetByCptCode(item.CPTCode);
                            }

                            
                            if (ndc != null)
                            {
                                item.NDCCode = ndc.NDCCode;
                                item.UnitOfMeasure = ndc.UoM;
                                item.DrugQty = (short?)ndc.DrugQty;
                                item.NDCFormat = ndc.Format.Value;
                            }
                            else
                            {
                                await this._chargesRepository.ThrowJCodeError();
                            }
                        }
                        else
                        {
                            var ndc = await this._nDCRepository.GetByCode(item.NDCCode);
                            if (ndc != null)
                            {
                                item.NDCCode = ndc.NDCCode;
                                item.UnitOfMeasure = ndc.UoM;
                                item.DrugQty = (short?)ndc.DrugQty;
                                item.NDCFormat = ndc.Format.Value;
                            }
                            else
                            {
                                await this._chargesRepository.ThrowJCodeError();
                            }
                        }
                        jCodeExits = true;
                    }

                    List<string> payerNamesFor95 = new List<string>() { "81400", "25463", "10990", "87726", "39026", "60054", "57604" };
                    var matchedPayerFor95 = payerNamesFor95.FirstOrDefault(i => i.ToLower().ToString() == primaryPolicy.InsuranceCompanyCode.ToLower());
                    if(matchedPayerFor95!=null)
                    {
                        List<string> modifiers = new List<string>();
                        if (!string.IsNullOrWhiteSpace(item.Mod1))
                            modifiers.Add(item.Mod1);
                        if (!string.IsNullOrWhiteSpace(item.Mod2))
                            modifiers.Add(item.Mod2);
                        if (!string.IsNullOrWhiteSpace(item.Mod3))
                            modifiers.Add(item.Mod3);
                        if (!string.IsNullOrWhiteSpace(item.Mod4))
                            modifiers.Add(item.Mod4);
                        var mod = modifiers.FirstOrDefault(i => i.ToString() == "95" || i.ToString() == "GT");
                        if(mod!=null)
                        {
                            item.POSId = "02";
                        }
                    }

                    if(item.CPTCode=="H2019" && item.Qty>=6)
                    {
                        item.POSId = "99";
                    }
                }

                if (jCodeExits)
                {
                    var T1502 = invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502");
                    var JCode = invoice.ChargeList.FirstOrDefault(i => i.CPTCode.Contains("J057"));
                    if (T1502 != null && JCode != null)
                    {
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").NDCCode = JCode.NDCCode;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").DrugQty = 100;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").UnitOfMeasure = 4;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").NDCFormat = JCode.NDCFormat;
                    }
                }


                /*Iterate charge list which are exist in invoice*/
                foreach (var item in invoice.ChargeList)
                {
                    if(item.PerformingFacilityUId.HasValue)
                    {
                        var PerformFacilityData = await this._facilityRepository.GetByUId(item.PerformingFacilityUId.Value);
                        item.PerformingFacilityId = PerformFacilityData == null ? 0 : (short?)PerformFacilityData.Id;
                    }
                    

                    var performProviderData = await this._providerRepository.GetByUId(item.PerformingProviderUId.Value);
                    item.PerformingProviderId = performProviderData == null ? 0 : (short?)performProviderData.Id;
                    item.Amount = item.MultiplyQty == true ? item.Qty > 0 ? (item.Qty * item.Amount) : item.Amount : item.Amount;

                    /* check charge is made for Insurance*/

                    if (item.BillToInsurance)
                    {
                        /*patient should have insurance policy to make charge on insurance.*/
                        policies = (await this._insurancePolicyRepository.GetPoliciesFromHL7(invoice.PatientCaseId, item.BillFromDate)).ToList();
                        if (policies.Count() == 0) /*if policy not exist it will throw exception.*/
                        {
                            if(invoice.IsFromHl7==null)
                            await this._insurancePolicyRepository.PolicyDoesNotExist();
                        }
                            
                    }

                    item.InvoiceId = result.Id;
                    item.PatientCaseId = invoice.PatientCaseId;


                    var cptDetails = await this._cPTCodeRepository.GetCPTCode(item.CPTCode);
                    if (cptDetails != null)
                    {
                        item.CPTCode = cptDetails.CPTCode;
                    }

                    /*check, CPT needs to convert into G-Code, that also depends on InsuranceCompany,
                    if Insurance Company accept G-Code then CPT can change into G-Code*/
                    if (entity.IsCombinedGCode)
                    {

                        if (cptDetails.DrugClassId != null)
                        {
                            if (!item.IsChargeDeleted)
                            {
                                await this._drugChargeRepository.AddNew(item, policies);
                                drugCharge.Add(item);
                            }
                            else
                                await this._chargesRepository.DeleteCharge((int)item.InvoiceId, item.Id);
                        }
                        else
                        {
                            if (!item.IsChargeDeleted)
                                await this._chargesRepository.AddNew(item, policies);
                            else
                                await this._chargesRepository.DeleteCharge((int)item.InvoiceId, item.Id);

                        }
                    }
                    else
                    {
                        /*add new Charge*/
                        if (item.Id == 0 && !item.IsChargeDeleted)
                            await this._chargesRepository.AddNew(item, policies);
                        else
                            await this._chargesRepository.DeleteCharge((int)item.InvoiceId, item.Id);
                    }
                }

                if (jCodeExits)
                {
                    var T1502 = invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502");
                    var JCode = invoice.ChargeList.FirstOrDefault(i => i.CPTCode.Contains("J057"));
                    if (T1502 != null && JCode != null)
                    {
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").NDCCode = JCode.NDCCode;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").DrugQty = 100;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").UnitOfMeasure = 4;
                    }
                }

                if (entity.IsCombinedGCode)
                {
                    if (drugCharge.Count() != 0)
                    {
                        var item = drugCharge.FirstOrDefault();
                        if (item != null && item.BillToInsurance)
                        {
                            policies = (await this._insurancePolicyRepository.GetPolicies(invoice.PatientCaseId, item.BillFromDate)).ToList();
                            //var drugConfig = await this._configDrugClassRepository.Get(drugCharge.Count());
                            var drugConfig = await this._configDrugClassRepository.GetByCode(item.CPTCode);
                            if(drugConfig!=null)
                                item.CPTCode = drugConfig.SubCPTCode;
                            var cptDetails = await this._cPTCodeRepository.GetCPTCode(item.CPTCode);
                            if (cptDetails != null)
                                item.Description = cptDetails.Description;
                            List<string> modifiers = new List<string>() { item.Mod1, item.Mod2, item.Mod3, item.Mod4 };

                            /*fetch feeSchedule according to CPTCode, Modifiers, performing doctor, insurance company, from Date*/
                            var feeSchulde = await this._feeScheduleService.GetChargeByCPT(item.CPTCode, modifiers, item.PerformingProviderUId.ToString(), item.InsuranceCompanyUId, item.BillFromDate);
                            item.Amount = feeSchulde != null ? feeSchulde.FacilityCharge : 0;
                          var savedCharge=  await this._chargesRepository.AddNew(item, policies);
                        }
                    }
                }
                /* insert Diagnosis list*/
                await this._invDiagnosisRepository.AddNewEntities(invoice.InvDiagnosisLst, result.Id);

                await ValidateLogicWithDupliateWithDOSProviderCPTScrub(result.Id);

                //seven days logic for H0048
                if(invoice.ChargeList.FirstOrDefault(i=>i.CPTCode=="H0048")!=null)
                {
                    await this._chargesRepository.Check7DayLogic(result.Id);
                }

                //seven days logic for H0048
                //commented on 05 Jan 2026, Venkat requested to stop
                //if (invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "H0015") != null)
                //{
                //    var countH0015=await this._chargesRepository.Check14CountLogicForH0015(result.Id);
                //    if(countH0015>=14)
                //    {
                //        await this._invoiceRepository.UpdateReviewNeeded(result.UId, true, "H0015 needs to be billed only 14 units per month, from 15th Unit check for authorization");
                //    }
                //}

                await LogicForSwapProvider(primaryPolicy,result);



                this._transactionProvider.CommitTransaction(transactionId);
                //if (result.Id > 0)
                //    await this._chargesRepository.RunChargeScrub(result.Id);
                return result;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        private async Task LogicForSwapProvider(IInsurancePolicy primaryPolicy, IInvoice invoice)
        {
            try
            {
                var invoiceChargeList = await this._chargesRepository.GetForChargeReference(invoice.Id);
                var nineCodes = invoiceChargeList.FirstOrDefault(i => i.CPTCode.StartsWith("9"));
                if (nineCodes != null)
                {
                    if (primaryPolicy.InsuranceCompanyTypeId != 4)
                    {
                        if(primaryPolicy.InsuranceCompanyTypeId == 5 && primaryPolicy.InsuranceCompanyCode== "15202")
                        {
                            return;
                        }

                        var performingPData = await this._providerRepository.GetById(invoice.PerformingProviderId.Value);
                        if (performingPData.SwapProviderId.HasValue && performingPData.SwapProviderId.Value > 0)
                        {
                            invoice.PerformingProviderId = performingPData.SwapProviderId.Value;
                            foreach (var item in invoiceChargeList)
                            {
                                item.PerformingProviderId = performingPData.SwapProviderId.Value;
                                await this._chargesRepository.UpdatePerformingProviderIdForNineSeries(item);
                            }
                            await this._invoiceRepository.UpdatePerformingProviderIdForNineSeries(invoice);
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }


        private async Task ValidateLogicWithDupliateWithDOSProviderCPTScrub(int invoiceId)
        {
            try
            {
                bool isNotBiilable = false;

                string comments = "";

                var invoiceChargeList = await this._chargesRepository.GetForChargeReference(invoiceId);

                foreach (var item in invoiceChargeList)
                {
                    var chargeList = await this._chargesRepository.GetExistsCharge(invoiceId, item.PatientCaseId,item.PerformingProviderId.Value, item.CPTCode);

                    var chargeItem = chargeList.Where(i => i.BillFromDate.Date == item.BillFromDate.Date 
                    && i.BillFromDate.Day == item.BillFromDate.Day 
                    && i.BillFromDate.Year == item.BillFromDate.Year).OrderByDescending(i=>i.InvoiceId).FirstOrDefault();
                    

                    if(chargeItem != null)
                    {
                        isNotBiilable = true;

                        var amount = chargeItem.Amount / chargeItem.Qty;
                        chargeItem.Qty += item.Qty;
                        chargeItem.Amount = amount * chargeItem.Qty;
                        chargeItem.FeeAmount = (chargeItem.FeeAmount==null?0: chargeItem.FeeAmount)+ (item.FeeAmount == null ? 0 : item.FeeAmount);
                        //chargeItem.RefChargeId = item.Id;

                        await this._chargesRepository.UpdateQuantityAndAmount(chargeItem,true);

                        if(chargeItem.FeeAmount.HasValue && chargeItem.FeeAmount.Value>0)
                        await this._invoiceRepository.UpdateFeeAmountWhileRollUP(chargeItem.InvoiceId, chargeItem.FeeAmount.Value);

                        string msg= chargeItem.AccessionNumber == null ? item.Id.ToString() : chargeItem.AccessionNumber.ToString();

                        comments += "This charge came again in a day with same provider, dos date and cpt code, so marked not billable and got lock, Ref EMR# : " + msg;

                        item.RefChargeComment = "This charge came again in a day with same provider, dos date and cpt code, so marked not billable and got lock, Ref EMR# : " + msg;
                        item.IsLocked = true;
                        item.IsDeleted = true;
                        item.RefChargeId = chargeItem.Id;

                        await this._chargesRepository.UpdateQuantityAndAmount(item, false);
                    }
                }

                if(isNotBiilable)
                {
                    await this._invoiceRepository.UpdateChargeRefComments(invoiceId, comments);
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task<string>ValidateEncounterRules(IInvoice entity)
        {
            string errorMessage = "";
            if(!string.IsNullOrWhiteSpace( entity.EncounterTypeCode))
            {
                var enccouterRule = await this._encounterRulesRepository.GetByCode(entity.EncounterTypeCode);
                if(enccouterRule!=null)
                {
                    //var cptCodesNotAllowed = entity.ChargeList.FirstOrDefault(i => i.CPTCode != enccouterRule.CptCode);
                    //if(cptCodesNotAllowed != null)
                    //{
                    //    errorMessage += "Only CptCode=" + enccouterRule.CptCode + " allowed with encouter type " + enccouterRule.EncounterType;
                    //}

                    var enccouterAllowedCPTs = await this._encounterRulesAllowedCPTRepository.GetByEncounterRuleId(enccouterRule.Id);
                    if (enccouterAllowedCPTs != null)
                    {
                        foreach (var item in entity.ChargeList)
                        {
                            var checkPosExists = enccouterAllowedCPTs.FirstOrDefault(i => i.CptCode == item.CPTCode);
                            if (checkPosExists == null)
                            {
                                errorMessage += "CPT code does not match with encounter listed CPT codes=" + item.CPTCode;
                            }
                        }
                    }

                    var cptCodes = entity.ChargeList.FirstOrDefault(i => i.CPTCode == enccouterRule.CptCode);
                    if (cptCodes == null)
                    {
                        errorMessage += "CptCode=" + enccouterRule.CptCode + " should be there with encouter type " + enccouterRule.EncounterType;
                    }

                    List<string> diagnosisList = new List<string>();
                    foreach (var item in entity.InvDiagnosisLst)
                    {
                        if(item.IcdClassification!=entity.InvoiceType)
                        {
                            errorMessage += "Icd Code=" + item.ICDCode + " does not match with encounter type " + enccouterRule.EncounterType;
                        }
                        diagnosisList.Add(item.ICDCode);
                    }

                    var matcheddiagnosis = await this._iCDCodeRepository.GetICDCodes(diagnosisList);
                    foreach (var item in matcheddiagnosis)
                    {
                        if (item.IcdType != entity.InvoiceType)
                        {
                            errorMessage += "Icd Code=" + item.Code + " does not match with encounter type " + enccouterRule.EncounterType;
                        }
                    }
                    
                    var timedureation = entity.ToTime.Value.Subtract(entity.FromTime.Value).TotalMinutes;
                    if(!string.IsNullOrEmpty(enccouterRule.MinimumDuration))
                    {
                        if(Convert.ToInt32(enccouterRule.MinimumDuration)> timedureation)
                        {
                            errorMessage += "Minimum time should be " + enccouterRule.MinimumDuration.ToString();
                        }
                    }

                    var enccouterAllowedPOS = await this._encounterRulesAllowedPOSRepository.GetByEncounterRuleId(enccouterRule.Id);
                    if(enccouterAllowedPOS!=null)
                    {
                        foreach (var item in entity.ChargeList)
                        {
                            var checkPosExists = enccouterAllowedPOS.FirstOrDefault(i => i.PosId == item.POSId);
                            if(checkPosExists==null)
                            {
                                errorMessage += "PosId does not match with encounter listed for CPT code=" + item.CPTCode;
                            }
                        }
                    }
                }
            }
            return "";
        }

        public async Task<IInvoice> UpdateEntity(IInvoice entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                Invoice invoice = entity as Invoice;
                List<IInsurancePolicy> policies = new List<IInsurancePolicy>();
                IEnumerable<IPaymentCharge> paymentCharges;
                bool isPayment = false;

                if (invoice.IsRejected.HasValue && invoice.IsRejected.Value)
                {
                    string tplCode = (await this._practiceRepository.Get()).ChargeRejectionCode;
                    if(!string.IsNullOrWhiteSpace(tplCode))
                    {
                        if(tplCode!=entity.RejectedPIN.Trim())
                        {
                            await this._invoiceRepository.ThrowRejectionPINNotMatched();
                        }
                    }
                }

                if(invoice.ChargeList.FirstOrDefault(i => i.IsRecurring.HasValue && i.IsRecurring.Value && i.CPTCode=="H0048")!=null)
                {
                    await this._chargesRepository.ThrowRecurringError();
                }

                invoice.FacilityId = invoice.FacilityId ?? invoice.BillFacilityId;
                /*update invoice info*/

                var currentBatch = await this._chargeBatchRepository.GetByUId(invoice.ChargeBatchUId.ToString());
                invoice.ChargeBatchId = currentBatch == null ? invoice.ChargeBatchId : currentBatch.Id;

                var patientCase = await this._patientCaseRepository.GetByUId(invoice.PatientCaseUId);
                invoice.PatientCaseId = patientCase == null ? 0 : patientCase.Id;

                //fetching facility data by Uid
                var facilityData = await this._facilityRepository.GetByUId(invoice.BillFacilityUId.Value);
                invoice.BillFacilityId = facilityData == null ? 0 : (short?)facilityData.Id;
                invoice.FacilityId = facilityData == null ? 0 : (short?)facilityData.Id;

                //fetching provider data by Uid
                var providerData = await this._providerRepository.GetByUId(invoice.BillProviderUId.Value);
                invoice.BillProviderId = providerData == null ? 0 : (short?)providerData.Id;

                var performingPData = await this._providerRepository.GetByUId(invoice.PerformingProviderUId.Value);
                invoice.PerformingProviderId = performingPData == null ? 0 : (short?)performingPData.Id;
                
                if (invoice.SupervisingProviderUId.HasValue)
                {
                    var supervisingProvider = await this._providerRepository.GetByUId(invoice.SupervisingProviderUId.Value);
                    invoice.SupervisingProviderId = supervisingProvider == null ? null : (short?)supervisingProvider.Id;
                }
                else
                {
                    invoice.SupervisingProviderId = null;
                }

                if (invoice.OrderringProviderUId.HasValue)
                {
                    var orderringProvider = await this._providerRepository.GetByUId(invoice.OrderringProviderUId.Value);
                    invoice.OrderringProviderId = orderringProvider == null ? null : (short?)orderringProvider.Id;
                }
                else
                {
                    invoice.OrderringProviderId = null;
                }

                if (invoice.AuxillaryProviderUId.HasValue)
                {
                    var auxillaryProvider = await this._providerRepository.GetByUId(invoice.AuxillaryProviderUId.Value);
                    invoice.AuxillaryProviderId = auxillaryProvider == null ? null : (short?)auxillaryProvider.Id;
                }
                else
                {
                    invoice.AuxillaryProviderId = null;
                }
                //invoice.SupervisingProviderId = supervisingProvider == null ? 0 : (short?)supervisingProvider.Id;

                //fetching ref doctor data by Uid
                invoice.RefDoctorUId = invoice.RefDoctorUId == null ? new Guid() : invoice.RefDoctorUId;
                var refDoctorData = await this._referringDoctorRepository.GetByUId(invoice.RefDoctorUId.Value);
                invoice.RefDoctorId = refDoctorData == null ? null : (short?)refDoctorData.Id;

                invoice.AuthorizationNumberUId = invoice.AuthorizationNumberUId == null ? new Guid() : invoice.AuthorizationNumberUId;
                var authorizationNumberUIdData = await this._patientAuthorizationNumberRepository.GetByUId(invoice.AuthorizationNumberUId.Value);
                invoice.AuthorizationNumberId = authorizationNumberUIdData == null ? 0 : (short?)authorizationNumberUIdData.Id;

                var lockedCharge = invoice.ChargeList.FirstOrDefault(i => i.IsLocked == true);

                if (lockedCharge!=null)
                {
                    if(invoice.IsBillable.HasValue && invoice.IsBillable.Value)
                    {
                        await this._invoiceRepository.ThrowChargeLockedError();
                    }
                }

                if (invoice.IsRejected.HasValue && invoice.IsRejected.Value)
                {
                    invoice.IsDeleted = true;
                    foreach (var delCharge in invoice.ChargeList)
                    {
                        delCharge.IsDeleted = true;
                        delCharge.IsRejected = true;
                    }
                }


                await this._invoiceRepository.Update(invoice);

                var patientPolicies = await this._insurancePolicyRepository.GetPoliciesForClaim(invoice.PatientCaseId, invoice.BillFromDate);
                IInsurancePolicy primaryPolicy = null;
                if (patientPolicies != null && patientPolicies.Count() > 0)
                {
                    primaryPolicy = patientPolicies.FirstOrDefault(i => i.InsuranceLevel == 1);
                }

                //if(invoice.ChargeList.Count(i=>i.IsDeleted == false) == 0) { }

                bool jCodeExits = false;

                foreach (var item in invoice.ChargeList)
                {
                    item.PerformingProviderUId = invoice.PerformingProviderUId;

                    if (item.CPTCode.StartsWith("J"))
                    {
                        if (string.IsNullOrWhiteSpace(item.NDCCode))
                        {
                            List<string> payerNames = new List<string>() { "87726", "88337", "25463", "02937"};
                            INDC ndc = null;
                            var matchedPayer = payerNames.FirstOrDefault(i => i.ToLower().ToString() == primaryPolicy.InsuranceCompanyCode.ToLower());

                            if (matchedPayer != null)
                            {
                                ndc = await this._nDCRepository.GetByCptCode("J0574");
                            }
                            else
                            {
                                ndc = await this._nDCRepository.GetByCptCode(item.CPTCode);
                            }


                            if (ndc != null)
                            {
                                item.NDCCode = ndc.NDCCode;
                                item.UnitOfMeasure = ndc.UoM;
                                item.DrugQty = (short?)ndc.DrugQty;
                                item.NDCFormat = ndc.Format.Value;
                            }
                            else
                            {
                                await this._chargesRepository.ThrowJCodeError();
                            }
                        }
                        else
                        {
                            var ndc = await this._nDCRepository.GetByCode(item.NDCCode);
                            if (ndc != null)
                            {
                                item.NDCCode = ndc.NDCCode;
                                item.UnitOfMeasure = ndc.UoM;
                                item.DrugQty = (short?)ndc.DrugQty;
                                item.NDCFormat = ndc.Format.Value;
                            }
                            else
                            {
                                await this._chargesRepository.ThrowJCodeError();
                            }
                        }
                        jCodeExits = true;
                    }

                    List<string> payerNamesFor95 = new List<string>() { "87726", "60054" };
                    var matchedPayerFor95 = payerNamesFor95.FirstOrDefault(i => i.ToLower().ToString() == primaryPolicy.InsuranceCompanyCode.ToLower());
                    if (matchedPayerFor95 != null)
                    {
                        List<string> modifiers = new List<string>();
                        if (!string.IsNullOrWhiteSpace(item.Mod1))
                            modifiers.Add(item.Mod1);
                        if (!string.IsNullOrWhiteSpace(item.Mod2))
                            modifiers.Add(item.Mod2);
                        if (!string.IsNullOrWhiteSpace(item.Mod3))
                            modifiers.Add(item.Mod3);
                        if (!string.IsNullOrWhiteSpace(item.Mod4))
                            modifiers.Add(item.Mod4);
                        var mod = modifiers.FirstOrDefault(i => i.ToString() == "95");
                        if (mod != null)
                        {
                            item.POSId = "02";
                        }
                    }
                }

                if (jCodeExits)
                {
                    var T1502 = invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502");
                    var JCode = invoice.ChargeList.FirstOrDefault(i => i.CPTCode.Contains("J057"));
                    if (T1502 != null && JCode != null)
                    {
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").NDCCode = JCode.NDCCode;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").DrugQty = 100;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").UnitOfMeasure = 4;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").NDCFormat = JCode.NDCFormat;
                    }
                }



                /*Iterate charge list which are exist in invoice*/
                foreach (var item in invoice.ChargeList)
                {
                    

                    if (item.CPTCode== "90834" && item.Qty>1)
                    {
                        await this._chargesRepository.Throw90834ChargeError();
                    }
                    // var chargeData = await this._chargesRepository.GetByUId(item.UId);
                    if(item.PerformingFacilityUId.HasValue)
                    {
                        var PerformFacilityData = await this._facilityRepository.GetByUId(item.PerformingFacilityUId.Value);
                        item.PerformingFacilityId = PerformFacilityData == null ? 0 : (short?)PerformFacilityData.Id;
                    }
                    else
                    {
                        item.PerformingFacilityId = null;
                    }

                    var performingProvider = await this._providerRepository.GetByUId(item.PerformingProviderUId.Value);
                    item.PerformingProviderId = performingProvider == null ? 0 : (short?)performingProvider.Id;
                    item.Amount = item.MultiplyQty == true ? (item.Qty * item.Amount) : item.Amount;

                    item.Mod1 = string.IsNullOrEmpty(item.Mod1) ? string.Empty : item.Mod1;
                    item.Mod2 = string.IsNullOrEmpty(item.Mod2) ? string.Empty : item.Mod2;
                    item.Mod3 = string.IsNullOrEmpty(item.Mod3) ? string.Empty : item.Mod3;
                    item.Mod4 = string.IsNullOrEmpty(item.Mod4) ? string.Empty : item.Mod4;
                    //item.POSId = invoice.BillProviderId.ToString();
                    //string[] newIcdCode = { item.ICD1, item.ICD2, item.ICD3, item.ICD4 };
                    //List<Guid> convertIcd = new List<Guid>();
                    //foreach (var icd in newIcdCode)
                    //{
                    //    if (icd != null)
                    //        convertIcd.Add(new Guid(icd));
                    //}

                    //var icdData = await this._iCDCodeRepository.GetAllActiveICD();
                    //var icdDataCode = icdData.Where(i => convertIcd.Contains(i.UId));

                    item.ICD1 = item.ICD1 == null ? "" : item.ICD1;
                    item.ICD2 = item.ICD2 == null ? "" : item.ICD2;
                    item.ICD3 = item.ICD3 == null ? "" : item.ICD3;
                    item.ICD4 = item.ICD4 == null ? "" : item.ICD4;

                    /* check charge is made for Insurance*/
                    if (item.BillToInsurance)
                    {
                        /*patient should have insurance policy to make charge on insurance.*/
                        policies = (await this._insurancePolicyRepository.GetPolicies(invoice.PatientCaseId, item.BillFromDate)).ToList();
                        if (policies.Count() == 0) /*if policy not exist it will throw exception.*/
                            await this._insurancePolicyRepository.PolicyDoesNotExist();
                    }

                    if (item.Id != 0)
                    {
                        paymentCharges = await this._paymentChargeRepository.GetByChargeId(item.Id);
                        if (paymentCharges.Count() != 0)
                            isPayment = true;
                    }

                    item.InvoiceId = invoice.Id;
                    item.PatientCaseId = invoice.PatientCaseId;

                    /*check, CPT needs to convert into G-Code, that also depends on InsuranceCompany,
                    if Insurance Company accept G-Code then CPT can change into G-Code*/
                    if (entity.IsCombinedGCode)
                    {
                        var cptDetails = await this._cPTCodeRepository.GetCPTCode(item.CPTCode);

                        if (cptDetails != null && cptDetails.DrugClassId != null)
                        {
                            if (item.Id != 0 && !item.IsChargeDeleted)
                            {
                                var id = item.Id;
                                item.Id = 0;
                                await this._claimChargeRepository.CheckChargeForDelete(id);

                                if (isPayment)
                                    await this._paymentChargeRepository.ThrowPaymentExistsWithThisChargeError();

                                if (!item.CPTCode.Contains("S9480"))
                                {
                                    var checkCPT = await this._drugChargeRepository.GetDrugCharge(item.InvoiceId, item.PatientCaseId, item.CPTCode);
                                    if (checkCPT)
                                        await this._drugChargeRepository.AddNew(item, policies);
                                }

                                await this._actionNoteRepository.DeleteByChargeId(id);
                                await this._chargesRepository.DeleteByChargeId((int)item.InvoiceId, id);
                            }
                            else if (item.Id == 0 && !item.IsChargeDeleted)
                            {
                                var checkCPT = await this._drugChargeRepository.GetDrugCharge(item.InvoiceId, item.PatientCaseId, item.CPTCode);
                                if (checkCPT)
                                    await this._drugChargeRepository.AddNew(item, policies);
                            }
                            else
                            {
                                await this._claimChargeRepository.CheckChargeForDelete(item.Id);
                                if (isPayment)
                                    await this._paymentChargeRepository.ThrowPaymentExistsWithThisChargeError();

                                await this._drugChargeRepository.DeletByInvoice((int)item.InvoiceId, item.ChargeNo);
                                await this._actionNoteRepository.DeleteByChargeId(item.Id);
                                await this._chargesRepository.DeleteByChargeId((int)item.InvoiceId, item.Id);
                            }
                        }
                        else
                        {
                            item.InvoiceId = invoice.Id;
                            if (item.Id != 0 && !item.IsChargeDeleted)
                            {
                                //await this._claimChargeRepository.CheckForDelete(item.Id);
                                item.IsOnlyUpdate = true;
                                await this._chargesRepository.Update(item, policies);
                            }
                            else if (item.Id == 0 && !item.IsChargeDeleted)
                                await this._chargesRepository.AddNew(item, policies);
                            else
                            {
                                /*Check, claim has been made for given Charge, if claim has been made then it will give exception that
                                 this charge is being use in claim*/
                                await this._claimChargeRepository.CheckChargeForDelete(item.Id);
                                /*Delete charge if claim is not made for given charge*/
                                if (isPayment)
                                    await this._paymentChargeRepository.ThrowPaymentExistsWithThisChargeError();

                                await this._actionNoteRepository.DeleteByChargeId(item.Id);
                                await this._chargesRepository.DeleteByChargeId((int)item.InvoiceId, item.Id);
                            }
                        }
                    }
                    else
                    {
                        item.InvoiceId = invoice == null ? 0 : invoice.Id;
                        if (item.Id != 0 && !item.IsChargeDeleted)
                            await this._chargesRepository.Update(item, policies);
                        else if (item.Id == 0 && !item.IsChargeDeleted)
                            await this._chargesRepository.AddNew(item, policies);
                        else
                        {
                            /*Check, claim has been made for given Charge, if claim has been made then it will give exception that
                             this charge is being use in claim*/
                            await this._claimChargeRepository.CheckChargeForDelete(item.Id);
                            /*Delete charge if claim is not made for given charge*/
                            if (isPayment)
                                await this._paymentChargeRepository.ThrowPaymentExistsWithThisChargeError();

                            await this._actionNoteRepository.DeleteByChargeId(item.Id);
                            await this._chargesRepository.DeleteByChargeId((int)item.InvoiceId, item.Id);
                        }
                    }
                }

                if (jCodeExits)
                {
                    var T1502 = invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502");
                    var JCode = invoice.ChargeList.FirstOrDefault(i => i.CPTCode.Contains("J057"));
                    if (T1502 != null && JCode != null)
                    {
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").NDCCode = JCode.NDCCode;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").DrugQty = 100;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").UnitOfMeasure = 4;
                        invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "T1502").NDCFormat = JCode.NDCFormat;
                    }
                }

                if (entity.IsCombinedGCode && (invoice.ChargeList.Where(i => i.IsOnlyUpdate == false && i.IsChargeDeleted == false)).Count() != 0)
                {
                    ICharges item;
                    // IEnumerable<IActionNote> actionNotes = null;
                    var chargeEntry = await this._chargesRepository.GetGcCodeEntry(invoice.InvoiceId);
                    //if (chargeEntry != null)
                    //{
                    //    await this._claimChargeRepository.CheckChargeForDelete(chargeEntry.Id);

                    //    actionNotes = await this._actionNoteRepository.GetByChargeId(chargeEntry.Id);
                    //    IEnumerable<int> ids = actionNotes.Select(i => i.Id).ToArray();
                    //    await this._actionNoteRepository.Delete(ids);
                    //}


                    // var gcRecord = await this._chargesRepository.DeleteGcCodeEntry(invoice.InvoiceId);
                    item = entity.ChargeList.Where(i => i.CPTCode.Contains("S9480") && !i.IsDeleted)?.FirstOrDefault();
                    var drugRecords = await this._drugChargeRepository.GetByInvoice(invoice.UId.ToString());
                    if (item == null)
                    {
                        item = drugRecords.OrderByDescending(i => i.Id).FirstOrDefault();

                        if (item != null)
                            item.Id = 0;
                    }
                    if (item != null /*&& item.BillToInsurance*/) //this condition suggested by rohit sir
                    {
                        policies = (await this._insurancePolicyRepository.GetPolicies(invoice.PatientCaseId, item.BillFromDate)).ToList();
                        //var drugConfig = await this._configDrugClassRepository.Get(drugRecords.Count());

                        var drugConfig = await this._configDrugClassRepository.GetByCode(item.CPTCode);
                        if (drugConfig != null)
                            item.CPTCode = drugConfig.SubCPTCode;

                        var cptCode = item.CPTCode;

                        var cptDetails = await this._cPTCodeRepository.GetCPTCode(cptCode);

                        if (cptDetails != null)
                            item.Description = cptDetails.Description;
                        List<string> modifiers = new List<string>() { item.Mod1, item.Mod2, item.Mod3, item.Mod4 };
                        var feeSchulde = await this._feeScheduleService.GetChargeByCPT(cptCode, modifiers, entity.ChargeList.FirstOrDefault().PerformingProviderUId.ToString(), primaryPolicy.InsuranceCompanyUId.ToString(), item.BillFromDate);
                        item.Amount = feeSchulde != null ? feeSchulde.FacilityCharge : 0;

                        //var cptDetails = await this._cPTCodeRepository.GetCPTCode(drugConfig.CptCode);
                        //if (cptDetails != null)
                        //    item.Description = cptDetails.Description;

                        if (item.Id == 0)
                            await this._chargesRepository.AddNew(item, policies);
                        else
                            await this._chargesRepository.Update(item, policies);

                        //if (chargeEntry != null)
                        //{
                        //    actionNotes.ToList().ForEach((res) =>
                        //    {
                        //        res.Id = 0;
                        //        res.ChargeId = chargeData.Id;
                        //    });

                        //    await this._actionNoteRepository.AddNote(actionNotes);
                        //}
                    }
                }
                /* update Diagnosis on behalf of invoiceId
                there diagnosis can be add, delete or update*/
                await this._invDiagnosisRepository.UpdateEntities(invoice.InvDiagnosisLst, invoice.Id);

                this._transactionProvider.CommitTransaction(transactionId);
                //if (invoice.Id > 0)
                //    await this._chargesRepository.RunChargeScrub(invoice.Id);
                return invoice;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        /// <summary>
        /// fetch Invoice with it's Charge and Diagnosis.
        /// </summary>
        /// <param name="patientCaseUId"></param>
        /// <param name="invoiceUId"></param>
        /// <returns></returns>
        public async Task<IInvoice> GetByInvoice(Guid patientCaseUId, Guid invoiceUId)
        {
            try
            {
                var patientCase = await this._patientCaseRepository.GetByUId(patientCaseUId);
                patientCase.Id = patientCase == null ? 0 : patientCase.Id;
                var invoice = await this._invoiceRepository.GetInvoice(patientCase.Id, invoiceUId);
                var chargeBatch = await this._chargeBatchRepository.Get(invoice.ChargeBatchId.Value);
                invoice.ChargeBatchUId = chargeBatch == null ? new Guid() : chargeBatch.UId;
                if (invoice != null)
                {
                    invoice.PatientCaseUId = patientCase.UId;
                    invoice.IsRejected= !invoice.IsRejected.HasValue?false :invoice.IsRejected.Value;

                    //fetching facility data by Uid
                    var facilityData = await this._facilityRepository.GetById(invoice.BillFacilityId.Value);
                    invoice.BillFacilityUId = facilityData == null ? new Guid() : facilityData.UId;

                    //fetching provider data by Uid
                    var providerData = await this._providerRepository.GetById(invoice.BillProviderId.Value);
                    invoice.BillProviderUId = providerData == null ? new Guid() : providerData.UId;

                    //invoice.SupervisingProviderUId = providerData == null ? new Guid() : providerData.UId;

                    if (invoice.SupervisingProviderId.HasValue)
                    {
                        var supervisingProvider = await this._providerRepository.GetById(invoice.SupervisingProviderId.Value);
                        invoice.SupervisingProviderUId = supervisingProvider == null ? new Guid() : supervisingProvider.UId;
                        var supervisingIdentity = await this._providerIdentityRepository.GetNPIByProviderId(invoice.SupervisingProviderUId.Value);
                        invoice.SupervisingProviderNPI = supervisingIdentity == null ? "" : supervisingIdentity.Identifier;

                    }


                    if (invoice.OrderringProviderId.HasValue)
                    {
                        var orderringProvider = await this._providerRepository.GetById(invoice.OrderringProviderId.Value);
                        invoice.OrderringProviderUId = orderringProvider == null ? new Guid() : orderringProvider.UId;
                    }

                    if (invoice.AuxillaryProviderId.HasValue)
                    {
                        var auxillaryProvider = await this._providerRepository.GetById(invoice.AuxillaryProviderId.Value);
                        invoice.AuxillaryProviderUId = auxillaryProvider == null ? new Guid() : auxillaryProvider.UId;
                    }


                    if (invoice.PerformingProviderId.HasValue)
                    {
                        var performingProvider = await this._providerRepository.GetById(invoice.PerformingProviderId.Value);
                        invoice.PerformingProviderUId = performingProvider == null ? new Guid() : performingProvider.UId;
                    }
                    else
                    {
                        invoice.PerformingProviderUId = providerData == null ? new Guid() : providerData.UId;
                    }


                    if (invoice.AuthorizationNumberId != null)
                    {
                        var authorizationNumberUIdData = await this._patientAuthorizationNumberRepository.Get(invoice.AuthorizationNumberId.Value);
                        invoice.AuthorizationNumberUId = authorizationNumberUIdData == null ? new Guid() : authorizationNumberUIdData.UId;
                    }

                    //fetching ref doctor data by Uid
                    if (invoice.RefDoctorId != null)
                    {
                        var refDoctorData = await this._referringDoctorRepository.GetById(invoice.RefDoctorId.Value);
                        invoice.RefDoctorUId = refDoctorData == null ? new Guid() : refDoctorData.UId;
                    }

                    invoice.ChargeList = await this._chargesRepository.GetById(invoice.Id, patientCase.Id);

                    foreach (var item in invoice.ChargeList)
                    {
                        if (item.MultiplyQty)
                        {
                            var feeSchedule = await this._feeScheduleRepository.GetFeeSchedules(DateTime.Now);
                            var feeCharge = feeSchedule == null ? new FSCharge() : await this._fsChargeRepository.GetByCPT(item.CPTCode, feeSchedule.Id);
                            item.Amount = feeCharge == null ? item.Amount : (feeCharge.FacilityCharge > 0 || feeCharge.NonFacilityCharge > 0) ? (item.Amount / item.Qty) : item.Amount;
                        }
                        if(item.PerformingFacilityId.HasValue)
                        {
                            var PerformFacilityData = await this._facilityRepository.GetById(item.PerformingFacilityId.Value);
                            item.PerformingFacilityUId = PerformFacilityData == null ? new Guid() : PerformFacilityData.UId;
                        }
                        
                        var chargePerformingProvider = await this._providerRepository.GetByUId(item.PerformingProviderUId.Value);
                        item.PerformingProviderId = chargePerformingProvider == null ? Convert.ToInt16(0) : chargePerformingProvider.Id;
                        //item.PerformingProviderUId = item.PerformingProviderUId == null ? new Guid() : (await this._providerRepository.GetById(item.PerformingProviderId.Value)).UId;
                        item.Mod1 = string.IsNullOrEmpty(item.Mod1) ? string.Empty : item.Mod1;
                        item.Mod2 = string.IsNullOrEmpty(item.Mod2) ? string.Empty : item.Mod2;
                        item.Mod3 = string.IsNullOrEmpty(item.Mod3) ? string.Empty : item.Mod3;
                        item.Mod4 = string.IsNullOrEmpty(item.Mod4) ? string.Empty : item.Mod4;

                    }

                    invoice.InvDiagnosisLst = await this._invDiagnosisRepository.GetByInvoice(invoice.Id);
                }

                return invoice;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// fetch Invoice with it's Charge and Diagnosis.
        /// </summary>
        /// <param name="patientCaseId"></param>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public async Task<IInvoice> GetByInvoice(int patientCaseId, int invoiceId)
        {
            try
            {
                var invoice = await this._invoiceRepository.GetInvoice(patientCaseId, invoiceId);
                if(invoice.AuthorizationNumberId.HasValue)
                {
                    var policyAuthorizationNumber = await this._patientAuthorizationNumberRepository.Get(invoice.AuthorizationNumberId.Value);
                    if(policyAuthorizationNumber!=null)
                    {
                        invoice.AuthorizationNumber = policyAuthorizationNumber.AuthorizationNumber;
                    }
                }
                

                if (invoice != null)
                {
                    invoice.ChargeList = await this._chargesRepository.GetById(invoice.Id, patientCaseId);
                    invoice.InvDiagnosisLst = await this._invDiagnosisRepository.GetByInvoice(invoice.Id);
                }
                return invoice;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Fetch Billing Summary of patient according to it's caseId
        /// </summary>
        /// <param name="patientCaseId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IInvoice>> GetByInvoices(string patientCaseUId)
        {
            try
            {
                var patientCase = await this._patientCaseRepository.GetByUId(Guid.Parse(patientCaseUId));
                var patientCaseId = patientCase == null ? 0 : patientCase.Id;

                InvoiceBillHistoryFilter filter = new InvoiceBillHistoryFilter();
                filter.PatientCaseId = patientCaseId;

                ChargePaymentBillingHistoryFilter charge = new ChargePaymentBillingHistoryFilter();
                charge.PatientCaseId = patientCaseId;

                /*fetch Invoice according to it's filter*/
                var invoices = await this._invoiceRepository.GetInvoices(filter);
                foreach (var item in invoices)
                {
                    charge.InvoiceId = item.Id;
                    //fetch charges
                    item.ChargeList = await this._chargesRepository.GetBalance(charge);

                    /*whenever multiply qty is true, CPT's Charge will multiply by Quantity
                    otherwise CPT's quantity will assume 1 by default and CPT's Charge will be calculate only for single quantity.
                    fetch total charge for particular invoice*/
                    item.TotalCharges = item.ChargeList.Sum(i => (i.MultiplyQty ? (i.Amount * i.Qty) : i.Amount));

                    /*fetch total discount from Charge list.*/
                    item.TotalDiscount = item.ChargeList.Sum(i => i.Discount);

                    /*calculate How much balance is due on insurance company, from that total charge which is assigned to insurance company.*/
                    item.InsuranceBalance = item.ChargeList.Sum(i => (i.BillToInsurance ? i.DueAmount : 0));
                    /*calculate How much balance is due on Patient, from that total charge which is assigned to Patient.*/
                    item.PatientBalance = item.ChargeList.Sum(i => (i.BillToPatient ? i.DueAmount : 0));
                    /*calculate total payment and adjustment which paid by insurance or patient.*/
                    item.TotalPaymentAndAdjustment = item.TotalCharges - (item.InsuranceBalance + item.PatientBalance);
                }

                return invoices;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// fetch Payment Summary
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>

        public async Task<IEnumerable<IPaymentBatchDTO>> Get(IPaymentFilterDTO filter)
        {
            var patient = filter.PatientUId == Guid.Empty ? null : await this._patientRepository.GetByUId(filter.PatientUId);

            List<int> patientIds = new List<int>() { patient == null ? 0 : patient.Id };
            IEnumerable<int> PatientCaseIds = (await this._patientCaseRepository.GetPatient(patientIds)).Select(i => i.Id).ToArray();
            List<PaymentBatchDTO> _paymentBatchs = new List<PaymentBatchDTO>();
            PaymentBatchDTO _paymentBatch = new PaymentBatchDTO();

            //var voucherData = await this._voucherRepository.Get(filter.VoucherUId);
            var _invoiceData = await this._invoiceRepository.GetInvoices(PatientCaseIds);
            int[] batchIds = _invoiceData.Select(i => i.ChargeBatchId.Value).ToArray();

            var paymentData = await this._paymentRepository.GetByUId(filter.PaymentUId) as Payment;
            var chargeBatchData = await this._chargeBatchRepository.GetAll(batchIds);

            var insuranceDepositData = paymentData == null ? null : await this._insuranceCompanyRepository.GetById(paymentData.DepositInsuranceCompanyId);
            var insurancePatientData = paymentData == null ? null : await this._insuranceCompanyRepository.GetById(paymentData.PatientInsuranceCompanyId);

            int[] invoiceIds = _invoiceData.Select(i => i.Id).ToArray();

            var chargeViewsData = await this._chargesRepository.GetById(invoiceIds, PatientCaseIds, filter);

            var distintInvoiceIds = chargeViewsData.Select(i => i.InvoiceId).Distinct().ToList();

            _invoiceData = _invoiceData.Where(i => distintInvoiceIds.Contains(i.Id));

            foreach (var item in _invoiceData)
            {
                var batchData = chargeBatchData.Where(i => i.Id == item.ChargeBatchId.Value).FirstOrDefault();
                _paymentBatch.Charges = chargeViewsData.Where(i => i.InvoiceId == item.Id);

                _paymentBatch.AccessionNumber = item.AccessionNumber;
                _paymentBatch.InvoiceUId = item.UId;
                _paymentBatch.BatchNo = batchData.BatchNo;
                _paymentBatch.ChargeBatchUId = batchData.UId;
                _paymentBatch.IsReversed = paymentData != null ? paymentData.IsReversed : false;
                _paymentBatch.BatchAmount = batchData.BatchAmount;
                _paymentBatch.PaymentUId = paymentData != null ? paymentData.UId : new Guid();
                _paymentBatch.PatientUId = patient.UId;
                _paymentBatch.DepositInsuranceCompanyUId = paymentData == null ? new Guid() : insuranceDepositData == null ? new Guid() : insuranceDepositData.UId;
                _paymentBatch.PatientInsuranceCompanyUId = paymentData == null ? new Guid() : insurancePatientData == null ? new Guid() : insurancePatientData.UId;

                if (_paymentBatch.Charges.Count() > 0)
                {
                    _paymentBatch.Charges = await this.Get(_paymentBatch.Charges, paymentData, filter, item.DateOfSign);
                    _paymentBatch.PayorControl = paymentData == null ? string.Empty : paymentData.PayorControl;
                    _logger.LogInformation("Get Charge Count - " + _paymentBatch.Charges.Count());
                    _paymentBatch.Charges.ToList().ForEach((res) =>
                    {
                        res.AccessionNumber = item.AccessionNumber;
                        res.Mod1 = res.Mod1 + ',' + res.Mod2 + ',' + res.Mod3 + ',' + res.Mod4;
                        res.Mod1 = res.Mod1.Contains(",,") ? Regex.Replace(res.Mod1, @",+", ",") : res.Mod1;
                        res.Mod1 = res.Mod1.TrimEnd(',');
                        res.Mod1 = res.Mod1.TrimStart(',');
                    });

                    _paymentBatch.TotalAdjustmentAmount = _paymentBatch.Charges.ToList().Sum(i => i.TotalAdjustment);
                    _paymentBatch.TotalPaidAmount = _paymentBatch.Charges.ToList().Sum(i => i.PaidAmount);
                }
                else
                {
                    _paymentBatch.TotalAdjustmentAmount = 0;
                    _paymentBatch.TotalPaidAmount = 0;
                }

                _paymentBatchs.Add(_paymentBatch);
                _paymentBatch = new PaymentBatchDTO();
            }

            return _paymentBatchs;
        }

        /// <summary>
        /// Delete Invoice's Charge
        /// </summary>
        /// <param name="chargeUId"></param>
        /// <returns></returns>
        public async Task<int> DeleteCharge(Guid chargeUId, bool isDelete)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var charge = await this._chargesRepository.GetByUId(chargeUId);

                var chargeId = charge == null ? 0 : charge.Id;

                /*Check, claim has been made for given Charge, if claim has been made then it will not allow to delete
                  and give exception that, charge is being use in claim*/
                await this._claimChargeRepository.CheckForDelete(chargeId, isDelete);

                var paymentCharge = await this._paymentChargeRepository.DeleteByChargeId(charge.Id);
                /*Check, Payment has been made for given charge, if payment has been made then it will not allow to delete
                 and throw exception that charge is in use.
                 */
                //if (paymentCharge.Count() > 0)
                //    await this._chargesRepository.DeleteChargeValidation();

                /*Delete Charge if all validation is succeed*/

                int[] invoiceIds = { charge.InvoiceId };

                var chargeData = await this._chargesRepository.Get(invoiceIds);
                var charges = chargeData.Where(i => i.Id != chargeId);

                if (charges.Count() == 0)
                {
                    var invoiceData = await this._invoiceRepository.GetById(charge.InvoiceId);
                    await this._invoiceRepository.UpdateIsDeleted(invoiceData);
                }

                var patientId = await this._patientCaseRepository.GetPatientCase(charge.PatientCaseId);

                var deleted = await this._chargesRepository.Delete(chargeUId);
                await this._actionNoteRepository.AddPaymentNote((int)patientId.PatientId, chargeId, "Charge (#" + charge.ChargeNo + ") of $" + (charge.Amount) + " deleted.");

                this._transactionProvider.CommitTransaction(transactionId);

                return deleted;
                
            }
            catch (Exception ex)
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
            
        }

        private async Task<IEnumerable<ICharges>> Get(IEnumerable<ICharges> charges, Payment paymentData, IPaymentFilterDTO filter, DateTime? dos)
        {
            try
            {
                int[] chargeIds = charges.Select(i => i.Id).ToArray();
                var paymentChargeData = await this._paymentChargeRepository.GetByChargeId(chargeIds);

                foreach (var charge in charges)
                {
                    var defaultAdjustmentData = (await this._defaultReasonCodeRepository.GetAll()).ToList();
                    IPaymentCharge _paymentCharge = null;
                    List<IPaymentAdjustment> _paymentTotalAdjustmentData = new List<IPaymentAdjustment>();
                    IEnumerable<IPaymentCharge> paymentCharges = null;

                    if (paymentData != null)
                    {
                        //_paymentCharge = await this._paymentChargeRepository.GetByChargeId(charge.Id, paymentData.Id);
                        _paymentCharge = paymentChargeData.FirstOrDefault(i => i.ChargeId == charge.Id && i.PaymentId == paymentData.Id);
                        List<IPaymentAdjustment> _paymentAdjustmentData = null;

                        if (_paymentCharge != null)
                        {
                            var remarchCodes = await this._paymentRemarkCodeRepository.Get(_paymentCharge.Id);
                            charge.RemarkCodes = remarchCodes.Count() > 0 ? (remarchCodes).Select(i => i.RemarkCode).Aggregate((i, j) => i + "," + j) : "";
                            List<int> ids = new List<int>();

                            foreach (var item in remarchCodes)
                            {
                                var remarkIds = await this._configERARemarkCodesRepository.Get(charge.RemarkCodes);
                                var codeIds = remarkIds.FirstOrDefault(i => i.FullCode == item.RemarkQualifier + ' ' + item.RemarkCode);

                                if (codeIds != null)
                                    ids.Add(codeIds.Id);
                            }
                            charge.RemarkCodeIds = string.Join(',', ids);

                            var paymentChargesData = paymentChargeData.Where(i => i.ChargeId == charge.Id);
                            int[] paymentChargeIds = paymentChargesData.Select(i => i.Id).ToArray();

                            _paymentAdjustmentData = (await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds)).ToList();
                            _paymentTotalAdjustmentData = _paymentAdjustmentData;
                            _paymentAdjustmentData = _paymentAdjustmentData.Where(i => i.PaymentChargeId == _paymentCharge.Id).ToList();

                            defaultAdjustmentData = (await this.FilterDefaultCodes(_paymentAdjustmentData, defaultAdjustmentData, charge.Id)).ToList();
                        }
                    }

                    if (_paymentCharge == null)
                    {
                        var paymentChargesData = paymentChargeData.Where(i => i.ChargeId == charge.Id);
                        int[] paymentChargeIds = paymentChargesData.Select(i => i.Id).ToArray();

                        _paymentTotalAdjustmentData = (await this._paymentAdjustmentRepository.GetByPaymentChargeId(paymentChargeIds)).ToList();
                    }

                    defaultAdjustmentData.ToList().ForEach((defaultCode) =>
                    {
                        defaultCode.PaymentChargeId = charge.Id;
                    });

                    paymentCharges = paymentChargeData.Where(i => i.ChargeId == charge.Id);
                    charge.PaidAmount = (paymentData != null && _paymentCharge != null) ? _paymentCharge.PaidAmount : 0;
                    charge.Adjustments = defaultAdjustmentData;
                    charge.DOS = dos; //(await this._invoiceRepository.GetById(charge.InvoiceId)).DateOfSign.Value;
                    charge.TotalAdjustment = defaultAdjustmentData.Where(i => i.IsAccounted == true).ToList().Sum(i => i.AdjustmentAmount);
                    var withDenialAmount = defaultAdjustmentData.Where(i => i.IsDenial == true).ToList().Sum(i => i.AdjustmentAmount);
                    charge.PreviousPaid = (paymentCharges.Sum(i => i.PaidAmount) + _paymentTotalAdjustmentData.Where(i => i.IsAccounted == true).Sum(i => i.Amount)) - (charge.PaidAmount + charge.TotalAdjustment);
                    //charge.DueAmount = charge.Amount - paymentChargeData.Sum(i => i.PaidAmount);

                    charge.DueAmount = (charge.Amount - ((paymentCharges.Sum(i => i.PaidAmount)) + _paymentTotalAdjustmentData.Where(i => i.IsAccounted == true).Sum(i => i.Amount)));
                    //charge.DueAmount = (charge.Amount - (charge.PreviousPaid));
                    // charge.DueAmount = charge.AllowedAmount == null ? (charge.Amount - charge.TotalAdjustment) : (charge.AllowedAmount.Value - (charge.PaidAmount + charge.TotalAdjustment));
                    _logger.LogInformation("Paid Amount -- " + charge.PaidAmount);
                    _logger.LogInformation("TotalAdjustment Amount -- " + charge.TotalAdjustment);
                    _logger.LogInformation("withDenial Amount -- " + withDenialAmount);
                    _logger.LogInformation("charges Count  -- " + charges.Count());

                    if (filter.IsShowOnlyRecorded)
                    {
                        charge.BonusAmount = charge.BonusAmount == null ? 0 : charge.BonusAmount;
                        if (charge.PaidAmount == 0 && withDenialAmount == 0 && charge.TotalAdjustment == 0 && charge.BonusAmount == 0)
                            charges = charges.Where(i => i.Id != charge.Id).ToList();

                        _logger.LogInformation("charges Count  -- " + charges.Count());
                    }

                }

                return charges;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetLockedChargesForACK()
        {
            //string[] str = { ".", "-" };
            List<string> str = new List<string>() { ".","-"};

            var list = await this._chargesRepository.GetLockedCharges();                        
            list = list.Where(i => !string.IsNullOrWhiteSpace(i.ActualEncounter));
            list = list.Where(i => !string.IsNullOrWhiteSpace(i.RolledUpEncounter));

            List<IRolledUpEncounterDTO> listFinal = new List<IRolledUpEncounterDTO>();
            foreach (var item in list)
            {
                if(!item.ActualEncounter.Contains("-") && !item.RolledUpEncounter.Contains("-"))
                {
                    listFinal.Add(item);
                }
            }

            if (listFinal.Count()>0)
            {
                var status=await this._patientRepository.SendRolledUpChargesToEMR(listFinal);
                if(status==true)
                    await this._chargesRepository.UpdateIsRolledUpNotifyToEMR(list);
            }

            return "";
        }

        public async Task<string> GetForPaymentACK()
        {
            try
            {
                //Notes: We need to ignore T and J code then keep in separate list and work with them.
                // ever time have to find with in Query with .1 and without
                // If J0754 comes with Accession 125631, then we need to send 125631,125631.1 and get the sum and same if 125631.1 comes then 125631.1,125631

                var paymentList = await this._paymentRepository.GetPaymetnsForACK();

                int[] paymentsIds = paymentList.Select(i => i.Id).Take(200).ToArray();
                var paymentChargeData = await this._paymentChargeRepository.GetBulkPaymentChargeForACK(paymentsIds);
                if(paymentChargeData!=null && paymentChargeData.Count()>0)
                {
                    foreach (var charge in paymentChargeData)
                    {

                        var remarchCodes = await this._paymentRemarkCodeRepository.Get(charge.PaymentChargeId);
                        charge.RemarkCode = remarchCodes.Count() > 0 ? (remarchCodes).Select(i => i.RemarkCode).Aggregate((i, j) => i + "," + j) : "";

                        var adjustmentData = (await this._paymentAdjustmentRepository.GetByPaymentChargeId(charge.PaymentChargeId)).ToList();
                        charge.AdjustmentCode = adjustmentData.Count() > 0 ? (adjustmentData).Select(i => i.ReasonCode).Aggregate((i, j) => i + "," + j) : "";
                    }

                    var distinctCases = paymentChargeData.Select(i => i.AccessionNumber).Distinct();
                    var accessWisePaymentAndAdjustments = await this._invoiceRepository.GetInvoicePaymentAdjustments(distinctCases.ToList());
                    List<IEMRChargeStatus> listEMRChargeStatus = new List<IEMRChargeStatus>();
                    foreach (var item in distinctCases)
                    {
                        if(item!=null)
                        {
                            if(item.Contains("-"))
                            {
                                continue;
                            }
                            if (item.Contains("."))
                            {
                                continue;
                            }
                            EMRChargeStatus obj = new EMRChargeStatus();
                            obj.BillingId = Convert.ToInt32(item);
                            obj.PaidAmount = accessWisePaymentAndAdjustments.FirstOrDefault(i => i.AccessionNumber == item).PaidAmount;
                            obj.AdjustmentAmount = accessWisePaymentAndAdjustments.FirstOrDefault(i => i.AccessionNumber == item).TotalAdjustment;
                            obj.DueAmount = accessWisePaymentAndAdjustments.FirstOrDefault(i => i.AccessionNumber == item).DueAmount;
                            //obj.PaidAmount = paymentChargeData.Where(i => i.AccessionNumber == item).Sum(i => i.TotalPaidAmount);
                            //obj.AdjustmentAmount = paymentChargeData.Where(i => i.AccessionNumber == item).Sum(i => i.TotalAdjustment);
                            obj.DueBy = paymentChargeData.Where(i => i.AccessionNumber == item).Select(i => i.DueBy).Distinct().Aggregate((i, j) => i + "," + j);
                            obj.AdjustmentCode = paymentChargeData.Where(i => i.AccessionNumber == item).Select(i => i.AdjustmentCode).Distinct().Aggregate((i, j) => i + "," + j);
                            obj.RemarkCode = paymentChargeData.Where(i => i.AccessionNumber == item).Select(i => i.RemarkCode).Distinct().Aggregate((i, j) => i + "," + j);
                            var denialCase = paymentChargeData.FirstOrDefault(i => i.HasDenial == true && i.AccessionNumber == item);
                            if (denialCase != null)
                                obj.HasDenial = true;
                            else
                                obj.HasDenial = false;
                            listEMRChargeStatus.Add(obj);
                        }                        
                    }

                    if (listEMRChargeStatus.Count() > 0)
                    {
                        await this._patientRepository.SendClaimSentAcknowledgementToEMR(listEMRChargeStatus);
                        await this.UpdatePaymentListAfterNotifyToEMR(paymentsIds);
                    }
                }
                else
                {
                    if(paymentsIds.Count()>0)
                    {
                        await this.UpdatePaymentListAfterNotifyToEMR(paymentsIds);
                    }
                }
                return "true";
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private async Task<bool> UpdatePaymentListAfterNotifyToEMR(IEnumerable<int> lst)
        {

            foreach (var item in lst)
            {
                await this._paymentRepository.UpdateSentAckToEMR(item);
            }
            return true;
        }

        private async Task<IEnumerable<IDefaultReasonCode>> FilterDefaultCodes(IEnumerable<IPaymentAdjustment> _paymentAdjustmentData, List<IDefaultReasonCode> defaultAdjustmentData, int chargeId)
        {
            foreach (var code in _paymentAdjustmentData)
            {
                DefaultReasonCode adjustment = new DefaultReasonCode();

                var returnResult = defaultAdjustmentData.ToList().Find(i => i.Code == code.ReasonCode);
                if (returnResult != null)
                {
                    if (returnResult.Code.ToLower() == AdjustmentCodes.CO45.ToString().ToLower())
                    {
                        returnResult.Id = code.Id;
                        returnResult.Uid = code.UId;
                    }

                    returnResult.AdjustmentAmount = code.Amount;
                    returnResult.IsDenial = code.IsDenial;
                    returnResult.IsAccounted = code.IsAccounted;
                    returnResult.PaymentChargeId = chargeId;
                }
                else
                {
                    adjustment.Id = code.Id;
                    adjustment.AdjustmentAmount = code.Amount;
                    adjustment.Code = code.ReasonCode;
                    adjustment.DisplayName = code.ReasonCode;
                    adjustment.IsFixed = false;
                    adjustment.PaymentChargeId = chargeId;
                    adjustment.Uid = code.UId;
                    adjustment.IsAccounted = code.IsAccounted;
                    adjustment.IsDenial = code.IsDenial;

                    defaultAdjustmentData.Add(adjustment);
                }
            }

            return defaultAdjustmentData;
        }

        private async Task<IEnumerable<ICharges>> GetPendingPayment(int invoiceId, IEnumerable<int> patientCaseIds, bool IsShowOnlyClaimed)
        {
            int[] invoiceIds = { invoiceId };
            var pendingCharge = await this._chargesRepository.GetView
                (invoiceIds, patientCaseIds, IsShowOnlyClaimed);
            return pendingCharge;
        }

        /// <summary>
        /// Convert CPT Code to G-Code, if insurance company accept G-Code.
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public async Task<int> UpdateGCCode(string invoiceUId)
        {
            try
            {
                var invoice = await this._invoiceRepository.GetByUId(Guid.Parse(invoiceUId));
                var invoiceId = invoice == null ? 0 : invoice.Id;
                List<IInsurancePolicy> policies = new List<IInsurancePolicy>();
                var gcodeEntry = await this._chargesRepository.GetGcCodeEntry(invoice.Id);
                if (gcodeEntry != null)
                {
                    var paymentCharge = await this._paymentChargeRepository.GetByChargeId(gcodeEntry.Id);
                    if (paymentCharge.Count() > 0)
                    {
                        await this._paymentRepository.DeleteByChargeId(gcodeEntry.Id);
                    }

                    var claimData = await this._claimChargeRepository.GetByIds(gcodeEntry.Id);
                    if (claimData.Count() > 0)
                    {
                        int[] claimIds = claimData.Select(i => i.ClaimId).ToArray();

                        await this._claimTotalRepository.DeleteByClaimId(claimIds);
                        await this._claimChargeRepository.DeleteByClaimId(claimIds);
                        await this._actionNoteRepository.UpdateClaim(claimIds);
                        await this._claimRepository.Delete(claimIds);
                        invoice.ClaimId = null;
                        await this._invoiceRepository.UpdateClaimId(invoice);
                    }

                    await this._actionNoteRepository.DeleteByChargeId(gcodeEntry.Id);
                }

                var result = await this._chargesRepository.DeleteGcCodeEntry(invoiceId);
                if (result != 0)
                {
                    var drugRecords = await this._drugChargeRepository.GetByInvoice(invoice.UId.ToString());
                    //var chargeData = await this._chargesRepository.Get(invoice.Id);

                    foreach (var item in drugRecords)
                    {
                        if (item.BillToInsurance)
                            policies = (await this._insurancePolicyRepository.GetPolicies(invoice.PatientCaseId, item.BillFromDate)).ToList();
                        item.Id = 0;//chargeData.LastOrDefault(i => i.CPTCode == item.CPTCode) == null ? 0 : chargeData.LastOrDefault(i => i.CPTCode == item.CPTCode).Id;
                        item.InvoiceId = invoiceId;
                        item.ICD1 = gcodeEntry == null ? item.ICD1 : gcodeEntry.ICD1;
                        item.ICD2 = gcodeEntry == null ? item.ICD2 : gcodeEntry.ICD2;
                        item.ICD3 = gcodeEntry == null ? item.ICD3 : gcodeEntry.ICD3;
                        item.ICD4 = gcodeEntry == null ? item.ICD4 : gcodeEntry.ICD4;

                        // if (item.Id == 0)
                        await this._chargesRepository.AddNew(item, policies);
                        //else
                        //    await this._chargesRepository.UpdateIsDeleted(item.Id);
                    }

                    await this._drugChargeRepository.DeletByInvoice(invoiceId);
                }
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CheckGCCode(string invoiceUId)
        {
            try
            {
                var invoice = await this._invoiceRepository.GetByUId(Guid.Parse(invoiceUId));
                var invoiceId = invoice == null ? 0 : invoice.Id;
                List<IInsurancePolicy> policies = new List<IInsurancePolicy>();
                var gcodeEntry = await this._chargesRepository.GetGcCodeEntry(invoice.Id);
                if (gcodeEntry != null)
                {
                    var paymentCheck = await this._paymentChargeRepository.GetByChargeId(gcodeEntry.Id);
                    if (paymentCheck.Count() > 0)
                        return 2;

                    var result = await _claimChargeRepository.GetByChargeId(gcodeEntry.Id);
                    if (result != null)
                        return 1;
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetDrugCharge(string invoiceUId)
        {
            return await this._drugChargeRepository.GetByInvoice(invoiceUId);
        }

        /// <summary>
        /// Delete Charge Batch
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public async Task<int> Delete(string chargeBatchUId)
        {
            /*fetch Invoices for given batch*/

            var invoiceData = await this._invoiceRepository.GetByBatchUId(chargeBatchUId);
            /*check batch, if given batch contains invoices then throw exception that charge batch is in use*/
            if (invoiceData.Count() > 0)
                await this._chargeBatchRepository.ThrowError();

            return await this._chargeBatchRepository.Delete(new Guid(chargeBatchUId));
        }

        /// <summary>
        /* HL7 file only provide CPT Code not it's description
         * Fill CPT Code descriptions for hl7 data
         * */
        /// </summary>
        /// <param name="charges"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ICharges>> FillCPTDesc(IEnumerable<ICharges> charges)
        {
            try
            {
                foreach (var item in charges)
                {
                    var result = await this._cPTCodeRepository.GetCPTCode(item.CPTCode);
                    if (result != null)
                    {
                        /*Set Description for CPT Code*/
                        item.Description = result.Description;

                        /*Set Place of Service for CPT Code*/
                        item.POSId = result.DefaultPOSId;

                        /*Set Type of service for CPT Code*/
                        item.TOSId = result.DefaultTOSId;
                        item.IsCPTExistInFavList = true;
                        /*Set Quantity for CPT Code*/
                        item.Qty = result.DefaultQuantity ?? 1;
                        /*Set CPT Code is for Insurance or Patient, if CPT's BillToInsurance is true then CPT
                         would be for Insurance otherwise it would be for patient*/
                        item.BillToInsurance = result.BillToInsurance;
                    }
                    else
                        item.IsCPTExistInFavList = false;
                }
                return charges;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IStatementDTO> GetStatement(Guid patientUId, DateTime fromDate, DateTime toDate)
        {
            IStatementDTO statementDTO = null;
            decimal paymentAmount = 0;
            decimal adjustmentAmount = 0;

            var patientData = await this._patientRepository.GetByUId(patientUId);
            statementDTO = await this._patientRepository.GetStatement(patientData.Id);
            List<int> patientIds = new List<int>() { patientData.Id };
            var patientCaseIds = (await this._patientCaseRepository.GetPatient(patientIds)).Select(i => i.Id);
            statementDTO.PatientCharges = await this._chargesRepository.GetStatement(patientCaseIds, fromDate.Date, toDate.Date);

            foreach (var item in statementDTO.PatientCharges)
            {
                int[] ids = { item.ChargeId };
                item.PaymentCharges = await this._paymentChargeRepository.GetByChargeIds(ids);
                paymentAmount = paymentAmount + item.PaymentCharges.Sum(i => i.PaidAmount);

                int[] adjIds = item.PaymentCharges.Select(i => i.Id).ToArray();
                var paymentAdjustments = await this._paymentAdjustmentRepository.GetByPaymentChargeId(adjIds);
                adjustmentAmount = adjustmentAmount + paymentAdjustments.Where(i => i.IsAccounted == true && i.IsDenial == false).Sum(i => i.Amount);

                foreach (var payment in item.PaymentCharges)
                {
                    payment.PaymentAdjustments = paymentAdjustments.Where(i => i.PaymentChargeId == payment.Id && i.IsAccounted == true && i.IsDenial == false);
                }
            }

            var totalCharges = statementDTO.PatientCharges.Sum(i => i.ChargeAmount);
            statementDTO.PatientChargesStatementFooterDTO.TotalDues = totalCharges - (paymentAmount + adjustmentAmount);
            statementDTO.PatientChargesStatementFooterDTO.AmountDues = statementDTO.PatientCharges.Sum(i => i.BalanceAmount);
            statementDTO.PatientChargesStatementFooterDTO.DueDate = DateTime.Now.Date;

            var patientStatementObject = await this.CreateStatementObject(patientData.Id, fromDate, toDate);
            await this._patientStatementRepository.AddNew(patientStatementObject);

            return statementDTO;
        }

        private async Task<IPatientStatement> CreateStatementObject(int patientId, DateTime fromDate, DateTime toDate)
        {
            PatientStatement patientStatement = new PatientStatement();
            patientStatement.FromDate = fromDate.Date;
            patientStatement.ToDate = toDate.Date;
            patientStatement.PatientId = patientId;

            return patientStatement;
        }

        public async Task<IInvoiceBillingHistoryDTO> GetBillingHistoryInvoiceForEMR(string billingId)
        {
            
            InvoiceBillingHistoryDTO billingHistoryPatientDetail = new InvoiceBillingHistoryDTO();
            InvoiceBillHistoryFilter filterBill = new InvoiceBillHistoryFilter();
            PaymentBillingHistoryFilter paymentBillingHistoryFilter = new PaymentBillingHistoryFilter();
            IChargePaymentBillingHistoryFilter filter =new ChargePaymentBillingHistoryFilter();

            var patient = await this._patientRepository.PatientByBillingId(billingId);
            if(patient==null)
            {
                return null;
            }
            
            filter.PatientCaseId = patient.DefaultCaseId.Value;

            filterBill = _mapper.Map<InvoiceBillHistoryFilter>(filter);
            paymentBillingHistoryFilter.FromDate = filter.FromDate;
            paymentBillingHistoryFilter.ToDate = filter.ToDate;
            paymentBillingHistoryFilter.isPayment = true;
            paymentBillingHistoryFilter.ChargeIds = new List<int>();

            

            filter.isPayment = 1;
            billingHistoryPatientDetail.Charges = await this._chargesRepository.GetCharges(filter);
           // billingHistoryPatientDetail.RollUpCharges = await this._chargesRepository.GetRollUpCharges(filter);
          //  billingHistoryPatientDetail.DuplicateCharges = await this._chargesRepository.DuplicateCharges(filter);

            paymentBillingHistoryFilter.isPayment = false;
            int[] Ids = billingHistoryPatientDetail.Charges.Select(i => i.Id).ToArray();
            paymentBillingHistoryFilter.ChargeIds = Ids;
            var paymentData = await this._paymentChargeRepository.Get(paymentBillingHistoryFilter, patient.Id);

            var patientCase = await this._patientCaseRepository.GetById(filter.PatientCaseId);

            var policies = await this._insurancePolicyRepository.GetByPatientCaseUIds(patientCase.UId.ToString());
            foreach (var item in billingHistoryPatientDetail.Charges)
            {
                item.PaymentCharges = paymentData.Where(i => i.ChargeId == item.Id);
                var selfPayment = item.PaymentCharges.Where(i => i.IsSelfPayment == true).Sum(i => i.PaidAmount);
                if(selfPayment>0)
                {
                    item.PatientPayment = selfPayment;
                    if (item.TotalPaidAmount >= selfPayment)
                        item.InsurancePayment = item.TotalPaidAmount - selfPayment;
                    else
                        item.InsurancePayment = item.TotalPaidAmount;
                }
                else
                {
                    item.PatientPayment = 0;
                    item.InsurancePayment = item.TotalPaidAmount;
                }


                item.IsChanged = item.PaymentCharges.Where(i => i.IsDenial == true).Count() > 0 ? true : false; // ischarged means is denial
                item.DenialAmount = item.PaymentCharges.Sum(i => i.DenialAmount);
                item.ChargeScrubs = new ChargeScrub();                

                if (string.IsNullOrWhiteSpace(item.DueByFlagCD))
                {
                    if (item.BillToPatient == true)
                    {
                        item.DueByFlagCD = "Patient";
                    }
                }

                if (item.DueByFlagCD.ToLower() == "patient")
                {
                    var findMedicaid = policies.FirstOrDefault(i => i.PlanEffectiveDate <= item.BillFromDate.Date &&
                    ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue && i.PlanExpirationDate >= item.BillFromDate.Date))
                    && i.InsuranceCompanyTypeId == 4);
                    if (findMedicaid != null)
                    {
                        item.IsMedicaidPatientDue = true;
                    }
                }
            }

            return billingHistoryPatientDetail;
        }

        public async Task<IInvoiceBillingHistoryDTO> GetBillingHistoryInvoice(IChargePaymentBillingHistoryFilter filter)
        {
            IPatientCase patientCaseData = null;
            InvoiceBillingHistoryDTO billingHistoryPatientDetail = new InvoiceBillingHistoryDTO();
            InvoiceBillHistoryFilter filterBill = new InvoiceBillHistoryFilter();
            PaymentBillingHistoryFilter paymentBillingHistoryFilter = new PaymentBillingHistoryFilter();

            if (filter.PatientCaseUId != null)
                patientCaseData = await this._patientCaseRepository.GetByUId(Guid.Parse(filter.PatientCaseUId));

            filter.PatientCaseId = filter.PatientCaseUId == null ? 0 : (patientCaseData).Id;

            filter.FromDate = filter.FromDate.Contains("NaN") ? null : Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00");
            filter.ToDate = filter.ToDate.Contains("NaN") ? null : Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59");

            filterBill = _mapper.Map<InvoiceBillHistoryFilter>(filter);
            paymentBillingHistoryFilter.FromDate = filter.FromDate;
            paymentBillingHistoryFilter.ToDate = filter.ToDate;
            paymentBillingHistoryFilter.isPayment = true;
            paymentBillingHistoryFilter.ChargeIds = new List<int>();

            billingHistoryPatientDetail.PaymentCharges = await this._paymentChargeRepository.Get(paymentBillingHistoryFilter, patientCaseData.PatientId);
            //billingHistoryPatientDetail.PaymentCharges = billingHistoryPatientDetail.PaymentCharges.Where(i => i.PatientCaseId == filter.PatientCaseId);

            billingHistoryPatientDetail.PaymentsCount = billingHistoryPatientDetail.PaymentCharges.Count();

            //billingHistoryPatientDetail.Invoices = await this._invoiceRepository.GetInvoices(filterBill);
            //billingHistoryPatientDetail.Invoices = billingHistoryPatientDetail.Invoices.OrderByDescending(i => i.BillFromDate);

            
            filter.isPayment = 1;
            var chargesList= await this._chargesRepository.GetChargesNew(filter);
            billingHistoryPatientDetail.Charges = chargesList.Where(i=>i.IsDeleted==false);
            billingHistoryPatientDetail.RollUpCharges = chargesList.Where(i => i.IsLocked == true); //await this._chargesRepository.GetRollUpCharges(filter);
            billingHistoryPatientDetail.DuplicateCharges = chargesList.Where(i => (i.IsDuplicate.HasValue && i.IsDuplicate == true));//await this._chargesRepository.DuplicateCharges(filter);
            billingHistoryPatientDetail.Charges = await this.Get(billingHistoryPatientDetail.Charges, filter.ChargesFilter);
            billingHistoryPatientDetail.RejectedCharges = chargesList.Where(i => i.IsRejected == true); //await this._chargesRepository.GetRejectedCharges(filter);

            int[] invoiceIds = billingHistoryPatientDetail.Charges.Select(i => i.InvoiceId).Distinct().ToArray();

            billingHistoryPatientDetail.Invoices = await this._invoiceRepository.GetInvoicesByIds(invoiceIds);
            billingHistoryPatientDetail.Invoices = billingHistoryPatientDetail.Invoices.OrderByDescending(i => i.BillFromDate);

            foreach (var item in billingHistoryPatientDetail.Invoices)
            {
                item.BillFromDate = billingHistoryPatientDetail.Charges.Where(i => i.InvoiceId == item.Id).Max(i => i.BillFromDate);
                item.BillToDate = item.BillFromDate;
            }


            //int[] chargeIds = billingHistoryPatientDetail.Charges.Where(i => i.ScrubError == true).Select(i => i.Id).ToArray();
            //var chargeScrub = await this._chargeScrubRepository.GetByChargeIds(chargeIds);

            paymentBillingHistoryFilter.isPayment = false;
            int[] Ids = billingHistoryPatientDetail.Charges.Select(i => i.Id).ToArray();
            paymentBillingHistoryFilter.ChargeIds = Ids;
            var paymentData = await this._paymentChargeRepository.Get(paymentBillingHistoryFilter, patientCaseData.PatientId);

            var paymentIds = paymentData.Select(i => i.PaymentId.ToString()).Distinct();

            var eraClaims = await this._iERAClaimRepository.GetbyPaymentIds(paymentIds);


            foreach (var item in billingHistoryPatientDetail.PaymentCharges)
            {
                var eraClaim = eraClaims.FirstOrDefault(i => Convert.ToInt32(i.PaymentUID) == item.PaymentId);
                if (eraClaim != null)
                {
                    item.PatientAccountNumber = eraClaim.PatientControlNumber;
                    if(eraClaim.ClaimLevel.HasValue)
                    item.ClaimLevel = eraClaim.ClaimLevel.Value.ToString();
                }
            }

            foreach (var item in paymentData)
            {
                var eraClaim = eraClaims.FirstOrDefault(i => Convert.ToInt32(i.PaymentUID) == item.PaymentId);
                if (eraClaim != null)
                {
                    item.PatientAccountNumber = eraClaim.PatientControlNumber;
                    if (eraClaim.ClaimLevel.HasValue)
                        item.ClaimLevel = eraClaim.ClaimLevel.Value.ToString();
                }
            }
            var policies = await this._insurancePolicyRepository.GetByPatientCaseUIds(filter.PatientCaseUId);
            foreach (var item in billingHistoryPatientDetail.Charges)
            {
                item.PaymentCharges = paymentData.Where(i => i.ChargeId == item.Id);
                item.IsChanged = item.PaymentCharges.Where(i => i.IsDenial == true).Count() > 0 ? true : false; // ischarged means is denial
                item.DenialAmount = item.PaymentCharges.Sum(i => i.DenialAmount);
                item.ChargeScrubs = new ChargeScrub();
                if (string.IsNullOrWhiteSpace(item.DueByFlagCD))
                {
                    if (item.BillToPatient == true)
                    {
                        item.DueByFlagCD = "Patient";
                    }
                }
                if(item.DueByFlagCD.ToLower()=="patient")
                {
                    var findMedicaid = policies.FirstOrDefault(i => i.PlanEffectiveDate <= item.BillFromDate.Date &&
                    ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue && i.PlanExpirationDate>=item.BillFromDate.Date))
                    && i.InsuranceCompanyTypeId == 4);
                    if (findMedicaid != null)
                    {
                        item.InsuranceCompanyName = findMedicaid.InsuranceCompanyName;
                        item.IsMedicaidPatientDue = true;
                    }
                }
                // && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&  i.PlanExpirationDate.Value.Date >= hL7FileDTOT.Invoice.BillFromDate))
            }


            //var patientChargesByCase= await this._chargesRepository.GetChargesByPatientCaseId(filter);

            //billingHistoryPatientDetail.TotalCharges = patientChargesByCase.Sum(i => i.Amount);
            //billingHistoryPatientDetail.TotalDenialAmount = patientChargesByCase.Sum(i => i.DenialAmount);
            //billingHistoryPatientDetail.DueByinsurance = patientChargesByCase.Where(i => i.DueByFlagCD.ToLower() != "patient" && i.IsChanged == false).Sum(i => i.DueAmount);
            //billingHistoryPatientDetail.DueByPatient = patientChargesByCase.Where(i => i.DueByFlagCD.ToLower() == "patient").Sum(i => i.DueAmount);
            //billingHistoryPatientDetail.TotalPaid = patientChargesByCase.Sum(i => i.TotalPaidAmount);
            //billingHistoryPatientDetail.TotalAdjustmentAmount = patientChargesByCase.Sum(i => i.TotalAdjustment);
            List<string> duyBy = new List<string>() { "", "patient" };

            billingHistoryPatientDetail.TotalCharges = billingHistoryPatientDetail.Charges.Sum(i => i.Amount);
            billingHistoryPatientDetail.TotalDenialAmount = billingHistoryPatientDetail.Charges.Where(i=>i.IsDenial==true).Sum(i => i.DueAmount);
            billingHistoryPatientDetail.DueByinsurance = billingHistoryPatientDetail.Charges.Where(i => !duyBy.Contains(i.DueByFlagCD.ToLower())).Sum(i => i.DueAmount);
            billingHistoryPatientDetail.DueByPatient = billingHistoryPatientDetail.Charges.Where(i => i.IsMedicaidPatientDue==false  && duyBy.Contains(i.DueByFlagCD.ToLower())).Sum(i => i.DueAmount);
            billingHistoryPatientDetail.DueByMedicaidPatient = billingHistoryPatientDetail.Charges.Where(i => i.IsMedicaidPatientDue == true && duyBy.Contains(i.DueByFlagCD.ToLower())).Sum(i => i.DueAmount);
            billingHistoryPatientDetail.MedicaidPatientCharges = billingHistoryPatientDetail.Charges.Where(i => i.IsMedicaidPatientDue == true && duyBy.Contains(i.DueByFlagCD.ToLower()));

            //var positiveAmount= billingHistoryPatientDetail.Charges.Where(i => i.DueAmount > 0 && duyBy.Contains(i.DueByFlagCD.ToLower())).Sum(i => i.DueAmount);
            //var negativeAmount = billingHistoryPatientDetail.Charges.Where(i => i.DueAmount < 0 && duyBy.Contains(i.DueByFlagCD.ToLower())).Sum(i => i.DueAmount);
            //if(positiveAmount==0 && negativeAmount<0)
            //{
            //    billingHistoryPatientDetail.DueByPatient = negativeAmount;
            //}
            //else
            //{
            //    billingHistoryPatientDetail.DueByPatient = positiveAmount;
            //}


            billingHistoryPatientDetail.TotalPaid = billingHistoryPatientDetail.Charges.Sum(i => i.TotalPaidAmount);
            billingHistoryPatientDetail.TotalAdjustmentAmount = billingHistoryPatientDetail.Charges.Sum(i => i.TotalAdjustment);

            billingHistoryPatientDetail.Invoices.ToList().ForEach((item) =>
            {
                filter.InvoiceUId = item.InvoiceUId.ToString();
                item.ChargeList = billingHistoryPatientDetail.Charges.Where(i => i.InvoiceId == item.InvoiceId);
                //.Where(i => i.IsChanged == false)
                item.TotalCharges = item.ChargeList.Sum(i => i.Amount);
                //.Where(i => i.IsChanged == false)
                item.TotalPaid = item.ChargeList.Sum(i => i.TotalPaidAmount);
                //.Where(i => i.IsChanged == false)
                //.Where(i => i.IsChanged == false)
                item.TotalAdjustment = item.ChargeList.Sum(i => i.TotalAdjustment);
                item.TotalDue = (item.TotalCharges - (item.TotalPaid + item.TotalAdjustment));
                //.Where(i => i.IsChanged == false)
                item.InsuranceBalance = item.ChargeList.Sum(i => (i.DueByFlagCD.ToLower() != "patient" ? i.DueAmount : 0));
                //.Where(i => i.IsChanged == false)
                item.PatientBalance = item.ChargeList.Sum(i => (i.DueByFlagCD.ToLower() == "patient" ? i.DueAmount : 0));
            });

            billingHistoryPatientDetail.Invoices = await this.Get(billingHistoryPatientDetail.Invoices, billingHistoryPatientDetail.Charges, filter.ChargesFilter);
            return billingHistoryPatientDetail;
        }

        /// <summary>
        /// Fetch Billing Summary according to charge filter
        /// </summary>
        /// <param name="charges"></param>
        /// <param name="chargeFilter"></param>
        /// <returns></returns>
        private async Task<IEnumerable<ICharges>> Get(IEnumerable<ICharges> charges, int chargeFilter)
        {
            List<ICharges> chargesList = new List<ICharges>();
            switch (chargeFilter)
            {
                /*Filter charges which are due by patient only*/
                case 1:
                    var dueByPatientCharges = charges.Where(i => i.DueAmount > 0 && i.DueByFlagCD.ToLower() == "patient");
                    chargesList.AddRange(dueByPatientCharges);
                    break;

                /*Filter charges which are due by Insurance only*/
                case 2:
                    var dueByInsuranceCharges = charges.Where(i => i.DueAmount > 0 && i.DueByFlagCD.ToLower() != "patient");
                    chargesList.AddRange(dueByInsuranceCharges);
                    break;

                /*add all given charges*/
                case 3:
                    chargesList.AddRange(charges);
                    break;
                default:
                    var dueCharges = charges.Where(i => i.DueAmount != 0);
                    chargesList.AddRange(dueCharges);
                    break;
            }

            return chargesList;
        }

        /// <summary>
        /// Get Billing Summary according to filters
        /// </summary>
        /// <param name="invoices"></param>
        /// <param name="charges"></param>
        /// <param name="chargeFilter"></param>
        /// <returns></returns>
        private async Task<IEnumerable<IInvoice>> Get(IEnumerable<IInvoice> invoices, IEnumerable<ICharges> charges, int chargeFilter)
        {
            List<IInvoice> invoicesList = new List<IInvoice>();
            switch (chargeFilter)
            {
                /*fetch invoice and their charges which are due by patient only*/
                case 1:
                    var dueByPatientInvoice = invoices.Where(i => i.TotalDue > 0);
                    if (charges.Count() > 0)
                        invoicesList.AddRange(dueByPatientInvoice);
                    break;

                /*fetch invoice and their charges which are due by insurance only*/
                case 2:
                    var dueByInsuranceInvoice = invoices.Where(i => i.TotalDue > 0);
                    if (charges.Count() > 0)
                        invoicesList.AddRange(dueByInsuranceInvoice);
                    break;

                /*fetch invoice and their charges.*/
                case 3:
                    invoicesList.AddRange(invoices);
                    break;

                default:
                    var dueInvoice = invoices.Where(i => i.TotalDue != 0);
                    invoicesList.AddRange(dueInvoice);
                    break;
            }

            return invoicesList;
        }

        public async Task<IEnumerable<IBalanceCharge>> GetChargesForAdjustment(Guid patientUId)
        {
            var patientData = await this._patientRepository.GetByUId(patientUId);
            var chargesList = await this._chargesRepository.GetChargesForAdjustment(patientData.DefaultCaseId.Value);

            return chargesList;
        }

        public async Task<IEnumerable<IDropDownDTO>> GetAccessionNumber(Guid patientUId)
        {
            List<DropDownDTO> dropDownDTOs = new List<DropDownDTO>();

            var patientData = await this._patientRepository.GetByUId(patientUId);
            patientData.DefaultCaseId = patientData == null ? 0 : patientData.DefaultCaseId;

            var invoiceData = await this._invoiceRepository.GetAllAccessionNumber(patientData.DefaultCaseId);
            int[] InvoiceIds = invoiceData.Select(i => i.Id).ToArray();

            var chargesData = await this._chargesRepository.Get(InvoiceIds);

            foreach (var item in invoiceData)
            {
                var chargeData = chargesData.Where(i => i.InvoiceId == item.Id);
                //int[] chargeIds = chargeData.Select(i => i.Id).ToArray();
                //var paymentData = await this._paymentChargeRepository.GetByChargeIds(chargeIds);

                //if (paymentData.Count() == 0)
                //{
                dropDownDTOs.Add(await this.CreateObject(item) as DropDownDTO);
                //}
            }

            return dropDownDTOs;
        }

        public async Task<IEnumerable<IDropDownDTO>> GetAccessionNumbersForRolledUp(Guid patientUId)
        {
            List<DropDownDTO> dropDownDTOs = new List<DropDownDTO>();

            var patientData = await this._patientRepository.GetByUId(patientUId);
            patientData.DefaultCaseId = patientData == null ? 0 : patientData.DefaultCaseId;

            var invoiceData = await this._invoiceRepository.GetAllAccessionNumberForRolledUp(patientData.DefaultCaseId);
            int[] InvoiceIds = invoiceData.Select(i => i.Id).ToArray();

            var chargesData = await this._chargesRepository.Get(InvoiceIds);

            foreach (var item in invoiceData)
            {
                var chargeData = chargesData.Where(i => i.InvoiceId == item.Id);
                //int[] chargeIds = chargeData.Select(i => i.Id).ToArray();
                //var paymentData = await this._paymentChargeRepository.GetByChargeIds(chargeIds);

                //if (paymentData.Count() == 0)
                //{
                dropDownDTOs.Add(await this.CreateObjectWithAccessionNumber(item) as DropDownDTO);
                //}
            }

            return dropDownDTOs;
        }

        public async Task<IEnumerable<IDropDownDTO>>GetAccessionNumberForRolledUpChild(Guid invoiceUId)
        {
            var list =await this._chargesRepository.GetAccessionForEolledUpchild(invoiceUId);
            List<DropDownDTO> dropDownDTOs = new List<DropDownDTO>();
            foreach (var item in list)
            {
                dropDownDTOs.Add(await this.CreateObjectWithAccessionNumber(item) as DropDownDTO);
            }
            return dropDownDTOs;
        }

        public async Task<int> RolledUpCharges(Guid parentInvoiceUId,Guid childInvoiceUid)
        {
            var parentCharges = await this._chargesRepository.GetByInvoiceId(parentInvoiceUId);

            var childCharges = await this._chargesRepository.GetByInvoiceId(childInvoiceUid);

            bool isNotBiilable = false;
            string comments = "";

            foreach (var item in childCharges)
            {
                //var chargeList = await this._chargesRepository.GetExistsChargeForRollUp(parentCharges.FirstOrDefault().Id, item.PatientCaseId, item.PerformingProviderId.Value, item.CPTCode);

                var chargeItem = parentCharges.FirstOrDefault(i => i.BillFromDate.Date == item.BillFromDate.Date
                    && i.BillFromDate.Day == item.BillFromDate.Day
                    && i.BillFromDate.Year == item.BillFromDate.Year);

                if (chargeItem != null)
                {
                    isNotBiilable = true;

                    var amount = chargeItem.Amount / chargeItem.Qty;
                    chargeItem.Qty += item.Qty;
                    chargeItem.Amount = amount * chargeItem.Qty;
                    chargeItem.FeeAmount = (chargeItem.FeeAmount == null ? 0 : chargeItem.FeeAmount) + (item.FeeAmount == null ? 0 : item.FeeAmount);

                    await this._chargesRepository.UpdateQuantityAndAmount(chargeItem, true);

                    if (chargeItem.FeeAmount.HasValue && chargeItem.FeeAmount.Value > 0)
                        await this._invoiceRepository.UpdateFeeAmountWhileRollUP(chargeItem.InvoiceId, chargeItem.FeeAmount.Value);

                    string msg = chargeItem.AccessionNumber == null ? item.Id.ToString() : chargeItem.AccessionNumber.ToString();

                    comments += "This charge came again in a day with same provider, dos date and cpt code, so marked not billable and got lock, Ref EMR# : " + msg;

                    item.RefChargeComment = "This charge came again in a day with same provider, dos date and cpt code, so marked not billable and got lock, Ref EMR# : " + msg;
                    item.IsLocked = true;
                    item.IsDeleted = true;
                    item.RefChargeId = chargeItem.Id;

                    await this._chargesRepository.UpdateQuantityAndAmount(item, false);
                }
            }

            if (isNotBiilable)
            {
                await this._invoiceRepository.UpdateChargeRefComments(childCharges.FirstOrDefault().InvoiceId, comments);
            }


            return 1;
        }

        private async Task<IDropDownDTO> CreateObject(IInvoice invoice)
        {
            DropDownDTO dropDownDTO = new DropDownDTO();
            dropDownDTO.label = invoice.BillFromDate.ToString("MM/dd/yyyy");
            dropDownDTO.value = invoice.UId;

            return dropDownDTO;
        }

        private async Task<IDropDownDTO> CreateObjectWithAccessionNumber(IInvoice invoice)
        {
            DropDownDTO dropDownDTO = new DropDownDTO();
            if(!string.IsNullOrWhiteSpace(invoice.AccessionNumber))
            {
                dropDownDTO.label = invoice.AccessionNumber+"-"+ invoice.BillFromDate.ToString("MM/dd/yyyy");
            }
            else
            {
                dropDownDTO.label = invoice.BillFromDate.ToString("MM/dd/yyyy");
            }
            
            dropDownDTO.value = invoice.UId;

            return dropDownDTO;
        }

        private async Task<IDropDownDTO> CreateObjectWithAccessionNumber(ICharges charge)
        {
            DropDownDTO dropDownDTO = new DropDownDTO();
            if (!string.IsNullOrWhiteSpace(charge.AccessionNumber))
            {
                dropDownDTO.label = charge.AccessionNumber + "-" + charge.BillFromDate.ToString("MM/dd/yyyy");
            }
            else
            {
                dropDownDTO.label = charge.BillFromDate.ToString("MM/dd/yyyy");
            }

            dropDownDTO.value = charge.InvoiceUId;

            return dropDownDTO;
        }

        public async Task<IEnumerable<ICharges>> GetCharges(Guid patientUId, Guid invoiceUId)
        {
            var patientData = await this._patientRepository.GetByUId(patientUId);

            var invoiceData = await this._invoiceRepository.GetAllAccessionNumber(patientData.DefaultCaseId);
            var InvoiceIds = invoiceData.Where(i => i.UId == invoiceUId).Select(i => i.UId).ToList();

            return await this._chargesRepository.GetChargesForBulkAdjustments(InvoiceIds);
        }

        public async Task<bool> UpdateCharges(IEnumerable<ICharges> charges)
        {
            List<IInsurancePolicy> policies = new List<IInsurancePolicy>();
            foreach (var item in charges)
            {
                if (item.BillToInsurance)
                    policies = (await this._insurancePolicyRepository.GetPolicies(item.PatientCaseId, item.BillFromDate)).ToList();

                await this._chargesRepository.Update(item, policies);
            }

            return true;
        }

        public async Task<bool>RunEMRScrub()
        {
            var list = await this._invoiceRepository.GetAllNotMadeClaim();
            foreach (var entity in list)
            {                
                var invoice = await this.GetByInvoice(entity.PatientCaseId, entity.InvoiceId);
                if(invoice.ChargeList.Count()>0)
                {
                    invoice = await this.EMRValidationScrub(invoice);
                    if (!string.IsNullOrWhiteSpace(invoice.ReviewComments))
                    {
                        await this._invoiceRepository.UpdateReviewNeeded(invoice.UId, true, invoice.ReviewComments);
                    }
                }
            }
            return true;
        }

        private async Task<IInvoice> EMRValidationScrub(IInvoice invoice)
        {
            string errorMessage = "";

            if (invoice.BillFromDate < Convert.ToDateTime("15 Dec 2021"))
            {
                invoice.ReviewNeeded = true;
                errorMessage += "Charges need to review before 15 Dec 2021.";
            }
            else
                invoice.ReviewNeeded = false;

            if(invoice.IspmgEncounter.HasValue && invoice.IspmgEncounter.Value)
            {
                //foreach (var item in invoice.ChargeList)
                //{
                //    if (item.Icd1Type.HasValue && item.Icd1Type.Value > 0)
                //        if (item.Icd1Type != 1)
                //            errorMessage += "Primary diagnosis does not match with Billing Facility for cpt code: " + item.CPTCode;
                //}
            }
            else
            {
                var privoderFacilityValidationList = await this._providerFacilityValidtionRepository.GetAll();
                var proivderFacVal = privoderFacilityValidationList.FirstOrDefault(i => i.ProviderId == invoice.ChargeList.FirstOrDefault().PerformingProviderId && i.FacilityId == invoice.ChargeList.FirstOrDefault().PerformingFacilityId);

                if (proivderFacVal == null)
                {
                    var billingFacility = await this._facilityRepository.GetById(invoice.BillFacilityId.Value);

                    if (billingFacility.IsMentalFacility.HasValue && billingFacility.IsMentalFacility.Value)
                    {
                        // mental health
                        foreach (var item in invoice.ChargeList)
                        {
                            if (item.Icd1Type.HasValue && item.Icd1Type.Value > 0)
                                if (item.Icd1Type != 1)
                                    errorMessage += "Primary diagnosis does not match with Billing Facility for cpt code: " + item.CPTCode;
                        }
                    }
                    else
                    {
                        // substance 
                        foreach (var item in invoice.ChargeList)
                        {
                            if (item.Icd1Type.HasValue && item.Icd1Type.Value > 0)
                                if (item.Icd1Type != 2)
                                    errorMessage += "Primary diagnosis does not match with Billing Facility for cpt code: " + item.CPTCode;
                        }
                    }
                }               
            }
            

            foreach (var item in invoice.ChargeList)
            {
                if (item.CPTCode == "H2019")
                {
                    List<string> modifiers = new List<string>();
                    if (!string.IsNullOrWhiteSpace(item.Mod1))
                        modifiers.Add(item.Mod1);
                    if (!string.IsNullOrWhiteSpace(item.Mod2))
                        modifiers.Add(item.Mod2);
                    if (!string.IsNullOrWhiteSpace(item.Mod3))
                        modifiers.Add(item.Mod3);
                    if (!string.IsNullOrWhiteSpace(item.Mod4))
                        modifiers.Add(item.Mod4);

                    var mod = modifiers.FirstOrDefault(i => i.ToString() == "U3" || i.ToString() == "U6");
                    if (mod != null)
                    {
                        errorMessage += "H2019 cannot be used Modifier: " + mod.ToString();
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                invoice.ReviewNeeded = true;
                invoice.ReviewComments = errorMessage;
            }

            return invoice;
        }

        public async Task<ICharges> GetChargeByDosAndCptCode(int patientCaseId, string cptcode, DateTime dosDate)
        {
            return await this._chargesRepository.GetChargeByDosAndCptCode(patientCaseId, cptcode, dosDate);
        }

        public async Task<ICharges> GetChargeByDosAndCptCodeAndProvider(int patientCaseId, string cptcode, DateTime dosDate, int performingProviderId)
        {
            return await this._chargesRepository.GetChargeByDosAndCptCodeAndProvider(patientCaseId, cptcode, dosDate,performingProviderId);
        }

        public async Task<bool> DoNotBillInvoices(List<Guid> invoiceUIds)
        {            
            foreach (var item in invoiceUIds)
            {
                await this._invoiceRepository.UpdateIsBillable(item, false, "");
            }
            return true;
        }

        public async Task<bool> MarkAsRejected(List<Guid> invoiceUIds,string pin)
        {            
            if (!string.IsNullOrWhiteSpace(pin))
            {
                string tplCode = (await this._practiceRepository.Get()).ChargeRejectionCode;
                if (!string.IsNullOrWhiteSpace(tplCode))
                {
                    if (tplCode != pin.Trim())
                    {
                        await this._invoiceRepository.ThrowRejectionPINNotMatched();
                    }
                }
            }

            foreach (var item in invoiceUIds)
            {
                await this._invoiceRepository.MarkAsRejected(item, pin);
                var charges = await this._chargesRepository.GetByInvoiceId(item);
                foreach (var charge in charges)
                {
                    await this._chargesRepository.MarkAsRejected(charge.Id);
                }

            }
            return true;
        }

        public async Task<bool> BillInvoices(List<Guid> invoiceUIds, string billableCoupon)
        {
            foreach (var item in invoiceUIds)
            {
                var charges = await this._chargesRepository.GetByInvoiceId(item);
                var lockedCharge = charges.FirstOrDefault(i => i.IsLocked == true);
                if(lockedCharge==null)
                    await this._invoiceRepository.UpdateIsBillable(item, true, billableCoupon);
            }
            return true;
        }

        public async Task<int> AddOrUpdateWriteOff(IChargeInWriteOffDTO chargeInWriteOffDTO)
        {
            try
            {   
                var chargesUIds = chargeInWriteOffDTO.ChargeUids.Split(',').ToArray<string>();                               
                var chargeIds = (await this._chargesRepository.GetByUIds(chargesUIds)).ToList();

                List<ChargeInWriteOff> lst = new List<ChargeInWriteOff>();
                foreach (var item in chargeIds)
                {
                    ChargeInWriteOff obj = new ChargeInWriteOff();
                    obj.ChargeId = item;
                    obj.Comments = chargeInWriteOffDTO.Comments;
                    obj.ReasonCode = chargeInWriteOffDTO.ReasonCodeId;
                    obj.StatusId = 1;

                    lst.Add(obj);
                }

                await this._chargeInWriteOffRepository.AddAll(lst);
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateWriteOff(IEnumerable<IEmrChargeInWriteOffDTO> lst)
        {
            try
            {
                List<ChargeInWriteOff> lstUpdate = new List<ChargeInWriteOff>();
                foreach (var item in lst)
                {
                    ChargeInWriteOff obj = new ChargeInWriteOff();
                    obj.ChargeId = item.ChargeId;                    
                    obj.StatusId = item.StatusId;

                    lstUpdate.Add(obj);
                }

                await this._chargeInWriteOffRepository.UpdateEntity(lstUpdate);
                return 1;
            }
            catch
            {
                throw;
            }
        }


        public async Task<IEnumerable<ICharges>> GetChargesByPatient(Guid patientUId)
        {
            var patientData = await this._patientRepository.GetByUId(patientUId);
            return await this._chargesRepository.GetChargesByPatientId(patientData.Id);
        }

        public async Task<IEnumerable<ICharges>> GetCahrges97201To05(int patientCaseId)
        {

            return await this._chargesRepository.GetCahrges97201To05(patientCaseId);
        }

        public async Task<IEnumerable<ICharges>> Validate90791(int patientCaseId)
        {

            return await this._chargesRepository.Validate90791(patientCaseId);
        }

        public async Task<IChargesDueAmountForEMR> GetDueChargesForEMR(string billingId)
        {   
            var patient = await this._patientRepository.PatientByBillingId(billingId);
            if (patient == null)
            {
                return null;
            }

            var result= await this._chargesRepository.GetDueChargesForEMR(patient.DefaultCaseId.Value,patient.PatientCaseUId);
                        
            var unMachedPayments=await this._dynmoPaymentsRepository.GetUnMatchedPaymentsByBillingId(billingId);
            if(unMachedPayments.Count()>0)
            {
                result.UnMatchedAmount = unMachedPayments.Sum(i => i.Amount);
            }

            var unPostedAmounts = await this._portalPaymentRepository.GetUnPostedPaymentByPatientId(billingId);
            if (unPostedAmounts.Count() > 0)
            {
                result.UnPostedAmount = unPostedAmounts.Sum(i => i.Amount);
            }

            return result;


        }

        public async Task<int> GetChargesForRefreshFeeAmountWhilePolicySyncing(int patientCaseId)
        {

            var list = await this._chargesRepository.GetChargesForRefreshFeeAmountWhilePolicySyncing(patientCaseId);

            foreach (var item in list)
            {
                List<string> modifiers = new List<string>();
                if (!string.IsNullOrWhiteSpace(item.Mod1))
                    modifiers.Add(item.Mod1);
                if (!string.IsNullOrWhiteSpace(item.Mod2))
                    modifiers.Add(item.Mod2);
                if (!string.IsNullOrWhiteSpace(item.Mod3))
                    modifiers.Add(item.Mod3);
                if (!string.IsNullOrWhiteSpace(item.Mod4))
                    modifiers.Add(item.Mod4);

                var patientPolicies = await this._insurancePolicyRepository.GetActivePolicies_OldCharges(item.PatientCaseId, item.BillFromDate);
                IInsurancePolicy primaryPolicy = null;
                if (patientPolicies != null && patientPolicies.Count() > 0)
                {
                    primaryPolicy = patientPolicies.FirstOrDefault(i => i.InsuranceLevel == 1);
                }
                if(primaryPolicy!=null)
                {
                    var feeSchulde = await this._feeScheduleService.GetChargeByCPT(item.CPTCode, modifiers, item.PerformingProviderUId.ToString(),
                  primaryPolicy != null ? primaryPolicy.InsuranceCompanyUId.ToString() : "", item.BillFromDate);
                    var updatedValue = feeSchulde != null ? feeSchulde.FacilityCharge : 0;

                    if (item.Amount != (updatedValue * item.Qty))
                    {
                        item.Amount = (updatedValue * item.Qty);
                        await this._chargesRepository.UpdateAmountWhilePolicySyncing(item);
                    }

                    if (primaryPolicy.InsuranceCompanyCode != "SelfP")
                    {
                        if (item.DueAmount == item.Amount)
                        {
                            item.BillToInsurance = true;
                            item.BillToPatient = false;
                            item.DueByFlagCD = "Primary";
                            await this._chargesRepository.UpdateDueByWhilePolicySyncing(item);
                        }
                    }
                    else
                    {
                        if (item.DueByFlagCD.ToLower() != "patient" && item.DueAmount == item.Amount)
                        {
                            item.BillToInsurance = false;
                            item.BillToPatient = true;
                            item.DueByFlagCD = "Patient";
                            await this._chargesRepository.UpdateDueByWhilePolicySyncing(item);
                        }
                    }
                }               
            }

            return 0;
        }

        public async Task<int> GetChargesForUpdateFeeAmount(List<int> ids)
        {

            var list = await this._chargesRepository.GetChargesForUpdateFeeAmount(ids);

            foreach (var item in list)
            {
                List<string> modifiers = new List<string>();
                if (!string.IsNullOrWhiteSpace(item.Mod1))
                    modifiers.Add(item.Mod1);
                if (!string.IsNullOrWhiteSpace(item.Mod2))
                    modifiers.Add(item.Mod2);
                if (!string.IsNullOrWhiteSpace(item.Mod3))
                    modifiers.Add(item.Mod3);
                if (!string.IsNullOrWhiteSpace(item.Mod4))
                    modifiers.Add(item.Mod4);

                var patientPolicies = await this._insurancePolicyRepository.GetActivePolicies_OldCharges(item.PatientCaseId, item.BillFromDate);
                IInsurancePolicy primaryPolicy = null;
                if (patientPolicies != null && patientPolicies.Count() > 0)
                {
                    primaryPolicy = patientPolicies.FirstOrDefault(i => i.InsuranceLevel == 1);
                }

                var feeSchulde = await this._feeScheduleService.GetChargeByCPT(item.CPTCode, modifiers, item.PerformingProviderUId.ToString(),
                   primaryPolicy != null ? primaryPolicy.InsuranceCompanyUId.ToString() : "", item.BillFromDate);
                var updatedValue = feeSchulde != null ? feeSchulde.FacilityCharge : 0;

                if (item.Amount != (updatedValue * item.Qty))
                {
                    item.Amount = (updatedValue * item.Qty);
                    await this._chargesRepository.UpdateAmountWhilePolicySyncing(item);
                }
            }

            return 0;
        }
    }
}
