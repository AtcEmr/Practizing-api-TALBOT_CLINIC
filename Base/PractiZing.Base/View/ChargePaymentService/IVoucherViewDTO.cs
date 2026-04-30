using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.View.ChargePaymentService
{
    public interface IVoucherViewDTO
    {
        string CompanyName { get; set; }
        string CheckNumber { get; set; }
        string DepositType { get; set; }
        DateTime EffectiveDate { get; set; }
        decimal CheckAmount { get; set; }
        decimal PostedAmount { get; set; }
        int InsuranceCompanyId { get; set; }
    }
}
