using PractiZing.Base.Entities.ERAService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ERAService
{
    public interface  IERAClaimChargePaymentRepository
    {
        Task<IEnumerable<IERAClaimChargePayment>> GetByClaimId(long[] id);
        Task<int> Update(IERAClaimChargePayment entity);
    }
}
