using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargeTotal : IChargeTotal
    {
        public decimal TotalPaid { get ; set ; }
        public decimal TotalWriteOff { get ; set ; }
        public decimal TotalCharges { get ; set ; }
        public decimal TotalDiscounts { get ; set ; }
    }
}
