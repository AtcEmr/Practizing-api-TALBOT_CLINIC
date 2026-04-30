using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPortalPayment : IPracticeDTO, IUniqueIdentifier
    {
        int Id { get; set; }
        int PatientId { get; set; }
        decimal Amount { get; set; }
        DateTime CreatedDate { get; set; }
        bool IsCommitted { get; set; }

        Guid PatientUId { get; set; }
        string ApplicationId { get; set; }
        string StripeResponse { get; set; }
        string CardId { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        string MobileNumber { get; set; }
        string ReceiptNumber { set; get; }
        string ResponseJson { get; set; }
        bool? IsRefund { get; set; }
        string RefChargeId { get; set; }
        string ChargeId { get; set; }
        string Reasons { get; set; }
        decimal RefundAmount { get; set; }
        bool? IsRefundNeeded { get; set; }
        bool? HasRefund { get; set; }        
        string PaymentType { get; set; }        
        string PaymentMethod { get; set; }
        int? PaymentId { get; set; }        
        string BillingId { get; set; }
        string DosDate { get; set; }
        string LocationName { get; set; }
        decimal? PostedAmount { get; set; }
        IEnumerable<IPostedCharges> InvChargeId { get; set; }
        bool? IsDeleted { get; set; }
        string Comments { get; set; }
        decimal? LabAmount { get; set; }
        int? LabPortalPaymentId { get; set; }
        DateTime? ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}
