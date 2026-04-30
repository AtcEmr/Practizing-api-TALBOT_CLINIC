using PractiZing.Base.Entities.SecurityService;
using System.Collections.Generic;

namespace PractiZing.Base.Object.SecurityService
{
    public interface IModuleDTO
    {
        bool OverriddenInheritedPermission { get; set; }
        IEnumerable<IPZModule> Modules { get; set; }
    }
}
