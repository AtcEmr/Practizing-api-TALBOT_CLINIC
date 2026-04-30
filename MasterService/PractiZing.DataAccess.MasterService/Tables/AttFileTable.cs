using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class AttFileTable : IAttFileTable
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public string TableName { get; set; }
    }
}
