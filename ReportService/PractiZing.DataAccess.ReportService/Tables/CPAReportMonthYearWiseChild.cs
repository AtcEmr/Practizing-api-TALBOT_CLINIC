using PractiZing.Base.Entities.ReportService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ReportService.Tables
{
    public class CPAReportMonthYearWiseChild : ICPAReportMonthYearWiseChild
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int CPAReportMonthYearWiseId { get; set; }
        public decimal? MonthPayment1 { get; set; }
        public decimal? MonthPayment2 { get; set; }
        public decimal? MonthPayment3 { get; set; }
        public decimal? MonthPayment4 { get; set; }
        public decimal? MonthPayment5 { get; set; }
        public decimal? MonthPayment6 { get; set; }
        public decimal? MonthPayment7 { get; set; }
        public decimal? MonthPayment8 { get; set; }
        public decimal? MonthPayment9 { get; set; }
        public decimal? MonthPayment10 { get; set; }
        public decimal? MonthPayment11 { get; set; }
        public decimal? MonthPayment12 { get; set; }
        public decimal? MonthAdjustment1 { get; set; }
        public decimal? MonthAdjustment2 { get; set; }
        public decimal? MonthAdjustment3 { get; set; }
        public decimal? MonthAdjustment4 { get; set; }
        public decimal? MonthAdjustment5 { get; set; }
        public decimal? MonthAdjustment6 { get; set; }
        public decimal? MonthAdjustment7 { get; set; }
        public decimal? MonthAdjustment8 { get; set; }
        public decimal? MonthAdjustment9 { get; set; }
        public decimal? MonthAdjustment10 { get; set; }
        public decimal? MonthAdjustment11 { get; set; }
        public decimal? MonthAdjustment12 { get; set; }
        public decimal? MonthWriteOff1 { get; set; }
        public decimal? MonthWriteOff2 { get; set; }
        public decimal? MonthWriteOff3 { get; set; }
        public decimal? MonthWriteOff4 { get; set; }
        public decimal? MonthWriteOff5 { get; set; }
        public decimal? MonthWriteOff6 { get; set; }
        public decimal? MonthWriteOff7 { get; set; }
        public decimal? MonthWriteOff8 { get; set; }
        public decimal? MonthWriteOff9 { get; set; }
        public decimal? MonthWriteOff10 { get; set; }
        public decimal? MonthWriteOff11 { get; set; }
        public decimal? MonthWriteOff12 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
