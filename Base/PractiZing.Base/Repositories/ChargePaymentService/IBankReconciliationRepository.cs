using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IBankReconciliationRepository
    {
        Task<IEnumerable<IBankReconciliation>> GetData(int monthId, int yearId);
        Task<int> Update(int voucherId, int chasePaymentId);
        Task<string> SyncData(int monthId, int yearid);
        Task<IEnumerable<string>> GetDataForChasePayment(int monthId, int yearId);
        Task<IEnumerable<IBankReconciliation>> GetDataByChasePaymentId(int chasePaymentId);
        Task<int> SyncDepositsWithChasePayments(int monthId, int yearId);
        Task<IEnumerable<IBankReconciliationDTO>> GetDataYearWise(int yearId);
        Task<IEnumerable<IBankReconciliationDTO>> GetUnmacnedDepositsYearWise(int yearId);
    }
}
