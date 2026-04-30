using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common.Object
{
    public class ScrubErrorJSON : IScrubErrorJSON
    {        
        public ScrubErrorJSON()
        {
            this.ChargeErrors = new List<ChargeError>();
        }

        public string ErrorMessage { get; set; }       
        public IEnumerable<IChargeError> ChargeErrors { get; set; }
        //public string CPTCodes { get; set; }
        //public string ICDCodes { get; set; }
        //public string Modifiers { get; set; }
    }
}
