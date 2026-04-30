using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPortalPaymentRepository
    {
        Task<int> Update(Guid portalPaymentUId);
        Task<IPortalPayment> Get(Guid uId);
        Task<IEnumerable<IPortalPayment>> Get(int patientId);
        Task<IEnumerable<IPortalPayment>> Get(IPortalPaymentFilterDTO filter);
        Task<StripeRefund> RefundCharge(IPortalPayment entity, decimal amount, string reasons);
        Task<IPortalPayment> AddNew(IPortalPayment entity);
        Task<int> UpdateRefundAmount(Guid portalPaymentUId, decimal refundAmount);
        Task<int> UpdateRefundMade(Guid portalPaymentUId);
        Task ThrowRefundException(string errorMessage);
        Task<StripeRefund> RefundChargeByChargeId(string chargeid, string reasons);
        Task<int> UpdatePaymentId(Guid portalPaymentUId, int paymentId, decimal totalPaidAmount = 0);
        Task<int> MarkPaymentIdAsDeleted(IEnumerable<int> paymentIds);
        Task ThrowAmountNotEqual();
        Task<int> UpdatePaymentId(Guid portalPaymentUId, int paymentId, bool isCommitted);
        Task<int> MarkPaymentIdAsDeleted(IEnumerable<int> paymentIds, decimal paidAmount);
        Task<IEnumerable<IPortalPaymentEMRDTO>> GetUnPostedPaymentByPatientId(string billingId);
        Task ThrowAmountNotEqualThenOnlySelectSignlePayment();
        Task<int> UpdateLabAmount(Guid portalPaymentUId, decimal labAmount, int? labPortalPaymentId);
        Task ThrowPaymentAmountGreaterThanActualOnline();
        Task ThrowZeroPostedPayment();
        Task ThrowPostPaymentGreaterValidation();
        Task<int> UpdateIsCommmited(IEnumerable<int> ids);
    }
}
