using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class BulkAdjustmentFROMUIModel: IBulkAdjustmentFROMUIModel
    {
        public IEnumerable<string> UIds { get; set; }
        public string AdjustmentCode { get; set; }
        public string ManagerPin { get; set; }
    }
}
