using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IFacilityIdentity : IUniqueIdentifier, IModifiedStamp
    {
        int Id { get; set; }
        short FacilityId { get; set; }
        short TypeId { get; set; }
        string Identifier { get; set; }
        string Prefix { get; set; }
        DateTime ActiveDate { get; set; }
        DateTime? InactiveDate { get; set; }
        Guid FacilityUId { get; set; }
    }
}
