using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPaymentCharge : IModifiedStamp, IUniqueIdentifier
    {
        int Id { get; set; }
        int PaymentId { get; set; }
        int ChargeId { get; set; }
        decimal PaidAmount { get; set; }
        string ReasonCode { get; set; }
        decimal AdjustmentAmount { get; set; }
        decimal PRAdjustmentAmount { get; set; }
        bool IsDenial { get; set; }
        DateTime? PaidDate { get; set; }
        DateTime? DOS { get; set; }
        string Mod1 { get; set; }
        decimal Amount { get; set; }
        decimal TotalPaidAmount { get; set; }
        decimal CoPay { get; set; }
        decimal Deductible { get; set; }
        decimal CoIns { get; set; }
        string CPTCode { get; set; }
        decimal TotalAdjustment { get; set; }
        decimal DueAmount { get; set; }
        int InvoiceId { get; set; }
        string DueByFlagCD { get; set; }
        string AccessionNumber { get; set; }
        Guid VoucherUId { get; set; }
        Guid PaymentUId { get; set; }
        Guid ChargeUId { get; set; }
        int PatientCaseId { get; set; }
        string InsuranceCompanyName { get; set; }
        int InsuranceCompanyId { get; set; }
        string PatientName { get; set; }
        int? ClaimId { get; set; }
        IEnumerable<IPaymentAdjustment> PaymentAdjustments { get; set; }
        IEnumerable<IPaymentRemarkCode> PaymentRemarkCodes { get; set; }
        string BillingID { get; set; }
        bool IsCommitted { get; set; }
        decimal DenialAmount { get; set; }
        int VoucherNo { get; set; }
        decimal BonusAmount { get; set; }
        bool IsReversed { get; set; }
        bool IsChargeDue { get; set; }
        bool IsSelfPayment { get; set; }
        string InsuranceCompanyCode { get; set; }
        string TempCompanyCode { get; set; }
        string PatientAccountNumber { get; set; }
        string ClaimLevel { get; set; }
    }
}
