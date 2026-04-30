using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using System.Collections.Generic;

namespace PractiZing.DataAccess.SecurityService.Objects
{
    public class UserRolePermissionDTO : IUserRolePermissionDTO
    {
        public UserRolePermissionDTO()
        {
            this.UserRoles = new List<UserRole>();
            this.UserPermissions = new List<UserPermission>();
        }

        public int UserId { get; set; }
        public IEnumerable<IUserRole> UserRoles { get; set; }
        public IEnumerable<IUserPermission> UserPermissions { get; set; }
        public bool OverriddenInheritedPermission { get; set; }
    }
}
