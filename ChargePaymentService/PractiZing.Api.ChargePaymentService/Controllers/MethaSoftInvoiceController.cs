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

    public class MethaSoftInvoiceController : SecuredRepositoryController<IMethaSoftInvoiceRepository>
    {


        private readonly ILogger _logger;
        public MethaSoftInvoiceController(IMethaSoftInvoiceRepository methaSoftInvoiceRepository,ILogger<InvoiceController> logger) : base(methaSoftInvoiceRepository)
        {
            _logger = logger;

        }



        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]MethaSoftInvoice entity)
        {
            try
            {
                var result = await this.Repository.AddNew(entity);
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

        [HttpPost("sendDataToEMR")]
        public async Task<IActionResult> SendDataToEMR()
        {
            try
            {
                var result = await this.Repository.SendDataToEMR();
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
