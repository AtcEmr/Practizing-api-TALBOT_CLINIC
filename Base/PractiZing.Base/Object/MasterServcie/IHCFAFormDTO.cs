using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IHCFAFormDTO
    {
        IEnumerable<IClaimConfig> DefaultData { get; set; }
        IEnumerable<IClaimConfig> CompanyTypes { get; set; }
        IEnumerable<IClaimConfig> Companys { get; set; }
    }
}
