using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.DenialService
{
    public enum ConfigSystemCDEnum
    {
       Charge,
       Claim,
       Patient       
    }

    public static class ConfigSystemCDConstant
    {
        public const string Charge = "NS.CHARGE";
        public const string Claim = "NS.CLAIM";
        public const string Patient = "NS.PATIENT";        
    }
}
