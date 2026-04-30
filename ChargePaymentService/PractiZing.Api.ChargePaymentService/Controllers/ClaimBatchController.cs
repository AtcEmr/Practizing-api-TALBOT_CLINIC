using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.BatchPaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ClaimBatchController : SecuredRepositoryController<IClaimBatchRepository>
    {
        private ILogger logger;
        public ClaimBatchController(IClaimBatchRepository claimBatchRepository, ILogger<ClaimBatchController> _logger) : base(claimBatchRepository)
        {
            this.logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repository.Get(null);
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

        [HttpGet("ClaimBatch")]
        public async Task<IActionResult> GetClaimBatch([FromQuery]ClaimFilter filter)
        {
            try
            {
                var result = await this.Repository.GetClaimBatches(filter);
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

        [HttpGet("GetFileText")]
        public async Task<IActionResult> GetFileText(Guid claimBatchUID)
        {
            try
            {
                var result = await this.Repository.GetFileText(claimBatchUID);
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

        [HttpPost("runScrub")]
        public async Task<IActionResult> RunScrub(string claimUId, string claimBatchUId, string providerUId, string facilityUId)
        {
            try
            {                
                var result = await this.Repository.RunScrub(claimUId, claimBatchUId, providerUId, facilityUId);                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("scrub")]
        [AllowAnonymous]
        public async Task<IActionResult> Scrub([FromBody]List<ScrubDTO> entities, string spName, int scrubId, string practiceCode)
        {
            try
            {
                var result = await this.Repository.RunAutoScrub(entities, spName, scrubId, practiceCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getClaimBatchScrub")]
        public async Task<IActionResult> GetClaimBatchScrubDTO(string claimBatchUId)
        {
            try
            {
                var result = await this.Repository.GetClaimBatchDTO(claimBatchUId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
