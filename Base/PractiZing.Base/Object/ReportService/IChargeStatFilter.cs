using System;

namespace PractiZing.Base.Object.ReportService
{
    public interface IChargeStatFilter
    {
        string StatNames { get; set; }
        string InsuranceCompanyUIds { get; set; }
        string InsuranceCompanyTypeIds { get; set; }
        string FollowCategoryUIds { get; set; }
        string ReasonCodes { get; set; }
        int PatientStatementCount { get; set; }
        bool? HasDenial { get; set; }
        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }
    }
}
