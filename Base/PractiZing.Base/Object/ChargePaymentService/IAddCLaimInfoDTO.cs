using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IAddClaimInfoDTO
    {
        int InvoiceId { get; set; }
        int PatientCaseId { get; set; }
        int InsuranceLevel { get; set; }
        string Frequency { get; set; }
        string Box10 { get; set; }
        string Box19 { get; set; }
        string Box7 { get; set; }
        string Box80 { get; set; }
        DateTime PatientSignatureDate { get; set; }
        string OriginalReferenceNumber { get; set; }
        string MedicadeResubmissionCode { get; set; }

        Guid PatientCaseUId { get; set; }
        Guid InvoiceUId { get; set; }
        Guid InsurancePolicyUId { get; set; }
        //string ChargeBatchUId { get; set; }
    }
}
