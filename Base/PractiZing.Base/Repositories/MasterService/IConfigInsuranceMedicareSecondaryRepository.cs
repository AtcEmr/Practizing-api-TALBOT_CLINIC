using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigInsuranceMedicareSecondaryRepository
    {
        Task<IEnumerable<IConfigInsuranceMedicareSecondary>> GetAll();
        Task<IConfigInsuranceMedicareSecondary> Get(Int16 id);
    }
}
