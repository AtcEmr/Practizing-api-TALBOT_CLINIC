using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IPZModuleRepository
    {
        Task<IEnumerable<IPZModule>> Get();
        Task<IEnumerable<IModulePermission>> GetModulePermissions(IEnumerable<int> ids);
        Task<IPZModule> Get(int id);
        Task<IPZModule> AddNew(IPZModule entity);
        Task<int> Update(IPZModule entity);
        Task<int> Delete(int id);
    }
}
