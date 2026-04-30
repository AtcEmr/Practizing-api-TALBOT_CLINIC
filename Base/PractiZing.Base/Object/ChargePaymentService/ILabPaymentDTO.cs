using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface ILabPaymentDTO
    {
        Guid UId { get; set; }
        decimal Amount { get; set; }        
    }
}
