using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientFilter
    {
        string PatientId { get; set; }
        string BillingId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string SSN { get; set; }
        string DOB { get; set; }
    }
}
