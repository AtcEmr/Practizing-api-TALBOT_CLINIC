using PractiZing.Base.Entities.MasterService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface IFacilityService
    {
        Task<IEnumerable<IFacilityIdentity>> GetFacilityIdentifiersByFacilityId(int facilityId);
        Task<int> AddIdentities(IEnumerable<IFacilityIdentity> entities);
        Task<IFacility> AddNew(IFacility entity);
        Task<IFacility> Update(IFacility entity);
    }
}
