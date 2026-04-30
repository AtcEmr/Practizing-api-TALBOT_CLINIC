using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigFacilityTypeRepository
    {
        Task<IEnumerable<IConfigFacilityType>> GetAll();
        Task<IConfigFacilityType> Get(int id);
    }
}
