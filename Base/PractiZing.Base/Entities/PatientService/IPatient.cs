using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatient : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        int Id { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string FullName { get; }
        string MI { get; set; }
        DateTime DOB { get; set; }
        Int16? Age { get; set; }
        Int16 ProviderId { get; set; }
        string PrimaryCareDoctor { get; set; }
        string PhoneNumber { get; set; }
        string BillingID { get; set; }
        string Pharmacy { get; set; }
        int DoctorUserId { get; set; }
        string SSN { get; set; }
        string Sex { get; set; }//changed from char to string
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }

        string State { get; set; }
        string ZipCode { get; set; }
        string ReferralSource { get; set; }
        string ReferredBy { get; set; }
        string Email { get; set; }
        Byte?[] Picture { get; set; }
        string SpouseName { get; set; }
        bool? HistoryOfDrugAbuse { get; set; }
        string HistoryOfDrugAbuseComments { get; set; }
        string MobilePhoneNumber { get; set; }
        string WorkPhoneNumber { get; set; }
        string PreferredPhoneNumber { get; set; }//changed from char to string
        bool? PatientHXExists { get; set; }
        string BillAddress1 { get; set; }
        string BillAddress2 { get; set; }
        string BillCity { get; set; }
        string BillState { get; set; }
        string BillZip { get; set; }
        Int16 Resesitate { get; set; }
        string POAName { get; set; }
        string POAAddress1 { get; set; }
        string POAAddress2 { get; set; }
        string POACity { get; set; }
        string POAState { get; set; }
        string POAZip { get; set; }
        string GName { get; set; }
        string GAddress1 { get; set; }
        string GAddress2 { get; set; }
        string GCity { get; set; }
        string GState { get; set; }
        string GZip { get; set; }
        string MedicalRelNames { get; set; }
        bool? HomeHealth { get; set; }
        string HomeHealthLoc { get; set; }
        bool? NursingHome { get; set; }
        string NursingHomeLoc { get; set; }
        bool? BillSameAsRes { get; set; }
        bool? Hospice { get; set; }
        string HospiceLoc { get; set; }
        bool? ResultsEmail { get; set; }
        bool? ResultsMail { get; set; }
        bool? ResultsPickup { get; set; }
        bool? ResultsPhone { get; set; }
        bool? ResultsFax { get; set; }

        int? Locked { get; set; }
        bool? InCollections { get; set; }
        string InCollectionsComments { get; set; }
        bool? IDVerified { get; set; }
        string IDVerifiedBy { get; set; }
        string IDVerifiedDate { get; set; }
        bool? Alert { get; set; }
        string AlertText { get; set; }
        Int16? BillType { get; set; }
        bool CustomAlert1 { get; set; }
        bool CustomAlert2 { get; set; }
        bool TransferOfCare { get; set; }
        string Language { get; set; }
        string Ethnicity { get; set; }
        string ECFirstName { get; set; }
        string ECLastName { get; set; }
        string ECMiddleInitial { get; set; }
        string ECRelationship { get; set; }
        string ECPhoneNumber { get; set; }
        bool? ResultsEAccess { get; set; }
        string Nickname_ac { get; set; }
        string BillingSelection { get; set; }
        string PrefContact { get; set; }
        int? Guardian1ID { get; set; }
        int? Guardian2ID { get; set; }
        string LivesWith { get; set; }
        DateTime? PatientSigned { get; set; }
        string MaritalStatus { get; set; }
        string Religion { get; set; }
        Int16? LivingWill { get; set; }
        bool? Impairment { get; set; }
        string ImpairmentLoc { get; set; }
        string MaidenName { get; set; }
        string ScheduleAlert { get; set; }
        string PublicityCode { get; set; }
        DateTime? PublicityEffDate { get; set; }
        string RegistryStatusCode { get; set; }
        DateTime? RegistryEffDate { get; set; }
        int? ShareHealthData { get; set; }
        DateTime? ShareHealthDataEffDate { get; set; }
        bool? CustomAlert3 { get; set; }
        bool PortalOptedOut { get; set; }
        bool? DisallowScheduling { get; set; }
        int? DefaultCaseId { get; set; }
        string DefaultICDCode { get; set; }
        IEnumerable<int> InsuranceCompanyId { get; set; }
        IEnumerable<IPatientCase> PatientCase { get; set; }
        IInsuranceGuarantor InsuranceGuarantor { get; set; }
        IEnumerable<IInsurancePolicy> InsurancePolicy { get; set; }
        Guid? ProviderUId { get; set; }
        Guid PatientCaseUId { get; set; }
        string ICDDescription { get; set; }
        int? RaceId { get; set; }
        string Race { get; set; }
    }
}
