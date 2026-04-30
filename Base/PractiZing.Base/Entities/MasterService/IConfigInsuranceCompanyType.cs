using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigInsuranceCompanyType : IActive
    {
        Int16 Id { get; set; }
        string CompanyType { get; set; }
        bool IsNew { get; set; }

        IEnumerable<IInsuranceCompany> InsuranceCompanies { get; set; }
    }
}
