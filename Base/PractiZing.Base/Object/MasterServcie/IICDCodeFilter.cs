using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IICDCodeFilter
    {
        string Code { get; set; }
        string Description { get; set; }
        string DefaultPlan { get; set; }
    }
}
