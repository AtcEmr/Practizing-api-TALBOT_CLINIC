using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class HCFAFormDTO : IHCFAFormDTO
    {

        public HCFAFormDTO()
        {
            this.DefaultData = new List<ClaimConfig>();
            this.CompanyTypes = new List<ClaimConfig>();
            this.Companys = new List<ClaimConfig>();
        }

        public IEnumerable<IClaimConfig> DefaultData { get; set; }
        public IEnumerable<IClaimConfig> CompanyTypes { get; set; }
        public IEnumerable<IClaimConfig> Companys { get; set; }
    }
}
