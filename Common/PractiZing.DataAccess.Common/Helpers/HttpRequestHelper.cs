using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.DataAccess.Common.Helpers
{
    public class HttpRequestHelper
    {
        public static async Task<string> GetRequestAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJraWQiOiJDVll1TDNCV0ozUGNSQkJSTVFqT2xMNFpxdHF1XC8rMms0cVhtOG1uZXBTaz0iLCJhbGciOiJSUzI1NiJ9.eyJzdWIiOiJhYTBiMmRjNC0zMjRlLTQ1YjctODM0ZS1kMGZlMTUwYmFjZDYiLCJhdWQiOiI3Z3RycjQ5a25vdGN1dGltcXVvdGZxOG9rbSIsImNvZ25pdG86Z3JvdXBzIjpbIlNBIl0sImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJldmVudF9pZCI6ImQxZTA5NGI3LTExNzUtNDdhMC04NjkxLTMxZmMwZWJmMjQ1MCIsInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNjE1MzY4NDY1LCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAudXMtZWFzdC0yLmFtYXpvbmF3cy5jb21cL3VzLWVhc3QtMl9mN2xZYVYwYlUiLCJjb2duaXRvOnVzZXJuYW1lIjoiYWRtaW5fbXlhY2Nlc3NvaC5jb20iLCJleHAiOjE2MTU1NjYzMTIsImlhdCI6MTYxNTU2MjcxMiwiZW1haWwiOiJhZG1pbkBteWFjY2Vzc29oLmNvbSJ9.V6CECye9v6UNv-jM5kSaYnMavDlqOKxyCWe_B6lFzR34u9sAwEuicLC-VxmzF00gupYNdkp28NyFJqSZlmCA8bXLTjffn4q2zRJtQlVgN87VrwqgyhC4MRj9_wTpVH8V_jvZ1NOcnwYkt7taHrNDUycZp3iPDP-zpysHVzB2uvpoCOe8lPfClDQMheuAUVe4tE2mfPqrCvkxY6G5jO7EnyLNLADmO8kNY9sSwWT0ZqNvJGtDibWWHYlaeA9Lr69o67XUMLCtyd6Fg4hNhl4bpeVHwKFV_Pc-n649uVXWbWEoENpgvkg-gcMtaejMJPBBYNp7BLosklgnOcTtaImfLQ");

                HttpResponseMessage httpResponse = new HttpResponseMessage();

                httpResponse = await client.GetAsync(uri);

                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}
