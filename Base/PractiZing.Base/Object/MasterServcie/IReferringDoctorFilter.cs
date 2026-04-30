using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IReferringDoctorFilter
    {
        string Prefix { get; set; }
        string FirstName { get; set; }
        string Middle { get; set; }
        string LastName { get; set; }
        string Suffix { get; set; }
        string NPI { get; set; }
        string Address { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string Email { get; set; }
        string PracticeName { get; set; }
        int? DirectEmailID { get; set; }
    }
}
