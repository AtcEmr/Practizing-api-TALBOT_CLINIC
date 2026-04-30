using PractiZing.Base.Object.DenialService;

namespace PractiZing.DataAccess.DenialService.Object
{
    public class DenialFilter : IDenialFilter
    {
        public string DenialManagementsTags { get; set; }
        public string InsuranceCompanies { get; set; }
        public string InsuranceCompanyTypes { get; set; }
        public string DenialQueues { get; set; }
        public string DenialAdjustments { get; set; }
        public int IsFilterTrue { get; set; }
        public int PatientStatementSentCount { get; set; }
    }
}
