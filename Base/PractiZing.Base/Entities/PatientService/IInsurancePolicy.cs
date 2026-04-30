using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IInsurancePolicy : IStamp, IUniqueIdentifier
    {
        long Id { get; set; }
        int PHID { get; set; }
        int PatientCaseId { get; set; }
        string PolicyNumber { get; set; }
        string ContactPerson { get; set; }
        string GroupNumber { get; set; }
        string GroupName { get; set; }
        DateTime? PlanEffectiveDate { get; set; }
        DateTime? PlanExpirationDate { get; set; }
        string AuthorizationInformation { get; set; }
        string PHFirstName { get; set; }
        string PHLastName { get; set; }
        string PHRelationshipToPatient { get; set; }
        string PHDOB { get; set; }
        string PlanType { get; set; }
        string PolicyDeductible { get; set; }
        int? InsuranceCompanyID { get; set; }
        int InsuranceLevel { get; set; }
        float Copay { get; set; }
        bool PHSignatureOnFile { get; set; }
        bool AcceptAssignment { get; set; }
        bool HL7UpdateFlag { get; set; }
        bool Eligible { get; set; }
        bool Medigap { get; set; }
        Int16? MedicareSecondary { get; set; }
        // int CaseNumber { get; set; }
        string MedicaidId { get; set; }
        IInsurancePolicyHolder InsurancePolicyHolder { get; set; }
        IInsuranceCompany InsuranceCompany { get; set; }
        string InsuranceCompanyName { get; set; }
        IEnumerable<IPatientAuthorizationNumber> PatientAuthorizationNumber { get; set; }
        bool? IsNotifyToEMR { get; set; }
        bool IsGCodeAccepted { get; set; }
        bool IsEdit { get; set; }
        string InsuranceCompanyCode { get; set; }
        Guid InsuranceCompanyUId { get; set; }
        Guid PatientCaseUId { get; set; }
        Guid PHUId { get; set; }
        bool IsUpdated { get; set; }
        bool? IsActive { get; set; }
        string BillinId { get; set; }
        bool? IsFromIntegration { get; set; }
        short? InsuranceCompanyTypeId { get; set; }
        string ErrorMessage { get; set; }
        Guid PatientUId { get; set; }
        long? EMRInsurancePolicyId { get; set; }
        bool? IsDeleted { get; set; }
    }
}
