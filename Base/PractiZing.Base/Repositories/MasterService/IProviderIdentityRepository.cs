using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IProviderIdentityRepository : IBaseRepository
    {
        Task<IEnumerable<IProviderIdentity>> GetAll();
        Task<IEnumerable<IProviderIdentity>> GetByProvider(Guid providerUId);
        Task<IProviderIdentity> GetProviderIdentity(short providerId, int? typeId, DateTime? activeDate, string hcfaField);
        Task<int> AddOrUpdate(IEnumerable<IProviderIdentity> entities);
        Task<IProviderIdentity> AddNew(IProviderIdentity entity);
        Task<int> Update(IProviderIdentity entity);
        Task<IProviderIdentity> Get(Guid uId);
        Task<int> Delete(Guid uid);
        Task<IProviderIdentity> GetNPIByProviderId(Guid uId);
        Task<int> DeleteByProviderId(int providerId);
        Task<IProvider> GetProviderByFacilityNPI(string facilitynpi);
        Task<IProviderIdentity> GetProviderTaxonomyByProviderUId(Guid uId);
        Task<IProviderIdentity> GetProviderTaxonomyByProviderUId(Guid uId, IFacility billingFacility);
    }
}
