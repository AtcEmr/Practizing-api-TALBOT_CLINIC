using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IMethaSoftInvoiceForEMRDTO
    {
        string CptCode { get; set; }
        string IcdCode { get; set; }
        int PatientId { get; set; }
        string ProviderNPI { get; set; }
        string POS { get; set; }
        string ErrorMessage { get; set; }
        int BillingMethaSoftInvocieId { get; set; }
        DateTime DOSDate { get; set; }
        string ProviderFirstName { get; set; }
        string ProviderLastName { get; set; }
    }
}
