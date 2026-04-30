using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientEligibilityDetailRepository
    {        
        Task<IPatientEligibilityDetail> AddNew(IPatientEligibilityDetail entity);        
    }
}
