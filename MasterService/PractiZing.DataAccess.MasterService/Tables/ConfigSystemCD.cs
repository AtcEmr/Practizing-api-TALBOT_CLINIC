using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigSystemCD : IConfigSystemCD
    {
        [Key]
        [MaxLength(50, ErrorMessage = "CD - Must not enter more than 50 characters.")]
        public string CD { get; set; }
        [MaxLength(50, ErrorMessage = "GroupCD - Must not enter more than 50 characters.")]
        public string GroupCD { get; set; }
        [MaxLength(100, ErrorMessage = "Description - Must not enter more than 100 characters.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
