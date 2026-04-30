using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IRefundPaymentDTO
    {
        Guid UId { get; set; }
        decimal RefundAmount { get; set; }
        string Reasons { get; set; }
    }
}
