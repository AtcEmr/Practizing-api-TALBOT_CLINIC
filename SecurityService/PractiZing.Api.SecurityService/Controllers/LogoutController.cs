using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.SecurityService;

namespace PractiZing.Api.SecurityService.Controllers
{
    [Route("api/[controller]")]
    public class LogoutController : BaseRepositoryController<IUserAuthenticationRepository>
    {
        public LogoutController(IUserAuthenticationRepository repository)
            : base(repository)
        {

        }
        /// <summary>
        /// delete logged user data by using qnique small token
        /// first we will delete data from database and then we will delete from 
        /// local cache because, we get original token from memory cache on basis of this 
        /// unique small token
        /// </summary>
        /// <returns>This method will return deleted record count from database by unique
        /// small token. The small token we will get from request</returns>
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            try
            {
                string token;
                int result = 0;
                if (!string.IsNullOrEmpty((Request.Headers["Authorization"])))
                {
                    var authorization = (Request.Headers["Authorization"])[0];
                    var authorizations = authorization.Split(' ').ToList();
                    token = authorizations.LastOrDefault();
                    result = await this.Repository.Delete(token);                   
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}