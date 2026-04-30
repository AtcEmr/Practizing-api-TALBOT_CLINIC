using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPaymentAdjustment : IStamp, IUniqueIdentifier
    {
        int Id { get; set; }
        int PaymentChargeId { get; set; }
        string ReasonCode { get; set; }
        decimal Amount { get; set; }
        bool IsDenial { get; set; }
        bool IsAccounted { get; set; }
        bool IsBonus { get; set; }
        string PaymentSourceCD { get; set; }
        int ChargeId { get; set; }
    }
}
