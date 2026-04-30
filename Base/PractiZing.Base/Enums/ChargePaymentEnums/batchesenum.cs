using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
    public enum BatchesEnum
    {
        batchedClaims = 1,
        unbatchedClaims,
        sent,
        notSent,
        PrintedClaims,
        notPrintedClaims,
        onHoldClaims
    }
}
