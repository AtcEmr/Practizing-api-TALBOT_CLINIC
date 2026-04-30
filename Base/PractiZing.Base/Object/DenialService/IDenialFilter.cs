using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.DenialService
{
    public interface IDenialFilter
    {
        string DenialManagementsTags { get; set; }
        string InsuranceCompanies { get; set; }
        string InsuranceCompanyTypes { get; set; }
        string DenialQueues { get; set; }
        string DenialAdjustments { get; set; }
        int IsFilterTrue { get; set; }
        int PatientStatementSentCount { get; set; }
    }
}
