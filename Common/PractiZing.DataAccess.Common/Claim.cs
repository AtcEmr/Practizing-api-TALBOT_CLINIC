using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.Common
{
    public class Claim : IClaim
    {
        public Claim()
        {
            this.InsuranceServices = new List<Charges>();
            this.InvDiagnoses = new List<InvDiagnosis>();
            this.ScrubErrors = new List<ScrubError>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int PracticeId { get; set; }
        public Guid UId { get; set; }

        public short? InsLevel { get; set; }

        [Ignore]
        public string InsuranceLevel
        {
            get
            {
                return this.InsLevel == 1 ? "Primary" :(this.InsLevel == 2? "Secondary": "Tertiory") ;
            }
        }

        public int InsuranceCompanyId { get; set; }
        public int InvoiceId { get; set; }
        public short? CarrierTypeId { get; set; }
        public string PayerName { get; set; }
        public short? CaseTypeId { get; set; }
        public short? FormTypeId { get; set; }
        public short? MaxServices { get; set; }
        public int PatientCaseId { get; set; }
        [MaxLength(15, ErrorMessage = "CaseIdNumber -Must not enter more than 15 characters.")]
        public string CaseIdNumber { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int VisitNo { get; set; }
        public short? Frequency { get; set; }
        public double TotalBilled { get; set; }

        [MaxLength(35, ErrorMessage = "ClaimToAddress1 -Must not enter more than 35 characters.")]
        public string ClaimToAddress1 { get; set; }
        [MaxLength(30, ErrorMessage = "ClaimToAddress2 -Must not enter more than 30 characters.")]
        public string ClaimToAddress2 { get; set; }
        [MaxLength(30, ErrorMessage = "ClaimToCity -Must not enter more than 30 characters.")]
        public string ClaimToCity { get; set; }
        [MaxLength(35, ErrorMessage = "ClaimToState -Must not enter more than 15 characters.")]
        public string ClaimToState { get; set; }
        [MaxLength(60, ErrorMessage = "ClaimToZip -Must not enter more than 60 characters.")]
        public string ClaimToZip { get; set; }
        public short? ClaimType { get; set; }

        [MaxLength(2, ErrorMessage = "InsuranceType -Must not enter more than 2 characters.")]
        public string InsuranceType { get; set; }
        [MaxLength(2, ErrorMessage = "Filling Code -Must not enter more than 2 characters.")]
        public string FillingCode { get; set; }
        
        
        [MaxLength(28, ErrorMessage = "PatientName -Must not enter more than 28 characters.")]
        public string PatientName { get; set; }
        [MaxLength(50, ErrorMessage = "PatientFirstName -Must not enter more than 50 characters.")]
        public string PatientFirstName { get; set; }
        [MaxLength(50, ErrorMessage = "PatientLastName -Must not enter more than 50 characters.")]
        public string PatientLastName { get; set; }
        [MaxLength(50, ErrorMessage = "PatientMiddleName -Must not enter more than 50 characters.")]
        public string PatientMiddleName { get; set; }
        [MaxLength(50, ErrorMessage = "PatientGender -Must not enter more than 50 characters.")]
        public string PatientGender { get; set; }
        [MaxLength(55, ErrorMessage = "Patient Street -Must not enter more than 28 characters.")]
        public string PatientStreet { get; set; }
        public string PatientCity { get; set; }
        [MaxLength(2, ErrorMessage = "Patient State -Must not enter more than 2 characters.")]
        public string PatientState { get; set; }
        [MaxLength(10, ErrorMessage = "PatientZip -Must not enter more than 10 characters.")]
        public string PatientZip { get; set; }
        [MaxLength(13, ErrorMessage = "Patient Phone -Must not enter more than 13 characters.")]
        public string PatientPhone { get; set; }
        [MaxLength(50, ErrorMessage = "PatientAreaCode -Must not enter more than 50 characters.")]
        public string PatientAreaCode { get; set; }
        public DateTime? PatientDOB { get; set; }

        public short? PolicyHolderRelation { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Policy Number is required.")]
        [MaxLength(28, ErrorMessage = "PolicyNo -Must not enter more than 28 characters.")]
        public string PolicyNo { get; set; }
        [MaxLength(28, ErrorMessage = "PolicyHolderName -Must not enter more than 28 characters.")]
        public string PolicyHolderName { get; set; }

        //[MaxLength(28, ErrorMessage = "Policy Holder Address1 with Address2 -Must not enter more than 28 characters.")]
        public string PolicyHolderStreet { get; set; }
        [MaxLength(25, ErrorMessage = "PolicyHolderCity -Must not enter more than 25 characters.")]
        public string PolicyHolderCity { get; set; }
        [MaxLength(2, ErrorMessage = "Policy Holder State -Must not enter more than 2 characters.")]
        public string PolicyHolderState { get; set; }
        [MaxLength(10, ErrorMessage = "PolicyHolderZip -Must not enter more than 10 characters.")]
        public string PolicyHolderZip { get; set; }
        [MaxLength(13, ErrorMessage = "PolicyHolderPhone -Must not enter more than 13 characters.")]
        public string PolicyHolderPhone { get; set; }
        [MaxLength(50, ErrorMessage = "PolicyHolderAreaCode -Must not enter more than 50 characters.")]
        public string PolicyHolderAreaCode { get; set; }
        [MaxLength(28, ErrorMessage = "PolicyHolderGroupNo -Must not enter more than 28 characters.")]
        public string PolicyHolderGroupNo { get; set; }
        public DateTime? PolicyHolderDOB { get; set; }
        public short? PolicyHolderSex { get; set; }
        [MaxLength(28, ErrorMessage = "PolicyHolderEmpl -Must not enter more than 28 characters.")]
        public string PolicyHolderEmpl { get; set; }
        [MaxLength(28, ErrorMessage = "PolicyInsurancePlanName -Must not enter more than 28 characters.")]
        public string PolicyInsurancePlanName { get; set; }

        public bool HasAnotherPlan { get; set; }



        [MaxLength(2, ErrorMessage = "Other Ins Type -Must not enter more than 2 characters.")]
        public string OtherInsType { get; set; }
        [MaxLength(2, ErrorMessage = "Other Ins Filling Code -Must not enter more than 2 characters.")]
        public string OtherInsFillingCode { get; set; }
        public int OtherInsCompanyId { get; set; }
        public short? OtherPolicyHolderRelation { get; set; }
        [MaxLength(28, ErrorMessage = "OtherPolicyHolderName -Must not enter more than 28 characters.")]
        public string OtherPolicyHolderName { get; set; }
        [MaxLength(20, ErrorMessage = "OtherPolicyNo -Must not enter more than 20 characters.")]
        public string OtherPolicyNo { get; set; }
        [MaxLength(28, ErrorMessage = "OtherPolicyHolderGroupNo -Must not enter more than 28 characters.")]
        public string OtherPolicyHolderGroupNo { get; set; }
        [MaxLength(28, ErrorMessage = "Other Policy Holder Street -Must not enter more than 28 characters.")]
        public string OtherPolicyHolderStreet { get; set; }
        [MaxLength(30, ErrorMessage = "OtherPolicyHolderCity -Must not enter more than 25 characters.")]
        public string OtherPolicyHolderCity { get; set; }
        [MaxLength(2, ErrorMessage = "Other Policy Holder state -Must not enter more than 2 characters.")]
        public string OtherPolicyHolderState { get; set; }
        [MaxLength(10, ErrorMessage = "OtherPolicyHolderZip -Must not enter more than 10 characters.")]
        public string OtherPolicyHolderZip { get; set; }
        public DateTime? OtherPolicyHolderDOB { get; set; }
        public short? OtherPolicyHolderSex { get; set; }
        [MaxLength(28, ErrorMessage = "OtherPolicyHolderEmpl -Must not enter more than 15 characters.")]
        public string OtherPolicyHolderEmpl { get; set; }
        [MaxLength(28, ErrorMessage = "OtherPolicyInsurancePlanName -Must not enter more than 20 characters.")]
        public string OtherPolicyInsurancePlanName { get; set; }
        public string OtherCompanyCode { get; set; }
        public string OtherPayerName { get; set; }
        public string OtherPolicyHolderSignature { get; set; }
        public string OtherPatientSignatureOnFile { get; set; }



        
        [MaxLength(2, ErrorMessage = "Other Ins Type -Must not enter more than 2 characters.")]
        public string Other2InsType { get; set; }
        [MaxLength(2, ErrorMessage = "Other Ins Filling Code -Must not enter more than 2 characters.")]
        public string Other2InsFillingCode { get; set; }
        public int Other2InsCompanyId { get; set; }
        public short? Other2PolicyHolderRelation { get; set; }
        [MaxLength(28, ErrorMessage = "OtherPolicyHolderName -Must not enter more than 28 characters.")]
        public string Other2PolicyHolderName { get; set; }
        [MaxLength(20, ErrorMessage = "OtherPolicyNo -Must not enter more than 20 characters.")]
        public string Other2PolicyNo { get; set; }
        [MaxLength(28, ErrorMessage = "OtherPolicyHolderGroupNo -Must not enter more than 28 characters.")]
        public string Other2PolicyHolderGroupNo { get; set; }
        [MaxLength(28, ErrorMessage = "Other Policy Holder Street -Must not enter more than 28 characters.")]
        public string Other2PolicyHolderStreet { get; set; }
        [MaxLength(25, ErrorMessage = "OtherPolicyHolderCity -Must not enter more than 25 characters.")]
        public string Other2PolicyHolderCity { get; set; }
        [MaxLength(2, ErrorMessage = "Other Policy Holder state -Must not enter more than 2 characters.")]
        public string Other2PolicyHolderState { get; set; }
        [MaxLength(10, ErrorMessage = "OtherPolicyHolderZip -Must not enter more than 10 characters.")]
        public string Other2PolicyHolderZip { get; set; }
        public DateTime? Other2PolicyHolderDOB { get; set; }
        public short? Other2PolicyHolderSex { get; set; }
        [MaxLength(28, ErrorMessage = "OtherPolicyHolderEmpl -Must not enter more than 15 characters.")]
        public string Other2PolicyHolderEmpl { get; set; }
        [MaxLength(20, ErrorMessage = "Other2PolicyInsurancePlanName -Must not enter more than 20 characters.")]
        public string Other2PolicyInsurancePlanName { get; set; }
        public string Other2CompanyCode { get; set; }
        public string Other2PayerName { get; set; }
        public string Other2PolicyHolderSignature { get; set; }
        public string Other2PatientSignatureOnFile { get; set; }
        



        [MaxLength(28, ErrorMessage = "Box10Value -Must not enter more than 28 characters.")]
        public string Box10Value { get; set; }
        public DateTime? PatientSignatureDate { get; set; }
        [MaxLength(25, ErrorMessage = "PolicyHolderSignature -Must not enter more than 25 characters.")]
        public string PolicyHolderSignature { get; set; }

        [MaxLength(50, ErrorMessage = "FederalTaxIDNumber -Must not enter more than 50 characters.")]
        public string FederalTaxIDNumber { get; set; }

        public short? ReferringPhyId { get; set; }
        [MaxLength(27, ErrorMessage = "ReferringPhyName -Must not enter more than 27 characters.")]
        public string ReferringPhyName { get; set; }
        [MaxLength(50, ErrorMessage = "ReferringPhyFirstName -Must not enter more than 50 characters.")]
        public string ReferringPhyFirstName { get; set; }
        [MaxLength(50, ErrorMessage = "ReferringPhyLastName -Must not enter more than 50 characters.")]
        public string ReferringPhyLastName { get; set; }
        [Ignore]
        public string ReferringPhyQualifier { get; set; }
        [MaxLength(2, ErrorMessage = "Billing Doctor Id Prefix -Must not enter more than 2 characters.")]
        public string BillingDoctorIDPrefix { get; set; }
        [MaxLength(16, ErrorMessage = "PhysicianIdOrAutoNo -Must not enter more than 16 characters.")]
        public string PhysicianIdOrAuthNo { get; set; }
        [MaxLength(10, ErrorMessage = "ReferringPhysicianNpi -Must not enter more than 10 characters.")]
        public string ReferringPhysicianNpi { get; set; }
        [MaxLength(48, ErrorMessage = "Reserved19 -Must not enter more than 48 characters.")]
        public string RESERVED19 { get; set; }
        public bool? ShowCPTDescripton { get; set; }
        [MaxLength(11, ErrorMessage = "MedicaidResubmissionCode -Must not enter more than 11 characters.")]
        public string MedicaidResubmissionCode { get; set; }
        [MaxLength(18, ErrorMessage = "OriginalReferenceNumber -Must not enter more than 18 characters.")]
        public string OriginalReferenceNumber { get; set; }
        [MaxLength(28, ErrorMessage = "PriorAuthorizationNumber -Must not enter more than 28 characters.")]
        public string PriorAuthorizationNumber { get; set; }
        public bool AcceptAssignment { get; set; }
        [MaxLength(21, ErrorMessage = "PhysicianSignature -Must not enter more than 21 characters.")]
        public string PhysicianSignature { get; set; }
        public DateTime? SentDate { get; set; }
        [MaxLength(14, ErrorMessage = "BillingFacilityId -Must not enter more than 14 characters.")]
        public string BillingFacilityId { get; set; }
        [MaxLength(13, ErrorMessage = "BillingDoctorPhone -Must not enter more than 13 characters.")]
        public string BillingDoctorPhone { get; set; }
        [MaxLength(50, ErrorMessage = "BillingDoctorAreaCode -Must not enter more than 50 characters.")]
        public string BillingDoctorAreaCode { get; set; }
        [MaxLength(30, ErrorMessage = "BillingDoctorName -Must not enter more than 30 characters.")]
        public string BillingDoctorName { get; set; }
        [MaxLength(30, ErrorMessage = "BillingDoctorAddressLine1 -Must not enter more than 30 characters.")]
        public string BillingDoctorAddressLine1 { get; set; }
        [MaxLength(30, ErrorMessage = "BillingDoctorAddressLine2 -Must not enter more than 30 characters.")]
        public string BillingDoctorAddressLine2 { get; set; }
        [MaxLength(50, ErrorMessage = "BillingDoctorFax -Must not enter more than 50 characters.")]
        public string BillingDoctorFax { get; set; }
        [MaxLength(30, ErrorMessage = "BillingDoctorCity -Must not enter more than 30 characters.")]
        public string BillingDoctorCity { get; set; }
        [MaxLength(30, ErrorMessage = "BillingDoctorState -Must not enter more than 30 characters.")]
        public string BillingDoctorState { get; set; }
        [MaxLength(30, ErrorMessage = "BillingDoctorZip -Must not enter more than 30 characters.")]
        public string BillingDoctorZip { get; set; }
        [MaxLength(15, ErrorMessage = "BillingFacilityNPI -Must not enter more than 15 characters.")]
        public string BillingFacilityNPI { get; set; }
        [MaxLength(2, ErrorMessage = "Billing Facility Id Qualifier -Must not enter more than 2 characters.")]
        public string BillingFacilityIDQualifier { get; set; }
        [MaxLength(15, ErrorMessage = "GRP -Must not enter more than 15 characters.")]
        public string GRP { get; set; }
        public short? ClearingHouseId { get; set; }
        [MaxLength(1, ErrorMessage = "Should be printed -Must not enter more than 2 characters.")]
        public string ShouldBePrinted { get; set; }
        [MaxLength(1, ErrorMessage = "Can be sent Electronically -Must not enter more than 2 characters.")]
        public string CanBeSentElectronically { get; set; }
        [MaxLength(15, ErrorMessage = "Status -Must not enter more than 15 characters.")]
        public string Status { get; set; }
        public int? ClaimBatchId { get; set; }
        public int FLAGS { get; set; }

        [MaxLength(50, ErrorMessage = "HoldBy -Must not enter more than 50 characters.")]
        public string HoldBy { get; set; }
        public DateTime? HoldDate { get; set; }
        [MaxLength(200, ErrorMessage = "HoldComment -Must not enter more than 200 characters.")]
        public string HoldComment { get; set; }

        [MaxLength(50, ErrorMessage = "ReleaseBy -Must not enter more than 50 characters.")]
        public string ReleaseBy { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [MaxLength(200, ErrorMessage = "ReleaseComment -Must not enter more than 200 characters.")]
        public string ReleaseComment { get; set; }

        public short? SupervisingPhysID { get; set; }
        public short? OrderingProviderId { get; set; }
        [MaxLength(50, ErrorMessage = "FacilityId -Must not enter more than 50 characters.")]
        public string FacilityId { get; set; }
        [Ignore]
        public bool? IsAuto { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
        [MaxLength(13, ErrorMessage = "PerformingDoctorPhone -Must not enter more than 13 characters.")]
        public string PerformingDoctorPhone { get; set; }
        [MaxLength(30, ErrorMessage = "PerformingDoctorName -Must not enter more than 30 characters.")]
        public string PerformingDoctorName { get; set; }
        [MaxLength(30, ErrorMessage = "PerformingDoctorAddressLine1 -Must not enter more than 30 characters.")]
        public string PerformingDoctorAddressLine1 { get; set; }
        [MaxLength(30, ErrorMessage = "PerformingDoctorAddressLine2 -Must not enter more than 30 characters.")]
        public string PerformingDoctorAddressLine2 { get; set; }
        [MaxLength(30, ErrorMessage = "PerformingDoctorCity -Must not enter more than 30 characters.")]
        public string PerformingDoctorCity { get; set; }
        [MaxLength(30, ErrorMessage = "PerformingDoctorState -Must not enter more than 30 characters.")]
        public string PerformingDoctorState { get; set; }
        [MaxLength(30, ErrorMessage = "PerformingDoctorZip -Must not enter more than 30 characters.")]
        public string PerformingDoctorZip { get; set; }
        [MaxLength(15, ErrorMessage = "PerformingFacilityNPI -Must not enter more than 15 characters.")]
        public string PerformingFacilityNPI { get; set; }
        [MaxLength(2, ErrorMessage = "Performing Facility Id Qualifier -Must not enter more than 2 characters.")]
        public string PerformingFacilityIDQualifier { get; set; }
        [Ignore]
        public int Count { get; set; }
        [Ignore]
        public int BatchStatus { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(30, ErrorMessage = "TaxonomyCode -Must not enter more than 30 characters.")]
        public string TaxonomyCode { get; set; }

        public DateTime? CurrentIllnesDate { get; set; }
        public DateTime? OtherIllnesDate { get; set; }
        public DateTime? UnableToWorkFrom { get; set; }
        public DateTime? UnableToWorkTo { get; set; }
        public DateTime? HospitalizationFrom { get; set; }
        public DateTime? HospitalizationTo { get; set; }
        [MaxLength(70, ErrorMessage = "DiagnosisCodes -Must not enter more than 50 characters.")]
        public string DiagnosisCodes { get; set; }
        [MaxLength(50, ErrorMessage = "PatientSignatureOnFile -Must not enter more than 50 characters.")]
        public string PatientSignatureOnFile { get; set; }
        [MaxLength(50, ErrorMessage = "InsuranceSignatureOnFile -Must not enter more than 50 characters.")]
        public string InsuranceSignatureOnFile { get; set; }
        [MaxLength(50, ErrorMessage = "BillTypeCode -Must not enter more than 50 characters.")]
        public string BillTypeCode { get; set; }
        public bool AccEmploy { get; set; }
        public bool AccAuto { get; set; }
        public bool AccOther { get; set; }
        public string AccState { get; set; }
        public string GroupNPI { get; set; }
        [Ignore]
        public IClaimTotal ClaimTotal { get; set; }
        [Ignore]
        public IEnumerable<ICharges> InsuranceServices { get; set; }
        [Ignore]
        public IEnumerable<IInvDiagnosis> InvDiagnoses { get; set; }
        [Ignore]
        public IEnumerable<IScrubError> ScrubErrors { get; set; }
        [Ignore]
        public string ClearingHouse { get; set; }
        [Ignore]
        public string Carrier { get; set; }
        [Ignore]
        public string FormType { get; set; }

        [Ignore]
        public string BillingId { get; set; }

        [MaxLength(50, ErrorMessage = "CaseIdNumber -Must not enter more than 15 characters.")]
        public string AccessionNumber { get; set; }

        [Ignore]
        public string CarrierType { get; set; }

        [Ignore]
        public DateTime DateOfService { get; set; }

        [Ignore]
        public int StatusOfBatch { get; set; }
        //[Ignore]
        //public string ClaimStatus { get; set; }
        [MaxLength(28, ErrorMessage = "Policy Holder Street -Must not enter more than 28 characters.")]
        public string PolicyHolderAddress1 { get; set; }

        [MaxLength(28, ErrorMessage = "Policy Holder Street -Must not enter more than 28 characters.")]
        public string PolicyHolderAddress2 { get; set; }

        [MaxLength(28, ErrorMessage = "InsuranceCompanyCode")]
        public string InsuranceCompanyCode { get; set; }

        [MaxLength(28, ErrorMessage = "PatientAccountNumber")]
        public string PatientAccountNumber { get; set; }

        public bool? IsCliaNumber { get; set; }

        [MaxLength(28, ErrorMessage = "BillingDoctorFirstName")]
        public string BillingDoctorFirstName { get; set; }

        [MaxLength(28, ErrorMessage = "BillingDoctorLastName")]
        public string BillingDoctorLastName { get; set; }

        [MaxLength(28, ErrorMessage = "BillingDoctorMiddleName")]
        public string BillingDoctorMiddleName { get; set; }

        public int? PerformingDoctorId { get; set; }

        [Ignore]
        public bool? IsUpdated { get; set; }

        public short? Box32FacilityId { get; set; }

        public string Box32FacilityAddress1 { get; set; }

        public string Box32FacilityAddress2 { get; set; }

        public string Box32FacilityCity { get; set; }

        public string Box32FacilityState { get; set; }

        public string Box32FacilityZip { get; set; }

        public string ReferringPhyMI { get; set; }
        public string ReferringPhySuffix { get; set; }

        public bool? IsLoop2420E { get; set; }

        public bool? IsLoop2420DRequired { get; set; }

        public string BillingProviderFacilityName { get; set; }

        public string POSCode { get; set; }

        public string ReferCliaNumber { get; set; }

        public string PatientControlNumber { get; set; }

        [Ignore]
        public Guid PatientUId { get; set; }

        public string PolicyGroupNumber { get; set; }

        public string PolicyGroupName { get; set; }

        public bool? IsRefProviderAndRendProviderSame { get; set; }
        public int? ScrubStatus { get; set; }
        
        [MaxLength(28, ErrorMessage = "SupervisionDoctorFirstName")]
        public string SupervisionDoctorFirstName { get; set; }

        [MaxLength(28, ErrorMessage = "SupervisionDoctorLastName")]
        public string SupervisionDoctorLastName { get; set; }

        [MaxLength(28, ErrorMessage = "SupervisionDoctorMiddleName")]
        public string SupervisionDoctorMiddleName { get; set; }
        [MaxLength(2, ErrorMessage = "Supervision Doctor Id Prefix -Must not enter more than 2 characters.")]
        public string SupervisionDoctorPrefix { get; set; }
        public string SupervisionDoctorSuffix { get; set; }
        public string SupervisionDoctorNPI { get; set; }




        [MaxLength(28, ErrorMessage = "OrderingDoctorFirstName")]
        public string OrderingDoctorFirstName { get; set; }

        [MaxLength(28, ErrorMessage = "OrderingDoctorLastName")]
        public string OrderingDoctorLastName { get; set; }

        [MaxLength(28, ErrorMessage = "OrderingDoctorMiddleName")]
        public string OrderingDoctorMiddleName { get; set; }
        [MaxLength(2, ErrorMessage = "OrderingDoctorPrefixId Prefix -Must not enter more than 2 characters.")]
        public string OrderingDoctorPrefix { get; set; }
        public string OrderingDoctorSuffix { get; set; }
        public string OrderingDoctorNPI { get; set; }








        public bool? IsLoop2310DRequired { get; set; }
        public bool? IsLoop2420ARequired { get; set; }
        

        public string PerformingLocationName { get; set; }
        public string PerformingLocationAddressLine1 { get; set; }
        public string PerformingLocationAddressLine2 { get; set; }
        public string PerformingLocationCity { get; set; }
        public string PerformingLocationState { get; set; }
        public string PerformingLocationZIP { get; set; }
        public string PerformingLocationPhone { get; set; }

        public string PerformingDoctorFirstName { get; set; }
        public string PerformingDoctorLastName { get; set; }
        public string PerformingDoctorMiddleName { get; set; }
        public string PerformingDoctorNPI { get; set; }
        public string PerformingProviderTaxonomy { get; set; }
        public bool? IsSendAck { get; set; }
        public DateTime? SendAckDate { get; set; }

        public int? MedicaidClearingHouseId { get; set; }
        public string MedicaidPayerId { get; set; }
        public string MedicaidPayerReceiverId { get; set; }

        public bool? IsMedicaidAttachment { get; set; }
        public string AttachmentControlNumber { get; set; }
        public Int64? TransactionNumber { get; set; }
        public string TransactionStatus { get; set; }

        [Ignore]
        public string SecondaryPayerName { get; set; }
        [Ignore]
        public string SecondaryInsuranceCompanyCode { get; set; }
        [Ignore]
        public string SecondaryPolicyHolderStreet { get; set; }
        [Ignore]
        public string SecondaryPolicyHolderCity { get; set; }
        [Ignore]
        public string SecondaryPolicyHolderState { get; set; }
        [Ignore]
        public string SecondaryPolicyHolderZip { get; set; }
        [Ignore]
        public string SecondaryPolicyHolderName { get; set; }
        [Ignore]
        public string SecondaryPolicyNo { get; set; }
        [Ignore]
        public short? SecondaryPolicyHolderRelation { get; set; }
        [Ignore]
        public string SecondaryInsuranceType { get; set; }
        [Ignore]
        public string SecondaryFillingCode { get; set; }
        [Ignore]
        public string SecondaryPolicyHolderGroupNo { get; set; }
        [Ignore]
        public string SecondaryPolicyHolderSignature { get; set; }
        [Ignore]
        public string SecondaryPatientSignatureOnFile { get; set; }
        [Ignore]
        public string InsuranceCompanyType { get; set; }

    }
}
