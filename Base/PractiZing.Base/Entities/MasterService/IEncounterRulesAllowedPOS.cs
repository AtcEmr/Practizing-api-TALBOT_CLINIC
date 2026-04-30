using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IEncounterRulesAllowedPOS
    {
        int Id { get; set; }
        int EncounterRuleId { get; set; }
        string PosId { get; set; }
        bool Active { get; set; }
    }
}
