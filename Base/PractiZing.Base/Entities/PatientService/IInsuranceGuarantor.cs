using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IInsuranceGuarantor : IModifiedStamp
    {
        int ID { get; set; }
        int PatientID { get; set; }
        string GuarantorNumber { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string HomePhone { get; set; }
        string BusPhone { get; set; }
        string DOB { get; set; }
        char AdminSex { get; set; }
        string GuarantorRel { get; set; }
        string EmployerAddress1 { get; set; }
        string EmployerAddress2 { get; set; }
        string EmployerCity { get; set; }
        string EmployerState { get; set; }
        string EmployerZip { get; set; }
        string EmployerPhone { get; set; }
        string EmploymentStatus { get; set; }
        string OrganizationName { get; set; }
        string MaritalStatus { get; set; }
        char Student { get; set; }
        char PreferedContact { get; set; }
        string MobilePhone { get; set; }
    }
}
