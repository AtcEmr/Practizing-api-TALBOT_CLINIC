using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigDrugClass
    {
        int Id { get; set; }
        int RangeFrom { get; set; }
        int RangeTo { get; set; }
        string CptCode { get; set; }
        string SubCPTCode { get; set; }
    }
}
