using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Model;
using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.PatientService
{
    public interface IPatientService
    {
        Task<IEnumerable<IPatientStatement>> GetPatientStatement(string patientUId);
        Task<IPatient> GetById(int id);
        Task<IPatient> GetByUId(Guid UId);
        Task<IEnumerable<IPatientChargeDTO>> Get(string patientName);
        Task<IPatientAuthorizationNumber> GetByInsurancePolicyUId(string insurancePolicyUId);
        Task<IPatient> Get(Guid patientUId, int patientCaseId);
        Task<IPatient> AddNew(IPatient entity);
        Task<IPatient> AddPatientInsuranceDetail(IPatient entity);
        //Task<int> UpdateEntity(IPatient entity);
        Task<int> DeletePatient(int patientId);
        Task<int> Delete(Guid uid);
        Task<IPatient> UpdateEntity(IPatient entity);
        Task<IEnumerable<IPatientStatementRDLCDTO>> GetAgingPatient();
        Task<IEnumerable<IArPatient>> GetArPatientBillingData();
    }
}
