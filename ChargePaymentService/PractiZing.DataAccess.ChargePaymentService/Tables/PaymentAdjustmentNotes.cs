using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PaymentAdjustmentNotes : IPaymentAdjustmentNotes
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int PaymentAdjustmentId { get; set; }
        public int PaymentChargeId { get; set; }
        public string ReasonCode { get; set; }
        public string Note { get; set; }
        public bool IsSendAck { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ChargeId { get; set; }
        [Ignore]
        public string BillingId { get; set; }
        [Ignore]
        public string AccessionNumber { get; set; }

    }
}
