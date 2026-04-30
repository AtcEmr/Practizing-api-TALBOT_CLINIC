using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigSettingGroupRepository : ModuleBaseRepository<ConfigSettingGroup>, IConfigSettingGroupRepository
    {
        public ConfigSettingGroupRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser)
                                            : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IConfigSettingGroup>> GetAll(bool isAppSetting)
        {
            if (isAppSetting)
                return (await this.Connection.SelectAsync<ConfigSettingGroup>()).Where(i => !i.SettingGroupCD.Trim().ToLower().Contains("claim")).OrderBy(i => i.DisplayOrder);
            else
                return (await this.Connection.SelectAsync<ConfigSettingGroup>()).Where(i => i.SettingGroupCD.Trim().ToLower().Contains("claim")).OrderBy(i => i.DisplayOrder);
        }

        public async Task<IEnumerable<IConfigSettingGroup>> GetClaimDefaultSetting(Guid? externalUID)
        {
            try
            {
                var configGroups = await this.Connection.SelectAsync<ConfigSettingGroup>(i => i.SettingGroupCD.Contains("Claim") && i.IsActive == true);

                if (externalUID == null)
                {
                    foreach (var item in configGroups)
                    {
                        item.ConfigSettings = await this.Connection.SelectAsync<ConfigSetting>(i => i.SettingGroupCD.ToLower() == item.SettingGroupCD.ToLower());
                    }

                    return configGroups;
                }

                var query = this.Connection.From<ConfigSetting>()
                       .LeftJoin<ConfigSetting, AppSetting>((cs, aps) => cs.SettingCD == aps.SettingCD && aps.PracticeId == LoggedUser.PracticeId)
                       .SelectDistinct<ConfigSetting, AppSetting>((cs, aps) => new
                       {
                           cs,
                           SettingValue = aps.SettingValue
                       })
                       .Where<ConfigSetting, AppSetting>((i, aps) => (i.SettingGroupCD.Contains("Claim")) && aps.ExternalTableUId == externalUID && i.IsActive == true)
                       .OrderBy<ConfigSetting>(i => i.DisplayOrder);

                var execute = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ConfigSetting>.MapList(execute);

                result.ToList().ForEach((res) =>
                {
                    if (res.DefaultValues != null && res.DefaultValues != "")
                        res.DefaultValuesList = res.DefaultValues.Split(',').ToArray<string>();

                    if (res.SettingValue != null && res.SettingValue != "")
                        res.SaveSettingValue = res.SettingValue.Split(',').ToArray<string>();

                    res.ExternalGUID = externalUID.Value;
                });

                configGroups.ForEach((res) =>
                {
                    res.ConfigSettings = result.Where(i => i.SettingGroupCD.ToLower() == res.SettingGroupCD.ToLower());
                });

                return configGroups;
            }
            catch
            {
                throw;
            }
        }
    }
}
