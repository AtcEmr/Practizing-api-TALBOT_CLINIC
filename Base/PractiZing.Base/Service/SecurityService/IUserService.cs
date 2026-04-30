using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.SecurityService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.SecurityService
{
    public interface IUserService
    {
        Task<ILoginUser> Login(string userName, string password);
        Task<IModuleDTO> GetAllByUser(string userUId, List<int> roleIds);
        Task<IModuleDTO> GetAllByRoleIds(List<int> roleIds);
        Task<IEnumerable<IPZModule>> GetModules(IEnumerable<IPZModule> modules, int userId);
        Task<bool> SaveRolesAndPermissions(IUserRolePermissionDTO entity);
        Task<ILoginUser> LoginAzure(string userName, string password);
    }
}
