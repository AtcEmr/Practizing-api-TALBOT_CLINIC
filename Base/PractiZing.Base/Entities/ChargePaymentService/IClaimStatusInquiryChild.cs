using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IClaimStatusInquiryChild
    {
        int Id { get; set; }
        int ClaimStatusInquiryId { get; set; }        
        string TransactionNumber { get; set; }
        string CategoryCode { get; set; }
        string StatuCode { get; set; }
        string CategoryCodeDescription { get; set; }
        string StatuCodeDescription { get; set; }
        string IdentifierCode { get; set; }
        string IdentifierDescription { get; set; }
        decimal? MonetaryAmount { get; set; }
        string PaymentMethodCode { get; set; }
        string CheckNumber { get; set; }        
        string ErrorMessage { get; set; }
        string Soruce { get; set; }
    }
}
