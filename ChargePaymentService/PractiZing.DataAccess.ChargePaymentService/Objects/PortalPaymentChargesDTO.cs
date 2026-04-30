using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PortalPaymentChargesDTO : IPortalPaymentChargesDTO
    {
        public string AccessionNumber { get; set; }
        public DateTime DOSDate { get; set; }
        public string CptCode { get; set; }
        public decimal ChargeAmount { get; set; }
        public string PerforingProviderName { get; set; }
        public decimal PaidAmount { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int PortalPaymentId { get; set; }


    }
}
