using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IHistoryPaymentRepository
    {
        Task Add(IHistoryPayment entity);
        Task<IEnumerable<IHistoryPayment>> All(string paginationToken = "");
        Task<IEnumerable<IHistoryPayment>> Find();
        Task Remove(string readerId);
        Task<IHistoryPayment> Single(string readerId);
        Task Update(string historyPaymentId);
    }
}
