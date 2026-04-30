using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IBulkAdjustmentFROMUIModel
    {
        IEnumerable<string> UIds { get; set; }
        string AdjustmentCode { get; set; }
        string ManagerPin { get; set; }
    }
}
