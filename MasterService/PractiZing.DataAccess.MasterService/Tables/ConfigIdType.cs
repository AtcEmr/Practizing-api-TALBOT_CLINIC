using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigIdType : IConfigIdType
    {
        [Key]
        [AutoIncrement]
        public short Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name - Must not enter more than 50 characters.")]
        public string Name { get; set; }
        [MaxLength(2, ErrorMessage = "Prefix - Must not enter more than 2 characters.")]
        public string Prefix { get; set; }
        public bool Active { get; set; }
    }
}
