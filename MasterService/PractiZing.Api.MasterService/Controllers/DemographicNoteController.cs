using System;
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
    public class DemographicNoteController : SecuredRepositoryController<IDemographicNoteRepository>
    {
        public DemographicNoteController(IDemographicNoteRepository repository) : base(repository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid uid)
        {
            var result = await this.Repository.GetByUId(uid);
            return Ok(result);
        }

        [HttpGet("getByChargeNumber/{chargeNumber}")]
        public async Task<IActionResult> GetByChargeNumber(long chargeNumber)
        {
            var result = await this.Repository.GetByChargeNumber(chargeNumber);
            return Ok(result);
        }

        [HttpPost("AddNoteOrResponse")]
        public async Task<IActionResult> AddNew([FromBody]DemographicNote entity)
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
        public async Task<IActionResult> Update([FromBody]DemographicNote entity)
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