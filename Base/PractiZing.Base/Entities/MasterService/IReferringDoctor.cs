using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IReferringDoctor : IUniqueIdentifier, IStamp, IPracticeDTO, IActive
    {

        Int16 Id { get; set; }
        string Prefix { get; set; }
        string FirstName { get; set; }
        string Middle { get; set; }
        string LastName { get; set; }
        string Suffix { get; set; }
        string Address { get; set; }
        string Address2 { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string Email { get; set; }
        string PracticeName { get; set; }
        Int16? Degree { get; set; }
        string NPI { get; set; }
        string Comments { get; set; }
        int? PM_Person_NO { get; set; }
        int? DirectEmailID { get; set; }
        string FullName
        {
            get;            
        }
    }
}
