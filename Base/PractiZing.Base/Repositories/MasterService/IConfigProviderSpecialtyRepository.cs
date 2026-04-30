using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigProviderSpecialtyRepository
    {
        Task<IEnumerable<IConfigProviderSpecialty>> GetAll();
        Task<IConfigProviderSpecialty> Get(Int16 id);
    }
}
