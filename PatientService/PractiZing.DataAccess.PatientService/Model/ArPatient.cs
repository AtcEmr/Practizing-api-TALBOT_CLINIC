using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Model.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Model
{
    public class ArPatient: IArPatient
    {
        //    public ArPatientBilling[] ArPatientBilling { get; set; }
        //}

        //public class ArPatientBilling
        //{
        public DateTime admissionDate { get; set; }
        public int patientId { get; set; }
        public int patientAddmissionId { get; set; }
        public int billingId { get; set; }        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string ssn { get; set; }
        public decimal? feeAmount { get; set; }
        public string MobilePhoneNumber { get; set; }
        public short patientBillTypeId { get; set; }
        public DateTime dateOfService { get; set; }
        public string BillingProviderFirstName { get; set; }
        public string BillingProviderLastName { get; set; }
        public string BillingProviderNPI { get; set; }
        public string RenderingProviderFirstName { get; set; }
        public string RenderingProviderLastName { get; set; }
        public string RenderingProviderNPI { get; set; }
        public string RenderingProviderSupervisorFirstName { get; set; }
        public string RenderingProviderSupervisorLastName { get; set; }
        public string RenderingProviderSupervisorNPI { get; set; }
        public string OrderingProviderFirstName { get; set; }
        public string OrderingProviderLastName { get; set; }
        public string OrderingProviderNPI { get; set; }
        public string OtherPlaceOfService { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int? encounterClacification { get; set; }
        public bool? isMentalHealth { get; set; }
        public bool? IsPrimaryCareNPI { get; set; }
        public Patientpolicy[] patientPolicy { get; set; }
        public Patientpolicyholder[] patientPolicyHolders { get; set; }
        public Guarantorpatientguarantor[] guarantorPatientGuarantors { get; set; }
        public Admissiondiagnosis[] admissionDiagnosis { get; set; }
        public Admissionprocedure[] admissionProcedures { get; set; }
        public IFacility1 billingFacility { get; set; }
        public IFacility1 performingFacility { get; set; }
        public IPlaceOfService placeOfService { get; set; }
        public ITypeOfService typeOfService { get; set; }
        IPatientpolicy[] IArPatient.patientPolicy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IPatientpolicyholder[] IArPatient.patientPolicyHolders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IGuarantorpatientguarantor[] IArPatient.guarantorPatientGuarantors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IAdmissiondiagnosis[] IArPatient.admissionDiagnosis { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IAdmissionprocedure[] IArPatient.admissionProcedures { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class Patientpolicy
    {
        public int id { get; set; }
        public int policyId { get; set; }
        public int patientId { get; set; }
        public int levelId { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public object medigap { get; set; }
        public Insurancepolicy insurancePolicy { get; set; }
        public Insurancepolicyholder insurancePolicyHolder { get; set; }
        public Insurancecompany insuranceCompany { get; set; }
        public List<PolicyAuthorizationNumberDTO> PolicyAuthorizationNumber { get; set; }
        public List<PatientDocumentsDTO> PatientDocuments { get; set; }
    }

    public class PolicyAuthorizationNumberDTO
    {
        public long Id { get; set; }
        public long PatientPolicyId { get; set; }
        public string AuthorizationNumber { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public short AuthorizationTypeId { get; set; }
        public DateTime? ReviewDate { get; set; }
    }

    public class PatientDocumentsDTO
    {
        public short Id { get; set; }
        public int PatientId { get; set; }
        public short DocTypeId { get; set; }
        public string DocTypeCode { get; set; }
        public string DocName { get; set; }
        public string Document { get; set; }
        public byte[] DocumentByte { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public bool IsPdf { get; set; }
        public bool IsFileUploaded { get; set; }
        public bool IsOtherDoc { get; set; }
        public long? PatientPolicyId { get; set; }
        public string DocTypeName { get; set; }
        public int? FormCategoryId { get; set; }
        public DateTime Date { get; set; }
    }

    public class Insurancepolicy
    {
        public string policyNumber { get; set; }
        public object contactPerson { get; set; }
        public string groupNumber { get; set; }
        public string groupName { get; set; }
        public DateTime planEffectiveDate { get; set; }
        public DateTime? planExpirationDate { get; set; }
        public int? planTypeId { get; set; }
        public object policyDeductible { get; set; }
        public int insuranceCompanyId { get; set; }
        public decimal? copay { get; set; }
        public object phSignatureOnFile { get; set; }
        public bool? acceptAssignment { get; set; }
        public object hL7UpdateFlag { get; set; }
        public object eligible { get; set; }
        public object medicareSecondaryId { get; set; }
        public int policyHolderId { get; set; }
        public int id { get; set; }
        public string medicaidId { get; set; }
    }

    public class Insurancepolicyholder
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string homePhone { get; set; }
        public object busPhone { get; set; }
        public object employerAddress1 { get; set; }
        public object employerAddress2 { get; set; }
        public object employerCity { get; set; }
        public object employerState { get; set; }
        public object employerZip { get; set; }
        public object employerPhone { get; set; }
        public object organizationName { get; set; }
        public object maritalStatus { get; set; }
        public object student { get; set; }
        public int genderId { get; set; }
        public int id { get; set; }
        public DateTime dob { get; set; }
        public virtual ICollection<PatientPolicyHolderDTO> PatientPolicyHolders { get; set; }
        public int phRelationId { get; set; }
    }

    public class PatientPolicyHolderDTO
    {

        public long Id { get; set; }

        public int PatientID { get; set; }

        public int PolicyHolderId { get; set; }

        public byte PHRelationId { get; set; }

        public bool? EmployeeStatus { get; set; }

    }

    public class Insurancecompany
    {
        public string code { get; set; }
        public string name { get; set; }
        public object address1 { get; set; }
        public object address2 { get; set; }
        public object city { get; set; }
        public object state { get; set; }
        public object zip { get; set; }
        public object phoneNumber { get; set; }
        public object pmsId { get; set; }
        public object externalId { get; set; }
        public bool medigap { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public bool transmitClaims { get; set; }
        public object clearingHouseId { get; set; }
        public short? typeId { get; set; }
        public object formTypeId { get; set; }
        public int id { get; set; }
        public bool inNetwork { get; set; }
        public bool gcodeAccepted { get; set; }
        public object companyType { get; set; }
    }

    public class Patientpolicyholder
    {
        public int id { get; set; }
        public int patientID { get; set; }
        public int policyHolderId { get; set; }
        public int phRelationId { get; set; }
        public object employeeStatus { get; set; }
        public object policyHolderRelation { get; set; }
    }

    public class Guarantorpatientguarantor
    {
        public int id { get; set; }
        public int patientId { get; set; }
        public int guarantorId { get; set; }
        public int relationId { get; set; }
        public Guarantorinsuranceguarantor guarantorInsuranceGuarantor { get; set; }
        public Relationpolicyholderrelation relationPolicyHolderRelation { get; set; }
    }

    public class Guarantorinsuranceguarantor
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string homePhone { get; set; }
        public string busPhone { get; set; }
        public object employerAddress1 { get; set; }
        public object employerAddress2 { get; set; }
        public object employerCity { get; set; }
        public object employerState { get; set; }
        public object employerZip { get; set; }
        public object employerPhone { get; set; }
        public object employmentStatus { get; set; }
        public string organizationName { get; set; }
        public object mobilePhone { get; set; }
        public object maritalStatusId { get; set; }
        public int? genderId { get; set; }
        public object preferedContactId { get; set; }
        public int id { get; set; }
        public string dob { get; set; }
        public object student { get; set; }
        public object preferedContactContactType { get; set; }
        public object gender { get; set; }
        public object maritalStatus { get; set; }
    }

    public class Relationpolicyholderrelation
    {
        public int id { get; set; }
        public string description { get; set; }
    }

    public class Admissiondiagnosis
    {
        public int id { get; set; }
        public int admissionId { get; set; }
        public int masterICD10Id { get; set; }
        public Mastericd10 masterIcd10 { get; set; }
        public int tempid { get; set; }
    }

    public class Mastericd10
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int? icdClassification { get; set; }
    }

    public class Admissionprocedure
    {
        public int id { get; set; }
        public int admissionId { get; set; }
        public string procedureCodeId { get; set; }
        public string primaryDxId { get; set; }
        public string dx2Id { get; set; }
        public string dx3Id { get; set; }
        public string dx4Id { get; set; }
        public int qty { get; set; }
        public object mod1Id { get; set; }
        public object mod2Id { get; set; }
        public object mod3Id { get; set; }
        public object mod4Id { get; set; }
        public string performingProviderId { get; set; }
        public object billingProviderId { get; set; }
        public DateTime? sentDate { get; set; }
    }

    public class EMRChargeStatus: IEMRChargeStatus
    {
        public int BillingId { get; set; }
        public int ChargeId { get; set; }
        public string ReasonsFromBillingSytem { get; set; }
        public int? ClaimId { get; set; }
        public DateTime? ClaimSentDate { get; set; }
        public double? ClaimAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public decimal? DueAmount { get; set; }
        public string DueBy { get; set; }
        public bool? HasDenial { get; set; }
        public string AdjustmentCode { get; set; }
        public string RemarkCode { get; set; }
    }

    public class PlaceOfService
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class TypeOfService
    {
        public string Code { get; set; }
        public string Descr { get; set; }
        public int Id { get; set; }
    }

    public class Facility1
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string NPI { get; set; }
        public string Code { get; set; }
    }



    public class IdentitiesDTO: IIdentitiesDTO
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class ProviderIdentitiesForBillingDTO: IProviderIdentitiesForBillingDTO
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }

        public short IdentityId { get; set; }

        public string Value { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public IIdentitiesDTO Identity { get; set; }
    }


    public class ProviderForBillingDTO: IProviderForBillingDTO
    {
        public ProviderForBillingDTO()
        {
            ProviderIdentities = new List<IProviderIdentitiesForBillingDTO>();
        }

        #region Generated Properties

        public int Id { get; set; }

        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string MiddleName { get; set; }


        public string LastName { get; set; }

        public string Suffix { get; set; }


        public string Address1 { get; set; }

        public string Address2 { get; set; }


        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public DateTime? DOB { get; set; }

        public string PrimaryPhone { get; set; }

        public int? PrimaryPhoneType { get; set; }

        public string PracticeName { get; set; }

        public bool Active { get; set; }

        public string Degree { get; set; }

        public string Comments { get; set; }

        public string ClinicianId { get; set; }

        public int? UserId { get; set; }

        public int? SupervisorId { get; set; }

        public bool? IsOptedForGroupBilling { get; set; } = false;

        public bool CanBill { get; set; }

        public string PrimaryFax { get; set; }

        public string NPI { get; set; }

        public string SSN { get; set; }
        public bool IsLocked { get; set; }

        public short? SupervisorTypeId { get; set; }

        public bool? BillUnderSupervisor { get; set; }

        public long? CircumstanceId { get; set; }

        public int? PractitonerModifierId { get; set; }
        public bool IsClinical { get; set; }
        public string DEA { get; set; }

        public bool IsNeedDosepot { get; set; }
        public bool IsDefaultClinician { get; set; }

        public bool? IsDiagnosisEvaluation { get; set; }

        public bool IsTestProvider { get; set; }
        #endregion

        #region Generated Relationships


        public List<IProviderIdentitiesForBillingDTO> ProviderIdentities { get; set; }

        #endregion
    }

    public class FacilityIdentitiesDTO: IFacilityIdentitiesDTO
    {
        public int Id { get; set; }
        public short FacilityId { get; set; }
        public short IdentityId { get; set; }
        public string Value { get; set; }
        public DateTime ActiveDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IIdentitiesDTO Identity { get; set; }
    }

    public class FacilityForBillingDTO: IFacilityForBillingDTO
    {
        public FacilityForBillingDTO()
        {
            FacilityIdentities = new List<IFacilityIdentitiesDTO>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public int? LocationId { get; set; }
        public string FacilityCode { get; set; }
        public string FacilityDescription { get; set; }
        public string Fax { get; set; }
        public string PosCode { get; set; }
        public string LocationCode { get; set; }
        public string NPI { get; set; }
        public string SUDNPI { get; set; }
        public string TIN { get; set; }
        public string TimeZone { get; set; }
        public string ServiceTypeCode { get; set; }
        public int? PMFacilityId { get; set; }
        public string Locality { get; set; }
        public short? FeeScheduleCarrierNumber { get; set; }
        public short? FeeLocalCarrNumId { get; set; }
        public bool? IsDefaultLocation { get; set; }
        public int? DefaultProviderId { get; set; }
        public string LIMSCode { get; set; }
        public List<IFacilityIdentitiesDTO> FacilityIdentities { get; set; }
    }

    public class InsurancePolicyDTO
    {
        public string PolicyNumber { get; set; }
        public string ContactPerson { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public DateTime PlanEffectiveDate { get; set; }
        public DateTime? PlanExpirationDate { get; set; }
        public byte? PlanTypeId { get; set; }
        public string PolicyDeductible { get; set; }
        public int InsuranceCompanyId { get; set; }
        //public byte LevelId { get; set; }
        public decimal? Copay { get; set; }
        public bool? PHSignatureOnFile { get; set; }
        public bool? AcceptAssignment { get; set; }
        public bool? HL7UpdateFlag { get; set; }
        public bool? Eligible { get; set; }
        public bool HaveInsurance { get; set; }
        //public bool? Medigap { get; set; } 
        public short? MedicareSecondaryId { get; set; }
        public int? PolicyHolderId { get; set; }
        public long Id { get; set; }
        public string MedicaidId { get; set; }
        public string BillingPolicyId { get; set; }
        public virtual Insurancepolicyholder InsurancePolicyHolder { get; set; }
        public virtual ICollection<Patientpolicy> PatientPolicy { get; set; }
        public virtual InsuranceMedicareSecondaryDTO InsuranceMedicareSecondary { get; set; }
        public virtual PlanTypeDTO PlanType { get; set; }
    }

    public class InsuranceMedicareSecondaryDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }

    public class PlanTypeDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }

    public class SyncPatientDetailDTO: ISyncPatientDetailDTO
    {
        public int Id { get; set; }
        public DateTime DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NicknameAc { get; set; }
        public string MI { get; set; }
        public string MaidenName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string SSN { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }
    }
}
