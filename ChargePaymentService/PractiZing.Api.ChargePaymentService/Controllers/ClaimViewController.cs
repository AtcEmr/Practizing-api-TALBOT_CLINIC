using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ClaimViewController : SecuredRepositoryController<IClaimFileProcessService>
    {
        public ClaimViewController(IClaimFileProcessService service) : base(service)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid uId)
        {
            try
            {
                var result = await this.Repository.ExportCms1500Async(uId);
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

        [HttpPost("proccessM837")]
        public async Task<IActionResult> ProccessM837(Guid batchUId)
        {
            try
            {
                var result = await this.Repository.ExportM837File(batchUId);
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

        [HttpPost("read277")]
        public async Task<IActionResult> Read277()
        {
            try
            {
                var result = await this.Repository.Read277();
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

        [HttpPost("read824")]
        public async Task<IActionResult> Read824()
        {
            try
            {
                var result = await this.Repository.Read824();
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

        [HttpPost("uploade270todeloitte")]
        public async Task<IActionResult> Upload270EdiFilesToDeloitte()
        {
            try
            {
                var result = await this.Repository.Upload270EdiFilesToDeloitte();
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

        [HttpPost("Upload837DeloitteFilesBulk")]
        public async Task<IActionResult> Upload837DeloitteFilesBulk()
        {
            try
            {
                var result = await this.Repository.Upload837DeloitteFiles_Bulk();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost("Create837PEdiFiles/{clearingHouseId}")]
        public async Task<IActionResult> Create837PEdiFiles(int clearingHouseId)
        {
            try
            {
                //deloitte
                var result = await this.Repository.Create837PEdiFiles(clearingHouseId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
