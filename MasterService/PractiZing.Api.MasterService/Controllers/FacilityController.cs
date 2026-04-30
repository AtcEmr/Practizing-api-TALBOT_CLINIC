using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class FacilityController : SecuredRepositoryController<IFacilityRepository>
    {
        IFacilityService _facilityService;
        public FacilityController(IFacilityRepository repository,IFacilityService facilityService) : base(repository)
        {
            this._facilityService = facilityService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getByUId/{uid}")]
        public async Task<IActionResult> GetByUId(Guid uid)
        {
            var result = await this.Repository.GetByUId(uid);
            return Ok(result);
        }

        [HttpGet("getAllActiveFacility")]
        public async Task<IActionResult> GetAllActiveFacility()
        {
            var result = await this.Repository.GetAllActiveFacility();
            return Ok(result);
        }

        [HttpGet("GetParentActiveFacility")]
        public async Task<IActionResult> GetParentActiveFacility()
        {
            var result = await this.Repository.GetParentActiveFacility();
            return Ok(result);
        }

        [HttpGet("DefaultFacility")]
        public async Task<IActionResult> GetDefaultFacility()
        {
            var result = await this.Repository.GetDefaultFacility();
            return Ok(result);
        }

        [HttpGet("getFacilityByName/{facilityName}")]
        public async Task<IActionResult> GetFacility(string facilityName)
        {
            var result = await this.Repository.GetFacilityByName(facilityName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]Facility entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                //var result = await this.Repository.AddNew(entity);
                var result = await this._facilityService.AddNew(entity);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> AddNew([FromBody]Facility entity)
        //{
        //    try
        //    {
        //        this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
        //        var result = await this.Repository.AddNew(entity);
        //        return Ok(result);
        //    }
        //    catch (EntityException ex)
        //    {
        //        return StatusCode(400, ex.ValidationCodeResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Facility entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this._facilityService.Update(entity);
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