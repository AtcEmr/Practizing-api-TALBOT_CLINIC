using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IChargeScrub
    {
        int Id { get; set; }
        int ChargeId { get; set; }
        string ErrorJson { get; set; }        
    }
}
