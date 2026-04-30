using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ChasePaymentChild : IChasePaymentChild
    {

        [Key]
        [AutoIncrement]
        public int Id { get; set; }        
        public int ChasePaymentId { get; set; }
        public int BankReconciliationId { get; set; }        
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
