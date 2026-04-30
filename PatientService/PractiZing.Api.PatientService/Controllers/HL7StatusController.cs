using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Model;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class HL7StatusController : SecuredRepositoryController<IHL7StatusRepository>
    {
        private ILogger _logger;

        public HL7StatusController(IHL7StatusRepository iHL7StatusRepository,
               ILogger<HL7StatusController> logger) : base(iHL7StatusRepository)
        {
            _logger = logger;
            _logger.LogInformation("$ HL7 status Controller");
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllData([FromQuery]HL7StatusFilter filter)
        {
            try
            {
                var result = await this.Repository.GetAllData(filter);
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

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.Repository.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetAllHL7")]
        public async Task<IActionResult> GetAll([FromQuery]HL7StatusFilter filter)
        {
            try
            {
                var result = await this.Repository.GetAll(filter);
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

        [HttpGet("moveFile")]
        public async Task<IActionResult> MoveFile(string entity)
        {
            try
            {
                var result = await this.Repository.MoveFile(entity);
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
        public async Task<IActionResult> AddNew([FromBody]HL7Status entity)
        {
            try
            {
                _logger.LogInformation("$ HL7 status addnew");

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

        [HttpPost("findFile")]
        public async Task<IActionResult> FindHL7File([FromBody]HL7StatusDTO entity)
        {
            try
            {
                var result = await this.Repository.FindFileByName(entity);
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
        public async Task<IActionResult> Update([FromBody]HL7Status entity)
        {
            try
            {
                _logger.LogInformation("$ HL7 status update");
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await this.Repository.Delete(id);
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

        [HttpDelete("DeleteFile")]
        public async Task<IActionResult> DeleteFile(string entity)
        {
            try
            {
                var result = await this.Repository.DeleteFile(entity);
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
