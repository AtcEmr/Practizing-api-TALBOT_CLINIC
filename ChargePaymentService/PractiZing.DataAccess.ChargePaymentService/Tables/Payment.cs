using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class Payment : IPayment
    {

        public Payment()
        {
            this.PaymentAdjustments = new List<PaymentAdjustment>();
            this.PaymentCharges = new List<PaymentCharge>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int VoucherId { get; set; }
        public int TransactionNo { get; set; }
        public int PatientId { get; set; }
        public bool IsCommitted { get; set; }
        public decimal Amount { get; set; }
        public decimal Adjustment { get; set; }
        public decimal NonAccAdjustment { get; set; }
        public bool IsReversed { get; set; }
        public string PaymentSourceCD { get; set; }
        public int? DepositInsuranceCompanyId { get; set; }
        public int PatientInsuranceCompanyId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PayorControl { get; set; }
        public bool? IsSendAck { get; set; }
        public string DeleteComments { get; set; }
        [Ignore]
        public IEnumerable<IPaymentCharge> PaymentCharges { get; set; }
        [Ignore]
        public IEnumerable<IPaymentAdjustment> PaymentAdjustments { get; set; }
        [Ignore]
        public string PatientName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        [Ignore]
        public string FirstName { get; set; }
        [Ignore]
        public string LastName { get; set; }
        [Ignore]
        public Guid? DepositInsuranceCompanyUId { get; set; }
        [Ignore]
        public Guid PatientInsuranceCompanyUId { get; set; }
        [Ignore]
        public string PatientControlNumber { get; set; }
    }
}
