using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class ReferringDoctorDTO : IReferringDoctorDTO
    {
        public short Id { get; set; }
        public int PracticeId { get; set; }

        public string FirstName { get; set; }
        public string Middle { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {Middle}";
            }
        }
    }
}
