using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPortalPaymentEMRDTO
    {
        decimal Amount { get; set; }
        DateTime CreatedDate { get; set; }
        string DosDate { get; set; }
        string PaymentType { get; set; }
        string PaymentMethod { get; set; }
        string Status { get; set; }
        decimal? RefundAmount { get; set; }        
    }

    public interface IPostedCharges
    {
        int Id { get; set; }
        decimal OnlinePostedAmount { get; set; }

    }
}
