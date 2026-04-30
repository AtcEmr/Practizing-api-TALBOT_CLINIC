using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientEligibility : IUniqueIdentifier, ICreatedStamp, IModifiedStamp, IPracticeDTO
    {
        int Id { get; set; }        
        int PatientId { get; set; }
        string TRN { get; set; }
        DateTime? EntryDate { get; set; }
        DateTime EligibilityDate { get; set; }
        string ErrorMessage { get; set; }
    }
}
