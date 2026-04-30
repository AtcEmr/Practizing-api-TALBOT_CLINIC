using System;

namespace PractiZing.Base.Entities
{
    public interface IStamp : ICreatedStamp, IModifiedStamp
    {
    }

    public interface IModifiedStamp
    {
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }

    public interface ICreatedStamp
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
