using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService
{
    public enum EnumErrorCode : Int32
    {
        InsuranceCompanyExists = 1000,
        CodeAndNameMustFilled = 1001,
        InsuranceCompanyLinkedWithAnyPolicy = 1002,
        PolicyFeildRequired = 1003,
        CodeAlreadyExists = 1004,
        DrugClassAlreadyExists = 1006,
        DrugCodeAlreadyExists = 1007,
        //  DescriptionAlreadyExists = 1008,
        CodeCannotBeNullOrEmpty = 1009,
        DescriptionCannotBeNullOrEmpty = 1010,
        DuplicateCompanyCode = 1011,
        InsuranceCompanyValidation = 1012,
        SameNPIAlreadyExists = 1013,
        EnterValidUserId = 1014,
        CategoryNameAlreadyExists = 1015,
        CategoryNameCannotBeNullOrEmpty = 1016,
        NotesCategoryIdAlreadyExist = 1017,
        ReasonCodeAlreadyExist = 1018,
        NotesCategoryIdCannotBeNullOrEmpty = 1019,
        ReasonCodeCannotBeNullOrEmpty = 1020,
        RevenueCodeAlreadyExists = 1021,
        InsuranceCompanyCannotBeDeleted = 1022,
        FacilityDoesnotHaveIdentity = 1023,
        ProviderDoesnotHaveIdentity = 1084,
        HCFAConfigDoesNotExist = 1024,
        NDCCodeAlreadyExists = 1025,
        CodeAlreadyChoosen = 1026,
        IdentityAlreadyExist = 1027,
        DefaultQuantityLessThanOne = 1028,
        DefaultQuantityNull = 1029,
        InsuranceCompanyDoesNotExists = 1030,
        PermissionDenied = 1031,
        FileNotExists = 1032,
        InvalidEmailFormat = 1033,
        InvalidFileFormat = 1034,
        DenialCategoryNameAlreadyExist = 1049,
        InsuranceCompanyNOtExists = 1050,
        GroupCodeAlreadyExists = 1051,
        CodesAlreadyExists = 1052,
        MonthClosedAlreadyExists = 1053,
        AlreadyExistsCode=1053
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
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyExists, "Insurance Company already exists."); //1000
            this.AddErrorCode(EnumErrorCode.CodeAndNameMustFilled, "Insurance Company name and code must be filled."); //1001
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyLinkedWithAnyPolicy, "You cannot delete this insurance company because it is linked with any insurance policy");
            this.AddErrorCode(EnumErrorCode.PolicyFeildRequired, "Insurance Company or Policy number required.");
            this.AddErrorCode(EnumErrorCode.CodeAlreadyExists, "Code already exists.");
            this.AddErrorCode(EnumErrorCode.DrugClassAlreadyExists, "Drug Class already exists");
            this.AddErrorCode(EnumErrorCode.DrugCodeAlreadyExists, "Drug Code already exists");
            // this.AddErrorCode(EnumErrorCode.DescriptionAlreadyExists, "Description already exists");
            this.AddErrorCode(EnumErrorCode.CodeCannotBeNullOrEmpty, "Code can not be null or empty");
            this.AddErrorCode(EnumErrorCode.DescriptionCannotBeNullOrEmpty, "Description can not be null or empty");
            this.AddErrorCode(EnumErrorCode.DuplicateCompanyCode, "Entered company code already exists with this company type.");
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyValidation, "Insurance company code and Insurance company name can not be null.");
            this.AddErrorCode(EnumErrorCode.SameNPIAlreadyExists, "Same NPI already exists");
            this.AddErrorCode(EnumErrorCode.EnterValidUserId, "This UserID doesnot exist. Kindly Enter Valid User Id");
            this.AddErrorCode(EnumErrorCode.CategoryNameAlreadyExists, "Category Name already exists");
            this.AddErrorCode(EnumErrorCode.CategoryNameCannotBeNullOrEmpty, "Category Name cannot be null or empty");
            this.AddErrorCode(EnumErrorCode.NotesCategoryIdAlreadyExist, "Notes category Id already exist");
            this.AddErrorCode(EnumErrorCode.ReasonCodeAlreadyExist, "Reason Code already exist");
            this.AddErrorCode(EnumErrorCode.NotesCategoryIdCannotBeNullOrEmpty, "Notes Category Id cannot be null or empty");
            this.AddErrorCode(EnumErrorCode.ReasonCodeCannotBeNullOrEmpty, "Reason Code cannot be null or empty");
            this.AddErrorCode(EnumErrorCode.RevenueCodeAlreadyExists, "Revenue Code already exists");
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyCannotBeDeleted, "Insurance Company is in use so it cannot be deleted.");
            this.AddErrorCode(EnumErrorCode.FacilityDoesnotHaveIdentity, "Facility does not have");

            this.AddErrorCode(EnumErrorCode.ProviderDoesnotHaveIdentity, "Provider does not have");

            this.AddErrorCode(EnumErrorCode.HCFAConfigDoesNotExist, "HCFA Configuration does not exist!");
            this.AddErrorCode(EnumErrorCode.NDCCodeAlreadyExists, "NDC Code already exists");
            this.AddErrorCode(EnumErrorCode.CodeAlreadyChoosen, "NDC code already exists for this CPT code.");
            this.AddErrorCode(EnumErrorCode.IdentityAlreadyExist, "Identity type already exists.");
            this.AddErrorCode(EnumErrorCode.DefaultQuantityLessThanOne, "Default quantity cannot be less than 1.");
            this.AddErrorCode(EnumErrorCode.DefaultQuantityNull, "Default quantity cannot be null.");

            this.AddErrorCode(EnumErrorCode.InsuranceCompanyDoesNotExists, "Insurance company doesnot exist.");
            this.AddErrorCode(EnumErrorCode.PermissionDenied, "Permission Denied!");
            this.AddErrorCode(EnumErrorCode.FileNotExists, "File does not exists.");
            this.AddErrorCode(EnumErrorCode.InvalidEmailFormat, "The Email field is not a valid e-mail address.");
            this.AddErrorCode(EnumErrorCode.InvalidFileFormat, "Incorrect file format.");
            this.AddErrorCode(EnumErrorCode.DenialCategoryNameAlreadyExist, "Denial Category name already exist!");
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyNOtExists, "Insurance Company doesn't exists.");
            this.AddErrorCode(EnumErrorCode.CodesAlreadyExists, "This code - {0} already exists with group code - {1}.");
            this.AddErrorCode(EnumErrorCode.GroupCodeAlreadyExists, "you cannot enter duplicate group code.");
            this.AddErrorCode(EnumErrorCode.MonthClosedAlreadyExists, "This Month and Year already has been closed.");            
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
