using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IEncounterRulesAllowedCPT
    {
        int Id { get; set; }
        int EncounterRuleId { get; set; }
        string CptCode { get; set; }
        bool Active { get; set; }
    }
}
