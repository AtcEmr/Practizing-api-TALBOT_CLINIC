using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IInvoiceBillingHistoryDTO
    {
        decimal? TotalCharges { get; set; }
        decimal? TotalPaid { get; set; }
        decimal? DueByPatient { get; set; }
        decimal? DueByinsurance { get; set; }
        decimal? TotalDenialAmount { get; set; }
        int? ChargesCount { get; set; }
        int? PaymentsCount { get; set; }
        decimal? TotalAdjustmentAmount { get; set; }
        decimal? DueByMedicaidPatient { get; set; }

        IEnumerable<IInvoice> Invoices { get; set; }
        IEnumerable<ICharges> Charges { get; set; }
        IEnumerable<IPaymentCharge> PaymentCharges { get; set; }
        IEnumerable<ICharges> RollUpCharges { get; set; }
        IEnumerable<ICharges> DuplicateCharges { get; set; }
        IEnumerable<ICharges> RejectedCharges { get; set; }
    }
}
