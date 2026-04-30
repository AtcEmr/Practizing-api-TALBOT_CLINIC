using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public interface IScrubErrorJSON
    {               
        string ErrorMessage { get; set; }        
        IEnumerable<IChargeError> ChargeErrors { get; set; }
        //string CPTCodes { get; set; }
        //string ICDCodes { get; set; }
        //string Modifiers { get; set; }
    }
}
