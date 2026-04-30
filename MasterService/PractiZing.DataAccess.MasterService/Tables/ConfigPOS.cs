using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigPOS : IConfigPOS
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? Facility { get; set; }
        public bool IsActive { get; set; }
    }
}
