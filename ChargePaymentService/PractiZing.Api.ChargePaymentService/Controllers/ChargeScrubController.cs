using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ChargeScrubController : SecuredRepositoryController<IChargeScrubRepository>
    {        
        public ChargeScrubController(IChargeScrubRepository chargeScrubRepository) : base(chargeScrubRepository)
        {
            
        }

        [HttpGet("getChargeScrub/{chargeId}")]
        public async Task<IActionResult> GetChargeScrub(int chargeId)
        {
            try
            {
                var result = await this.Repository.GetByChargeId(chargeId);
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
