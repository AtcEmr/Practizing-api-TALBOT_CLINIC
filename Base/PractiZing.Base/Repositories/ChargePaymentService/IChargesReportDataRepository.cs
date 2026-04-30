using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChargesReportDataRepository
    {
        Task<IChargesReportDataDTO> Get(IChargesReportDataFilterDTO filter);
        Task<IChargesReportDataDTO> GetOnlyDenials(IChargesReportDataFilterDTO filter);
        Task<ICPAReportDTO> GetCPAReportAnalytics();
        Task<IEnumerable<IChargesReportData>> GetCPAChargesAnalytics(string value);
        Task<IEnumerable<IChargesReportDataConsolidate>> GetPatientCharges(string billingId);
        Task<IEnumerable<IChargesReportData>> GetData();
        Task<IEnumerable<IChargesReportDataConsolidate>> GetPatientBalancesList();
        Task<IEnumerable<IChargesReportData>> GetOnlyWriteOff();
        Task<IEnumerable<IChargesReportDataConsolidate>> GetConsolidateData();
        Task<IEnumerable<IPatientBalanceForEMR>> GetPatientBalancesForEMR();
        Task<IEnumerable<IChargesReportData>> GetChargesForWriteOffLessThanGivingDates(DateTime dosDate);
        Task<IEnumerable<IChargesReportData>> GetDenialChargesForRebillWherePrimaryPolicyChanged();
        Task<IEnumerable<IChargesReportData>> GetPatientForStatement();
        Task<IEnumerable<ICharges>> GetPatientChargesForStatements(List<int> patientIds);
        Task<IEnumerable<IChargesReportData>> GetPatientForStatementOverThreeMonths();
        Task<IEnumerable<IChargesReportData>> GetChargesForWriteOff(DateTime dosDate, string adjustmentCode);
        Task<IEnumerable<IPatientBalanceForEMR>> GetPatientBalancesForMobileAPP(IMobileInputModel mobileInputModel);
        Task<IEnumerable<IBalanceForEMR>> GetBalancesForMobileAPP();
        Task<int> GetPatientForStatementWithOurMedicaid(string patientUid);
        Task<IEnumerable<IBalanceForEMR>> GetBalancesForEMRWithDuemAmont(decimal dueAmount);
        Task<IEnumerable<IChargesReportData>> WriteOffHandTCharges();
        Task<IEnumerable<IChargesReportData>> GetChargesForMakeClaims_BilledVsCurrentIns();
        Task<IEnumerable<IChargesReportData>> GetOldPatientDueCharges(DateTime dosDate);
        Task<string> DailyImportDataStaticsSend();
    }
}
