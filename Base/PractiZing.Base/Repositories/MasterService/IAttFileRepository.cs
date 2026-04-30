using Microsoft.AspNetCore.Http;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IAttFileRepository : IBaseRepository
    {
        Task<IAttFile> GetByTableId(int Id);
        Task<IAttFile> GetByUId(Guid uid);
        Task<string> SaveFile(IFormFile file, string fileName, string folderInnerName);
       // Task<IAttFile> CreateAttachment(string fileName, int tableValueId, string attTable, bool isPatientStatement = true);
        Task<int> UpdateFileName(IAttFile entity);
       // Task<IAttFile> CreateAttachment(string fileName, int tableValueId, string attTable, bool isPatientStatement = true);
        //Task<IAttFile> CreateAttachment(string fileName, int tableValueId, string attTable, bool isPatientStatement = true);
        Task<IAttFile> CreateAttachments(IFormFile formFile, int tableValueId, string attTable, string fileName, string practiceCode = "", bool isPatientStatement = false);
        Task<IEnumerable<IAttFile>> GetByTableId(int tableValueId, string tableName);
        Task Delete(IEnumerable<string> uids);
        Task<Tuple<byte[], string>> DownloadFile(string uid, bool isReport = false);
        Task<IEnumerable<IAttFile>> GetByTableId(IEnumerable<int> tableValueIds, string tableName);
        //string FilePath(string folderInnerName, string fileNameExt, string fileName, bool isReport = false);
        string FilePath(string folderInnerName, string fileNameExt, string fileName, bool isReport = false);
        string ContentType(string ext);
        Task<int> GetFilesByTypes(int Id, string type, string fileNameExt);
        Task<IAttFile> GetByTableIdBatchStatment(int Id);
    }
}
