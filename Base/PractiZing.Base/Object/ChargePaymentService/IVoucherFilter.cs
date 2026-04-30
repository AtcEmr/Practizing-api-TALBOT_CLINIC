using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IVoucherFilter
    {
        string DepositTypeIds { get; set; }
        string FromDate { get; set; }
        string ToDate { get; set; }
        string IsCommitted { get; set; }
        string PaymentSourceCD { get; set; }
        int? DifferenceId { get; set; }
    }
}
