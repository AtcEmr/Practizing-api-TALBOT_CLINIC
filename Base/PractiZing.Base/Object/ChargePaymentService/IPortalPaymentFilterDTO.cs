using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPortalPaymentFilterDTO
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        string IsCommitted { get; set; }
        string IsRefundedRecord { get; set; }
    }

    public interface IDynmoPaymentFilterDTO
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        string IsImportInBilling{ get; set; }
    }

    public interface IChargesReportDataFilterDTO
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        int IsPostOrDosDate { get; set; }
        string ReasonCode { get; set; }
        string PerformingProviderUId { get; set; }
        string InsuranceCompanyUId { get; set; }
    }

    public interface IPaymentReportDataFilterDTO
    {
        string FromDate { get; set; }
        string ToDate { get; set; }        
    }
}
