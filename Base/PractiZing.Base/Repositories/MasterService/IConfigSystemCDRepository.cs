using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigSystemCDRepository : IBaseRepository
    {
        Task<IEnumerable<IConfigSystemCD>> GetAll();
        Task<IConfigSystemCD> GetByCD(string CD);
        Task<IConfigSystemCD> AddNew(IConfigSystemCD entity);
        Task<int> Update(IConfigSystemCD entity);
        Task<int> Delete(string CD);
        Task<IEnumerable<IConfigSystemCD>> GetAllFollowUp();
        Task<IEnumerable<IConfigSystemCD>> GetAllActionResponse();
    }
}
