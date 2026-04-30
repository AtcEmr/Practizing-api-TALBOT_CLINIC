using System;

namespace PractiZing.Base.Entities.ReportService
{
    public interface ICPAReportMonthYearWise
    {
        int Id { get; set; }
        int YearId { get; set; }
        int MonthId { get; set; }
        decimal? ChargeAmount { get; set; }
        decimal? ExpectedAmount { get; set; }
        decimal? DenialAmount { get; set; }
        decimal? Payment { get; set; }
        decimal? Adjustment { get; set; }
        decimal? WriteOffAmount { get; set; }
        decimal? DueAmount { get; set; }
        decimal? TotalRecoverableAmount { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
