using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargePaymentBillingHistoryFilter : IChargePaymentBillingHistoryFilter
    {
        [SearchField(Name = ChargeFilterModel.FromDate)]
        public string FromDate { get; set; }
        [SearchField(Name = ChargeFilterModel.ToDate)]
        public string ToDate { get; set; }
        public int ChargesFilter { get; set; }
        public int PatientCaseId { get; set; }
        [SearchField(Name = ChargeFilterModel.InvoiceId)]
        public int? InvoiceId { get; set; }
        public int? isDOSSelected { get; set; }
        public int? isPayment { get; set; }
        public string PatientCaseUId { get; set; }
        public string InvoiceUId { get; set; }
    }

    public class ChargeFilterModel
    {
        public const string FromDate = "vw_GetChargeForPendingPayment" + "." + "BillToDate";
        public const string ToDate = "vw_GetChargeForPendingPayment" + "." + "BillToDate";
        public const string InvoiceId = "vw_GetChargeForPendingPayment" + "." + "InvoiceId";
        public const string PatientCaseId = "vw_GetChargeForPendingPayment" + "." + "PatientCaseId";
    }
}
