using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigBillType : IConfigBillType
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Value { get; set; }
    }
}
