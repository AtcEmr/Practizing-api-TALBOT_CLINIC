using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
  public  interface IConfigFollowUpPeriodRepository : IBaseRepository
    {
        Task<IEnumerable<IConfigFollowUpPeriod>> GetAll();
        Task<IConfigFollowUpPeriod> GetById(int id);
        Task<IConfigFollowUpPeriod> AddNew(IConfigFollowUpPeriod entity);
        Task<int> Update(IConfigFollowUpPeriod entity);
        Task<int> Delete(short id);
    }
}
