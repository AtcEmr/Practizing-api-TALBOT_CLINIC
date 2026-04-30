using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPaymentChargeRepository
    {
        Task<IEnumerable<int>> GetChargeIdsByReasonCodes(string codes);
        Task<IPaymentCharge> Get(Guid uid);
        Task<IEnumerable<IPaymentCharge>> Get(IPaymentBillingHistoryFilter filter, long patientId);
        Task<IEnumerable<IPaymentCharge>> GetByPaymentId(IEnumerable<int> paymentId);
        Task<IPaymentCharge> GetByChargeId(int chargeId, int paymentId);
        Task<IEnumerable<IPaymentCharge>> GetByPaymentId(int paymentId, int chargeId);
        Task<IPaymentCharge> GetById(int id);
        Task<IEnumerable<IPaymentCharge>> GetByChargeIds(IEnumerable<int> chargeIds);
        Task<IEnumerable<IPaymentCharge>> GetByPaymentId(int paymentId);
        //Task<IEnumerable<IPaymentCharge>> GetByPaymentUId(string paymentUId);
        Task<IEnumerable<IPaymentChargeDTO>> GetPaymentCharge(IEnumerable<int> paymentIds);
        Task<IEnumerable<IPaymentCharge>> GetByChargeId(int chargeId);
        Task<IEnumerable<IPaymentCharge>> GetById(IEnumerable<int> ids);
        Task<IEnumerable<IPaymentCharge>> GetByChargeId(IEnumerable<int> chargeIds);
        Task<IPaymentCharge> AddNew(IPaymentCharge entity);
        Task<bool> AddBulkAdjustmentPayment(IEnumerable<IPaymentCharge> paymentCharges, bool isRemarkCode, int patientId);
        Task<int> AddOrUpdate(IEnumerable<IPaymentCharge> entities);
        Task<IPaymentCharge> Update(IPaymentCharge entity);
        Task<int> DeleteByPaymentId(IEnumerable<int> paymentIds);
        Task<int> DeleteByChargeId(int chargeId);
        Task<int> DeleteByPaymentChargeId(int paymentChargeId);
        Task ThrowPaymentExistsWithThisChargeError();
        Task<IEnumerable<IPaymentChargeDTO>> GetPaymentCharge(int paymentId);
        Task<IEnumerable<IPaymentChargeDTO>> GetBulkPaymentCharge(IEnumerable<int> paymentIds);
        Task<IEnumerable<IPaymentCharge>> GetPaymentsByChargeId(int chargeId);
        Task AddAll(IEnumerable<IPaymentCharge> entities);
        Task<bool> AddBalanceAdjustmentPayment(IEnumerable<IPaymentCharge> paymentCharges);
        Task<IEnumerable<IPaymentChargeForACKDTO>> GetBulkPaymentChargeForACK(IEnumerable<int> paymentIds);
    }
}
