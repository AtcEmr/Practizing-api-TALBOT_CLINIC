using PractiZing.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
   public interface IReferringDoctorDTO : IPracticeDTO
    {
        Int16 Id { get; set; }
        string FirstName { get; set; }
        string Middle { get; set; }
        string LastName { get; set; }
        string FullName { get; }
    }
}
