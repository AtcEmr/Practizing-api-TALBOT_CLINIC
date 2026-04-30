using PractiZing.Base.Entities.BatchPaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.BatchPaymentService.Tables;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ClaimBatchTabsCount : IClaimBatchTabsCount
    {

        public ClaimBatchTabsCount()
        {
            this.ClaimBatches = new List<ClaimBatch>();
        }

        public long BatchedCount { get; set; }
        public long UnBatchedCount { get; set; }
        public long SentCount { get; set; }
        public long NotSentCount { get; set; }
        public long PrintedCount { get; set; }
        public long NotPrintedCount { get; set; }
        public long OnHoldCount { get; set; }
        public long ChargeCount { get; set; }
        public long SentChargeCount { get; set; }
        public IEnumerable<IClaimBatch> ClaimBatches { get; set; }
    }
}
