using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ReferringDoctorController : SecuredRepositoryController<IReferringDoctorRepository>
    {
        public ReferringDoctorController(IReferringDoctorRepository referringDoctorRepository) : base(referringDoctorRepository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery]ReferringDoctorFilter entity)
        {

            var result = await this.Repository.GetAll(entity);
            return Ok(result);
        }

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            var result = await this.Repository.GetByUId(UId);
            return Ok(result);
        }

        [HttpGet("getReferringDoctors")]
        public async Task<IActionResult> GetReferringDoctors()
        {
            var result = await this.Repository.GetReferringDoctors();
            return Ok(result);
        }

        [HttpGet("getByNPI/{NPI}")]
        public async Task<IActionResult> GetByNPI(string npi)
        {
            var result = await this.Repository.GetByNPI(npi);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ReferringDoctor entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
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
        public async Task<IActionResult> Update([FromBody]ReferringDoctor entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
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