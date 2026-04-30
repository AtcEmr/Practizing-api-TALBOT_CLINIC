using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigNDCUOMRepository
    {
        Task<IConfigNDCUOM> AddNew(IConfigNDCUOM entity);
        Task<int> Update(IConfigNDCUOM entity);
        Task<int> Delete(Int16 id);
        Task<IEnumerable<IConfigNDCUOM>> GetConfigNDCUOMCodes();
    }
}
