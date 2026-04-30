using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
   public interface IConfigCaseTypeRepository
    {
        Task<IEnumerable<IConfigCaseType>> GetAll();
        Task<IConfigCaseType> Get(Int16 id);
    }
}
