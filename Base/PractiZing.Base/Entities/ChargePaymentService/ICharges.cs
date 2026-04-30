using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface ICharges : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        int Id { get; set; }
        DateTime EntryDate { get; set; }
        DateTime BillFromDate { get; set; }
        DateTime BillToDate { get; set; }
        DateTime? ShiftDate { get; set; }
        int ChargeNo { get; set; }
        bool IsDeleted { get; set; }
        bool IsLocked { get; set; }
        int PatientCaseId { get; set; }
        int InvoiceId { get; set; }
        bool IsTaxable { get; set; }
        bool BillToInsurance { get; set; }
        bool BillToPatient { get; set; }
        bool BillToClinic { get; set; }
        string CPTCode { get; set; }
        string Mod1 { get; set; }
        string Mod2 { get; set; }
        string Mod3 { get; set; }
        string Mod4 { get; set; }
        string ICD1 { get; set; }
        string ICD2 { get; set; }
        string ICD3 { get; set; }
        string ICD4 { get; set; }
        string Description { get; set; }
        string NDCCode { get; set; }
        Int16 NDCFormat { get; set; }
        Int16? UnitOfMeasure { get; set; }
        Int16? DrugQty { get; set; }
        string TOSId { get; set; }
        string POSId { get; set; }
        Int16? PerformingProviderId { get; set; }
        Int16? OrderingProviderId { get; set; }
        Int16? PerformingFacilityId { get; set; }

        Guid? PerformingProviderUId { get; set; }
        Guid? OrderingProviderUId { get; set; }
        Guid? PerformingFacilityUId { get; set; }

        Int16 Qty { get; set; }
        bool MultiplyQty { get; set; }
        decimal Amount { get; set; }
        decimal Discount { get; set; }
        decimal Tax { get; set; }
        decimal CoIns { get; set; }
        decimal CoPay { get; set; }
        decimal Deductible { get; set; }
        string DueByFlagCD { get; set; }
        string Comments { get; set; }
        string Message1 { get; set; }
        string Message2 { get; set; }
        string RefNumber { get; set; }
        string EMG { get; set; }
        decimal? AllowedAmount { get; set; }
        decimal? BonusAmount { get; set; }

        bool IsChargeDeleted { get; set; }

        decimal PaidAmount { get; set; }

        decimal TotalAdjustment { get; set; }

        DateTime? DOS { get; set; }
        string ModifierName { get; set; }
        int PatientStatementCount { get; set; }

        IEnumerable<IDefaultReasonCode> Adjustments { get; set; }
        bool IsChanged { get; set; }
        decimal DueAmount { get; set; }
        decimal ActualAmount { get; set; }
        decimal PreviousPaid { get; set; }
        string RemarkCodes { get; set; }
        string RemarkCodeIds { get; set; }
        string AccessionNumber { get; set; }
        decimal NonAccPaid { get; set; }
        decimal TotalPaidAmount { get; set; }
        string POSDescription { get; set; }
        string TOSDescription { get; set; }
        string BatchNo { get; set; }
        bool IsActive { get; set; }
        string DiagnoseCode { get; set; }
        string PatientName { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int InsuranceCompanyId { get; set; }
        string InsuranceCompanyName { get; set; }
        string OrderingPhysician { get; }
        string OrderingPhysicianFirstName { get; set; }
        string OrderingPhysicianLastName { get; set; }
        DateTime? PlanEffectiveDate { get; set; }
        int PaymentId { get; set; }
        decimal BatchAmount { get; set; }
        int? ClaimId { get; set; }
        bool IsSelfPayment { get; set; }
        string BatchNumber { get; set; }
        int PageNumber { get; set; }
        bool? IsCPTExistInFavList { get; set; }

        Guid? VoucherUId { get; set; }
        Guid InvoiceUId { get; set; }
        IEnumerable<IPaymentCharge> PaymentCharges { get; set; }
        IChargeScrub ChargeScrubs { get; set; }
        Int16 ProviderId { get; set; }
        DateTime PatientDOB { get; set; }
        DateTime? PatientSigned { get; set; }
        string PatientCaseNumber { get; set; }

        bool IsOnlyUpdate { get; set; }
        DateTime? SentDate { get; set; }
        Guid PatientUId { get; set; }
        Guid ClaimUId { get; set; }
        string BillingID { get; set; }
        string CliaNumber { get; set; }
        Guid PatientCaseUId { get; set; }
        string InsuranceCompanyUId { get; set; }
        decimal DenialAmount { get; set; }
        bool ScrubError { get; set; }
        bool IsSameAsDefault { get; set; }
        bool IsAROldCharges { get; set; }
        int? InvoiceType { get; set; }
        int? Icd1Type { get; set; }
        bool? ReviewNeeded { get; set; }
        string ReviewComments { get; set; }
        bool? IsBillable { get; set; }
        int? ClaimBatchId { get; set; }        
        string PerformingPhysicianFirstName { get; set; }        
        string PerformingPhysicianLastName { get; set; }
        int? RefChargeId { get; set; }
        string RefChargeComment { get; set; }
        string NonBillableComments { get; set; }
        decimal? FeeAmount { get; set; }
        bool? IsDuplicate { get; set; }
        string InsuranceCompanyCode { get; set; }
        bool IsDenial { get; set; }
        bool IsFromHL7 { get; set; }
        bool? IsRejected { get; set; }
        string StatuCodeDescription { get; set; }
        string ErrorMessage { get; set; }
        decimal? InsurancePayment { get; set; }
        decimal? PatientPayment { get; set; }
        decimal OnlinePostedAmount { get; set; }
        int PatientId { get; set; }
        bool? IsRolledUpNotifyToEMR { get; set; }
        DateTime? RolledUpNotifyToEMRDateTime { get; set; }
        string ClaimChargeMod1 { get; set; }
        string ClaimChargeMod2 { get; set; }
        string ClaimChargeMod3 { get; set; }
        string ClaimChargeMod4 { get; set; }
        string ProfessionalAbbreviation { get; set; }
        bool? IsRecurring { get; set; }
        bool IsMedicaidPatientDue { get; set; }
        string PatientAccountNumber { get; set; }
        string SUDProfessionalAbbreviation { get; set; }
    }
}
