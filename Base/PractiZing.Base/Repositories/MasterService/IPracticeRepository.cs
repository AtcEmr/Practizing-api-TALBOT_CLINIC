using PractiZing.Base.Entities.MasterService;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IPracticeRepository
    {
        Task<IPractice> Get(int id);
        Task<IPractice> Get();
        Task ThrowPermissionDeniedError();
        string GetLoggedUser();
    }
}
