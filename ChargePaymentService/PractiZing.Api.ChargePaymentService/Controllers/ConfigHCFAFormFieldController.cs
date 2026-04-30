using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Objects;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigHCFAFormFieldController : SecuredRepositoryController<IConfigHCFAFormFieldRepository>
    {

        public ConfigHCFAFormFieldController(IConfigHCFAFormFieldRepository ConfigHCFAFormFieldRepository) : base(ConfigHCFAFormFieldRepository)
        {
        }

        [HttpGet("get/{insuranceCompanyUId}")]
        public async Task<IActionResult> Get(string insuranceCompanyUId)
        {
            try
            {
                var result = await this.Repository.Get(insuranceCompanyUId);
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

        [HttpGet("getByInsuranceCompanyUId/{insuranceCompanyUId}")]
        public async Task<IActionResult> GetByInsuranceCompanyUId(string insuranceCompanyUId)
        {
            try
            {
                var result = await this.Repository.GetByInsuranceCompanyUId(insuranceCompanyUId);
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

        [HttpGet("GetAllByInsuranceCompanyUId/{insuranceCompanyUId}/{insuranceCompanyTypeId}")]
        public async Task<IActionResult> GetAllByInsuranceCompanyUId(string insuranceCompanyUId, int insuranceCompanyTypeId)
        {
            try
            {
                var result = await this.Repository.GetAllByInsuranceCompanyUId(0, insuranceCompanyTypeId, insuranceCompanyUId, false);
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
        public async Task<IActionResult> AddNew([FromBody]ConfigHCFAFormField entity)
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
        public async Task<IActionResult> Update([FromBody]ConfigHCFAFormField entity)
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
    }
}