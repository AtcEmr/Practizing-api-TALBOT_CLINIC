using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class GetBatchNumberDTO : IGetBatchNumberDTO
    {
        public string BatchNumber { get; set; }
    }
}
