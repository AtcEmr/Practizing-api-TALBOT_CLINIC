using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IEDIEligibilityLogRepository
    {        
        Task<IEDIEligibilityLog> AddNew(IEDIEligibilityLog entity);

        Task<int> Delete(int patientEligibilityId);
    }
}
