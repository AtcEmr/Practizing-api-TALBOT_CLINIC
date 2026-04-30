using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Object
{
    public class ProviderDTO : IProviderDTO
    {
        public Int16 Id { get; set; }
        public Guid UId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Middle { get; set; }
        public string FullName
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Middle) ? $"{this.FirstName} {this.LastName}" : $"{this.FirstName} {this.LastName}, {this.Middle}";
                //  return $"{LastName}, {FirstName} {Middle}";
            }
        }
        public int PracticeId { get; set; }
        public Int16? PUserId { get; set; }

        public bool? IsDefault { get; set; }
        public string Modifier { get; set; }

        public Guid? SupervisorUId { get; set; }

        public bool? IsBillUnderSupervisor { get; set; }

        public short SupervisorId { get; set; }

        public int? ServiceCircumstanceId { get; set; }

        public Int16 FacilityId { get; set; }

        public Guid FacilityUId { get; set; }

        public string Qualification { get; set; }

        public string SUDQualification { get; set; }

    }
}