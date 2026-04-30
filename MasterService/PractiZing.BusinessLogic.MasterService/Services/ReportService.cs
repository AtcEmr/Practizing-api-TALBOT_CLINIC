using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficeOpenXml;
using PractiZing.Api.Common;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Object.ReportService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Service.MasterService;
using PractiZing.Base.Service.PatientService;
using PractiZing.BusinessLogic.MasterService.MimeFileType;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.MasterServcie.Objects;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.DataAccess.PatientService.Tables;
using PractiZing.DataAccess.ReportService.DTO.Statement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private IPracticeRepository _practiceRepository;
        private IFullFrameworkRequestService _fullFrameworkRequestService;
        private IReportParameterService _reportParameterService;
        private IReportRepository _reportRepository;
        private IMergePdfFiles _mergePdfFiles;
        private IAttFileRepository _attFileRepository;
        private IAttFileTableRepository _attFileTableRepository;
        private IBatchStatementRepository _batchStatementRepository;
        private IStatementFileService _statementFileService;
        private IChargesReportDataRepository _chargesReportDataRepository;
        private string _baseUrl;
        private string _relativePath;
        private string _baseDirectory;
        private string _attachmentDirectory;
        private string _patientStatement;
        private bool _isTestServerURL;
        private ILogger _logger;
        private IPatientStatementRepository _patientStatementRepository;
        private IAttService _attService;
        private string domainName;
        private string _baseBatchStatementDirectory;
        private IPatientRepository _patientRepository;
        private IChargesRepository _chargesRepository;
        private IChargeStatementCountRepository _chargeStatementCountRepository;
        private readonly ITransactionProvider _transactionProvider;

        public ReportService(ITransactionProvider transactionProvider, IPracticeRepository practiceRepository, IFullFrameworkRequestService fullFrameworkRequestService,
                             IConfiguration configuration, ILogger<IReportService> logger, IReportParameterService reportParameterService,
                             IReportRepository reportRepository, IMergePdfFiles mergePdfFiles, IPatientStatementRepository patientStatementRepository,
                             IAttFileRepository attFileRepository, IAttFileTableRepository attFileTableRepository, IAttService attService,
                             IStatementFileService statementFileService,IBatchStatementRepository batchStatementRepository, IMapper mapper,
                             IPatientRepository patientRepository,
                             IChargesReportDataRepository chargesReportDataRepository,
                             IChargesRepository chargesRepository,
                             IChargeStatementCountRepository chargeStatementCountRepository)
        {
            this._transactionProvider = transactionProvider;
            this._chargeStatementCountRepository = chargeStatementCountRepository;
            this._chargesRepository = chargesRepository;
            this._chargesReportDataRepository = chargesReportDataRepository;
            this._patientRepository = patientRepository;
            this._mapper = mapper;
            this._practiceRepository = practiceRepository;
            this._batchStatementRepository = batchStatementRepository;
            this._mergePdfFiles = mergePdfFiles;
            this._reportRepository = reportRepository;
            this._fullFrameworkRequestService = fullFrameworkRequestService;
            _baseBatchStatementDirectory = configuration["BaseBatchStatementDirectory"];
            _baseUrl = configuration["ApplicationUrl"];
            _relativePath = configuration["AttachmentReportFolder"];
            _patientStatement = configuration["AttachmentPatientStatementFolder"];
            //  _baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "../";
            _baseDirectory = configuration["BaseWindowDirectory"];
            _attachmentDirectory = configuration["AttachmentFolder"];
            bool.TryParse(configuration["IsTestServerURL"], out _isTestServerURL);
            this._logger = logger;
            this._reportParameterService = reportParameterService;
            this._patientStatementRepository = patientStatementRepository;
            this._attFileRepository = attFileRepository;
            this._attFileTableRepository = attFileTableRepository;
            this._attService = attService;
            this._statementFileService = statementFileService;
            domainName = configuration["DomainName"];
        }

        public async Task<Tuple<byte[], string>> GeneratePatientStatement(IPatientStatementParameterDTO patientStatement)
        {
            try
            {
                List<StatmentFileName> statmentFileNames = new List<StatmentFileName>();
                string restApiUrl = "";
                List<string> mergeFilePath = new List<string>();
                string fileName = _patientStatement;
                string filePath = "";
                var getPatientStatementReport = await this._reportRepository.GetPatientStatement();
                IPatientStatement patientStatementId = null;
                var practiceName = await this._practiceRepository.Get();
                var practiceCode = this._practiceRepository.GetLoggedUser();

                IPatientStatementParameterDTO convertIntoGUid = null;
                if(!patientStatement.IsFromEMR)
                {
                    convertIntoGUid = await this._reportParameterService.ConvertGUIDToId(patientStatement);
                }
                else
                {
                    convertIntoGUid = await this._reportParameterService.ConvertGUIDToIdForEMR(patientStatement);
                    patientStatement.FromDate = "1 Jan 2020";
                    patientStatement.ToDate = DateTime.Now.ToShortDateString();
                    //convertIntoGUid = patientStatement;
                }
                

                string[] patientIds = convertIntoGUid.PatientId.Split(',');
                if(patientIds.Count()>1)
                {
                    patientStatement.IsBulkStatement = "True";
                }
                else if (patientIds.Count() ==1)
                {
                    patientStatement.IsBulkStatement = "False";
                }

                foreach (var item in patientIds)
                {
                    fileName = _patientStatement;

                    patientStatement.PatientId = item;

                    patientStatement.PracticeName = practiceName.PracticeName;
                    var serializeData = JsonConvert.SerializeObject(patientStatement);

                    if (_isTestServerURL)
                    {                        
                        restApiUrl = $"http:\\localhost:5001";
                    }
                    else
                    {
                        restApiUrl = $"https:\\{practiceCode}"+domainName;
                    }

                    var responseString = await this._fullFrameworkRequestService.FullFrameWorkRequest("/api/Report/generatePatientStatement?=" + getPatientStatementReport.ID + "&restApiUrl=" + restApiUrl + "&practiceCode=" + practiceCode, serializeData);
                    

                    //getting file name from fullframe response
                    var pieces = responseString.Split("\\");
                    

                    fileName = fileName + "-" + practiceCode + "-" + patientStatement.PatientId + '-' + Guid.NewGuid().ToString() + ".pdf";

                    //creating file path where file have to move
                    var path = this.FilePath("", false, practiceCode);

                    filePath = Path.Combine(path, fileName);
                    mergeFilePath.Add(filePath);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    File.Move(responseString, filePath);

                    StatmentFileName statmentFileName = new StatmentFileName();
                    statmentFileName.PatientUId = item;
                    statmentFileName.FileName = fileName;
                    statmentFileNames.Add(statmentFileName);
                }

                foreach (var item in patientIds)
                {
                    string fromDate = patientStatement.FromDate == null ? null : patientStatement.FromDate;
                    string toDate = patientStatement.ToDate == null ? null : patientStatement.ToDate;

                    var patientStatementObject = await this.CreateObject(item, fromDate, toDate);
                    patientStatementObject.Note = patientStatement.Message != null ? patientStatement.Message : "";
                    if (patientStatement.IsFromEMR)
                        patientStatementObject.IsFromEMR = true;

                    patientStatementId = await this._patientStatementRepository.AddNew(patientStatementObject);
                    var statementFileName = statmentFileNames.FirstOrDefault(i => i.PatientUId == item).FileName;
                    await this._attFileRepository.CreateAttachments(null, patientStatementId.Id, AttTableConstant.PatientStatements, statementFileName, practiceCode, true);

                }

               fileName = Path.Combine(_baseDirectory+"\\"+practiceCode, fileName);

                var mergedFile = await this._mergePdfFiles.CreatePDF(mergeFilePath, fileName);

                var fileData = File.ReadAllBytes(mergedFile);
                
                string extensions = Path.GetExtension(mergedFile);
                extensions = extensions.Replace(".", "");

                var contentType = this.ContentType(extensions);

                var returnData = Tuple.Create<byte[], string>(fileData, contentType);
                return returnData;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception . " + ex.StackTrace);
                throw ex;
            }
        }

        public async Task<Tuple<byte[], string>> GeneratePatientStatementTest(IPatientStatementParameterDTO patientStatement)
        {
            try
            {
                List<StatmentFileName> statmentFileNames = new List<StatmentFileName>();
                string restApiUrl = "";
                List<string> mergeFilePath = new List<string>();
                string fileName = _patientStatement;
                string filePath = "";
                var getPatientStatementReport = await this._reportRepository.GetPatientStatement();
                IPatientStatement patientStatementId = null;
                var practiceName = await this._practiceRepository.Get();
                var practiceCode = this._practiceRepository.GetLoggedUser();

                IPatientStatementParameterDTO convertIntoGUid = null;
                if (!patientStatement.IsFromEMR)
                {
                    convertIntoGUid = await this._reportParameterService.ConvertGUIDToId(patientStatement);
                }
                else
                {
                    convertIntoGUid = await this._reportParameterService.ConvertGUIDToIdForEMR(patientStatement);
                    patientStatement.FromDate = "1 Jan 2020";
                    patientStatement.ToDate = DateTime.Now.ToShortDateString();
                    //convertIntoGUid = patientStatement;
                }


                string[] patientIds = convertIntoGUid.PatientId.Split(',');
                if (patientIds.Count() > 1)
                {
                    patientStatement.IsBulkStatement = "True";
                }
                else if (patientIds.Count() == 1)
                {
                    patientStatement.IsBulkStatement = "False";
                }



                fileName = _patientStatement;

                patientStatement.PatientId = convertIntoGUid.PatientId;

                patientStatement.PracticeName = practiceName.PracticeName;
                var serializeData = JsonConvert.SerializeObject(patientStatement);

                if (_isTestServerURL)
                {
                    restApiUrl = $"http:\\localhost:5001";
                }
                else
                {
                    restApiUrl = $"https:\\{practiceCode}" + domainName;
                }

                var responseString = await this._fullFrameworkRequestService.FullFrameWorkRequest("/api/Report/generatePatientStatementBulk?=" + getPatientStatementReport.ID + "&restApiUrl=" + restApiUrl + "&practiceCode=" + practiceCode, serializeData);

                var reportsPath = JsonConvert.DeserializeObject<List<ReportResponse>>(responseString);


               if(reportsPath.Count()==0)
                {
                    throw new Exception("There is no data to Print the statement.");
                }

                foreach (var item in patientIds)
                {
                    string fromDate = patientStatement.FromDate == null ? null : patientStatement.FromDate;
                    string toDate = patientStatement.ToDate == null ? null : patientStatement.ToDate;

                    var patientStatementObject = await this.CreateObject(item, fromDate, toDate);
                    patientStatementObject.Note = patientStatement.Message != null ? patientStatement.Message : "";
                    if (patientStatement.IsFromEMR)
                        patientStatementObject.IsFromEMR = true;

                    patientStatementId = await this._patientStatementRepository.AddNew(patientStatementObject);
                    if(reportsPath.FirstOrDefault(i => i.PatientId == item)!=null)
                    {
                        var statementFileName = reportsPath.FirstOrDefault(i => i.PatientId == item).FilePath;
                        await this._attFileRepository.CreateAttachments(null, patientStatementId.Id, AttTableConstant.PatientStatements, statementFileName, practiceCode, true);
                        mergeFilePath.Add(statementFileName);
                    }
                }
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();                

                fileName = Path.Combine(_baseDirectory + "\\" + practiceCode, fileName+ timestamp+".pdf");

                var mergedFile = await this._mergePdfFiles.CreatePDF(mergeFilePath, fileName);

                var fileData = File.ReadAllBytes(mergedFile);

                string extensions = Path.GetExtension(mergedFile);
                extensions = extensions.Replace(".", "");

                var contentType = this.ContentType(extensions);

                var returnData = Tuple.Create<byte[], string>(fileData, contentType);
                return returnData;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception . " + ex.StackTrace);
                throw ex;
            }
        }

        

        public class ReportResponse
        {
            public string PatientId { get; set; }
            public string FilePath { get; set; }
        }

        private class StatmentFileName
        {
            public string PatientUId { get; set; }
            public string FileName { get; set; }

        }

        /// <summary>
        /// Generate report for that reportid with the help of full frame work api request and return file path 
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="parameterObject"></param>
        /// <returns>string</returns>
        public async Task<Tuple<byte[], string>> GenerateReport(IReportParameterDTO parameterObject)
        {
            try
            {
                string restApiUrl = "";
                int reportId = parameterObject.ReportId;
                _logger.LogInformation("Getting Practice Name using logged user practice Name");
                var practiceName = await this._practiceRepository.Get();
                var practiceCode = this._practiceRepository.GetLoggedUser();

                _logger.LogInformation("Getting Practice Name using logged user practice Name - " + practiceName.PracticeName);
                //send request to full frame work with content

                // parameterObject = parameterObject.ToString() + " PracticeName:"+ practiceName.PracticeName;
                _logger.LogInformation("Getting practice name using logged user practice Id - " + practiceName.PracticeName);
                //var reportData = JsonConvert.DeserializeObject<ReportParameterDTO>(parameterObject.ToString());

                var convertIntoGUid = await this._reportParameterService.ConvertGUIDToId(parameterObject);
                convertIntoGUid.PracticeName = practiceName.PracticeName;
                convertIntoGUid.PracticeId = practiceName.Id.ToString();

                var serializeData = JsonConvert.SerializeObject(parameterObject);
                //serializeData = serializeData.Replace("PracticeNames", practiceName.PracticeName);
                //serializeData = serializeData.Replace("PracticeIds", practiceName.Id.ToString());

                if (_isTestServerURL)
                {
                    //restApiUrl = $"http:\\40.77.104.76";
                    //restApiUrl = $"https:\\azdemo.practizing.com";
                    restApiUrl = $"http:\\localhost:5001";
                }
                else
                {
                    restApiUrl = $"https:\\{practiceCode}" + domainName;
                }

                _logger.LogInformation("restApiUrl == " + restApiUrl);

                _logger.LogInformation("throw request on ff service to generate report.");
                var responseString = await this._fullFrameworkRequestService.FullFrameWorkRequest("/api/Report/genrateReport?=" + reportId + "&restApiUrl=" + restApiUrl, serializeData);
                _logger.LogInformation("report path. ->" + responseString);

                //getting file name from fullframe response
                var pieces = responseString.Split("\\");
                _logger.LogInformation("split path into pieces for getting name of report" + responseString);

                string basePath = $"{_baseDirectory}{_relativePath}\\{"OutputReport"}\\{ pieces[pieces.Length - 1]}";

                //creating file path where file have to move
                var path = this.FilePath("OutputReport", true, "");

                var filePath = Path.Combine(path, pieces[pieces.Length - 1]);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // var file = Path.Combine(basePath, pieces[pieces.Length - 1]);
                //move file from genrated file path to our directory path

                if (System.IO.File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _logger.LogInformation("moving file.");
                File.Move(responseString, filePath);
                _logger.LogInformation("file moving successfully.");

                var fileData = File.ReadAllBytes(filePath);
                string extensions = Path.GetExtension(filePath);
                extensions = extensions.Replace(".", "");

                var contentType = this.ContentType(extensions);
                var returnData = Tuple.Create<byte[], string>(fileData, contentType);

                return returnData;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Testing Message== " + ex.Message);
                _logger.LogInformation("Testing InnerException== " + ex.InnerException);
                throw ex;
            }
        }

        private string ContentType(string ext)
        {
            string contentType = "";
            switch (ext)
            {
                case "pdf":
                    contentType = MimeTypes.PdfContentType;
                    break;

                case "docx":
                    contentType = MimeTypes.DocxContentType;
                    break;

                case "png":
                    contentType = MimeTypes.pngContentType;
                    break;

                case "txt":
                    contentType = MimeTypes.txtContentType;
                    break;

                case "xlsx":
                case "xls":
                    contentType = MimeTypes.ExcelContentType;
                    break;

                case "jpg":
                case "jpeg":
                    contentType = MimeTypes.jpgContentType;
                    break;
                case "xml":
                    contentType = MimeTypes.xmlContentType;
                    break;
            }

            return contentType;
        }

        private string FilePath(string folderInnerName, bool isReport, string practiceCode)
        {
            string basePath = "";
            if (isReport)
                basePath = $"{_baseDirectory}{_relativePath}/{folderInnerName}";
            else
                basePath = _baseDirectory + "\\" + practiceCode;

            return basePath;
        }

        private async Task<IPatientStatement> CreateObject(string patientId, string FromDate, string ToDate, int batchStatementId = 0, bool isXml = false)
        {
            DateTime? newFromDate = null;
            PatientStatement tEntity = new PatientStatement();
            tEntity.Id = 0;
            tEntity.PatientId = Convert.ToInt32(patientId);
            tEntity.BatchStatementId = batchStatementId;
            tEntity.IsXml = isXml;
            if (FromDate != null)
                newFromDate = Convert.ToDateTime(FromDate);

            tEntity.FromDate = FromDate == null ? null : newFromDate;
            tEntity.ToDate = ToDate == null ? DateTime.Now : Convert.ToDateTime(ToDate);

            return tEntity;
        }

        private async Task<IPatientStatement> CreateObject(string patientId, string FromDate, string ToDate)
        {
            DateTime? newFromDate = null;
            PatientStatement tEntity = new PatientStatement();
            tEntity.Id = 0;
            tEntity.PatientId = Convert.ToInt32(patientId);

            if (FromDate != null)
                newFromDate = Convert.ToDateTime(FromDate);

            tEntity.FromDate = FromDate == null ? null : newFromDate;
            tEntity.ToDate = ToDate == null ? DateTime.Now : Convert.ToDateTime(ToDate);

            return tEntity;
        }

        private async Task<IAttFile> CreateObjectAttFile(int tableValueId, string fileName)
        {
            var tableId = await this._attFileTableRepository.GetByName(AttTableConstant.PatientStatements);
            AttFile attFile = new AttFile();
            attFile.AttFileTableId = tableId.Id;
            attFile.TableIdValue = tableValueId;
            attFile.FileName = fileName;
            attFile.FullPath = "PatientStatements";

            return attFile;
        }

        public async Task<Tuple<byte[], string>> DownloadFile(string uId)
        {
            try
            {
                var tableValues = await this._patientStatementRepository.Get(Guid.Parse(uId));
                var attData = await this._attFileRepository.GetByTableId(tableValues.Id);

                return await this._attService.DownloadFile(attData.UId.ToString(), true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GeneratePatientForAutoStatement(int days)
        {
            var result = await this._reportRepository.GeneratePatientForAutoStatement(days);
            if (!string.IsNullOrWhiteSpace(result))
            {
                PatientStatementParameterDTO obj = new PatientStatementParameterDTO();
                obj.IsXML = true;
                obj.PatientId = result;
                var res = await GeneratePatientStatementXML(obj);
                //var returnData = Convert.ToBase64String(res.Item1);
                //return returnData;
            }
            else
            {
                throw new Exception("There are no records for this day difference");
            }
            return "true";
        }

        public async Task<Tuple<byte[], string>> GeneratePatientStatementXML(IPatientStatementParameterDTO patientStatement)
        {
            try
            {

                string restApiUrl = "";
                List<IFileResultDTO> mergeFilePath = new List<IFileResultDTO>();
                string fileName = _patientStatement;
                string filePath = "";
                var getPatientStatementReport = await this._reportRepository.GetPatientStatement();
                IPatientStatement patientStatementId = null;
                var practiceName = await this._practiceRepository.Get();
                var practiceCode = this._practiceRepository.GetLoggedUser();

                var convertIntoGUid = await this._reportParameterService.ConvertGUIDToId(patientStatement);
                string[] patientIds = convertIntoGUid.PatientId.Split(',');

                patientStatement.PatientId = convertIntoGUid.PatientId;
                patientStatement.PracticeName = practiceName.PracticeName;
                var serializeData = JsonConvert.SerializeObject(patientStatement);


                if (_isTestServerURL)
                {
                    //restApiUrl = $"http:\\40.77.104.76";
                    //restApiUrl = $"https:\\azdemo.apeasycloud.com";
                    restApiUrl = $"http:\\localhost:5001";
                }
                else
                {
                    restApiUrl = $"https:\\{practiceCode}.apeasycloud.com";
                }

                var responseString = await this._fullFrameworkRequestService.FullFrameWorkRequest("/api/Report/generatePatientStatementXML?=" + getPatientStatementReport.ID + "&restApiUrl=" + restApiUrl + "&practiceCode=" + practiceCode, serializeData);
                _logger.LogInformation("report path. ->" + responseString);

                // var resultResponse= await this._reportRepository.GeneratePatientStatementXML_SELF(getPatientStatementReport.ID, patientStatement, @"c:\\temp");

                var deserializeData = JsonConvert.DeserializeObject<Dictionary<int, object>>(responseString);
                _logger.LogInformation("deserializeData report path. ->" + deserializeData);

                IBatchStatement objBatchStatement = null;
                if (patientIds.Count() > 0)
                {
                    BatchStatement batchStatement = new BatchStatement();
                    batchStatement.IsXml = true;
                    objBatchStatement = await this._batchStatementRepository.AddNew(batchStatement);

                }
                foreach (var item in patientIds)
                {
                    fileName = _patientStatement;
                    fileName = fileName + "-" + practiceCode + "-" + item + '-' + Guid.NewGuid().ToString() + ".xml";
                    //creating file path where file have to move
                    var path = this.FilePath("", false, practiceCode);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = Path.Combine(path, fileName);
                    //move file from genrated file path to our directory path
                    int patientId = Convert.ToInt32(item);

                    var result = deserializeData.FirstOrDefault(i => i.Key == patientId);
                    string sourceFileName = "";
                    if (result.Value != null)
                    {
                        sourceFileName = result.Value.ToString();

                        _logger.LogInformation("moving file.");
                        File.Move(sourceFileName, filePath);
                        _logger.LogInformation("file moving successfully.");

                        var bytes = File.ReadAllBytes(filePath);
                        mergeFilePath.Add(new FileResultDTO(fileName, bytes));

                        string fromDate = patientStatement.FromDate == null ? null : patientStatement.FromDate;
                        string toDate = patientStatement.ToDate == null ? null : patientStatement.ToDate;

                        var patientStatementObject = await this.CreateObject(item, fromDate, toDate, objBatchStatement.Id, true);
                        _logger.LogInformation("inserting patientStatement row.");

                        patientStatementId = await this._patientStatementRepository.AddNew(patientStatementObject);
                        _logger.LogInformation("inserted patientStatement row.");

                        await this._attFileRepository.CreateAttachments(null, patientStatementId.Id, AttTableConstant.PatientStatements, fileName, practiceCode, true);
                        _logger.LogInformation("inserted CreateAttachment row.");
                    }
                }

                string tempFileName = fileName;

                if (!Directory.Exists(_baseBatchStatementDirectory + "\\" + practiceCode))
                {
                    Directory.CreateDirectory(_baseBatchStatementDirectory + "\\" + practiceCode);
                }

                fileName = Path.Combine(_baseBatchStatementDirectory + "\\" + practiceCode, fileName);
                _logger.LogInformation("fileName . " + fileName);
                var mergedFile = this._statementFileService.CombineXmlFiles(mergeFilePath, fileName);

                await this._attFileRepository.CreateAttachments(null, objBatchStatement.Id, AttTableConstant.BatchStatement, tempFileName, practiceCode, true);

                var fileData = File.ReadAllBytes(mergedFile);
                _logger.LogInformation("fileData - " + fileData);
                string extensions = Path.GetExtension(mergedFile);
                extensions = extensions.Replace(".", "");

                var contentType = this.ContentType(extensions);

                var returnData = Tuple.Create<byte[], string>(fileData, contentType);
                return returnData;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception . " + ex.StackTrace);
                throw ex;
            }
        }

        public async Task<string> GeneratePatientFromExcelImport(IFormFile file)
        {
            var filesToDelete = new List<string>();
            var name = Path.GetFileName(file.FileName);
            var extension = Path.GetExtension(name);
            var tempFilePath = Path.GetTempFileName();
            filesToDelete.Add(tempFilePath);
            // full path to file in temp location
            var filePath = tempFilePath + "_" + DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + "_" + name;
            filesToDelete.Add(filePath);
            try
            {
                await FileOperations.CreateFileUsingIFromFile(file, filePath);
                if (extension == ".csv")
                {
                    string csvFileName = filePath;
                    string excelFileName = filePath + ".xlsx";
                    FileOperations.ConvertCsvToXlsx(excelFileName, csvFileName);
                    filePath = excelFileName;
                }

                List<string> lstPatientIds = new List<string>();

                FileInfo fileInfo = new FileInfo(Path.Combine(filePath));
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    if ((ColCount >= 1) && rowCount > 0)
                    {
                        string patientIds = "";

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var id = Convert.ToString(worksheet.Cells[row, 1].Value);
                            lstPatientIds.Add(id);
                            //if (row == 2)
                            //{
                            //    patientIds = id.ToString();
                            //}
                            //else
                            //{
                            //    patientIds += "," + id.ToString();
                            //}
                        }
                    }

                }
                if (lstPatientIds.Count > 0)
                {
                    var patientUids = await _patientStatementRepository.GetPatientByIds(lstPatientIds);
                    await CreateStatmentBatch(patientUids);
                }
                return "true";

            }
            catch
            {
                throw;
            }
            finally
            {
                try
                {
                    await FileOperations.DeleteFiles(filesToDelete);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        private async Task CreateStatmentBatch(string patientUids)
        {
            try
            {
                PatientStatementParameterDTO obj = new PatientStatementParameterDTO();
                obj.IsXML = true;
                obj.PatientId = patientUids;
                var res = await GeneratePatientStatementXML(obj);
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<IPatientStatementRDLCDTO>> GetPatientAgingBalances_BatchStatement(string uid)
        {
            var result = await this._reportRepository.usp_GetPatientAgingBalances_BatchStatement(uid);
            var results = _mapper.Map<List<PatientStatementRDLCDTO>>(result);
            return results;

        }

        public async Task<Tuple<byte[], string>> DownloadBatchStatementFile(string uId)
        {
            try
            {
                var tableValues = await this._batchStatementRepository.Get(Guid.Parse(uId));
                var attData = await this._attFileRepository.GetByTableIdBatchStatment(tableValues.Id);

                return await this._attService.DownloadBatchStatmentFile(attData.UId.ToString(), true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UploadBatchStatementFile(string uId)
        {
            try
            {
                var tableValues = await this._batchStatementRepository.Get(Guid.Parse(uId));
                var attData = await this._attFileRepository.GetByTableIdBatchStatment(tableValues.Id);

                var item = await this._attService.DownloadBatchStatmentFile(attData.UId.ToString(), true);

                var result = await this._batchStatementRepository.SaveFileOnSFTPFile(attData.FileName, ".xml", item.Item1);
                if (result == true)
                {
                    await this._batchStatementRepository.Update(tableValues.UId);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UploadBatchStatementOnly(string uId)
        {
            try
            {
                await this._batchStatementRepository.Update(Guid.Parse(uId));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<byte[], string>> GetLabPatientBalancesStatments(IPatientStatementParameterDTO patientStatementParameterDTO)
        {
            string fileContentResult = "";

            var patient = await this._patientRepository.GetByUId(Guid.Parse(patientStatementParameterDTO.PatientId));

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var practice = await this._practiceRepository.Get();
                    if(string.IsNullOrWhiteSpace(practice.LabURL))
                    {
                        throw new Exception("No Lab configration found.");
                    }

                    string token = await _reportRepository.GetBillingToken(practice.LabURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    PatientStatementParameterDTO patientStatementParameter = new PatientStatementParameterDTO()
                    {
                        PatientId = patient.BillingID.ToString(),
                        IsFromEMR = true
                    };
                    string jsonString = JsonConvert.SerializeObject(patientStatementParameter, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    content.Headers.ContentLength = jsonString.Length;

                    HttpResponseMessage response = client.PostAsync(practice.LabURL + "api/Report/GetPatientStatementEMR", content).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                       
                    }
                    else
                    {
                        fileContentResult = await response.Content.ReadAsAsync<string>();
                    }
                }
                

                byte[] fileData = System.Convert.FromBase64String(fileContentResult);

                
                var contentType = this.ContentType("pdf");

                var returnData = Tuple.Create<byte[], string>(fileData, contentType);
                return returnData;
                //string fileName = "Statement_" + patientId + "_" + DateTime.Now.ToString("MM-dd-yyyy");
                //return new FileResult(fileName, "application/pdf", Convert.FromBase64String(fileContentResult));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GenerateBatchStatements()
        {

            var practice = await this._practiceRepository.Get();

            var listCharges = await this._chargesReportDataRepository.GetPatientForStatement();
            if(listCharges.Count()==0)
            {
                return 0;
            }

            var list = listCharges.GroupBy(i => i.PatientId).Select(g => new ChargesReportData
            {
                PatientId = g.FirstOrDefault().PatientId,
                DueAmount = g.Select(i => i.DueAmount).Sum()
            });

            var patientIds = list.Where(i=>i.DueAmount>10).Take(practice.AutoStatementCount).Select(i => i.PatientId).ToArray();

            List<List<int>> temppatientIds = new List<List<int>>();

            if (patientIds.Count() > 0)
            {
                temppatientIds = CollectionChunksHelper.Chunk(patientIds, practice.AutoStatementCount);
            }
            string transactionId = this._transactionProvider.StartTransaction(true);

            try
            {
                foreach (var item in temppatientIds)
                {
                    try
                    {
                        string ptIds = String.Join(",", item);
                        var totalBatchAmount = list.Where(i => item.Contains(i.PatientId)).Sum(i => i.DueAmount);

                        var chargelist = list.Where(i => item.Contains(i.PatientId));

                        BatchStatement batchStatement = new BatchStatement();
                        batchStatement.BatchTotal = totalBatchAmount;
                        batchStatement.StatementCount = item.Count;
                        batchStatement.IsXml = true;
                        var objBatchStatement = await this._batchStatementRepository.AddNew(batchStatement);

                        var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        firstDayOfMonth = firstDayOfMonth.AddMonths(-1);
                        PatientStatementParameterDTO patientStatementParameterDTO = new PatientStatementParameterDTO();
                        patientStatementParameterDTO.FromDate = "1 Jan 2020";
                        patientStatementParameterDTO.ToDate = firstDayOfMonth.ToShortDateString();
                        patientStatementParameterDTO.IsFromEMR = false;
                        patientStatementParameterDTO.PatientId = ptIds;
                        patientStatementParameterDTO.PracticeName = practice.PracticeName;

                        List<Statement> statements = await this.GenerateBatchPatientStatement(patientStatementParameterDTO, chargelist, objBatchStatement);

                        var patientCharges = listCharges.Where(i=>item.Contains(i.PatientId));

                        List<ICharges> chargesForUpdate = new List<ICharges>();

                        foreach (var patientId in item)
                        {
                            var patientStatement = statements.FirstOrDefault(i => i.PatientId == patientId);

                            List<IChargeStatementCount> chargeStatementCounts = new List<IChargeStatementCount>();

                            

                            patientCharges.Where(i => i.PatientId == patientId).ToList().ForEach(x =>
                            {
                                ChargeStatementCount chargeStatementCount = new ChargeStatementCount();
                                chargeStatementCount.ChargeDueAmount = x.DueAmount.Value;
                                chargeStatementCount.ChargeId = x.ChargeId;
                                chargeStatementCount.PatientStatementId = patientStatement.PatientStatementId;
                                chargeStatementCount.StatementCount = x.PatientStatementCount+1;
                                chargeStatementCount.StatementDate = firstDayOfMonth;
                                chargeStatementCount.CreatedDate = DateTime.Now;
                                chargeStatementCounts.Add(chargeStatementCount);

                                Charges charge = new Charges();
                                charge.Id = x.ChargeId;
                                charge.PatientStatementCount = x.PatientStatementCount + 1;
                                chargesForUpdate.Add(charge);

                            });
                            await this._chargeStatementCountRepository.AddNew(chargeStatementCounts);
                        }



                        await this._chargesRepository.UpdatePatientStatementCount(chargesForUpdate);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }

                this._transactionProvider.CommitTransaction(transactionId);
            }
            catch (Exception ex )
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }

            

            return 0;
        }

        private async Task<List<Statement>> GenerateBatchPatientStatement(IPatientStatementParameterDTO patientStatement, 
            IEnumerable<IChargesReportData> charges, IBatchStatement objBatchStatement)
        {
            try
            {
                List<StatmentFileName> statmentFileNames = new List<StatmentFileName>();
                string restApiUrl = "";
                List<string> mergeFilePath = new List<string>();
                string fileName = _patientStatement;
                string filePath = "";
                var getPatientStatementReport = await this._reportRepository.GetPatientStatement();
                IPatientStatement patientStatementId = null;
                
                var practiceCode = this._practiceRepository.GetLoggedUser();


                string[] patientIds = patientStatement.PatientId.Split(',');

                if (patientIds.Count() > 1)
                {
                    patientStatement.IsBulkStatement = "True";
                }
                else if (patientIds.Count() == 1)
                {
                    patientStatement.IsBulkStatement = "False";
                }

                fileName = _patientStatement;

                //patientStatement.PracticeName = practiceName.PracticeName;
                var serializeData = JsonConvert.SerializeObject(patientStatement);

                if (_isTestServerURL)
                {
                    restApiUrl = $"http:\\localhost:5001";
                }
                else
                {
                    restApiUrl = $"https:\\{practiceCode}" + domainName;
                }

                var responseString = await this._fullFrameworkRequestService.FullFrameWorkRequest("/api/Report/generatePatientStatementBulk?=" + getPatientStatementReport.ID + "&restApiUrl=" + restApiUrl + "&practiceCode=" + practiceCode, serializeData);

                var reportsPath = JsonConvert.DeserializeObject<List<ReportResponse>>(responseString);

                List<Statement> statements = new List<Statement>();
                foreach (var item in patientIds)
                {
                    string fromDate = patientStatement.FromDate == null ? null : patientStatement.FromDate;
                    string toDate = patientStatement.ToDate == null ? null : patientStatement.ToDate;


                    var totalAmount = charges.FirstOrDefault(i => i.PatientId == Convert.ToInt32(item)).DueAmount;

                    var patientStatementObject = await this.CreateObject(item, fromDate, toDate, objBatchStatement.Id);
                    patientStatementObject.Note = patientStatement.Message != null ? patientStatement.Message : "";
                    if (patientStatement.IsFromEMR)
                        patientStatementObject.IsFromEMR = true;

                    patientStatementObject.TotalAmount = totalAmount;
                    patientStatementId = await this._patientStatementRepository.AddNew(patientStatementObject);
                    if (reportsPath.FirstOrDefault(i => i.PatientId == item) != null)
                    {
                        var statementFileName = reportsPath.FirstOrDefault(i => i.PatientId == item).FilePath;
                        await this._attFileRepository.CreateAttachments(null, patientStatementId.Id, AttTableConstant.PatientStatements, statementFileName, practiceCode, true);
                        mergeFilePath.Add(statementFileName);
                    }

                    Statement statement = new Statement();
                    statement.PatientId = Convert.ToInt32(item);
                    statement.PatientStatementId = patientStatementId.Id;
                    statements.Add(statement);

                }
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                fileName = Path.Combine(_baseDirectory + "\\" + practiceCode, fileName + timestamp + ".pdf");

                var mergedFile = await this._mergePdfFiles.CreatePDF(mergeFilePath, fileName);


                await this._attFileRepository.CreateAttachments(null, objBatchStatement.Id, AttTableConstant.BatchStatement, fileName, practiceCode, true);

                //var fileData = File.ReadAllBytes(mergedFile);

                //string extensions = Path.GetExtension(mergedFile);
                //extensions = extensions.Replace(".", "");

                //var contentType = this.ContentType(extensions);

                //var returnData = Tuple.Create<byte[], string>(fileData, contentType);
                return statements;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception . " + ex.StackTrace);
                throw ex;
            }
        }

        public async Task<int> GetPatientForStatementWithOurMedicaid(string patientUid)
        {
            return await this._chargesReportDataRepository.GetPatientForStatementWithOurMedicaid(patientUid);
        }

        private class Statement
        {
            public int PatientId { get; set; }
            public int PatientStatementId { get; set; }
        }
    }    
}
