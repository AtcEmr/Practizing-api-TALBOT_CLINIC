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

    public class InvoiceController : SecuredRepositoryController<IInvoiceRepository>
    {

        public IChargeInvoiceService _chargeInvoiceService;
        private readonly ILogger _logger;
        public InvoiceController(IChargeInvoiceService chargeInvoiceService,
            IInvoiceRepository chargeRepository,
            ILogger<InvoiceController> logger) : base(chargeRepository)
        {
            _logger = logger;
            _chargeInvoiceService = chargeInvoiceService;
        }

        [HttpGet("getByPatientCaseUId/{patientCaseUId}/{invoiceUId}")]
        public async Task<IActionResult> GetInvoice(Guid patientCaseUId, Guid invoiceUId)
        {
            var result = await this._chargeInvoiceService.GetByInvoice(patientCaseUId, invoiceUId);
            return Ok(result);
        }

        [HttpGet("getInvoices/{patientCaseUId}")]
        public async Task<IActionResult> GetInvoices(string patientCaseUId)
        {
            var result = await this._chargeInvoiceService.GetByInvoices(patientCaseUId);
            return Ok(result);
        }

        [HttpGet("getMaxId")]
        public async Task<IActionResult> GetMaxId()
        {
            try
            {
                var result = await this.Repository.GetMaxId();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]Invoice entity)
        {
            try
            {
                var result = await this._chargeInvoiceService.AddNew(entity);
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Invoice entity)
        {
            try
            {
                var result = await this._chargeInvoiceService.UpdateEntity(entity);
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
        public async Task<IActionResult> Delete(string uid)
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

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            var result = await this.Repository.GetByUId(UId);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpPost("udateOriginalCPTCode/{uid}")]
        public async Task<IActionResult> UdateOriginalCPTCode(string uid)
        {
            try
            {
                var result = await this._chargeInvoiceService.UpdateGCCode(uid);
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

        [HttpGet("checkGCCode/{uId}")]
        public async Task<IActionResult> CheckGCCode(string uid)
        {
            try
            {
                var result = await this._chargeInvoiceService.CheckGCCode(uid);
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

        [HttpGet("checkForAccessionNumber/{accessionNumber}")]
        public async Task<IActionResult> CheckForAccessionNumber(string accessionNumber)
        {
            var result = await this.Repository.CheckForAccessionNumber(accessionNumber);
            return Ok(result);
        }

        [HttpGet("GetBillingHistoryInvoice")]
        public async Task<IActionResult> GetBillingHistoryInvoice([FromQuery]ChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetBillingHistoryInvoice(filter);
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

        [HttpGet("GetBillingHistoryInvoiceForEMR/{billingId}")]
        public async Task<IActionResult> GetBillingHistoryInvoiceForEMR(string billingId)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetBillingHistoryInvoiceForEMR(billingId);
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

        [HttpGet("GetAccessionNumbers/{patientUId}")]
        public async Task<IActionResult> GetAccessionNumbers(Guid patientUId)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetAccessionNumber(patientUId);
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

        [HttpGet("GetChargesForAdjustment/{patientUId}")]
        public async Task<IActionResult> GetChargesForAdjustment(Guid patientUId)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetChargesForAdjustment(patientUId);
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

        [HttpGet("GetAccessionNumbersForRolledUp/{patientUId}")]
        public async Task<IActionResult> GetAccessionNumbersForRolledUp(Guid patientUId)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetAccessionNumbersForRolledUp(patientUId);
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

        [HttpGet("GetAccessionNumbersForRolledUpChild/{invoiceUid}")]
        public async Task<IActionResult> GetAccessionNumbersForRolledUpChild(Guid invoiceUid)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetAccessionNumberForRolledUpChild(invoiceUid);
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

        [HttpPost("RolledUpCharges/{parentInvoiceUid}/{childInvoiceUid}")]
        public async Task<IActionResult> RolledUpCharges(Guid parentInvoiceUid, Guid childInvoiceUid)
        {
            try
            {
                var result = await this._chargeInvoiceService.RolledUpCharges(parentInvoiceUid,childInvoiceUid);
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

        [HttpPost("UpdateCharges")]
        public async Task<IActionResult> UpdateCharges([FromBody]List<Charges> charges)
        {
            try
            {
                var result = await this._chargeInvoiceService.UpdateCharges(charges);
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

        [HttpPost("runemrscrub")]
        public async Task<IActionResult> RunEmrScrub()
        {
            try
            {
                var result = await this._chargeInvoiceService.RunEMRScrub();
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

        [HttpPost("doNotBillInvoices")]
        public async Task<IActionResult> DoNotBillInvoices([FromBody] List<string> invoiceUIds)
        {
            try
            {
                List<Guid> invoiceGUIds = new List<Guid>();                
                invoiceGUIds = invoiceUIds.ConvertAll(Guid.Parse);
                var result = await this._chargeInvoiceService.DoNotBillInvoices(invoiceGUIds);
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

        [HttpPost("billInvoices")]
        public async Task<IActionResult> BillInvoices([FromBody] Invoice invoice)
        {
            try
            {
                List<Guid> invoiceGUIds = new List<Guid>();
                invoiceGUIds = invoice.InvoiceUIds.ConvertAll(Guid.Parse);
                var result = await this._chargeInvoiceService.BillInvoices(invoiceGUIds, invoice.BillableCoupon);
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

        [HttpPost("rejectedInvoices")]
        public async Task<IActionResult> MarkAsRejectedCases([FromBody] Invoice invoice)
        {
            try
            {
                List<Guid> invoiceGUIds = new List<Guid>();
                invoiceGUIds = invoice.InvoiceUIds.ConvertAll(Guid.Parse);
                var result = await this._chargeInvoiceService.MarkAsRejected(invoiceGUIds, invoice.BillableCoupon);
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


        [HttpPost("addOrUpdateWriteoff")]
        public async Task<IActionResult> AddOrUpdateWriteOff([FromBody] ChargeInWriteOffDTO chargeInWriteOffDTO)
        {
            try
            {
                var result = await this._chargeInvoiceService.AddOrUpdateWriteOff(chargeInWriteOffDTO);
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

        [HttpPost("UpdateWriteoff")]
        public async Task<IActionResult> UpdateWriteoff([FromBody] List<EmrChargeInWriteOffDTO> chargeInWriteOffDTO)
        {
            try
            {
                var result = await this._chargeInvoiceService.UpdateWriteOff(chargeInWriteOffDTO);
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
