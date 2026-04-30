using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IFeeLocalityCarrierNumber
    {
        Int16 LCID { get; set; }
        string Locality { get; set; }
        Int16 CarrierNumber { get; set; }
    }
}
