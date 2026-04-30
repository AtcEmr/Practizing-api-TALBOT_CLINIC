using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.DenialService
{
    public enum EnumErrorCode : Int32
    {
        InsuranceCompanyExists = 1000,
        ParentCategoryExist = 1001,
        CategoryRequired = 1002,
        ActionNoteDelete = 1003,
        ActionNoteExist = 1004,
        UserNotFound = 1005
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
            this.AddErrorCode(EnumErrorCode.InsuranceCompanyExists, "Insurance Company Already Exists."); //1000
            this.AddErrorCode(EnumErrorCode.ParentCategoryExist, $"Action Category cannot be deleted as it is used as parent action category.To delete it, first delete action categories with ParentCategoryId = ");
            this.AddErrorCode(EnumErrorCode.ActionNoteDelete, $"Action Note cannot be deleted as it is created by another user. Note can be deleted by whom added that note.");
            this.AddErrorCode(EnumErrorCode.ActionNoteExist, "Action Category cannot be deleted as action notes exist on this category.");
            this.AddErrorCode(EnumErrorCode.UserNotFound, "User not found.");
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
