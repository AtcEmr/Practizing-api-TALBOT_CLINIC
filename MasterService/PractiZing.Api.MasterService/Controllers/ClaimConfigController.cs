using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ClaimConfigController : SecuredRepositoryController<IClaimConfigRepository>
    {
        private IAppSettingService _appSettingService;
        public ClaimConfigController(IClaimConfigRepository repository, IAppSettingService appSettingService) : base(repository)
        {
            this._appSettingService = appSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string insuranceCompanyUId)
        {
            try
            {
                var result = await this.Repository.Get(null, insuranceCompanyUId, null);
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

        [HttpGet("getDefaultSetting")]
        public async Task<IActionResult> GetDefaultSetting()
        {
            try
            {
                var result = await this._appSettingService.GetDefault();
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

        [HttpGet("getClaimConfigForInsuranceCompany")]
        public async Task<IActionResult> GetClaimConfigForInsuranceCompany(string insuranceCompanyUId)
        {
            try
            {
                var result = await this._appSettingService.GetClaimConfigForInsuranceCompany(insuranceCompanyUId);
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

        [HttpGet("getClaimConfigForInsuranceType")]
        public async Task<IActionResult> GetClaimConfigForInsuranceType(int insuranceCompanyTypeId)
        {
            try
            {
                var result = await this._appSettingService.GetClaimConfigForInsuranceType(insuranceCompanyTypeId);
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
