using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ClaimStatusInquiryChild : IClaimStatusInquiryChild
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ClaimStatusInquiryId { get; set; }
        public string TransactionNumber { get; set; }
        public string CategoryCode { get; set; }
        public string StatuCode { get; set; }
        public string CategoryCodeDescription { get; set; }
        public string StatuCodeDescription { get; set; }
        public string IdentifierCode { get; set; }
        public string IdentifierDescription { get; set; }
        public decimal? MonetaryAmount { get; set; }
        public string PaymentMethodCode { get; set; }
        public string CheckNumber { get; set; }        
        public string ErrorMessage { get; set; }
        public string Soruce { get; set; }

    }
}
