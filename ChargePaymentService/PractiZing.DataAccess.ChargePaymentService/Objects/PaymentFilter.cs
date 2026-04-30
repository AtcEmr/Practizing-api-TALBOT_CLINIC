using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PaymentFilter: IPaymentFilter
    {
        [SearchField(Name = PaymentModel.IsCommitted)]
        public string IsCommitted { get; set; }
        [SearchField(Name = PaymentModel.PaymentSourceCD)]
        public string PaymentSourceCD { get; set; }
        public int? DifferenceId { get; set; }

    }

    public class PaymentModel
    {
        public const string TableName = "Payment";
        public const string IsCommitted = TableName + "." + "IsCommitted";
        public const string PaymentSourceCD = TableName + "." + "PaymentSourceCD";
    }
}
