using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientChargeDTO : IPatientChargeDTO
    {

        public PatientChargeDTO()
        {
            this.InsuranceCompanyId = new List<int?>();
            this.PatientCaseId = new List<int>();
            this.PatientCaseUId = new List<string>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return $"{LastName}  {FirstName}";
            }
        }

        public string GName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public Guid PatientUID { get; set; }

        public IEnumerable<int?> InsuranceCompanyId { get; set; }
        public IEnumerable<int> PatientCaseId { get; set; }
        public IEnumerable<string> PatientCaseUId { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public string tempDob { get; set; }
    }
}
