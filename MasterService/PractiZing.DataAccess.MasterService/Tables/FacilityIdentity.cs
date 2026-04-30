using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class FacilityIdentity : IFacilityIdentity
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }

        public short FacilityId { get; set; }
        public short TypeId { get; set; }

        [MaxLength(50, ErrorMessage = "Identifier - Must not enter more than 50 characters.")]
        public string Identifier { get; set; }

        public DateTime ActiveDate { get; set; }
        public DateTime? InactiveDate { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public string Prefix { get; set; }

        [Ignore]
        public Guid FacilityUId { get; set; }
    }
}
