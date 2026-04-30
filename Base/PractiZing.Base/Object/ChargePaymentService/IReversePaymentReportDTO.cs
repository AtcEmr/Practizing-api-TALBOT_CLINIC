using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IReversePaymentReportDTO
    {
        int ChargeId { get; set; }
        int PatientId { get; set; }
        string BillingID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Provider { get; set; }
        DateTime DosDate { get; set; }
        string CptCode { get; set; }
        decimal ChargeAmount { get; set; }
        decimal AdjustmentAmount { get; set; }
        decimal TakeBackAmount { get; set; }
        DateTime PaymentDate { get; set; }
        string CheckNumber { get; set; }
        decimal DueAmount { get; set; }
        string AdjustCode { get; set; }
        string AdjustReason { get; set; }
        string RemarkCode { get; set; }
        string RemarkMessage { get; set; }
        decimal ActualPayment { get; set; }
        string InsuranceCompany { get; set; }
        string AccessionNumber { get; set; }
        string PatientUId { get; set; }
        string DueBy { get; set; }
        string PaymentPostDate { get; set; }
        string RemitDate { get; set; }
    }
}
