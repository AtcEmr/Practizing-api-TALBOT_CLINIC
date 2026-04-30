using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPlaidPayment 
    {
        int Id { get; set; }
        string AccountId { get; set; }
        string AccountOwner { get; set; }
        decimal Amount { get; set; }
        string AuthorizedDate { get; set; }
        string AuthorizedDatetime { get; set; }
        string Category { get; set; }
        string CheckNumber { get; set; }
        string PaymentDate { get; set; }
        string PaymentDatetime { get; set; }
        string IsoCurrencyCode { get; set; }
        string LocationAddress { get; set; }
        string LocationCity { get; set; }
        string LocationCountry { get; set; }
        string LocationLat { get; set; }
        string LocationLon { get; set; }
        string LocationPostalCode { get; set; }
        string LocationRegion { get; set; }
        string LocationStoreNumber { get; set; }
        string MerchantName { get; set; }
        string Name { get; set; }
        string PaymentMetabyOrderOf { get; set; }
        string PaymentMetaPayee { get; set; }
        string PaymentMetaPayer { get; set; }
        string PaymentMetaPaymentMethod { get; set; }
        string PaymentMetaPaymentProcessor { get; set; }
        string PaymentMetaPpdId { get; set; }
        string PaymentMetaReason { get; set; }
        string PaymentMetaReferenceNumber { get; set; }
        bool Pending { get; set; }
        string PendingTransactionId { get; set; }
        string PersonalFinanceCategory { get; set; }
        string TransactionCode { get; set; }
        string TransactionId { get; set; }
        string TransactionType { get; set; }
        string UnofficialCurrencyCode { get; set; }
        string MatchedSource { get; set; }
        int? VoucherId { get; set; }
        string PersonalFinanceCategoryDetailed { get; set; }
        string PersonalFinanceCategoryPrimary { get; set; }

    }
}
