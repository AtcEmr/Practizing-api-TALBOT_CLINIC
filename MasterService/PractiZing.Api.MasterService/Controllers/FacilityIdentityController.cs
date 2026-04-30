using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class FacilityIdentityController : SecuredRepositoryController<IFacilityIdentityRepository>
    {
        public FacilityIdentityController(IFacilityIdentityRepository facilityIdentityRepository) : base(facilityIdentityRepository)
        {
        }

        [HttpGet("getByFacility/{facilityUId}")]
        public async Task<IActionResult> GetByFacility(Guid facilityUId)
        {
            var result = await this.Repository.GetByFacility(facilityUId);
            return Ok(result);
        }

        [HttpPost("addOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody]IEnumerable<FacilityIdentity> entities)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
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

        [HttpPost]
        public async Task<IActionResult> AddNewEntity([FromBody]FacilityIdentity entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this.Repository.AddNew(entity);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntity([FromBody]FacilityIdentity entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this.Repository.UpdateEntityData(entity);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid uid)
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
    }
}