using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigTOS : IActive
    {
        string Code { get; set; }
        string Descr { get; set; }
    }
}
