using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.DenialService
{
    public interface IDenailForAdjustment
    {
        int AccountCount { get; set; }
        decimal BalanceAmount { get; set; }
        string ReasonCode { get; set; }
        decimal AdjustmentAmount { get; set; }
        bool IsSelected { get; set; }
    }
}
