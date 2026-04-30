using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigServiceType
    {
        string Code { get; set; }
        string Description { get; set; }
        string FieldName { get; set; }
        string SegmentName { get; set; }
    }
}
