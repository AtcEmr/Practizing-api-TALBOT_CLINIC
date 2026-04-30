using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public interface IRoleModuleRepository
    {
        Task<IEnumerable<IRoleModule>> Get();
        Task<IEnumerable<IPZModule>> GetModuleByRoleIds(IEnumerable<int> roleIds);
        Task<IRoleModule> Get(int id);
        Task<IRoleModule> AddNew(IRoleModule entity);
        Task<int> Update(IRoleModule entity);
        Task<int> Delete(int id);
    }
}