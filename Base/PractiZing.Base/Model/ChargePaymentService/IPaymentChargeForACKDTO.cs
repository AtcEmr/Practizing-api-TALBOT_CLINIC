using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IPaymentChargeForACKDTO
    {
        decimal TotalAdjustment { get; set; }
        decimal TotalPaidAmount { get; set; }
        int PaymentChargeId { get; set; }
        int PaymentId { get; set; }
        string AccessionNumber { get; set; }
        bool HasDenial { get; set; }
        decimal DueAmount { get; set; }
        string AdjustmentCode { get; set; }
        string RemarkCode { get; set; }
        string DueBy { get; set; }
        
    }
}
