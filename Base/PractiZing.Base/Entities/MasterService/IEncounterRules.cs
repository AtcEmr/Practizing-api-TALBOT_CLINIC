using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IEncounterRules
    {
        int Id { get; set; }
        int EncounterTypeId { get; set; }
        string EncounterType { get; set; }
        string CptCode { get; set; }
        string AllowedIcdType { get; set; }
        string MinimumDuration { get; set; }
        bool SupervisorRate { get; set; }
        bool CredentialBasedRate { get; set; }
        bool POSRates { get; set; }
        bool InteractiveComplexity { get; set; }
        bool SessionModelling { get; set; }
        bool IsActive { get; set; }
        
    }
}
