using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class DenialCategoryReasonCode : IDenialCategoryReasonCode
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int DenialCategoryId { get; set; }
        public string ReasonCode { get; set; }

    }
}
