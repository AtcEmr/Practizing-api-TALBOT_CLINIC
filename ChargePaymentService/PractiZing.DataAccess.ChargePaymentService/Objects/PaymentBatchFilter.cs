using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PaymentBatchFilter: IPaymentBatchFilter
    {
        [SearchField(Name = PaymentClaimBatchFilter.BatchDate)]
        public string BatchFromDate { get; set; }
        [SearchField(Name = PaymentClaimBatchFilter.BatchDate)]
        public string BatchToDate { get; set; }
    }
}
