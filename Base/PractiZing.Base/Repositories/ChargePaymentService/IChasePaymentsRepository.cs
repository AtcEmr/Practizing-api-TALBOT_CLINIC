using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChasePaymentsRepository
    {
        Task<IChasePaymentDashboardDTO> Get(int monthId, int yearId);
        Task<IChasePayments> AddNew(IChasePayments entity);
        Task<bool> CheckRecordExists(int monthId, int yearId);
        Task<bool> AddBulk(IEnumerable<IChasePayments> entityList);
        Task<bool> AddChasePaymentChild(IChasePaymentDTO chasePaymentDTO);
        Task<IChasePaymentReporParenttDTO> GetDataYearWise(int yearId);
        Task<int> UpdateAsOwenerDeposit(int chasePaymentId);
        Task<IEnumerable<IChasePayments>> GetUnMappedChasePayments(int monthId, int yearId);
        Task<IEnumerable<IChasePayments>> GetOwnerChasePayments(int monthId, int yearId);
    }
}
