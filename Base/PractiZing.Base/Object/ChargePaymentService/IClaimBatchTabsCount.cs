using PractiZing.Base.Entities.BatchPaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IClaimBatchTabsCount
    {
        long BatchedCount { get; set; }
        long UnBatchedCount { get; set; }
        long SentCount { get; set; }
        long NotSentCount { get; set; }
        long PrintedCount { get; set; }
        long NotPrintedCount { get; set; }
        long OnHoldCount { get; set; }
        long ChargeCount { get; set; }
        IEnumerable<IClaimBatch> ClaimBatches { get; set; }
        long SentChargeCount { get; set; }
    }
}
