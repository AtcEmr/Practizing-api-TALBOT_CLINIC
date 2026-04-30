using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IArPatient
    {   
        int patientId { get; set; }
        int patientAddmissionId { get; set; }
        int billingId { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string dob { get; set; }
        string gender { get; set; }
        string address1 { get; set; }
        string address2 { get; set; }
        string city { get; set; }
        string state { get; set; }
        string zipCode { get; set; }
        string ssn { get; set; }
        decimal? feeAmount { get; set; }
        string MobilePhoneNumber { get; set; }
        short patientBillTypeId { get; set; }
        DateTime dateOfService { get; set; }
        DateTime admissionDate { get; set; }
        DateTime? startDate { get; set; }
        DateTime? endDate { get; set; }
        string BillingProviderFirstName { get; set; }
        string BillingProviderLastName { get; set; }
        string BillingProviderNPI { get; set; }
        string RenderingProviderFirstName { get; set; }
        string RenderingProviderLastName { get; set; }
        string RenderingProviderNPI { get; set; }
        string RenderingProviderSupervisorFirstName { get; set; }
        string RenderingProviderSupervisorLastName { get; set; }
        string RenderingProviderSupervisorNPI { get; set; }
        IPatientpolicy[] patientPolicy { get; set; }
        IPatientpolicyholder[] patientPolicyHolders { get; set; }
        IGuarantorpatientguarantor[] guarantorPatientGuarantors { get; set; }
        IAdmissiondiagnosis[] admissionDiagnosis { get; set; }
        IAdmissionprocedure[] admissionProcedures { get; set; }
        IFacility1 billingFacility { get; set; }
        IFacility1 performingFacility { get; set; }
        IPlaceOfService placeOfService { get; set; }
        ITypeOfService typeOfService { get; set; }
        int? encounterClacification { get; set; }
        bool? isMentalHealth { get; set; }
        string OrderingProviderFirstName { get; set; }
        string OrderingProviderLastName { get; set; }
        string OrderingProviderNPI { get; set; }
        bool? IsPrimaryCareNPI { get; set; }
        string OtherPlaceOfService { get; set; }
    }

    public class IPlaceOfService
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ITypeOfService
    {
        public string Code { get; set; }
        public string Descr { get; set; }
        public int Id { get; set; }
    }

    public class IFacility1
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string NPI { get; set; }
        public string Code { get; set; }
    }

    public class IPatientpolicy
    {
        public int id { get; set; }
        public int policyId { get; set; }
        public int patientId { get; set; }
        public int levelId { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        public object medigap { get; set; }
        public IInsurancepolicy insurancePolicy { get; set; }
        public IInsurancepolicyholder insurancePolicyHolder { get; set; }
        public IInsurancecompany insuranceCompany { get; set; }
    }

    public class IInsurancepolicy
    {
        public string policyNumber { get; set; }
        public object contactPerson { get; set; }
        public string groupNumber { get; set; }
        public object groupName { get; set; }
        public DateTime planEffectiveDate { get; set; }
        public object planExpirationDate { get; set; }
        public int planTypeId { get; set; }
        public object policyDeductible { get; set; }
        public int insuranceCompanyId { get; set; }
        public decimal? copay { get; set; }
        public object phSignatureOnFile { get; set; }
        public bool acceptAssignment { get; set; }
        public object hL7UpdateFlag { get; set; }
        public object eligible { get; set; }
        public object medicareSecondaryId { get; set; }
        public int policyHolderId { get; set; }
        public int id { get; set; }
    }

    public class IInsurancepolicyholder
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
    }

    public class IInsurancecompany
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
        public int typeId { get; set; }
        public object formTypeId { get; set; }
        public int id { get; set; }
        public bool inNetwork { get; set; }
        public bool gcodeAccepted { get; set; }
        public object companyType { get; set; }
    }

    public class IPatientpolicyholder
    {
        public int id { get; set; }
        public int patientID { get; set; }
        public int policyHolderId { get; set; }
        public int phRelationId { get; set; }
        public object employeeStatus { get; set; }
        public object policyHolderRelation { get; set; }
    }

    public class IGuarantorpatientguarantor
    {
        public int id { get; set; }
        public int patientId { get; set; }
        public int guarantorId { get; set; }
        public int relationId { get; set; }
        public IGuarantorinsuranceguarantor guarantorInsuranceGuarantor { get; set; }
        public IRelationpolicyholderrelation relationPolicyHolderRelation { get; set; }
    }

    public class IGuarantorinsuranceguarantor
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public object homePhone { get; set; }
        public object busPhone { get; set; }
        public object employerAddress1 { get; set; }
        public object employerAddress2 { get; set; }
        public object employerCity { get; set; }
        public object employerState { get; set; }
        public object employerZip { get; set; }
        public object employerPhone { get; set; }
        public object employmentStatus { get; set; }
        public object organizationName { get; set; }
        public object mobilePhone { get; set; }
        public object maritalStatusId { get; set; }
        public int genderId { get; set; }
        public object preferedContactId { get; set; }
        public int id { get; set; }
        public DateTime dob { get; set; }
        public object student { get; set; }
        public object preferedContactContactType { get; set; }
        public object gender { get; set; }
        public object maritalStatus { get; set; }
    }

    public class IRelationpolicyholderrelation
    {
        public int id { get; set; }
        public string description { get; set; }
    }

    public class IAdmissiondiagnosis
    {
        public int id { get; set; }
        public int admissionId { get; set; }
        public int masterICD10Id { get; set; }
        public IMastericd10 masterIcd10 { get; set; }
    }

    public class IMastericd10
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class IAdmissionprocedure
    {
        public int id { get; set; }
        public int admissionId { get; set; }
        public string procedureCodeId { get; set; }
        public string primaryDxId { get; set; }
        public object dx2Id { get; set; }
        public object dx3Id { get; set; }
        public object dx4Id { get; set; }
        public int qty { get; set; }
        public object mod1Id { get; set; }
        public object mod2Id { get; set; }
        public object mod3Id { get; set; }
        public object mod4Id { get; set; }
        public string performingProviderId { get; set; }
        public object billingProviderId { get; set; }
        public DateTime sentDate { get; set; }
    }


    public interface IIdentitiesDTO
    {
        short Id { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        bool Active { get; set; }
    }

    public interface IProviderIdentitiesForBillingDTO
    {
        int Id { get; set; }

        int ProviderId { get; set; }

        short IdentityId { get; set; }

        string Value { get; set; }
        DateTime ActiveDate { get; set; }
        DateTime? InactiveDate { get; set; }
        IIdentitiesDTO Identity { get; set; }
    }


    public interface IProviderForBillingDTO
    {
        #region Generated Properties

        int Id { get; set; }

        string Prefix { get; set; }

        string FirstName { get; set; }

        string FullName
        {
            get; set;
        }

        string MiddleName { get; set; }


        string LastName { get; set; }

        string Suffix { get; set; }


        string Address1 { get; set; }

        string Address2 { get; set; }


        string City { get; set; }

        string State { get; set; }

        string ZipCode { get; set; }

        DateTime? DOB { get; set; }

        string PrimaryPhone { get; set; }

        int? PrimaryPhoneType { get; set; }

        string PracticeName { get; set; }

        bool Active { get; set; }

        string Degree { get; set; }

        string Comments { get; set; }

        string ClinicianId { get; set; }

        int? UserId { get; set; }

        int? SupervisorId { get; set; }

        bool? IsOptedForGroupBilling { get; set; }

        bool CanBill { get; set; }

        string PrimaryFax { get; set; }

        string NPI { get; set; }

        string SSN { get; set; }
        bool IsLocked { get; set; }

        short? SupervisorTypeId { get; set; }

        bool? BillUnderSupervisor { get; set; }

        long? CircumstanceId { get; set; }

        int? PractitonerModifierId { get; set; }
        bool IsClinical { get; set; }
        string DEA { get; set; }

        bool IsNeedDosepot { get; set; }
        bool IsDefaultClinician { get; set; }

        bool? IsDiagnosisEvaluation { get; set; }

        bool IsTestProvider { get; set; }
        #endregion

        #region Generated Relationships


        List<IProviderIdentitiesForBillingDTO> ProviderIdentities { get; set; }

        #endregion
    }

    public interface IFacilityIdentitiesDTO
    {
        int Id { get; set; }
        short FacilityId { get; set; }
        short IdentityId { get; set; }
        string Value { get; set; }
        DateTime ActiveDate { get; set; }
        DateTime? InactiveDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }

        IIdentitiesDTO Identity { get; set; }
    }

    public interface IFacilityForBillingDTO
    {
        

        short Id { get; set; }
        string Name { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string Phone { get; set; }
        int? LocationId { get; set; }
        string FacilityCode { get; set; }
        string FacilityDescription { get; set; }
        string Fax { get; set; }
        string PosCode { get; set; }
        string LocationCode { get; set; }
        string NPI { get; set; }
        string SUDNPI { get; set; }
        string TIN { get; set; }
        string TimeZone { get; set; }
        string ServiceTypeCode { get; set; }
        int? PMFacilityId { get; set; }
        string Locality { get; set; }
        short? FeeScheduleCarrierNumber { get; set; }
        short? FeeLocalCarrNumId { get; set; }
        bool? IsDefaultLocation { get; set; }
        int? DefaultProviderId { get; set; }
        string LIMSCode { get; set; }
        List<IFacilityIdentitiesDTO> FacilityIdentities { get; set; }
    }

    public interface IEMRChargeStatus
    {
        int BillingId { get; set; }
        int ChargeId { get; set; }
        string ReasonsFromBillingSytem { get; set; }
        int? ClaimId { get; set; }
        DateTime? ClaimSentDate { get; set; }
        double? ClaimAmount { get; set; }
        decimal? PaidAmount { get; set; }
        decimal? AdjustmentAmount { get; set; }
        bool? HasDenial { get; set; }
        string AdjustmentCode { get; set; }
        string RemarkCode { get; set; }
        decimal? DueAmount { get; set; }
        string DueBy { get; set; }
    }

}
