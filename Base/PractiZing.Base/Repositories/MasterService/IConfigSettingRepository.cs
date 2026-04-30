using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigSettingRepository : IBaseRepository
    {
        Task<IConfigSetting> AddNew(IConfigSetting entity);
        Task<int> Update(IConfigSetting entity);
        Task<IEnumerable<IConfigSetting>> Get(string settingGroupCD);
        Task<IEnumerable<IConfigSetting>> Get();
        Task<IEnumerable<IConfigSetting>> GetClaimDefaultSetting(Guid? externalUID);
        Task<IConfigSetting> GetBySettingCD(string settingCD);
        Task<IConfigSetting> GetBySettingCDAndSettingGroupCD(string settingCD, string settingGroupCD);
    }
}
