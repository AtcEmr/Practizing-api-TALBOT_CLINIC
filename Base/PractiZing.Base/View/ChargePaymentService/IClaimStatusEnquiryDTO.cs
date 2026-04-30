using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.View.ChargePaymentService
{
    public interface IClaimStatusEnquiryDTO
    {
        int ClaimId { get; set; }
        string StatuCode { get; set; }
        string StatuCodeDescription { get; set; }
        string ErrorMessage { get; set; }
    }
}
