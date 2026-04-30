using Microsoft.AspNetCore.Mvc;
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
    public class ConfigSettingController : SecuredRepositoryController<IConfigSettingRepository>
    {
        private IAppSettingService _appSettingService;

        public ConfigSettingController(IConfigSettingRepository repository, IAppSettingService appSettingService)
                                     : base(repository)
        {
            this._appSettingService = appSettingService;
        }

        [HttpGet("Get/{settingGroupCD}")]
        public async Task<IActionResult> Get(string settingGroupCD)
        {
            var result = await this.Repository.Get(settingGroupCD);
            return Ok(result);
        }

        [HttpGet("getBySettingCD/{settingCD}")]
        public async Task<IActionResult> GetBySettingCD(string settingCD)
        {
            var result = await this.Repository.GetBySettingCD(settingCD);
            return Ok(result);
        }

        [HttpPost("AddUpdate")]
        public async Task<IActionResult> AddUpdate([FromBody]IEnumerable<ConfigSettingGroup> entities, bool isAppSetting)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                await this._appSettingService.AddUpdate(entities, isAppSetting);
                return Ok(1);
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
