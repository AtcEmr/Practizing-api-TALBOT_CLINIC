using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService.Tables
{
    [Alias("PZ_UserPermission")]
    public class UserPermission : IUserPermission
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ModulePermissionId { get; set; }
        public bool HasPermission { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public string PermissionName { get; set; }
        [Ignore]
        public string ModuleName { get; set; }
        [Ignore]
        public int ModuleId { get; set; }
        [Ignore]
        public int RoleId{ get; set; }
    }
}
