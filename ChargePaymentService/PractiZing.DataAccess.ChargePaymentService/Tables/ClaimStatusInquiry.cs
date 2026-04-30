using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ClaimStatusInquiry : IClaimStatusInquiry
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int PracticeId { get; set; }
        public int ClaimId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
