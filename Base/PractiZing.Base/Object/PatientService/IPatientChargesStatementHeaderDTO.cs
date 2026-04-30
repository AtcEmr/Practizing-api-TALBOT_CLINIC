using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientChargesStatementHeaderDTO
    {
        int PatientId { get; set; }
        string FacilityName { get; set; }
        string FacilityAddress1 { get; set; }
        string FacilityAddress2 { get; set; }
        string FacilityCity { get; set; }
        string FacilityState { get; set; }
        string FacilityZipCode { get; set; }
        string FacilityPhone { get; set; }
        string BillPatientName { get; }
        string BillAddress1 { get; set; }
        string BillAddress2 { get; set; }
        string BillCity { get; set; }
        string BillState { get; set; }
        string BillZip { get; set; }
        string PatientAddress1 { get; set; }
        string PatientAddress2 { get; set; }
        string PatientCity { get; set; }
        string PatientState { get; set; }
        string PatientZipCode { get; set; }
        string PatientName { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int PracticeId { get; set; }
        DateTime StatementDate { get; set; }
    }
}
