using PractiZing.Base.Object.DenialService;
using PractiZing.Base.Object.ERAService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ERAService.Object
{
    public class ClaimChargeTotalDTO : IClaimChargeTotalDTO
    {
        public decimal TotalBilledAmount { get; set; }
        public decimal TotalAllowedDed { get; set; }
        public decimal TotalDed { get; set; }
        public decimal TotalCoPay { get; set; }
        public decimal TotalCoIns { get; set; }
        public decimal TotalLastFilled { get; set; }
        public decimal TotalAdjustments { get; set; }
        public decimal TotalPrevPaid { get; set; }
    }
}
