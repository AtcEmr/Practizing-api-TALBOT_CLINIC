using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChasePaymentDTO : IChasePaymentDTO
    {
        public ChasePaymentDTO()
        {
            BankReconciliationIds = new List<int>();
        }

        public int  ChasePaymentId { get; set; }
        public IEnumerable<int> BankReconciliationIds { get; set; }
    }

    public class ChasePaymentDashboardDTO : IChasePaymentDashboardDTO
    {
        public ChasePaymentDashboardDTO()
        {
            ChasePayments = new List<IChasePayments>();
        }
        
        public decimal? TotalChasePayment { get; set; }        
        public decimal? TotalPostedPayment { get; set; }        
        public decimal? TotalDiffPayment { get; set; }        
        public decimal? UnmatchedPayment { get; set; }
        public decimal? OwnerPayments { get; set; }
        public decimal? UnmatchedChasePayment { get; set; }
        public decimal? YearlyPosted { get; set; }

        public IEnumerable<IChasePayments> ChasePayments { get; set; }
    }

    public class ChasePaymentReportDTO : IChasePaymentReportDTO
    {

        public int MonthId { get; set; }
        public int YearId { get; set; }
        public string MonthName { get; set; }
        public decimal? TotalChasePayment { get; set; }
        public decimal? TotalPostedPayment { get; set; }
        public decimal? TotalDiffPayment { get; set; }
        public decimal? UnmatchedPayment { get; set; }
        public decimal? TotalClinicPostedPayment { get; set; }
        public decimal? TotalLABPostedPayment { get; set; }
        public decimal? TotalRESPostedPayment { get; set; }
        public decimal? TotalOwnerPayment { get; set; }
    }

    public class ChasePaymentReporParenttDTO : IChasePaymentReporParenttDTO
    {
        public ChasePaymentReporParenttDTO()
        {
            ChasePaymentYearly = new List<ChasePaymentReportDTO>();
        }

        public IEnumerable<IChasePaymentReportDTO> ChasePaymentYearly { get; set; }
        public decimal? PostedAmountYearly { get; set; }
    }
}
