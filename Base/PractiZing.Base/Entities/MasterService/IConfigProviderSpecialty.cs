using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigProviderSpecialty 
    {
        Int16 Id { get; set; }
        string Description { get; set; }
        bool? Visible { get; set; }
        bool Active { get; set; }
    }
}
