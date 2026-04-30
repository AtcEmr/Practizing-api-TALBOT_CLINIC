using PractiZing.Base.Object.ChargePaymentService;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class AddClaimInfoDTO : IAddClaimInfoDTO
    {
        public int InvoiceId { get; set; }
        public int PatientCaseId { get; set; }
        public int InsuranceLevel { get; set; }
        public string Frequency { get; set; }
        public string Box10 { get; set; }
        public string Box19 { get; set; }
        public string Box7 { get; set; }
        public string Box80 { get; set; }
        public DateTime PatientSignatureDate { get; set; }
        public string OriginalReferenceNumber { get; set; }
        public string MedicadeResubmissionCode { get; set; }
        public Guid PatientCaseUId { get; set; }
        public Guid InvoiceUId { get; set; }
        public Guid InsurancePolicyUId { get; set; }
        //public string ChargeBatchUId { get; set; }
    }
}
