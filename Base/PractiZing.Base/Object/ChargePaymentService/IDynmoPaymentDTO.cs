using System;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IDynmoPaymentDTO
    {
        int Id { get; set; }
        string AccountNumber { get; set; }
        string Amount { get; set; }
        string DOB { get; set; }
        string TransactionDate { get; set; }
    }
}
