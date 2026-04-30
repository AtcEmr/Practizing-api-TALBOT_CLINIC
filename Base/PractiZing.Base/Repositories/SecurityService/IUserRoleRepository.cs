using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<IUserRole>> GetAll();
        Task<IEnumerable<IUserRole>> GetByUser(int userId);
        Task<IEnumerable<IUserRole>> GetAllByUser(string userUId);
        Task<bool> ModifyList(IEnumerable<IUserRole> entity);
    }
}
