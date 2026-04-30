using System;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IHistoryPayment
    {
        string ID { get; set; }
        string AccountNumber { get; set; }
        string Amount { get; set; }
        string Date { get; set; }
        string DOB { get; set; }
        string PaymentConfirmationCode { get; set; }
        string Phone { get; set; }
        string TransactionID { get; set; }
    }
}
