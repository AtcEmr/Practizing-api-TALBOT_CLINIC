using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ClaimCharge : IClaimCharge
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ChargeId { get; set; }
        public int ClaimId { get; set; }
        public int? PageNumber { get; set; }
        public string CliaNumber { get; set; }
        public string Mod1 { get; set; }
        public string Mod2 { get; set; }
        public string Mod3 { get; set; }
        public string Mod4 { get; set; }
        [Ignore]
        public int BatchId { get; set; }
        [Ignore]
        public DateTime? SentDate { get; set; }
        [Ignore]
        public string ClaimStatus { get; set; }
        [Ignore]
        public int BatchStatusId { get; set; }
    }
}
