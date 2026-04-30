using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPaymentBatchFilter
    {
        string BatchFromDate { get; set; }
        string BatchToDate { get; set; }
    }
}
