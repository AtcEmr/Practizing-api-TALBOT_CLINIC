using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class DepositTypeController : SecuredRepositoryController<IDepositTypeRepository>
    {
        public DepositTypeController(IDepositTypeRepository repository) : base(repository)
        {
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this.Repository.GetAll();
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
