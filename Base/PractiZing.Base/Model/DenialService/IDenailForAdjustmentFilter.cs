using PractiZing.Base.Object.DenialService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.DenialService
{
    public interface IDenailForAdjustmentFilter
    {
        string Header { get; set; }
        IEnumerable<IDenailForAdjustment> DenialForAdjustment { get; set; }
    }
}
