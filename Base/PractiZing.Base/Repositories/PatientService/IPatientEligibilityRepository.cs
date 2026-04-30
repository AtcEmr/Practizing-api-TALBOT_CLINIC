using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientEligibilityRepository
    {        
        Task<IPatientEligibility> AddNew(IPatientEligibility entity);

        Task<int> Update(IPatientEligibility entity, bool isErrorMessageUpdate);
    }
}
