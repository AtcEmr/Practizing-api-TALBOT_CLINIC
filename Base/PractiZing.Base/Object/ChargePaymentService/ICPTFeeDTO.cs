using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface ICPTFeeDTO
    {
        int SerialNo { get; set; }
        string CPTCode { get; set; }
        List<string> Modifiers { get; set; }
        decimal Amount { get; set; }
        decimal Discount { get; set; }
    }
}
