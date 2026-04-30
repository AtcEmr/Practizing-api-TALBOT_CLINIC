using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargesReportDataDTO
    {
        long TotalSamples { get; set; }
        decimal? ChargesAmount { get; set; }
        decimal? Payments { get; set; }
        decimal? Adjustments { get; set; }
        decimal? DenialsAmount { get; set; }
        decimal? DueAmount { get; set; }
        decimal? FeeAmount { get; set; }
        decimal? WriteOffAmount { get; set; }        
        IEnumerable<IChargesReportData> Charges { get; set; }
    }

    public interface ICPAReportDTO
    {
        decimal? ThirtyDaysBalance { get; set; }
        decimal? SixtyDaysBalance { get; set; }
        decimal? AboveNintyBalance { get; set; }
        decimal? UnAdjucatedBalance { get; set; }
        decimal? UnderPaid { get; set; }
        decimal? BillableButNotClaimed { get; set; }
        decimal? NotBillableClaim { get; set; }
        decimal? UnTouchCharges { get; set; }
        decimal? AllCharges { get; set; }
        decimal? InWriteOffRequest { get; set; }
        decimal? ClaimFillingLimit { get; set; }
        decimal? RejectedCharges { get; set; }
        decimal? TotalWriteOff { get; set; }
        decimal? PayerRatherThanSelfAmount { get; set; }
        decimal? BilledVsCurrentIns { get; set; }
    }

    public interface IPatientBalanceForEMR
    {
        int PatientId { get; set; }
        string BillingID { get; set; }
        string EmrBillingId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DOB { get; set; }
        string CptCode { get; set; }
        DateTime DosDate { get; set; }
        string Provider { get; set; }
        decimal? ChargeAmount { get; set; }
        decimal? FeeAmount { get; set; }
        decimal? Payment { get; set; }
        decimal? Adjustment { get; set; }
        string AdjustmentCode { get; set; }
        decimal? DueAmount { get; set; }
        string DBName { get; set; }
        bool? IsMedicaidCharge { get; set; }
    }

    public interface IBalanceForEMR
    {
        string BillingID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DOB { get; set; }
        decimal? DueAmount { get; set; }
        string PatientPhone { get; set; }
        string PatientCaseUId { get; set; }
        DateTime DosDate { get; set; }
        int PatientCaseId { get; set; }
        decimal UnPostedAmount { get; set; }
        decimal UnMatchedAmount { get; set; }
        string DBName { get; set; }
    }
}
