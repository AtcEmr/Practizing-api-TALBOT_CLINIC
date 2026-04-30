using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PaymentRemarkCode : IPaymentRemarkCode
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int PaymentChargeId { get; set; }
        public string RemarkCode { get; set; }
        public string RemarkQualifier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
