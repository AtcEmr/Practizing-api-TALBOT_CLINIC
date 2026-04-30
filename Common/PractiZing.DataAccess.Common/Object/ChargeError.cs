using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common.Object
{
    public class ChargeError : IChargeError
    {
        public ChargeError(int claimId, int chargeId, DateTime dosDate, string cptCode, short qty,
        string mod1, string mod2, string mod3, string mod4, string errorMessage)
        {
            this.ClaimId = claimId;
            this.ChargeId = chargeId;
            this.DOSDate = dosDate;            
            this.CPTCode = cptCode;
            this.Qty = qty;
            this.Mod1 = mod1;
            this.Mod2 = mod2;
            this.Mod3 = mod3;
            this.Mod4 = mod4;
            this.ErrorMessage = errorMessage;
        }

        public int ClaimId { get; set; }
        public int ChargeId { get; set; }        
        public DateTime DOSDate { get ; set ; }        
        public string CPTCode { get ; set ; }
        public short Qty { get; set; }
        public string Mod1 { get ; set ; }
        public string Mod2 { get ; set ; }
        public string Mod3 { get ; set ; }
        public string Mod4 { get ; set ; }
        public string ErrorMessage { get; set; }
    }
}
