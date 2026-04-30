using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IMasterICD10
    {
        string Code { get; set; }
        string Description { get; set; }
    }
}
