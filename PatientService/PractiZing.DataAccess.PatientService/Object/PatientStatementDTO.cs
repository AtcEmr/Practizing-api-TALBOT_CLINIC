using PractiZing.Base.Entities;
using PractiZing.Base.Object.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientStatementDTO : IPatientStatementDTO, IEntity
    {
        public int PatientID { get; set; }
        public int CaseNumber { get; set; }
        public String PatientName { get; set; }
        public DateTime PatientDOB { get; set; }
        public String PatientAddress { get; set; }
        public Decimal BalanceLess30 { get; set; }
        public Decimal Balance3060 { get; set; }
        public Decimal Balance6090 { get; set; }
        public Decimal Balance90120 { get; set; }
        public Decimal BalanceMore120 { get; set; }
        public Decimal TotalBalance { get; set; }
        public Decimal AppliedAmount { get; set; }
        public DateTime? LastPayment { get; set; }
        public DateTime? LastStatement { get; set; }
        public int NumberOfStatements { get; set; }
        public String ValidateInsuranceGuarantor { get; set; }
        [Ignore]
        public string KeyID { get; set; }
    }
}
