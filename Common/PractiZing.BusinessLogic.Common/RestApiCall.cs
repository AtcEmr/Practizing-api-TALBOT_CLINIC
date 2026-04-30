using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.Common
{
    public class RestApiCall
    {
        
        public RestApiCall()
        {
            
        }
        public async Task<HttpResponseMessage> GetAsync(string restApi, string url, string token)
        {
            try
            {

                HttpResponseMessage response;
                //url = url.Contains("5001") == true ? url : url + ":5001/";

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    // Add an Accept header for JSON format.    
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // List all Names.    
                    if(!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    response = await client.GetAsync(restApi);  // Blocking call!    
                    

                }
                return response;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string jsonData, string restApi, string url, string token)
        {
            try
            {
                HttpResponseMessage response;
                //url = url.Contains("5001") == true ? url : url + ":5001/";

                using (var client = new HttpClient { BaseAddress = new Uri(url) })
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    response = await client.PostAsync(restApi, content);
                    

                }
                return response;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        

        public async Task<HttpResponseMessage> PostWithHeaderAsync(string userName, string password,string jsonData, string restApi, string url, string token)
        {
            try
            {
                HttpResponseMessage response;
                //url = url.Contains("5001") == true ? url : url + ":5001/";

                using (var client = new HttpClient { BaseAddress = new Uri(url) })
                {

                    using (var request = new HttpRequestMessage(new HttpMethod("POST"),url))
                    {
                        request.Headers.TryAddWithoutValidation("password", password);
                        request.Headers.TryAddWithoutValidation("username", userName);
                        request.Headers.TryAddWithoutValidation("url", url);
                        response = await client.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {

                            string result = await response.Content.ReadAsStringAsync();
                            //return result;
                        }
                        else
                        {
                            //return "";
                        }
                    }


                    ////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    //client.DefaultRequestHeaders.Add("Username", userName);
                    //client.DefaultRequestHeaders.Add("Password", password);


                    ////var response = await httpClient.SendAsync(request);


                    ////client.DefaultRequestHeaders.Add("url", url);
                    //var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    //response = await client.PostAsync(restApi, null);


                }
                return response;

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<HttpResponseMessage> PutAsync(string jsonData, string restApi, string url, string token)
        {
            try
            {
                HttpResponseMessage response;
                //url = url.Contains("5001") == true ? url : url + ":5001/";

                using (var client = new HttpClient { BaseAddress = new Uri(url) })
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    response = await client.PutAsync(restApi, content);
                }

                return response;
            }
            catch (Exception ex)
            {                
                throw;
            }
        }
    }
}
