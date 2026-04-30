using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPortalPaymentChargesDTO
    {
        string AccessionNumber { get; set; }
        DateTime DOSDate { get; set; }
        string CptCode { get; set; }
        decimal ChargeAmount { get; set; }
        string PerforingProviderName { get; set; }
        decimal PaidAmount { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        int PortalPaymentId { get; set; }
    }
}
