using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Common;
using PractiZing.Base.Model;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : SecuredRepositoryController<IPatientRepository>
    {
        private readonly IPatientService _patientService;
        private readonly IDataIntegrationService _dataIntegrationService;

        public PatientController(IPatientRepository patientRepository, IPatientService patientService) : base(patientRepository)
        {
            this._patientService = patientService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll([FromQuery]SearchQuery<BaseSearchModel> entity, string searchKey, string sortOrder)
        {
            try
            {
                var queryInterface = SearchQuery.Map<BaseSearchModel, IBaseSearchModel>(entity);
                var result = await this.Repository.GetAll(queryInterface, searchKey, sortOrder);
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
            var result = await this._patientService.GetByUId(UId);
            return Ok(result);
        }

        [HttpGet("GetByPatientUId/{patientUId}")]
        public async Task<IActionResult> GetByPatientId(Guid patientUId, int? patientCaseId = 0)
        {
            try
            {
                var result = await this._patientService.Get(patientUId, (int)patientCaseId);
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

        [HttpGet("GetPatient")]
        public async Task<IActionResult> GetPatient(string patientName)
        {
            var result = await this._patientService.Get(patientName);
            return Ok(result);
        }

        [HttpGet("GetPatients/{patientName}")]
        public async Task<IActionResult> GetAll(string patientName)
        {
            var result = await this.Repository.GetAll(patientName);
            return Ok(result);
        }

        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var result = await this._patientService.GetAgingPatient();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]Patient entity)
        {
            try
            {
                var result = await this._patientService.AddNew(entity);
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

        [HttpPost("AddPatientInsuranceDetail")]
        public async Task<IActionResult> AddPatientInsuranceDetail([FromBody]Patient entity)
        {
            try
            {
                var result = await this._patientService.AddPatientInsuranceDetail(entity);
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
        public async Task<IActionResult> Update([FromBody]Patient entity)
        {
            try
            {
                var result = await this._patientService.UpdateEntity(entity);
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
        public async Task<IActionResult> Delete(Guid uid)
        {
            try
            {
                var result = await this._patientService.Delete(uid);
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

        [HttpGet("GetResidentialPatientData")]
        public async Task<IActionResult> GetResidentialPatientData()
        {
            try
            {
                var result = await this._dataIntegrationService.GetArPatientBillingData();
                return Ok(result);
            }         
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("refreshChargesReportData/{UId}")]
        public async Task<IActionResult> RefreshChargesReportData(Guid UId)
        {
            try
            {
                var result = await this.Repository.RefreshPatientChargesReport_WareHouse(UId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
