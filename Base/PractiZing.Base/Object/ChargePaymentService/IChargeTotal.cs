using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargeTotal
    {
        decimal TotalPaid { get; set; }
        decimal TotalWriteOff { get; set; }
        decimal TotalCharges { get; set; }
        decimal TotalDiscounts { get; set; }
        
    }
}
