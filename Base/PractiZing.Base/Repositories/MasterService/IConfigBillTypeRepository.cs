using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigBillTypeRepository
    {
        Task<IEnumerable<IConfigBillType>> Get();
        Task<IConfigBillType> Get(Int16 id);
    }
}
