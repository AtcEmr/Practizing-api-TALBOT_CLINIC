using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IClaimStatusInquiry
    {
        int Id { get; set; }
        int PracticeId { get; set; }
        int ClaimId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
