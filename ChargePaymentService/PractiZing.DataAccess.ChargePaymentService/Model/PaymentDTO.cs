using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class PaymentDTO : IPaymentDTO
    {

        public PaymentDTO()
        {
            this.ChargeDTOs = new List<PaymentChargeDTO>();
            this.Voucher = new Voucher();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public decimal TotalChargeAmount { get; set; }
        public decimal TotalCrChargeAmount { get; set; }
        public decimal TotalDrChargeAmount { get; set; }
        public decimal TotalAdjustmentAmount { get; set; }
        public decimal PatientResponsibility { get; set; }
        public decimal NonAccAdjustment { get; set; }
        [Ignore]
        public decimal BonusAmount { get; set; }
        public decimal DifferenceAmount
        {
            get;
            set;
        }

        public int VoucherId { get; set; }
        public int PaymentId { get; set; }
        public decimal PaidAmount { get; set; }
        public bool IsReversed { get; set; }
        public bool IsCommitted { get; set; }
        public Guid PaymentGUId { get; set; }

        public IEnumerable<IPaymentChargeDTO> ChargeDTOs { get; set; }
        public IVoucher Voucher { get; set; }
        public Guid VoucherUId { get; set; }
        public Guid PatientUId { get; set; }
        [Ignore]
        public Guid PatientCaseUId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
