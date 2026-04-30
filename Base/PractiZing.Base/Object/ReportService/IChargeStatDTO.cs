using System.Collections.Generic;

namespace PractiZing.Base.Object.ReportService
{
    public interface IChargeStatDTO
    {
        string StatName { get; set; }
        decimal? Amount { get; set; }
        int Count { get; set; }
        string StatUId { get; set; }
        
    }

    public class IBaseStatisticsDTO
    {
        int Count { get; set; }
        decimal? Charges { get; set; }
    }

    public interface IDenialBaseStatisticsDTO
    {
        IBaseStatisticsDTO TotalClaimsInDenial { get; set; }
        IBaseStatisticsDTO AssignedToMe { get; set; }
        IBaseStatisticsDTO MyFollowUp { get; set; }
    }

    public interface IDenialDashboardDTO
    {
        IEnumerable<IChargeStatDTO> ARAging { get; set; }
        IEnumerable<IChargeStatDTO> InsuranceCompanies { get; set; }
        IEnumerable<IChargeStatDTO> CarrerTypes { get; set; }
        IEnumerable<IChargeStatDTO> TopFollowingCategories { get; set; }
        IEnumerable<IChargeStatDTO> TopDenialReasons { get; set; }
        IDenialBaseStatisticsDTO DenialBaseStatistics { get; set; }
    }
}
