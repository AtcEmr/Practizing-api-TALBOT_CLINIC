using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class Scrub : IScrub
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DestinationId { get; set; }
        public bool Active { get; set; }

        public short Priority { get; set; }
        public short Order { get; set; }

        public string StoredProcedure { get; set; }

        //public bool IsProcedure { get; set; }

        //public bool IsPracticeCentral { get; set; }
        //public bool IsAutoScrub { get; set; }

        [Ignore]
        public short ScrubStatus { get; set; }
    }
}
