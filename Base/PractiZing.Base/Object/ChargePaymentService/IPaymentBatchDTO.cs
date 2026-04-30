using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPaymentBatchDTO
    {
        Guid InvoiceUId { get; set; }
        Guid VoucherUId { get; set; }
        string BatchNo { get; set; }
        Guid ChargeBatchUId { get; set; }
        string AccessionNumber { get; set; }
        decimal BatchAmount { get; set; }
        decimal TotalPayableAmount { get; set; }
        decimal TotalPaidAmount { get; set; }
        Guid PatientUId { get; set; }
        decimal DifferenceAmount { get; set; }
        decimal TotalAdjustmentAmount { get; set; }
        bool IsChanged { get; set; }
        bool IsReversed { get; set; }
        bool IsNewPayment { get; set; }
        Guid PaymentUId { get; set; }
        Guid? DepositInsuranceCompanyUId { get; set; }
        Guid? PatientInsuranceCompanyUId { get; set; }
        string PayorControl { get; set; }

        IVoucher Voucher { get; set; }
        IEnumerable<ICharges> Charges { get; set; }
    }
}
