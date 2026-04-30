using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService.Tables;

namespace PractiZing.Api.DenialService.Controllers
{
    [Route("api/[controller]")]
    public class ActionNoteController : SecuredRepositoryController<IActionNoteRepository>
    {
        public ActionNoteController(IActionNoteRepository repository) : base(repository)
        {

        }

        [HttpGet("getByChargeUId/{patientUId}/{chargeUId}")]
        public async Task<IActionResult> GetByChargeUId(Guid patientUId, Guid chargeUId)
        {
            var result = await this.Repository.GetByChargeUId(patientUId, chargeUId);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.Get();
            return Ok(result);
        }

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            var result = await this.Repository.Get(UId);
            return Ok(result);
        }

        [HttpGet("getByPatientUId")]
        public async Task<IActionResult> GetByPatientUId(string patientUId)
        {
            var result = await this.Repository.GetByPatientUId(patientUId);
            return Ok(result);
        }

        [HttpGet("getExceptPatientsByPatientUId")]
        public async Task<IActionResult> GetExceptPatientsByPatientUId(string patientUId)
        {
            var result = await this.Repository.GetByPatientUIdExceptPatientsNotes(patientUId);
            return Ok(result);
        }

        [HttpPost("AddNoteOrResponse")]
        public async Task<IActionResult> AddNew()
        {
            try
            {
                var files = Request.Form.Files;
                string obj = Request.Form["ActionNote"].FirstOrDefault();
                var actionNote = Newtonsoft.Json.JsonConvert.DeserializeObject<ActionNote>(obj);
                var result = await this.Repository.AddNew(actionNote, files);
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

        [HttpPost("AddPatientNote")]
        public async Task<IActionResult> AddNew([FromBody]ActionNote entity)
        {
            try
            {
                var result = await this.Repository.AddPatientNote(entity);
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
        public async Task<IActionResult> Update([FromBody]ActionNote entity)
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

        [HttpPut("UpdatePatientNote")]
        public async Task<IActionResult> UpdatePatientNote([FromBody]ActionNote entity)
        {
            try
            {
                var result = await this.Repository.UpdatePatientNote(entity);
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
                var result = await this.Repository.Delete(uId);
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