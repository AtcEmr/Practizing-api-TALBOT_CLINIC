using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigInsuranceMedicareSecondary : IActive
    {
        Int16 Id { get; set; }
        string Name { get; set; }
    }
}
