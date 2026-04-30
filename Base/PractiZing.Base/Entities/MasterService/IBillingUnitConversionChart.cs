using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IBillingUnitConversionChart
    {
        int Id { get; set; }
        short MinimumMinutes { get; set; }
        short MaximumMinutes { get; set; }
        short BillingUnit { get; set; }
    }
}
