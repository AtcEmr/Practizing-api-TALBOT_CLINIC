using PractiZing.Base.Entities.DenialService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.DenialService
{
    public interface IARGroupReasonCodeRepository
    {
        Task<IEnumerable<IARGroupReasonCode>> Get();
        Task<IARGroupReasonCode> Get(int id);
        Task<IARGroupReasonCode> AddNew(IARGroupReasonCode entity);
        Task<int> Update(IARGroupReasonCode entity);
        Task<int> Delete(int id);
    }
}
