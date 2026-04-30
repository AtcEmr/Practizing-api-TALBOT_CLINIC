using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPaymentReportData
    {
        long Id { get; set; }
        int ChargeId { get; set; }
        DateTime ChargePostDate { get; set; }
        DateTime DosDate { get; set; }
        string CptCode { get; set; }
        string Description { get; set; }
        decimal ChargeAmount { get; set; }
        decimal? Payment { get; set; }
        decimal? Adjustment { get; set; }
        string PaymentPostDate { get; set; }
        DateTime RemitDate { get; set; }
        int PatientId { get; set; }
        string BillingID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DOB { get; set; }
        string PatientUId { get; set; }
        string PerformingProviderUId { get; set; }
        string PatientCaseUId { get; set; }
        string InvoiceUId { get; set; }
        string PatientName { get; set; }
        string AccessionNumber { get; set; }
        string Aging { get; set; }
        string AgingText { get; set; }
        string AgingByPostDate { get; set; }
        string AgingByPostDateText { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime DepositCreationDate { get; set; }
        int ChargeRowNumber { get; set; }
        int InvoiceId { get; set; }
        string DepositType { get; set; }
        bool? HasDenial { get; set; }
        bool? IsAccounted { get; set; }
    }
}
