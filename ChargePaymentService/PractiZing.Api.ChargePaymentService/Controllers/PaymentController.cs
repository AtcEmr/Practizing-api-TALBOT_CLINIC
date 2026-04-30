using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : SecuredRepositoryController<IPaymentRepository>
    {

        private IPaymentService _paymentService;

        public PaymentController(IPaymentRepository PaymentRepository, IPaymentService paymentService) : base(PaymentRepository)
        {
            this._paymentService = paymentService;
        }

        [HttpGet("GetByVoucherUId/{voucherUId}")]
        public async Task<IActionResult> GetByVoucherUId(string voucherUId)
        {
            try
            {
                var result = await this._paymentService.GetByVoucher(voucherUId, string.Empty);
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

        [HttpGet("GetBulkPaymentByVoucherId")]
        public async Task<IActionResult> GetPayment([FromQuery]BulkPaymentFilter filter)
        {
            try
            {
                var result = await this.Repository.GetPayment(filter);
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
        public async Task<IActionResult> AddNew([FromBody]Payment entity)
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

        [HttpPost("AddNewPayment")]
        public async Task<IActionResult> AddNewPayment([FromBody]Voucher entity)
        {
            try
            {
                var result = await this._paymentService.AddNewPayment(entity);
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

        [HttpPost("AddUpdateBulkPayment")]
        public async Task<IActionResult> AddUpdateBulkPayment([FromBody]IEnumerable<PaymentBatchDTO> entities)
        {
            try
            {
                await this._paymentService.AddUpdateBulkPayment(entities);
                return Ok(1);
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
        public async Task<IActionResult> AddOrUpdate([FromBody]IEnumerable<Payment> entities)
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
        public async Task<IActionResult> Update([FromBody]Payment entity)
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
        public async Task<IActionResult> Delete(Guid UId)
        {
            try
            {
                var result = await this._paymentService.Delete(UId);
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

        [HttpDelete("DeleteChargePayment/{chargePaymentId}")]
        public async Task<IActionResult> DeleteChargePayment(Guid chargePaymentId)
        {
            try
            {
                var result = await this._paymentService.DeleteChargePayment(chargePaymentId);
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

        [HttpDelete("DeleteChargePaymentBulk")]
        public async Task<IActionResult> DeleteChargePaymentBulk([FromBody] IEnumerable<Guid> chargePaymentIds)
        {
            try
            {
                foreach (var chargePaymentId in chargePaymentIds)
                {
                    var result = await this._paymentService.DeleteChargePayment(chargePaymentId);
                }
                
                return Ok(1);
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

        [HttpPost("AddBulkAdjustment/{invoiceUId}/{adjustmentCode}/{isRemarkCode}")]
        public async Task<IActionResult> AddBulkAdjustment(Guid invoiceUId, string adjustmentCode, bool isRemarkCode)
        {
            try
            {
                await this._paymentService.AddBulkAdjustment(invoiceUId, adjustmentCode, isRemarkCode);
                return Ok(1);
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

        [HttpPost("AddBalanceAdjustment")]
        public async Task<IActionResult> AddBalanceAdjustment([FromBody]BalanceAdjustmentModel obj)
        {
            try
            {
                await this._paymentService.AddBalanceAdjustmentFromUI(obj);
                return Ok(1);
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

        [HttpPost("WriteOffOldCharges")]
        public async Task<IActionResult> WriteOffOldCharges(string dosDate)
        {
            try
            {
                await this._paymentService.WriteOffOldAdjustment(dosDate);
                return Ok(1);
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

        [HttpPost("WriteOffDueByPatientCharges")]
        public async Task<IActionResult> WriteOffDueByPatientCharges(string dosDate)
        {
            try
            {
                await this._paymentService.WriteOffDueByPatientCharges(dosDate);
                return Ok(1);
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

        [HttpPost("WriteOffCharges")]
        public async Task<IActionResult> WriteOffCharges(string dosDate,string adjustmentCode,string postAdjusmentCode)
        {
            try
            {
                await this._paymentService.WriteOffCharges(dosDate, adjustmentCode, postAdjusmentCode);
                return Ok(1);
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

        [HttpPost("GetExcelForInsuranceWisePaymentReport")]
        public async Task<IActionResult> GetExcelForInsuranceWisePaymentReport([FromBody] object parameterObject)
        {
            try
            {
                var parameterData = ObjectConvertor<object>.ObjToDataTable(parameterObject);

                DateTime fromDate = Convert.ToDateTime(parameterData.Rows[0]["FromDate"].ToString());
                DateTime toDate = Convert.ToDateTime(parameterData.Rows[0]["ToDate"].ToString());

                var result = await this.Repository.GetExcelForInsuranceWisePaymentReport(fromDate, toDate);
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result, "Insurancewise Payment");
                return File(fileBytes, ExcelExportHelper.ExcelContentType);
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

        [HttpPost("GetReversPayments")]
        public async Task<IActionResult> GetReversPayments()
        {
            try
            {
                var result = await this.Repository.GetReversPayments();
                //System.Data.DataTable dt = ExcelExportHelper.ListToDataTable<IReversePaymentReportDTO>(result.ToList());
                //byte[] fileBytes = ExcelExportHelper.DownloadExcel(dt, "Reverse Payment");
                //return File(fileBytes, ExcelExportHelper.ExcelContentType);
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

        [HttpPost("PostWriteOffForAdjusments")]
        public async Task<IActionResult> PostWriteOffForAdjusments()
        {
            try
            {
                var result = await this._paymentService.PostWriteOffForAdjusments();
                return Ok(1);
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

        [HttpGet("getPaymentChargesForPortalPayment/{paymentId}")]
        public async Task<IActionResult> GetPaymentChargesForPortalPayment(int paymentId)
        {
            try
            {
                var result = await this.Repository.GetChargesForPortalPayment(paymentId);
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

        [HttpPost("WriteOffHandTCharges")]
        public async Task<IActionResult> WriteOffHandTCharges()
        {
            try
            {
                await this._paymentService.WriteOffHandTCharges();
                return Ok(1);
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

        [HttpPost("WriteOffBulkCharges")]
        public async Task<IActionResult> WriteOffBulkCharges([FromBody]BulkAdjustmentFROMUIModel adjustmentModel)
        {
            try
            {
                await this._paymentService.WriteOffAdjusmentCharges(adjustmentModel);
                return Ok(1);
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
