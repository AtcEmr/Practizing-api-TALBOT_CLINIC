using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IDynmoPayments : IStamp
    {
        int Id { get; set; }
        string AccountNumber { get; set; }
        string Amount { get; set; }
        string DOB { get; set; }
        string TransactionDate { get; set; }
        string HistoryPaymentId { get; set; }
        bool IsBadRecord { get; set; }
        string PaymentConfirmationCode { get; set; }
        string Phone { get; set; }
        string TransactionId { get; set; }
        bool IsImportInBilling { get; set; }
        string BillingServiceProvider { get; set; }
        DateTime? ImportDate { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string ErrorMessage { get; set; }
        DateTime? NotificationDate { get; set; }
        bool? IsBadRecordFromCatalystRCM { get; set; }
        string EmrAccountNumber{ get; set; }
        string PaymentType { get; set; }
        string PaymentMethod{ get; set; }
        int? PortalPaymentId { get; set; }
        bool? IsSendToEMR { get; set; }
        string DosDate { get; set; }
        string LocationName { get; set; }
        string PaymentMethodText { get; set; }
    }
}
