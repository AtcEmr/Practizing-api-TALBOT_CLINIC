using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPortalPaymentChild 
    {
        int Id { get; set; }
        int PortalPaymentId { get; set; }
        int PaymentId { get; set; }
    }
}
