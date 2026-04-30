using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IScrubError
    {
        int Id { get; set; }
        int ClaimId { get; set; }
        int InvoiceId { get; set; }
        Guid InvoiceUId { get; set; }
        DateTime ScrubDateTime { get; set; }
        bool HasError { get; set; }
        string ErrorJson { get; set; }
        int PatientId { get; set; }
        Guid PatientUId { get; set; }
        int ChargeId { get; set; }
        string ScrubName { get; set; }
        string AccessionNumber { get; set; }
        string ErrorMessage { get; set; }
    }
}
