using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
    public enum AddClaimImfoEnum
    {
        [Description("None")]
        None = 0,

        [Description("Medicare")]
        Medicare = 1,

        [Description("Medicaid")]
        Medicaid,

        [Description("TRICARE")]
        Tricare,

        [Description("ChampVA")]
        ChampVa,

        [Description("Group Health Plan")]
        GroupHealthPlan,

        [Description("FECA/Black Lung")]
        FecaBlackLung,

        [Description("Other")]
        Other
    }

    public enum AdjustmentCodes
    {
        CO45,
        PR1,
        PR2,
        PR3,
        Bonus
    }
}
