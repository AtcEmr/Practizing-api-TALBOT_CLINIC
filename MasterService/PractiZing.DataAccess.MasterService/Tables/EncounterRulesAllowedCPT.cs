using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class EncounterRulesAllowedCPT : IEncounterRulesAllowedCPT
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int EncounterRuleId { get; set; }
        public string CptCode { get; set; }
        public bool Active { get; set; }
    }
}
