using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IVoucherViewFilter
    {        
        string FromDate { get; set; }
        string ToDate { get; set; }        
        int? InsuranceCompanyId { get; set; }
    }
}
