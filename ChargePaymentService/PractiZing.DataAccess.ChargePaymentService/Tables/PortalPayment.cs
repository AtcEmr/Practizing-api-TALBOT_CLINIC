using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PortalPayment : IPortalPayment
    {
        public PortalPayment()
        {
            InvChargeId = new List<PostedCharges>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PatientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PracticeId { get; set; }
        public string ApplicationId { get; set; }
        public string StripeResponse { get; set; }
        public bool IsCommitted { get; set; }
        public string CardId { get; set; }
        public string ReceiptNumber { set; get; }
        public string ResponseJson { get; set; }
        public bool? IsRefund { get; set; }
        public string RefChargeId { get; set; }
        public string ChargeId { get; set; }
        public string Reasons { get; set; }
        public decimal RefundAmount { get; set; }
        public bool? IsRefundNeeded { get; set; }
        public bool? HasRefund { get; set; }
        public int? PaymentId { get; set; }
        public string DosDate { get; set; }
        public string LocationName { get; set; }
        public bool? IsDeleted { get; set; }
        public string Comments { get; set; }
        public decimal? LabAmount { get; set; }
        public int? LabPortalPaymentId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        [Ignore]
        public Guid PatientUId { get; set; }
        [Ignore]
        public string FirstName { get; set; }
        [Ignore]
        public string LastName { get; set; }
        [Ignore]
        public string MobileNumber { get; set; }
        [Ignore]
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
        [Ignore]
        public string PaymentType { get; set; }
        [Ignore]
        public string PaymentMethod { get; set; }
        [Ignore]
        public IEnumerable<IPostedCharges> InvChargeId { get; set; }
        [Ignore]
        public string BillingId { get; set; }
        [Ignore]
        public decimal? PostedAmount { get; set; }
    }
}
