using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IEncounterTypes
    {
        int Id { get; set; }        
        string Code { get; set; }
        string Name { get; set; }
        bool IsBillable { get; set; }
        bool IsMentalHealthCPT { get; set; }
        int EncounterTypeClacification { get; set; }
        bool SupervisionRequired { get; set; }
        bool Active { get; set; }
    }
}
