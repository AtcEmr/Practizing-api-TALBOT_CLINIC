using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ChargeBatchController : SecuredRepositoryController<IChargeBatchRepository>
    {
        private IChargeInvoiceService _chargeInvoiceService;
        private IChargeBatchRepository _chargeBatchRepository;
        public ChargeBatchController(IChargeBatchRepository chargeBatchRepository, IChargeInvoiceService chargeInvoiceService) : base(chargeBatchRepository)
        {
            this._chargeInvoiceService = chargeInvoiceService;
            this._chargeBatchRepository = chargeBatchRepository;
        }

        /// <summary>
        /// method for get charges with payment's for bulk payment screen
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery]PaymentFilterDTO filter)
        {
            try
            {
                var result = await this._chargeInvoiceService.Get(filter);
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

        /// <summary>
        /// get method for charge screen group by cpt codes
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        //[HttpGet("getChargeGrid")]
        //public async Task<IActionResult> GetChargeGrid([FromQuery]BatchFilter filter)
        //{
        //    try
        //    {
        //        var result = await this.Repository.GetChargeGrid(filter);
        //        return Ok(result);
        //    }
        //    catch (EntityException ex)
        //    {
        //        return StatusCode(400, ex.ValidationCodeResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        /// <summary>
        /// this mathod generates batch number
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// this method generate current active charge batch
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCurrentBatchNo")]
        public async Task<IActionResult> GetCurrentBatchNo()
        {
            try
            {
                var result = await this.Repository.GetCurrentBatch();
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

        /// <summary>
        /// post method to add new charge batch
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ChargeBatch entity)
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

        /// <summary>
        /// method to update charge batch
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ChargeBatch entity)
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

        /// <summary>
        /// method to update charge batch status
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("updateStatus/{chargeBatchUId}/{isActive}")]
        public async Task<IActionResult> UpdateStatus(string chargeBatchUId, bool isActive)
        {
            try
            {
                var result = await this.Repository.UpdateStatus(chargeBatchUId, isActive);
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

        /// <summary>
        /// delete charge batch
        /// </summary>
        /// <param name="chargeBatchId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(string chargeBatchUId)
        {
            try
            {
                var result = await this._chargeInvoiceService.Delete(chargeBatchUId);
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

        [HttpGet("getActive")]
        public async Task<IActionResult> GetActive()
        {
            try
            {
                var result = await this.Repository.GetActive();
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

        [HttpGet("GetpPaymentForACK")]
        public async Task<IActionResult> GetpPaymentForACK()
        {
            try
            {
                var result = await this._chargeInvoiceService.GetForPaymentACK();
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

        [HttpPost("GetLockedChargesForACK")]
        public async Task<IActionResult> GetLockedChargesForACK()
        {
            try
            {
                var result = await this._chargeInvoiceService.GetLockedChargesForACK();
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

        [HttpGet("UpdateCCNClaims")]
        public async Task<IActionResult> UpdateCCNClaims()
        {
            try
            {
                var result = await this._chargeBatchRepository.UpdateCCNClaims();
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
