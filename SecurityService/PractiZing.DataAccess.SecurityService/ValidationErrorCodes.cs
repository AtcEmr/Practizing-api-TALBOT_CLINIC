using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.SecurityService
{
    public enum EnumErrorCode : Int32
    {
        UserNameAlreadyExists = 5001,
        UserPermissionAlreadyExist = 5002,
        UserRoleAlreadyExist = 5003,
        UserPINEmpty = 5004,
        UserPINNotMatched=5005
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
            this.AddErrorCode(EnumErrorCode.UserNameAlreadyExists, "User Name Already Exists.");
            this.AddErrorCode(EnumErrorCode.UserPermissionAlreadyExist, "User permission already exist.");
            this.AddErrorCode(EnumErrorCode.UserRoleAlreadyExist, "User role already exist.");
            this.AddErrorCode(EnumErrorCode.UserPINEmpty, "User Pin is empty. Please enter pin for the user.");
            this.AddErrorCode(EnumErrorCode.UserPINNotMatched, "PIN does not match with user pin.");
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
