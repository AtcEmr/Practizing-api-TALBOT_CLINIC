using System;

namespace PractiZing.Base.Entities.ReportService
{
    public interface IChargeStat
    {
        int Id { get; set; }
        int? ActionStatusId { get; set; }
        int? InsuranceCompanyId { get; set; }
        decimal? Charges { get; set; }
        decimal? Payments { get; set; }
        decimal? Adjustments { get; set; }
        decimal? Denials { get; set; }
        bool? HasDenial { get; set; }
        DateTime? EntryDate { get; set; }
        decimal? Amount { get; set; }
        string StatName { get; set; }
        Guid? StatUId { get; set; }
        int? InsuranceCompanyTypeId { get; set; }
        short? StatId { get; set; }
        string OrderingPhysician { get; set; }
        DateTime? EffectiveDate { get; set; }
        string DueByFlag { get; set; }
        //string Modifier { get; set; }
        //decimal? Balance { get; set; }
        //decimal? PatientOverDue { get; set; }
    }
}
