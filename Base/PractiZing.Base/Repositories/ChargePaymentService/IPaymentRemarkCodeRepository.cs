using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPaymentRemarkCodeRepository
    {
        Task<IEnumerable<IPaymentRemarkCode>> Get(int paymentChargeId);
        Task<IEnumerable<IPaymentRemarkCode>> Get();
        Task AddAll(IEnumerable<IPaymentRemarkCode> entities);
        Task AddAll(string codes, int paymentChargeId);
        Task<int> Delete(IEnumerable<int> paymentChargeId);
        Task<IPaymentRemarkCode> AddNew(IPaymentRemarkCode entity);
        Task<IEnumerable<IPaymentRemarkCode>> Get(IEnumerable<int> paymentChargeIds);
    }
}
