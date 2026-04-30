using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class MethaSoftInvoiceForEMRDTO : IMethaSoftInvoiceForEMRDTO
    {
        public string CptCode { get; set; }
        public string IcdCode { get; set; }        
        public int PatientId { get; set; }
        public string ProviderNPI { get; set; }
        public string POS { get; set; }
        public string ErrorMessage { get; set; }
        public int BillingMethaSoftInvocieId { get; set; }
        public DateTime DOSDate { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }

    }
}
