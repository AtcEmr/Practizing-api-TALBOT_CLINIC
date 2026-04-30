using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigTrizettoPatientEligibilityRepository
    {
        Task<IConfigTrizettoPatientEligibility> GetAll();
        Task<int> UpdateTransactionNumber(IConfigTrizettoPatientEligibility entity);
    }
}
