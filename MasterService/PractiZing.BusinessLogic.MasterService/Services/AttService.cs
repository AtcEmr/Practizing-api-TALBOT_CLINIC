using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.MasterService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class AttService : IAttService
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IActionNoteRepository _actionNoteRepository;
        private readonly IPaymentBatchRepository _paymentBatchRepository;
        private readonly IChargeBatchRepository _chargeBatchRepository;
        private readonly IActionCategoryRepository _actionCategoryRepository;
        private readonly IPatientStatementRepository _patientStatementRepository;
        private readonly IAttFileRepository _attFileRepository;
        private ILogger _logger;
        private IConfiguration _configuration;
        private string _statementPath;
        private string _baseBatchStatementDirectory;

        public AttService(IVoucherRepository voucherRepository,
                          IActionNoteRepository actionNoteRepository,
                          IPaymentBatchRepository paymentBatchRepository,
                          IChargeBatchRepository chargeBatchRepository,
                          IActionCategoryRepository actionCategoryRepository,
                          IPatientStatementRepository patientStatementRepository,
                          IAttFileRepository attFileRepository,
                           IConfiguration configuration,
                          ILogger<AttService> logger)
        {
            this._voucherRepository = voucherRepository;
            this._actionNoteRepository = actionNoteRepository;
            this._paymentBatchRepository = paymentBatchRepository;
            this._chargeBatchRepository = chargeBatchRepository;
            this._actionCategoryRepository = actionCategoryRepository;
            this._patientStatementRepository = patientStatementRepository;
            this._attFileRepository = attFileRepository;
            this._configuration = configuration;
            _statementPath = configuration["BaseWindowDirectory"];
            this._baseBatchStatementDirectory = configuration["BaseBatchStatementDirectory"];
            this._logger = logger;
        }

        public async Task<Tuple<byte[], string>> DownloadFile(string uid, bool isReport = false)
        {
            try
            {
                byte[] file = null;
                string contentType = "";

                var fileData = await this._attFileRepository.GetByUId(Guid.Parse(uid));
                if (fileData != null)
                {
                    var tableName = await this.Get(fileData.AttFileTableId);
                   // var getData = await this.GetAttTableFileData(fileData.TableIdValue, tableName);
                    var fileName = isReport ? fileData.FileName + fileData.FileNameExt.ToString() : fileData.UId.ToString() + fileData.FileNameExt.ToString();

                    var getPath = isReport ? this._attFileRepository.FilePath(_statementPath, fileData.FileNameExt, fileName, true) : this._attFileRepository.FilePath(fileData.FullPath, fileData.FileNameExt, fileName);
                    _logger.LogInformation("getPath - " + getPath);

                    if (File.Exists(getPath))
                    {
                        file = File.ReadAllBytes(getPath);

                        string extensions = Path.GetExtension(getPath);
                        extensions = extensions.Replace(".", "");

                        contentType = this._attFileRepository.ContentType(extensions.ToLower());
                    }
                }

                var returnData = Tuple.Create<byte[], string>(file, contentType);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SaveFile(IFormFile file, string fileName, string folderInnerName)
        {
            var getAttTableValueData = await this.GetAttTableFileData(new Guid(fileName), folderInnerName);
            var getAttData = await this._attFileRepository.GetFilesByTypes(getAttTableValueData, folderInnerName, Path.GetExtension(file.FileName));
            if (getAttData > 0)
            {
                await this._attFileRepository.SaveFile(file, fileName, folderInnerName);
            }

            return "";
        }

        private async Task<Guid> GetAttTableFileData(int Id, string type)
        {
            Guid returnUid = new Guid();
            switch (type.ToLower())
            {
                case "voucher":
                    returnUid = (await this._voucherRepository.Get(Id)).UId;
                    break;
                case "chargebatch":
                    returnUid = (await this._chargeBatchRepository.Get(Id)).UId;
                    break;
                case "paymentbatch":
                    returnUid = (await this._paymentBatchRepository.GetById(Id)).UId;
                    break;
                case "actioncategory":
                    returnUid = (await this._actionCategoryRepository.GetById(Id)).UId;
                    break;
                case "actionnote":
                    returnUid = (await this._actionNoteRepository.Get(Id)).UId;
                    break;
            }

            return returnUid;
        }

        private async Task<int> GetAttTableFileData(Guid UId, string type)
        {
            int returnId = 0;
            switch (type.ToLower())
            {
                case "voucher":
                    returnId = (await this._voucherRepository.GetByUId(UId)).Id;
                    break;
                case "chargebatch":
                    returnId = (await this._chargeBatchRepository.GetByUId(UId.ToString())).Id;
                    break;
                case "paymentbatch":
                    returnId = (await this._paymentBatchRepository.Get(UId)).Id;
                    break;
                case "actioncategory":
                    returnId = (await this._actionCategoryRepository.Get(UId)).Id;
                    break;
                case "actionnote":
                    returnId = (await this._actionNoteRepository.Get(UId)).Id;
                    break;
            }

            return returnId;
        }

        public async Task<Tuple<byte[], string>> DownloadBatchStatmentFile(string uid, bool isReport = false)
        {
            try
            {
                byte[] file = null;
                string contentType = "";

                var fileData = await this._attFileRepository.GetByUId(Guid.Parse(uid));
                if (fileData != null)
                {
                    var tableName = await this.Get(fileData.AttFileTableId);
                    // var getData = await this.GetAttTableFileData(fileData.TableIdValue, tableName);
                    var fileName = isReport ? fileData.FileName + fileData.FileNameExt.ToString() : fileData.UId.ToString() + fileData.FileNameExt.ToString();

                    var getPath = isReport ? this._attFileRepository.FilePath(_baseBatchStatementDirectory, fileData.FileNameExt, fileName, true) : this._attFileRepository.FilePath(fileData.FullPath, fileData.FileNameExt, fileName);
                    _logger.LogInformation("getPath - " + getPath);

                    if (File.Exists(getPath))
                    {
                        file = File.ReadAllBytes(getPath);

                        string extensions = Path.GetExtension(getPath);
                        extensions = extensions.Replace(".", "");

                        contentType = this._attFileRepository.ContentType(extensions.ToLower());
                    }
                }

                var returnData = Tuple.Create<byte[], string>(file, contentType);
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<string> Get(int Id)
        {
            string name = "";
            switch (Id)
            {
                case 1:
                    name = "Voucher";
                    break;
                case 2:
                    name = "ChargeBatch";
                    break;
                case 3:
                    name = "PaymentBatch";
                    break;
                case 4:
                    name = "ActionCategory";
                    break;
                case 5:
                    name = "ActionNote";
                    break;
                case 6:
                    name = "PatientStatements";
                    break;
                case 7:
                    name = "BatchStatement";
                    break;
            }

            return name;
        }
    }
}
