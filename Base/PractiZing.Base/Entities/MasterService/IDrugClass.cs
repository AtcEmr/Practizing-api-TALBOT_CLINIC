using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IDrugClass : IStamp, IActive
    {
        int Id { get; set; }
        string DrugCode { get; set; }
        string Description { get; set; }
    }
}
