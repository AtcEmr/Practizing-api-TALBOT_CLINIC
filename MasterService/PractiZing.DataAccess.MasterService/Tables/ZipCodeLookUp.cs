using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ZipCodeLookUp : IZipCodeLookUp
    {
        [AutoIncrement]
        public int ID { get; set; }
        public int PracticeId { get; set; }
        [Key]
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AreaCode { get; set; }
        public bool IsActive { get; set; }
    }
}
