using PractiZing.Base.Model.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class PaymentChargeForACKDTO : IPaymentChargeForACKDTO
    {
        public decimal TotalAdjustment { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public int PaymentChargeId { get; set; }
        public int PaymentId { get; set; }
        public string AccessionNumber { get; set; }
        public bool HasDenial { get; set; }
        public decimal DueAmount { get; set; }
        public string AdjustmentCode { get; set; }
        public string RemarkCode { get; set; }
        public string DueBy { get; set; }

    }
}
