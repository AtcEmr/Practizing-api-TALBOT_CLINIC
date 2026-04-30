using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientStatementRDLCDTO
    {
        int PatientId { get; set; }
        Guid PatientUId { get; set; }
        int CaseNumber { get; set; }
        string PatientName { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DOB { get; set; }
        string PatientAddress { get; set; }
        decimal Balance030 { get; set; }
        decimal Balance3160 { get; set; }
        decimal Balance6190 { get; set; }
        decimal Balance91120 { get; set; }
        decimal BalanceOver120 { get; set; }
        decimal TotalBalance { get; set; }
        DateTime LastPayment { get; set; }
        DateTime LastStatement { get; set; }
        int NumberOfStatements { get; set; }
        bool UnPostedPayment { get; set; }
        bool UnMatchedPayment { get; set; }
        string BillingId { get; set; }
    }
}
