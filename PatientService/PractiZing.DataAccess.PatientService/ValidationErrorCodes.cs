using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.PatientService
{
    public enum EnumErrorCode : Int32
    {
        InsuranceCompanyExists = 1000,
        CodeAndNameMustFilled = 1001,
        InsuranceCompanyLinkedWithAnyPolicy = 1002,
        PolicyFieldRequired = 1003,
        PolicyAlreadyExists = 1004,
        PatientDOBValidation = 1005,
        PatientIdMandatory = 1006,
        InsuranceComapnyIdMandatory = 1007,
        CaseIdNumberAlreadyExist = 1008,
        AuthorizationNumberAlreadyExists = 1009,
        AuthorizationNumberNullOrEmpty = 1010,
        AuthorizationEffectiveDateValidation = 1011,
        SSNAlreadyExists = 1012,
        InsurancePolicyDoesNotExist = 1013,
        EffectiveExpirationDateValidation = 1014,
        SecondaryPolicyEffectiveDate = 1015,
        SecondaryPolicyExpirationDate = 1016,
        SecondaryPolicyEffectivePeriod = 1017,
        ErrorDeletingInsurancePolicy = 1018,
        InsuranceLevelRequired = 1019,
        PolicyExpired = 1020,
        DOBRequired = 1021,
        PatientGenderRequired = 1022,
        GuarantorDOBRequired = 1023,
        FileDoesNotExist = 2001,
        PatientDoesnotExists = 2002,
        PatientUIdDoesnotExists = 2003,
        PolicyHolderRequired = 2004,
        AccessDenied = 2005,
        ClaimConfig = 2006,
        PolicyNotExist = 2007,
        PolicyExistForOtherPatient = 2010,
        PrimaryPolicyEffectiveDate = 2011,
        InsurancePolicyExistWithSecondaryLevelAndDate = 2012,
        InsurancePolicyExistWithSecondaryLevel = 2013,
        InsuranceOverlapError = 2014,
        InsurancePolicyExistWithSameLeveloNSecondary = 2015,
        PrimaryPolicyDateOverlap = 2016,
        EffectivePolicyActive = 2017,
        InsuranceCompanyNOtExists = 2018,
        PatientStreetRequired = 2019,
        PatientStateRequired = 2020,
        PatientCityRequired = 2021,
        PatientZipRequired = 2022,

        SubscriberStreetRequired = 2023,
        SubscriberStateRequired = 2024,
        SubscriberCityRequired = 2025,
        SubscriberZipRequired = 2026,
        PolicyNumberLength = 2027,
        PatientDOBWrong = 2028,
        InsuranceMedicaidIdNotMatched = 2050,
        AnthemPolicyNumberValidation = 2055,
        SelfPValidation = 2056,
        InsuranceCompanyTypeValidation = 2070,
        MedicaidIdRequired= 2071,
        MedicaidZERO = 2072,

    }

    public class ValidationErrorCodes : BaseValidationErrorCodes
    {
        public ValidationErrorCodes()
        {
            this.InitializeErrorCodes();
        }

        protected override void InitializeErrorCodes()
        {
            base.InitializeErrorCodes();
            this.AddErrorCode(EnumErrorCode.MedicaidZERO, "Medicaid Policy entered 0, please fix first."); //1000
            this.AddErrorCode(EnumErrorCode.MedicaidIdRequired, "Medicaid Id is required for company type Medicaid"); //1000
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyTypeValidation, "Insurance Company Type is UNKNOWN, Please fix first."); //1000
            this.AddErrorCode(EnumErrorCode.SelfPValidation, "SelfP Compnay only for the due by patient charges. cannot create the claim."); //1000
            this.AddErrorCode(EnumErrorCode.AnthemPolicyNumberValidation, "Anthem policy must start with 3 letter alpha prefix like JRI or MZO or YRN etc."); //1000
            this.AddErrorCode(EnumErrorCode.InsuranceMedicaidIdNotMatched, "Policy Number should be diffrent with MedicaidId for Paramount"); //1000
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyExists, "Insurance company already Exists."); //1000
            this.AddErrorCode(EnumErrorCode.CodeAndNameMustFilled, "Insurance company name And code must be filled."); //1001
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyLinkedWithAnyPolicy, "You cannot delete this insurance company because it is linked with any insurance policy");
            this.AddErrorCode(EnumErrorCode.PolicyFieldRequired, "Insurance company or policy number required.");
            this.AddErrorCode(EnumErrorCode.PolicyAlreadyExists, "Insurance policy already exists with this user on this level.");
            this.AddErrorCode(EnumErrorCode.PatientDOBValidation, "Patient DOB should not be in future");
            this.AddErrorCode(EnumErrorCode.InsuranceComapnyIdMandatory, "Please select insurance company.");
            this.AddErrorCode(EnumErrorCode.PatientIdMandatory, "Please select patient company.");
            this.AddErrorCode(EnumErrorCode.CaseIdNumberAlreadyExist, "Case Id number already exist");
            this.AddErrorCode(EnumErrorCode.AuthorizationNumberAlreadyExists, "Authorization number already exists");
            this.AddErrorCode(EnumErrorCode.AuthorizationNumberNullOrEmpty, "Authorization number cannot be null or empty");
            this.AddErrorCode(EnumErrorCode.AuthorizationEffectiveDateValidation, "Effective date must be greater than previous authorization number's expiration date");
            this.AddErrorCode(EnumErrorCode.SSNAlreadyExists, "SSN already exists");
            this.AddErrorCode(EnumErrorCode.InsurancePolicyDoesNotExist, "Insurance policy does not exist");
            this.AddErrorCode(EnumErrorCode.EffectiveExpirationDateValidation, "Plan effective date can not be greater than plan expiration date");
            this.AddErrorCode(EnumErrorCode.SecondaryPolicyEffectiveDate, "Secondary policy's effective date cannot be less than primary policy's effective date");
            this.AddErrorCode(EnumErrorCode.SecondaryPolicyExpirationDate, "Secondary policy's expiration date must be less than or same as primary policy's expiration Date");
            this.AddErrorCode(EnumErrorCode.SecondaryPolicyEffectivePeriod, "Secondary policy must have Primary policy effective throughout the period.");
            this.AddErrorCode(EnumErrorCode.ErrorDeletingInsurancePolicy, "you cannot delete this policy. It has existing secondary policy. so, first delete primary policy then try to delete this policy.");
            this.AddErrorCode(EnumErrorCode.InsuranceLevelRequired, "Please select insurance Level.");
            this.AddErrorCode(EnumErrorCode.PolicyExpired, "there is no policy with this dos date.");
            this.AddErrorCode(EnumErrorCode.DOBRequired, "DOB required!");
            this.AddErrorCode(EnumErrorCode.GuarantorDOBRequired, "Insurance Guarantor DOB is required");
            this.AddErrorCode(EnumErrorCode.FileDoesNotExist, "File Does not exist on this path -");
            this.AddErrorCode(EnumErrorCode.PatientDoesnotExists, "Patient does not Exists");
            this.AddErrorCode(EnumErrorCode.PatientUIdDoesnotExists, "Patient UId is incorrect.");
            this.AddErrorCode(EnumErrorCode.PolicyHolderRequired, "Policy Holder Information required!");
            this.AddErrorCode(EnumErrorCode.AccessDenied, "Access Denied!");
            this.AddErrorCode(EnumErrorCode.ClaimConfig, "Insurance company cannot be deleted because it has hcfa configuration.");
            this.AddErrorCode(EnumErrorCode.PolicyNotExist, "Insurance policy doesn't exist's with this patient on bill date.");
            this.AddErrorCode(EnumErrorCode.PolicyExistForOtherPatient, "This Policy number is already exist for other patient");
            this.AddErrorCode(EnumErrorCode.PrimaryPolicyEffectiveDate, "Primary policy's effective date cannot be less than primary policy's effective date");
            this.AddErrorCode(EnumErrorCode.InsurancePolicyExistWithSecondaryLevelAndDate, "Secondary policy doesn't have effective primary policy from - {0} - to - {1}");
            this.AddErrorCode(EnumErrorCode.InsurancePolicyExistWithSecondaryLevel, "Secondary policy does not have an effective primary policy' and the user should not able to create the secondary policy outside the primary policy date period");
            this.AddErrorCode(EnumErrorCode.InsuranceOverlapError, "There may be no overlaps in policy coverage dates for each level.");
            this.AddErrorCode(EnumErrorCode.InsurancePolicyExistWithSameLeveloNSecondary, "you cannot make secondary policy because secondary policy date may be overlap previous policy date.");
            this.AddErrorCode(EnumErrorCode.PrimaryPolicyDateOverlap, "There may be no overlaps in policy coverage dates for each level. {0} policy effective  {1} and expires {2} overlaps with one or more policies.");
            this.AddErrorCode(EnumErrorCode.EffectivePolicyActive, "you aleady have active policy with this date. you must enter expiry date in this policy before the effective date of active policy.");
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyNOtExists, "Insurance Company doesn't exists.");
            this.AddErrorCode(EnumErrorCode.PatientStreetRequired, "Patient address: Street is required.");
            this.AddErrorCode(EnumErrorCode.PatientStateRequired, "Patient address: State is required.");
            this.AddErrorCode(EnumErrorCode.PatientCityRequired, "Patient address: City is required.");
            this.AddErrorCode(EnumErrorCode.PatientZipRequired, "Patient address: Zip is required.");

            this.AddErrorCode(EnumErrorCode.SubscriberStreetRequired, "{0} subscriber address: Street is required.");
            this.AddErrorCode(EnumErrorCode.SubscriberStateRequired, "{0} subscriber address: State is required.");
            this.AddErrorCode(EnumErrorCode.SubscriberCityRequired, "{0} subscriber address: City is required.");
            this.AddErrorCode(EnumErrorCode.SubscriberZipRequired, "{0} subscriber address: Zip is required.");
            this.AddErrorCode(EnumErrorCode.PolicyNumberLength, "policy number must be <= 20 character.");
            this.AddErrorCode(EnumErrorCode.PatientDOBWrong, "Patient DOB is wrong. - {0}");
        }


        public void AddErrorCode(EnumErrorCode errorCode, string message)
        {
            base.AddErrorCode((int)errorCode, message);
        }

        public KeyValuePair<int, string> this[EnumErrorCode errorCode, params object[] formatter]
        {
            get
            {
                return base[(int)errorCode, formatter];
            }
        }
    }
}
