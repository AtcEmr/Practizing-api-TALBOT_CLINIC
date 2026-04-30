using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.Common;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]

    public class InvDiagnosisController : SecuredRepositoryController<IInvDiagnosisRepository>
    {
        public InvDiagnosisController(IInvDiagnosisRepository InvDiagnosisRepository) : base(InvDiagnosisRepository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getByInvoiceUId/{invoiceUId}")]
        public async Task<IActionResult> GetByInvoiceUId(string invoiceUId)
        {
            var result = await this.Repository.GetByInvoiceUId(invoiceUId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]InvDiagnosis entity)
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]InvDiagnosis entity)
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
        public async Task<IActionResult> Delete(string invoiceUId)
        {
            try
            {
                var result = await this.Repository.Delete(invoiceUId);
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