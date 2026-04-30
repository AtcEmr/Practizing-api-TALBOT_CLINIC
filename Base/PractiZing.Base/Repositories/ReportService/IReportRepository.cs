using PractiZing.Base.Entities.ReportService;
using PractiZing.Base.Object.ReportService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ReportService
{
    public interface IReportRepository
    {
        Task<IEnumerable<IReport>> GetAll();
        Task<IReport> GetById(long id);
        Task<IReport> GetPatientStatement();
        Task<string> GenerateReportData(int reportId, object parameterJson);
        Task<string> GeneratePatientStatement(int reportId, object parameterObject);
        Task<string> GeneratePatientForAutoStatement(int days);
        Task<string> GeneratePatientStatementXML(int reportId, object parameterObject, string xmlFilePath);
        Task<dynamic> usp_GetPatientAgingBalances_BatchStatement(string uid);
        IReportDataDTO SerializeToDictionary(string command, object parameterObject);
        Task<string> GetBillingToken(string url);
    }
}
