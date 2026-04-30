using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IBatchListDTO
    {
        IEnumerable<IBatchDTO> ChargeBatch { get; set; }
        IEnumerable<IBatchDTO> PaymentBatch { get; set; }
    }
}
