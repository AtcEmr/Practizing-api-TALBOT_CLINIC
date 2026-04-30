using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class PaymentAdjustmentController : SecuredRepositoryController<IPaymentAdjustmentRepository>
    {
        IPaymentService _paymentService;
        public PaymentAdjustmentController(IPaymentAdjustmentRepository PaymentAdjustmentRepository, IPaymentService paymentService) : base(PaymentAdjustmentRepository)
        {
            _paymentService = paymentService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]PaymentAdjustment entity)
        {
            try
            {
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

        [HttpPost("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody]IEnumerable<PaymentAdjustment> entities)
        {
            try
            {
                var result = await this.Repository.AddOrUpdate(entities);
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
        public async Task<IActionResult> Update([FromBody]PaymentAdjustment entity)
        {
            try
            {
                var result = await this.Repository.Update(entity);
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
        public async Task<IActionResult> Delete(Guid uid)
        {
            try
            {
                var result = await this.Repository.Delete(uid);
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
