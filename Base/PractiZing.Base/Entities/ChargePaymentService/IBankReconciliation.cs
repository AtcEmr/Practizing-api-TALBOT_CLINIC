using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IBankReconciliation 
    {
        int Id { get; set; }
        string CheckNumber { get; set; }
        DateTime EffectiveDate { get; set; }
        DateTime? ClinicEffectiveDate { get; set; }
        DateTime? LABEffectiveDate { get; set; }
        DateTime? RESEffectiveDate { get; set; }
        string ClinicDepositType { get; set; }
        string LABDepositType { get; set; }
        string RESDepositType { get; set; }
        string ClinicPayerName { get; set; }
        string LABPayerName { get; set; }
        string RESPayerName { get; set; }
        decimal? ClinicDepositAmount { get; set; }
        decimal? LABDepositAmount { get; set; }
        decimal? RESDepositAmount { get; set; }
        decimal? ClinicPaymentAmount { get; set; }
        decimal? LABPaymentAmount { get; set; }
        decimal? RESPaymentAmount { get; set; }
        int? ClinicVoucherId { get; set; }
        int? LABVoucherId { get; set; }
        int? RESVoucherId { get; set; }
        int? ClinicPayerId { get; set; }
        int? LABPayerId { get; set; }
        int? RESPayerId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifyDate { get; set; }
        int? ChaseTransactionId { get; set; }
        int YearId { get; set; }
        int MonthId { get; set; }
        decimal? TotalDeposit { get; set; }        
        decimal? TotalPayment { get; set; }        
        decimal? TotalDifference { get; set; }
        string InsuranceCompany { get; set; }
        DateTime? ChaseTransactionDate { get; set; }
        string ChaseTransactionUpdatedBy { get; set; }
        decimal? ChasePaymentAmount { get; set; }
        int? ChasePaymentChildId { get; set; }
    }
}
