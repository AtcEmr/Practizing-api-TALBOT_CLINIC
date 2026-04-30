using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class PatientDTO : IPatientDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public short? BillType { get; set; }
        public string PrimaryCareDoctor { get; set; }
        public string ReferralSource { get; set; }
        public string ReferredBy { get; set; }
        public string Pharmacy { get; set; }
        public DateTime? PatientSigned { get; set; }
        public string GAddress1 { get; set; }
        public string GAddress2 { get; set; }
        public string GCity { get; set; }
        public string GState { get; set; }
        public string GZip { get; set; }
        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string PrefContact { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PhoneNumber { get; set; }

        public string PayorId { get ; set ; }
        public string InsuranceName { get ; set ; }
        public string TrizettoInsuranceCode { get ; set ; }
        public string ProviderLName { get ; set ; }
        public string ProviderFName { get ; set ; }
        public string ProviderNPI { get ; set ; }
        public string MI { get ; set ; }
        public string PolicyNumber { get ; set ; }
        public bool PatientElig { get ; set ; }
        public string Clearinghouse { get ; set ; }
    }
}
