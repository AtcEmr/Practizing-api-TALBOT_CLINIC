using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PortalPaymentEMRDTO : IPortalPaymentEMRDTO
    {
        public decimal  Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DosDate { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public decimal? RefundAmount { get; set; }
    }

    public class PostedCharges: IPostedCharges
    {
        public int Id { get; set; }
        public decimal OnlinePostedAmount { get; set; }

    }
}
