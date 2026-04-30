using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class Patient : IPatient
    {
        public Patient()
        {
            this.PatientCase = new List<PatientCase>();
            this.InsuranceGuarantor = new InsuranceGuarantor();
            this.InsurancePolicy = new List<InsurancePolicy>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }

        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        // [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(30, ErrorMessage = "LastName - Must not enter more than 30 characters.")]
        public string LastName { get; set; }

        //[System.ComponentModel.DataAnnotations.Required]
        [MaxLength(30, ErrorMessage = "FirstName - Must not enter more than 30 characters.")]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "MI - Must not enter more than 30 characters.")]
        public string MI { get; set; }

        [Ignore]
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MI}";
            }
        }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "DOB required")]
        public DateTime DOB { get; set; }

        public Int16? Age { get; set; }
        public Int16 ProviderId { get; set; }

        [MaxLength(50, ErrorMessage = "PrimaryCareDoctor - Must not enter more than 50 characters.")]
        public string PrimaryCareDoctor { get; set; }

        [MaxLength(15, ErrorMessage = "PhoneNumber - Must not enter more than 15 characters.")]
        public string PhoneNumber { get; set; }

        public string BillingID { get; set; }
        [MaxLength(30, ErrorMessage = "Pharmacy - Must not enter more than 30 characters.")]
        public string Pharmacy { get; set; }
        public int DoctorUserId { get; set; }

        [MaxLength(11, ErrorMessage = "SSN - Must not enter more than 11 characters.")]
        public string SSN { get; set; }

        //[System.ComponentModel.DataAnnotations.Required]
        public string Sex { get; set; }

        [MaxLength(55, ErrorMessage = "Address1 - Must not enter more than 55 characters.")]
        public string Address1 { get; set; }
        [MaxLength(30, ErrorMessage = "Address2 - Must not enter more than 30 characters.")]
        public string Address2 { get; set; }

        [MaxLength(30, ErrorMessage = "City - Must not enter more than 20 characters.")]
        public string City { get; set; }

        [MaxLength(2, ErrorMessage = "State - Must not enter more than 2 characters.")]
        public string State { get; set; } // all states 2 character long

        [MaxLength(10, ErrorMessage = "ZipCode - Must not enter more than 10 characters.")]
        public string ZipCode { get; set; }

        [MaxLength(20, ErrorMessage = "ReferralSource - Must not enter more than 20 characters.")]
        public string ReferralSource { get; set; }
        [MaxLength(50, ErrorMessage = "ReferredBy - Must not enter more than 50 characters.")]
        public string ReferredBy { get; set; }

        [MaxLength(50, ErrorMessage = "Email - Must not enter more than 50 characters.")]
        //[EmailAddress]
        public string Email { get; set; }
        [Ignore]
        [MaxLength(16, ErrorMessage = "Picture - Must not enter more than 16 characters.")]
        public Byte?[] Picture { get; set; }

        [MaxLength(50, ErrorMessage = "SpouseName - Must not enter more than 50 characters.")]
        public string SpouseName { get; set; }

        public bool? HistoryOfDrugAbuse { get; set; }
        [MaxLength(400, ErrorMessage = "HistoryOfDrugAbuseComments - Must not enter more than 400 characters.")]
        public string HistoryOfDrugAbuseComments { get; set; }

        [MaxLength(15, ErrorMessage = "MobilePhoneNumber - Must not enter more than 15 characters.")]
        public string MobilePhoneNumber { get; set; }
        [MaxLength(25, ErrorMessage = "WorkPhoneNumber - Must not enter more than 25 characters.")]
        public string WorkPhoneNumber { get; set; }
        public string PreferredPhoneNumber { get; set; }

        public bool? PatientHXExists { get; set; }

        [MaxLength(55, ErrorMessage = "BillAddress1 - Must not enter more than 55 characters.")]
        public string BillAddress1 { get; set; }
        [MaxLength(30, ErrorMessage = "BillAddress2 - Must not enter more than 30 characters.")]
        public string BillAddress2 { get; set; }
        [MaxLength(30, ErrorMessage = "BillCity - Must not enter more than 30 characters.")]
        public string BillCity { get; set; }
        [MaxLength(2, ErrorMessage = "BillState - Must not enter more than 2 characters.")]
        public string BillState { get; set; }
        [MaxLength(10, ErrorMessage = "BillZip - Must not enter more than 10 characters.")]
        public string BillZip { get; set; }

        //[MaxLength(2, ErrorMessage = "Resesitate - Must not enter more than 2 characters.")]
        public Int16 Resesitate { get; set; }

        [MaxLength(50, ErrorMessage = "POAName - Must not enter more than 50 characters.")]
        public string POAName { get; set; }
        [MaxLength(30, ErrorMessage = "POAAddress1 - Must not enter more than 30 characters.")]
        public string POAAddress1 { get; set; }
        [MaxLength(30, ErrorMessage = "POAAddress2 - Must not enter more than 30 characters.")]
        public string POAAddress2 { get; set; }
        [MaxLength(30, ErrorMessage = "POACity - Must not enter more than 20 characters.")]
        public string POACity { get; set; }
        [MaxLength(2, ErrorMessage = "POAState - Must not enter more than 2 characters.")]
        public string POAState { get; set; }
        [MaxLength(10, ErrorMessage = "POAZip - Must not enter more than 10 characters.")]
        public string POAZip { get; set; }

        [MaxLength(50, ErrorMessage = "GName - Must not enter more than 50 characters.")]
        public string GName { get; set; }
        [MaxLength(30, ErrorMessage = "GAddress1 - Must not enter more than 30 characters.")]
        public string GAddress1 { get; set; }
        [MaxLength(30, ErrorMessage = "GAddress2 - Must not enter more than 30 characters.")]
        public string GAddress2 { get; set; }
        [MaxLength(30, ErrorMessage = "GCity - Must not enter more than 20 characters.")]
        public string GCity { get; set; }
        [MaxLength(2, ErrorMessage = "GState - Must not enter more than 2 characters.")]
        public string GState { get; set; }
        [MaxLength(10, ErrorMessage = "GZip - Must not enter more than 10 characters.")]
        public string GZip { get; set; }

        [MaxLength(500, ErrorMessage = "MedicalRelNames - Must not enter more than 500 characters.")]
        public string MedicalRelNames { get; set; }
        public bool? HomeHealth { get; set; }
        [MaxLength(75, ErrorMessage = "HomeHealthLoc - Must not enter more than 75 characters.")]
        public string HomeHealthLoc { get; set; }

        public bool? NursingHome { get; set; }
        [MaxLength(75, ErrorMessage = "NursingHomeLoc - Must not enter more than 75 characters.")]
        public string NursingHomeLoc { get; set; }

        public bool? BillSameAsRes { get; set; }

        public bool? Hospice { get; set; }
        [MaxLength(75, ErrorMessage = "HospiceLoc - Must not enter more than 75 characters.")]
        public string HospiceLoc { get; set; }

        public bool? ResultsEmail { get; set; }
        public bool? ResultsMail { get; set; }
        public bool? ResultsPickup { get; set; }
        public bool? ResultsPhone { get; set; }
        public bool? ResultsFax { get; set; }

        //[MaxLength(4, ErrorMessage = "Locked - Must not enter more than 4 characters.")]
        public int? Locked { get; set; }

        //[MaxLength(400, ErrorMessage = "InCollections - Must not enter more than 400 characters.")]
        public bool? InCollections { get; set; }
        public string InCollectionsComments { get; set; }

        public bool? IDVerified { get; set; }
        [MaxLength(70, ErrorMessage = "IDVerifiedBy - Must not enter more than 70 characters.")]
        public string IDVerifiedBy { get; set; }
        [MaxLength(10, ErrorMessage = "IDVerifiedDate - Must not enter more than 10 characters.")]
        public string IDVerifiedDate { get; set; }

        public bool? Alert { get; set; }
        [MaxLength(400, ErrorMessage = "AlertText - Must not enter more than 400 characters.")]
        public string AlertText { get; set; }

        //[MaxLength(2, ErrorMessage = "BillType - Must not enter more than 2 characters.")]
        public Int16? BillType { get; set; }

        public bool CustomAlert1 { get; set; }
        public bool CustomAlert2 { get; set; }

        public bool TransferOfCare { get; set; }

        [MaxLength(30, ErrorMessage = "Language - Must not enter more than 30 characters.")]
        public string Language { get; set; }
        [MaxLength(30, ErrorMessage = "Ethnicity - Must not enter more than 30 characters.")]
        public string Ethnicity { get; set; }
        [MaxLength(30, ErrorMessage = "ECFirstName - Must not enter more than 30 characters.")]
        public string ECFirstName { get; set; }
        [MaxLength(30, ErrorMessage = "ECLastName - Must not enter more than 30 characters.")]
        public string ECLastName { get; set; }
        [MaxLength(1, ErrorMessage = "ECMiddleInitial - Must not enter more than 1 characters.")]
        public string ECMiddleInitial { get; set; } //1 character long
        [MaxLength(30, ErrorMessage = "ECRelationship - Must not enter more than 30 characters.")]
        public string ECRelationship { get; set; }
        [MaxLength(15, ErrorMessage = "ECPhoneNumber - Must not enter more than 15 characters.")]
        public string ECPhoneNumber { get; set; }
        public bool? ResultsEAccess { get; set; }
        [MaxLength(30, ErrorMessage = "Nickname_ac - Must not enter more than 30 characters.")]
        public string Nickname_ac { get; set; }
        [MaxLength(15, ErrorMessage = "BillingSelection - Must not enter more than 15 characters.")]
        public string BillingSelection { get; set; }
        [MaxLength(15, ErrorMessage = "PrefContact - Must not enter more than 15 characters.")]
        public string PrefContact { get; set; }

        public int? Guardian1ID { get; set; }
        public int? Guardian2ID { get; set; }
        [MaxLength(20, ErrorMessage = "Nickname_ac - Must not enter more than 20 characters.")]
        public string LivesWith { get; set; }

        public DateTime? PatientSigned { get; set; }
        [MaxLength(10, ErrorMessage = "MaritalStatus - Must not enter more than 10 characters.")]
        public string MaritalStatus { get; set; }
        [MaxLength(20, ErrorMessage = "Religion - Must not enter more than 20 characters.")]
        public string Religion { get; set; }
        //[MaxLength(2, ErrorMessage = "LivingWill - Must not enter more than 2 characters.")]
        public Int16? LivingWill { get; set; }

        public bool? Impairment { get; set; }
        [MaxLength(75, ErrorMessage = "ImpairmentLoc - Must not enter more than 75 characters.")]
        public string ImpairmentLoc { get; set; }
        [MaxLength(30, ErrorMessage = "MaidenName - Must not enter more than 30 characters.")]
        public string MaidenName { get; set; }
        [MaxLength(150, ErrorMessage = "ScheduleAlert - Must not enter more than 150 characters.")]
        public string ScheduleAlert { get; set; }
        [MaxLength(10, ErrorMessage = "PublicityCode - Must not enter more than 10 characters.")]
        public string PublicityCode { get; set; }

        public DateTime? PublicityEffDate { get; set; }
        [MaxLength(10, ErrorMessage = "RegistryStatusCode - Must not enter more than 10 characters.")]
        public string RegistryStatusCode { get; set; }

        public DateTime? RegistryEffDate { get; set; }
        //[MaxLength(10, ErrorMessage = "ShareHealthData - Must not enter more than 10 characters.")]
        public int? ShareHealthData { get; set; }

        public DateTime? ShareHealthDataEffDate { get; set; }
        public bool? CustomAlert3 { get; set; }
        public bool PortalOptedOut { get; set; }

        public bool? DisallowScheduling { get; set; }
        public int? DefaultCaseId { get; set; }

        public string CreatedBy { get; set; }
        //   [Ignore]
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string DefaultICDCode { get; set; }

        public int? RaceId { get; set; }

        [Ignore]
        public string Race { get; set; }

        [Ignore]
        public IEnumerable<int> InsuranceCompanyId { get; set; }
        [Ignore]
        public IEnumerable<IPatientCase> PatientCase { get; set; }
        [Ignore]
        public IInsuranceGuarantor InsuranceGuarantor { get; set; }
        [Ignore]
        public IEnumerable<IInsurancePolicy> InsurancePolicy { get; set; }
        [Ignore]
        public Guid? ProviderUId { get; set; }

        [Ignore]
        public Guid PatientCaseUId { get; set; }

        [Ignore]
        public string ICDDescription { get; set; }
    }
}
