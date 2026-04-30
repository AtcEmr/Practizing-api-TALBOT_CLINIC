using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IClaimCharge
    {
        int Id { get; set; }
        int ChargeId { get; set; }
        int ClaimId { get; set; }
        int? PageNumber { get; set; }
        string CliaNumber { get; set; }
        string Mod1 { get; set; }
        string Mod2 { get; set; }
        string Mod3 { get; set; }
        string Mod4 { get; set; }
        DateTime? SentDate { get; set; }
        int BatchId { get; set; }
        string ClaimStatus { get; set; }
        int BatchStatusId { get; set; }
    }
}
