using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.Common;

namespace PractiZing.Api.ClaimPaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ClaimController : SecuredRepositoryController<IClaimRepository>
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimRepository ClaimRepository, IClaimService claimService) : base(ClaimRepository)
        {
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.Repository.Get();
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

        [HttpGet("getbyInvoiceId/{invoiceUid}")]
        public async Task<IActionResult> GetByInvoiceId(Guid invoiceUid)
        {
            try
            {
                var result = await this.Repository.GetByInvoiceId(invoiceUid);
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

        [HttpGet("getByBatchUId/{claimBatchUId}")]
        public async Task<IActionResult> GetByBatchId(Guid claimBatchUId)
        {
            var result = await this.Repository.GetByBatchUId(claimBatchUId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]AddClaimInfoDTO entity)
        {
            try
            {
                var result = await this._claimService.CreateClaim(entity);
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

        [HttpPost("makeclaim")]
        public async Task<IActionResult> AddNew([FromBody]List<Guid> invoiceUIds)
        {
            try
            {
                var result = await this._claimService.MakeClaim(invoiceUIds);
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

        [HttpPost("MakeClaimForRatherThanSelf")]
        public async Task<IActionResult> MakeClaimForRatherThanSelf([FromBody]List<Guid> invoiceUIds)
        {
            try
            {
                var result = await this._claimService.MakeClaimForRatherThanSelf(invoiceUIds);
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

        [HttpPost("makePrimaryclaimWithSecondary")]
        public async Task<IActionResult> MakePrimaryClaimWithSecondary([FromBody]List<Guid> invoiceUIds)
        {
            try
            {
                var result = await this._claimService.MakePrimaryClaimWithSecondary(invoiceUIds);
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

        [HttpPost("makeCorrectedclaim")]
        public async Task<IActionResult> MakeCorrectedclaim([FromBody]List<int> claimIds)
        {
            try
            {
                var result = await this._claimService.MakeCorrectedClaim(claimIds);
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

        [HttpPost("reivewneeded")]
        public async Task<IActionResult> ReviewNeeded([FromBody]List<Guid> invoiceUIds)
        {
            try
            {
                var result = await this._claimService.ReviewNeeded(invoiceUIds,true,"Manually did for Review Needed from UI.");
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

        [HttpPost("reivewnotneeded")]
        public async Task<IActionResult> ReviewNotNeeded([FromBody]List<Guid> invoiceUIds)
        {
            try
            {
                var result = await this._claimService.ReviewNeeded(invoiceUIds, false, "Manually did Release from Review Needed from UI.");
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

        [HttpPut("createBatch")]
        public async Task<IActionResult> CreateBatch([FromBody] List<Guid> claimUIds)
        {
            try
            {
                string uids = string.Join(",", claimUIds);
                var result = await this._claimService.CreateBatchAuto(uids);
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

        [HttpPut("updateEntities")]
        public async Task<IActionResult> UpdateEntities([FromBody]IList<Claim> entities)
        {
            try
            {
                var result = await this.Repository.UpdateEntities(entities);
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

        [HttpPut("unBatch")]
        public async Task<IActionResult> UnBatch([FromBody]Claim entity)
        {
            try
            {
                var result = await this._claimService.UnBatchClaim(entity);
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

        [HttpGet("getClaimbyInvoice/{invoiceUId}/{lvl}")]
        public async Task<IActionResult> GetClaimbyInvoice(string invoiceUId, short lvl)
        {
            try
            {
                var result = await this.Repository.GetClaimbyInvoice(invoiceUId, lvl);
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
        public async Task<IActionResult> Update([FromBody]Claim entity)
        {
            try
            {
                var result = await this.Repository.UpdateEntity(entity);
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
        public async Task<IActionResult> Delete(Guid uId)
        {
            try
            {
                var result = await this._claimService.Delete(uId);
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

        [HttpGet("secondaryclaimAutomation")]
        public async Task<IActionResult> ClaimAutomation()
        {
            try
            {
                var result = await this._claimService.MakeClaim_Secondary();
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

        [HttpGet("GetForACK")]
        public async Task<IActionResult> GetForACK()
        {
            try
            {
                var result = await this._claimService.GetForACK();
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

        [HttpGet("UpdateClaimAfterNotifyRevdx/{claimid}")]
        public async Task<IActionResult> UpdateClaimAfterNotifyRevdx(long claimid)
        {
            try
            {
                var result = await this._claimService.UpdateClaimAfterNotifyRevdx(claimid);
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

        [HttpPost("RebillDenialChargesWherePrimaryPolicyChanged")]
        public async Task<IActionResult> RebillDenialChargesWherePrimaryPolicyChanged()
        {
            try
            {
                var result = await this._claimService.RebillDenialChargesWherePrimaryPolicyChanged();
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

        [HttpPost("RebillDenialChargesWherePayerChanged")]
        public async Task<IActionResult> RebillDenialChargesWherePayerChanged()
        {
            try
            {
                var result = await this._claimService.RebillDenialChargesWherePayerChanged();
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

        [HttpPost("PrimaryClaimAutomation")]
        public async Task<IActionResult> PrimaryClaimAutomation()
        {
            try
            {
                var result = await this._claimService.PrimaryClaimAutomation();
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

        [HttpPost("createBatchAutomation")]
        public async Task<IActionResult> CreateBatchAutomation()
        {
            try
            {

                var result = await this._claimService.CreateBatchAutomtion();
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

        [HttpPost("RunBatchScrubForAutomtion/{clearingHouseId}")]
        public async Task<IActionResult> RunBatchScrubForAutomtion(int clearingHouseId)
        {
            try
            {
                var result = await this._claimService.RunBatchScrubForAutomtion(clearingHouseId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
