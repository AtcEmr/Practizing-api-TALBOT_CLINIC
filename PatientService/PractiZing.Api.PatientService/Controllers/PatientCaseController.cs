using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class PatientCaseController : SecuredRepositoryController<IPatientCaseRepository>
    {
        public PatientCaseController(IPatientCaseRepository patientCaseRepository) : base(patientCaseRepository)
        {
        }

        [HttpGet("get/{uniqueId}")]
        public async Task<IActionResult> Get(Guid uniqueId)
        {
            var result = await this.Repository.GetPatientCases(uniqueId);
            return Ok(result);
        }

        [HttpGet("getPatientCase/{patientUIds}")]
        public async Task<IActionResult> GetPatientCase(string patientUIds)
        {
            var result = await this.Repository.GetPatient(patientUIds);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]PatientCase entity)
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
        public async Task<IActionResult> Update([FromBody]PatientCase entity)
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
    }
}
