using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class BankReconciliation : IBankReconciliation
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string CheckNumber { get; set; }        
        public DateTime? ClinicEffectiveDate { get; set; }
        public DateTime? LABEffectiveDate { get; set; }
        public DateTime? RESEffectiveDate { get; set; }
        public string ClinicDepositType { get; set; }
        public string LABDepositType { get; set; }
        public string RESDepositType { get; set; }
        public string ClinicPayerName { get; set; }
        public string LABPayerName { get; set; }
        public string RESPayerName { get; set; }
        public decimal? ClinicDepositAmount { get; set; }
        public decimal? LABDepositAmount { get; set; }
        public decimal? RESDepositAmount { get; set; }
        public decimal? ClinicPaymentAmount { get; set; }
        public decimal? LABPaymentAmount { get; set; }
        public decimal? RESPaymentAmount { get; set; }
        public int? ClinicVoucherId { get; set; }
        public int? LABVoucherId { get; set; }
        public int? RESVoucherId { get; set; }
        public int? ClinicPayerId { get; set; }
        public int? LABPayerId { get; set; }
        public int? RESPayerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? ChaseTransactionId { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public DateTime? ChaseTransactionDate { get; set; }
        public string ChaseTransactionUpdatedBy { get; set; }

        [Ignore]
        public decimal? TotalDeposit { get; set; }
        [Ignore]
        public decimal? TotalPayment { get; set; }
        [Ignore]
        public decimal? TotalDifference { get; set; }
        [Ignore]
        public DateTime EffectiveDate { get; set; }
        [Ignore]
        public string InsuranceCompany { get; set; }
        [Ignore]
        public decimal? ChasePaymentAmount { get; set; }
        [Ignore]
        public int? ChasePaymentChildId { get; set; }

    }
}
