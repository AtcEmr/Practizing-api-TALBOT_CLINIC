using System;
using System.Collections.Generic;

namespace PractiZing.Base.Model.Master
{
    public interface IProviderEmrDTO
    {
        int id { get; set; }
        string prefix { get; set; }
        string firstName { get; set; }
        string fullName { get; set; }
        string middleName { get; set; }
        string lastName { get; set; }
        string suffix { get; set; }
        string address1 { get; set; }
        string address2 { get; set; }
        string city { get; set; }
        string state { get; set; }
        string zipCode { get; set; }
        DateTime dob { get; set; }
        string primaryPhone { get; set; }
        int primaryPhoneType { get; set; }
        string practiceName { get; set; }
        bool active { get; set; }
        string degree { get; set; }
        string comments { get; set; }
        string clinicianId { get; set; }
        int userId { get; set; }
        int? supervisorId { get; set; }
        bool? isOptedForGroupBilling { get; set; }
        bool canBill { get; set; }
        string primaryFax { get; set; }
        string npi { get; set; }
        string ssn { get; set; }
        bool isLocked { get; set; }
        int? supervisorTypeId { get; set; }
        bool? billUnderSupervisor { get; set; }
        int? circumstanceId { get; set; }
        int? practitonerModifierId { get; set; }
        bool isClinical { get; set; }
        string dea { get; set; }
        bool isNeedDosepot { get; set; }
        bool isDefaultClinician { get; set; }
        bool? isDiagnosisEvaluation { get; set; }
        bool isTestProvider { get; set; }
        int? MHPractitonerModifierId { get; set; }
        int? SUDPractitonerModifierId { get; set; }
        IProvideridentity[] providerIdentities { get; set; }
        IProviderFacilityDTO[] providerFacility { get; set; }
    }

    public class IProviderFacilityDTO
    {
        public int id { get; set; }
        public int providerId { get; set; }
        public int facilityId { get; set; }
    }

    public class IProvideridentity
    {
        public int id { get; set; }
        public int providerId { get; set; }
        public int identityId { get; set; }
        public string value { get; set; }
        public DateTime activeDate { get; set; }
        public DateTime? inactiveDate { get; set; }
        public IIdentity identity { get; set; }
        public short? billingIdentityId { get; set; }
    }

    public class IIdentity
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public short? billingIdentityId { get; set; }
    }


    public interface IFacilityEMRDto
    {
        int id { get; set; }
        string name { get; set; }
        string address1 { get; set; }
        string address2 { get; set; }
        string city { get; set; }
        string state { get; set; }
        string zipCode { get; set; }
        string phone { get; set; }
        int? locationId { get; set; }
        string facilityCode { get; set; }
        string facilityDescription { get; set; }
        string fax { get; set; }
        string posCode { get; set; }
        string locationCode { get; set; }
        string npi { get; set; }
        string sudnpi { get; set; }
        string tin { get; set; }
        string timeZone { get; set; }
        string serviceTypeCode { get; set; }
        int? pmFacilityId { get; set; }
        string locality { get; set; }
        int? feeScheduleCarrierNumber { get; set; }
        int? feeLocalCarrNumId { get; set; }
        bool isDefaultLocation { get; set; }
        int? defaultProviderId { get; set; }        
        string limsCode { get; set; }
        IFacilityidentity[] facilityIdentities { get; set; }
    }

    public class IFacilityidentity
    {
        public int id { get; set; }
        public int facilityId { get; set; }
        public int identityId { get; set; }
        public string value { get; set; }
        public DateTime activeDate { get; set; }
        public DateTime? inactiveDate { get; set; }
        public IIdentity identity { get; set; }
        
    }

    public interface IPractitionerModifiersDTO
    {
        int id { get; set; }
        string name { get; set; }
        int cptModifierId { get; set; }
        string description { get; set; }
        bool? isSupervisionRequired { get; set; }
        bool? canSuperviseOther { get; set; }
        bool? canAdminSuperviseOther { get; set; }
        ICptmodifier cptModifier { get; set; }
        ISudcptmodifier sudcptModifier { get; set; }
    }

    public interface ICptmodifier
    {
        int id { get; set; }
        string code { get; set; }
        string description { get; set; }
    }

    public interface ISudcptmodifier
    {
        int id { get; set; }
        string code { get; set; }
        string description { get; set; }
    }

    public interface ISyncPatientDetailDTO
    {
        int Id { get; set; }
        DateTime DOB { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string NicknameAc { get; set; }
        string MI { get; set; }
        string MaidenName { get; set; }
        string PhoneNumber { get; set; }
        string MobilePhoneNumber { get; set; }
        string SSN { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string BillAddress1 { get; set; }
        string BillAddress2 { get; set; }
        string BillCity { get; set; }
        string BillState { get; set; }
        string BillZip { get; set; }
    }
}
