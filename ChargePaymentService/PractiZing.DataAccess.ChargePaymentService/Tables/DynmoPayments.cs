using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class DynmoPayments : IDynmoPayments
    {

        public DynmoPayments()
        {
            
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }

        public string AccountNumber { get; set; }
        public string  Amount { get; set; }
        public string DOB { get; set; }
        public string TransactionDate { get; set; }
        public string HistoryPaymentId { get; set; }
        public bool IsBadRecord { get; set; }
        public string PaymentConfirmationCode { get; set; }
        public string Phone { get; set; }
        public string TransactionId { get; set; }
        public bool IsImportInBilling { get; set; }
        public string BillingServiceProvider { get; set; }
        public DateTime? ImportDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime? NotificationDate { get; set; }
        public bool? IsBadRecordFromCatalystRCM { get; set; }
        public string EmrAccountNumber { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethod { get; set; }
        public int? PortalPaymentId { get; set; }
        public bool? IsSendToEMR { get; set; }
        public string DosDate { get; set; }
        public string LocationName { get; set; }
        [Ignore]
        public string PaymentMethodText { get; set; }
    }
}
