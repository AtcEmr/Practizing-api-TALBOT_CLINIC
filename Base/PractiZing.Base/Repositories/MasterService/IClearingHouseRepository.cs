using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IClearingHouseRepository : IBaseRepository
    {
        Task<IEnumerable<IClearingHouse>> Get();
        Task<IClearingHouse> GetById(int id);
        Task<IClearingHouse> GetByUId(Guid uid);
        Task<IClearingHouse> AddNew(IClearingHouse entity);
        Task<int> Update(IClearingHouse entity);
        Task<int> Delete(Guid uid);
        Task<IClearingHouse> GetByName(string name);
        Task<int> UpdateClaimBatchTransactionNumber(IClearingHouse entity);
        Task<int> UpdateTransactionNumber(IClearingHouse entity);
        Task<IEnumerable<IClearingHouse>> GetForOHIOUI();
    }
}
