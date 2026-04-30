using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class PaymentBatchDTO : IPaymentBatchDTO
    {
        public PaymentBatchDTO()
        {
            this.Voucher = new Voucher();
            this.Charges = new List<Charges>();
        }

        public string BatchNo { get; set; }
        public string AccessionNumber { get; set; }
        public decimal BatchAmount { get; set; }
        public decimal TotalPayableAmount { get; set; }
        public decimal DifferenceAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalAdjustmentAmount { get; set; }
        public bool IsChanged { get; set; }
        public bool IsReversed { get; set; }
        public bool IsNewPayment { get; set; }
        public Guid InvoiceUId { get; set; }
        public Guid VoucherUId { get; set; }
        public Guid ChargeBatchUId { get; set; }
        public Guid PatientUId { get; set; }
        public Guid PaymentUId { get; set; }
        public Guid? DepositInsuranceCompanyUId { get; set; }
        public Guid? PatientInsuranceCompanyUId { get; set; }
        public string PayorControl { get; set; }

        public IVoucher Voucher { get; set; }
        public IEnumerable<ICharges> Charges { get; set; }
    }
}
