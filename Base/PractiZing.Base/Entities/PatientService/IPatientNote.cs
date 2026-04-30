using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientNote : IPracticeDTO, IUniqueIdentifier, IStamp
    {
        int Id { get; set; }
        string Note { get; set; }
        int PatientId { get; set; }
    }
}
