using PractiZing.Base.Object.ChargePaymentService;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PaymentFilterDTO : IPaymentFilterDTO
    {
        public bool IsShowOnlyClaimed { get; set; }
        public bool IsShowAllPendingPayment { get; set; }
        public bool IsShowOnlyRecorded { get; set; }
        public bool IsShowAllRecord { get; set; }
        public Guid PatientUId { get; set; }
        public Guid VoucherUId { get; set; }
        public Guid PaymentUId { get; set; }
    }
}
