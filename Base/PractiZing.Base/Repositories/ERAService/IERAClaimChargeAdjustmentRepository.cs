using PractiZing.Base.Entities.ERAService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ERAService
{
    public interface IERAClaimChargeAdjustmentRepository
    {
        Task<IEnumerable<IERAClaimChargeAdjustment>> Get(long[] ids);
    }
}
