using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IDepositTypeRepository
    {
        Task<IEnumerable<IDepositType>> GetAll();
        Task<IEnumerable<IDepositType>> GetByUId(IEnumerable<Guid> uids);
        Task<IDepositType> GetByUId(Guid uid);
    }
}
