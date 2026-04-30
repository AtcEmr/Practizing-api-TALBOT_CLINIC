using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using PractiZing.Api.Common.Authorize;
using System.Linq;
using System.Threading.Tasks;
using PractiZing.Base.Common;
using System;
using Newtonsoft.Json;

namespace PractiZing.Api.Common.Authorize
{
    public class FingerPrinterMiddleWare
    {
        private static readonly MD5 _hasher = MD5.Create();
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _serializerSettings;
        public FingerPrinterMiddleWare()
        {

        }
        public FingerPrinterMiddleWare(RequestDelegate next)
        {
            _next = next;
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
        /// <summary>
        /// this method will be called when each requet will be received
        /// </summary>
        /// <param name="context">http request all data</param>
        /// <returns>it will verify the request fingerprint of current and logged user finger 
        /// print</returns>
        public Task Invoke(HttpContext context)
        {
            if (!string.IsNullOrEmpty((context.Request.Headers["Authorization"])))
            {
                var authorization = (context.Request.Headers["Authorization"])[0];
                var authorizations = authorization.Split(' ').ToList();
                var token = authorizations.LastOrDefault();
                //if (!string.IsNullOrEmpty(token))
                //{
                //    string fingerPrint = this.GenerateRequestFingerPrint(context.Request).Result;
                //    var response = MemoryCache.Get(token);
                //    fingerPrint = fingerPrint == response?.FingerPrint ? fingerPrint : "";
                //    if (string.IsNullOrEmpty(fingerPrint))
                //    {
                //        context.Response.StatusCode = 401;
                //        context.Response.ContentType = "application/json";
                //        return context.Response.WriteAsync(JsonConvert.SerializeObject("Unauthorized Access", _serializerSettings));
                //    }
                //}
            }


            return _next(context);

        }

        /// <summary>
        /// this method will generate request finger print
        /// </summary>
        /// <param name="context">http request all data</param>
        /// <returns>this method will return created request finger print</returns>
        public async Task<string> GenerateRequestFingerPrint(HttpRequest request)
        {
            //var remoteIpAddress = (((HttpProtocol)((DefaultHttpContext)((DefaultHttpRequest)request).HttpContext).Features).RemoteIpAddress).ToString();
            //var remotePort = (((HttpProtocol)((DefaultHttpContext)((DefaultHttpRequest)request).HttpContext).Features).RemotePort).ToString();
            string protocol = !string.IsNullOrEmpty(request.Protocol) ? request.Protocol : string.Empty;
            string encoding = ((HttpRequestHeaders)((DefaultHttpRequest)request).Headers).HeaderAcceptEncoding;
            string language = ((HttpRequestHeaders)((DefaultHttpRequest)request).Headers).HeaderAcceptLanguage;
            string userAgent = ((HttpRequestHeaders)((DefaultHttpRequest)request).Headers).HeaderUserAgent;
            string headerReferer = ((HttpRequestHeaders)((DefaultHttpRequest)request).Headers).HeaderOrigin;

            string stringToTokenise = protocol + encoding + language + userAgent + headerReferer;
            var fingerPrint = await this.GetMd5Hash(_hasher, stringToTokenise);
            return fingerPrint;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="md5Hash">this is variable of type system.security.Cryptography</param>
        /// <param name="input">this is plane text</param>
        /// <returns>this method will create incrypted string using md5Hash and string input
        /// will retuen incrypted string</returns>
        private async Task<string> GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
