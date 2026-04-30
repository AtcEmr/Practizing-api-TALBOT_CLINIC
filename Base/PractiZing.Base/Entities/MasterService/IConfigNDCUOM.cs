using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigNDCUOM : IActive
    {
        short Id { get; set; }
        string Code { get; set; }
        string Description { get; set; }
    }
}
