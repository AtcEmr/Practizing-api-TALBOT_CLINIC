using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigSupervisionTypeController : SecuredRepositoryController<IConfigSupervisionTypeRepository>
    {
        public ConfigSupervisionTypeController(IConfigSupervisionTypeRepository repository) : base(repository)
        {
        }

        /// <summary>
        ///  get all provider speciality 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.Get();
            return Ok(result);
        }
    }
}