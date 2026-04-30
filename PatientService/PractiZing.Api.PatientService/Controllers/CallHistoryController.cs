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
    public class CallHistoryController: SecuredRepositoryController<ICallHistoryRepository>
    {
        private ILogger _logger;
        public CallHistoryController(ICallHistoryRepository callHistoryRepository,
                                     ILogger<CallHistoryController> logger) : base(callHistoryRepository)
        {
            _logger = logger;
            _logger.LogInformation("CallHistory Controller");
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]CallHistory entity)
        {
            try
            {
                _logger.LogInformation("$ CallHistory AddNew");

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
