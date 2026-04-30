using PractiZing.Base.Object.DenialService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Object
{
    public class DenialManagementInsuranceTypeDTO : IDenialManagementInsuranceTypeDTO
    {
        public decimal BalanceAmount { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public int InsuranceCompanyId { get; set; }
        public int AccountCount { get; set; }

        [Ignore]
        public bool IsSelected { get; set; }
    }
}
