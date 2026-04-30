using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientStatementRepository
    {
        Task<IEnumerable<IPatientStatement>> GetAll(int patientId);
        Task<IPatientStatement> Get(Guid uId);
        Task<IPatientStatement> AddNew(IPatientStatement entity);
        Task<int> Delete(string uid);
        Task<IEnumerable<IPatientStatement>> GetById(int Id);
        Task<string> GetPatientByIds(List<string> ids);
        Task<int> GetCount(int batchStatementId);
    }
}
