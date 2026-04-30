using Microsoft.Extensions.Configuration;
using PractiZing.Base.Service.ERAService;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BussinessLogic.ERAService.Service
{
    public class ERARequestService : IERARequestService
    {
        private string eRAServiceURL;
        public ERARequestService(IConfiguration configuration)
        {
            eRAServiceURL = configuration["ERAServiceURL"];
        }

        public async Task<string> ERARequest(string requestUrl, string serializeData)
        {
            try
            {
                serializeData = serializeData == null ? "" : serializeData;
                var content = new StringContent(serializeData, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                client.Timeout = new TimeSpan(10, 1, 1);

                HttpResponseMessage response = await client.PutAsync(eRAServiceURL + requestUrl, content);
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
