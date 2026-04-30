using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.DataAccess.Common;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class DrugCharge : ICharges
    {
        public DrugCharge()
        {
            this.ChargeScrubs = new ChargeScrub();
            this.Adjustments = new List<DefaultReasonCode>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime BillFromDate { get; set; }
        public DateTime BillToDate { get; set; }
        public DateTime? ShiftDate { get; set; }
        public int ChargeNo { get; set; }

        public bool IsDeleted { get; set; }
        public bool? IsRejected { get; set; }
        public bool IsLocked { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int PatientCaseId { get; set; }
        public int InvoiceId { get; set; }

        public bool IsTaxable { get; set; }
        public bool BillToInsurance { get; set; }
        public bool BillToPatient { get; set; }
        public bool BillToClinic { get; set; }
        [MaxLength(5, ErrorMessage = "CPTCode -Must not enter more than 5 characters.")]
        [System.ComponentModel.DataAnnotations.Required]
        public string CPTCode { get; set; }

        [MaxLength(2, ErrorMessage = "Mod1 -Must not enter more than 2 characters.")]
        public string Mod1 { get; set; }
        [MaxLength(2, ErrorMessage = "Mod2 -Must not enter more than 2 characters.")]
        public string Mod2 { get; set; }
        [MaxLength(2, ErrorMessage = "Mod3 - Must not enter more than 2 characters.")]
        public string Mod3 { get; set; }
        [MaxLength(2, ErrorMessage = "Mod4 - Must not enter more than 2 characters.")]
        public string Mod4 { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(12, ErrorMessage = "ICD1 - Must not enter more than 12 characters.")]
        public string ICD1 { get; set; }
        [MaxLength(12, ErrorMessage = "ICD2 - Must not enter more than 12 characters.")]
        public string ICD2 { get; set; }
        [MaxLength(12, ErrorMessage = "ICD3 - Must not enter more than 12 characters.")]
        public string ICD3 { get; set; }
        [MaxLength(12, ErrorMessage = "ICD4 - Must not enter more than 12 characters.")]
        public string ICD4 { get; set; }

        [MaxLength(255, ErrorMessage = "Description - Must not enter more than 255 characters.")]
        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
        [MaxLength(11, ErrorMessage = "NDCCode - Must not enter more than 11 characters.")]
        public string NDCCode { get; set; }

        public short NDCFormat { get; set; }

        public short? UnitOfMeasure { get; set; }

        public short? DrugQty { get; set; }

        public string TOSId { get; set; }

        public string POSId { get; set; }

        public short? PerformingProviderId { get; set; }

        public short? OrderingProviderId { get; set; }
        //[System.ComponentModel.DataAnnotations.Required]
        public short? PerformingFacilityId { get; set; }

        public short Qty { get; set; }

        public bool MultiplyQty { get; set; }


        public decimal Amount { get; set; }

        public decimal Discount { get; set; }
        public decimal Tax { get; set; }

        [MaxLength(50, ErrorMessage = "DueByFlagCD - Must not enter more than 50 characters.")]
        public string DueByFlagCD { get; set; }

        [MaxLength(500, ErrorMessage = "Comments - Must not enter more than 500 characters.")]
        public string Comments { get; set; }

        [MaxLength(10, ErrorMessage = "Message1 - Must not enter more than 10 characters.")]
        public string Message1 { get; set; }
        [MaxLength(10, ErrorMessage = "Message2 - Must not enter more than 10 characters.")]
        public string Message2 { get; set; }
        [MaxLength(20, ErrorMessage = "RefNumber - Must not enter more than 20 characters.")]
        public string RefNumber { get; set; }
        [MaxLength(2, ErrorMessage = "EMG - Must not enter more than 2 characters.")]
        public string EMG { get; set; }

        public decimal CoIns { get; set; }
        public decimal CoPay { get; set; }
        public decimal Deductible { get; set; }
        public decimal? AllowedAmount { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int PatientStatementCount { get; set; }
        public decimal? BonusAmount { get; set; }
        public bool ScrubError { get; set; }

        public int? RefChargeId { get; set; }
        public string RefChargeComment { get; set; }
        public bool? IsDuplicate { get; set; }
        public bool? IsRolledUpNotifyToEMR { get; set; }
        public DateTime? RolledUpNotifyToEMRDateTime { get; set; }

        [ServiceStack.DataAnnotations.Ignore]
        public IChargeScrub ChargeScrubs { get; set; }

        [ServiceStack.DataAnnotations.Ignore]
        public bool IsChargeDeleted { get; set; }

        [ServiceStack.DataAnnotations.Ignore]
        public decimal PaidAmount { get; set; }

        [ServiceStack.DataAnnotations.Ignore]
        public decimal TotalAdjustment { get; set; }

        [ServiceStack.DataAnnotations.Ignore]
        public DateTime? DOS { get; set; }
        [ServiceStack.DataAnnotations.Ignore]
        public string ModifierName { get; set; }

        [Ignore]
        public IEnumerable<IDefaultReasonCode> Adjustments { get; set; }
        [Ignore]
        public bool IsChanged { get; set; }
        [Ignore]
        public decimal DueAmount { get; set; }
        [Ignore]
        public decimal PreviousPaid { get; set; }
        [Ignore]
        public decimal ActualAmount { get; set; }
        [Ignore]
        public string RemarkCodes { get; set; }
        [Ignore]
        public decimal NonAccPaid { get; set; }
        [Ignore]
        public string AccessionNumber { get; set; }
        [Ignore]
        public decimal TotalPaidAmount { get; set; }
        [Ignore]
        public string POSDescription { get; set; }
        [Ignore]
        public string TOSDescription { get; set; }
        [Ignore]
        public string BatchNo { get; set; }
        [Ignore]
        public bool IsActive { get; set; }
        [Ignore]
        public string DiagnoseCode { get; set; }
        [Ignore]
        public string FirstName { get; set; }
        [Ignore]
        public string LastName { get; set; }
        [Ignore]
        public string PatientName
        {
            get
            {
                return $"{FirstName}  {LastName}";
            }
        }

        [Ignore]
        public int InsuranceCompanyId { get; set; }

        [Ignore]
        public string InsuranceCompanyName { get; set; }

        [Ignore]
        public string InsuranceCompanyCode { get; set; }

        [Ignore]
        public string OrderingPhysician
        {
            get
            {
                return $"{OrderingPhysicianFirstName}  {OrderingPhysicianLastName}";
            }
        }

        [Ignore]
        public string PerformingPhysician
        {
            get
            {
                return $"{PerformingPhysicianFirstName}  {PerformingPhysicianLastName}";
            }
        }

        [Ignore]
        public string BillingPhysician
        {
            get
            {
                return $"{BillingPhysicianFirstName}  {BillingPhysicianLastName}";
            }
        }

        [Ignore]
        public string OrderingPhysicianFirstName { get; set; }
        [Ignore]
        public string OrderingPhysicianLastName { get; set; }

        [Ignore]
        public string PerformingPhysicianFirstName { get; set; }
        [Ignore]
        public string PerformingPhysicianLastName { get; set; }

        [Ignore]
        public string BillingPhysicianFirstName { get; set; }
        [Ignore]
        public string BillingPhysicianLastName { get; set; }


        [Ignore]
        public DateTime? PlanEffectiveDate { get; set; }

        [Ignore]
        public int PaymentId { get; set; }

        [Ignore]
        public decimal BatchAmount { get; set; }

        [Ignore]
        public int? ClaimId { get; set; }

        [Ignore]
        public bool IsSelfPayment { get; set; }

        [Ignore]
        public string BatchNumber { get; set; }

        [Ignore]
        public int PageNumber { get; set; }

        [Ignore]
        public bool? IsCPTExistInFavList { get; set; }

        [Ignore]
        public Guid? VoucherUId { get; set; }

        [Ignore]
        public Guid InvoiceUId { get; set; }

        [Ignore]
        public IEnumerable<IPaymentCharge> PaymentCharges { get; set; }

        [Ignore]
        public Int16 ProviderId { get; set; }

        [Ignore]
        public DateTime PatientDOB { get; set; }

        [Ignore]
        public DateTime? PatientSigned { get; set; }

        [Ignore]
        public string PatientCaseNumber { get; set; }
        [Ignore]
        public string RemarkCodeIds { get; set; }
        [Ignore]
        public bool IsOnlyUpdate { get; set; }

        [Ignore]
        public DateTime? SentDate { get; set; }

        [Ignore]
        public Guid PatientUId { get; set; }

        [Ignore]
        public Guid PatientCaseUId { get; set; }

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

        [Ignore]
        public string CliaNumber { get; set; }

        [Ignore]
        public string InsuranceCompanyUId { get; set; }
        [Ignore]
        public decimal DenialAmount { get; set; }

        [Ignore]
        public bool IsSameAsDefault { get; set; }

        [Ignore]
        public bool IsAROldCharges { get; set; }

        [Ignore]
        public int? InvoiceType { get; set; }

        [Ignore]
        public int? Icd1Type { get; set; }

        [Ignore]
        public bool? ReviewNeeded { get; set; }

        [Ignore]
        public string ReviewComments { get; set; }

        [Ignore]
        public bool? IsBillable { get; set; }

        [Ignore]
        public int? ClaimBatchId { get; set; }

        [Ignore]
        public string NonBillableComments { get; set; }
        [Ignore]
        public decimal? FeeAmount { get; set; }
        [Ignore]
        public bool IsDenial { get; set; }
        [Ignore]
        public bool IsFromHL7 { get; set; }
        [Ignore]
        public string StatuCodeDescription { get; set; }
        [Ignore]
        public string ErrorMessage { get; set; }

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
        public bool? IsRecurring { get; set; }
        [Ignore]
        public bool IsMedicaidPatientDue { get; set; }
        [Ignore]
        public string PatientAccountNumber { get; set; }
        [Ignore]
        public string SUDProfessionalAbbreviation { get; set; }

    }
}
