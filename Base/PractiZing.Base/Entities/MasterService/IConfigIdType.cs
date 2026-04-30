using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigIdType
    {
        Int16 Id { get; set; }
        string Name { get; set; }
        string Prefix { get; set; }
        bool Active { get; set; }
    }
}
