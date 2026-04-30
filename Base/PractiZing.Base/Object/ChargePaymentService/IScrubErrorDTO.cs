using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IScrubErrorDTO
    {       
        string AccessionNumber { get; set; }
        string CPTCode { get; set; }
        string ICDCode { get; set; }
        string Modifier { get; set; }
        string ErrorMessage { get; set; }        
    }
}
