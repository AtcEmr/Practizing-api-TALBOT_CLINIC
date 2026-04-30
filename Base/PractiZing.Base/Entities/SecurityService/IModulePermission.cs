using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IModulePermission
    {
        int Id { get; set; }
        int ModuleId { get; set; }
        string PermissionName { get; set; }
        string ModuleName { get; set; }
    }
}
