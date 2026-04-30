using PractiZing.Base.Entities.SecurityService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IUserAuthenticationRepository
    {
        Task<IUserAuthentication> Get(string smallToken);
        Task<IUserAuthentication> AddNew(int userId, string token, DateTime expiryDateTime, string fingerPrint,string smallToken);
        Task SetAllInCache(IEnumerable<IPracticeCentralPractice> practices);
        Task<int> RemoveAllExpiredTokenFromCache(IEnumerable<IPracticeCentralPractice> practices);
        Task<int> Update(string smallToken, DateTime expiryDateTime, string token);
        Task<int> Delete(string smallToken);
        Task<int> Delete(int userId);
    }
}
