using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientChargesStatementHeaderDTO : IPatientChargesStatementHeaderDTO
    {
        public int PatientId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress1 { get; set; }
        public string FacilityAddress2 { get; set; }
        public string FacilityCity { get; set; }
        public string FacilityState { get; set; }
        public string FacilityZipCode { get; set; }
        public string FacilityPhone { get; set; }
        public string BillPatientName { get { return $"{FirstName} {LastName}"; } }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }
        public string PatientAddress1 { get; set; }
        public string PatientAddress2 { get; set; }
        public string PatientCity { get; set; }
        public string PatientState { get; set; }
        public string PatientZipCode { get; set; }
        public string PatientName
        {
            get
            {
                return $"{LastName} , {FirstName}";
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PracticeId { get; set; }
        public DateTime StatementDate { get; set; }
    }
}
