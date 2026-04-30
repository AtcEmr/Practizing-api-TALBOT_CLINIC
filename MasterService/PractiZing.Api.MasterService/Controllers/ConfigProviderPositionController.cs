using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigProviderPositionController : SecuredRepositoryController<IConfigProviderPositionRepository>
    {
        public ConfigProviderPositionController(IConfigProviderPositionRepository repository) : base(repository)
        {
        }

        /// <summary>
        ///  get all provider position
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }
    }
}