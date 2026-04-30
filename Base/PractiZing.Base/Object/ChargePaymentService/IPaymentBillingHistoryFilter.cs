using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPaymentBillingHistoryFilter
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        IEnumerable<int> ChargeIds { get; set; }
        bool isPayment { get; set; }
    }
}
