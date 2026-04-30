using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ERAService
{
    public interface IERARequestService
    {
        Task<string> ERARequest(string requestUrl, string serializeData);
      
    }
}
