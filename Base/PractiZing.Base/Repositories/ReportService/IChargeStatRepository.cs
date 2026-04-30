using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.ReportService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ReportService
{
    public interface IChargeStatRepository
    {
        Task<IDenialQueueDTO> GetDenialData(IChargeStatFilter chargeStatFilter);
        Task<IEnumerable<IDenialStatDTO>> GetDenialDataForFilters(IChargeStatFilter chargeStatFilter);
        Task<IDenialDashboardDTO> GetDenialDashboardData(bool? hasDenial, bool isBaseStatsRequired);
        Task<IEnumerable<IChargeStatDTO>> GetAgingByCharge(bool? hasDenial);
        Task<IEnumerable<IChargeStatDTO>> ChargeStatByInsuranceCompany(bool? hasDenial);
        Task<IEnumerable<IChargeStatDTO>> ChargeStatByReasonCode(bool? hasDenial);
        Task<string> RefreshDenialDashboard();
        Task<IEnumerable<IDataFormDenailFileDTO>> GetDenailFileData();
        Task<IEnumerable<IDataFormDenailFileDTO>> GetAgingFileData();
        Task<IEnumerable<IDataFormDenailFileDTO>> GetDenialReasonsFile();
        Task<IEnumerable<IDataFormDenailFileDTO>> GetInsuranceCompaniesFile();
        Task<IEnumerable<IDataFormDenailFileDTO>> GetInsuranceTypesFile();
    }
}
