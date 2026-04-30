using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ClaimBatchFilter : IClaimBatchFilter
    {
        [SearchField(Name = ClaimBatchFilterModel.FromDate)]
        public string FromDate { get; set; }
        [SearchField(Name = ClaimBatchFilterModel.ToDate)]
        public string ToDate { get; set; }
        public int? InsuranceCompanyId { get; set; }        
        public int? BillTo { get; set; }
        //public int? SelectedType { get; set; }
        public string InsuranceCompanyUId { get; set; }
    }

    public class ClaimBatchFilterModel
    {
        public const string FromDate = "vw_GetChargeForPendingPayment" + "." + "CreatedDate";
        public const string ToDate = "vw_GetChargeForPendingPayment" + "." + "CreatedDate";
        public const string IsActive = "ChargeBatch" + "." + "IsActive";
        public const string InsuranceCompanyID = "InsurancePolicy" + "." + "InsuranceCompanyID";
    }

    public class ChargeDashboardBatchFilter : IChargeDashboardBatchFilter
    {
        [SearchField(Name = ChargeDashboardBatchFilterModel.FromDate)]
        public string FromDate { get; set; }
        [SearchField(Name = ChargeDashboardBatchFilterModel.ToDate)]
        public string ToDate { get; set; }
        public int? InsuranceCompanyId { get; set; }
        [SearchField(Name = ChargeDashboardBatchFilterModel.IsActive)]
        public string IsActive { get; set; }
        public int? BillTo { get; set; }
        //public int? SelectedType { get; set; }
        public string InsuranceCompanyUId { get; set; }
    }

    public class ChargeDashboardBatchFilterModel
    {
        public const string FromDate = "vw_GetChargeForPendingPayment" + "." + "CreatedDate";
        public const string ToDate = "vw_GetChargeForPendingPayment" + "." + "CreatedDate";
        public const string IsActive = "vw_GetChargeForPendingPayment" + "." + "IsActive";
        public const string InsuranceCompanyID = "InsurancePolicy" + "." + "InsuranceCompanyID";
    }
}
