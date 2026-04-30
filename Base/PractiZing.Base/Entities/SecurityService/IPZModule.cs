using System.Collections.Generic;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IPZModule
    {
        int Id { get; set; }
        string ModuleName { get; set; }
        string MenuLinkName { get; set; }
        IEnumerable<IModulePermission> ModulePermissions { get; set; }
        IEnumerable<IUserPermission> UserPermissions { get; set; }
        bool HasPermission { get; set; }
    }
}
