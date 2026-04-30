using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigRelationship : IConfigRelationship
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public bool GuarantorVisible { get; set; }
        public bool PolicyHolderVisible { get; set; }
        public string RelationshipCode { get; set; }
        public bool IsActive { get; set; }
    }
}
