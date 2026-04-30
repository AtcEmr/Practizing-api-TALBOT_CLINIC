using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigReferralSourceController : SecuredRepositoryController<IConfigReferralSourceRepository>
    {
        public ConfigReferralSourceController(IConfigReferralSourceRepository configReferralSourceRepository) : base(configReferralSourceRepository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }
    }
}