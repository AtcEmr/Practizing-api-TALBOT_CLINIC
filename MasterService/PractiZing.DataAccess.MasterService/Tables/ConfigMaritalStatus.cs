using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigMaritalStatus : IConfigMaritalStatus
    {
        [Key]
        public byte Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
