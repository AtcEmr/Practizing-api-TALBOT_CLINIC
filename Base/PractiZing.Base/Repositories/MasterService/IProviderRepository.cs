using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.CommonEntites;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IProviderRepository : IBaseRepository
    {
        Task<IEnumerable<IProvider>> GetAll();
        Task<IEnumerable<IDropDownDTO>> GetForDDO();
        Task<IPaginationQuery<IProvider>> GetProviderList(SearchQuery<IProviderFilter> entity);
        Task<IProvider> GetById(short id);
        Task<IProvider> GetByUId(Guid UId, bool isForInternalUser = false);
        Task<IEnumerable<IProvider>> GetByFacilityUId(Guid facilityUId);
        Task<IEnumerable<IProviderDTO>> GetProviderDTO();
        Task<IProvider> AddNew(IProvider entity);
        Task<int> Update(IProvider entity);
        Task<int> Delete(short id);
        Task<IProvider> Get(string npi);
        Task<IProvider> GetDefaultProvider();
        Task<IEnumerable<IProvider>> GetByUId(IEnumerable<Guid> Ids);
        Task<IEnumerable<IProviderDTO>> GetSupervisionProviderDTO();
        Task<IProvider> GetByEmrId(int id);
        Task ThrowError();
        Task<IProvider> GetByIdWithQualification(short id);
        Task<IProvider> GetByIdWithQualificationSUD(short id);
    }
}
