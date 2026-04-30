using Amazon.DynamoDBv2.DataModel;
using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    [DynamoDBTable("HELPDESK-PAYMENTS")]
    public class HistoryPayment : IHistoryPayment
    {
        [DynamoDBProperty("ID")]
        [DynamoDBHashKey]
        public string ID { get; set; }

        [DynamoDBProperty("AccountNumber")]
        public string AccountNumber { get; set; }

        [DynamoDBProperty("Amount")]
        public string Amount { get; set; }

        [DynamoDBProperty("Date")]
        public string Date { get; set; }

        [DynamoDBProperty("DOB")]
        public string DOB { get; set; }

        [DynamoDBProperty("PaymentConfirmationCode")]
        public string PaymentConfirmationCode { get; set; }

        [DynamoDBProperty("Phone")]
        public string Phone { get; set; }

        [DynamoDBProperty("TransactionID")]
        public string TransactionID { get; set; }

        [DynamoDBProperty("IsExported")]
        public string IsExported { get; set; }

    }
}
