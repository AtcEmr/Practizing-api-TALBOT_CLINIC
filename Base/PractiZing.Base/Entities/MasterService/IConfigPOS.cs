using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigPOS : IActive
    {
        string Code { get; set; }
        string Description { get; set; }
        bool? Facility { get; set; }
    }
}
