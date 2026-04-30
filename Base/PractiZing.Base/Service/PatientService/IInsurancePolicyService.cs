using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.PatientService
{
    public interface IInsurancePolicyService
    {
        Task<string> GetByPatientCaseUId(string patientCaseUId);
        Task<IInsurancePolicy> Add(IInsurancePolicy entity, bool isFromHL7 = false);
        Task<int> DeleteInsuranceCompany(Guid insuranceCompanyUId);
        // Task<IInsuranceDTO> GetByPolicyId(int policyId);
        Task<IInsuranceDTO> GetByUId(Guid uid);
        Task<IEnumerable<IInsurancePolicy>> GetPolicies(Guid patientCaseUId, DateTime fromDate);
        Task<int> Delete(Guid policyUId);
        Task<IEnumerable<IInsurancePolicy>> GetActivePolicies(Guid patientCaseUId, DateTime fromDate);
        Task<int> SendInsuranceACKToEMR();
        Task<int> DeleteAllByPatientId(int patientId);
        Task<int> DeleteAllByPatientId(int patientId, IEnumerable<int> emrPlociesIds);
    }
}
