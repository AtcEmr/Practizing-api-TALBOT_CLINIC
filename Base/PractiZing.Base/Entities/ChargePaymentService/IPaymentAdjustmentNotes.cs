using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPaymentAdjustmentNotes : ICreatedStamp
    {
        int Id { get; set; }
        int PaymentAdjustmentId { get; set; }
        int PaymentChargeId { get; set; }
        string ReasonCode { get; set; }
        string Note { get; set; }
        bool IsSendAck { get; set; }
        string BillingId { get; set; }
        string AccessionNumber { get; set; }
        int? ChargeId { get; set; }
    }
}
