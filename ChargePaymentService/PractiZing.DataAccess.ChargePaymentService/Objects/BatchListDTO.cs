using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class BatchListDTO : IBatchListDTO
    {
        public BatchListDTO()
        {
            this.PaymentBatch = new List<BatchDTO>();
            this.ChargeBatch = new List<BatchDTO>();
        }

        public IEnumerable<IBatchDTO> ChargeBatch { get; set; }
        public IEnumerable<IBatchDTO> PaymentBatch { get; set; }
    }
}
