using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigProviderPositionRepository
    {
        Task<IEnumerable<IConfigProviderPosition>> GetAll();
        Task<IConfigProviderPosition> Get(Int16 id);
    }
}
