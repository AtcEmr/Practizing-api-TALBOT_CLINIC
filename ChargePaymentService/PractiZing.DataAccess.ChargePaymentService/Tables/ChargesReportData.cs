using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ChargesReportData : IChargesReportData
    {

        public ChargesReportData()
        {
            
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }
        public Guid ChargeUId { get; set; }
        public int ChargeId { get; set; }
        public DateTime ChargePostDate { get; set; }
        public DateTime DosDate { get; set; }
        public string CptCode { get; set; }
        public string Description { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal? Payment { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? DueAmount { get; set; }
        public string Aging { get; set; }
        public string AgingText { get; set; }
        public string AdjustmentCode { get; set; }
        public string Denial { get; set; }
        public int InsuranceCompanyId { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string CompanyType { get; set; }
        public int PerforingProviderId { get; set; }
        public string PerforingProviderName { get; set; }
        public string BillFacilityName { get; set; }
        public string PaymentReceived { get; set; }
        public int? ClaimId { get; set; }
        public DateTime? ClaimSentDate { get; set; }
        public string ClaimStatus { get; set; }
        public int? PerformingFacilityId { get; set; }
        public string PerformingFacilityName { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal? DenialAmount { get; set; }
        public string DueBy { get; set; }
        public string ClaimSent { get; set; }
        public string PaymentPostDate { get; set; }
        public string IsRollUp { get; set; }        
        public string RemitDate { get; set; }
        public int InvoiceId { get; set; }
        public int PatientCaseId { get; set; }
        public int PatientId { get; set; }
        public string BillingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string PatientUId { get; set; }
        public string PerformingProviderUId { get; set; }
        public string PatientCaseUId { get; set; }
        public string InvoiceUId { get; set; }
        public string PatientName { get; set; }
        public string AccessionNumber { get; set; }
        public string AgingByPostDate { get; set; }
        public string AgingByPostDateText { get; set; }
        public string ReasonCodeDescription { get; set; }
        public decimal? FeeAmount { get; set; }
        public decimal? WriteOffAmount { get; set; }
        public decimal? PatientPayment { get; set; }
        public string ReasonCode1 { get; set; }
        public string ReasonCode2 { get; set; }
        public string ReasonCode3 { get; set; }
        public string ReasonCode4 { get; set; }
        public string Deleted { get; set; }
        public int? PrimaryInsuranceCompanyId { get; set; }
        public string PrimaryInsuranceCompanyName { get; set; }
        public string Mod1 { get; set; }
        public string Mod2 { get; set; }
        public bool? IsBillable { get; set; }
        public string NonBillableComments { get; set; }
        public DateTime? ChargeNoteDate { get; set; }
        public string ChargeNote { get; set; }
        public string NoteCategoryName { get; set; }
        public string PatientAccountNumber { get; set; }
        public string ICNNumber { get; set; }
        public string PatientAccountNumberSecondary { get; set; }
        public string ICNNumberSecondary { get; set; }
        public string AssignedTo { get; set; }
        public string AssignedBy { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string PrimaryPolicyNo { get; set; }
        public string SecondaryInsuranceCompanyName { get; set; }
        public string SecondaryPolicyNo { get; set; }
        public bool InWriteOffQueue { get; set; }
        public string WriteOffRequestReasonCode { get; set; }
        public string WriteOffRequestComment { get; set; }
        public string WriteOffRequestStatus { get; set; }
        public DateTime WriteOffRequestDate { get; set; }
        public string WriteOffRequestBy { get; set; }
        public string WriteOffRequestReasonCodeDesc { get; set; }
        public string ICD1 { get; set; }
        public string ICD2 { get; set; }
        public string ICD3 { get; set; }
        public string ICD4 { get; set; }
        public DateTime WriteOffRequestModifiedDate { get; set; }
        public DateTime? PrimarySentDate { get; set; }
        public DateTime? SecondarySentDate { get; set; }
        public bool IsRejected { get; set; }
        public string RejectedPIN { get; set; }
        public int Qty { get; set; }
        public string POS { get; set; }
        public int? SecondaryInsuranceCompanyId { get; set; }
        public int PatientStatementCount { get; set; }
        public string PerformingProfessionalAbbreviation { get; set; }
        public string PrimaryPriorAuthorizationNumber { get; set; }
        public string SecondaryPriorAuthorizationNumber { get; set; }
        public int? ChargePrimaryCompanyId { get; set; }
        public int? ChargeSecondaryCompanyId { get; set; }
        public int? ChargeTertiaryCompanyId { get; set; }
        public string ChargePrimaryCompanyName { get; set; }
        public string ChargeSecondaryCompanyName { get; set; }
        public string ChargeTertiaryCompanyName { get; set; }
        public string ChargePrimaryCompanyType { get; set; }
        public string PrimaryCompanyType { get; set; }
        public string ChargeSecondaryCompanyType { get; set; }
        public string ChargeTertiaryCompanyType { get; set; }
        public bool? IsMedicaidCharge { get; set; }
        public bool ReviewNeeded { get; set; }
        public string ReviewComments { get; set; }
        public string RemarkCodes { get; set; }
        public string Remark1Desc { get; set; }
        public string Remark2Desc { get; set; }
        public string Remark3Desc { get; set; }
        public string Remark4Desc { get; set; }
        public string Solution { get; set; }
        [Ignore]
        public DateTime? LastNoteDate { get; set; }
        [Ignore]
        public string CategoryName { get; set; }
        [Ignore]
        public string ChargeNoteDateTemp { get; set; }
        [Ignore]
        public int ChargeInWriteOffId { get; set; }
        [Ignore]
        public string ProviderLicence { get; set; }


    }
}
