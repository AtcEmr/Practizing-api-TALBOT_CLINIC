using PractiZing.Base.Entities.BatchPaymentService;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.DataAccess.Common;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.BatchPaymentService.Tables
{
    public class ClaimBatch : IClaimBatch
    {

        public ClaimBatch()
        {
            this.Claims = new List<Claim>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int? ClearingHouseId { get; set; }
        public DateTime DateMade { get; set; }
        public string UserName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime? FirstSent { get; set; }
        public DateTime? LastSent { get; set; }
        public int ClaimCount { get; set; }
        public decimal Total { get; set; }
        public int ScrubStatus { get; set; }
        public DateTime? ScrubSent { get; set; }
        public int BatchStatus { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string FilePath { get; set; }
        public string ClaimBatchNumber { get; set; }
        public int? ProviderId { get; set; }
        public int? InsuranceCompanyId { get; set; }

        [Ignore]
        public string FullFilePath { get; set; }
        [Ignore]
        public string FullFileText { get; set; }
        [Ignore]
        public IEnumerable<IClaim> Claims { get; set; }

        //[Ignore]
        //public bool ShouldBePrint { get; set; }

        //[Ignore]
        //public string ClearingHouse { get; set; }
        //[Ignore]
        //public string Carrier { get; set; }
    }
}
