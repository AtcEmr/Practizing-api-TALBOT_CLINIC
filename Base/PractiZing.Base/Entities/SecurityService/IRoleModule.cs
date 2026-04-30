using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IRoleModule
    {
        int Id { get; set; } 
        int RoleId { get; set; }
        int ModuleId { get; set; }
    }
}
