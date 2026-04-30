using Microsoft.AspNetCore.Http;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface IReportService
    {
        // Task<string> GenerateReport(int reportId, object parameterObject);
        Task<Tuple<byte[], string>> GenerateReport(IReportParameterDTO parameterObject);
        Task<Tuple<byte[], string>> GeneratePatientStatement(IPatientStatementParameterDTO parameterDTO);
        Task<Tuple<byte[], string>> DownloadFile(string uId);
        Task<string> GeneratePatientForAutoStatement(int days);
        Task<string> GeneratePatientFromExcelImport(IFormFile file);
        Task<Tuple<byte[], string>> GeneratePatientStatementXML(IPatientStatementParameterDTO patientStatement);
        Task<IEnumerable<IPatientStatementRDLCDTO>> GetPatientAgingBalances_BatchStatement(string uid);
        Task<Tuple<byte[], string>> DownloadBatchStatementFile(string uId);
        Task UploadBatchStatementFile(string uId);
        Task<Tuple<byte[], string>> GeneratePatientStatementTest(IPatientStatementParameterDTO patientStatement);
        Task<Tuple<byte[], string>> GetLabPatientBalancesStatments(IPatientStatementParameterDTO patientStatementParameterDTO);
        Task<int> GenerateBatchStatements();
        Task UploadBatchStatementOnly(string uId);
        Task<int> GetPatientForStatementWithOurMedicaid(string patientUid);
    }
}
