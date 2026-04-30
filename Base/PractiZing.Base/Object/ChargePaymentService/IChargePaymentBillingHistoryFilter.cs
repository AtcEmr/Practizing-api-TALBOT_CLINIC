using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargePaymentBillingHistoryFilter
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        int PatientCaseId { get; set; }
        int? InvoiceId { get; set; }
        int ChargesFilter { get; set; }
        int? isDOSSelected { get; set; }
        int? isPayment { get; set; }
        string PatientCaseUId { get; set; }
        string InvoiceUId { get; set; }
    }
}
