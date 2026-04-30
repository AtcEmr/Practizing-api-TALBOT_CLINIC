using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
    public enum GenderType
    {
        [Description("Unknown")]
        Unknown = -1,

        [Description("Male")]
        Male = 0,

        [Description("Female")]
        Female = 1
    }
}
