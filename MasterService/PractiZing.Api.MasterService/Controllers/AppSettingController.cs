using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class AppSettingController : SecuredRepositoryController<IAppSettingRepository>
    {
        private IAppSettingService _appSettingService;
        private ILogger _logger;

        public AppSettingController(IAppSettingRepository repository, IAppSettingService appSettingService,
            ILoggerFactory loggerFactory) : base(repository)
        {
            this._appSettingService = appSettingService;
            _logger = loggerFactory.CreateLogger<AppSettingController>();

        }

        [HttpGet("GetClaimFormType")]
        public async Task<IActionResult> GetClaimFormType()
        {
            var result = await this.Repository.GetClaimFormType();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("GetHL7Config/{practiceCentralId}")]
        public async Task<IActionResult> GetHL7Config(int practiceCentralId)
        {
            try
            {
                _logger.LogInformation($"{practiceCentralId} - practice Central Id");
                var result = await this.Repository.GetHL7Config(practiceCentralId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{ex.Message} - exception defined");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]AppSetting entity)
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

        [HttpPost("AddUpdate")]
        public async Task<IActionResult> AddUpdate([FromBody]IEnumerable<AppSetting> entities)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this.Repository.AddUpdate(entities);
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
        public async Task<IActionResult> Update([FromBody]AppSetting entity)
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
        public async Task<IActionResult> Delete(Guid? insuranceCompanyUId)
        {
            try
            {
                var result = await this._appSettingService.Delete(insuranceCompanyUId);
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

        [HttpDelete("DeleteBatch")]
        public async Task<IActionResult> DeleteBatch(int? insuranceTypeId, string insuranceCompanyId)
        {
            try
            {
                var result = await this._appSettingService.DeleteBatch(insuranceTypeId, insuranceCompanyId);
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
