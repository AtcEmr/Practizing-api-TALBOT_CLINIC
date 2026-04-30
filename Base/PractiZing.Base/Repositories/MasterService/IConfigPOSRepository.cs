using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigPOSRepository
    {
        Task<IEnumerable<IConfigPOS>> GetAll();
        Task<IConfigPOS> Get(string code);
    }
}
