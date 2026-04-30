using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.MasterService
{
    public static class AttTableConstant
    {
        public const string Voucher = "Voucher";
        public const string ChargeBatch = "ChargeBatch";
        public const string PaymentBatch = "PaymentBatch";
        public const string ActionCategory = "ActionCategory";
        public const string ActionNote = "ActionNote";
        public const string PatientStatements = "PatientStatements";
        public const string BatchStatement = "BatchStatement";
    }

    public enum AttEnum
    {
        Voucher = 1,
        ChargeBatch = 2,
        PaymentBatch = 3,
        ActionCategory = 4,
        ActionNote = 5,
        PatientStatements = 6,
        BatchStatement = 7
    }

    public static class ReportConstant
    {
        public const string DepositID = "DepositID";
        public const string ReasonCode = "ReasonCode";
        public const string ProviderID = "ProviderID";
        public const string UserID = "UserID";
        public const string CompanyNameID = "CompanyNameID";
        public const string CptCode = "CptCode";
    }
}
