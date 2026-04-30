using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]

    public class ChasePaymentChildController : SecuredRepositoryController<IChasePaymentChildRepository>
    {


        private readonly ILogger _logger;
        public ChasePaymentChildController(IChasePaymentChildRepository chasePaymentChildRepository,ILogger<ChasePaymentChildController> logger) : base(chasePaymentChildRepository)
        {
            _logger = logger;

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id )
        {
            try
            {   
                var result = await this.Repository.Delete(id );
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
