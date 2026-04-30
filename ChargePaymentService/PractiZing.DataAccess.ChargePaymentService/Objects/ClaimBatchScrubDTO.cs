using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ClaimBatchScrubDTO :IClaimBatchScrubDTO
    {
        public ClaimBatchScrubDTO()
        {
            this.ClaimScrubs = new List<ScrubDTO>();
            this.Scrubs = new List<Scrub>();

        }
        public IEnumerable<IScrubDTO> ClaimScrubs { get; set; }

        public IEnumerable<IScrub> Scrubs { get; set; }

        public int ClaimBatchId { get; set; }
        public string PracticeCode { get; set; }
    }
}
