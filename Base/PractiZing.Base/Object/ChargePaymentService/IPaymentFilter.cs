using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPaymentFilter
    {
        string IsCommitted { get; set; }
        string PaymentSourceCD { get; set; }
        int? DifferenceId { get; set; }
    }
}
