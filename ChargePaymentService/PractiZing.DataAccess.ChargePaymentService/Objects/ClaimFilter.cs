using PractiZing.Base.Object.ChargePaymentService;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ClaimFilter : IClaimFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int SelectedType { get; set; }
        public int ClearingHouseId { get; set; }
    }
}
