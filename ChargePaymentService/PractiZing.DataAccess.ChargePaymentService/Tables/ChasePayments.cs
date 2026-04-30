using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ChasePayments : IChasePayments
    {
        public ChasePayments()
        {
            PaymentDTOs = new List<IBankReconciliation>();
        }
        [Key]
        [AutoIncrement]
        public int Id { get; set; }        
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public string Details { get; set; }
        public DateTime PostingDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string ChaseType { get; set; }
        public decimal? Balance { get; set; }
        public string CheckOrSlip { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsOwnerDeposit { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public IEnumerable<IBankReconciliation> PaymentDTOs { get; set; }
        [Ignore]
        public decimal? PaymentAmount { get; set; }
        [Ignore]
        public decimal? DiffAmount { get; set; }
        [Ignore]
        public string CheckNumber { get; set; }
    }
}
