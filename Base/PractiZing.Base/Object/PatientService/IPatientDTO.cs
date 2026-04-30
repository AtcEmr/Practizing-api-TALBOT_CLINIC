using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.PatientService
{
    public interface IPatientDTO
    {
        int Id { get; set; }
        
        Int16? BillType { get; set; }
        string PrimaryCareDoctor { get; set; }
        string ReferralSource { get; set; }
        string ReferredBy { get; set; }
        string Pharmacy { get; set; }
        DateTime? PatientSigned { get; set; }
        string GAddress1 { get; set; }
        string GAddress2 { get; set; }
        string GCity { get; set; }
        string GState { get; set; }
        string GZip { get; set; }       
        string PrefContact { get; set; }
        string MobilePhoneNumber { get; set; }
        string WorkPhoneNumber { get; set; }
        string PhoneNumber { get; set; }

        string PayorId { get; set; }
        string InsuranceName { get; set; }
        string TrizettoInsuranceCode { get; set; }
        string ProviderLName { get; set; }
        string ProviderFName { get; set; }
        string ProviderNPI { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MI { get; set; }
        string PolicyNumber { get; set; }
        DateTime DOB { get; set; }
        string Sex { get; set; }
        bool PatientElig { get; set; }
        string Clearinghouse { get; set; }
    }
}
