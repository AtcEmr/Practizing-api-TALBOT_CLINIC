using PractiZing.Base.Entities.MasterService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigFacilitySubTypeRepository
    {
        Task<IEnumerable<IConfigFacilitySubType>> GetAll();
        Task<IEnumerable<IConfigFacilitySubType>> GetByFacilityUId(string faciltyUId);
    }
}
