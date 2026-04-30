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
    public class MasterICD10Controller : SecuredRepositoryController<IMasterICD10Repository>
    {
        public MasterICD10Controller(IMasterICD10Repository masterICD10Repository) : base(masterICD10Repository)
        {
        }

        [HttpGet("searchICD")]
        public async Task<IActionResult> SearchICD([FromQuery]SearchQuery<MasterICD10Filter> entity)
        {
            try
            {
                var queryInterface = SearchQuery.Map<MasterICD10Filter, IMasterICD10Filter>(entity);
                var result = await this.Repository.SearchICD(queryInterface);
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