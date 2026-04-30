using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.BatchPaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ClaimStatusInquiryController : SecuredRepositoryController<IClaimBatchRepository>
    {
        private ILogger logger;
        private IClaimStatusEnquiryService _claimStatusEnquiryService;
        public ClaimStatusInquiryController(IClaimBatchRepository claimBatchRepository, IClaimStatusEnquiryService claimStatusEnquiryService,ILogger<ClaimBatchController> _logger) : base(claimBatchRepository)
        {
            this.logger = _logger;
            this._claimStatusEnquiryService = claimStatusEnquiryService;
        }

        [HttpGet("SentClaimStatusInquiry")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this._claimStatusEnquiryService.SentClaimStatusInquiry();
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
