using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IInsurancePolicyRepository
    {
        Task<IEnumerable<IInsurancePolicy>> GetByPatientCaseUIds(string patientCaseUIds);
        Task<IEnumerable<IInsurancePolicy>> Get(int insuranceCompanyId);
        Task<IInsurancePolicy> GetByUId(Guid uid);
        Task<IInsurancePolicy> GetByPolicyId(int policyId);
        Task<IEnumerable<IInsurancePolicy>> GetByPatientId(int patientId);
        Task<Guid> GetByPatientCaseId(int patientCaseId);
        Task<IEnumerable<IInsurancePolicy>> GetByCaseId(IEnumerable<int> patientCaseId);
        Task<IEnumerable<IInsurancePolicy>> GetActivePolicies(int patientCaseId, DateTime fromDate);
        Task<IEnumerable<IInsurancePolicy>> GetPolicies(int patientCaseId, DateTime fromDate);
        Task<IEnumerable<IInsurancePolicy>> GetById(int patientCaseId);
        Task<IInsurancePolicy> GetByPolicyNumber(string policyNumber, IEnumerable<int> patientCaseIds);
        Task<IInsurancePolicy> GetByInsuranceCompanyId(int companyId);
        Task<IEnumerable<IInsurancePolicy>> GetByInsuranceCompanyId(IEnumerable<int> companyIds);
        Task<IInsurancePolicy> Get(int patientCaseId, int level);
        Task<IInsurancePolicy> GetById(int patientCaseId, int insuranceId);
        //Task<IEnumerable<IInsurancePolicy>> GetPoliciesByPatientCaseUId(Guid patientCaseUId);
        Task<IEnumerable<IInsurancePolicy>> GetInsurancePolicies(string billingId);
        Task<IInsurancePolicy> AddNew(IInsurancePolicy entity, bool isFromHL7 = false);

        Task<int> Update(IInsurancePolicy entity, bool isConditionCheck = true, bool isfromUI = false);
        Task<int> DeleteByUId(Guid uId);
        Task<int> Delete(int policyId);
        Task<int> DeleteByPatientCaseId(int patientCaseId);
        Task PolicyDoesNotExist();
        Task ThrowError(IInsurancePolicy policyData);
        Task ErrorDeletingInsurancePolicy();
        Task ThrowError(IEnumerable<IValidationResult> errors);
        Task ValidateInsurancePolicy();
        Task ValidateClaimConfig();
        Task<List<IValidationResult>> AddValidationError();
        // Task<IEnumerable<IInsurancePolicy>> GetByPolicyHolderId(IInsurancePolicyHolder entity);
        //Task<IEnumerable<IInsurancePolicy>> GetPoliciesByPatientCaseId(int patientCaseId);//
        // Task<IEnumerable<IInsurancePolicy>> GetByPolicyHolderId(IInsurancePolicyHolder entity);
        Task<IEnumerable<IInsurancePolicy>> GetPoliciesByPatientCaseId(int patientCaseId);
        Task<bool> CheckInsurancePolicyExists(int patientCaseId, DateTime fromDate, int insuranceLevel);
        Task<string> VerifyPatientEligibility(Guid patientUId, Guid policyUId, string serviceTypeCode);
        Task<IEnumerable<IInsurancePolicyDTO>> GetActivePolicies(IEnumerable<int> patientCaseIds);
        Task<string> GetCompanyType(int patientCaseId, DateTime fromDate);
        Task ValidateMedicaidInsurancePolicy();
        Task<bool> CheckPolicyHoderUsed(long policyId, int policyHolderId);
        Task<IEnumerable<IInsurancePolicy>> GetPoliciesFromHL7(int patientCaseId, DateTime fromDate);
        Task ValidateAnthemInsurancePolicy();
        Task<IEnumerable<IInsurancePolicy>> GetListForEMR();
        Task ValidateSelfPInsurancePolicy();
        Task<IEnumerable<IInsurancePolicy>> GetPoliciesForClaim(int patientCaseId, DateTime fromDate);
        Task ValidateInsuranceCompanyType();
        Task<IEnumerable<IInsurancePolicy>> GetPolicyEMRExceptionList();
        Task<IPolicyException> SendAcktoEMRAfterAddOrUpdate(IInsurancePolicy insurancePolicy);
        Task ThrowErrorFromEMR(string errorMessage);
        Task CheckPoliciesCameOrNotFromEMR(List<int> policyIds, int patientCaseId);
        Task<IInsurancePolicy> GetSecondayPolicy(int patientCaseId, DateTime fromDate);
        Task<IEnumerable<IInsurancePolicy>> GetActivePolicies_OldCharges(int patientCaseId, DateTime fromDate);
        Task ValidateMedicaidZEROInsurancePolicy();
        Task<IEnumerable<IInsurancePolicyDTO>> GetActivePolicies_Secondary(IEnumerable<int> patientCaseIds);
        Task<IEnumerable<IInsurancePolicy>> GetActivePoliciesForAdjustClaims(int patientCaseId, DateTime fromDate);
    }
}
