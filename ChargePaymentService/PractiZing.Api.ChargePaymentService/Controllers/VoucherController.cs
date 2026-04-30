using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class VoucherController : SecuredRepositoryController<IVoucherRepository>
    {

        private IPaymentService _paymentService;
        public VoucherController(IVoucherRepository VoucherRepository, IPaymentService paymentService) : base(VoucherRepository)
        {
            this._paymentService = paymentService;
        }

        [HttpGet("getByUId/{paymentBatchUId}/{patientUId}")]
        public async Task<IActionResult> GetByUId(string paymentBatchUId, string patientUId)
        {
            try
            {
                var result = await this.Repository.GetByUId(paymentBatchUId, patientUId);
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

        [HttpGet("GetByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            try
            {
                var result = await this.Repository.GetByUId(UId);
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

        [HttpGet("GetByCheckNumber")]
        public async Task<IActionResult> GetByCheckNumber(string checkNumber)
        {
            try
            {
                var result = await this.Repository.GetByCheckNumber(checkNumber);
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
                string obj = Request.Form["Voucher"].FirstOrDefault();
                var voucher = Newtonsoft.Json.JsonConvert.DeserializeObject<Voucher>(obj);
                var result = await this._paymentService.AddNewVoucher(voucher, files);
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
                string obj = Request.Form["Voucher"].FirstOrDefault();
                var voucher = Newtonsoft.Json.JsonConvert.DeserializeObject<Voucher>(obj);
                var result = await this._paymentService.Update(voucher, files);
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

        [HttpPut("UpdateIsCommitted")]
        public async Task<IActionResult> UpdateIsCommitted(Guid? voucherUId, Guid? paymentUId)
        {
            try
            {
                var result = await this._paymentService.CommitPayments(voucherUId, paymentUId);
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
        public async Task<IActionResult> Delete(Guid voucherUId)
        {
            try
            {
                var result = await this._paymentService.DeleteVoucher(voucherUId);
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

        [HttpPost("plaidMatched")]
        public async Task<IActionResult> CompareVoucherWithBank()
        {
            try
            {
                var result = await this._paymentService.CompareVoucherWithBank();
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
