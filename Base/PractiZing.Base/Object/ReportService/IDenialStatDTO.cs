using System;

namespace PractiZing.Base.Object.ReportService
{
    public interface IDenialStatDTO
    {
        int ChargeId { get; set; }
        string AccessionNumber { get; set; }
        DateTime? DOS { get; set; }
        string CPTCode { get; set; }
        string Modifier { get; }
        string Mod1 { get; set; }
        string Mod2 { get; set; }
        string Mod3 { get; set; }
        string Mod4 { get; set; }
        string DueByFlagCD { get; set; }
        int? PatientCaseId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PatientName { get; }
        int PatientId { get; set; }
        Guid PatientUId { get; set; }
        decimal? TotalPaidAmount { get; set; }
        decimal? TotalAdjustment { get; set; }
        decimal? CoPay { get; set; }
        decimal? Deductible { get; set; }
        decimal? InsuranceOverDue { get; }
        decimal? PatientOverDue { get; }
        int? InsuranceCompanyId { get; set; }
        Guid? InsuranceCompanyUId { get; set; }
        short? InsuranceCompanyTypeId { get; set; }
        string InsuranceCompanyType { get; set; }
        string InsuranceCompanyName { get; set; }
        string ReasonCodes { get; set; }
        DateTime? EntryDate { get; set; }
        int? PatientStatementSentCount { get; set; }
        string StatName { get; set; }
        decimal? Charge { get; set; }
        decimal? Balance { get; set; }
        string AssignedTo { get; set; }
        DateTime? FollowUpDate { get; set; }
        DateTime? EffectiveDate { get; set; }
        Guid ChargeUId { get; set; }
        string OrderingPhysicianLastName { get; set; }
        string OrderingPhysicianFirstName { get; set; }
        string OrderingPhysician { get; }
        int InvoiceId { get; set; }
        Guid InvoiceUId { get; set; }
        DateTime PatientDOB { get; set; }
        Guid PatientCaseUId { get; set; }
        Guid? PerformingProviderUId { get; set; }
        //DateTime? fromDate { get; set; }
        //DateTime? toDate { get; set; }
    }
}