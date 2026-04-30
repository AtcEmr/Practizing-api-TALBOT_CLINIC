using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ERAService
{
    public enum EnumErrorCode : Int32
    {
        ERARootObjectNull = 7000,
        VoucherExistsCheckNo = 7001
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
            this.AddErrorCode(EnumErrorCode.ERARootObjectNull, "ERARoot Object is null");
            this.AddErrorCode(EnumErrorCode.VoucherExistsCheckNo, "File doesn't exists with check number - {0}.");
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
