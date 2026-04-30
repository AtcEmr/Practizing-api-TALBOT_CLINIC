using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigServiceType : IConfigServiceType
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public string FieldName { get; set; }
        public string SegmentName { get; set; }
    }
}
