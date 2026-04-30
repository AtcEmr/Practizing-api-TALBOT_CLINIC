using Newtonsoft.Json;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.PatientService;
using PractiZing.BusinessLogic.ChargePaymentService.Repositories;
using PractiZing.DataAccess.PatientService.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Services
{
    public class InsurancePolicyService : IInsurancePolicyService
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
        private readonly IFSDiscountRepository _fSDiscountRepository;
        private readonly IInsurancePolicyExceptionRepository _insurancePolicyExceptionRepository;

        public InsurancePolicyService(IInsuranceCompanyRepository insuranceCompanyRepository,
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
                                      IInsurancePolicyExceptionRepository insurancePolicyExceptionRepository)
        {
            this._insurancePolicyExceptionRepository = insurancePolicyExceptionRepository;
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
            this._fSDiscountRepository = fSDiscountRepository;
        }

        public async Task<IInsuranceDTO> GetByUId(Guid uid)
        {
            InsuranceDTO insuranceDTO = new InsuranceDTO();
            var policyData = await this._insurancePolicyRepository.GetByUId(uid);

            if (policyData != null)
            {
                insuranceDTO.InsurancePolicy = policyData;
                insuranceDTO.InsuranceCompany = await this._insuranceCompanyRepository.GetByUId(policyData.InsuranceCompanyUId);
                insuranceDTO.InsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetByUId(policyData.PHUId);
            }

            return insuranceDTO;
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetPolicies(Guid patientCaseUId, DateTime fromDate)
        {
            try
            {
                var patientCase = await this._patientCaseRepository.GetByUId(patientCaseUId);
                patientCase.Id = patientCase == null ? 0 : patientCase.Id;

                var result = await this._insurancePolicyRepository.GetPolicies(patientCase.Id, fromDate);
                foreach (var item in result)
                {
                    var res = (await this._insuranceCompanyRepository.GetById(item.InsuranceCompanyID));
                    item.InsuranceCompanyName = res.CompanyName;
                    item.IsGCodeAccepted = res.IsGCodeAccepted;
                    item.PatientAuthorizationNumber = await this._patientAuthorizationNumberRepository.GetAuthorizationNos(item.Id, fromDate);
                    item.InsuranceCompanyUId = res.UId;
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetActivePolicies(Guid patientCaseUId, DateTime fromDate)
        {
            try
            {
                var patientCase = await this._patientCaseRepository.GetByUId(patientCaseUId);

                return await this._insurancePolicyRepository.GetActivePolicies(patientCase.Id, fromDate);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetByPatientCaseUId(string patientCaseUId)
        {
            var patientCase = await this._patientCaseRepository.GetByUId(Guid.Parse(patientCaseUId));
            patientCase.Id = patientCase == null ? 0 : patientCase.Id;

            var result = await this._insurancePolicyRepository.GetByPatientCaseId(patientCase.Id);
            if (result == Guid.Empty)
                return null;
            return JsonConvert.SerializeObject(result.ToString()); ;
        }

        public async Task<IInsurancePolicy> Add(IInsurancePolicy entity, bool isFromHL7 = false)
        {
            var transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var _patientCase = await this._patientCaseRepository.GetByUId(entity.PatientCaseUId);
                var patientData = (await this._patientRepository.GetById(Convert.ToInt16(_patientCase.PatientId)));
                entity.PatientCaseId = _patientCase.Id;
                entity.InsurancePolicyHolder.PatientId = Convert.ToInt32(_patientCase.PatientId);

                if (isFromHL7)
                {
                    entity.IsFromIntegration = true;
                    //var allPolicies = await this._insurancePolicyRepository.GetById(_patientCase.Id);
                    //if (allPolicies.Count() == 0)
                    //    entity.PlanEffectiveDate = Convert.ToDateTime("1 June 2021");
                }
                else
                {
                    entity.IsFromIntegration = false;
                }

                if (patientData != null)
                {
                    entity.InsurancePolicyHolder.Address1 = patientData.Address1;
                    entity.InsurancePolicyHolder.Address2 = patientData.Address2;
                    entity.InsurancePolicyHolder.City = patientData.City;
                    entity.InsurancePolicyHolder.State = patientData.State;
                    entity.InsurancePolicyHolder.Zip = patientData.ZipCode;
                    entity.InsurancePolicyHolder.ModifiedDate = DateTime.Now;
                }

                var existingPH = await this._insurancePolicyHolderRepository.GetByIdAndRel(patientData.Id, entity.PHRelationshipToPatient);
                IInsurancePolicyHolder savePolicyHolder = null;

                if (existingPH == null)
                {
                    savePolicyHolder = await this._insurancePolicyHolderRepository.AddNew(entity.InsurancePolicyHolder);
                }
                else
                {
                    entity.InsurancePolicyHolder.Id = existingPH.Id;
                    entity.InsurancePolicyHolder.UId = existingPH.UId;
                    savePolicyHolder = await this._insurancePolicyHolderRepository.Update(entity.InsurancePolicyHolder);
                }

                entity.PHID = savePolicyHolder.Id;
                entity.PHUId = savePolicyHolder.UId;

                var savepolicy = await this._insurancePolicyRepository.AddNew(entity, isFromHL7);
                savepolicy.InsurancePolicyHolder = savePolicyHolder;

                if (entity.PatientAuthorizationNumber != null)
                {
                    foreach (var authorizationNumber in entity.PatientAuthorizationNumber)
                    {
                        authorizationNumber.InsurancePolicyId = savepolicy.Id;
                        var authRecord = await this._patientAuthorizationNumberRepository.AddNewFromIntegration(authorizationNumber);
                        List<IPatientAuthorizationNumber> authorizationList = new List<IPatientAuthorizationNumber>();
                        authorizationList.Add(authRecord);
                        if (authRecord != null)
                        {
                            savepolicy.PatientAuthorizationNumber = authorizationList;
                        }
                    }
                }

                this._transactionProvider.CommitTransaction(transactionId);
                return savepolicy;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        //public async Task<IInsuranceDTO> GetByPolicyId(int policyId)
        //{
        //    InsuranceDTO insuranceDTO = new InsuranceDTO();
        //    var policyData = await this._insurancePolicyRepository.GetByPolicyUId(policyUId);

        //    if (policyData != null)
        //    {
        //        insuranceDTO.InsurancePolicy = policyData;
        //        insuranceDTO.InsuranceCompany = await this._insuranceCompanyRepository.GetById(policyData.InsuranceCompanyID.Value);
        //        insuranceDTO.InsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetByUId(policyData.PHUId);
        //    }

        //    return insuranceDTO;
        //}

        public async Task<int> DeleteAllByPatientId(int patientId)
        {
            var patient = await this._patientRepository.GetById(patientId);
            if(patient!=null)
            {
                var policies = await this._insurancePolicyRepository.GetById(patient.DefaultCaseId.Value);
                foreach (var item in policies)
                {
                    await this.Delete(item.UId);
                }
            }
            return 0;
        }

        public async Task<int> DeleteAllByPatientId(int patientId,IEnumerable<int> emrPlociesIds)
        {
            var patient = await this._patientRepository.GetById(patientId);
            if (patient != null)
            {
                var policies = await this._insurancePolicyRepository.GetById(patient.DefaultCaseId.Value);
                policies = policies.Where(i => !emrPlociesIds.Contains((int)i.EMRInsurancePolicyId));
                foreach (var item in policies)
                {
                    await this.Delete(item.UId);
                }
            }
            return 0;
        }

        public async Task<int> Delete(Guid uid)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var policy = await this._insurancePolicyRepository.GetByUId(uid);

                if (policy != null && policy.InsuranceLevel == 1)
                {
                    var _policies = await this._insurancePolicyRepository.GetPoliciesByPatientCaseId(policy.PatientCaseId);
                    //if (!policy.PlanExpirationDate.HasValue)
                    //{
                    //    if (_policies.Count() > 0)
                    //        await this._insurancePolicyRepository.ErrorDeletingInsurancePolicy();
                    //}
                    //else
                    //{
                    //    var _policiesBetweenPrimary = _policies.FirstOrDefault(i => i.PlanEffectiveDate >= policy.PlanEffectiveDate && i.PlanEffectiveDate <= policy.PlanExpirationDate);
                    //    if (_policiesBetweenPrimary != null)
                    //        await this._insurancePolicyRepository.ErrorDeletingInsurancePolicy();
                    //}

                    //var _policiesBetweenPrimary = _policies.FirstOrDefault(i => i.PlanEffectiveDate >= policy.PlanEffectiveDate && i.PlanEffectiveDate <= policy.PlanExpirationDate);
                    //if (_policiesBetweenPrimary != null)
                    //    await this._insurancePolicyRepository.ErrorDeletingInsurancePolicy();
                }

                //if (policy != null && policy.InsuranceLevel == 1)
                //{
                //    var _policies = await this._insurancePolicyRepository.GetPoliciesByPatientCaseId(policy.PatientCaseId);
                //    var _policiesBetweenPrimary = _policies.FirstOrDefault(i => i.PlanEffectiveDate >= policy.PlanEffectiveDate && i.PlanExpirationDate <= policy.PlanExpirationDate);

                //    if (_policiesBetweenPrimary == null)
                //        await this._insurancePolicyRepository.ErrorDeletingInsurancePolicy();
                //}

                //delete InsurancePolicyHolder corresponding to this policy
                if (policy != null)
                {
                    var checkPHIDUsed = await this._insurancePolicyRepository.CheckPolicyHoderUsed(policy.Id, policy.PHID);
                    if (!checkPHIDUsed)
                    {
                        await this._insurancePolicyHolderRepository.Delete(policy.PHUId);
                    }
                }

                // DELETE PatientAuthorizationNumber corresponding to this policy
                await this._patientAuthorizationNumberRepository.DeleteInsurancePolicy(policy.Id);

                await this._insurancePolicyExceptionRepository.DeleteByPolicyId((int)policy.Id);

                //DELETE InsurancePolicy 
                await this._insurancePolicyRepository.DeleteByUId(uid);

                this._transactionProvider.CommitTransaction(transactionId);
                return 1;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> DeleteInsuranceCompany(Guid insuranceCompanyUId)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var insuranceCompany = await this._insuranceCompanyRepository.GetByUId(insuranceCompanyUId);
                var insuranceCompanyId = insuranceCompany == null ? 0 : insuranceCompany.Id;
                var insurancePolicy = await this._insurancePolicyRepository.Get(insuranceCompanyId);
                if (insurancePolicy.Count() > 0)
                {
                    var errors = await this._insurancePolicyRepository.AddValidationError();
                    await this._insurancePolicyRepository.ThrowError(errors);
                }

                var voucher = await this._voucherRepository.GetByInsuranceCompanyId(insuranceCompanyId);
                if (voucher != null)
                    await this._voucherRepository.VoucherExists();

                var discounts = await this._fSDiscountRepository.GetByInsuranceCompanyId(insuranceCompanyId);
                if (discounts != null)
                    await this._fSDiscountRepository.ValidateFsDisocunt();

                var claimConfig = await this._claimConfigRepository.GetCompany(insuranceCompanyId);
                if (claimConfig != null)
                    await this._insurancePolicyRepository.ValidateClaimConfig();

                await this._insuranceCompanyRepository.DeleteByUId(insuranceCompanyUId);
                this._transactionProvider.CommitTransaction(transactionId);
                return 1;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> SendInsuranceACKToEMR()
        {
            var list = await this._insurancePolicyRepository.GetListForEMR();
            return 1;
        }
    }
}
