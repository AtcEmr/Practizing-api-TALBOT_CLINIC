using PractiZing.Base.Repositories.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.Base.Service.ChargePaymentService;
using System.IO;
using Microsoft.Extensions.Configuration;

using PractiZing.DataAccess.Common;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.BatchPaymentService;
using PractiZing.Base.Object.ClaimService;

using Newtonsoft.Json;


using PractiZing.Base.Entities.MasterService;
using System.Text;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.Claim;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.ClaimCreator.Base;
using PractiZing.ClaimCreator.Form;
using PractiZing.ClaimCreator.Prof;
using PractiZing.Sftp;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.BusinessLogic.Common;
using EdiFabric.Templates.Hipaa5010;
using EdiFabric.Core.Model.Edi.X12;
using PractiZing.Base.Common;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class ClaimFileProcessService : IClaimFileProcessService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IClaimTotalRepository _claimTotalRepository;
        
        private readonly IClaimChargeRepository _claimChargeRepository;
        private readonly IInvDiagnosisRepository _invDiagnosisRepository;
        //private readonly IFillUB04FormService _fillUB04FormService;
        private readonly IClearingHouseRepository _clearingHouseRepository;
        private readonly IClaimBatchRepository _claimBatchRepository;
        private readonly IPracticeRepository _practiceRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IActionNoteRepository _actionNoteRepository;
        private readonly IScrubErrorRepository _scrubErrorRepository;
        private string _relativePath;
        private string _baseUrl;
        private string _claimFolder;
        private string _fileType;
        private string _filePath;
        private readonly IClaimConfigRepository _claimConfigRepository;
        private readonly IConfiguration _configuration;
        private readonly IClaimService _claimService;
        private readonly IPaymentChargeRepository _iPaymentChargeRepository;
        private readonly string _senderName;
        private ClaimFileCreator _claimFileCreator;
        private readonly IAppSettingRepository _appSettingRepository;
        private readonly IClaimStatusInquiryRepository _claimStatusInquiryRepository;
        private readonly IClaimStatusInquiryChildRepository _claimStatusInquiryChildRepository;
        private readonly IClaim824StatusRepository _claim824StatusRepository;
        private readonly ITransactionProvider _transactionProvider;


        public ClaimFileProcessService(IClaimRepository claimRepository, IClaimTotalRepository claimTotalRepository,IClaimChargeRepository claimChargeRepository, IInvDiagnosisRepository invDiagnosisRepository,
            IConfiguration configuration, IClearingHouseRepository clearingHouseRepository, IClaimBatchRepository claimBatchRepository,
            IPracticeRepository practiceRepository, IClaimConfigRepository claimConfigRepository, IInsuranceCompanyRepository insuranceCompanyRepository, IActionNoteRepository actionNoteRepository,
            IScrubErrorRepository scrubErrorRepository, IClaimService claimService, 
            IPaymentChargeRepository iPaymentChargeRepository,
            IClaimStatusInquiryRepository claimStatusInquiryRepository,
            IClaimStatusInquiryChildRepository claimStatusInquiryChildRepository,
            ClaimFileCreator claimFileCreator, IAppSettingRepository appSettingRepository,
            IClaim824StatusRepository claim824StatusRepository,
            ITransactionProvider transactionProvider)
        {
            this._claim824StatusRepository = claim824StatusRepository;
            this._claimStatusInquiryChildRepository = claimStatusInquiryChildRepository;
            this._claimStatusInquiryRepository = claimStatusInquiryRepository;
            this._appSettingRepository = appSettingRepository;
            this._claimRepository = claimRepository;
            this._claimTotalRepository = claimTotalRepository;
            this._transactionProvider = transactionProvider;
            this._claimChargeRepository = claimChargeRepository;
            this._invDiagnosisRepository = invDiagnosisRepository;
            //this._fillUB04FormService = ub04FillFormService;
            _baseUrl = configuration["ApplicationUrl"];
            _relativePath = configuration["AttachmentFolder"];
            _claimFolder = configuration["ClaimViewFolder"];
            _fileType = configuration["ClaimType"];
            _filePath = configuration["ApiPath"];
            _senderName = configuration["BillLast"];

            this._clearingHouseRepository = clearingHouseRepository;
            this._claimBatchRepository = claimBatchRepository;
            this._configuration = configuration;
            this._practiceRepository = practiceRepository;
            this._claimConfigRepository = claimConfigRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._actionNoteRepository = actionNoteRepository;
            this._scrubErrorRepository = scrubErrorRepository;
            this._claimService = claimService;
            this._iPaymentChargeRepository = iPaymentChargeRepository;
            this._claimFileCreator = claimFileCreator;
        }

        public async Task<string> ExportCms1500Async(Guid uId)
        {
            List<FileResultX> lstClaims = new List<FileResultX>();
            var claim = await _claimRepository.GetByUID(uId);
            var claimId = claim.Id;
            var claimTotalsRows = await _claimTotalRepository.GetByClaimId(claimId, 0);
            foreach (var item in claimTotalsRows)
            {

                int pageNumber = Convert.ToInt32(item.PageNumber);
                FileResultX exportCms1500Result =  await ExportPdfFile(claimId, pageNumber);
                lstClaims.Add(exportCms1500Result);
            }

            var path = GetCms1500PdfFile(lstClaims);
            //var path = Save(lstClaims[0].File);
            var jsonPath = JsonConvert.SerializeObject(path);
            return jsonPath;
        }

        public string GetCms1500PdfFile(List<FileResultX> files)
        {
          
            List<string> fileList = new List<string>();
            var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _claimFolder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _claimFolder);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileName = files.FirstOrDefault().Name.ToString().Split('_').FirstOrDefault();
            foreach (var item in files)
            {
                var pdfFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _claimFolder, item.Name) + ".pdf";

                if (File.Exists(pdfFileName))
                    File.Delete(pdfFileName);
                fileList.Add(pdfFileName);
                File.WriteAllBytes(pdfFileName, item.Bytes);
            }

            
            var firstDocument = PdfSharpCore.Pdf.IO.PdfReader.Open(fileList.FirstOrDefault().ToString(), PdfSharpCore.Pdf.IO.PdfDocumentOpenMode.Modify);

            int pageInsertNumber = 1;
            foreach (var item in fileList.Skip(1))
            {
                var document = PdfSharpCore.Pdf.IO.PdfReader.Open(item.ToString(), PdfSharpCore.Pdf.IO.PdfDocumentOpenMode.Import);
                var pdfpage = document.Pages[0];
                firstDocument.InsertPage(pageInsertNumber, pdfpage);
                pageInsertNumber = pageInsertNumber + 1;
            }

            string[] splitarrayList = fileList.FirstOrDefault().ToString().Split('_');
            var savedFileName = splitarrayList.ToList().FirstOrDefault();
            var _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _claimFolder, fileName) + ".pdf";

            firstDocument.Save(_fileName);

            _fileName = $"{_baseUrl}/{_relativePath}/{_claimFolder}/{fileName + ".pdf"}";

            return _fileName;
        }


        private async Task<FileResultX> ExportPdfFile(int claimId, int pageNumber)
        {
            
            var claim = await this._claimRepository.Get(claimId);
            Base.Model.Claim.IInsuranceClaimData claimData = null;
            FileResultX document = null;
            var claimTotal = await this._claimTotalRepository.GetByClaimId(claimId, pageNumber);
            if (claim != null)
            {
                claim.ClaimTotal = (await this._claimTotalRepository.GetByClaimId(claimId, pageNumber)).FirstOrDefault();

                var chargeList = await this._claimChargeRepository.GetByClaim(claimId, claim.InvoiceId, pageNumber);

                var inv = await this._invDiagnosisRepository.GetByInvoice(claim.InvoiceId);

                claim.InsuranceServices = chargeList;
                foreach (var item in chargeList)
                {
                    var array = new[] { item.ICD1, item.ICD2, item.ICD3, item.ICD4 };
                    string diagnose = string.Join(",", array.Where(s => !string.IsNullOrEmpty(s)));

                    List<string> invlist = (inv.Where(i => array.Contains(i.ICDCode))).Select(i => i.DiagnoseNo).ToList();
                    item.DiagnoseCode = string.Join("", invlist);
                }
                claim.InvDiagnoses = inv;

                switch (_fileType)
                {
                    case "Cms1500":
                        claimData = new Cms1500ClaimData(claim);
                        claimData = await SetBillingProvider(claim, claimData);
                        document = await _claimFileCreator.CreateFileAsync(FormTemplateType.CMS1500, claimData);
                        break;
                    case "UB04":
                        claimData = new UB04ClaimData(claim);
                        claimData = await SetBillingProvider(claim, claimData);
                       // document = await this._fillUB04FormService.GetFormAsync(claimData);
                        break;
                }
                
                string filename = document.Name + "_" + pageNumber.ToString();// + ".pdf";
                document.Name = filename;
            }
            return document;

        }

        private async Task<IInsuranceClaimData> SetBillingProvider(IClaim claim, IInsuranceClaimData claimData)
        {
            var insuranceCompany = await this._insuranceCompanyRepository.GetById(claim.InsuranceCompanyId);
            var insuranceCompanyUId = insuranceCompany == null ? Guid.Empty : insuranceCompany.UId;
            var _primaryConfigHCFAFormFields = await this._claimConfigRepository.Get(claim.CarrierTypeId, insuranceCompanyUId.ToString(), null);
            switch (_primaryConfigHCFAFormFields.Box33.ToString())
            {
                case "Doctor":
                    claimData.BillingProviderName = claim.BillingProviderFacilityName;
                    break;
                case "Clinic":
                    claimData.BillingProviderName = claim.BillingDoctorName;
                    break;

                default:
                    claimData.BillingProviderName = claim.BillingDoctorName;
                    break;
            }
            return claimData;

        }

        private string Save(FileResultX result)
        {

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _claimFolder);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string path = Path.Combine(filePath, "" + result.Name + "_batchReport.pdf");

            using (FileStream writer = new FileStream(path, FileMode.Create))
            {
                writer.Write(result.Bytes, 0, result.Bytes.Length);
            }
            return $"{_baseUrl}/{_relativePath}/{_claimFolder}/{result.Name + "_batchReport.pdf"}";
        }

        public async Task<string> ExportM837File(Guid batchUId)
        {
            try
            {
                var batchRecord = await this._claimBatchRepository.Get(batchUId);

                var clearningHouse = await this._clearingHouseRepository.GetById
                    (batchRecord != null ? batchRecord.ClearingHouseId.Value : 0);

                await this._claimBatchRepository.UpdateStatus(batchUId, BatchStatus.Pending, true, null);

                var inCorrectClaims = await this._claimService.UnBatchClaims(batchUId);

                var claims = await this._claimRepository.GetByBatchUId(batchUId);
                int[] claimIds = claims.Select(i => i.Id).Distinct().ToArray();
                await this._claimBatchRepository.UpdateClaimCount(batchUId, claims.Count());

                IEnumerable<ICharges> charges = await this._claimChargeRepository.GetByClaim(claimIds);

                try
                {


                    foreach (var item in claims)
                    {
                        item.ClaimTotal = (await this._claimTotalRepository.GetByClaimId(item.Id, 0)).FirstOrDefault();

                        var chargeList = await this._claimChargeRepository.GetByClaim(item.Id,item.InvoiceId, null);
                        if(item.InsLevel>1)
                        {
                            var previousPrimaryClaim = await this._claimRepository.GetByInvoiceIdByINSLevel(item.InvoiceId, 1);
                            foreach (var charge in chargeList)
                            {
                                charge.PaymentCharges = await this._iPaymentChargeRepository.GetPaymentsByChargeId(charge.Id);
                                foreach (var paymentItem in charge.PaymentCharges)
                                {
                                    paymentItem.InsuranceCompanyCode = previousPrimaryClaim.InsuranceCompanyCode;
                                    paymentItem.InsuranceCompanyId = previousPrimaryClaim.InsuranceCompanyId;
                                }
                            }
                            item.SecondaryPayerName = previousPrimaryClaim.PayerName;
                            item.SecondaryInsuranceCompanyCode = previousPrimaryClaim.InsuranceCompanyCode;
                            item.SecondaryPolicyHolderStreet = previousPrimaryClaim.PolicyHolderStreet;
                            item.SecondaryPolicyHolderCity = previousPrimaryClaim.PolicyHolderCity;
                            item.SecondaryPolicyHolderState = previousPrimaryClaim.PolicyHolderState;
                            item.SecondaryPolicyHolderZip = previousPrimaryClaim.PolicyHolderZip;
                            item.SecondaryPolicyHolderName = previousPrimaryClaim.PolicyHolderName;
                            item.SecondaryPolicyNo = previousPrimaryClaim.PolicyNo;
                            item.SecondaryPolicyHolderRelation = previousPrimaryClaim.PolicyHolderRelation;
                            item.SecondaryInsuranceType = previousPrimaryClaim.InsuranceType;
                            item.SecondaryFillingCode = previousPrimaryClaim.FillingCode;
                            item.SecondaryPolicyHolderGroupNo = previousPrimaryClaim.PolicyHolderGroupNo;
                            item.SecondaryPolicyHolderSignature = previousPrimaryClaim.PolicyHolderSignature;
                            item.SecondaryPatientSignatureOnFile = previousPrimaryClaim.PatientSignatureOnFile;
                        }

                        var inv = await this._invDiagnosisRepository.GetByInvoice(item.InvoiceId);

                        List<string> payerNames = new List<string>() { "81400", "25463", "10990", "87726",  "39026", "60054", "57604" };
                        var matchedPayer = payerNames.FirstOrDefault(i => i.ToLower().ToString() == item.InsuranceCompanyCode.ToLower());

                        item.InsuranceServices = chargeList;
                        foreach (var charge in chargeList)
                        {
                            var array = new[] { charge.ICD1, charge.ICD2, charge.ICD3, charge.ICD4 };
                            string diagnose = string.Join(",", array.Where(s => !string.IsNullOrEmpty(s)));

                            List<string> invlist = (inv.Where(i => array.Contains(i.ICDCode))).Select(i => i.DiagnoseNo).ToList();
                            charge.DiagnoseCode = string.Join("", invlist);
                            string code = null;
                            foreach (var item1 in invlist)
                            {

                                if (string.IsNullOrWhiteSpace(code))
                                    //code = (i + 1).ToString();
                                    code = (Convert.ToInt32(inv.ToList().FindIndex(x => x.DiagnoseNo == item1)) + 1).ToString();
                                else
                                    //code += "," + (i + 1).ToString();
                                    code += "," + (Convert.ToInt32(inv.ToList().FindIndex(x => x.DiagnoseNo == item1)) + 1).ToString();
                            }
                            charge.DiagnoseCode = code;

                            
                            if (item.CarrierTypeId!=4)
                            {
                                if (!string.IsNullOrWhiteSpace(charge.Mod1))
                                {
                                    if (charge.Mod1 == "GT")
                                    {
                                        charge.Mod1 = "95";
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod2))
                                {
                                    if (charge.Mod2 == "GT")
                                    {
                                        charge.Mod2 = "95";
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod3))
                                {
                                    if (charge.Mod3 == "GT")
                                    {
                                        charge.Mod3 = "95";
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod4))
                                {
                                    if (charge.Mod4 == "GT")
                                    {
                                        charge.Mod4 = "95";
                                    }
                                }
                            }    
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(charge.Mod1))
                                {
                                    if (charge.Mod1 == "95")
                                    {
                                        charge.Mod1 = "GT";
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod2))
                                {
                                    if (charge.Mod2 == "95")
                                    {
                                        charge.Mod2 = "GT";
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod3))
                                {
                                    if (charge.Mod3 == "95")
                                    {
                                        charge.Mod3 = "GT";
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod4))
                                {
                                    if (charge.Mod4 == "95")
                                    {
                                        charge.Mod4 = "GT";
                                    }
                                }
                            }

                            List<string> modifiers = new List<string>();
                            if (!string.IsNullOrWhiteSpace(charge.Mod1)) modifiers.Add(charge.Mod1);
                            if (!string.IsNullOrWhiteSpace(charge.Mod2)) modifiers.Add(charge.Mod2);
                            if (!string.IsNullOrWhiteSpace(charge.Mod3)) modifiers.Add(charge.Mod3);
                            if (!string.IsNullOrWhiteSpace(charge.Mod4)) modifiers.Add(charge.Mod4);

                            if (matchedPayer != null)
                            {
                                var gt95Mod = modifiers.FirstOrDefault(i => i.ToString() == "GT" || i.ToString() == "95");
                                if (gt95Mod != null)
                                {
                                    charge.POSId = "02";
                                }
                            }

                            if (charge.CPTCode == "H2019" && charge.Qty >= 6)
                            {
                                charge.POSId = "99";
                            }

                            if (item.CarrierTypeId != 4)
                            {
                                if (!string.IsNullOrWhiteSpace(charge.Mod1) && charge.Mod1.StartsWith("U"))
                                {
                                    charge.Mod1 = "";
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod2) && charge.Mod2.StartsWith("U"))
                                {
                                    charge.Mod2 = "";
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod3) && charge.Mod3.StartsWith("U"))
                                {
                                    charge.Mod3 = "";
                                }
                                if (!string.IsNullOrWhiteSpace(charge.Mod4) && charge.Mod4.StartsWith("U"))
                                {
                                    charge.Mod4 = "";
                                }
                                int xcount = 0;
                                while (xcount<1)
                                {
                                    if (!string.IsNullOrWhiteSpace(charge.Mod4))
                                    {
                                        if (string.IsNullOrWhiteSpace(charge.Mod3))
                                        {
                                            charge.Mod3 = charge.Mod4;
                                            charge.Mod4 = "";
                                            xcount = 0;
                                            continue;
                                        }
                                    }
                                    if (!string.IsNullOrWhiteSpace(charge.Mod3))
                                    {
                                        if (string.IsNullOrWhiteSpace(charge.Mod2))
                                        {
                                            charge.Mod2 = charge.Mod3;
                                            charge.Mod3 = "";
                                            xcount = 0;
                                            continue;
                                        }
                                    }
                                    if (!string.IsNullOrWhiteSpace(charge.Mod2))
                                    {
                                        if (string.IsNullOrWhiteSpace(charge.Mod1))
                                        {
                                            charge.Mod1 = charge.Mod2;
                                            charge.Mod2 = "";
                                            xcount = 0;
                                            continue;
                                        }
                                    }
                                    xcount++;
                                }
                                
                            }

                        }
                        item.InvDiagnoses = inv;
                        if (clearningHouse.SENDER_ID != "0021876")
                        {
                            item.IsSendAck = false;
                            item.SentDate = DateTime.Now;
                            item.Status = ClaimStatusEnum.SENT.ToString();
                        }
                        else
                        {                            
                            item.Status = ClaimStatusEnum.PROCESSING.ToString();
                        }
                        
                        await this._claimRepository.UpdateEntity(item);
                    }

                    // var submitter = await this._claimRepository.OrganizationSubmitterAsync(clearningHouse.SENDER_ID);

                    //submitter.Contacts = GetContactInfo();

                    //var converter = new ClaimProfessionalConverter(submitter, clearningHouse, DateTime.Now);

                    //string x12 = await converter.ConvertAsync((claims as IEnumerable<Claim>).ToArray());

                    var practice = await _practiceRepository.Get(clearningHouse.PracticeId);

                    var creator = new X12_837P_Creator(GetClaimOptions(clearningHouse,practice, batchRecord.ClaimBatchNumber));

                    string x12 = creator.Create((claims as IEnumerable<Claim>));

                    string path = "";

                    if (clearningHouse.SENDER_ID != "0021876")
                    {
                        path = await SaveSFTPFile(x12, clearningHouse, claims, batchUId);
                        await this._claimBatchRepository.UpdateStatus(batchUId, BatchStatus.Success, false, _relativePath + "/" + path);
                    }
                    else
                    {
                        path = await SaveClaimFileOnDeloitteFolder(x12, clearningHouse, claims, batchUId);                        
                        await this._claimBatchRepository.UpdateStatus(batchUId, BatchStatus.InProcess, false, _relativePath + "/" + path);
                    }

                    var jPath = JsonConvert.SerializeObject($"{_baseUrl}/{_relativePath}/{path}");

                    

                    foreach (var item in claimIds)
                    {                       
                        try
                        {

                            var chargesData = charges.Where(i => i.ClaimId == item).ToArray();
                            if (clearningHouse.SENDER_ID != "0021876")
                            {
                                await this._actionNoteRepository.CreateObject(0, chargesData, item, "Claim sent successfully (#" + item + ")");
                            }
                            else
                            {
                                await this._actionNoteRepository.CreateObject(0, chargesData, item, "Claim under in processing (#" + item + ")");
                            }
                                
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    return jPath;
                }
                catch
                {
                    claims.ToList().ForEach((item) =>
                    {
                        item.SentDate = null;
                        item.Status = "CREATED";
                        item.IsSendAck = null;
                    });

                    await this._claimRepository.UpdateEntity(claims);

                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> SaveSFTPFile(string fileX12, IClearingHouse clearingHouse, IEnumerable<IClaim> claims, Guid batchUID)
        {
            try
            {
                SftpService sftpService = null;
                if (clearingHouse.IsOhioMedicaid.Value)
                {
                    sftpService = GetSftpServiceForDeloitte(clearingHouse);
                }
                else
                {
                    sftpService = GetSftpService(clearingHouse);
                }

                var practice = await _practiceRepository.Get(clearingHouse.PracticeId);
                string fileName = practice.PracticeCodeCLM + $"{(long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds}";

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, clearingHouse.FolderName);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string path = Path.Combine(filePath, "" + fileName + clearingHouse.ClaimExtension);

                var bytes = Encoding.UTF8.GetBytes(fileX12);

                using (FileStream writer = new FileStream(path, FileMode.Create))
                {
                    writer.Write(bytes, 0, bytes.Length);
                }

                await this._claimBatchRepository.UpdateFilePath(batchUID, $"{_relativePath}/{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}");

                if (clearingHouse.SENDER_ID == "0021876")
                {
                    await sftpService.UploadDeloitteAsync(fileName, sftpService.claimExtension, Encoding.UTF8.GetBytes(fileX12));
                    //await sftpService.UploadDeloitteAsync(fileName, sftpService.claimExtension, fileX12);
                    return $"{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}";
                }

                if (clearingHouse.RECVR_ID == "STEDI")
                {
                    await sftpService.UploadStediAsync(fileName, sftpService.claimExtension, Encoding.UTF8.GetBytes(fileX12));
                    //await sftpService.UploadDeloitteAsync(fileName, sftpService.claimExtension, fileX12);
                    return $"{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}";
                }

                await sftpService.UploadAsync(fileName, sftpService.claimExtension, Encoding.UTF8.GetBytes(fileX12));
                return $"{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}";

            }
            catch(Exception ex)
            {
                claims.ToList().ForEach((item) =>
                {
                    item.SentDate = null;
                    item.Status = "PROCESSING";
                });

                await this._claimRepository.UpdateEntity(claims);

                //await _practiceRepository.ThrowPermissionDeniedError();
                throw ex;
            }
        }

        public async Task<bool> Upload837DeloitteFiles_Bulk_Old()
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                var claimbatch = await this._claimBatchRepository.GetclaimBatchForBulkUpload();

                var clearingHouse = await this._clearingHouseRepository.GetById(3);
                
                foreach (var item in claimbatch)
                {
                    var claims = await this._claimRepository.GetByBatchUId(item.UId);
                    foreach (var claim in claims)
                    {
                        claim.IsSendAck = false;
                        claim.SentDate = DateTime.Now;
                        claim.Status = ClaimStatusEnum.SENT.ToString();
                        await this._claimRepository.UpdateEntity(claim);
                    }


                    string[] splitname = item.FilePath.Split("/")[2].Split(".");
                    string fileMovedPath = Path.Combine(_relativePath, clearingHouse.FolderName, "Archived", splitname[0] + clearingHouse.ClaimExtension);
                    await this._claimBatchRepository.UpdateStatus(item.UId, BatchStatus.Success, false, fileMovedPath);
                }


                var sftpService = GetSftpServiceForDeloitte(clearingHouse);

                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, clearingHouse.FolderName);

                await sftpService.Upload837FileToDeloitteAsync(claimbatch.Select(i => i.FilePath).ToArray(), clearingHouse.ClaimExtension, folderPath);

                this._transactionProvider.CommitTransaction(transactionId);

                return true;
            }
            catch (Exception ex)
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<bool> Upload837DeloitteFiles_Bulk()
        {
            try
            {
                var claimbatch = await this._claimBatchRepository.GetclaimBatchForBulkUpload();

                var clearingHouse = await this._clearingHouseRepository.GetById(3);

                var sftpService = GetSftpServiceForDeloitte(clearingHouse);

                sftpService.SetCurrentDirectory(clearingHouse.ClaimExtension);

                var connection = sftpService.GetDeloitteConnection();
                using (var sftp = new SftpClient(connection))
                {
                    sftp.Connect();

                    foreach (var item in claimbatch)
                    {
                        string transactionId = this._transactionProvider.StartTransaction(true);
                        try
                        {
                            var claims = await this._claimRepository.GetByBatchUId(item.UId);
                            foreach (var claim in claims)
                            {
                                claim.IsSendAck = false;
                                claim.SentDate = DateTime.Now;
                                claim.Status = ClaimStatusEnum.SENT.ToString();
                                await this._claimRepository.UpdateEntity(claim);
                            }


                            string[] splitname = item.FilePath.Split("/")[2].Split(".");
                            string fileMovedPath = Path.Combine(_relativePath, clearingHouse.FolderName, "Archived", splitname[0] + clearingHouse.ClaimExtension);
                            await this._claimBatchRepository.UpdateStatus(item.UId, BatchStatus.Success, false, fileMovedPath);

                            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, clearingHouse.FolderName);

                            //await sftpService.Upload837FileToDeloitteAsync(claimbatch.Select(i => i.FilePath).ToArray(), clearingHouse.ClaimExtension, folderPath);


                            
                            string filePath = Path.Combine(folderPath, splitname[0] + clearingHouse.ClaimExtension);

                            string desPath = clearingHouse.ClaimDirectory + "/" + splitname[0] + clearingHouse.ClaimExtension;
                            var content = await File.ReadAllBytesAsync(filePath);
                            using (Stream stream = new MemoryStream(content))
                            {
                                await sftp.UploadFileAsync(stream, desPath);

                                fileMovedPath = Path.Combine(folderPath, "Archived", splitname[0] + clearingHouse.ClaimExtension);
                                File.Move(filePath, fileMovedPath);
                            }

                            this._transactionProvider.CommitTransaction(transactionId);
                        }
                        catch (Exception)
                        {
                            this._transactionProvider.RollbackTransaction(transactionId);

                        }
                       
                    }

                    sftp.Disconnect();
                    //await sftp.WriteAllBytesAsync(Path.Combine(_currentDirectory, $"{fileName}{_currentExtension}"), contents);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return true;
        }

        public async Task<string> SaveClaimFileOnDeloitteFolder(string fileX12, IClearingHouse clearingHouse, IEnumerable<IClaim> claims, Guid batchUID)
        {
            try
            {
                var practice = await _practiceRepository.Get(clearingHouse.PracticeId);
                string fileName = practice.PracticeCodeCLM + $"{(long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds}";

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, clearingHouse.FolderName);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string path = Path.Combine(filePath, "" + fileName + clearingHouse.ClaimExtension);

                var bytes = Encoding.UTF8.GetBytes(fileX12);

                using (FileStream writer = new FileStream(path, FileMode.Create))
                {
                    writer.Write(bytes, 0, bytes.Length);
                }

                await this._claimBatchRepository.UpdateFilePath(batchUID, $"{_relativePath}/{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}");
                
                return $"{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}";

            }
            catch (Exception ex)
            {
                claims.ToList().ForEach((item) =>
                {
                    item.SentDate = null;
                    item.Status = "CREATED";
                });

                await this._claimRepository.UpdateEntity(claims);

                //await _practiceRepository.ThrowPermissionDeniedError();
                throw ex;
            }
        }

        
        private static SftpService GetSftpService(IClearingHouse clearingHouse)
        {
            return new SftpService(clearingHouse.Host, clearingHouse.HostPort.Value,
                clearingHouse.UserName, clearingHouse.Password,
                clearingHouse.ClaimDirectory, clearingHouse.ClaimExtension,
                clearingHouse.ERADirectory, clearingHouse.ERAExtension, clearingHouse.AckDirectory,
                clearingHouse.AckExtension,clearingHouse.StatementDirectory,clearingHouse.StatementExtension);
        }

        private static SftpService GetSftpServiceForDeloitte(IClearingHouse clearingHouse)
        {
            return new SftpService(clearingHouse.Host, clearingHouse.HostPort.Value,
                clearingHouse.UserName, clearingHouse.Password,
                clearingHouse.ClaimDirectory, clearingHouse.ClaimExtension,
                clearingHouse.ERADirectory, clearingHouse.ERAExtension, clearingHouse.AckDirectory,
                clearingHouse.AckExtension, clearingHouse.PrivateKeyFilePath);
        }

        //private ISubmitterContacts GetContactInfo()
        //{
        //    var sub = new SubmitterContacts();
        //    sub.Phone = this._configuration["phoneNumber"];
        //    sub.Fax = this._configuration["Fax"];
        //    sub.Email = this._configuration["Email"];
        //    sub.Extension = this._configuration["Extension"];
        //    return sub;
        //}

        public PracticeConfig GetSenderConfig(string senderId, string practiceName)
        {
            PracticeConfig practiceConfig = new PracticeConfig();
            practiceConfig.Code = senderId;
            practiceConfig.Name = practiceName;
            practiceConfig.Contact = new PracticeContact();
            practiceConfig.Contact.Phone = this._configuration["phoneNumber"];
            practiceConfig.Contact.Fax = this._configuration["Fax"];
            practiceConfig.Contact.Email = this._configuration["Email"];
            practiceConfig.Contact.Extension = this._configuration["Extension"];

            return practiceConfig;
        }

        private List<string> GetEMCodes()
        {
            List<string> strList = new List<string>();
            var item = this._appSettingRepository.GetAppSettingEMCodes().Result;

            if(item!=null && !string.IsNullOrWhiteSpace(item.SettingValue))
            {
                string[] codes = item.SettingValue.Split(",");                
                foreach (var str in codes)
                {
                    strList.Add(str);
                }
            }

            return strList;
        }


        private ClaimOptions GetClaimOptions(IClearingHouse clearingHouse, IPractice practice, string claimBatchNumber)
        {
            ClaimOptions options = new ClaimOptions();
            options.ClearingHouse = clearingHouse;
            options.PracticeConfig = GetSenderConfig(clearingHouse.SENDER_ID,practice.PracticeName);
            options.TransactionDate = DateTime.Now;
            options.CptCodes = GetEMCodes();
            options.ClaimBatchNumber = claimBatchNumber;
            return options;
        }

        public async Task<IEnumerable<IClaimAckDTO>> GetForACK()
        {
            return await this._claimRepository.GetForACK();
        }

        public async Task<int> UpdateClaimAfterNotifyRevdx(long id)
        {
            return await this._claimRepository.UpdateClaimAfterNotifyRevdx(id);
        }

        private DirectoryInfo CheckDirectory(string folderName)
        {
            try
            {

                //get the current directory of this service
                string basePath = this._configuration["FolderPath"];
                if (string.IsNullOrEmpty(basePath))
                    basePath = Directory.GetCurrentDirectory();
                //add current directory with folder name
                string sourcePath = Path.Combine(basePath, folderName);

                //if combined sourcepath not exist then craete
                if (!Directory.Exists(sourcePath))
                {

                    Directory.CreateDirectory(sourcePath);

                }
                DirectoryInfo filePath = new DirectoryInfo(sourcePath);

                return filePath;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> Read277()
        {
            DirectoryInfo filePath = null;
            FileInfo[] files = null;
            var path277File = await this._appSettingRepository.Get277FilePath();

            string sourceFileFolder = path277File.SettingValue; //@"C:/DSIG/PractizingProjects/837P_OHIOMedicaid/277";
            filePath = this.CheckDirectory(sourceFileFolder);

            var processedFolderPath = sourceFileFolder + "//Processed//";
            var errorFolderPath = sourceFileFolder + "//Error//";

            files = filePath.GetFiles();//.Where(s => s.Name.Contains("277")).ToArray();            


            foreach (var item in files)
            {
                try
                {
                    var reader = new X12_999_Reader();
                    var rawObjects = reader.Read(item, sourceFileFolder);
                    var claims277 = rawObjects.Where(x => x.GetType().Name == "TS277A").ToList();

                    List<IClaimStatusInquiryChild> lst = null;

                    foreach (TS277A ack277 in claims277)
                    {
                        lst = new List<IClaimStatusInquiryChild>();
                        //var patientControlNumber = ack277.Loop2000A.Loop2000B.Loop2200B.TRN_InformationReceiverApplicationTraceIdentifier.CurrentTransactionTraceNumber_02;
                        var patientControlNumber = ack277.Loop2000A.Loop2000B.Loop2000C.FirstOrDefault().Loop2000D.FirstOrDefault().Loop2200D.FirstOrDefault().TRN_ClaimStatusTrackingNumber.CurrentTransactionTraceNumber_02;
                        if (patientControlNumber.Contains("-"))
                        {

                            string[] str = patientControlNumber.Split("-");

                            ClaimStatusInquiry claimStatusInquiry = new ClaimStatusInquiry();
                            claimStatusInquiry.ClaimId = Convert.ToInt32(str[1].ToString());
                            var claimStatusInq = await this._claimStatusInquiryRepository.AddNew(claimStatusInquiry);

                            var stcLoops = ack277.Loop2000A.Loop2000B.Loop2000C.FirstOrDefault().Loop2000D.FirstOrDefault().Loop2200D.FirstOrDefault().STC_ClaimLevelStatusInformation;
                            foreach (var stcLoop in stcLoops)
                            {
                                ClaimStatusInquiryChild claimStatusInquiryChild = new ClaimStatusInquiryChild();
                                claimStatusInquiryChild.ClaimStatusInquiryId = claimStatusInq.Id;

                                claimStatusInquiryChild.CategoryCode = stcLoop.HealthCareClaimStatus_01.HealthCareClaimStatusCategoryCode_01;
                                claimStatusInquiryChild.CategoryCodeDescription = EDIHelpers277.ClaimStatusCategory().FirstOrDefault(i => i.Key == stcLoop.HealthCareClaimStatus_01.HealthCareClaimStatusCategoryCode_01).Value;
                                claimStatusInquiryChild.StatuCode = stcLoop.HealthCareClaimStatus_01.StatusCode_02;
                                claimStatusInquiryChild.StatuCodeDescription = EDIHelpers277.ClaimStatusCodes().FirstOrDefault(i => i.Key == stcLoop.HealthCareClaimStatus_01.StatusCode_02).Value;
                                claimStatusInquiryChild.CheckNumber = stcLoop.CheckNumber_09;

                                claimStatusInquiryChild.IdentifierCode = stcLoop.HealthCareClaimStatus_01.EntityIdentifierCode_03;
                                claimStatusInquiryChild.IdentifierDescription = EDIHelpers277.ClaimStatus_STC01_3().FirstOrDefault(i => i.Key == stcLoop.HealthCareClaimStatus_01.EntityIdentifierCode_03).Value;
                                claimStatusInquiryChild.MonetaryAmount = Convert.ToDecimal(stcLoop.MonetaryAmount_05);
                                claimStatusInquiryChild.PaymentMethodCode = stcLoop.PaymentMethodCode_07;
                                claimStatusInquiryChild.TransactionNumber = "";
                                claimStatusInquiryChild.ErrorMessage = stcLoop.FreeformMessageText_12;
                                claimStatusInquiryChild.Soruce = "277";
                                lst.Add(claimStatusInquiryChild);
                            }
                            if (lst.Count > 0)
                            {
                                await this._claimStatusInquiryChildRepository.AddNew(lst);
                            }
                        }
                    }
                    MoveFiles(item.FullName, processedFolderPath + item.Name);
                }
                catch (Exception ex)
                {
                    MoveFiles(item.FullName, errorFolderPath + item.Name);
                }
            }
            return "";
        }

        public async Task<string> Read824()
        {
            DirectoryInfo filePath = null;
            FileInfo[] files = null;
            var path824File = await this._appSettingRepository.Get824FilePath();
            
            string sourceFileFolder = path824File.SettingValue; //@"C:/DSIG/PractizingProjects/837P_OHIOMedicaid/277";
            filePath = this.CheckDirectory(sourceFileFolder);

            var processedFolderPath = sourceFileFolder + "//Processed//";
            var errorFolderPath = sourceFileFolder + "//Error//";

            files = filePath.GetFiles().ToArray();
            
            foreach (var item in files)
            {
                try
                {
                   
                    var reader = new X12_999_Reader();
                    var rawObjects = reader.Read(item, sourceFileFolder);
                    var claims824 = rawObjects.Where(x => x.GetType().Name == "TS824").ToList();

                    
                     ISA isa = rawObjects.FirstOrDefault(x => x.GetType().Name == "ISA") as ISA;

                    foreach (TS824 ack824 in claims824)
                    {
                        string transactionType = ack824.OTILoop.FirstOrDefault().OTI.TransactionSetIdentifierCode_10;
                        if(transactionType=="837")
                        {
                            string clearingHouseTransactionNo = ack824.BGN_BeginningSegment.OriginalTransactionSetReferenceNumber_06;
                            string payerCode = isa.InterchangeSenderID_6;
                            string claimBatchNumber = ack824.OTILoop.FirstOrDefault().OTI.GroupControlNumber_08;
                            string claimTransactionNumber = ack824.OTILoop.FirstOrDefault().OTI.TransactionSetControlNumber_09;
                            string errorCode = ack824.OTILoop.FirstOrDefault().TEDLoop.FirstOrDefault().RED.FirstOrDefault().IndustryCode_06;
                            string errorDesc = EDIHelpers277.EDI_ERROR_Codes().FirstOrDefault(i => i.Key == errorCode).Value;

                            EDI824 eDI824 = new EDI824();
                            eDI824.ClaimBatchNumber = claimBatchNumber.Trim();
                            eDI824.ClaimTransactionNumber = claimTransactionNumber.Trim();
                            eDI824.ErrorCode = errorCode.Trim();
                            eDI824.ErrorDesc = errorDesc.Trim();
                            eDI824.ClearingHouseTransactionNo = clearingHouseTransactionNo.Trim();
                            eDI824.PayerCode = payerCode.Trim();

                            await this._claim824StatusRepository.AddNew(eDI824);
                        }                        
                    }
                    MoveFiles(item.FullName, processedFolderPath + item.Name);
                }
                catch (Exception ex)
                {
                    MoveFiles(item.FullName, errorFolderPath + item.Name);
                }
            }
            return "";
        }

        //        CREATE TABLE EDI824
        //(
        //    Id BIGINT IDENTITY(1,1)     PRIMARY KEY,
        //    ClearingHouseTransactionNo  VARCHAR(50),
        //	PayerCode VARCHAR(10),
        //	ClaimBatchNumber VARCHAR(20),
        //	ClaimTransactionNumber VARCHAR(20),
        //	ErrorCode VARCHAR(20),
        //	ErrorDesc VARCHAR(500),
        //	IsFound SMALLINT DEFAULT(0),
        //	PracticeName VARCHAR(50),
        //	Note VARCHAR(200),
        //	CreatedDate DATETIME
        //  ClaimId INT,
        //)

        private void MoveFiles(string fromfilepath, string tofilepath)
        {
            if (File.Exists(tofilepath))
            {
                File.Delete(tofilepath);
            }

            File.Copy(fromfilepath, tofilepath);
            File.Delete(fromfilepath);
        }

        public async Task<string> Upload270EdiFilesToDeloitte()
        {
            DirectoryInfo filePath = null;
            FileInfo[] files = null;

            var clearingHouse = await this._clearingHouseRepository.GetById(3);

            var path270File = await this._appSettingRepository.Get270FilePath();

            string sourceFileFolder = path270File.SettingValue; //@"C:/DSIG/PractizingProjects/837P_OHIOMedicaid/277";

            SftpService sftpService = null;
            sftpService = GetSftpServiceForDeloitte(clearingHouse);
            
            filePath = this.CheckDirectory(sourceFileFolder);

            var processedFolderPath = sourceFileFolder + "//Processed//";
            var errorFolderPath = sourceFileFolder + "//Error//";

            files = filePath.GetFiles().ToArray();

            foreach (var item in files)
            {
                try
                {
                    var strByte = File.ReadAllBytes(item.FullName);
                    await sftpService.UploadDeloitteAsync(item.Name, sftpService.claimExtension, strByte);

                    MoveFiles(item.FullName, processedFolderPath + item.Name);
                }
                catch (Exception ex)
                {
                    MoveFiles(item.FullName, errorFolderPath + item.Name);
                }                
            }

            return "";
        }

        public async Task<bool> Create837PEdiFiles(int clearingHouseId)
        {
            var claimbatchs = await this._claimBatchRepository.GetClaimsForCreate837PEdiFile(clearingHouseId);
            foreach (var item in claimbatchs)
            {
                try
                {
                    await ExportM837File(item.UId);
                }
                catch (Exception ex)
                {

                }
            }

            return true;
        }
    }
}
