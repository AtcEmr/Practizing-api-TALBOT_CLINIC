using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class PatientAlertController : SecuredRepositoryController<IPatientAlertRepository>
    {
        private ILogger _logger;
        public PatientAlertController(IPatientAlertRepository patientAlertRepository,
                                     ILogger<PatientAlertController> logger) : base(patientAlertRepository)
        {
            _logger = logger;
            _logger.LogInformation("PatientNote Controller");
        }

        [HttpGet("getAll")]
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

        [HttpGet]
        public async Task<IActionResult> Get(Guid uId)
        {
            try
            {
                var result = await this.Repository.Get(uId);
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

        [HttpGet("activealert")]
        public async Task<IActionResult> GetActiveAlert(Guid patientUId)
        {
            try
            {
                var result = await this.Repository.GetActiveAlert(patientUId);
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

        [HttpGet("GetByPatientUId")]
        public async Task<IActionResult> GetByPatientUId(Guid patientUId)
        {
            try
            {
                var result = await this.Repository.GetByPatientUId(patientUId);
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

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            var result = await this.Repository.Get(UId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]PatientAlert entity)
        {
            try
            {
                _logger.LogInformation("$ PatientNote AddNew");

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
        public async Task<IActionResult> Update([FromBody]PatientAlert entity)
        {
            try
            {
                _logger.LogInformation("$ PatientNote Update");
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
        public async Task<IActionResult> Delete(Guid uId)
        {
            try
            {
                _logger.LogInformation("$ PatientNote Delete");
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
