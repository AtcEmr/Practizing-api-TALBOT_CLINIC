using PractiZing.Base.Entities.ReportService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ReportService.Tables
{
    public class CPAReportMonthYearWise : ICPAReportMonthYearWise
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public decimal? ChargeAmount { get; set; }
        public decimal? ExpectedAmount { get; set; }
        public decimal? DenialAmount { get; set; }
        public decimal? Payment { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? WriteOffAmount { get; set; }
        public decimal? DueAmount { get; set; }
        public decimal? TotalRecoverableAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
