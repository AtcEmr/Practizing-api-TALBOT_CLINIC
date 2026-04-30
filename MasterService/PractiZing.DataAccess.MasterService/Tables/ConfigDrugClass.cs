using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigDrugClass : IConfigDrugClass
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public string CptCode { get; set; }
        public string SubCPTCode { get; set; }        
    }
}
