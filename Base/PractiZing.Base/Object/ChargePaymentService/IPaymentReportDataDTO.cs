using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPaymentReportDataDTO
    {
        long TotalSamples { get; set; }
        decimal? ChargesAmount { get; set; }
        decimal? Payments { get; set; }
        decimal? Adjustments { get; set; }
        long ZeroPaymentSamples { get; set; }
        long DenialsCount { get; set; }
        decimal? BankDeposits { get; set; }
        IEnumerable<IPaymentReportData> Charges { get; set; }
    }
}
