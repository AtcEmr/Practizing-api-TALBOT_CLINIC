using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.PatientService
{
    public interface IHL7StatusFilter
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        IEnumerable<string> AccessionNumber { get; set; }
        string BillingId { get; set; }
    }
}
