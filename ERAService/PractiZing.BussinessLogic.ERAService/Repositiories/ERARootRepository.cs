using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using PractiZing.DataAccess.ERAService.Tables;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Common;
using PractiZing.DataAccess.ERAService;
using Microsoft.Extensions.Configuration;
using PractiZing.Base.Enums.ERAService;
using System.IO;
using PractiZing.Base.Object.ERAService;
using PractiZing.DataAccess.ERAService.Object;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.BussinessLogic.ERAService.Repositiories
{
    public class ERARootRepository : BaseRepository<ERARoot>, IERARootRepository

    {
        private IConfiguration _configuration;
        private IAppSettingRepository _appSettingRepository;
        public ERARootRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 IConfiguration configuration,
                                 IAppSettingRepository appSettingRepository) : base(errorCodes, dbContext, loggedUser)
        {
            this._configuration = configuration;
            this._appSettingRepository = appSettingRepository;
        }



        public async Task<IEnumerable<IERARoot>> Get(string checkNo)
        {
            checkNo = checkNo == null ? "" : checkNo;

            var query = this.Connection.From<ERARoot>()
                        .Select<ERARoot>((e) => new
                        {
                            e
                        })
                        .Where(i => i.CheckNumber.Contains(checkNo) && i.PracticeId == LoggedUser.PracticeId)
                        .OrderByDescending(i => i.CreateDate);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ERARoot>.MapList(queryResult);

            return result;
        }

        public async Task<IERARoot> GetbyId(long id)
        {
            return await this.Connection.SingleAsync<ERARoot>(i => i.Id == id);
        }

        public async Task<IEnumerable<IValidationResult>> ThrowError(IERARoot eRARoot)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            if (eRARoot == null)
            {
                errors.Add(new ValidationCodeResult(ErrorCodes[Convert.ToInt32(EnumErrorCode.ERARootObjectNull)]));
            }

            return errors;
        }

        public async Task<IEnumerable<IValidationResult>> ThrowError(IEnumerable<IValidationResult> errors)
        {
            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }

            return errors;
        }

        public string LoggedUserPracticeCode()
        {
            return LoggedUser.PracticeCode;
        }

        //public async Task<Tuple<byte[], string>> DownloadFile(string checkNumber)
        //{
        //    try
        //    {
        //        var eraRoot = await this.Connection.SingleAsync<ERARoot>(i => i.CheckNumber == checkNumber && i.ErrorLog == null);
        //        string eraFilesPath = _configuration["ERAFileDirectory"];
        //        string eraFolderName = _configuration["ERAFolderDirectory"];

        //        string folderName = "";
        //        byte[] file = null;
        //        string contentType = "";

        //        switch (LoggedUser.PracticeCode)
        //        {
        //            case "lucid":
        //                folderName = ERAFolderName.lucid;
        //                break;
        //            case "access":
        //                folderName = ERAFolderName.access;
        //                break;
        //            case "apollo":
        //                folderName = ERAFolderName.apollo;
        //                break;
        //            case "bt":
        //                folderName = ERAFolderName.bt;
        //                break;
        //            case "unilab":
        //                folderName = ERAFolderName.unilab;
        //                break;
        //            default: break;
        //        }

        //        string filePath = eraFilesPath + "\\" + folderName + "\\" + eraFolderName + "\\" + eraRoot.FileName;
        //        if (File.Exists(filePath))
        //        {
        //            file = File.ReadAllBytes(filePath);

        //            string extensions = Path.GetExtension(filePath);
        //            extensions = extensions.Replace(".", "");

        //            contentType = MimeTypes.txtContentType;
        //        }

        //        var returnData = Tuple.Create<byte[], string>(file, contentType);
        //        return returnData;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task<IFileRead> DownloadFile(string checkNumber)
        {
            try
            {
                FileRead fileRead = new FileRead();
                var eraRoot = await this.Connection.SingleAsync<ERARoot>(i => i.CheckNumber == checkNumber && i.ErrorLog == null);
                if(eraRoot == null)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[(int)EnumErrorCode.VoucherExistsCheckNo,checkNumber]));

                string eraFilesPath = _configuration["ERAFileDirectory"];
                string eraFolderName = _configuration["ERAFolderDirectory"];

                string folderName = "";
                string file = null;

                var appSettings = await this._appSettingRepository.GetAppERAConfig();
                folderName = appSettings.Count() == 0 ? string.Empty : appSettings.Where(i => i.SettingCD == SettingCDConstant.FolderName).Select(i => i.SettingValue).FirstOrDefault();
            
                string filePath = eraFilesPath + "\\" + folderName + "\\" + eraFolderName + "\\" + eraRoot.FileName;
                if (File.Exists(filePath))
                {
                    file = File.ReadAllText(filePath);
                    fileRead.FileText = file;
                    fileRead.FileText = fileRead.FileText.Replace("~", "~" + Environment.NewLine);
                }
                
                return fileRead;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IERARoot>> GetbyERARootId(IEnumerable<long> ids)
        {
            return await this.Connection.SelectAsync<ERARoot>(i => ids.Contains(i.Id));
        }
    }
}
