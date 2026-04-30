using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IAttFileTableRepository : IBaseRepository
    {
        Task<IEnumerable<IAttFileTable>> GetAll();
        Task<IAttFileTable> GetByName(string name);
    }
}
