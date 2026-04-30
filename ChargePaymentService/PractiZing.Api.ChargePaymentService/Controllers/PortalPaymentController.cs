using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
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
    [Route("api/[Controller]")]
    public class PortalPaymentController : SecuredRepositoryController<IPortalPaymentRepository>
    {
        IPortalPaymentService _portalPaymentService;
        public PortalPaymentController(IPortalPaymentRepository portalPaymentRepository, IPortalPaymentService portalPaymentService) : base(portalPaymentRepository)
        {
            this._portalPaymentService = portalPaymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PortalPaymentFilterDTO filter)
        {
            try
            {
                var result = await this._portalPaymentService.Get(filter);
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


        [HttpGet("getPortalPayments")]
        public async Task<IActionResult> GetPortalPayments(Guid patientUId)
        {
            try
            {
                var result = await this._portalPaymentService.GetPatientPayments(patientUId);
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

        [HttpGet("getPortalPaymentsEMR/{emrPaientId}")]
        public async Task<IActionResult> GetPortalPaymentsEMR(string emrPaientId)
        {
            try
            {
                var result = await this._portalPaymentService.GetPatientPaymentsForEMR(emrPaientId);
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

        [HttpPost("Refund")]
        public async Task<IActionResult> Refund([FromBody]RefundPaymentDTO entity)
        {
            try
            {
                var result = await this._portalPaymentService.RefundPortalPayment(entity);
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

        [HttpGet("HelpDeskPayments")]
        public async Task<IActionResult> GetHelpDeskPayments()
        {
            try
            {
                var result = await this._portalPaymentService.GetHelpDeskPayments();
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

        [HttpGet("dynmoPayments")]
        public async Task<IActionResult> GetHelpDeskPayments([FromQuery]DynmoPaymentFilterDTO filter)
        {
            try
            {
                var result = await this._portalPaymentService.GetDynmoPayments(filter);
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

        [HttpPost("dynmoExcelData")]
        public async Task<IActionResult> DymnoExcelForCatalystRCM([FromBody] List<int> ids)
        {
            try
            {
                var result = await this._portalPaymentService.GetDynmoPaymentsForCatalystRCM();
                //result.Columns.RemoveAt(0);
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result, "OnlinePayments");
                //await System.IO.File.WriteAllBytesAsync("c:/temp/hh.xlxs", fileBytes);
                //return File(fileBytes, ExcelExportHelper.ExcelContentType);
                return Ok(fileBytes);

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

        [HttpPost("updatedynmopayments")]
        public async Task<IActionResult> UpdateDynmoNotification([FromBody]List<int> ids)
        {
            try
            {
                var result = await this._portalPaymentService.UpdateDynmoNotification(ids);
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

        [HttpPost("updateFromCatalystRCMAsNotExists")]
        public async Task<IActionResult> UpdateBadRecordFromCatalystRCM([FromBody]List<int> ids)
        {
            try
            {
                var result = await this._portalPaymentService.UpdateBadRecordFromCatalystRCM(ids);
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

        [HttpPost("updateDynmoPayment")]
        public async Task<IActionResult> UpdateDynmoPayment([FromBody]DynmoPayments entity)
        {
            try
            {
                var result = await this._portalPaymentService.UpdateDynmoPayment(entity);
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

        [HttpPost("moveinportalpayment/{paymentid}")]
        public async Task<IActionResult> MoveInPortalPayment(int paymentid)
        {
            try
            {
                var result = await this._portalPaymentService.MoveInPortalPayment(paymentid);
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

        [HttpPost("saveDatainPortalPaymentTables")]
        public async Task<IActionResult> SaveDatainPortalPaymentTables([FromBody] DynmoPayments entity)
        {
            try
            {
                List<IDynmoPayments> dynmoPayments = new List<IDynmoPayments>();
                dynmoPayments.Add(entity);
                var result = await this._portalPaymentService.SaveDatainPortalPaymentTables(dynmoPayments);
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

        [HttpPost("RefundManual")]
        public async Task<IActionResult> RefundManual(string chargeid, string reasons)
        {
            try
            {
                var result = await this._portalPaymentService.RefundChargeByChargeId(chargeid, reasons);
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

        [HttpPost("AddNewPayment/{portalPaymentUId}")]
        public async Task<IActionResult> AddNewPayment(Guid portalPaymentUId)
        {
            try
            {
                var result = await this._portalPaymentService.AddNewPayment(portalPaymentUId);
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

        [HttpPost("adjustCopayPayment")]
        public async Task<IActionResult> AdjustCopayPayment([FromBody] PortalPayment entity)
        {
            try
            {                
                var result = await this._portalPaymentService.AdjustCopayPayment(entity);
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

        [HttpPost("getPaymentChargesForPortalPayment/{portalPaymentUId}")]
        public async Task<IActionResult> GetPaymentChargesForPortalPayment(Guid portalPaymentUId)
        {
            try
            {
                var result = await this._portalPaymentService.GetChargesForPortalPayment(portalPaymentUId);
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

        [HttpGet("GetOnlineUnPostedPayments/{billingId}")]
        public async Task<IActionResult> GetOnlineUnPostedPayments(string billingId)
        {
            try
            {
                var result = await this._portalPaymentService.GetOnlineUnPostedPayments(billingId);
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

        [HttpPost("sendMoneyToLab")]
        public async Task<IActionResult> SendMoneyToLab([FromBody] LabPaymentDTO labPaymentDTO)
        {
            try
            {
                var result = await this._portalPaymentService.SendMoneyToLab(labPaymentDTO);
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

        [HttpPost("AutoMoveInPortalPayment")]
        public async Task<IActionResult> AutoMoveInPortalPayment()
        {
            try
            {
                var result = await this._portalPaymentService.AutoMoveInPortalPayment();
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
