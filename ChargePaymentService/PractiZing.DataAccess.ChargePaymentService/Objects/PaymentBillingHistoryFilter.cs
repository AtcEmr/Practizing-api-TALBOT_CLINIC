using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PaymentBillingHistoryFilter: IPaymentBillingHistoryFilter
    {
        [SearchField(Name = PaymentDataFilterModel.FromDate)]
        public string FromDate { get; set; }
        [SearchField(Name = PaymentDataFilterModel.ToDate)]
        public string ToDate { get; set; }
        public IEnumerable<int> ChargeIds { get; set; }
        public bool isPayment { get; set; }
    }

    public class PaymentDataFilterModel
    {
        public const string FromDate = "Payment" + "." + "CreatedDate";
        public const string ToDate = "Payment" + "." + "CreatedDate";
    }
}
