using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IMonthEndCloseRepository : IBaseRepository
    {
        Task<IMonthEndClose> AddNew(IMonthEndClose entity);
        Task<int> Update(IMonthEndClose entity);
        Task<int> Delete(Guid uid);
        Task<IMonthEndClose> Get(Guid uid);
        Task<IEnumerable<IMonthEndClose>> Get();
        Task<IMonthEndClose> GetByDateId(int monthId, int yearId);
    }
}
