using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class RolledUpEncounterDTO : IRolledUpEncounterDTO
    {
        public string RolledUpEncounter { get; set; }
        public string ActualEncounter { get; set; }        
    }
}
