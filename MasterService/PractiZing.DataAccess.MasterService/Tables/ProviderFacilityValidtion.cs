using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ProviderFacilityValidtion : IProviderFacilityValidtion
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public short ProviderId { get; set; }
        public short FacilityId { get; set; }

    }
}
