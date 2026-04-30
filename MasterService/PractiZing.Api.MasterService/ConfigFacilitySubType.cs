using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigFacilitySubType : IConfigFacilitySubType
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeValue { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; }
    }
}
