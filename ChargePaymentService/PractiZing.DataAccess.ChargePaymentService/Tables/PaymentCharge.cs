using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PaymentCharge : IPaymentCharge
    {
        public PaymentCharge()
        {
            this.PaymentAdjustments = new List<PaymentAdjustment>();
            this.PaymentRemarkCodes = new List<PaymentRemarkCode>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PaymentId { get; set; }
        public int ChargeId { get; set; }
        public decimal PaidAmount { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public string ReasonCode { get; set; }
        [Ignore]
        public decimal AdjustmentAmount { get; set; }
        [Ignore]
        public decimal PRAdjustmentAmount { get; set; }
        [Ignore]
        public decimal BonusAmount { get; set; }
        [Ignore]
        public bool IsDenial { get; set; }
        [Ignore]
        public DateTime? PaidDate { get; set; }
        [Ignore]
        public DateTime? DOS { get; set; }
        [Ignore]
        public string Mod1 { get; set; }
        [Ignore]
        public decimal Amount { get; set; }
        [Ignore]
        public decimal TotalPaidAmount { get; set; }
        [Ignore]
        public decimal CoPay { get; set; }
        [Ignore]
        public decimal Deductible { get; set; }
        [Ignore]
        public decimal CoIns { get; set; }
        [Ignore]
        public string CPTCode { get; set; }
        [Ignore]
        public decimal TotalAdjustment { get; set; }
        [Ignore]
        public decimal DueAmount { get; set; }
        [Ignore]
        public int InvoiceId { get; set; }
        [Ignore]
        public string DueByFlagCD { get; set; }
        [Ignore]
        public string AccessionNumber { get; set; }
        [Ignore]
        public Guid VoucherUId { get; set; }
        [Ignore]
        public Guid PaymentUId { get; set; }
        [Ignore]
        public Guid ChargeUId { get; set; }
        [Ignore]
        public int PatientCaseId { get; set; }
        [Ignore]
        public string InsuranceCompanyName { get; set; }
        [Ignore]
        public int InsuranceCompanyId { get; set; }
        [Ignore]
        public string PatientName { get; set; }
        [Ignore]
        public IEnumerable<IPaymentAdjustment> PaymentAdjustments { get; set; }
        [Ignore]
        public IEnumerable<IPaymentRemarkCode> PaymentRemarkCodes { get; set; }
        [Ignore]
        public int? ClaimId { get; set; }
        [Ignore]
        public string BillingID { get; set; }
        [Ignore]
        public bool IsCommitted { get; set; }
        [Ignore]
        public decimal DenialAmount { get; set; }
        [Ignore]
        public int VoucherNo { get; set; }
        [Ignore]
        public bool IsReversed { get; set; }
        [Ignore]
        public bool IsChargeDue { get; set; }
        [Ignore]
        public bool IsSelfPayment { get; set; }
        [Ignore]
        public string InsuranceCompanyCode { get; set; }
        [Ignore]
        public string TempCompanyCode { get; set; }
        [Ignore]
        public string PatientAccountNumber { get; set; }
        [Ignore]
        public string ClaimLevel { get; set; }        
    }
}
