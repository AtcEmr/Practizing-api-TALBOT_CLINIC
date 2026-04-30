using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class RefundPaymentDTO : IRefundPaymentDTO
    {
        public Guid UId { get; set; }
        public decimal RefundAmount { get; set; }
        public string Reasons { get; set; }
    }
}
