using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IRoleRepository
    {
        Task<IEnumerable<IRole>> Get();
        Task<IRole> Get(int id);
        Task<IRole> AddNew(IRole entity);
        Task<int> Update(IRole entity);
        Task<int> Delete(int id);
    }
}
