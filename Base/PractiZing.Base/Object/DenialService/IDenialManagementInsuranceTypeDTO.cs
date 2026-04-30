using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.DenialService
{
    public interface IDenialManagementInsuranceTypeDTO
    {
        decimal BalanceAmount { get; set; }
        string CompanyName { get; set; }
        string CompanyType { get; set; }
        int AccountCount { get; set; }
        int InsuranceCompanyId { get; set; }

        bool IsSelected { get; set; }
    }
}
