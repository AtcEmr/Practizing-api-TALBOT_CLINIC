using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]

    public class ConfigNDCUOMController : SecuredRepositoryController<IConfigNDCUOMRepository>
    {
        public ConfigNDCUOMController(IConfigNDCUOMRepository repository) : base(repository)
        {
        }

        /// <summary>
        ///  get all types of service
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetConfigNDCUOMCodes();
            return Ok(result);
        }
    }
}