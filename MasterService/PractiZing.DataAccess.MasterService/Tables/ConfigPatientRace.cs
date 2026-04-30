using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigPatientRace : IConfigPatientRace
    {
        [Key]
        public int Id { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string CodeSystem { get; set; }
        public string ExternalID { get; set; }
    }
}
