using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class MethaSoftInvoice : IMethaSoftInvoice
    {

        [Key]
        [AutoIncrement]
        public int Id { get; set; }        
        public int EMRPatientId { get; set; }
        public DateTime DosDate { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }
        public string ProviderNPI { get; set; }
        public string CptCode { get; set; }
        public string IcdCodes { get; set; }
        public string POS { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSentToEMR { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SentDateToEMR { get; set; }
        public string Qty { get; set; }
        public string Amount { get; set; }
        public string CptDescription { get; set; }
        public string HL7FileName { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsMatched { get; set; }
    }
}
