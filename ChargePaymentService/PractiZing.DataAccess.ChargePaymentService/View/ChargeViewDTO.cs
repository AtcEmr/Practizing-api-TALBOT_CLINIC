using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.View
{
    [Alias("vw_GetChargeForPendingPayment")]
    public class ChargeViewDTO : ICharges
    {
        public ChargeViewDTO()
        {
            this.PaymentCharges = new List<PaymentCharge>();
            this.ChargeScrubs = new ChargeScrub();
        }

        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime BillFromDate { get; set; }
        public DateTime BillToDate { get; set; }
        public DateTime? ShiftDate { get; set; }
        public int ChargeNo { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public int PatientCaseId { get; set; }
        public int InvoiceId { get; set; }
        public bool IsTaxable { get; set; }
        public bool BillToInsurance { get; set; }
        public bool BillToPatient { get; set; }
        public bool BillToClinic { get; set; }
        public string CPTCode { get; set; }
        public string Mod1 { get; set; }
        public string Mod2 { get; set; }
        public string Mod3 { get; set; }
        public string Mod4 { get; set; }
        public string ICD1 { get; set; }
        public string ICD2 { get; set; }
        public string ICD3 { get; set; }
        public string ICD4 { get; set; }
        public string Description { get; set; }
        public string NDCCode { get; set; }
        public short NDCFormat { get; set; }
        public short? UnitOfMeasure { get; set; }
        public short? DrugQty { get; set; }
        public string TOSId { get; set; }
        public string POSId { get; set; }
        public short? PerformingProviderId { get; set; }
        public short? OrderingProviderId { get; set; }
        public short? PerformingFacilityId { get; set; }
        public short Qty { get; set; }
        public bool MultiplyQty { get; set; }
        public decimal Amount { get; set; }
        public decimal? AllowedAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }

        public string DueByFlagCD { get; set; }
        public string Comments { get; set; }
        public string Message1 { get; set; }
        public string Message2 { get; set; }

        public string RefNumber { get; set; }
        public string EMG { get; set; }
        public decimal DueAmount { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        public decimal TotalPaidAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal TotalAdjustment { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDuplicate { get; set; }
        public string StatuCodeDescription { get; set; }
        public string ErrorMessage { get; set; }
        [Ignore]
        public bool? IsRejected { get; set; }

        [Ignore]
        public decimal? BonusAmount { get; set; }

        [Ignore]
        public int PatientStatementCount { get; set; }
        [Ignore]
        public string RemarkCodeIds { get; set; }
        [Ignore]
        public int PaymentId { get; set; }
        [Ignore]
        public decimal ActualAmount { get; set; }

        [Ignore]
        public bool IsChargeDeleted { get; set; }

        [Ignore]
        public DateTime? DOS { get; set; }

        [Ignore]
        public string ModifierName { get; set; }

        [Ignore]
        public decimal PreviousPaid { get; set; }

        [Ignore]
        public IEnumerable<IDefaultReasonCode> Adjustments { get; set; }

        [Ignore]
        public bool IsChanged { get; set; }

        [Ignore]
        public string RemarkCodes { get; set; }

        [Ignore]
        public decimal NonAccPaid { get; set; }

        [Ignore]
        public string AccessionNumber { get; set; }

        [Ignore]
        public string POSDescription { get; set; }

        [Ignore]
        public string TOSDescription { get; set; }

        public string BatchNo { get; set; }
        public bool IsActive { get; set; }

        [Ignore]
        public string DiagnoseCode { get; set; }

        [Ignore]
        public string PatientName
        {
            get
            {
                return $"{FirstName}  {LastName}";
            }
        }

        [Ignore]
        public string FirstName { get; set; }

        [Ignore]
        public string LastName { get; set; }

        [Ignore]
        public int InsuranceCompanyId { get; set; }

        [Ignore]
        public string InsuranceCompanyName { get; set; }

        [Ignore]
        public string OrderingPhysician
        {
            get
            {
                return $"{OrderingPhysicianFirstName}  {OrderingPhysicianLastName}";
            }
        }
        [Ignore]
        public string OrderingPhysicianFirstName { get; set; }
        [Ignore]
        public string OrderingPhysicianLastName { get; set; }

        [Ignore]
        public DateTime? PlanEffectiveDate { get; set; }

        [Ignore]
        [Alias("Amount")]
        public decimal BatchAmount { get; set; }

        [Ignore]
        public int? ClaimId { get; set; }

        [Ignore]
        public string BatchNumber { get; set; }

        [Ignore]
        public bool IsSelfPayment { get; set; }

        [Ignore]
        public short? DueBy { get; set; }

        [Ignore]
        public decimal CoIns { get; set; }

        [Ignore]
        public decimal CoPay { get; set; }

        [Ignore]
        public decimal Deductible { get; set; }

        [Ignore]
        public int PageNumber { get; set; }

        [Ignore]
        public bool? IsCPTExistInFavList { get; set; }

        [Ignore]
        public Guid? VoucherUId { get; set; }

        [Ignore]
        public Guid? PaymentUId { get; set; }

        [Ignore]
        public IEnumerable<IPaymentCharge> PaymentCharges { get; set; }

        [Ignore]
        public short ProviderId { get; set; }

        [Ignore]
        public DateTime PatientDOB { get; set; }

        [Ignore]
        public DateTime? PatientSigned { get; set; }

        [Ignore]
        public string PatientCaseNumber { get; set; }

        [Ignore]
        public bool IsOnlyUpdate { get; set; }

        [Ignore]
        public DateTime? SentDate { get; set; }

        [Ignore]
        public Guid PatientUId { get; set; }

        [Ignore]
        public string BillingID { get; set; }

        [Ignore]
        public Guid ClaimUId { get; set; }

        [Ignore]
        public Guid? PerformingProviderUId { get; set; }
        [Ignore]
        public Guid? OrderingProviderUId { get; set; }
        [Ignore]
        public Guid? PerformingFacilityUId { get; set; }
        //[Ignore]
        //public string ICD1Code { get; set; }
        //[Ignore]
        //public string ICD2Code { get; set; }
        //[Ignore]
        //public string ICD3Code { get; set; }
        //[Ignore]
        //public string ICD4Code { get; set; }
        //[Ignore]
        //public string CPTCodeLabel { get; set; }
        [Ignore]
        public string CliaNumber { get; set; }

        [Ignore]
        public Guid PatientCaseUId { get; set; }

        [Ignore]
        public string InsuranceCompanyUId { get; set; }
        [Ignore]
        public decimal DenialAmount { get; set; }

        [Ignore]
        public Guid InvoiceUId { get; set; }

        //[Ignore]
        public bool ScrubError { get; set; }
        [Ignore]
        public IChargeScrub ChargeScrubs { get; set; }
        [Ignore]
        public bool IsSameAsDefault { get; set; }

        //[Ignore]
        public bool IsAROldCharges { get; set; }

        [Ignore]
        public int? InvoiceType { get; set; }

        [Ignore]
        public int? Icd1Type { get; set; }

        //[Ignore]
        public bool? ReviewNeeded { get; set; }

        [Ignore]
        public string ReviewComments { get; set; }

        //[Ignore]
        public bool? IsBillable { get; set; }

        [Ignore]
        public int? ClaimBatchId { get; set; }
        [Ignore]
        public string PerformingPhysicianFirstName { get; set; }
        [Ignore]
        public string PerformingPhysicianLastName { get; set; }
        [Ignore]
        public string PerformingPhysician
        {
            get
            {
                return $"{PerformingPhysicianFirstName}  {PerformingPhysicianLastName}";
            }
        }

        public int? RefChargeId { get; set; }
        public string RefChargeComment { get; set; }
        public bool? IsRolledUpNotifyToEMR { get; set; }
        public DateTime? RolledUpNotifyToEMRDateTime { get; set; }

        [Ignore]
        public string NonBillableComments { get; set; }

        [Ignore]
        public decimal? FeeAmount { get; set; }

        [Ignore]
        public string InsuranceCompanyCode { get; set; }

        [Ignore]
        public bool IsDenial { get; set; }

        [Ignore]
        public bool IsFromHL7 { get; set; }
        [Ignore]
        public decimal? InsurancePayment { get; set; }
        [Ignore]
        public decimal? PatientPayment { get; set; }

        [Ignore]
        public decimal OnlinePostedAmount { get; set; }
        [Ignore]
        public int PatientId { get; set; }
        [Ignore]
        public string ClaimChargeMod1 { get; set; }
        [Ignore]
        public string ClaimChargeMod2 { get; set; }
        [Ignore]
        public string ClaimChargeMod3 { get; set; }
        [Ignore]
        public string ClaimChargeMod4 { get; set; }
        [Ignore]
        public string ProfessionalAbbreviation { get; set; }
        [Ignore]
        public string SUDProfessionalAbbreviation { get; set; }
        [Ignore]
        public bool? IsRecurring { get; set; }
        [Ignore]
        public bool IsMedicaidPatientDue { get; set; }
        [Ignore]
        public string PatientAccountNumber { get; set; }
    }
}
