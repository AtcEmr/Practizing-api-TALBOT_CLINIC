using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class InsurancePolicy : IInsurancePolicy
    {
        public InsurancePolicy()
        {
            this.InsurancePolicyHolder = new InsurancePolicyHolder();
            this.InsuranceCompany = new InsuranceCompany();
            this.PatientAuthorizationNumber = new List<PatientAuthorizationNumber>();
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }
        public int PatientCaseId { get; set; }
        public Guid UId { get; set; }

        public int InsuranceLevel { get; set; }
        public string PolicyNumber { get; set; }
        public string ContactPerson { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public DateTime? PlanEffectiveDate { get; set; }
        public DateTime? PlanExpirationDate { get; set; }
        public string AuthorizationInformation { get; set; }
        public string PHFirstName { get; set; }
        public string PHLastName { get; set; }
        public string PHRelationshipToPatient { get; set; }
        public string PHDOB { get; set; }
        public string PlanType { get; set; }
        public string PolicyDeductible { get; set; }
        public int? InsuranceCompanyID { get; set; }
        public float Copay { get; set; }
        public bool PHSignatureOnFile { get; set; }
        public bool AcceptAssignment { get; set; }
        public bool HL7UpdateFlag { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int PHID { get; set; }
        public string MedicaidId { get; set; }
        public bool? IsNotifyToEMR { get; set; }
        public bool Eligible { get; set; }
        public bool Medigap { get; set; }
        public Int16? MedicareSecondary { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long? EMRInsurancePolicyId { get; set; }
        // public int CaseNumber {get; set;}
        [Ignore]
        public IInsurancePolicyHolder InsurancePolicyHolder { get; set; }
        [Ignore]
        public IInsuranceCompany InsuranceCompany { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsFromIntegration { get; set; }

        [Ignore]
        public string InsuranceCompanyName { get; set; }

        [Ignore]
        public IEnumerable<IPatientAuthorizationNumber> PatientAuthorizationNumber { get; set; }

        [Ignore]
        public bool IsGCodeAccepted { get; set; }

        [Ignore]
        public bool IsEdit { get; set; }

        [Ignore]
        public string InsuranceCompanyCode { get; set; }

        [Ignore]
        public Guid InsuranceCompanyUId { get; set; }

        [Ignore]
        public Guid PatientCaseUId { get; set; }

        [Ignore]
        public Guid PatientUId { get; set; }

        [Ignore]
        public Guid PHUId { get; set; }

        [Ignore]
        public bool IsUpdated { get; set; }

        [Ignore]
        public string   BillinId { get; set; }
        [Ignore]
        public short? InsuranceCompanyTypeId { get; set; }

        [Ignore]
        public string ErrorMessage { get; set; }
    }
}