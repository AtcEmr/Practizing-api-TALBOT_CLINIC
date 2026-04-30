using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService.Object;
using PractiZing.DataAccess.DenialService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class DenialQueueController : SecuredRepositoryController<IDenialQueueRepository>
    {
        public DenialQueueController(IDenialQueueRepository repository) : base(repository)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetUId(Guid UId)
        {
            var result = await this.Repository.GetByUId(UId);
            return Ok(result);
        }

        [HttpGet("GetAgingCount")]
        public async Task<IActionResult> GetAgingCount()
        {
            try
            {
                var result = await this.Repository.GetAgingCount();
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

        [HttpGet("GetFilterForDenialCharge")]
        public async Task<IActionResult> GetFilterForDenialCharge()
        {
            var result = await this.Repository.GetFilterForDenialCharge();
            return Ok(result);
        }

        [HttpGet("GetCharges")]
        public async Task<IActionResult> GetCharges([FromQuery]DenialFilter filter)
        {
            var result = await this.Repository.GetCharges(filter);
            return Ok(result);
        }

        [HttpGet("getAssignedFollowUpCount/{chargeIds}")]
        public async Task<IActionResult> GetAssignedFollowUpCount(IList<int> chargeIds)
        {
            try
            {
                var result = await this.Repository.GetAssignedFollowUpCount(chargeIds);
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

        [HttpPost("addOrUpdate")]
        public async Task<IActionResult> AddOrUpdate(string chargeUIds, string userUId)
        {
            try
            {
                var result = await this.Repository.AddOrUpdate(chargeUIds, userUId);
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
        public async Task<IActionResult> AddNew([FromBody]DenialQueue entity)
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
        public async Task<IActionResult> Update([FromBody]DenialQueue entity)
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
    }
}