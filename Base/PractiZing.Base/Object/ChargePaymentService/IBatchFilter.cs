using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IBatchFilter
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        int? InsuranceCompanyId { get; set; }
        string InsuranceCompanyUId { get; set; }
        string BatchStatus { get; set; }
    }
}

