using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
    public enum InsuranceLevel
    {
        Primary = 1,
        Secondary = 2,
        Tertiary = 3,
        [Description("Quaternary")]
        Fourth = 4
    }
}
