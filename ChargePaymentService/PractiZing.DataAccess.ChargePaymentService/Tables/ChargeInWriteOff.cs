using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ChargeInWriteOff : IChargeInWriteOff
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ChargeId { get; set; }
        public int StatusId { get; set; }
        public string ReasonCode { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsPosted { get; set; }
    }
}
