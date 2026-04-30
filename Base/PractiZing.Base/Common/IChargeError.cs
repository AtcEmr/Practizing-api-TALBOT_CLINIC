using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public interface IChargeError
    {          
        int ClaimId { get; set; }
        int ChargeId { get; set; }     
        DateTime DOSDate { get; set; }        
        string CPTCode { get; set; }
        string Mod1 { get; set; }
        string Mod2 { get; set; }
        string Mod3 { get; set; }
        string Mod4 { get; set; }
        string ErrorMessage { get; set; }        
    }
}
