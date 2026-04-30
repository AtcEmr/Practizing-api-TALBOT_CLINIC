using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ERAService
{
    public interface IClaimChargeTotalDTO
    {
        decimal TotalBilledAmount { get; set; }
        decimal TotalAllowedDed { get; set; }
        decimal TotalDed { get; set; }
        decimal TotalCoPay { get; set; }
        decimal TotalCoIns { get; set; }
        decimal TotalLastFilled { get; set; }
        decimal TotalAdjustments { get; set; }
        decimal TotalPrevPaid { get; set; }
    }
}
