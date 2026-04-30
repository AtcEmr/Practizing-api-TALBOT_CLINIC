using System;

namespace PractiZing.Base.Entities.ReportService
{
    public interface ICPAReportMonthYearWiseChild
    {
        int Id { get; set; }
        int YearId { get; set; }
        int CPAReportMonthYearWiseId { get; set; }
        decimal? MonthPayment1 { get; set; }
        decimal? MonthPayment2 { get; set; }
        decimal? MonthPayment3 { get; set; }
        decimal? MonthPayment4 { get; set; }
        decimal? MonthPayment5 { get; set; }
        decimal? MonthPayment6 { get; set; }
        decimal? MonthPayment7 { get; set; }
        decimal? MonthPayment8 { get; set; }
        decimal? MonthPayment9 { get; set; }
        decimal? MonthPayment10 { get; set; }
        decimal? MonthPayment11 { get; set; }
        decimal? MonthPayment12 { get; set; }
        decimal? MonthAdjustment1 { get; set; }
        decimal? MonthAdjustment2 { get; set; }
        decimal? MonthAdjustment3 { get; set; }
        decimal? MonthAdjustment4 { get; set; }
        decimal? MonthAdjustment5 { get; set; }
        decimal? MonthAdjustment6 { get; set; }
        decimal? MonthAdjustment7 { get; set; }
        decimal? MonthAdjustment8 { get; set; }
        decimal? MonthAdjustment9 { get; set; }
        decimal? MonthAdjustment10 { get; set; }
        decimal? MonthAdjustment11 { get; set; }
        decimal? MonthAdjustment12 { get; set; }
        decimal? MonthWriteOff1 { get; set; }
        decimal? MonthWriteOff2 { get; set; }
        decimal? MonthWriteOff3 { get; set; }
        decimal? MonthWriteOff4 { get; set; }
        decimal? MonthWriteOff5 { get; set; }
        decimal? MonthWriteOff6 { get; set; }
        decimal? MonthWriteOff7 { get; set; }
        decimal? MonthWriteOff8 { get; set; }
        decimal? MonthWriteOff9 { get; set; }
        decimal? MonthWriteOff10 { get; set; }
        decimal? MonthWriteOff11 { get; set; }
        decimal? MonthWriteOff12 { get; set; }

        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
