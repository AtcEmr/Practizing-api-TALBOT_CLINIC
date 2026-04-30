using PractiZing.Base.Entities.DenialService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.DenialService
{
    public interface IARGroupRepository
    {
        Task<IEnumerable<IARGroup>> Get();
        Task<IARGroup> Get(int id);
        Task<IARGroup> Get(Guid UId);
        Task<IARGroup> AddNew(IARGroup entity);
        Task<int> Update(IARGroup entity);
        Task<int> Delete(int id);
    }
}
