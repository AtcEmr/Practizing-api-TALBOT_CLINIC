using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class InsurancePolicyController : SecuredRepositoryController<IInsurancePolicyRepository>
    {
        private readonly IInsurancePolicyService _insurancePolicyService;
        public InsurancePolicyController(IInsurancePolicyRepository insurancePolicyRepository, IInsurancePolicyService insurancePolicyService) : base(insurancePolicyRepository)
        {
            this._insurancePolicyService = insurancePolicyService;
        }

        [HttpGet("getByUId/{uid}")]
        public async Task<IActionResult> GetByUId(Guid uid)
        {
            try
            {
                var result = await this._insurancePolicyService.GetByUId(uid);
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

        //[HttpGet("getByPolicyUId/{policyUId}")]
        //public async Task<IActionResult> GetByPolicyUId(Guid policyUId)
        //{
        //    var result = await this._insurancePolicyService.GetByPolicyUId(policyUId);
        //    return Ok(result);
        //}

        [HttpGet("getByPatientCaseUIds/{patientCaseUId}")]
        public async Task<IActionResult> GetByPatientCaseUIds(string patientCaseUId)
        {
            try
            {
                var result = await this.Repository.GetByPatientCaseUIds(patientCaseUId);
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

        [HttpGet("getByPatientCaseUId/{patientCaseUId}")]
        public async Task<IActionResult> GetByPatientCaseUId(string patientCaseUId)
        {
            try
            {
                var result = await this._insurancePolicyService.GetByPatientCaseUId(patientCaseUId);
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

        [HttpGet("getPrimaryPolicy/{patientCaseUId}/{fromDate}")]
        public async Task<IActionResult> GetActivePrimaryPolicy(Guid patientCaseUId, DateTime fromDate)
        {
            try
            {
                var result = await this._insurancePolicyService.GetPolicies(patientCaseUId, fromDate);
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

        [HttpGet("getActivePolicies/{patientCaseUId}/{fromDate}")]
        public async Task<IActionResult> GetActivePolicies(Guid patientCaseUId, DateTime fromDate)
        {
            try
            {
                var result = await this._insurancePolicyService.GetActivePolicies(patientCaseUId, fromDate);
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

        [HttpGet("getInsurancePolicy/{billingId}")]
        public async Task<IActionResult> GetInsurancePolicy(string billingId)
        {
            try
            {
                var result = await this.Repository.GetInsurancePolicies(billingId);
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
        public async Task<IActionResult> AddNew([FromBody]InsurancePolicy entity)
        {
            try
            {
                var result = await this._insurancePolicyService.Add(entity);
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

        [HttpPost("AddPolicyFromHL7")]
        public async Task<IActionResult> AddNewFromHL7([FromBody]InsurancePolicy entity)
        {
            try
            {
                var result = await this._insurancePolicyService.Add(entity, true);
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
        public async Task<IActionResult> Delete(Guid policyUId)
        {
            try
            {
                var result = await this._insurancePolicyService.Delete(policyUId);
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

        [HttpPost("VerifyPatientEligibility/{patientUId}/{policyUId}/{serviceTypeCode}")]
        public async Task<IActionResult> VerifyPatientEligibility(Guid patientUId, Guid policyUId, string serviceTypeCode)
        {
            try
            {
                var result = await this.Repository.VerifyPatientEligibility(patientUId, policyUId, serviceTypeCode);
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

        [HttpPost("SendInsuranceACKToEMR")]
        public async Task<IActionResult> SendInsuranceACKToEMR()
        {
            try
            {
                var result = await this._insurancePolicyService.SendInsuranceACKToEMR();
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

        [HttpGet("getPolicyEMRExceptionList")]
        public async Task<IActionResult> GetPolicyEMRExceptionList()
        {
            try
            {
                var result = await this.Repository.GetPolicyEMRExceptionList();
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
