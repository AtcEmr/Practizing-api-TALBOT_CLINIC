using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class EncounterRules : IEncounterRules
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int EncounterTypeId { get; set; }
        public string CptCode { get; set; }
        public string AllowedIcdType { get; set; }
        public string MinimumDuration { get; set; }        
        public bool SupervisorRate { get; set; }
        public bool CredentialBasedRate { get; set; }
        public bool POSRates { get; set; }
        public bool InteractiveComplexity { get; set; }
        public bool SessionModelling { get; set; }
        public bool IsActive { get; set; }
        [Ignore]
        public string EncounterType { get; set; }
    }
}
