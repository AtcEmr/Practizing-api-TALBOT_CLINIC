using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IInvoice : IPracticeDTO, IUniqueIdentifier, IStamp
    {
        int Id { get; set; }
        int PatientCaseId { get; set; }
        int? ChargeBatchId { get; set; }
        string AccessionNumber { get; set; }
        DateTime EntryDate { get; set; }
        DateTime BillFromDate { get; set; }
        DateTime BillToDate { get; set; }
        Int16? BillProviderId { get; set; }
        Guid? BillProviderUId { get; set; }
        Int16? SupervisingProviderId { get; set; }
        Guid? SupervisingProviderUId { get; set; }
        Int16? BillFacilityId { get; set; }
        Guid? BillFacilityUId { get; set; }
        Int16? FacilityId { get; set; }
        Guid? FacilityUId { get; set; }
        int? ClaimId { get; set; }
        Int16? PatientGender { get; set; }
        Int16? MartialStatus { get; set; }
        Int16? EmployementStatus { get; set; }
        DateTime? DateOfSign { get; set; }
        DateTime? IllnessDate { get; set; }
        DateTime? IllnessSimDate { get; set; }
        Int16? RefDoctorId { get; set; }
        Guid? RefDoctorUId { get; set; }
        DateTime? DisabilityFrom { get; set; }
        DateTime? DisabilityTo { get; set; }
        DateTime? HospitalizedFrom { get; set; }
        DateTime? HospitalizedTo { get; set; }
        int? AuthorizationNumberId { get; set; }
        int? LabSalesRepID { get; set; }
        Guid? AuthorizationNumberUId { get; set; }
        Guid? LabSalesRepUID { get; set; }
        bool AccEmploy { get; set; }
        bool AccAuto { get; set; }
        bool AccOther { get; set; }
        string AccState { get; set; }
        bool IsDeleted { get; set; }
        int? ServiceCircumstanceId { get; set; }
        bool? ReviewNeeded { get; set; }
        string ReviewComments { get; set; }

        IEnumerable<ICharges> ChargeList { get; set; }

        IEnumerable<IInvDiagnosis> InvDiagnosisLst { get; set; }

        decimal? TotalCharges { get; set; }
        decimal? TotalPaid { get; set; }
        decimal? TotalAdjustment { get; set; }
        decimal? TotalDue { get; set; }

        decimal? TotalDiscount { get; set; }

        int InvoiceId { get; set; }
        Guid InvoiceUId { get; set; }
        decimal? InsuranceBalance { get; set; }

        decimal? PatientBalance { get; set; }
        string BatchNo { get; set; }

        decimal? TotalPaymentAndAdjustment { get; set; }

        bool IsCombinedGCode { get; set; }
        string PatientName { get; set; }
        string PatientNameBillingHistory { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        DateTime? DOB { get; set; }
        DateTime? SentDate { get; set; }
        string BillingID { get; set; }
        Guid BillingUID { get; set; }
        Guid ClaimUId { get; set; }
        Guid PatientCaseUId { get; set; }
        Guid ChargeBatchUId { get; set; }
        DateTime? FromTime { get; set; }
        DateTime? ToTime { get; set; }
        Int16? PerformingProviderId { get; set; }
        Guid? PerformingProviderUId { get; set; }
        string SupervisingProviderNPI { get; set; }
        string AuthorizationNumber { get; set; }
        bool IsAROldCharges { get; set; }
        Guid? OrderringProviderUId { get; set; }
        short? OrderringProviderId { get; set; }
        Guid? AuxillaryProviderUId { get; set; }
        short? AuxillaryProviderId { get; set; }
        int? InvoiceType { get; set; }
        string EncounterTypeCode { get; set; }
        bool? IsBillable { get; set; }
        string BillableCoupon { get; set; }
        List<string> InvoiceUIds { get; set; }
        decimal? FeeAmount { get; set; }
        string NonBillableComments { get; set; }
        bool? IsFromHl7 { get; set; }
        string InternalMessage { get; set; }
        bool? IsRejected { get; set; }
        string RejectedPIN { get; set; }
        bool? IspmgEncounter { get; set; }
        string PatientAccountNumber { get; set; }
        string OtherPlaceOfService { get; set; }
        string PrimaryPayerCode { get; set; }
    }
}
