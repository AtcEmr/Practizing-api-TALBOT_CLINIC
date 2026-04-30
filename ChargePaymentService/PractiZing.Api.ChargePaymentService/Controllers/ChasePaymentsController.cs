using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]

    public class ChasePaymentsController : SecuredRepositoryController<IChasePaymentsRepository>
    {


        private readonly ILogger _logger;
        public ChasePaymentsController(IChasePaymentsRepository chasePaymentsRepository,ILogger<ChasePaymentsController> logger) : base(chasePaymentsRepository)
        {
            _logger = logger;

        }

        [HttpGet("data/{monthId}/{yearId}")]
        public async Task<IActionResult> Get(int monthId,int yearId)
        {
            try
            {
                var result = await this.Repository.Get(monthId,yearId);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                _logger.LogInformation($"validation error {ex.ValidationCodeResult}");
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ChasePaymentDTO entity)
        {
            try
            {
                var result = await this.Repository.AddChasePaymentChild(entity);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                _logger.LogInformation($"validation error {ex.ValidationCodeResult}");
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("report/{yearId}")]
        public async Task<IActionResult> GetDataYearWise(int yearId)
        {
            try
            {
                var result = await this.Repository.GetDataYearWise( yearId);
                //byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "ChasePayement_"+yearId.ToString());
                //return File(fileBytes, ExcelExportHelper.ExcelContentType);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                _logger.LogInformation($"validation error {ex.ValidationCodeResult}");
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updateownerDeposit/{chasePaymentId}")]
        public async Task<IActionResult> Update(int chasePaymentId)
        {
            try
            {
                var result = await this.Repository.UpdateAsOwenerDeposit(chasePaymentId);
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

        [HttpGet("unmappedChasePayments/{monthId}/{yearId}")]
        public async Task<IActionResult> UnmappedChasePayments(int monthId, int yearId)
        {
            try
            {
                var result = await this.Repository.GetUnMappedChasePayments(monthId, yearId);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                _logger.LogInformation($"validation error {ex.ValidationCodeResult}");
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ownerchasepayments/{monthId}/{yearId}")]
        public async Task<IActionResult> GetOwnerChasePayments(int monthId, int yearId)
        {
            try
            {
                var result = await this.Repository.GetOwnerChasePayments(monthId, yearId);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                _logger.LogInformation($"validation error {ex.ValidationCodeResult}");
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
