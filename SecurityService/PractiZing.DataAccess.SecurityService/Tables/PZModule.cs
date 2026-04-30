using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService.Tables
{
    [Alias("PZ_Module")]
    public class PZModule : IPZModule
    {
        public PZModule()
        {
            this.ModulePermissions = new List<ModulePermission>();
            this.UserPermissions = new List<UserPermission>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "ModuleName - Must not enter more than 50 characters.")]
        public string ModuleName { get; set; }
        [MaxLength(50, ErrorMessage = "MenuLinkName - Must not enter more than 50 characters.")]
        public string MenuLinkName { get; set; }
        [Ignore]
        public IEnumerable<IModulePermission> ModulePermissions { get; set; }
        [Ignore]
        public IEnumerable<IUserPermission> UserPermissions { get; set; }
        [Ignore]
        public bool HasPermission { get; set; }
    }
}
