using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService.Tables
{
    [Alias("PZ_Role")]
    public class Role : IRole
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "RoleName - Must not enter more than 50 characters.")]
        public string RoleName { get; set; }
    }
}
