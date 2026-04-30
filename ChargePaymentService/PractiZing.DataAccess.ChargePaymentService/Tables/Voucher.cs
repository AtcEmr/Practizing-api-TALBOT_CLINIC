using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class Voucher : IVoucher
    {
        public Voucher()
        {
            this.Payments = new List<Payment>();
            this.PatientCaseId = new List<int>();
            this.AttFiles = new List<AttFile>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public int PaymentBatchId { get; set; }
        public int VoucherNo { get; set; }
        public string VoucherTypeCD { get; set; }
        public string PaymentSourceCD { get; set; }
        public Int16 DepositTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime ReferenceDate { get; set; }
        public bool IsSelfPayment { get; set; }
        public int? PatientId { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public bool IsCommitted { get; set; }
        // public string PayorClaimControlNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsMatchedWithBank { get; set; }
        
        [Ignore]
        public string InsuranceCompanyName { get; set; }

        [Ignore]
        public IEnumerable<IPayment> Payments { get; set; }
        [Ignore]
        public IEnumerable<int> PatientCaseId { get; set; }
        [Ignore]
        public string PatientName
        {
            get
            {
                return $"{PatientFirstName}  {PatientLastName}";
            }
        }
        [Ignore]
        public string PatientFirstName { get; set; }
        [Ignore]
        public string PatientLastName { get; set; }
        [Ignore]
        public decimal TotalPaymentsInVoucher { get; set; }
        [Ignore]
        public decimal PaymentBatchAmount { get; set; }
        [Ignore]
        public decimal TotalPaidAmountInVoucher { get; set; }
        [Ignore]
        public IEnumerable<IAttFile> AttFiles { get; set; }
        [Ignore]
        public Guid DepositTypeUId { get; set; }
        [Ignore]
        public Guid PatientCaseUId { get; set; }
        [Ignore]
        public Guid PatientUId { get; set; }
        [Ignore]
        public Guid PaymentBatchUId { get; set; }
        [Ignore]
        public Guid DepositInsuranceCompanyUId { get; set; }
        
    }
}
