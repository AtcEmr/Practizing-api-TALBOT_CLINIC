using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IEDIEligibilityLog : IUniqueIdentifier, ICreatedStamp, IModifiedStamp
    {
        int Id { get; set; }        
        int PatientEligibilityId { get; set; }
        string Transaction270 { get; set; }        
        string Transaction271 { get; set; }
    }
}
