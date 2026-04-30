using PractiZing.Base.Object.ChargePaymentService;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class BatchFilter : IBatchFilter
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public string InsuranceCompanyUId { get; set; }
        public string BatchStatus { get; set; }
    }
}
