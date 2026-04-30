using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService.Tables
{
    [Alias("PZ_ModulePermission")]
    public class ModulePermission : IModulePermission
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int ModuleId { get; set; }
        [MaxLength(100, ErrorMessage = "PermissionName - Must not enter more than 100 characters.")]
        public string PermissionName { get; set; }
        [Ignore]
        public string ModuleName { get; set; }
    }
}
