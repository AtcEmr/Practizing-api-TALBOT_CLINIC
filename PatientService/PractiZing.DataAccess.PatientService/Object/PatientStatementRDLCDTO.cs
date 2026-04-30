using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientStatementRDLCDTO : IPatientStatementRDLCDTO
    {
        public int PatientId { get; set; }
        public Guid PatientUId { get; set; }
        public int CaseNumber { get; set; }
        public string PatientName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string PatientAddress { get; set; }
        public decimal Balance030 { get; set; }
        public decimal Balance3160 { get; set; }
        public decimal Balance6190 { get; set; }
        public decimal Balance91120 { get; set; }
        public decimal BalanceOver120 { get; set; }
        public decimal TotalBalance { get; set; }
        public DateTime LastPayment { get; set; }
        public DateTime LastStatement { get; set; }
        public int NumberOfStatements { get; set; }
        public bool UnPostedPayment { get; set; }
        public bool UnMatchedPayment { get; set; }
        public string BillingId { get; set; }
    }
}
