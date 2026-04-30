using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]

    public class ConfigBillTypeController : SecuredRepositoryController<IConfigBillTypeRepository>
    {
        public ConfigBillTypeController(IConfigBillTypeRepository configBillTypeRepository) : base(configBillTypeRepository)
        {
        }

        /// <summary>
        ///  get all Config Bill Type
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repository.Get();
            return Ok(result);
        }
    }
}
