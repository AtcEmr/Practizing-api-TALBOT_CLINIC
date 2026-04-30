using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IInsuranceCompanyTypes : IActive
    {
        int CTID { get; set; }
        string CompanyType { get; set; }
    }
}
