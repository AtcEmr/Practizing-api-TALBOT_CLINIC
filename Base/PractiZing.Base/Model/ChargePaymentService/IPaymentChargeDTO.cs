using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IPaymentChargeDTO
    {
        DateTime DOS { get; set; }
        string CPTCode { get; set; }
        int ChargeNumber { get; set; }
        string Mod { get; set; }
        decimal ChargeAmount { get; set; }
        bool IsReversed { get; set; }
        decimal CrChargeAmount { get; set; }
        int PaymentChargeId { get; set; }
        decimal PaidAmount { get; set; }
        decimal DrChargeAmount { get; set; }
        decimal TotalAdjustmentAmount { get; set; }
        decimal PatientResponsibility { get; set; }
        decimal NonAccAdjustment { get; set; }
        decimal DifferenceAmount { get; }
        string ReasonCode { get; set; }
        int PaymentId { get; set; }
        short Quantity { get; set; }
        decimal BonusAmount { get; set; }
    }
}
