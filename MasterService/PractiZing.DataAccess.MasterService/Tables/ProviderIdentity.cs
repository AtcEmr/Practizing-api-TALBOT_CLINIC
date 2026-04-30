using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ProviderIdentity : IProviderIdentity
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }

        public short ProviderId { get; set; }
        public short TypeId { get; set; }

        [MaxLength(50, ErrorMessage = "Identifier - Must not enter more than 50 characters.")]
        public string Identifier { get; set; }

        [System.ComponentModel.DataAnnotations.Range(typeof(DateTime), "2/1/1753", "12/30/9999", ErrorMessage = "Date is out of Range")]
        public DateTime ActiveDate { get; set; }
        public DateTime? InactiveDate { get; set; }

        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public Guid ProviderUId { get; set; }
    }
}
