using Microsoft.Extensions.Configuration;
using PractiZing.Base.Service.MasterService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class FullFrameworkRequestService : IFullFrameworkRequestService
    {
        private string fullFrameWorkURL;
        public FullFrameworkRequestService(IConfiguration configuration)
        {
            fullFrameWorkURL = configuration["FullFrameWorkURL"];
        }

        public async Task<string> FullFrameWorkRequest(string requestUrl, string serializeData)
        {
            try
            {
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(10, 1, 1);

                HttpResponseMessage response = await client.PostAsync(fullFrameWorkURL + requestUrl, content);
                string responseString = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return responseString;
                }
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
                return responseString;
            }
            catch
            {
                throw;
            }
        }
    }
}
