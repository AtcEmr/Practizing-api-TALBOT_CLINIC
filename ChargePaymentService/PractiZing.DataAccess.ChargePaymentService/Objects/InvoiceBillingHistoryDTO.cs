using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class InvoiceBillingHistoryDTO : IInvoiceBillingHistoryDTO
    {
        public InvoiceBillingHistoryDTO()
        {
            this.Invoices = new List<Invoice>();
            this.Charges = new List<ChargeViewDTO>();
            this.RollUpCharges = new List<ChargeViewDTO>();
            this.PaymentCharges = new List<PaymentCharge>();
            this.DuplicateCharges = new List<ChargeViewDTO>();
            this.MedicaidPatientCharges = new List<ChargeViewDTO>();
        }

        public decimal? TotalCharges { get; set; }
        public decimal? TotalPaid { get; set; }
        public decimal? DueByPatient { get; set; }
        public decimal? DueByMedicaidPatient { get; set; }
        public decimal? DueByinsurance { get; set; }
        public decimal? TotalDenialAmount { get; set; }
        public int? ChargesCount { get; set; }
        public int? PaymentsCount { get; set; }
        public decimal? TotalAdjustmentAmount { get; set; }

        public IEnumerable<IInvoice> Invoices { get; set; }
        public IEnumerable<ICharges> Charges { get; set; }
        public IEnumerable<IPaymentCharge> PaymentCharges { get; set; }
        public IEnumerable<ICharges> RollUpCharges { get; set; }
        public IEnumerable<ICharges> DuplicateCharges { get; set; }
        public IEnumerable<ICharges> RejectedCharges { get; set; }
        public IEnumerable<ICharges> MedicaidPatientCharges { get; set; }
    }
}
