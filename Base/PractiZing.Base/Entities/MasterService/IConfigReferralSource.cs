using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigReferralSource : IActive
    {
        Int16 Id { get; set; }
        string ReferralSource { get; set; }
    }
}

