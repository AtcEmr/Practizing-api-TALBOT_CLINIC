using PractiZing.Base.Common;
using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Object.ERAService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ERAService
{
    public interface IERARootRepository
    {
        Task<IEnumerable<IERARoot>> Get(string checkNo);
        Task<IERARoot> GetbyId(long id);
        Task<IEnumerable<IValidationResult>> ThrowError(IERARoot eRARoot);
        Task<IEnumerable<IValidationResult>> ThrowError(IEnumerable<IValidationResult> errors);
        string LoggedUserPracticeCode();
       // Task<Tuple<byte[], string>> DownloadFile(string checkNumber);
        Task<IFileRead> DownloadFile(string checkNumber);
        Task<IEnumerable<IERARoot>> GetbyERARootId(IEnumerable<long> ids);
    }
}
