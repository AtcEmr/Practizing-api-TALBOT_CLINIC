using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
    public enum VoucherTypeEnum
    {
        PAYMENT,
        PROVISION
    }

    public enum PaymentSourceTypeEnum
    {
        MANUAL_PAYMENT,
        ERA_PAYMENT,
        BulkAdjustment_Payment,
        CARD_PAYMENT,
        BalanceAdjustment_Payment
    }

    public enum DrugFlagTypeEnum
    {
        PRIMARY,
        SECONDARY,
        TERNARY,
        PATIENT
    }

    public enum DifferenceEnum
    {
        Equal = 1,
        NonEqual = 2
    }

    public enum DrugClassFlag
    {
        PRIMARY = 1,
        SECONDARY = 2,
        TERNARY = 3,
        PATIENT = 0
    }

    public enum DepositTypeEnum
    {
        MedFocusMail = 1,
        NSFReversal = 2,
        ClinicMailChecks = 3,
        ClinicOTC = 4,
        ClinicCreditCards = 5,
        ClinicEFT = 6,
        ClinicLockbox = 7,
        InstaMedMF = 11
    }
}
