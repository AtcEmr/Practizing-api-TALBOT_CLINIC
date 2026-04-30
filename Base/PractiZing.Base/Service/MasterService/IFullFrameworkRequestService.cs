using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface IFullFrameworkRequestService
    {
        Task<string> FullFrameWorkRequest(string requestUrl, string serializeData);
    }
}
