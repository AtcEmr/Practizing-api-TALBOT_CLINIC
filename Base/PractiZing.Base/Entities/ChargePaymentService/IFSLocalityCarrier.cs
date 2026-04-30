using System;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IFSLocalityCarrier
    {
        Int16 Id { get; set; }
        string Locality { get; set; }
        Int16 CarrierNumber { get; set; }
    }
}
