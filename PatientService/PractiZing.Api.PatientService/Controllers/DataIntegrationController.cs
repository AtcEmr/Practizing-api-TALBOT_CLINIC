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
    public class DataIntegrationController : SecuredRepositoryController<IDataIntegrationRepository>
    {
        private readonly IDataIntegrationService _dataIntegrationService;

        public DataIntegrationController(IDataIntegrationService dataIntegrationService, IDataIntegrationRepository dataIntegrationRepository) : base(dataIntegrationRepository)
        {
            this._dataIntegrationService = dataIntegrationService;
        }

        [HttpPost("GetResidentialPatientData")]
        public async Task<IActionResult> GetResidentialPatientData()
        {
            try
            {
                var result = await this._dataIntegrationService.GetArPatientBillingData();
                //var result = await this._dataIntegrationService.GetAllPolicies();
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

        //[HttpPost("GetResidentialPatientData_Talbot")]
        //public async Task<IActionResult> GetResidentialPatientDataTALBOT()
        //{
        //    try
        //    {
        //        //var result = await this._dataIntegrationService.GetArPatientBillingData_TALBOTRES();
        //        //return Ok(result);
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

        [HttpPost("GetEmrProviders")]
        public async Task<IActionResult> GetEMRProviders()
        {
            try
            {
                var result = await this._dataIntegrationService.GetEMRProviders();
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

        [HttpPost("GetEmrFacilites")]
        public async Task<IActionResult> GetEmrFacilites()
        {
            try
            {
                var result = await this._dataIntegrationService.GetEMRFacilities();
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

        [HttpPost("GetPractitionerModifierList")]
        public async Task<IActionResult> GetPractitionerModifierList()
        {
            try
            {
                var result = await this._dataIntegrationService.GetPractitionerModifierList();
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

        [HttpGet("ImportPatientPoliciesFromEMR")]
        public async Task<IActionResult> ImortPatientPoliciesFromEMR()
        {
            try
            {
                var result = await this._dataIntegrationService.GetAllPolicies();
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

        [HttpPost("syncpoliciesfromemr/{patientId}")]
        public async Task<IActionResult> SyncPoliciesFromEMR(int patientId)
        {
            try
            {
                var result = await this._dataIntegrationService.SyncPoliciesFromEMR(patientId);
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

        [HttpPost("EMRUpdatedPolicySync")]
        public async Task<IActionResult> EMRUpdatedPolicySync()
        {
            try
            {
                var result = await this._dataIntegrationService.SyncPoliciesFromEMRBulk();
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

        [HttpPost("SyncEmrPatients")]
        public async Task<IActionResult> SyncEmrPatients()
        {
            try
            {
                var result = await this._dataIntegrationService.SyncEmrPatients();
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
