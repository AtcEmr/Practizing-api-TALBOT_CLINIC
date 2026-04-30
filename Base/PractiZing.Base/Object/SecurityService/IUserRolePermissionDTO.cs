using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;

namespace PractiZing.Base.Object.SecurityService
{
    public interface IUserRolePermissionDTO
    {
        int UserId { get; set; }
        IEnumerable<IUserRole> UserRoles { get; set; }
        IEnumerable<IUserPermission> UserPermissions { get; set; }
        bool OverriddenInheritedPermission { get; set; }
    }
}
