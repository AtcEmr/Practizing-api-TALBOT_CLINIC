using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.MasterService.MimeFileType;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class AttFileRepository : ModuleBaseRepository<AttFile>, IAttFileRepository
    {
        private string _baseUrl;
        private IConfiguration _configuration;
        private string _relativePath;
        private string _statementPath;
        private string _baseDirectory;
        private string _baseStatementDirectory;
        private IAttFileTableRepository _attFileTableRepository;
        public ILogger _logger;

        public AttFileRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 IConfiguration configuration,
                                 IAttFileTableRepository attFileTableRepository,
                                 ILogger<AttFileRepository> logger)
                                 : base(errorCodes, dbContext, loggedUser)
        {
            _baseUrl = configuration["ApplicationUrl"];
            _baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "../";
            _baseStatementDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this._configuration = configuration;
            _logger = logger;
            _relativePath = configuration["AttachmentFolder"];
            _statementPath = configuration["BaseWindowDirectory"];
            this._attFileTableRepository = attFileTableRepository;
        }

        public async Task<IAttFile> GetByTableId(int Id)
        {
            return await this.Connection.SingleAsync<AttFile>(i => i.TableIdValue == Id && i.AttFileTableId == (int)AttEnum.PatientStatements);
        }

        public async Task<IAttFile> GetByUId(Guid uid)
        {
            return await this.Connection.SingleAsync<AttFile>(i => i.UId == uid);
        }

        //public async Task<IAttFile> CreateAttachment(string fileName, int tableValueId, string attTable, bool isPatientStatement = true)
        //{
        //    var attData = await this._attFileTableRepository.GetAll();

        //    AttFile entity = new AttFile();
        //    entity.FileNameExt = Path.GetExtension(fileName);
        //    entity.FileName = isPatientStatement ? fileName.Split('.')[0] : fileName;
        //    entity.FullPath = isPatientStatement ? $"{LoggedUser.PracticeId}/{attTable}" : $"{attTable}";
        //    entity.TableIdValue = tableValueId;
        //    entity.AttFileTableId = attData.Where(i => i.TableName.ToLower() == attTable.ToLower()).FirstOrDefault().Id;

        //    var attachment = await this.AddNewAttachment(entity);
        //    return attachment;
        //}

        public async Task<IAttFile> CreateAttachments(IFormFile formFile, int tableValueId, string attTable, string fileName, string practiceCode = "", bool isPatientStatement = false)
        {
            var attData = await this._attFileTableRepository.GetAll();

            var ext = isPatientStatement ? Path.GetExtension(fileName) : Path.GetExtension(formFile.FileName);
            if (ext.ToLower() == ".zip" || ext.ToLower() == ".rar")
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InvalidFileFormat]));
            }

            AttFile entity = new AttFile();
            //entity.FileName = fileName.Split('.')[0];
            //entity.FullPath = isPatientStatement ? $"{LoggedUser.PracticeId}/{attTable}" : $"{attTable}";
            entity.FileNameExt = isPatientStatement ? Path.GetExtension(fileName) : Path.GetExtension(formFile.FileName);
            entity.FileName = isPatientStatement ? fileName.Split('.')[0] : formFile.FileName.Split('.')[0];
            entity.FullPath = isPatientStatement ? $"{attTable}\\{practiceCode}" : $"{LoggedUser.PracticeId}/{attTable}";
            entity.TableIdValue = tableValueId;
            entity.AttFileTableId = attData.Where(i => i.TableName.ToLower() == attTable.ToLower()).FirstOrDefault().Id;

            var attachment = await this.AddNewAttachment(entity);
            // await this.UpdateFileName(attachment);
            return attachment;
        }

        private async Task<IAttFile> AddNewAttachment(IAttFile entity)
        {
            try
            {
                AttFile tEntity = entity as AttFile;

                var errors = await this.ValidateEntityToAdd(tEntity);
                //check if error exist
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var attachment = await base.AddNewAsync(tEntity);
                return attachment;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetFilesByTypes(int Id, string type, string fileNameExt)
        {
            var getTableName = await this._attFileTableRepository.GetByName(type);
            var result = await this.Connection.SelectAsync<AttFile>(i => i.AttFileTableId == getTableName.Id && i.TableIdValue == Id && i.FileNameExt == fileNameExt);
            return result.Count();
        }

        public async Task<string> SaveFile(IFormFile file, string fileName, string folderInnerName)
        {
            string baseFullPath = "";

            if (file.Length > 0)
            {
                string basePath = $"{_baseDirectory}/{_relativePath}/{LoggedUser.PracticeId}";

                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);

                baseFullPath = this.InnerFoler(folderInnerName);
                string extName = Path.GetExtension(file.FileName);

                fileName = fileName + extName;
                //fileName = file.FileName;
                if (extName.ToLower() == ".zip")
                {
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InvalidFileFormat]));
                }
                
                string fullPath = Path.Combine(baseFullPath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            // string[] fileData = { baseFullPath , fileName};
            return file.FileName;
        }

        private string InnerFoler(string folderInnerName)
        {
            string basePath = $"{_baseDirectory}{_relativePath}/{LoggedUser.PracticeId}/{folderInnerName}";

            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            return basePath;
        }

        public async Task<IEnumerable<IAttFile>> GetByTableId(int tableValueId, string tableName)
        {
            List<AttFile> result = new List<AttFile>();
            var tableId = await this._attFileTableRepository.GetByName(tableName);

            if (tableId != null)
            {
                result = await this.Connection.SelectAsync<AttFile>(i => i.TableIdValue == tableValueId && i.AttFileTableId == tableId.Id);
                foreach (var item in result)
                {
                    item.FullPathAttachment = $"{_baseUrl}/{_relativePath}/{item.FullPath}/{item.FileName}";
                    item.FullPathAttachment = item.FullPathAttachment.Replace(" ", string.Empty);
                }
            }

            return result;
        }

        public async Task<IEnumerable<IAttFile>> GetByTableId(IEnumerable<int> tableValueIds, string tableName)
        {
            List<AttFile> result = new List<AttFile>();
            var tableId = await this._attFileTableRepository.GetByName(tableName);

            if (tableId != null)
            {
                result = await this.Connection.SelectAsync<AttFile>(i => tableValueIds.Contains(i.TableIdValue) && i.AttFileTableId == tableId.Id);
                foreach (var item in result)
                {

                    item.FullPathAttachment = $"{_baseUrl}/{_relativePath}/{item.FullPath}/{item.FileName}{item.FileNameExt}";
                    item.FullPathAttachment = item.FullPathAttachment.Replace(" ", string.Empty);
                }
            }

            return result;
        }

        private void DeleteFile(IAttFile attachment)
        {
            string baseDirectory = $"{_baseDirectory}{_relativePath}";
            attachment.FullPath = attachment.FullPath.Replace(" ", string.Empty);
            string deleteAttachment = Path.Combine(baseDirectory, attachment.FullPath, attachment.FileName);
            if (File.Exists(deleteAttachment))
                File.Delete(deleteAttachment);
        }

        public async Task Delete(IEnumerable<string> uids)
        {
            try
            {
                foreach (var uid in uids)
                {
                    var attachment = await this.GetByUId(Guid.Parse(uid));
                    if (attachment != null)
                    {
                        var value = await this.Connection.DeleteAsync<AttFile>(i => i.UId == attachment.UId);
                        this.DeleteFile(attachment);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Tuple<byte[], string>> DownloadFile(string uid, bool isReport = false)
        {
            try
            {
                byte[] file = null;
                string contentType = "";

                var fileData = await this.Connection.SingleAsync<AttFile>(i => i.UId == Guid.Parse(uid));
                if (fileData != null)
                {
                    var getPath = isReport ? this.FilePath(_statementPath, fileData.FileNameExt, fileData.FileName, true) : this.FilePath(fileData.FullPath,fileData.FileNameExt, fileData.FileName);
                    _logger.LogInformation("getPath - " + getPath);

                    if (File.Exists(getPath))
                    {
                        file = File.ReadAllBytes(getPath);

                        string extensions = Path.GetExtension(getPath);
                        extensions = extensions.Replace(".", "");

                        contentType = this.ContentType(extensions);
                    }
                    else
                    {
                        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FileNotExists]));
                    }
                }

                var returnData = Tuple.Create<byte[], string>(file, contentType);
                return returnData;
            }
            catch (Exception ex)
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FileNotExists]));
                throw ex;
            }
        }

        public string FilePath(string folderInnerName, string fileNameExt, string fileName, bool isReport = false)
        {
            string basePath = isReport ? Path.Combine(folderInnerName, LoggedUser.PracticeCode, fileName) : $"{_baseDirectory}{_relativePath}/{folderInnerName}/{fileName}";
            return basePath;
        }

        public string ContentType(string ext)
        {
            string contentType = "";
            switch (ext)
            {
                case "pdf":
                    contentType = MimeTypes.PdfContentType;
                    break;

                case "docx":
                case "doc":
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
                case "csv":
                    contentType = MimeTypes.CsvContentType;
                    break;
                case "xml":
                    contentType = MimeTypes.xmlContentType;
                    break;
            }

            return contentType;
        }

        public async Task<int> UpdateFileName(IAttFile entity)
        {
            try
            {
                AttFile tEntity = entity as AttFile;
                tEntity.FileName = tEntity.UId.ToString();

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<AttFile>()
                                           .Update(x => new
                                           {
                                               x.FileName
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IAttFile> GetByTableIdBatchStatment(int Id)
        {
            return await this.Connection.SingleAsync<AttFile>(i => i.TableIdValue == Id && i.AttFileTableId == (int)AttEnum.BatchStatement);
        }
    }
}
