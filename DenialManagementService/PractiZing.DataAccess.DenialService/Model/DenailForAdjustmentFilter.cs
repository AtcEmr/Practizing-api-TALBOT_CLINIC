using PractiZing.Base.Model.DenialService;
using PractiZing.Base.Object.DenialService;
using PractiZing.DataAccess.DenialService.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Model
{
    public class DenailForAdjustmentFilter: IDenailForAdjustmentFilter
    {
        public DenailForAdjustmentFilter()
        {
            this.DenialForAdjustment = new List<DenailForAdjustment>();
        }

        public string Header { get; set; }
        public IEnumerable<IDenailForAdjustment> DenialForAdjustment { get; set; }
    }
}
