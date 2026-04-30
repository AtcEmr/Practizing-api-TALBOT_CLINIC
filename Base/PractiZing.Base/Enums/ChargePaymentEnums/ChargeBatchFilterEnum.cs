using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
    public enum ChargeBatchFilterEnum
    {
        Batched = 1,
        UnBatched,
        Sent,
        NotSent,
        Printed,
        NotPrinted,
        OnHold
    }

    public enum ChargeBillingHistoryENUM
    {
        AllDueCharges = 1,
        DueByPatient = 2,
        DueByInsurance = 3,
        AllCharges = 4
    }

    public enum ClaimEnum
    {
        Process = 1,
        DueByPatient = 2,
        DueByInsurance = 3,
        AllCharges = 4,
        FederalTaxId = 5
    }

    public enum ScrubErrorEnum
    {
        Failed = 1,
        Success = 2
    }
}

