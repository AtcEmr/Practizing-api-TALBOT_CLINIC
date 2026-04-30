using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface ICPTCategoryRepository : IBaseRepository
    {
        Task<IEnumerable<ICPTCategory>> Get();
        Task<ICPTCategory> Get(short id);
        Task<ICPTCategory> GetByUId(Guid UId);
        Task<ICPTCategory> AddNew(ICPTCategory entity);
        Task<int> Update(ICPTCategory entity);
        Task<int> Delete(Guid uid);
        Task<IEnumerable<ICategoryDDO>> GetCategoryDTO();
    }
}
