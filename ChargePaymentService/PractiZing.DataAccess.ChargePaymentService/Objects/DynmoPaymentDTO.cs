using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class DynmoPaymentDTO : IDynmoPaymentDTO
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Amount { get; set; }
        public string DOB { get; set; }
        public string TransactionDate { get; set; }
    }
}
