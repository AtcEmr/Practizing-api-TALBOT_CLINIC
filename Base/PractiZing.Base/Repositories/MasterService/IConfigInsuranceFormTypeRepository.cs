using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigInsuranceFormTypeRepository
    {
        Task<IEnumerable<IConfigInsuranceFormType>> GetAll();
        Task<IConfigInsuranceFormType> Get(Int16 id);
    }
}
