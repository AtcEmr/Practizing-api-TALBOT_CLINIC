using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigFacilityTypeController : SecuredRepositoryController<IConfigFacilityTypeRepository>
    {
        public ConfigFacilityTypeController(IConfigFacilityTypeRepository configFacilityTypeRepository) : base(configFacilityTypeRepository)
        {
        }

        /// <summary>
        ///  get all facility type
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