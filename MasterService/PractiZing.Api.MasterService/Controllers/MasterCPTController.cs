using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Common;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Objects;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class MasterCPTController : SecuredRepositoryController<IMasterCPTRepository>
    {
        public MasterCPTController(IMasterCPTRepository masterCPTRepository) : base(masterCPTRepository)
        {
        }

        [HttpGet("searchCPT")]
        public async Task<IActionResult> SearchCPT([FromQuery]SearchQuery<MasterCPTFilter> entity)
        {
            try
            {
                var queryInterface = SearchQuery.Map<MasterCPTFilter, IMasterCPTFilter>(entity);
                var result = await this.Repository.SearchCPT(queryInterface);
                return Ok(result);
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