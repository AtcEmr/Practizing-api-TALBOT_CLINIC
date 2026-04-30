using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigSettingGroupController : SecuredRepositoryController<IConfigSettingGroupRepository>
    {
        private IAppSettingService _appSettingService;
        public ConfigSettingGroupController(IConfigSettingGroupRepository repository, IAppSettingService appSettingService) : base(repository)
        {
            this._appSettingService = appSettingService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(bool isAppSetting)
        {
            var result = await this._appSettingService.Get(isAppSetting);
            return Ok(result);
        }
    }
}
