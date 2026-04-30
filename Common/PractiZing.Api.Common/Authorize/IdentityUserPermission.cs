using PractiZing.Base.Entities.SecurityService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Api.Common.Authorize
{
    public class IdentityUserPermission : IUserPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModulePermissionId { get; set; }
        public bool HasPermission { get; set; }
        public string PermissionName { get; set; }
        public string ModuleName { get; set; }
        public bool OverriddenInheritedPermission { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModuleId { get; set; }
        public int RoleId { get; set; }

    }
}
