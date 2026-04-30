using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PaymentReportDataDTO : IPaymentReportDataDTO
    {
        public PaymentReportDataDTO()
        {
            Charges = new List<IPaymentReportData>();
        }
        public long TotalSamples { get; set; }
        public decimal? ChargesAmount { get; set; }
        public decimal? Payments { get; set; }
        public decimal? Adjustments { get; set; }
        public long ZeroPaymentSamples { get; set; }
        public long DenialsCount { get; set; }
        public decimal? BankDeposits { get; set; }
        public  IEnumerable<IPaymentReportData> Charges { get; set; }
    }
}
