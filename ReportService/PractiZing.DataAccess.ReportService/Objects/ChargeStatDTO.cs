using PractiZing.Base.Object.ReportService;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ReportService.Objects
{
    public class ChargeStatDTO : IChargeStatDTO
    {
        public string StatName { get; set; }
        public decimal? Amount { get; set; }
        public int Count { get; set; }
        public string StatUId { get; set; }
    }

    public class BaseStatisticsDTO : IBaseStatisticsDTO
    {
        public int Count { get; set; }
        public decimal? Charges { get; set; }
    }

    public class DenialBaseStatisticsDTO : IDenialBaseStatisticsDTO
    {
        public IBaseStatisticsDTO TotalClaimsInDenial { get; set; }
        public IBaseStatisticsDTO AssignedToMe { get; set; }
        public IBaseStatisticsDTO MyFollowUp { get; set; }
    }

    public class DenialDashboardDTO : IDenialDashboardDTO
    {
        public IEnumerable<IChargeStatDTO> ARAging { get; set; }
        public IEnumerable<IChargeStatDTO> InsuranceCompanies { get; set; }
        public IEnumerable<IChargeStatDTO> CarrerTypes { get; set; }
        public IEnumerable<IChargeStatDTO> TopFollowingCategories { get; set; }
        public IEnumerable<IChargeStatDTO> TopDenialReasons { get; set; }
        public IDenialBaseStatisticsDTO DenialBaseStatistics { get; set; }
    }
}
