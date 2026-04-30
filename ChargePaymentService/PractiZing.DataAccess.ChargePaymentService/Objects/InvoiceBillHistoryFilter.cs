using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class InvoiceBillHistoryFilter : IInvoiceBillHistoryFilter
    {
        [SearchField(Name = InvoiceFilterModel.FromDate)]
        public string FromDate { get; set; }
        [SearchField(Name = InvoiceFilterModel.ToDate)]
        public string ToDate { get; set; }
        public int PatientCaseId { get; set; }
        public string PatientCaseUId { get; set; }
    }

    public class InvoiceFilterModel
    {
        public const string FromDate = "Invoice" + "." + "BillToDate";
        public const string ToDate = "Invoice" + "." + "BillToDate";
        public const string PatientCaseId = "Invoice" + "." + "PatientCaseId";
    }
}
