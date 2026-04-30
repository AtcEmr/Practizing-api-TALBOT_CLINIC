using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IChargeError
    {          
        int ClaimId { get; set; }
        int ChargeId { get; set; }        
        string ErrorMessage { get; set; }        
    }
}
