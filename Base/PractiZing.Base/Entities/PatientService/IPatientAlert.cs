using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientAlert :  IUniqueIdentifier, IStamp
    {
        int Id { get; set; }
        string AlertText { get; set; }
        int PatientId { get; set; }
        bool IsActive { get; set; }
        Guid PatientUId { get; set; }
    }
}
