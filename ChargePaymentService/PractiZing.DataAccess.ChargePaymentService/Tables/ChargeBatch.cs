using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ChargeBatch : IChargeBatch
    {

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [MaxLength(50, ErrorMessage = "BatchNo - Must not enter more than 50 characters.")]
        public string BatchNo { get; set; }

        public DateTime BatchDate { get; set; }
        [Alias("Amount")]
        public decimal BatchAmount { get; set; }
        public int RecordCount { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public string CPTCode { get; set; }
        [Ignore]
        public int PostedChargesCount { get; set; }
        [Ignore]
        public decimal PostedChargesValue { get; set; }
        public bool IsActive { get; set; }
        [Ignore]
        public decimal Amount { get; set; }
    }
}
