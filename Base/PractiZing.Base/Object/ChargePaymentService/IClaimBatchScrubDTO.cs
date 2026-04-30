using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IClaimBatchScrubDTO
    {
         IEnumerable<IScrubDTO> ClaimScrubs { get; set; }

        IEnumerable<IScrub> Scrubs { get; set; }

        int ClaimBatchId { get; set; }
        string PracticeCode { get; set; }
    }
}
