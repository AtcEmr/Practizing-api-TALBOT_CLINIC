using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.Base.Service.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class InsuranceCompanyController : SecuredRepositoryController<IInsuranceCompanyRepository>
    {
        private ILogger _logger;

        private IInsuranceCompanyService _insuranceCompanyService;
        private IInsurancePolicyService _insurancePolicyService;
        public InsuranceCompanyController(IInsuranceCompanyRepository insuranceCompanyRepository,
                                          IInsuranceCompanyService insuranceCompanyService,
                                          IInsurancePolicyService insurancePolicyService,
                                          ILoggerFactory loggerFactory) : base(insuranceCompanyRepository)
        {
            this._insuranceCompanyService = insuranceCompanyService;
            _insurancePolicyService = insurancePolicyService;
            _logger = loggerFactory.CreateLogger<InsuranceCompanyController>();

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll(string companyName)
        {
            var result = await this.Repository.GetAll(companyName);
            return Ok(result);
        }

        [HttpGet("getForDDO")]
        public async Task<IActionResult> GetForDDO()
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

        [HttpGet("getForPatient")]
        public async Task<IActionResult> GetForPatient(string searchKey)
        {
            var result = await this.Repository.GetForPatient(searchKey);
            return Ok(result);
        }

        [HttpGet("getByCodeOrName/{code}/{name}")]
        public async Task<IActionResult> Get(string code, string name)
        {
            try
            {
                _logger.LogInformation($"code- {code}");

                _logger.LogInformation($"name- {name}");

                var result = await this.Repository.GetInsuranceCompany(code, name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message} -- Exception");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]InsuranceCompany entity)
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

        [HttpPost("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody]IEnumerable<InsuranceCompany> entities)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this._insuranceCompanyService.AddOrUpdate(entities);
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
        public async Task<IActionResult> Update([FromBody]InsuranceCompany entity)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid uid)
        {
            try
            {
                var result = await this._insurancePolicyService.DeleteInsuranceCompany(uid);
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
