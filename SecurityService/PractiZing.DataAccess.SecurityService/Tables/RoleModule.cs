using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService.Tables
{ 
    [Alias("PZ_RoleModule")]
    public class RoleModule : IRoleModule
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
    }
}
