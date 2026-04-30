using PractiZing.Base.Entities.MasterService;
using System;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigReferralSource : IConfigReferralSource
    {
        public Int16 Id { get; set; }
        public string ReferralSource { get; set; }
        public bool IsActive { get; set; }
    }
}
