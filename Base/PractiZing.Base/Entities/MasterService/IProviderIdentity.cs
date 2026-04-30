using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IProviderIdentity : IUniqueIdentifier, IModifiedStamp
    {
        int Id { get; set; }
        short ProviderId { get; set; }
        short TypeId { get; set; }
        string Identifier { get; set; }
        DateTime ActiveDate { get; set; }
        DateTime? InactiveDate { get; set; }
        Guid ProviderUId { get; set; }
    }
}
