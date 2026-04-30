using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class DailyQueueController : SecuredRepositoryController<IDailyQueueRepository>
    {
        private ILogger _logger;
        public DailyQueueController(IDailyQueueRepository dailyQueueRepository,
                                     ILogger<DailyQueueController> logger) : base(dailyQueueRepository)
        {
            _logger = logger;
            _logger.LogInformation("DailyQueue Controller");
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]DailyQueue entity)
        {
            try
            {
                _logger.LogInformation("$ DailyQueue AddNew");

                var result = await this.Repository.AddNew(entity);
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
