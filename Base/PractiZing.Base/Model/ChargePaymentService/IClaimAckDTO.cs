using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IClaimAckDTO
    {
        int Id { get; set; }
        string AccessionNumber { get; set; }
        double TotalBilled { get; set; }
        DateTime? SentDate { get; set; }
        int LabClientID { get; set; }
        int? CaseType { get; set; }
        int InvoiceId { get; set; }
    }
}
