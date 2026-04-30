using PractiZing.Base.Object.ReportService;
using PractiZing.DataAccess.Common;
using System;

namespace PractiZing.DataAccess.ReportService.Objects
{
    public class ChargeStatFilter : BaseSearchModel, IChargeStatFilter
    {
        public string StatNames { get; set; }
        //[SearchField(Name = ChargeStatFilterModel.InsuranceCompanyUIds)]
        public string InsuranceCompanyUIds { get; set; }
        // [SearchField(Name = ChargeStatFilterModel.InsuranceCompanyTypeIds)]
        public string InsuranceCompanyTypeIds { get; set; }
        // [SearchField(Name = ChargeStatFilterModel.ReasonCodes)]
        public string ReasonCodes { get; set; }
        // [SearchField(Name = ChargeStatFilterModel.PatientStatementCount)]
        public int PatientStatementCount { get; set; }
        // [SearchField(Name = ChargeStatFilterModel.HasDenial)]
        public bool? HasDenial { get; set; }
        // [SearchField(Name = ChargeStatFilterModel.FromDate)]
        public DateTime? FromDate { get; set; }
        // [SearchField(Name = ChargeStatFilterModel.ToDate)]
        public DateTime? ToDate { get; set; }
        public string FollowCategoryUIds { get; set; }
    }
    public class ChargeStatFilterModel
    {
        public const string InsuranceCompanyUIds = "InsuranceCompany" + "." + "UId";
        public const string InsuranceCompanyTypeIds = "ConfigInsuranceCompanyType" + "." + "Id";
        public const string ReasonCodes = "PaymentAdjustment" + "." + "ReasonCode";
        public const string PatientStatementCount = "Charge" + "." + "PatientStatementCount";
        public const string HasDenial = "ChargeStat" + "." + "HasDenial";
        public const string FromDate = "Voucher" + "." + "EffectiveDate";
        public const string ToDate = "Voucher" + "." + "EffectiveDate";
        public const string FollowCategoryUIds = "ActionCategory" + "." + "UId";
    }
}