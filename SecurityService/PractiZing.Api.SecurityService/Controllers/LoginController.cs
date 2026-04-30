using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Authorize;
using Newtonsoft.Json;
using PractiZing.Base.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService.Objects;

namespace PractiZing.Api.SecurityService.Controllers
{
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        string headerOrigin = "";
        private ILogger _logger;
        private HttpContext _context;
        private IConfiguration _configuration;
        public LoginController(IConfiguration configuration,
                               IHttpContextAccessor httpContextAccessor,
                               ILogger<LoginController> logger)
        {
            this._logger = logger;
            this._configuration = configuration;
            _context = httpContextAccessor.HttpContext;
            var headers = httpContextAccessor.HttpContext.Request.Headers;
            if (headers.ContainsKey("Host"))
                headerOrigin = headers["Host"];
            else if (headers.ContainsKey("Referer"))
                headerOrigin = headers["Referer"];
            else
                headerOrigin = headers["Origin"];

            _logger.LogInformation($"HeaderOrigin1- {headerOrigin}");

        }

        /// <summary>
        /// Login from Web
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody]LoginDTO login)
        {
            //FingerPrinterMiddleWare fingerPrinter = new FingerPrinterMiddleWare();
            //string fingerPrint = await fingerPrinter.GenerateRequestFingerPrint(_context.Request);
            _logger.LogInformation($"LoginDTO- {login}");
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
            _logger.LogInformation($"LoginDTO- {login.UserName}");
            values.Add(new KeyValuePair<string, string>("UserName", login.UserName));
            _logger.LogInformation($"LoginDTO- {login.Password}");
            values.Add(new KeyValuePair<string, string>("UserPwd", login.Password));
            //values.Add(new KeyValuePair<string, string>("FingerPrint", fingerPrint));

            return await this.Login(values);
        }

        private async Task<ActionResult> Login(List<KeyValuePair<string, string>> values)
        {
            if (!headerOrigin.Contains(_configuration["http"]))
            {
                headerOrigin = _configuration["http"] + "://" + headerOrigin;
            }

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            _logger.LogInformation($"Header Origin - {headerOrigin}");
            _logger.LogInformation($"client.DefaultRequestHeaders - {JsonConvert.SerializeObject(client.DefaultRequestHeaders)}");
            //client.DefaultRequestHeaders.Add("Referrer", headerOrigin);
            client.DefaultRequestHeaders.Referrer = new Uri(headerOrigin);
            _logger.LogInformation($"client.DefaultRequestHeaders - {JsonConvert.SerializeObject(client.DefaultRequestHeaders)}");
            client.BaseAddress = new Uri(headerOrigin);

            _logger.LogInformation($"Client BaseAddress - {client.BaseAddress}");

            Uri uriResult;
            bool isURLCorrect = Uri.TryCreate(headerOrigin, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;
            _logger.LogInformation($"url correct - {isURLCorrect}");

            _logger.LogInformation($"Client BaseAddress - {client.BaseAddress}");
            client.BaseAddress = new Uri(headerOrigin);
            System.Net.Http.FormUrlEncodedContent content = new System.Net.Http.FormUrlEncodedContent(values);
            var response = await client.PostAsync("/token", content);

            string result = response.Content.ReadAsStringAsync().Result;

            object dataObject = result;
            try
            {
                if ((int)response.StatusCode == 400)
                {
                    ICollection<IValidationResult> errors = new List<IValidationResult>();
                    errors.Add(new ValidationCodeResult(result));
                    throw new EntityValidationException("Request rejected due to following errors -", errors);
                }
                else
                {
                    dataObject = Newtonsoft.Json.Linq.JObject.Parse(result);
                }
                return StatusCode((int)response.StatusCode, dataObject);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("LoginAzure")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginWithUser([FromBody]LoginDTO login)
        {
            
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
            _logger.LogInformation($"LoginDTO- {login.UserName}");
            values.Add(new KeyValuePair<string, string>("UserName", login.UserName));
            //values.Add(new KeyValuePair<string, string>("FingerPrint", fingerPrint));

            return await this.Login(values);
        }

        private async Task<ActionResult> LoginAzure(List<KeyValuePair<string, string>> values)
        {
            if (!headerOrigin.Contains(_configuration["http"]))
            {
                headerOrigin = _configuration["http"] + "://" + headerOrigin;
            }

            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Referrer = new Uri(headerOrigin);            
            client.BaseAddress = new Uri(headerOrigin);
            
            Uri uriResult;
            bool isURLCorrect = Uri.TryCreate(headerOrigin, UriKind.Absolute, out uriResult)
                && uriResult.Scheme == Uri.UriSchemeHttp;
            
            client.BaseAddress = new Uri(headerOrigin);
            System.Net.Http.FormUrlEncodedContent content = new System.Net.Http.FormUrlEncodedContent(values);
            var response = await client.PostAsync("/tokenAzure", content);

            string result = response.Content.ReadAsStringAsync().Result;

            object dataObject = result;
            try
            {
                if ((int)response.StatusCode == 400)
                {
                    ICollection<IValidationResult> errors = new List<IValidationResult>();
                    errors.Add(new ValidationCodeResult(result));
                    throw new EntityValidationException("Request rejected due to following errors -", errors);
                }
                else
                {
                    dataObject = Newtonsoft.Json.Linq.JObject.Parse(result);
                }
                return StatusCode((int)response.StatusCode, dataObject);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
