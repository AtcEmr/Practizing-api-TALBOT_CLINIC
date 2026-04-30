using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class WriteOffTHCode : IWriteOffTHCode
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAckNeeded { get; set; }
    }
}
