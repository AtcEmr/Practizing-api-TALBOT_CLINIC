using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IPaymentFilterDTO
    {
        bool IsShowOnlyClaimed { get; set; }
        bool IsShowAllPendingPayment { get; set; }
        bool IsShowAllRecord { get; set; }
        bool IsShowOnlyRecorded { get; set; }
        Guid PatientUId { get; set; }
        Guid VoucherUId { get; set; }
        Guid PaymentUId { get; set; }
    }
}
