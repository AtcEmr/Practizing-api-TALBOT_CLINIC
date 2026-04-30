using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class BankReconciliationController : SecuredRepositoryController<IBankReconciliationRepository>
    {        
        public BankReconciliationController(IBankReconciliationRepository bankReconciliationRepository) : base(bankReconciliationRepository)
        {
            
        }

        [HttpGet("data/{monthId}/{yearId}")]
        public async Task<IActionResult> DownloadScrubErrors(int monthId,int yearId)
        {
            try
            {
                var result = await this.Repository.GetData(monthId, yearId);
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

        [HttpPut("update/{voucherId}/{chasePaymentId}")]
        public async Task<IActionResult> Update(int voucherId, int chasePaymentId)
        {
            try
            {
                var result = await this.Repository.Update(voucherId,chasePaymentId);
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

        [HttpPost("sync/{monthId}/{yearId}")]
        public async Task<IActionResult> Sync(int monthId, int yearId)
        {
            try
            {
                await this.Repository.SyncData(monthId,yearId);

                return Ok();
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

        [HttpPost("SyncDepositsWithChasePayments/{monthId}/{yearId}")]
        public async Task<IActionResult> SyncDepositsWithChasePayments(int monthId, int yearId)
        {
            try
            {
                await this.Repository.SyncDepositsWithChasePayments(monthId, yearId);

                return Ok();
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
