using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface ILabSalesRepRepository : IBaseRepository
    {
        Task<IEnumerable<ILabSalesRep>> GetAll();
        Task<ILabSalesRep> GetByUId(Guid uid);
        Task<ILabSalesRep> AddNew(ILabSalesRep entity);
        Task<int> Update(ILabSalesRep entity);
    }
}
