using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigInsuranceCompanyType : IConfigInsuranceCompanyType
    {
        public ConfigInsuranceCompanyType()
        {
            this.InsuranceCompanies = new List<InsuranceCompany>();
        }

        public Int16 Id { get; set; }
        public string CompanyType { get; set; }
        public bool IsActive { get; set; }

        [Ignore]
        public bool IsNew { get; set; }

        [Ignore]
        public IEnumerable<IInsuranceCompany> InsuranceCompanies { get; set; }
    }
}
