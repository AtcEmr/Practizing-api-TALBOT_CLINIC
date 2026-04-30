using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargeDTO
    {
        int InvoiceId { get; set; }
        string BatchNo { get; set; }
        string AccessionNumber { get; set; }
        DateTime DOS { get; set; }
        string PatientName { get; set; }
        string InsuranceCompanyName { get; set; }
        string OrderingPhysician { get; set; }
        DateTime PostDate { get; set; }
        decimal ChargeAmount { get; set; }
        decimal Interest { get; set; }
        decimal Balance { get; set; }
        string DueByFlagCD { get; set; }
    }
}
