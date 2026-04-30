using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]

    public class ConfigPOSController : SecuredRepositoryController<IConfigPOSRepository>
    {
        public ConfigPOSController(IConfigPOSRepository repository) : base(repository)
        {
        }

        /// <summary>
        ///  get all places of service
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// get place of service by code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("get/{code}")]
        public async Task<IActionResult> Get(string code)
        {
            var result = await this.Repository.Get(code);
            return Ok(result);
        }
    }
}