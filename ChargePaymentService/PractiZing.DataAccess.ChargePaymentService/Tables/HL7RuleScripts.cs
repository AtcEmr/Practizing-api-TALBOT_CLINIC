using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class HL7RuleScripts : IHL7RuleScripts
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string SqlStatement { get; set; }
        public bool IsActive { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
    }
}
