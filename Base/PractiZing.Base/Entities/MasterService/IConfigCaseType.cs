using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigCaseType : IActive, IModifiedStamp
    {
        Int16 Id { get; set; }
        string Name { get; set; }
    }
}
