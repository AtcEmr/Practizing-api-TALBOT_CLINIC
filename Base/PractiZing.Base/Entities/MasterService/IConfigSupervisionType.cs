using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigSupervisionType
    {
        Int16 Id { get; set; }        
        string SupervisionType  { get; set; }        
    }
}
