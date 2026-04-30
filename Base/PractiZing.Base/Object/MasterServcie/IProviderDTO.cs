using PractiZing.Base.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IProviderDTO : IUniqueIdentifier, IPracticeDTO
    {
        Int16 Id { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string Middle { get; set; }
        string FullName { get; }

        Int16? PUserId { get; set; }

        bool? IsDefault { get; set; }
        string Modifier { get; set; }
        Guid? SupervisorUId { get; set; }
        bool? IsBillUnderSupervisor { get; set; }
        short SupervisorId { get; set; }
        int? ServiceCircumstanceId { get; set; }
        Int16 FacilityId { get; set; }
        Guid FacilityUId { get; set; }
        string Qualification { get; set; }
        string SUDQualification { get; set; }
    }
}
