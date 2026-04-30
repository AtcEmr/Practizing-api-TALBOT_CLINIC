using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientChargeDTO
    {
        int Id { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string FullName { get; }
        string GName { get; set; }
        string MobilePhoneNumber { get; set; }
        Guid PatientUID { get; set; }

        IEnumerable<int?> InsuranceCompanyId { get; set; }
        IEnumerable<int> PatientCaseId { get; set; }
        IEnumerable<string> PatientCaseUId { get; set; }
        string PhoneNumber { get; set; }
        string WorkPhoneNumber { get; set; }
        DateTime Dob { get; set; }
        string tempDob { get; set; }
    }
}
