using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IUserPermissionRepository
    {
        Task<IEnumerable<IUserPermission>> Get(int userId);
        Task<IEnumerable<IUserPermission>> GetByModuleIds(List<int> moduleIds);
        Task<IEnumerable<IUserPermission>> GetSavedByModuleIds(List<int> moduleIds, int userId);
        Task<IEnumerable<IUserPermission>> GetByUserId(int userId);
        Task<bool> SaveList(IEnumerable<IUserPermission> entities);
        Task<int> Update(IUserPermission entity);
        Task<int> DeleteByUserId(int userId);
    }
}
