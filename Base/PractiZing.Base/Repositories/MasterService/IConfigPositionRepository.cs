using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
  public  interface IConfigPositionRepository
    {
        Task<IEnumerable<IConfigPosition>> GetAll();
        Task<IConfigPosition> Get(Int16 id);
    }
}
