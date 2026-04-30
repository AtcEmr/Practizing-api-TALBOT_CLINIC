using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IAdjustmentReasonCodeRepository
    {
        Task<IAdjustmentReasonCode> AddNew(IAdjustmentReasonCode entity);
        Task<int> Update(IAdjustmentReasonCode entity);
        Task<IAdjustmentReasonCode> GetByUId(Guid UId);
        Task<IEnumerable<IAdjustmentReasonCode>> Get(string codes);
    }
}
