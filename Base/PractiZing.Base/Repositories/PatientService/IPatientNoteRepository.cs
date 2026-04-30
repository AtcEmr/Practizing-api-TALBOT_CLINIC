using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientNoteRepository
    {
        Task<IPatientNote> AddNew(IPatientNote entity);
        Task<int> Update(IPatientNote entity);
        Task<IPatientNote> Get(Guid UId);
        Task<IEnumerable<IPatientNote>> Get();
        Task<IEnumerable<IPatientNote>> GetByPatientUId(Guid patientUId);
        Task<int> Delete(Guid UId);
    }
}
