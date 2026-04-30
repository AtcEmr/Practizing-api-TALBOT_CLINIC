using System;

namespace PractiZing.Base.Entities.ReportService
{
    public interface IReportARChargesMonthWise
    {
        int Id { get; set; }
        int YearId { get; set; }
        int MonthId { get; set; }
        decimal? Jan { get; set; }
        decimal? Feb { get; set; }
        decimal? March { get; set; }
        decimal? April { get; set; }
        decimal? May { get; set; }
        decimal? June { get; set; }
        decimal? July { get; set; }
        decimal? Aug { get; set; }
        decimal? Sep { get; set; }
        decimal? Oct { get; set; }
        decimal? Nov { get; set; }
        decimal? Dec { get; set; }
        decimal? Charges { get; set; }
        decimal? RecoverdAmount { get; set; }
        string RecoverdAmountString { get; set; }
        string RecoverdPercentage { get; set; }
        DateTime? CreatedDate { get; set; }
        string Month { get; set; }
        string CreatedDateString { get; set; }
        
        string JanString { get; set; }
        
        string FebString { get; set; }
        
        string MarchString { get; set; }
        
        string AprilString { get; set; }
        
        string MayString { get; set; }
        
        string JuneString { get; set; }
        
        string JulyString { get; set; }
        
        string AugString { get; set; }
        
        string SepString { get; set; }
        
        string OctString { get; set; }
        
        string NovString { get; set; }
        
        string DecString { get; set; }
        string ChargesString { get; set; }
    }
}
