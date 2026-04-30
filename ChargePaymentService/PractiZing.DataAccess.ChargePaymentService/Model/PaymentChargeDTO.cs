using PractiZing.Base.Model.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class PaymentChargeDTO : IPaymentChargeDTO
    {
        public DateTime DOS { get; set; }
        public string CPTCode { get; set; }
        public int ChargeNumber { get; set; }
        public string Mod { get; set; }
        public decimal ChargeAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public bool IsReversed { get; set; }
        private decimal _crChargeAmount;
        public decimal CrChargeAmount
        {
            get
            {
                return this.IsReversed == false ? this.PaidAmount : 0;
            }
            set
            {
                this._crChargeAmount = value == this.PaidAmount ? this.PaidAmount : value;
            }
        }

        private decimal _drChargeAmount;
        public decimal DrChargeAmount
        {
            get
            {
                return this.IsReversed == true ? this.PaidAmount : 0;
            }
            set
            {
                this._drChargeAmount = value == this.PaidAmount ? this.PaidAmount : value;
            }
        }

        public decimal TotalAdjustmentAmount { get; set; }
        public decimal PatientResponsibility { get; set; }
        public decimal NonAccAdjustment { get; set; }
        [Ignore]
        public decimal BonusAmount { get; set; }
        public int PaymentChargeId { get; set; }
        public decimal DifferenceAmount
        {
            get
            {
                return this.ChargeAmount - ((this.CrChargeAmount + this.TotalAdjustmentAmount) + this.DrChargeAmount + this.PatientResponsibility) - this.NonAccAdjustment;
            }
        }

        public string ReasonCode { get; set; }
        public int PaymentId { get; set; }
        public short Quantity { get; set; }
    }
}
