using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ChargeStatementCount : IChargeStatementCount
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ChargeId { get; set; }
        public int StatementCount { get; set; }
        public int PatientStatementId { get; set; }
        public decimal ChargeDueAmount { get; set; }
        public DateTime StatementDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
