using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IClaimBatchFilter
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        int? InsuranceCompanyId { get; set; }
        string InsuranceCompanyUId { get; set; }
        
        int? BillTo { get; set; }
        //int? SelectedType { get; set; }
    }

    public interface IChargeDashboardBatchFilter
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        int? InsuranceCompanyId { get; set; }
        string InsuranceCompanyUId { get; set; }
        string IsActive { get; set; }
        int? BillTo { get; set; }
        //int? SelectedType { get; set; }
    }
    
}
