using System;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientStatementDTO
    {
        int PatientID { get; set; }
        int CaseNumber { get; set; }
        String PatientName { get; set; }
        DateTime PatientDOB { get; set; }
        String PatientAddress { get; set; }
        Decimal BalanceLess30 { get; set; }
        Decimal Balance3060 { get; set; }
        Decimal Balance6090 { get; set; }
        Decimal Balance90120 { get; set; }
        Decimal BalanceMore120 { get; set; }
        Decimal TotalBalance { get; set; }
        Decimal AppliedAmount { get; set; }
        DateTime? LastPayment { get; set; }
        DateTime? LastStatement { get; set; }
        int NumberOfStatements { get; set; }
        String ValidateInsuranceGuarantor { get; set; }
    }
}
