using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class PaymentBatchController : SecuredRepositoryController<IPaymentBatchRepository>
    {
        private IPaymentService _paymentService;

        public PaymentBatchController(IPaymentBatchRepository paymentBatchRepository, IPaymentService paymentService) : base(paymentBatchRepository)
        {
            this._paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this._paymentService.Get();
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

        [HttpGet("GetBatchNumber")]
        public async Task<IActionResult> GetBatchNumber()
        {
            try
            {
                var result = await this.Repository.GetBatchNumber();
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

        [HttpGet("Get/{UId}")]
        public async Task<IActionResult> Get(Guid UId)
        {
            try
            {
                var result = await this.Repository.Get(UId);
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

        [HttpGet("GetBulkPayment")]
        public async Task<IActionResult> GetBulkPayment([FromQuery]BulkPaymentFilter filter)
        {
            try
            {
                var result = await this._paymentService.GetBulkPayment(filter);
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

        [HttpPost]
        public async Task<IActionResult> AddNew()
        {
            try
            {
                var files = Request.Form.Files;
                string obj = Request.Form["PaymentBatch"].FirstOrDefault();
                var paymentBatch = Newtonsoft.Json.JsonConvert.DeserializeObject<PaymentBatch>(obj);
                var result = await this.Repository.AddNew(paymentBatch, files);
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

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            try
            {
                var files = Request.Form.Files;
                string obj = Request.Form["PaymentBatch"].FirstOrDefault();
                var paymentBatch = Newtonsoft.Json.JsonConvert.DeserializeObject<PaymentBatch>(obj);
                var result = await this.Repository.Update(paymentBatch, files);
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

        [HttpPut("UpdateBatch")]
        public async Task<IActionResult> Update([FromBody]PaymentBatch paymentBatch)
        {
            try
            {
                var result = await this.Repository.Update(paymentBatch);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteByBatchUId(Guid batchUId)
        {
            try
            {
                var result = await this._paymentService.DeleteByBatchUId(batchUId, false);
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

        [HttpDelete("DeletePaymentBatch")]
        public async Task<IActionResult> DeletePaymentBatch(Guid batchUId)
        {
            try
            {
                var result = await this._paymentService.DeleteByBatchUId(batchUId, true);
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

        [HttpGet("GetBatchesGrid")]
        public async Task<IActionResult> GetBatchesGrid([FromQuery]BatchFilter entity)
        {
            try
            {
                var result = await this._paymentService.GetBatches(entity);
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

        [HttpGet("getVouchers")]
        public async Task<IActionResult> GetVouchers([FromQuery]VoucherViewFilter filter)
        {
            try
            {
                var result = await this._paymentService.GetBulkVouchers(filter);
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
