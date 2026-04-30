
using System;


public class EMRPolicySync
{
    public string policyNumber { get; set; }
    public object contactPerson { get; set; }
    public string groupNumber { get; set; }
    public string groupName { get; set; }
    public DateTime planEffectiveDate { get; set; }
    public object planExpirationDate { get; set; }
    public int? planTypeId { get; set; }
    public object policyDeductible { get; set; }
    public int insuranceCompanyId { get; set; }
    public object copay { get; set; }
    public bool? phSignatureOnFile { get; set; }
    public bool? acceptAssignment { get; set; }
    public object hL7UpdateFlag { get; set; }
    public object eligible { get; set; }
    public bool? haveInsurance { get; set; }
    public object medicareSecondaryId { get; set; }
    public int policyHolderId { get; set; }
    public int id { get; set; }
    public string medicaidId { get; set; }
    public object billingPolicyId { get; set; }
    public object trizettoError { get; set; }
    public object medicaidError { get; set; }
    public object isEligibilityActive { get; set; }
    public object isTypeMismatched { get; set; }    
    public EMRPatientpolicy[] patientPolicy { get; set; }
    public object insuranceMedicareSecondary { get; set; }
}


public class EMRPatientpolicy
{
    public int id { get; set; }
    public int policyId { get; set; }
    public int patientId { get; set; }
    public int levelId { get; set; }
    public bool isActive { get; set; }
    public bool isDeleted { get; set; }
    public object medigap { get; set; }
    public string modifiedBy { get; set; }
    public DateTime modifiedDate { get; set; }
    public object[] policyAuthorizationNumber { get; set; }
    public object insuranceCompany { get; set; }
    public object[] patientDocuments { get; set; }
}
