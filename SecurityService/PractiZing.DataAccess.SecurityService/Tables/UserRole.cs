using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService
{
    [Alias("PZ_UserRole")]
    public class UserRole : IUserRole
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public Int16 UserId { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public bool IsAssigned { get; set; } = true;
        [Ignore]
        public string RoleName { get; set; }
    }
}
