using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PaymentAdjustment : IPaymentAdjustment
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PaymentChargeId { get; set; }
        public string ReasonCode { get; set; }
        public decimal Amount { get; set; }
        public bool IsDenial { get; set; }
        public bool IsAccounted { get; set; }
        public bool IsBonus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public string PaymentSourceCD { get; set; }
        [Ignore]
        public int ChargeId { get; set; }
    }
}
