using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigERARemarkCodesController : SecuredRepositoryController<IConfigERARemarkCodesRepository>
    {

        public ConfigERARemarkCodesController(IConfigERARemarkCodesRepository configERARemarkCodesRepository) : base(configERARemarkCodesRepository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(string remarkCode = "")
        {
            try
            {
                var result = await this.Repository.GetAll(remarkCode);
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
