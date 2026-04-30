using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChasePaymentDTO
    {
        int ChasePaymentId { get; set; }
        IEnumerable<int> BankReconciliationIds { get; set; }
    }

    public interface IChasePaymentDashboardDTO
    {
        decimal? TotalChasePayment { get; set; }
        decimal? TotalPostedPayment { get; set; }
        decimal? TotalDiffPayment { get; set; }
        decimal? UnmatchedPayment { get; set; }
        decimal? OwnerPayments { get; set; }
        IEnumerable<IChasePayments> ChasePayments { get; set; }
        decimal? YearlyPosted { get; set; }
    }

    public interface IChasePaymentReportDTO
    {
        int MonthId { get; set; }
        int YearId { get; set; }
        string MonthName { get; set; }
        decimal? TotalChasePayment { get; set; }
        decimal? TotalPostedPayment { get; set; }
        decimal? TotalDiffPayment { get; set; }
        decimal? UnmatchedPayment { get; set; }
        decimal? TotalClinicPostedPayment { get; set; }
        decimal? TotalLABPostedPayment { get; set; }
        decimal? TotalRESPostedPayment { get; set; }
        decimal? TotalOwnerPayment { get; set; }

    }

    public interface IChasePaymentReporParenttDTO
    {
        IEnumerable<IChasePaymentReportDTO> ChasePaymentYearly { get; set; }
        decimal? PostedAmountYearly { get; set; }
    }
}
