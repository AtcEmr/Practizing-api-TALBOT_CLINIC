using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using System.Collections.Generic;

namespace PractiZing.DataAccess.SecurityService.Objects
{
    public class ModuleDTO : IModuleDTO
    {
        public ModuleDTO()
        {
            this.Modules = new List<PZModule>();
        }
        public bool OverriddenInheritedPermission { get; set; }
        public IEnumerable<IPZModule> Modules { get; set; }
    }
}
