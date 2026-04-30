using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class InsuranceCompanyFilter : IInsuranceCompanyFilter
    {
        [SearchField(Name = CompanyFilterModel.CompanyName)]
        public string CompanyName { get; set; }
    }

    public class CompanyFilterModel
    {
        public const string TableName = "InsuranceCompany";
        public const string CompanyName = TableName + "." + "CompanyName";
    }
}
