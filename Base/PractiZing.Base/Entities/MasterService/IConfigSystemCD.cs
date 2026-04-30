using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigSystemCD : IActive
    {
        string CD { get; set; }
        string GroupCD { get; set; }
        string Description { get; set; }
    }
}
