using PractiZing.Base.Model;
using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IBulkPaymentFilter : IBaseSearchModel
    {
        string BatchFromDate { get; set; }
        string BatchToDate { get; set; }
        string FromDate { get; set; }
        string ToDate { get; set; }
        string DepositTypeIds { get; set; }
        string DepositTypeUIds { get; set; }
        string IsCommitted { get; set; }
        string PaymentSourceCD { get; set; }
        int? DifferenceId { get; set; }
        Guid? VoucherUId { get; set; }
    }
}
