using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IClaimFilter
    {
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        int SelectedType { get; set; }
        int ClearingHouseId { get; set; }
    }
}

