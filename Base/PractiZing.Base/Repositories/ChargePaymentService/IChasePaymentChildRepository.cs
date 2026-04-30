using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChasePaymentChildRepository
    {
        Task<IEnumerable<IChasePaymentChild>> Get(int chasePaymentId);
        Task<bool> AddBulk(IEnumerable<IChasePaymentChild> entityList);
        Task<int> Delete(int id);
    }
}
