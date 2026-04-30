using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigAdjustmentReasonCodeRepository : IBaseRepository
    {
        Task<IEnumerable<IConfigAdjustmentReasonCode>> GetAll();
        Task<IConfigAdjustmentReasonCode> GetByReasonCode(string groupCode, string code);
        Task<IEnumerable<IConfigAdjustmentReasonCode>> Get(int categoryId);
        Task<IConfigAdjustmentReasonCode> AddNew(IConfigAdjustmentReasonCode entity);
        Task<long> Update(IConfigAdjustmentReasonCode entity);
        Task<int> Delete(string reasonCode);
        Task<IEnumerable<IConfigAdjustmentReasonCode>> GetRemarkCode();
        Task<IEnumerable<IConfigAdjustmentReasonCode>> Get(string reasonCode);
        Task<IEnumerable<IConfigAdjustmentReasonCode>> GetAll(string reasonCode);
        Task<IEnumerable<IConfigAdjustmentReasonCode>> GetAllWriteOff();
    }
}
