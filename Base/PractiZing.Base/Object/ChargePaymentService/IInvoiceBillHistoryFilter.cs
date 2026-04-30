using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IInvoiceBillHistoryFilter
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        int PatientCaseId { get; set; }
        string PatientCaseUId { get; set; }
    }
}
