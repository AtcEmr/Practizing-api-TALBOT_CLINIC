using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientCaseRepository
    {
        Task<IPatientCase> AddNew(IPatientCase entity);
        Task<IEnumerable<IPatientCase>> AddNew(IEnumerable<IPatientCase> entities, long patientId);
        Task UpdateEntity(IEnumerable<IPatientCase> entities, long patientId);
        Task<int> UpdateEntity(IPatientCase entity);
        Task<IEnumerable<IPatientCase>> GetPatientCases(Guid uniqueId);
        Task<IEnumerable<IPatientCase>> GetPatient(List<int> patientId);
        Task DeleteCase(int patientId);
        Task<IPatientCase> Get(int patientId);
        Task<IPatientCase> GetPatientCase(int patientCaseId);
        Task<IEnumerable<IPatientCase>> GetByUIds(IEnumerable<Guid> caseIds);
        Task<IPatientCase> GetByUId(Guid caseUId);
        Task<IPatientCase> GetById(int caseId);

        Task<IEnumerable<IPatientCase>> GetPatient(string patientUIds);
        Task<IPatientCase> GetByCaseNo(string caseNo);
        Task<IEnumerable<IPatientCase>> GetPatients(int patientId);

    }
}
