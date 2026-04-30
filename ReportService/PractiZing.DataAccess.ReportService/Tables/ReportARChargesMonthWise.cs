using PractiZing.Base.Entities.ReportService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ReportService.Tables
{
    public class ReportARChargesMonthWise : IReportARChargesMonthWise
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public decimal? Jan { get; set; }        
        public decimal? Feb { get; set; }
        public decimal? March { get; set; }
        public decimal? April { get; set; }
        public decimal? May { get; set; }
        public decimal? June { get; set; }
        public decimal? July { get; set; }
        public decimal? Aug { get; set; }
        public decimal? Sep { get; set; }
        public decimal? Oct { get; set; }
        public decimal? Nov { get; set; }
        public decimal? Dec { get; set; }
        public decimal? Charges { get; set; }
        
        public decimal? RecoverdAmount { get; set; }
        public string RecoverdPercentage { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Ignore]
        public string ChargesString { get; set; }
        [Ignore]
        public string Month { get; set; }
        [Ignore]
        public string CreatedDateString { get; set; }
        [Ignore]
        public string JanString { get; set; }
        [Ignore]
        public string FebString { get; set; }
        [Ignore]
        public string MarchString { get; set; }
        [Ignore]
        public string AprilString { get; set; }
        [Ignore]
        public string MayString { get; set; }
        [Ignore]
        public string JuneString { get; set; }
        [Ignore]
        public string JulyString { get; set; }
        [Ignore]
        public string AugString { get; set; }
        [Ignore]
        public string SepString { get; set; }
        [Ignore]
        public string OctString { get; set; }
        [Ignore]
        public string NovString { get; set; }
        [Ignore]
        public string DecString { get; set; }
        [Ignore]
        public string RecoverdAmountString { get; set; }
    }
}
