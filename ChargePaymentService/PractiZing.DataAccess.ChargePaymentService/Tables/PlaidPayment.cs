using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PlaidPayment : IPlaidPayment
    {
        public PlaidPayment()
        {
            
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }

        public string AccountId { get; set; }
        public string AccountOwner { get; set; }
        public decimal Amount { get; set; }
        public string AuthorizedDate { get; set; }
        public string AuthorizedDatetime { get; set; }
        public string Category { get; set; }
        public string CheckNumber { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentDatetime { get; set; }
        public string IsoCurrencyCode { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        public string LocationLat { get; set; }
        public string LocationLon { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationRegion { get; set; }
        public string LocationStoreNumber { get; set; }
        public string MerchantName { get; set; }
        public string Name { get; set; }
        public string PaymentMetabyOrderOf { get; set; }
        public string PaymentMetaPayee { get; set; }
        public string PaymentMetaPayer { get; set; }
        public string PaymentMetaPaymentMethod { get; set; }
        public string PaymentMetaPaymentProcessor { get; set; }
        public string PaymentMetaPpdId { get; set; }
        public string PaymentMetaReason { get; set; }
        public string PaymentMetaReferenceNumber { get; set; }
        public bool Pending { get; set; }
        public string PendingTransactionId { get; set; }
        public string PersonalFinanceCategory { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string UnofficialCurrencyCode { get; set; }
        public string MatchedSource { get; set; }
        public int? VoucherId { get; set; }
        public string PersonalFinanceCategoryDetailed { get; set; }
        public string PersonalFinanceCategoryPrimary { get; set; }
    }
}
