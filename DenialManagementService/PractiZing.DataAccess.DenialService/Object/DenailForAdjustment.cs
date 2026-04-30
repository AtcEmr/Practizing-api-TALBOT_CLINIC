using PractiZing.Base.Object.DenialService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Object
{
    public class DenailForAdjustment : IDenailForAdjustment
    {
        public int AccountCount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string ReasonCode { get; set; }
        public decimal AdjustmentAmount { get; set; }

        [Ignore]
        public bool IsSelected { get; set; }
    }
}
