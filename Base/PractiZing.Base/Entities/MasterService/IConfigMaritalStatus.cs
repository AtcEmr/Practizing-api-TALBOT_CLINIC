using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigMaritalStatus : IActive
    {
        byte Id { get; set; }
        string Description { get; set; }
    }
}
