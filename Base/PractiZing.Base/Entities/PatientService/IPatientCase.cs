using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientCase : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        int Id { get; set; }
        string CaseIdNumber { get; set; }
        long PatientId { get; set; }
        int? CaseTypeId { get; set; }
        int? ProviderId { get; set; }
        int? FacilityId { get; set; }
    }
}
