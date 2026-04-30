using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IMobileInputModel
    {
        string BillingId { get; set; }
        DateTime DOB { get; set; }
        string LastName { get; set; }
    }
}
