using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    [Alias("InsuranceCompanyTypes")]
    public class InsuranceCompanyTypes : IInsuranceCompanyTypes
    {
        [Key]
        public int CTID { get; set; }
        public string CompanyType { get; set; }
       public bool IsActive { get; set; }
    }
}
