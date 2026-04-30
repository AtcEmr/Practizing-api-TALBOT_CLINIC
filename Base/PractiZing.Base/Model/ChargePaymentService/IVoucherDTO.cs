using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IVoucherDTO
    {
        string BatchNumber { get; set; }
        Int16 DepositTypeId { get; set; }
        DateTime DepositDate { get; set; }
        string PayeeName { get; set; }
        decimal PostedAmount { get; set; }
        decimal DepositAmount { get; set; }
        int PatientId { get; set; }
        int InsuranceCompanyId { get; set; }
        decimal DifferenceAmount { get; set; }
        string CheckRefNo { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int PaymentBatchId { get; set; }
        bool IsSelfPayment { get; set; }
        bool IsCommitted { get; set; }
        bool IsReversed { get; set; }
        int VoucherId { get; set; }
        Guid VoucherGUId { get; set; }
        Guid PatientUID { get; set; }
        string PaymentSourceCD { get; set; }

        IEnumerable<IPaymentDTO> PaymentDTOs { get; set; }
        Guid PaymentBatchGUId { get; set; }
        Guid PatientCaseUID { get; set; }

        IVoucher Voucher { get; set; }
        decimal TotalPaidAmount { get; set; }
        decimal PaymentBatchAmount { get; set; }
        DateTime EffectiveDate { get; set; }
        DateTime ReferenceDate { get; set; }
        bool? IsMatchedWithBank { get; set; }
    }

    public interface IVoucherPlaidDTO
    {
        int Id { get; set; }
        decimal Amount { get; set; }
        DateTime EffectiveDate { get; set; }
        string Practice { get; set; }
    }

    public interface IVoucherPlaidUpdateDTO
    {
        int VoucherId { get; set; }
        int PlaidPaymentId { get; set; }
    }
}
