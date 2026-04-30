using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IModulePermissionRepository
    {
        Task<IEnumerable<IModulePermission>> Get(IEnumerable<int> roleIds);
        Task<IEnumerable<IPZModule>> GetModulesByIds(IEnumerable<int> ids);
        Task<IEnumerable<IUserPermission>> GetByModuleIds(List<int> moduleIds);
        Task<IModulePermission> Get(int id);
        Task<IModulePermission> AddNew(IModulePermission entity);
        Task<int> Update(IModulePermission entity);
        Task<int> Delete(int id);
    }
}
