using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IMethaSoftInvoice 
    {
        int Id { get; set; }
        int EMRPatientId { get; set; }
        DateTime DosDate { get; set; }
        string ProviderFirstName { get; set; }
        string ProviderLastName { get; set; }
        string ProviderNPI { get; set; }
        string CptCode { get; set; }
        string IcdCodes { get; set; }
        string POS { get; set; }
        string ErrorMessage { get; set; }
        bool IsSentToEMR { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? SentDateToEMR { get; set; }
        string Qty { get; set; }
        string Amount { get; set; }
        string CptDescription { get; set; }
        string HL7FileName { get; set; }
        bool? IsDeleted { get; set; }
        bool? IsMatched { get; set; }
    }
}
