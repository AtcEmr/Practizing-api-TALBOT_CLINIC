using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface IAttService
    {
        Task<Tuple<byte[], string>> DownloadFile(string uid, bool isReport = false);
        Task<Tuple<byte[], string>> DownloadBatchStatmentFile(string uid, bool isReport = false);
    }
}
