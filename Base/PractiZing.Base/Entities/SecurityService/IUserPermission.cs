using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IUserPermission : IStamp
    {
        int Id { get; set; }
        int UserId { get; set; }
        int ModulePermissionId { get; set; }
        bool HasPermission { get; set; }
        string PermissionName { get; set; }
        string ModuleName { get; set; }
        int ModuleId { get; set; }
        int RoleId { get; set; }
    }
}
