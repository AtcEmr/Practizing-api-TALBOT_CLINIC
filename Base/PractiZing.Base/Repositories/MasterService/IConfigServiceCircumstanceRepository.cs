using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigServiceCircumstanceRepository
    {
        Task<IEnumerable<IConfigServiceCircumstance>> Get();
        Task<IConfigServiceCircumstance> AddNew(IConfigServiceCircumstance entity);
        Task<int> Update(IConfigServiceCircumstance entity);
        Task<IConfigServiceCircumstance> GetById(int id);
    }
}
