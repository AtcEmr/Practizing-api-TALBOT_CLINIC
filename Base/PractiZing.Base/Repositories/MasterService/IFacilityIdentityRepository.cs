using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IFacilityIdentityRepository : IBaseRepository
    {
        Task<IEnumerable<IFacilityIdentity>> GetIdentifier(string Identifier);
        Task<IFacilityIdentity> GetIdentity(int facilityId, int? typeId);
        Task<IFacilityIdentity> GetById(short id);
        Task<IEnumerable<IFacilityIdentity>> GetByFacility(Guid facilityUId);
        Task<IFacilityIdentity> GetByUId(Guid UId);
        Task<int> AddOrUpdate(IEnumerable<IFacilityIdentity> entities);
        Task<IFacilityIdentity> AddNew(IFacilityIdentity entity);
        Task<long> UpdateEntityData(IFacilityIdentity entity);
        Task<int> Delete(Guid uid);
        Task<IEnumerable<IFacilityIdentity>> GetFacilityIdentifiersByFacilityId(int facilityId);
        Task<int> DeleteByFacilityId(int facilityId);
        Task<int> GetFacilityBasedOnNPI(string npi);
        Task<IFacilityIdentity> GetDefaultFacilitySUDNPI();
    }
}
