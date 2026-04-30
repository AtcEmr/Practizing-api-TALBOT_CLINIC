using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPaymentAdjustmentRepository
    {
        Task<IPaymentAdjustment> GetById(int id);
        Task<IEnumerable<IPaymentAdjustment>> GetByPaymentChargeId(int paymentChargeId);
        Task<IEnumerable<IPaymentAdjustment>> GetBonus(IEnumerable<int> paymentChargeIds);
        Task<IEnumerable<IPaymentAdjustment>> GetByPaymentChargeId(IEnumerable<int> paymentChargeIds);
        Task<IEnumerable<IPaymentAdjustment>> GetByCodes(IEnumerable<string> codes);
        Task<IEnumerable<int>> GetByCodes(string codes);
        Task<IPaymentAdjustment> AddNew(IPaymentAdjustment entity);
        Task<int> AddOrUpdate(IEnumerable<IPaymentAdjustment> entities);
        Task<int> Update(IPaymentAdjustment entity);
        Task<int> DeleteById(IEnumerable<int> paymentChargeIds);
        Task<int> Delete(Guid uid);
    }
}
