using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientAlertRepository
    {
        Task<IPatientAlert> AddNew(IPatientAlert entity);
        Task<int> Update(IPatientAlert entity);
        Task<IPatientAlert> Get(Guid UId);
        Task<IEnumerable<IPatientAlert>> Get();
        Task<IEnumerable<IPatientAlert>> GetByPatientUId(Guid patientUId);
        Task<int> Delete(Guid UId);
        Task<IPatientAlert> GetActiveAlert(Guid patientUId);
    }
}
