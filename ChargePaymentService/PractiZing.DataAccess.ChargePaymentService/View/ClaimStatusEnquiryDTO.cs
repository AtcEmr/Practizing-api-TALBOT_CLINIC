using PractiZing.Base.View.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.View
{
    [Alias("vw_ClaimStatusEnquiry")]
    public class ClaimStatusEnquiryDTO: IClaimStatusEnquiryDTO
    {
        public int ClaimId { get; set; }
        public string StatuCode { get; set; }
        public string StatuCodeDescription { get; set; }
        public string ErrorMessage { get; set; }        
    }
}
