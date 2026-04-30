using PractiZing.Base.Entities.SecurityService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IUserRepository
    {
        Task<ILoginUser> Login(string userName, string password);
        Task<IEnumerable<IUser>> GetAll();
        Task<IUser> AddNew(IUser entity);
        Task<int> Update(IUser entity);
        Task<int> Delete(Guid uid);
        Task<IUser> GetByUId(Guid UId);
        Task<IEnumerable<IUser>> GetByUId(IEnumerable<Guid> Ids);
        Task<ILoginUser> LoginAzure(string userName, string password);
        Task<IUser> GetCurrentUser();
        Task ThrowPinEmptyError();
        Task ThrowPinNotMatchedError();
    }
}
