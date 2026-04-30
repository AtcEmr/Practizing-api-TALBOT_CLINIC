using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigFacilitySubType : IActive
    {
        int Id { get; set; }
        string TypeName { get; set; }
        string TypeValue { get; set; }
        int? ParentId { get; set; }
    }
}
