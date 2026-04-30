using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Object.PatientService;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class HL7FileDTO : IHL7FileDTO, IPatient
    {
        public HL7FileDTO()
        {
            var HL7Status = new HL7Status();
        }
        public int Id { get; set; }

        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int CaseType { get; set; }

        public string MI { get; set; }
        public DateTime DOB { get; set; }
        public short? Age { get; set; }
        public short ProviderId { get; set; }
        public string PrimaryCareDoctor { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingID { get; set; }
        public int LabClientID { get; set; }
        public string Pharmacy { get; set; }
        public int DoctorUserId { get; set; }
        public string SSN { get; set; }
        public string Sex { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ReferralSource { get; set; }
        public string ReferredBy { get; set; }
        public string Email { get; set; }
        public string ClientName { get; set; }
        public string DrivingLicenseNo { get; set; }
        public short? PatientBillTypeId { get; set; }

        [Ignore]
        public byte?[] Picture { get; set; }
        public string SpouseName { get; set; }
        public bool? HistoryOfDrugAbuse { get; set; }
        public string HistoryOfDrugAbuseComments { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PreferredPhoneNumber { get; set; }
        public bool? PatientHXExists { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }
        public short Resesitate { get; set; }
        public string POAName { get; set; }
        public string POAAddress1 { get; set; }
        public string POAAddress2 { get; set; }
        public string POACity { get; set; }
        public string POAState { get; set; }
        public string POAZip { get; set; }
        public string GName { get; set; }
        public string GAddress1 { get; set; }
        public string GAddress2 { get; set; }
        public string GCity { get; set; }
        public string GState { get; set; }
        public string GZip { get; set; }
        public string MedicalRelNames { get; set; }
        public bool? HomeHealth { get; set; }
        public string HomeHealthLoc { get; set; }
        public bool? NursingHome { get; set; }
        public string NursingHomeLoc { get; set; }
        public bool? BillSameAsRes { get; set; }
        public bool? Hospice { get; set; }
        public string HospiceLoc { get; set; }
        public bool? ResultsEmail { get; set; }
        public bool? ResultsMail { get; set; }
        public bool? ResultsPickup { get; set; }
        public bool? ResultsPhone { get; set; }
        public bool? ResultsFax { get; set; }
        public int? Locked { get; set; }
        public bool? InCollections { get; set; }
        public string InCollectionsComments { get; set; }
        public bool? IDVerified { get; set; }
        public string IDVerifiedBy { get; set; }
        public string IDVerifiedDate { get; set; }
        public bool? Alert { get; set; }
        public string AlertText { get; set; }
        public short? BillType { get; set; }
        public bool CustomAlert1 { get; set; }
        public bool CustomAlert2 { get; set; }
        public bool TransferOfCare { get; set; }
        public string Language { get; set; }
        public string Ethnicity { get; set; }
        public string ECFirstName { get; set; }
        public string ECLastName { get; set; }
        public string ECMiddleInitial { get; set; }
        public string ECRelationship { get; set; }
        public string ECPhoneNumber { get; set; }
        public bool? ResultsEAccess { get; set; }
        public string Nickname_ac { get; set; }
        public string BillingSelection { get; set; }
        public string PrefContact { get; set; }
        public int? Guardian1ID { get; set; }
        public int? Guardian2ID { get; set; }
        public string LivesWith { get; set; }
        public DateTime? PatientSigned { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public short? LivingWill { get; set; }
        public bool? Impairment { get; set; }
        public string ImpairmentLoc { get; set; }
        public string MaidenName { get; set; }
        public string ScheduleAlert { get; set; }
        public string PublicityCode { get; set; }
        public DateTime? PublicityEffDate { get; set; }
        public string RegistryStatusCode { get; set; }
        public DateTime? RegistryEffDate { get; set; }
        public int? ShareHealthData { get; set; }
        public DateTime? ShareHealthDataEffDate { get; set; }
        public bool? CustomAlert3 { get; set; }
        public bool PortalOptedOut { get; set; }
        public bool? DisallowScheduling { get; set; }
        public int? DefaultCaseId { get; set; }
        public bool? IsPrimaryCareNPI { get; set; }

        public int? RaceId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public Guid? ProviderUId { get; set; }
        [Ignore]
        public string ReferringNPI { get; set; }

        [Ignore]
        public string ReferringProviderFirstName { get; set; }

        [Ignore]
        public string ReferringProviderLastName { get; set; }

        [Ignore]
        public string ReferringProviderAddress1 { get; set; }

        [Ignore]
        public string ReferringProviderAddress2 { get; set; }

        [Ignore]
        public string ReferringProviderCity { get; set; }
        [Ignore]
        public string ReferringProviderState { get; set; }
        [Ignore]
        public string ReferringProviderZip { get; set; }

        [Ignore]
        public string Location { get; set; }

        [Ignore]
        public short? PerformingFacilityId { get; set; }
        [Ignore]
        public Guid? PerformingFacilityUId { get; set; }

        [Ignore]
        public short BillFacilityId { get; set; }

        [Ignore]
        public Guid BillFacilityUId { get; set; }
        [Ignore]
        public IEnumerable<int> InsuranceCompanyId { get; set; }
        [Ignore]
        public IEnumerable<IInsurancePolicy> InsurancePolicy { get; set; }
        [Ignore]
        public IEnumerable<IPatientCase> PatientCase { get; set; }

        [Ignore]
        public IInvoice Invoice { get; set; }

        [Ignore]
        public IHL7Status HL7Status { get; set; }

        [Ignore]
        public List<IDiagnosisDTO> DiagnosisDTOs { get; set; }

        [Ignore]
        public string ProviderName { get; set; }

        [Ignore]
        public string POSCode { get; set; }

        [Ignore]
        public IInsuranceGuarantor InsuranceGuarantor { get; set; }

        public string FullName { get; set; }

        public string DefaultICDCode { get; set; }
        public Guid PatientCaseUId { get; set; }
        public string ICDDescription { get; set; }

        [Ignore]
        public string BillingProviderFirstName { get; set; }
        [Ignore]
        public string BillingProviderLastName { get; set; }
        [Ignore]
        public string BillingProviderNPI { get; set; }

        [Ignore]
        public string RenderingProviderFirstName { get; set; }
        [Ignore]
        public string RenderingProviderLastName { get; set; }
        [Ignore]
        public string RenderingProviderNPI { get; set; }

        [Ignore]
        public string Race { get; set; }
        [Ignore]
        public string RenderingProviderSupervisorFirstName { get; set; }
        [Ignore]
        public string RenderingProviderSupervisorLastName { get; set; }
        [Ignore]
        public string RenderingProviderSupervisorNPI { get; set; }

        [Ignore]
        public string BillingFacilityNPI { get; set; }
        [Ignore]
        public string PerformingFacilityNPI { get; set; }
        [Ignore]
        public string TOSCode { get; set; }

        [Ignore]
        public string PerformingFacilityCode { get; set; }
        [Ignore]
        public string BillingFacilityCode { get; set; }

        [Ignore]
        public string OrderingProviderFirstName { get; set; }
        [Ignore]
        public string OrderingProviderLastName { get; set; }
        [Ignore]
        public string OrderingProviderNPI { get; set; }
    }

    

}
