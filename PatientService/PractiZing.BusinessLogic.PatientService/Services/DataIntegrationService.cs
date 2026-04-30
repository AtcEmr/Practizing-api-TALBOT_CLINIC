using AutoMapper;
using Newtonsoft.Json;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Enums.PatientEnums;
using PractiZing.Base.Model.Master;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.Base.Service.PatientService;
using PractiZing.BusinessLogic.ChargePaymentService.Repositories;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Models;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Model;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Services
{
    public class DataIntegrationService : IDataIntegrationService
    {
        private readonly IInsurancePolicyRepository _insurancePolicyRepository;
        private readonly ILabVendorInsuranceCodesRepository _labVendorInsuranceCodesRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly ITransactionProvider _transactionProvider;
        private readonly IInsurancePolicyHolderRepository _insurancePolicyHolderRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientCaseRepository _patientCaseRepository;
        public readonly IPatientAuthorizationNumberRepository _patientAuthorizationNumberRepository;
        public readonly IPatientStatementRepository _patientStatementRepository;
        private readonly IClaimConfigRepository _claimConfigRepository;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IFSDiscountRepository _fsDiscountRepository;
        private readonly IConfigPractitionerServiceRepository _configPractitionerService;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IReferringDoctorRepository _referringDoctorRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly ICPTCodeRepository _cPTCodeRepository;
        private readonly IICDCodeRepository _iCDCodeRepository;
        private readonly IFSChargeRepository _fsChargeRepository;
        private readonly IFeeScheduleRepository _feeScheduleRepository;
        private readonly IInsuranceGuarantorRepository _insuranceGuarantorRepository;
        private readonly IMapper _mapper;
        private readonly IChargeInvoiceService _chargeInvoiceService;
        private readonly IInsurancePolicyService _insurancePolicyService;
        private readonly IHL7StatusRepository _hL7StatusRepository;
        private readonly IFeeScheduleService _feeScheduleService;
        private readonly IProviderIdentityRepository _providerIdentityRepository;
        private readonly IFacilityIdentityRepository _facilityIdentityRepository;
        private readonly ICPTModifierRepository _cPTModifierRepository;

        public DataIntegrationService(IInsuranceCompanyRepository insuranceCompanyRepository,
                                      IInsurancePolicyRepository insurancePolicyRepository,
                                      IInsurancePolicyHolderRepository insurancePolicyHolderRepository,
                                      ILabVendorInsuranceCodesRepository labVendorInsuranceCodesRepository,
                                      IPatientRepository patientRepository,
                                      IPatientCaseRepository patientCaseRepository,
                                      IPatientAuthorizationNumberRepository patientAuthorizationNumberRepository,
                                      IPatientStatementRepository patientStatementRepository,
                                      IClaimConfigRepository claimConfigRepository,
                                      ITransactionProvider transactionProvider,
                                      IVoucherRepository voucherRepository,
                                      IFSDiscountRepository fSDiscountRepository,
                                      IFeeScheduleService feeScheduleService,
                                      IInvoiceRepository invoiceRepository,
                                      IProviderRepository providerRepository,
                                      IReferringDoctorRepository referringDoctorRepository,
                                      IFacilityRepository facilityRepository,
                                      ICPTCodeRepository cPTCodeRepository,
                                      IICDCodeRepository iCDCodeRepository,
                                      IFSChargeRepository fSChargeRepository,
                                      IFeeScheduleRepository feeScheduleRepository,
                                      IInsuranceGuarantorRepository insuranceGuarantorRepository,
                                      IMapper mapper,
                                      IChargeInvoiceService chargeInvoiceService,
                                      IInsurancePolicyService insurancePolicyService,
                                      IHL7StatusRepository hL7StatusRepository,
                                      IProviderIdentityRepository providerIdentityRepository,
                                      IFacilityIdentityRepository facilityIdentityRepository,
                                      IConfigPractitionerServiceRepository configPractitionerService,
                                      ICPTModifierRepository cPTModifierRepository)
        {
            this._cPTModifierRepository = cPTModifierRepository;
            this._configPractitionerService = configPractitionerService;
            this._facilityIdentityRepository = facilityIdentityRepository;
            this._providerIdentityRepository = providerIdentityRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._insurancePolicyRepository = insurancePolicyRepository;
            this._labVendorInsuranceCodesRepository = labVendorInsuranceCodesRepository;
            this._insurancePolicyHolderRepository = insurancePolicyHolderRepository;
            this._patientRepository = patientRepository;
            this._patientCaseRepository = patientCaseRepository;
            this._patientAuthorizationNumberRepository = patientAuthorizationNumberRepository;
            this._patientStatementRepository = patientStatementRepository;
            this._claimConfigRepository = claimConfigRepository;
            this._transactionProvider = transactionProvider;
            this._voucherRepository = voucherRepository;
            this._feeScheduleService = feeScheduleService;
            this._mapper = mapper;
            this._invoiceRepository = invoiceRepository;
            this._providerRepository = providerRepository;
            this._referringDoctorRepository = referringDoctorRepository;
            this._facilityRepository = facilityRepository;
            this._cPTCodeRepository = cPTCodeRepository;
            this._iCDCodeRepository = iCDCodeRepository;
            this._fsChargeRepository = fSChargeRepository;
            this._feeScheduleRepository = feeScheduleRepository;
            this._fsDiscountRepository = fSDiscountRepository;
            this._insuranceGuarantorRepository = insuranceGuarantorRepository;
            this._chargeInvoiceService = chargeInvoiceService;
            this._insurancePolicyService = insurancePolicyService;
            this._hL7StatusRepository = hL7StatusRepository;

        }

        string errors = "";

        public async Task<bool> GetAllPolicies()
        {
            try
            {
                string error = "";
                //IEnumerable<IPatientpolicy> patientList = await this._patientRepository.ImortPatientPoliciesFromEMR();
                var patientList = await this._patientRepository.ImortPatientPoliciesFromEMR();
                var list = (IEnumerable<Patientpolicy>) patientList;
                foreach (var item in list.OrderBy(i=>i.levelId))
                {
                    try
                    {
                        if (item.isDeleted == false)
                        {
                            var patient = await this._patientRepository.PatientByBillingId(item.patientId.ToString());
                            if (patient != null)
                            {
                                var policy = await SetInsurancePolicy(item, patient);
                                await this._insurancePolicyService.Add(policy, true);
                            }
                        }
                    }
                    catch (EntityException ex)
                    {
                        if (ex != null && ex.ValidationCodeResult != null && ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors.Count() > 0)
                        {
                            foreach (var content in ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors)
                            {
                                try
                                {
                                    error += item.patientId.ToString() + "-" + content.ErrorMessage + System.Environment.NewLine;
                                }
                                catch (Exception)
                                {

                                }

                            }
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        error += item.patientId.ToString() + "-" + ex.Message + System.Environment.NewLine;
                    }
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<bool> SyncPoliciesFromEMRBulk()
        {
            string emrToken = await this._patientRepository.GetEMRToken();

            var policyList = await this._patientRepository.EMRPolicySyncService(emrToken);
            var list = (IEnumerable<EMRPolicySync>)policyList;
            List<int> policyIds = new List<int>();
            List<int> patientIds = new List<int>();
            foreach (var item in list)
            {
                try
                {
                    policyIds.Add(item.patientPolicy.FirstOrDefault().policyId);
                    int val = patientIds.FirstOrDefault(i => i.ToString() == item.patientPolicy.FirstOrDefault().patientId.ToString());
                    if(val>0)
                    {
                        continue;
                    }

                    patientIds.Add(item.patientPolicy.FirstOrDefault().patientId);
                    var patient=await this._patientRepository.PatientByBillingId(item.patientPolicy.FirstOrDefault().patientId.ToString());
                    if(patient!=null)
                    {
                        await SyncPoliciesFromEMR(patient.Id,emrToken);                        
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            if(policyIds.Count()>0)
            {
                await this._patientRepository.EMRUpdatePolicyWithIdsSync(emrToken, policyIds);
            }
            
            return true;
        }

        public async Task<bool> SyncPoliciesFromEMR(int patientId,string emrToken="")
        {

            string error = "";
            var patient = await this._patientRepository.PatientByPatientIdWithCaseUid(patientId);

            var patientList = await this._patientRepository.SyncPoliciesFromEMR(patient.BillingID,emrToken);
            var list = (IEnumerable<Patientpolicy>)patientList;

            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var emrPlociesIds = list.Select(i => i.policyId);

                await this._insurancePolicyService.DeleteAllByPatientId(patient.Id,emrPlociesIds);

                foreach (var item in list.OrderBy(i => i.levelId).ThenBy(i=>i.insurancePolicy.planEffectiveDate))
                {
                    try
                    {
                        if (item.isDeleted == false)
                        {   
                            if (patient != null)
                            {
                                var policy = await SetInsurancePolicy(item, patient);
                                await this._insurancePolicyService.Add(policy, true);                                
                            }
                        }
                    }
                    catch (EntityException ex)
                    {
                        if (ex != null && ex.ValidationCodeResult != null && ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors.Count() > 0)
                        {
                            foreach (var content in ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors)
                            {
                                try
                                {
                                    error += item.patientId.ToString() + "-" + content.ErrorMessage + System.Environment.NewLine;
                                }
                                catch (Exception)
                                {

                                }

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        error += item.patientId.ToString() + "-" + ex.Message + System.Environment.NewLine;
                        throw new Exception(error);
                    }
                    
                }
                await this._chargeInvoiceService.GetChargesForRefreshFeeAmountWhilePolicySyncing(patient.DefaultCaseId.Value);
                this._transactionProvider.CommitTransaction(transactionId);
                return true;
            }
            catch (Exception ex)
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<IEnumerable<IArPatient>> GetArPatientBillingData()
        {
            try
            {                
                IEnumerable<IArPatient> result = new List<IArPatient>();
                IEnumerable<IArPatient> patientList = await this._patientRepository.GetArPatientBillingData();
                List<IEMRChargeStatus> lstEmrStatus = new List<IEMRChargeStatus>();

                if (patientList.Count() > 0)
                {
                    foreach (ArPatient arPatient in patientList)
                    {
                        if (arPatient.lastName == "Mouse")
                        {
                            continue;
                        }
                        this.errors = "";
                        var hl7Data = await this.SaveHL7Data(arPatient);
                        try
                        {
                            var hL7FileObj = new HL7FileDTO()
                            {
                                IsPrimaryCareNPI=arPatient.IsPrimaryCareNPI,
                                BillingID = arPatient.patientId.ToString(),
                                LastName = arPatient.lastName,
                                FirstName = arPatient.firstName,
                                MI = "",
                                Sex = arPatient.gender.ToCharArray()[0].ToString(),
                                DOB = Convert.ToDateTime(arPatient.dob),
                                DrivingLicenseNo = "",
                                Address1 = arPatient.address1,
                                Address2 = arPatient.address2,
                                City = arPatient.city,
                                State = arPatient.state,
                                ZipCode = arPatient.zipCode,
                                BillAddress1 = arPatient.address1,
                                BillAddress2 = arPatient.address2,
                                BillCity = arPatient.city,
                                BillState = arPatient.state,
                                BillZip = arPatient.zipCode,
                                PhoneNumber = arPatient.MobilePhoneNumber,
                                WorkPhoneNumber = "",
                                SSN = arPatient.ssn,
                                Location = "",     
                                MobilePhoneNumber=arPatient.MobilePhoneNumber,
                                BillingProviderFirstName = arPatient.BillingProviderFirstName,
                                BillingProviderLastName = arPatient.BillingProviderLastName,
                                BillingProviderNPI = arPatient.BillingProviderNPI,
                                RenderingProviderFirstName = arPatient.RenderingProviderFirstName,
                                RenderingProviderLastName = arPatient.RenderingProviderLastName,
                                RenderingProviderNPI = arPatient.RenderingProviderNPI,
                                OrderingProviderFirstName = arPatient.OrderingProviderFirstName,
                                OrderingProviderLastName = arPatient.OrderingProviderLastName,
                                OrderingProviderNPI= arPatient.OrderingProviderNPI,
                                RenderingProviderSupervisorFirstName = arPatient.RenderingProviderSupervisorFirstName,
                                RenderingProviderSupervisorLastName = arPatient.RenderingProviderSupervisorLastName,
                                RenderingProviderSupervisorNPI = arPatient.RenderingProviderSupervisorNPI,
                                InsurancePolicy = SetInsurancePolicies(arPatient.patientPolicy, arPatient.guarantorPatientGuarantors, arPatient),
                                InsuranceGuarantor = SetInsuranceGuarantor(arPatient.guarantorPatientGuarantors),
                                Invoice = SetInvoice(arPatient),
                                DiagnosisDTOs = SetDiagnosisDTO(arPatient.admissionDiagnosis),
                                BillingFacilityNPI = arPatient.billingFacility.NPI,
                                BillingFacilityCode = arPatient.billingFacility.Code,
                                //PerformingFacilityCode = arPatient.billingFacility.Code,
                                //PerformingFacilityNPI = arPatient.billingFacility.NPI,
                                PerformingFacilityCode= arPatient.performingFacility!=null ?arPatient.performingFacility.Code:"",
                                PerformingFacilityNPI = arPatient.performingFacility != null ? arPatient.performingFacility.NPI:"",
                                POSCode = arPatient.placeOfService.Code,
                                PatientBillTypeId=arPatient.patientBillTypeId

                            };
                            if (hL7FileObj.LastName == "Mouse")
                            {
                                continue;
                            }
                            //Cassandra Ramos, Paula Smith, Lauren Sottile, Corinna Reynolds
                            
                            var id = await this.AddIntegrationData(hL7FileObj);
                            if (id == 0)
                            {
                                hl7Data.ErrorMessage = this.errors;
                                EMRChargeStatus obj = new EMRChargeStatus();
                                obj.BillingId = Convert.ToInt32(arPatient.billingId);
                                obj.ChargeId = id;
                                obj.ReasonsFromBillingSytem = this.errors;
                                lstEmrStatus.Add(obj);
                                hl7Data.StatusCode = HL7StatusEnum.Error.ToString();
                              //  await this._hL7StatusRepository.Update(hl7Data);
                                //await this._patientRepository.SendAcknowledgementToEMR(arPatient.billingId, id, this.errors);
                            }
                            else
                            {
                                hl7Data.StatusCode = HL7StatusEnum.Processed.ToString();
                                EMRChargeStatus obj = new EMRChargeStatus();
                                obj.BillingId = Convert.ToInt32(arPatient.billingId);
                                obj.ChargeId = id;
                                obj.ReasonsFromBillingSytem = this.errors;
                                lstEmrStatus.Add(obj);
                               // await this._hL7StatusRepository.Update(hl7Data);
                                //await this._patientRepository.SendAcknowledgementToEMR(arPatient.billingId, id, "");
                            }

                        }
                        catch (Exception ex)
                        {
                            hl7Data.ErrorMessage = ex.Message;
                            await this._hL7StatusRepository.Update(hl7Data);
                        }
                    }
                    if(lstEmrStatus.Count>0)
                    {
                        await this._patientRepository.SendEncounterImportAcknowledgementToEMR(lstEmrStatus);
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddIntegrationData(IHL7FileDTO hL7FileDTOT)
        {
            try
            {
                var hL7FileDTO = hL7FileDTOT as HL7FileDTO;

                if (hL7FileDTO != null)
                {
                    var result = await this._invoiceRepository.CheckForAccessionNumber(hL7FileDTO.Invoice.AccessionNumber);
                    if (result)
                    {
                        this.errors += $"Accession No {hL7FileDTO.Invoice.AccessionNumber} already exist. ";
                    }

                    if(hL7FileDTO.Invoice.ChargeList.Where(i=>i.CPTCode=="H0048").Count()>0)
                    {
                        var defaultSUDNpi = await this._facilityIdentityRepository.GetDefaultFacilitySUDNPI();
                        hL7FileDTO.BillingFacilityNPI = defaultSUDNpi.Identifier;
                    }

                    //var defaultProvider = await this._providerRepository.GetDefaultProvider();
                    var defaultProvider = await this._providerIdentityRepository.GetProviderByFacilityNPI(hL7FileDTO.BillingFacilityNPI);
                    //var defaultProvider = await this._providerIdentityRepository.GetProviderByFacilityNPI(hL7FileDTO.BillingProviderNPI);
                    hL7FileDTO.ProviderId = defaultProvider.Id;
                    hL7FileDTO.ProviderUId = defaultProvider.UId;

                    await GetProvider(hL7FileDTO);

                    //await GetFacility(hL7FileDTO);
                    await GetBillingFacility(hL7FileDTO);

                    await GetPerformingFacility(hL7FileDTO);

                    await GetRenderingProvider(hL7FileDTO);

                    await GetOrderingProvider(hL7FileDTO);

                    //commented on 13 Jan 2022, no need supervisor
                    //await GetSupervisorProvider(hL7FileDTO);

                    await InsertCPTDesc(hL7FileDTO.Invoice);

                    if (hL7FileDTO.Invoice.InvDiagnosisLst.Count() == 0)
                        this.errors += $"Diagnosis does not exist!";

                    foreach (var item in hL7FileDTO.Invoice.InvDiagnosisLst)
                    {
                        if (item.ICDCode.Length < 3)
                        {
                            this.errors += $"Diagnosis code [" + item.ICDCode + "] length should not be greater than 3.";
                        }
                    }

                    InsertBillingInfo(hL7FileDTO, hL7FileDTO.Invoice);

                    if (hL7FileDTO.InsurancePolicy.Count() == 0)
                    {
                        this.errors += $"Insurance Policy does not exist for this patient.";
                    }
                    else
                    {
                        var medicaidPolicies= hL7FileDTO.InsurancePolicy.Where(i => i.InsuranceCompanyTypeId == 4);
                        foreach (var item in medicaidPolicies)
                        {
                            if(string.IsNullOrWhiteSpace( item.MedicaidId))
                            {
                                this.errors += $"There must be medicaidid for insurance type=Medicaid for Policy No: "+ item.PolicyNumber;
                            }
                        }
                    }

                    await ValidatePolicies(hL7FileDTO, hL7FileDTO.InsurancePolicy);
                    var insurancePolicies = hL7FileDTO.InsurancePolicy;

                    Guid insuranaceCompanyUId=new Guid();

                    if (insurancePolicies != null && insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 1) != null)
                    {
                        insuranaceCompanyUId = (insurancePolicies != null && insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 1) != null) ? insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 1).InsuranceCompanyUId : hL7FileDTO.InsurancePolicy.FirstOrDefault(i => i.InsuranceLevel == 1).InsuranceCompanyUId;
                    }
                    else if (insurancePolicies != null && insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2) != null)
                    {
                        insuranaceCompanyUId = (insurancePolicies != null && insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2) != null) ? insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2).InsuranceCompanyUId : hL7FileDTO.InsurancePolicy.FirstOrDefault(i => i.InsuranceLevel == 2).InsuranceCompanyUId;
                    }

                    int? insuranceCompanyTypeId = null;
                    if (insurancePolicies != null && insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 1) != null)
                    {
                        var resultList = insurancePolicies.Where(i => (i.PlanEffectiveDate.HasValue
                            && i.PlanEffectiveDate.Value.Date <= hL7FileDTOT.Invoice.BillFromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= hL7FileDTOT.Invoice.BillFromDate.Date))).ToList();

                        if (resultList.Count()==0)
                        {
                            this.errors += $"There is not active policy according DOS date.";
                        }
                        else
                        {
                            insuranceCompanyTypeId = resultList.FirstOrDefault(i => i.InsuranceLevel == 1).InsuranceCompanyTypeId;
                            insuranaceCompanyUId = resultList.FirstOrDefault(i => i.InsuranceLevel == 1).InsuranceCompanyUId;
                        }                        
                    }
                    else if (insurancePolicies != null && insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2) != null)
                    {
                        insuranceCompanyTypeId = (insurancePolicies != null && insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2) != null) ? insurancePolicies.FirstOrDefault(i => i.InsuranceLevel == 2).InsuranceCompanyTypeId : hL7FileDTO.InsurancePolicy.FirstOrDefault(i => i.InsuranceLevel == 2).InsuranceCompanyTypeId;
                    }

                    

                    //var response = await restApi.PostAsync(jsondata, RestApiConfig.PatientApi, url, token);

                    var patientObj = hL7FileDTO as IPatient;
                    if (string.IsNullOrWhiteSpace(patientObj.PreferredPhoneNumber))
                    {
                        patientObj.PreferredPhoneNumber = "";
                    }


                    var patient = await this.AddNew(patientObj);

                    if (patient != null)
                    {
                        AddPatientInfoInInsurancePolicy(hL7FileDTO.InsurancePolicy, patient); ;
                        if (hL7FileDTO.InsuranceGuarantor == null)
                        {
                            hL7FileDTO.InsuranceGuarantor = new InsuranceGuarantor();
                            hL7FileDTO.InsuranceGuarantor.GuarantorNumber = string.Empty;
                            hL7FileDTO.InsuranceGuarantor.LastName = patient.LastName;
                            hL7FileDTO.InsuranceGuarantor.FirstName = patient.FirstName;
                            hL7FileDTO.InsuranceGuarantor.Address1 = patient.Address1;
                            hL7FileDTO.InsuranceGuarantor.Address2 = patient.Address2;
                            hL7FileDTO.InsuranceGuarantor.City = patient.City;
                            hL7FileDTO.InsuranceGuarantor.State = patient.State;
                            hL7FileDTO.InsuranceGuarantor.Zip = patient.ZipCode;
                            hL7FileDTO.InsuranceGuarantor.MobilePhone = patient.MobilePhoneNumber;
                            hL7FileDTO.InsuranceGuarantor.HomePhone = patient.PhoneNumber;
                            hL7FileDTO.InsuranceGuarantor.BusPhone = patient.WorkPhoneNumber;
                            hL7FileDTO.InsuranceGuarantor.GuarantorRel = "Self";
                            hL7FileDTO.InsuranceGuarantor.OrganizationName = string.Empty;
                            hL7FileDTO.InsuranceGuarantor.DOB = patient.DOB.Date.ToShortDateString();
                            hL7FileDTO.InsuranceGuarantor.AdminSex = patient.Sex.ToCharArray()[0];
                        }
                        else
                        {

                        }

                        hL7FileDTO.InsuranceGuarantor.PatientID = patient.Id;
                        await this._insuranceGuarantorRepository.AddNew(hL7FileDTO.InsuranceGuarantor);

                        await InsertInsurancePolicy(hL7FileDTO.InsurancePolicy);

                        hL7FileDTO.Invoice.PatientCaseId = patient.DefaultCaseId.Value;
                        hL7FileDTO.Invoice.PatientCaseUId = patient.PatientCaseUId;
                        
                        AddChargesInfo(hL7FileDTO);




                        if(insuranceCompanyTypeId==null)
                        {
                            return 0;
                        }

                        await this.InsertCPTCharge(hL7FileDTO.Invoice, insuranaceCompanyUId, insuranceCompanyTypeId);

                        if (this.errors.Length > 0)
                        {
                            return 0;
                        }
                        var invoiceEntity = await InsertCharges(hL7FileDTO.Invoice, hL7FileDTO);
                        return invoiceEntity.Id;
                    }
                }
            }
            catch (EntityException ex)
            {
                this.errors += ex.Message;
                if (ex != null && ex.ValidationCodeResult != null && ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors.Count() > 0)
                {
                    foreach (var content in ((PractiZing.DataAccess.Common.EntityValidationCodeResult)ex.ValidationCodeResult).ValidationErrors)
                    {
                        this.errors += content.ErrorMessage;
                    }
                }

            }
            catch (Exception ex)
            {
                this.errors += ex.Message;
                return 0;
            }
            return 0;
        }

        private async Task<IPatient> AddNew(IPatient entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                List<IPatientCase> patientCases = new List<IPatientCase>();
                IPatientCase patientCase = new PatientCase();
                var provider = await this._providerRepository.GetByUId(entity.ProviderUId.Value, true);
                entity.ProviderId = provider.Id;

                var result = await this._patientRepository.AddNew(entity);

                patientCase.PatientId = result.Id;
                patientCase.CaseIdNumber = Convert.ToString(result.Id * 100 + 1);

                var res = await this._patientCaseRepository.AddNew(patientCase);

                patientCases.Add(res);

                entity.DefaultCaseId = res.Id;
                result.PatientCase = patientCases;
                entity.Id = result.Id;
                entity.UId = result.UId;
                await this._patientRepository.UpdateEntity(entity);

                result.DefaultCaseId = res.Id;
                result.PatientCaseUId = res.UId;
                this._transactionProvider.CommitTransaction(transactionId);
                return result;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        //private async Task<bool> RunScrubToEMRCharges()
        //{
        //    this._chargeInvoiceService.AddNew
        //}

        

        private async Task<IInvoice> InsertCharges(IInvoice invoice, HL7FileDTO hL7FileDTOT)
        {
            try
            {
                invoice = await ValidationScrub(invoice, hL7FileDTOT);
                invoice.IsFromHl7 = true;
                var response = await this._chargeInvoiceService.AddNew(invoice);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<IInvoice> ValidationScrub(IInvoice invoice, HL7FileDTO hL7FileObj)
        {
            try
            {
                
                string errorMessage = "";

                if (invoice.BillFromDate < Convert.ToDateTime("15 Dec 2021"))
                {
                    invoice.ReviewNeeded = true;
                    errorMessage += "Charges need to review before 15 Dec 2021.";
                }
                else
                    invoice.ReviewNeeded = false;


                if(hL7FileObj.BillingProviderNPI== "XXXXXXXXXX")
                {
                    invoice.ReviewNeeded = true;
                    errorMessage += "Encoutner has dummy provider. Please change accordingly";
                }


                var billingFacility = await this._facilityRepository.GetById(invoice.BillFacilityId.Value);
                if(hL7FileObj.IsPrimaryCareNPI.HasValue && hL7FileObj.IsPrimaryCareNPI.Value)
                {
                    foreach (var item in invoice.ChargeList)
                    {
                        var primDX = await this._iCDCodeRepository.GetICDCode(item.ICD1);
                        if (primDX.IcdType.HasValue && primDX.IcdType.Value > 0)
                            if (primDX.IcdType != 1)
                                errorMessage += "Primary diagnosis does not match with Billing Facility for cpt code: " + item.CPTCode;
                    }
                }
                else
                {
                    if (billingFacility.IsMentalFacility.HasValue && billingFacility.IsMentalFacility.Value)
                    {
                        // mental health
                        foreach (var item in invoice.ChargeList)
                        {
                            var primDX = await this._iCDCodeRepository.GetICDCode(item.ICD1);
                            if (primDX.IcdType.HasValue && primDX.IcdType.Value > 0)
                                if (primDX.IcdType != 1)
                                    errorMessage += "Primary diagnosis does not match with Billing Facility for cpt code: " + item.CPTCode;
                        }
                    }
                    else
                    {
                        // substance 
                        foreach (var item in invoice.ChargeList)
                        {
                            var primDX = await this._iCDCodeRepository.GetICDCode(item.ICD1);
                            if (primDX.IcdType.HasValue && primDX.IcdType.Value > 0)
                                if (primDX.IcdType != 2)
                                    errorMessage += "Primary diagnosis does not match with Billing Facility for cpt code: " + item.CPTCode;
                        }
                    }
                }
                

                List<string> onlyPrescriberCptCodes = new List<string>() { "99201", "99202", "99203", "99204", "99205", "99211", "99212", "99213", "99214", "99215" };

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

                        // Commented Code on 12212023-- Venkat Requested the same
                        //Rohit - As per the discussion with Kaite and Jodie, they approved to Bill H0005 and H2019 with GT Modifier. Please remove the list from Error.
                        //if(item.POSId=="99")
                        //{
                        //    var gTmod = modifiers.FirstOrDefault(i => i.ToString() == "GT");
                        //    if(gTmod!=null)
                        //    {
                        //        errorMessage += "GT Modifier cannot used with POS 99";
                        //    }                            
                        //}
                    }

                    var prescriberCPT = onlyPrescriberCptCodes.FirstOrDefault(i => i.ToString() == item.CPTCode);
                    if(prescriberCPT != null)
                    {
                        var checkPrescriberProvider = await this._providerRepository.GetById(item.PerformingProviderId.Value);
                        if (checkPrescriberProvider.IsPrescriber.HasValue && !checkPrescriberProvider.IsPrescriber.Value)
                        {
                            errorMessage += item.CPTCode+ "- Cpt Code only can be used with Prescriber;";
                        }
                    }                    

                    //Stopped on 20 June 2022/ Now we will merge the Quanity and adjust the amount with existing charge for the same day 
                    //var dupCharge = await this._chargeInvoiceService.GetChargeByDosAndCptCodeAndProvider(item.PatientCaseId, item.CPTCode, item.BillFromDate, (int)item.PerformingProviderId);
                    //if (dupCharge != null)
                    //{
                    //    errorMessage += "Patient has the same Cpt Code:" + item.CPTCode + " with same Dos Date: " + item.BillFromDate.ToShortDateString();
                    //    invoice.IsBillable = false;
                    //}

                    //Start this validations for some of cpt codes as suggested by Maddy, below is the same Skype comments
                    //there are some charges that cannot be rolled up...
                    //you can only bill 1 unit per day...
                    //we need to add logic to ignore those..
                    var dupCharge = await this._chargeInvoiceService.GetChargeByDosAndCptCodeAndProvider(item.PatientCaseId, item.CPTCode, item.BillFromDate, (int)item.PerformingProviderId);
                    if (dupCharge != null)
                    {
                        var listForDuplicateChecking = GetCptCodeForDuplicateChecking();
                        var checkDuplicateCPT = listForDuplicateChecking.FirstOrDefault(i => i.ToString() == item.CPTCode.Trim());
                        if(checkDuplicateCPT!=null)
                        {
                            errorMessage += "Patient has the same Cpt Code:" + item.CPTCode + " with same Dos Date: " + item.BillFromDate.ToShortDateString();
                            invoice.IsBillable = false;                            
                            item.IsDuplicate = true;
                        }
                    }


                    if (item.ICD1== "F1110" || item.ICD1== "F1113")
                    {
                        errorMessage += "Please change the Primary DX, cannot be "+item.ICD1;
                    }

                    if (item.ICD1 == "F438" || item.ICD2 == "F438" || item.ICD3 == "F438" || item.ICD4 == "F438")
                    {
                        errorMessage += "Wrong Icd Code (F438). Please change it.";
                    }
                }


                if (hL7FileObj.FirstName == "Cassandra" && hL7FileObj.LastName == "Ramos")
                {
                    var item = hL7FileObj.Invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "99204" || i.CPTCode == "99214");
                    if (item == null)
                    {
                        errorMessage += "Patient should not have cpt code rather than 99204 or 99214";
                    }
                }
                if (hL7FileObj.FirstName == "Paula" && hL7FileObj.LastName == "Smith")
                {
                    var item = hL7FileObj.Invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "99204" || i.CPTCode == "99214");
                    if (item == null)
                    {
                        errorMessage += "Patient should not have cpt code rather than 99204 or 99214";
                    }
                }
                if (hL7FileObj.FirstName == "Lauren" && hL7FileObj.LastName == "Sottile")
                {
                    var item = hL7FileObj.Invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "99204" || i.CPTCode == "99214");
                    if (item == null)
                    {
                        errorMessage += "Patient should not have cpt code rather than 99204 or 99214";
                    }
                }
                if (hL7FileObj.FirstName == "Corinna" && hL7FileObj.LastName == "Reynolds")
                {
                    var item = hL7FileObj.Invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "99204" || i.CPTCode == "99214");
                    if (item == null)
                    {
                        errorMessage += "Patient should not have cpt code rather than 99204 or 99214";
                    }
                }



                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    if (invoice.IsBillable.Value)
                        invoice.ReviewNeeded = true;
                    invoice.ReviewComments = errorMessage;
                }                

                return invoice;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<string> GetCptCodeForDuplicateChecking()
        {
            List<string> lst = new List<string>() {"99201","99202","99203","99204","99205","99211","99212","99213","99214","99215","99415","99416","99417","G2212","90791","90792" };
            return lst;
        }


        private void AddChargesInfo(HL7FileDTO hL7FileDTO)
        {
            foreach (var item in hL7FileDTO.Invoice.ChargeList)
            {
                item.POSId = hL7FileDTO.POSCode;
                item.PatientCaseId = hL7FileDTO.Invoice.PatientCaseId;
                if(hL7FileDTO.PatientBillTypeId==3)
                {
                    item.BillToInsurance = false;
                    item.BillToPatient = true;
                }
                else
                {
                    item.BillToInsurance = true;
                    item.BillToPatient = false;
                }

                item.PerformingFacilityId = hL7FileDTO.PerformingFacilityId;
                item.PerformingFacilityUId = hL7FileDTO.PerformingFacilityUId;
                item.PerformingProviderId = hL7FileDTO.Invoice.PerformingProviderId;
                item.PerformingProviderUId = hL7FileDTO.Invoice.PerformingProviderUId;
                if (item.Mod1 == "NA" || item.Mod2 == "NA" || item.Mod3 == "NA" || item.Mod4 == "NA")
                {
                    this.errors += $"CPT code [" + item.CPTCode + "] has modifier NA. NA not allowed.";
                }
            }
        }

        private void AddPatientInfoInInsurancePolicy(IEnumerable<IInsurancePolicy> insurancePolicies, IPatient patient)
        {
            if (insurancePolicies != null && insurancePolicies.Count() > 0)
                foreach (var item in insurancePolicies)
                {
                    item.PatientCaseId = patient.DefaultCaseId.Value;
                    item.PatientCaseUId = patient.PatientCaseUId;
                    item.InsurancePolicyHolder.PatientId = patient.Id;
                    item.InsurancePolicyHolder.PatientUId = patient.UId;
                }
        }

        private async Task InsertInsurancePolicy(IEnumerable<IInsurancePolicy> policies)
        {
            if (policies == null || policies.Count() == 0)
                return;

            var patientCaseId = policies.FirstOrDefault().PatientCaseId;

            var policyIds = policies.Select(i => (int)i.EMRInsurancePolicyId);

            await this._insurancePolicyRepository.CheckPoliciesCameOrNotFromEMR(policyIds.ToList(), patientCaseId);

            foreach (var item in policies.OrderBy(i => i.InsuranceLevel).ThenBy(i=>i.PlanEffectiveDate))
            {                
                await this._insurancePolicyService.Add(item, true);
            }
        }

        private async Task InsertCPTCharge(IInvoice invoice, Guid insuranceCompanyUId,int? insuranceCompanyTypeId)
        {
            string jsondata = JsonConvert.SerializeObject(invoice.ChargeList);

            //var response = await restApi.PostAsync(jsondata, $"{RestApiConfig.GetFeeScheduleApi}?providerUId={invoice.BillProviderUId}&modifiers={string.Empty}&insuranceCompanyUId={insuranceCompanyUId}&fromDate={invoice.BillFromDate}", url, token);

            foreach (var item in invoice.ChargeList)
            {
                item.IsFromHL7 = true;
                List<IFSDiscount> _fsDiscounts = new List<IFSDiscount>();

                List<string> modifiers = new List<string>();
                if (!string.IsNullOrWhiteSpace(item.Mod1))
                    modifiers.Add(item.Mod1);
                if (!string.IsNullOrWhiteSpace(item.Mod2))
                    modifiers.Add(item.Mod2);
                if (!string.IsNullOrWhiteSpace(item.Mod3))
                    modifiers.Add(item.Mod3);
                if (!string.IsNullOrWhiteSpace(item.Mod4))
                    modifiers.Add(item.Mod4);


                if (item.CPTCode == "90792")
                {
                    var list = await this._chargeInvoiceService.GetCahrges97201To05(item.PatientCaseId);
                    if (list.Count() > 0)
                    {
                        item.CPTCode = "90834";                        
                    }
                    //else
                    //{
                    //    item.CPTCode = "99204";
                    //}
                }
                else if (item.CPTCode == "90791")
                {
                    var validate90791 = await this._chargeInvoiceService.Validate90791(item.PatientCaseId);
                    if (validate90791.Count() > 0)
                    {
                        int daysDiff = (item.BillFromDate - validate90791.FirstOrDefault().BillFromDate).Days;
                        if (daysDiff < 365)
                        {
                            item.CPTCode = "90834";
                        }
                    }
                }
                var cptDesc = await this._cPTCodeRepository.GetCPTCode(item.CPTCode);
                if(cptDesc!=null)
                    item.Description = cptDesc.Description;

                var result = await this.GetChargeByCPT(item.CPTCode, modifiers, invoice.PerformingProviderUId.Value.ToString(), insuranceCompanyUId.ToString(), invoice.BillFromDate);
                if (result != null)
                {
                    
                    item.Amount = result.NonFacilityCharge * item.Qty;
                    if (item.POSId == "99")
                    {
                        if(result.CommunityCharge>0)
                        {
                            item.Amount = result.CommunityCharge * item.Qty;
                        }
                    }

                    _fsDiscounts = result.FSDiscounts.ToList();
                    if (_fsDiscounts.Count() > 0)
                        item.Discount = _fsDiscounts.FirstOrDefault().NonFacilityDiscount;
                }

                var modGT = modifiers.FirstOrDefault(i => i.ToString() == "GT");
                if(modGT!=null)
                {
                    if(insuranceCompanyTypeId.HasValue && insuranceCompanyTypeId.Value!=4)
                    {
                        if (!string.IsNullOrWhiteSpace(item.Mod1))
                        {
                            if (item.Mod1 == "GT")
                            {
                                item.Mod1 = "95";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(item.Mod2))
                        {
                            if (item.Mod2 == "GT")
                            {
                                item.Mod2 = "95";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(item.Mod3))
                        {
                            if (item.Mod3 == "GT")
                            {
                                item.Mod3 = "95";
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(item.Mod4))
                        {
                            if (item.Mod4 == "GT")
                            {
                                item.Mod4 = "95";
                            }
                        }
                    }
                }
            }
        }

        public async Task<IFSCharge> GetChargeByCPT(string cptCode, IEnumerable<string> modifiers, string providerUId, string insuranceCompanyUId, DateTime fromDate)
        {

            return await this._feeScheduleService.GetChargeByCPT(cptCode, modifiers, providerUId, insuranceCompanyUId, fromDate);

        }

        private async Task ValidatePolicies(HL7FileDTO hL7FileDTO, IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            if (insurancePolicies != null && insurancePolicies.Count() > 0)
            {
                InsertDateInInsurancePolicies(hL7FileDTO.Invoice, insurancePolicies);
                await this.CheckInsuranceCompanyExist(insurancePolicies);
            }

            await ValidateCPTCodeExist(hL7FileDTO.Invoice, hL7FileDTO);
            await ValidateICDCodeExist(hL7FileDTO);


        }

        private async Task ValidateCPTCodeExist(IInvoice invoice, IHL7FileDTO hL7FileDTO)
        {

            //var _invoice = invoice as IInvoice;
            foreach (var item in invoice.ChargeList)
            {
                if (!item.IsCPTExistInFavList.Value)
                {
                    this.errors += $" CPT Code {item.CPTCode} Does not exist in Favourite list .";
                }
                //if (string.IsNullOrEmpty(item.POSId))
                //item.POSId = hL7FileDTO.POSCode;
            }
        }

        private async Task ValidateICDCodeExist(HL7FileDTO hL7FileDTO)
        {
            string jsondata = JsonConvert.SerializeObject(hL7FileDTO.DiagnosisDTOs);

            var response = await this._iCDCodeRepository.CheckIfICDExists(hL7FileDTO.DiagnosisDTOs);
            if (response != null)
            {
                foreach (var item in response)
                {
                    if (!item.IsExistInFavouriteList)
                    {
                        this.errors += $"ICd Code {item.Code} does not exist. ";
                    }
                }
            }

        }

        private async Task CheckInsuranceCompanyExist(IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            if (insurancePolicies.Count() == 0)
                return;

            foreach (var item in insurancePolicies)
            {
                if (item.PolicyNumber.Length > 15)
                {
                    item.PolicyNumber = "Review";
                    //errors += $"Policy Number length should not be greater than 15 characters:  {item.PolicyNumber} ";
                    //continue;
                }

                InsuranceCompaniesDTO dto = new InsuranceCompaniesDTO();
                dto.CompanyCode = item.InsuranceCompanyCode;
                dto.CompanyName = item.InsuranceCompanyName;

                string insData = JsonConvert.SerializeObject(dto);

                var insuranceCompany = await this._insuranceCompanyRepository.GetInsuranceCompanyForEMR(dto.CompanyCode.Trim(), dto.CompanyName.Trim(),item.InsuranceCompanyTypeId);
                if (insuranceCompany != null)
                {
                    item.InsuranceCompanyID = insuranceCompany.Id;
                    item.InsuranceCompanyUId = insuranceCompany.UId;
                    item.InsuranceCompanyTypeId = insuranceCompany.CompanyTypeId;
                }
                else
                {
                    this.errors += $"InsuranceCompany {item.InsuranceCompanyName} Does not exist. ";
                }

            }
        }


        private void InsertDateInInsurancePolicies(IInvoice invoice, IEnumerable<IInsurancePolicy> insurancePolicies)
        {

            foreach (var item in insurancePolicies)
            {
                if (item.PlanEffectiveDate == null)
                    item.PlanEffectiveDate = invoice.BillFromDate;

                if (item.InsurancePolicyHolder != null && item.InsurancePolicyHolder.DOB == DateTime.MinValue)
                    item.InsurancePolicyHolder.DOB = null;

                if (item.InsurancePolicyHolder == null)
                {
                    item.InsurancePolicyHolder = new InsurancePolicyHolder();

                    item.InsurancePolicyHolder.PHRel = item.PHRelationshipToPatient;

                }
            }
        }

        private void InsertBillingInfo(HL7FileDTO hL7FileDTO, IInvoice invoice)
        {
            invoice.BillFacilityId = hL7FileDTO.BillFacilityId;
            invoice.BillFacilityUId = hL7FileDTO.BillFacilityUId;
            invoice.BillProviderId = hL7FileDTO.ProviderId;
            invoice.BillProviderUId = hL7FileDTO.ProviderUId;
            invoice.FacilityId = hL7FileDTO.BillFacilityId;
            //invoice.FromTime = DateTime.Now;
            //invoice.ToTime = invoice.FromTime;
            if (!invoice.PerformingProviderId.HasValue)
                invoice.PerformingProviderId = invoice.BillProviderId;
        }

        private async Task InsertCPTDesc(IInvoice invoice)
        {
            await FillCPTDesc(invoice.ChargeList);
        }

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
                        //item.POSId = result.DefaultPOSId;

                        /*Set Type of service for CPT Code*/
                        item.TOSId = result.DefaultTOSId;
                        item.IsCPTExistInFavList = true;
                        /*Set Quantity for CPT Code*/
                        //item.Qty = result.DefaultQuantity ?? 1;
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

        private async Task GetFacility(IHL7FileDTO hL7FileDTO)
        {
            var facility = await this._facilityRepository.GetFacilityByName(hL7FileDTO.Location);
            if (facility == null)
            {
                facility = await this._facilityRepository.GetDefaultFacility();
            }

            hL7FileDTO.BillFacilityId = facility.Id;
            hL7FileDTO.BillFacilityUId = facility.UId;
            //hL7FileDTO.POSCode = facility.POSCode;
        }

        private async Task GetPerformingFacility(IHL7FileDTO hL7FileDTO)
        {
            if(!string.IsNullOrWhiteSpace(hL7FileDTO.PerformingFacilityNPI))
            {

                Base.Entities.MasterService.IFacility facility = null;
                string npi = "";

                if (hL7FileDTO.IsPrimaryCareNPI.HasValue && hL7FileDTO.IsPrimaryCareNPI.Value)
                {
                    npi = hL7FileDTO.PerformingFacilityNPI;
                }
                else
                {
                    var primaryDx = await this._iCDCodeRepository.GetICDCode(hL7FileDTO.Invoice.ChargeList.FirstOrDefault().ICD1);

                    if (primaryDx != null && primaryDx.IcdType.HasValue)
                    {
                        npi = await this._facilityRepository.GetFacilityNPIByICDClassification(primaryDx.IcdType.Value);
                    }
                    if (string.IsNullOrWhiteSpace(npi))
                    {
                        npi = hL7FileDTO.BillingFacilityNPI;
                    }
                }

                facility = await this._facilityRepository.GetFacilityByNPIAndCode(npi, hL7FileDTO.PerformingFacilityCode);
                if (facility == null)
                {
                    facility = await this._facilityRepository.GetDefaultFacility();
                    this.errors += $"Performing Facility Does not Exists.";
                }

                string gTmod = null;
                foreach (var item in hL7FileDTO.Invoice.ChargeList)
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

                        gTmod = modifiers.FirstOrDefault(i => i.ToString() == "GT");
                    }
                }


                var cptCodeH2019 = hL7FileDTO.Invoice.ChargeList.FirstOrDefault(i => i.CPTCode == "H2019");
                if(cptCodeH2019==null)
                {
                    hL7FileDTO.POSCode = facility.POSCode;
                }
                else
                {
                    if(hL7FileDTO.POSCode!="99" && hL7FileDTO.POSCode!="11")
                    {
                        hL7FileDTO.Invoice.InternalMessage = "Pos was came as "+ hL7FileDTO.POSCode+ " but as per logic had to change";
                        if(gTmod==null)
                        hL7FileDTO.POSCode = "99";
                        else
                            hL7FileDTO.POSCode = "11";
                    }
                }
                
                //only office then need to set performing facility
                if (hL7FileDTO.POSCode!="99")
                {
                    hL7FileDTO.PerformingFacilityId = facility.Id;
                    hL7FileDTO.PerformingFacilityUId = facility.UId;
                }                
            }
            else
            {
                this.errors += $"Performing Facility NPI is coming blank from EMR.";
            }
        }

        private async Task GetBillingFacility(IHL7FileDTO hL7FileDTO)
        {
            var facility = await this._facilityRepository.GetFacilityByNPIAndCode(hL7FileDTO.BillingFacilityNPI,hL7FileDTO.BillingFacilityCode);
            if (facility == null)
            {
                facility = await this._facilityRepository.GetDefaultFacility();
            }

            hL7FileDTO.BillFacilityId = facility.Id;
            hL7FileDTO.BillFacilityUId = facility.UId;
            //hL7FileDTO.POSCode = facility.POSCode;
        }

        private async Task GetProvider(IHL7FileDTO patient)
        {
            ReferringDoctor doc = new ReferringDoctor();
            doc.Address = patient.ReferringProviderAddress1;
            doc.Address2 = patient.ReferringProviderAddress2;
            doc.City = patient.ReferringProviderCity;
            doc.State = patient.ReferringProviderState;
            doc.Zip = patient.ReferringProviderZip;
            doc.FirstName = patient.ReferringProviderFirstName;
            doc.LastName = patient.ReferringProviderLastName;
            doc.NPI = patient.ReferringNPI;

            var referringDoctor = await this._referringDoctorRepository.GetByNPI(doc);
            if (referringDoctor != null)
            {
                patient.Invoice.RefDoctorId = referringDoctor.Id;
                patient.Invoice.RefDoctorUId = referringDoctor.UId;
            }
        }

        private async Task GetRenderingProvider(IHL7FileDTO patient)
        {
            if (string.IsNullOrWhiteSpace(patient.BillingProviderNPI))
            {
                if(patient.Invoice.ChargeList.FirstOrDefault(i=>i.CPTCode=="H0048")!=null)
                {
                    patient.BillingProviderNPI = "XXXXXXXXXX";
                }
                else
                {
                    this.errors += $"Billing Provider NPI is blank.";
                }
            }

            var provider = await this._providerRepository.Get(patient.BillingProviderNPI);
            if (provider != null)
            {
                patient.Invoice.PerformingProviderId = provider.Id;
                patient.Invoice.PerformingProviderUId = provider.UId;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(patient.BillingProviderNPI))
                {
                    this.errors += $"Billing Provider NPI is blank.";
                }
                else
                {
                    this.errors += $"Billing Provider NPI is not available in billing side.";
                }

            }
        }

        private async Task GetOrderingProvider(IHL7FileDTO patient)
        {
            if (!string.IsNullOrWhiteSpace(patient.OrderingProviderNPI))
            {
                var provider = await this._providerRepository.Get(patient.OrderingProviderNPI);
                if (provider != null)
                {
                    patient.Invoice.OrderringProviderId = provider.Id;
                    patient.Invoice.OrderringProviderUId = provider.UId;
                }
                else
                {
                    this.errors += $"Ordering Provider NPI is not available in billing side.";
                }
            }
        }

        private async Task GetSupervisorProvider(IHL7FileDTO patient)
        {
            if (!string.IsNullOrWhiteSpace(patient.RenderingProviderSupervisorNPI))
            {
                var provider = await this._providerRepository.Get(patient.RenderingProviderSupervisorNPI);
                if (provider != null)
                {
                    patient.Invoice.SupervisingProviderId = provider.Id;
                    patient.Invoice.SupervisingProviderUId = provider.UId;
                }
                else
                {
                    this.errors += $"Supervising Provider NPI is not available in billing side.";
                }
            }
        }

        private async Task<IHL7Status> SaveHL7Data(ArPatient arPatient)
        {
            HL7Status hl7Obj = new HL7Status();
            hl7Obj.BillingId = arPatient.patientId.ToString();
            hl7Obj.MessageType = "DFT";
            hl7Obj.StatusCode = HL7StatusEnum.Pending.ToString();
            hl7Obj.SentBy = "EMR";
            hl7Obj.SentDate = DateTime.Now;
            hl7Obj.FileName = arPatient.billingId.ToString();
            hl7Obj.FilePath = "";

            await this._hL7StatusRepository.DeleteByAccessionNumber(hl7Obj.FileName);

            var saveentity = await this._hL7StatusRepository.AddNew(hl7Obj);

            return saveentity;
        }

        private List<IInsurancePolicy> SetInsurancePolicies(Patientpolicy[] patientpolicies, Guarantorpatientguarantor[] guarantorpatientList, ArPatient arPatient)
        {
            string relationShip = "Self";
            if (guarantorpatientList.Count() > 0)
            {
                foreach (Guarantorpatientguarantor guarantorpatient in guarantorpatientList)
                {
                    if (guarantorpatient.relationPolicyHolderRelation != null)
                    {
                        relationShip = guarantorpatient.relationPolicyHolderRelation.description;
                    }
                }

            }
            List<IInsurancePolicy> insurancePolicyList = new List<IInsurancePolicy>();
            if (patientpolicies.Count() > 0)
            {
                foreach (Patientpolicy patientpolicy in patientpolicies.Where(i=>i.isActive==true))
                {
                    InsurancePolicy insurancePolicy = new InsurancePolicy();

                    var policyHolder = arPatient.patientPolicyHolders.FirstOrDefault(i => i.policyHolderId == patientpolicy.insurancePolicy.policyHolderId);
                    if(policyHolder!=null)
                    {
                        if (policyHolder.phRelationId == 1) relationShip = "Self";
                        if (policyHolder.phRelationId == 2) relationShip = "Spouse";
                        if (policyHolder.phRelationId == 3) relationShip = "Child";
                        if (policyHolder.phRelationId == 4) relationShip = "Other";
                        if (policyHolder.phRelationId == 5) relationShip = "Mother";
                        if (policyHolder.phRelationId == 6) relationShip = "Father";
                    }

                    insurancePolicy.EMRInsurancePolicyId = patientpolicy.insurancePolicy.id;
                    insurancePolicy.PHRelationshipToPatient = relationShip;
                    insurancePolicy.PHFirstName = patientpolicy.insurancePolicyHolder.firstName;
                    insurancePolicy.PHLastName = patientpolicy.insurancePolicyHolder.lastName;
                    insurancePolicy.PolicyNumber = patientpolicy.insurancePolicy.policyNumber;
                    insurancePolicy.MedicaidId = patientpolicy.insurancePolicy.medicaidId;
                    insurancePolicy.GroupName = patientpolicy.insurancePolicy.groupName;
                    insurancePolicy.GroupNumber = patientpolicy.insurancePolicy.groupNumber;
                    insurancePolicy.InsuranceLevel = patientpolicy.levelId;
                    insurancePolicy.InsuranceCompanyName = patientpolicy.insuranceCompany.name;
                    insurancePolicy.InsuranceCompanyCode = patientpolicy.insuranceCompany.code;
                    insurancePolicy.InsuranceCompanyTypeId= Convert.ToInt16( patientpolicy.insuranceCompany.typeId);
                    insurancePolicy.PHSignatureOnFile = true;
                    insurancePolicy.AcceptAssignment = true;
                    insurancePolicy.PlanEffectiveDate = patientpolicy.insurancePolicy.planEffectiveDate;
                    insurancePolicy.PlanExpirationDate = patientpolicy.insurancePolicy.planExpirationDate;

                    insurancePolicy.InsurancePolicyHolder = new InsurancePolicyHolder()
                    {
                        FirstName = patientpolicy.insurancePolicyHolder.firstName,
                        LastName = patientpolicy.insurancePolicyHolder.lastName,
                        DOB = patientpolicy.insurancePolicyHolder.dob,
                        PHRel = relationShip,
                        Sex = arPatient.gender.ToCharArray()[0].ToString(),
                    };

                    if (patientpolicy.PolicyAuthorizationNumber != null && patientpolicy.PolicyAuthorizationNumber.Count() > 0)
                    {
                        List<PatientAuthorizationNumber> authList = new List<PatientAuthorizationNumber>();
                        List<int> lstAuthType = new List<int>() { 3, 4 };
                        //foreach (var item in patientpolicy.PolicyAuthorizationNumber.Where(i => i.AuthorizationTypeId == 3))// 3 is for clinic only
                        foreach (var item in patientpolicy.PolicyAuthorizationNumber.Where(i => lstAuthType.Contains(i.AuthorizationTypeId)))// 3 is for clinic only
                        {
                            PatientAuthorizationNumber patientAuthorizationNumber = new PatientAuthorizationNumber();
                            patientAuthorizationNumber.AuthorizationNumber = item.AuthorizationNumber;
                            patientAuthorizationNumber.EffectiveDate = item.EffectiveDate;
                            patientAuthorizationNumber.ExpirationDate = item.ExpirationDate;
                            authList.Add(patientAuthorizationNumber);
                        }

                        insurancePolicy.PatientAuthorizationNumber = authList;
                    }

                    insurancePolicyList.Add(insurancePolicy);
                }
            }

            return insurancePolicyList;
        }

        private async Task<IInsurancePolicy> SetInsurancePolicy(Patientpolicy patientpolicy,IPatient patient)
        {
            string relationShip = "Self";
            InsurancePolicy insurancePolicy = new InsurancePolicy();

            var policyHolder = patientpolicy.insurancePolicyHolder;
            if (policyHolder != null)
            {
                if (policyHolder.phRelationId == 1) relationShip = "Self";
                if (policyHolder.phRelationId == 2) relationShip = "Spouse";
                if (policyHolder.phRelationId == 7) relationShip = "Child";
                if (policyHolder.phRelationId == 4) relationShip = "Other";
                if (policyHolder.phRelationId == 3) relationShip = "Other";
                if (policyHolder.phRelationId == 5) relationShip = "Mother";
                if (policyHolder.phRelationId == 6) relationShip = "Father";
                if (policyHolder.phRelationId == 0) relationShip = "Self";
            }

            insurancePolicy.EMRInsurancePolicyId = patientpolicy.insurancePolicy.id;
            insurancePolicy.PHRelationshipToPatient = relationShip;
            insurancePolicy.PHFirstName = patientpolicy.insurancePolicyHolder.firstName;
            insurancePolicy.PHLastName = patientpolicy.insurancePolicyHolder.lastName;
            insurancePolicy.PolicyNumber = patientpolicy.insurancePolicy.policyNumber;
            insurancePolicy.MedicaidId = patientpolicy.insurancePolicy.medicaidId;
            insurancePolicy.GroupName = patientpolicy.insurancePolicy.groupName;
            insurancePolicy.GroupNumber = patientpolicy.insurancePolicy.groupNumber;
            insurancePolicy.InsuranceLevel = patientpolicy.levelId;
            insurancePolicy.InsuranceCompanyName = patientpolicy.insuranceCompany.name;
            insurancePolicy.InsuranceCompanyCode = patientpolicy.insuranceCompany.code;
            insurancePolicy.InsuranceCompanyTypeId = Convert.ToInt16(patientpolicy.insuranceCompany.typeId);
            insurancePolicy.PHSignatureOnFile = true;
            insurancePolicy.AcceptAssignment = true;
            insurancePolicy.PlanEffectiveDate = patientpolicy.insurancePolicy.planEffectiveDate;
            insurancePolicy.PlanExpirationDate = patientpolicy.insurancePolicy.planExpirationDate;


            var insuranceCompany = await this._insuranceCompanyRepository.GetInsuranceCompanyForEMR(insurancePolicy.InsuranceCompanyCode.Trim(), insurancePolicy.InsuranceCompanyName.Trim(), insurancePolicy.InsuranceCompanyTypeId);
            if (insuranceCompany != null)
            {
                insurancePolicy.InsuranceCompanyID = insuranceCompany.Id;
                insurancePolicy.InsuranceCompanyUId = insuranceCompany.UId;
                insurancePolicy.InsuranceCompanyTypeId = insuranceCompany.CompanyTypeId;
            }
            else
            {
                throw new Exception("Insuance company ["+ insurancePolicy.InsuranceCompanyName + "] is not in billing side please add fisrt then sync");
            }

            insurancePolicy.InsurancePolicyHolder = new InsurancePolicyHolder()
            {
                FirstName = patientpolicy.insurancePolicyHolder.firstName,
                LastName = patientpolicy.insurancePolicyHolder.lastName,
                DOB = patientpolicy.insurancePolicyHolder.dob,
                PHRel = relationShip,
                Sex = patient.Sex.ToCharArray()[0].ToString(),
            };

            insurancePolicy.PatientCaseId = patient.DefaultCaseId.Value;
            insurancePolicy.PatientCaseUId = patient.PatientCaseUId;
            insurancePolicy.InsurancePolicyHolder.PatientId = patient.Id;
            insurancePolicy.InsurancePolicyHolder.PatientUId = patient.UId;

            if (patientpolicy.PolicyAuthorizationNumber != null && patientpolicy.PolicyAuthorizationNumber.Count() > 0)
            {
                List<PatientAuthorizationNumber> authList = new List<PatientAuthorizationNumber>();
                List<int> lstAuthType = new List<int>() { 3, 4 };
                //foreach (var item in patientpolicy.PolicyAuthorizationNumber.Where(i=>i.AuthorizationTypeId==3))// 3 is for clinic only
                foreach (var item in patientpolicy.PolicyAuthorizationNumber.Where(i => lstAuthType.Contains( i.AuthorizationTypeId)))// 3 is for clinic only
                {
                    PatientAuthorizationNumber patientAuthorizationNumber = new PatientAuthorizationNumber();
                    patientAuthorizationNumber.AuthorizationNumber = item.AuthorizationNumber;
                    patientAuthorizationNumber.EffectiveDate = item.EffectiveDate;
                    patientAuthorizationNumber.ExpirationDate = item.ExpirationDate;
                    authList.Add(patientAuthorizationNumber);
                }

                insurancePolicy.PatientAuthorizationNumber = authList;
            }

            return insurancePolicy;
        }

        private InsuranceGuarantor SetInsuranceGuarantor(Guarantorpatientguarantor[] guarantorpatientList)
        {
            InsuranceGuarantor insuranceGuarantor = new InsuranceGuarantor();
            if (guarantorpatientList.Count() > 0)
            {
                foreach (Guarantorpatientguarantor guarantorpatient in guarantorpatientList)
                {
                    insuranceGuarantor.GuarantorNumber = "";
                    insuranceGuarantor.FirstName = guarantorpatient.guarantorInsuranceGuarantor.firstName;
                    insuranceGuarantor.LastName = guarantorpatient.guarantorInsuranceGuarantor.lastName;
                    insuranceGuarantor.Address1 = guarantorpatient.guarantorInsuranceGuarantor.address1;
                    insuranceGuarantor.HomePhone = guarantorpatient.guarantorInsuranceGuarantor.homePhone;
                    insuranceGuarantor.BusPhone = guarantorpatient.guarantorInsuranceGuarantor.busPhone;
                    insuranceGuarantor.GuarantorRel = guarantorpatient.relationPolicyHolderRelation.description;
                    insuranceGuarantor.OrganizationName = guarantorpatient.guarantorInsuranceGuarantor.organizationName;
                    insuranceGuarantor.Zip = guarantorpatient.guarantorInsuranceGuarantor.zip;
                    insuranceGuarantor.State = guarantorpatient.guarantorInsuranceGuarantor.state;
                    insuranceGuarantor.City = guarantorpatient.guarantorInsuranceGuarantor.city;
                    if (guarantorpatient.guarantorInsuranceGuarantor.address2 != null)
                        insuranceGuarantor.Address2 = guarantorpatient.guarantorInsuranceGuarantor.address2.ToString();
                    insuranceGuarantor.DOB = guarantorpatient.guarantorInsuranceGuarantor.dob;
                }
            }

            return insuranceGuarantor;
        }

        private List<IInvDiagnosis> SetDiagnosis(Admissiondiagnosis[] admissiondiagnosisList,IEnumerable<ICharges> charges)
        {
            List<IInvDiagnosis> diagnosis = new List<IInvDiagnosis>();

            if (admissiondiagnosisList.Count() > 0)
            {
                var primaryDx = charges.FirstOrDefault().ICD1;
                foreach (var item in admissiondiagnosisList)
                {
                    if(item.masterIcd10.code.Replace(".","")==primaryDx)
                    {
                        item.tempid = 100;
                    }
                }


                foreach (Admissiondiagnosis admissiondiagnosis in admissiondiagnosisList.ToList().OrderByDescending(i=>i.tempid))
                {
                    InvDiagnosis invDiagnosis = new InvDiagnosis();
                    invDiagnosis.ICDCode = admissiondiagnosis.masterIcd10.code.Replace(".", "");
                    invDiagnosis.Description = admissiondiagnosis.masterIcd10.description;
                    invDiagnosis.IcdClassification = admissiondiagnosis.masterIcd10.icdClassification;
                    diagnosis.Add(invDiagnosis);
                }
            }

            return diagnosis;
        }

        private List<IDiagnosisDTO> SetDiagnosisDTO(Admissiondiagnosis[] admissiondiagnosisList)
        {
            List<IDiagnosisDTO> diagnosis = new List<IDiagnosisDTO>();
            if (admissiondiagnosisList.Count() > 0)
            {
                foreach (Admissiondiagnosis admissiondiagnosis in admissiondiagnosisList)
                {
                    DiagnosisDTO invDiagnosis = new DiagnosisDTO();
                    invDiagnosis.Code = admissiondiagnosis.masterIcd10.code.Replace(".", "");
                    invDiagnosis.Description = admissiondiagnosis.masterIcd10.description;
                    invDiagnosis.IsExistInFavouriteList = false;
                    invDiagnosis.IcdClassification = admissiondiagnosis.masterIcd10.icdClassification;
                    diagnosis.Add(invDiagnosis);
                }
            }

            return diagnosis;
        }

        private Invoice SetInvoice(ArPatient arPatient)
        {
            Invoice invoice = new Invoice();
            if (arPatient != null)
            {
                invoice.IspmgEncounter = arPatient.IsPrimaryCareNPI;
                invoice.IsBillable = true;
                invoice.FeeAmount = arPatient.feeAmount;
                invoice.InvoiceType = arPatient.encounterClacification;
                invoice.AccessionNumber = arPatient.billingId.ToString();
                invoice.BillFromDate = arPatient.dateOfService;
                invoice.EntryDate = DateTime.Now;
                invoice.BillToDate = arPatient.dateOfService;
                invoice.ChargeList = SetChargeList(arPatient.admissionProcedures, arPatient.dateOfService, arPatient);
                invoice.InvDiagnosisLst = SetDiagnosis(arPatient.admissionDiagnosis, invoice.ChargeList);
                if (arPatient.admissionDate.Year > 1)
                    invoice.HospitalizedFrom = arPatient.admissionDate;
                if (arPatient.startDate.HasValue) if (arPatient.startDate.Value.Year > 1) invoice.FromTime = arPatient.startDate.Value;
                if (arPatient.endDate.HasValue) if (arPatient.endDate.Value.Year > 1) invoice.ToTime = arPatient.endDate.Value;

                ConvertDate(arPatient.startDate.Value);

            }

            return invoice;
        }

        private DateTime? ConvertDate(DateTime date)
        {
            string tempdate = date.ToShortDateString();

            return null;
        }

        private List<ICharges> SetChargeList(Admissionprocedure[] admissionproceduresList, DateTime dateOfService, ArPatient arPatient)
        {
            List<ICharges> chargesList = new List<ICharges>();
            if (admissionproceduresList.Count() > 0)
            {
                foreach (Admissionprocedure admissionprocedures in admissionproceduresList)
                {
                    Charges charges = new Charges();
                    charges.CPTCode = admissionprocedures.procedureCodeId;
                    charges.Qty = Convert.ToInt16(admissionprocedures.qty);
                    charges.BillFromDate = dateOfService;
                    charges.BillToDate = dateOfService;
                    charges.EntryDate = DateTime.Now;
                    charges.ICD1 = admissionprocedures.primaryDxId.Replace(".", "");
                    charges.ICD2 = admissionprocedures.dx2Id != null ? admissionprocedures.dx2Id.Replace(".", "") : admissionprocedures.dx2Id;
                    charges.ICD3 = admissionprocedures.dx3Id != null ? admissionprocedures.dx3Id.Replace(".", "") : admissionprocedures.dx3Id;
                    charges.ICD4 = admissionprocedures.dx4Id != null ? admissionprocedures.dx4Id.Replace(".", "") : admissionprocedures.dx4Id;

                    charges.Mod1 = admissionprocedures.mod1Id != null ? admissionprocedures.mod1Id.ToString() : null;
                    charges.Mod2 = admissionprocedures.mod2Id != null ? admissionprocedures.mod2Id.ToString() : null;
                    charges.Mod3 = admissionprocedures.mod3Id != null ? admissionprocedures.mod3Id.ToString() : null;
                    charges.Mod4 = admissionprocedures.mod4Id != null ? admissionprocedures.mod4Id.ToString() : null;

                    List<string> modifiers = new List<string>();
                    if (!string.IsNullOrWhiteSpace(charges.Mod1))
                        modifiers.Add(charges.Mod1);
                    if (!string.IsNullOrWhiteSpace(charges.Mod2))
                        modifiers.Add(charges.Mod2);
                    if (!string.IsNullOrWhiteSpace(charges.Mod3))
                        modifiers.Add(charges.Mod3);
                    if (!string.IsNullOrWhiteSpace(charges.Mod4))
                        modifiers.Add(charges.Mod4);

                    if (charges.CPTCode=="H0005")
                    {
                        if(charges.Mod1=="U2" || charges.Mod1 == "U3" || charges.Mod1 == "U4" || charges.Mod1 == "U5")
                        {
                            var checkHK = modifiers.FirstOrDefault(i => i.ToString() == "HK");
                            if(checkHK==null)
                            {
                                if(string.IsNullOrWhiteSpace(charges.Mod2))
                                {
                                    charges.Mod2 = "HK";
                                }
                                else if (string.IsNullOrWhiteSpace(charges.Mod3))
                                {
                                    charges.Mod3 = "HK";
                                }
                                else if (string.IsNullOrWhiteSpace(charges.Mod4))
                                {
                                    charges.Mod4 = "HK";
                                }
                            }
                        }
                    }

                    //if (charges.CPTCode == "H2000")
                    //{
                    //    var checkGT = modifiers.FirstOrDefault(i => i.ToString() == "GT");
                    //    if(checkGT!=null)
                    //    {
                    //        charges.Mod1 = "GT";
                    //        charges.Mod2 = null;
                    //        charges.Mod3 = null;
                    //        charges.Mod4 = null;
                    //    }
                    //    else
                    //    {
                    //        charges.Mod1 = null;
                    //        charges.Mod2 = null;
                    //        charges.Mod3 = null;
                    //        charges.Mod4 = null;
                    //    }
                    //}
                    //if (arPatient.placeOfService != null)
                    //{
                    //    charges.POSId = arPatient.placeOfService.Code;
                    //}

                    //if (arPatient.typeOfService != null)
                    //{
                    //    charges.TOSId = arPatient.typeOfService.Code;
                    //}

                    chargesList.Add(charges);
                }
            }

            return chargesList;
        }

        public async Task<IEnumerable<IProviderEmrDTO>> GetEMRProviders()
        {
            try
            {
                await this.GetPractitionerModifierList();

                var defaultFacility = await this._facilityRepository.GetDefaultFacility();

                IEnumerable<IProviderEmrDTO> providerList = await this._patientRepository.GetEMRProviders();
                foreach (var item in providerList.Where(i => i.canBill == true))
                {
                    var emrProvider = await this._providerRepository.GetByEmrId(item.id);
                    
                    if (emrProvider == null)
                    {
                        emrProvider = new Provider();
                        emrProvider.FacilityId = defaultFacility.Id;
                        emrProvider.FacilityUId = defaultFacility.UId;
                        emrProvider.IsActive = true;
                        emrProvider.TOC = true;
                        emrProvider.Slot = 0;
                        emrProvider.CreatedDate = DateTime.Now;
                        emrProvider.CreatedBy = "Admin";
                        emrProvider.ModifiedDate = DateTime.Now;
                        emrProvider.ModifiedBy = "Admin";
                        emrProvider.IsDefault = false;
                        emrProvider.EmrProviderId = item.id;                        
                    }
                    if (item.MHPractitonerModifierId.HasValue)
                        if (item.MHPractitonerModifierId.Value > 0)
                        {
                            var configPractitionerService = await this._configPractitionerService.GetByEmrId(item.MHPractitonerModifierId.Value);
                            if(configPractitionerService!=null)
                            {
                                emrProvider.PractitionerServiceId = configPractitionerService.Id;
                            }
                        }
                    if (item.SUDPractitonerModifierId.HasValue)
                        if (item.SUDPractitonerModifierId.Value > 0)
                        {
                            var configPractitionerService = await this._configPractitionerService.GetByEmrId(item.SUDPractitonerModifierId.Value);
                            if (configPractitionerService != null)
                            {
                                emrProvider.SUDPractitionerServiceId = configPractitionerService.Id;
                            }
                        }


                    emrProvider.FirstName = item.firstName;
                    emrProvider.LastName = item.lastName;
                    emrProvider.Middle = item.middleName;

                    if (emrProvider.Id > 0)
                    {
                        await this._providerIdentityRepository.DeleteByProviderId(emrProvider.Id);
                        await this._providerRepository.Update(emrProvider);
                    }
                    else
                    {
                        emrProvider = await this._providerRepository.AddNew(emrProvider);
                    }
                    List<ProviderIdentity> identities = new List<ProviderIdentity>();


                    if (item.providerIdentities != null)
                    {
                        List<ProviderIdentity> identityList = new List<ProviderIdentity>();
                        foreach (IProvideridentity identityItem in item.providerIdentities)
                        {
                            if (!identityItem.identity.billingIdentityId.HasValue)
                            {
                                continue;
                            }
                            ProviderIdentity providerIdentity = new ProviderIdentity();
                            providerIdentity.ActiveDate = identityItem.activeDate;
                            providerIdentity.InactiveDate = identityItem.inactiveDate;
                            providerIdentity.ProviderId = emrProvider.Id;
                            providerIdentity.ProviderUId = emrProvider.UId;
                            providerIdentity.TypeId = identityItem.identity.billingIdentityId.Value;
                            providerIdentity.Identifier = identityItem.value;
                            identityList.Add(providerIdentity);
                        }
                        await this._providerIdentityRepository.AddOrUpdate(identityList);
                    }
                }

                return providerList;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<IPractitionerModifiersDTO>> GetPractitionerModifierList()
        {
            IEnumerable<IPractitionerModifiersDTO> practitionerServices = await this._patientRepository.GetPractitionerModifierList();

            foreach (var item in practitionerServices)
            {
                var configPractitionerService = await this._configPractitionerService.GetByEmrId(item.id);
                if(configPractitionerService==null)
                {
                    configPractitionerService = new ConfigPractitionerService();
                }

                configPractitionerService.EmrId = item.id;
                configPractitionerService.IsActive = true;
                configPractitionerService.ProvidingService = item.description;
                configPractitionerService.ProfessionalAbbreviation = item.name;
                configPractitionerService.Designation = "A";
                if (item.cptModifier != null)
                {
                    if (item.cptModifier.code != "NA")
                    {
                        var cptModifier = await this._cPTModifierRepository.GetByCode(item.cptModifier.code);
                        if (cptModifier != null)
                        {
                            configPractitionerService.CPTModifier_Id = cptModifier.ID;
                        }
                        else
                        {
                            cptModifier = new CPTModifier();
                            cptModifier.Code = item.cptModifier.code;
                            cptModifier.Description = item.cptModifier.description;
                            var record = await this._cPTModifierRepository.AddNew(cptModifier);
                            configPractitionerService.CPTModifier_Id = record.ID;
                            configPractitionerService.CPTModifierUId = record.UId;
                        }
                        configPractitionerService.PractitionerModifier = item.cptModifier.code;
                    }
                    else
                    {
                        configPractitionerService.CPTModifier_Id = null;
                    }
                }
                if(configPractitionerService.Id>0)
                {
                    await this._configPractitionerService.Update(configPractitionerService);
                }
                else
                {
                    await this._configPractitionerService.AddNew(configPractitionerService);
                }
                
            }

            return null;
        }

        public async Task<IEnumerable<IFacilityEMRDto>> GetEMRFacilities()
        {
            try
            {

                IEnumerable<IFacilityEMRDto> faciliyList = await this._patientRepository.GetEMRFacilities();
                List<string> mhsud = new List<string>() { "28", "29" };
                foreach (var item in faciliyList)
                {
                    if (item.facilityIdentities != null)
                    {
                        var checkSUDMH = item.facilityIdentities.Where(i => mhsud.Contains(i.identity.billingIdentityId.ToString()));
                        if (checkSUDMH.Count() == 2)
                        {
                            foreach (var npi in checkSUDMH.OrderBy(i => i.identity.billingIdentityId))
                            {
                                if (npi.identity.billingIdentityId == 28)
                                {
                                    await ProviderMHSUDLogic(item, npi.value, true);
                                }
                                else
                                {
                                    await ProviderMHSUDLogic(item, npi.value, false);
                                }

                            }
                            continue;
                        }
                    }

                    var isMhRecord = item.facilityIdentities.FirstOrDefault(i => mhsud.Contains(i.identity.billingIdentityId.ToString()));
                    bool IsMentalFacility = false;
                    if (isMhRecord != null)
                    {
                        if (isMhRecord.identity.billingIdentityId == 28)
                        {
                            IsMentalFacility = true;
                        }
                        if (isMhRecord.identity.billingIdentityId == 29)
                        {
                            IsMentalFacility = false;
                        }
                    }

                    var emrfacility = await this._facilityRepository.GetByCode(item.facilityCode, false);
                    if (emrfacility == null)
                    {
                        emrfacility = new Facility();
                        emrfacility.EMRFacilityId = item.id;
                    }
                    emrfacility.IsMentalFacility = IsMentalFacility;
                    emrfacility.Name = item.name;
                    emrfacility.PracticeId = 1;
                    emrfacility.Address1 = item.address1;
                    emrfacility.Address2 = item.address2;
                    emrfacility.ZipCode = item.zipCode;
                    emrfacility.city = item.city;
                    emrfacility.state = item.state;
                    emrfacility.FacilityCode = item.facilityCode;
                    emrfacility.FacilityDescription = item.facilityDescription;
                    emrfacility.POSCode = item.posCode;
                    emrfacility.LocationCode = item.locationCode;
                    emrfacility.TimeZone = item.timeZone;
                    emrfacility.ServiceTypeCode = item.serviceTypeCode;
                    emrfacility.IsActive = true;
                    emrfacility.CreatedBy = "Admin";
                    emrfacility.ModifiedBy = "Admin";
                    emrfacility.CreatedDate = DateTime.Now;
                    emrfacility.ModifiedDate = DateTime.Now;
                    emrfacility.Phone = item.phone;
                    emrfacility.IsDefault = item.isDefaultLocation;

                    if (emrfacility.Id > 0)
                    {
                        await this._facilityIdentityRepository.DeleteByFacilityId(emrfacility.Id);
                        await this._facilityRepository.Update(emrfacility);
                    }
                    else
                    {
                        emrfacility = await this._facilityRepository.AddNew(emrfacility);
                    }

                    List<ProviderIdentity> identities = new List<ProviderIdentity>();


                    if (item.facilityIdentities != null)
                    {
                        List<FacilityIdentity> identityList = new List<FacilityIdentity>();
                        int countid = 1;
                        foreach (IFacilityidentity identityItem in item.facilityIdentities)
                        {
                            FacilityIdentity providerIdentity = new FacilityIdentity();
                            providerIdentity.ActiveDate = identityItem.activeDate;
                            providerIdentity.InactiveDate = identityItem.inactiveDate;
                            providerIdentity.FacilityId = emrfacility.Id;
                            providerIdentity.FacilityUId = emrfacility.UId;
                            if (identityItem.identity.billingIdentityId.Value == 28 || identityItem.identity.billingIdentityId.Value == 29)
                                providerIdentity.TypeId = 1;
                            else
                                providerIdentity.TypeId = identityItem.identity.billingIdentityId.Value;
                            providerIdentity.Identifier = identityItem.value;
                            identityList.Add(providerIdentity);
                            countid++;
                        }
                        await this._facilityIdentityRepository.AddOrUpdate(identityList);

                    }

                }

                return faciliyList;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task ProviderMHSUDLogic(IFacilityEMRDto item, string npi, bool isMH)
        {

            var emrfacility = await this._facilityRepository.GetByCode(item.facilityCode, isMH);


            if (emrfacility == null)
            {
                emrfacility = new Facility();
                emrfacility.EMRFacilityId = item.id;
            }

            emrfacility.IsMentalFacility = isMH;
            emrfacility.Name = item.name + (isMH == true ? "-MH" : "-SUD");
            emrfacility.PracticeId = 1;
            emrfacility.Address1 = item.address1;
            emrfacility.Address2 = item.address2;
            emrfacility.ZipCode = item.zipCode;
            emrfacility.city = item.city;
            emrfacility.state = item.state;
            emrfacility.FacilityCode = item.facilityCode;
            emrfacility.FacilityDescription = item.facilityDescription;
            emrfacility.POSCode = item.posCode;
            emrfacility.LocationCode = item.locationCode;
            emrfacility.TimeZone = item.timeZone;
            emrfacility.ServiceTypeCode = item.serviceTypeCode;
            emrfacility.IsActive = true;
            emrfacility.CreatedBy = "Admin";
            emrfacility.ModifiedBy = "Admin";
            emrfacility.CreatedDate = DateTime.Now;
            emrfacility.ModifiedDate = DateTime.Now;
            emrfacility.Phone = item.phone;

            if (emrfacility.Id > 0)
            {
                await this._facilityIdentityRepository.DeleteByFacilityId(emrfacility.Id);
                await this._facilityRepository.Update(emrfacility);
            }
            else
            {
                emrfacility = await this._facilityRepository.AddNew(emrfacility);
            }

            List<ProviderIdentity> identities = new List<ProviderIdentity>();


            if (item.facilityIdentities != null)
            {
                List<FacilityIdentity> identityList = new List<FacilityIdentity>();
                int countid = 1;
                short typeId = 0;
                bool isNPIExist = false;
                string identifier = "";
                foreach (IFacilityidentity identityItem in item.facilityIdentities)
                {
                    if (identityItem.identity.billingIdentityId.HasValue)
                    {
                        if (identityItem.identity.billingIdentityId.Value == 28 || identityItem.identity.billingIdentityId.Value == 29)
                        {
                            if (isNPIExist)
                            {
                                continue;
                            }
                            typeId = 1;
                            identifier = npi;
                            isNPIExist = true;
                        }
                        else
                        {
                            typeId = identityItem.identity.billingIdentityId.Value;
                            identifier = identityItem.value;
                        }

                        FacilityIdentity providerIdentity = new FacilityIdentity();
                        providerIdentity.ActiveDate = identityItem.activeDate;
                        providerIdentity.InactiveDate = identityItem.inactiveDate;
                        providerIdentity.FacilityId = emrfacility.Id;
                        providerIdentity.FacilityUId = emrfacility.UId;
                        providerIdentity.TypeId = typeId;
                        providerIdentity.Identifier = identifier;
                        identityList.Add(providerIdentity);
                        countid++;
                    }
                }
                await this._facilityIdentityRepository.AddOrUpdate(identityList);

            }
        }

        public async Task<bool> SyncEmrPatients()
        {
            try
            {
                IEnumerable<ISyncPatientDetailDTO> patientList = await this._patientRepository.GetPatientsForSync();
                foreach (var item in patientList)
                {
                    try
                    {
                        var patient = await this._patientRepository.CheckPatientExist(item.Id.ToString());
                        if (patient != null)
                        {
                            patient.DOB = item.DOB;

                            if (!string.IsNullOrWhiteSpace(item.Address1))
                                patient.Address1 = item.Address1;
                            if (!string.IsNullOrWhiteSpace(item.Address2))
                                patient.Address2 = item.Address2;
                            if (!string.IsNullOrWhiteSpace(item.BillAddress1))
                                patient.BillAddress1 = item.BillAddress1;
                            if (!string.IsNullOrWhiteSpace(item.BillAddress2))
                                patient.BillAddress2 = item.BillAddress2;
                            if (!string.IsNullOrWhiteSpace(item.BillCity))
                                patient.BillCity = item.BillCity;
                            if (!string.IsNullOrWhiteSpace(item.BillState))
                                patient.BillState = item.BillState;
                            if (!string.IsNullOrWhiteSpace(item.BillZip))
                                patient.BillZip = item.BillZip;
                            if (!string.IsNullOrWhiteSpace(item.City))
                                patient.City = item.City;
                            if (!string.IsNullOrWhiteSpace(item.FirstName))
                                patient.FirstName = item.FirstName;
                            if (!string.IsNullOrWhiteSpace(item.LastName))
                                patient.LastName = item.LastName;
                            if (!string.IsNullOrWhiteSpace(item.MaidenName))
                                patient.MaidenName = item.MaidenName;
                            if (!string.IsNullOrWhiteSpace(item.MI))
                                patient.MI = item.MI;
                            if (!string.IsNullOrWhiteSpace(item.MobilePhoneNumber))
                                patient.MobilePhoneNumber = item.MobilePhoneNumber;
                            if (!string.IsNullOrWhiteSpace(item.PhoneNumber))
                                patient.PhoneNumber = item.PhoneNumber;
                            if (!string.IsNullOrWhiteSpace(item.SSN))
                                patient.SSN = item.SSN;
                            if (!string.IsNullOrWhiteSpace(item.State))
                                patient.State = item.State;
                            if (!string.IsNullOrWhiteSpace(item.ZipCode))
                                patient.ZipCode = item.ZipCode;

                            await this._patientRepository.UpdatePatientByEmrSync(patient);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                    
                }

                if(patientList.Count()>0)
                    await this._patientRepository.SendPatientSyncAckToEMR(patientList.Select(i => i.Id));

                return true;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //private async Task ProviderMHSUDLogic(IFacilityEMRDto item,string npi,bool isMH)
        //{

        //    var facilityId = await this._facilityIdentityRepository.GetFacilityBasedOnNPI(npi);

        //    Base.Entities.MasterService.IFacility emrfacility = null;
        //    if(facilityId==0)
        //    {
        //        emrfacility = await this._facilityRepository.GetByEmrIdWithMH(item.id,isMH);                
        //    }

        //    if(facilityId>0)
        //    {
        //        emrfacility = await this._facilityRepository.GetById((short)facilityId);
        //    }

        //    if (emrfacility == null)
        //    {
        //        emrfacility = new Facility();
        //        emrfacility.EMRFacilityId = item.id;
        //    }

        //    emrfacility.IsMentalFacility = isMH;
        //    emrfacility.Name = item.name+(isMH==true?"-MH":"-SUD");
        //    emrfacility.PracticeId = 1;
        //    emrfacility.Address1 = item.address1;
        //    emrfacility.Address2 = item.address2;
        //    emrfacility.ZipCode = item.zipCode;
        //    emrfacility.city = item.city;
        //    emrfacility.state = item.state;
        //    emrfacility.FacilityCode = item.facilityCode;
        //    emrfacility.FacilityDescription = item.facilityDescription;
        //    emrfacility.POSCode = item.posCode;
        //    emrfacility.LocationCode = item.locationCode;
        //    emrfacility.TimeZone = item.timeZone;
        //    emrfacility.ServiceTypeCode = item.serviceTypeCode;
        //    emrfacility.IsActive = true;
        //    emrfacility.CreatedBy = "Admin";
        //    emrfacility.ModifiedBy = "Admin";
        //    emrfacility.CreatedDate = DateTime.Now;
        //    emrfacility.ModifiedDate = DateTime.Now;
        //    emrfacility.Phone = item.phone;

        //    if (emrfacility.Id > 0)
        //    {
        //        await this._facilityIdentityRepository.DeleteByFacilityId(emrfacility.Id);
        //        await this._facilityRepository.Update(emrfacility);
        //    }
        //    else
        //    {
        //      emrfacility=  await this._facilityRepository.AddNew(emrfacility);
        //    }

        //    List<ProviderIdentity> identities = new List<ProviderIdentity>();


        //    if (item.facilityIdentities != null)
        //    {
        //        List<FacilityIdentity> identityList = new List<FacilityIdentity>();
        //        int countid = 1;
        //        short typeId = 0;
        //        bool isNPIExist = false;
        //        string identifier = "";
        //        foreach (IFacilityidentity identityItem in item.facilityIdentities)
        //        {
        //            if(identityItem.identity.billingIdentityId.HasValue)
        //            {                        
        //                if(identityItem.identity.billingIdentityId.Value==28 || identityItem.identity.billingIdentityId.Value == 29)
        //                {
        //                    if(isNPIExist)
        //                    {
        //                        continue;
        //                    }
        //                    typeId = 1;
        //                    identifier = npi;
        //                    isNPIExist = true;
        //                }
        //                else
        //                {
        //                    typeId = identityItem.identity.billingIdentityId.Value;
        //                    identifier = identityItem.value;
        //                }

        //                FacilityIdentity providerIdentity = new FacilityIdentity();
        //                providerIdentity.ActiveDate = identityItem.activeDate;
        //                providerIdentity.InactiveDate = identityItem.inactiveDate;
        //                providerIdentity.FacilityId = emrfacility.Id;
        //                providerIdentity.FacilityUId = emrfacility.UId;
        //                providerIdentity.TypeId = typeId;
        //                providerIdentity.Identifier = identifier;
        //                identityList.Add(providerIdentity);
        //                countid++;
        //            }                    
        //        }
        //        await this._facilityIdentityRepository.AddOrUpdate(identityList);

        //    }
        //}

    }

}