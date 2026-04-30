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
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigSettingRepository<ConfigSetting, AppSetting> : ModuleBaseRepository<ConfigSetting>, IConfigSettingRepository
           where ConfigSetting : class, IConfigSetting, new()
           where AppSetting : class, IAppSetting, new()
    {

        public ConfigSettingRepository(ValidationErrorCodes errorCodes,
                                       DataBaseContext dbContext,
                                       ILoginUser loggedUser)
                                       : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigSetting> AddNew(IConfigSetting entity)
        {
            try
            {
                ConfigSetting tEntity = entity as ConfigSetting;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                return await base.AddNewAsync(tEntity);

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IConfigSetting>> Get(string settingGroupCD)
        {
            try
            {
                var query = this.Connection.From<ConfigSetting>()
                        .LeftJoin<ConfigSetting, AppSetting>((cs, aps) => cs.SettingCD == aps.SettingCD && aps.PracticeId == LoggedUser.PracticeId)
                        .SelectDistinct<ConfigSetting, AppSetting>((cs, aps) => new
                        {
                            cs,
                            SettingValue = aps.SettingValue
                        })
                        .Where<ConfigSetting, AppSetting>((cs, aps) => cs.SettingGroupCD == settingGroupCD && cs.IsActive == true)
                        .OrderBy<ConfigSetting>(i => i.DisplayOrder);

                var execute = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ConfigSetting>.MapList(execute);

                result.ToList().ForEach((res) =>
                {
                    if (res.DefaultValues != null && res.DefaultValues != "")
                        res.DefaultValuesList = res.DefaultValues.Split(',').ToArray<string>();

                    if (res.SettingValue != null && res.SettingValue != "")
                        res.SaveSettingValue = res.SettingValue.Split(',').ToArray<string>();
                });
                return result;

            }
            catch
            {
                throw;
            }
        }

        public async Task<IConfigSetting> GetBySettingCD(string settingCD)
        {
            var result = await this.Connection.SingleAsync<ConfigSetting>(i => i.SettingCD == settingCD);
            return result;

        }

        public async Task<IConfigSetting> GetBySettingCDAndSettingGroupCD(string settingCD, string settingGroupCD)
        {
            var result = await this.Connection.SingleAsync<ConfigSetting>(i => i.SettingCD == settingCD && i.SettingGroupCD == settingGroupCD);
            return result;

        }

        public async Task<IEnumerable<IConfigSetting>> Get()
        {
            try
            {
                var query = this.Connection.From<ConfigSetting>()
                        .LeftJoin<ConfigSetting, AppSetting>((cs, aps) => cs.SettingCD == aps.SettingCD && aps.PracticeId == LoggedUser.PracticeId)
                        .Join<AppSetting, ClaimConfig>((ap, cc) => ap.ExternalTableUId == cc.UId)
                        .SelectDistinct<ConfigSetting, AppSetting>((cs, aps) => new
                        {
                            cs,
                            SettingValue = aps.SettingValue
                        })
                        .Where<ConfigSetting, AppSetting>((cs, aps) => cs.SettingGroupCD == "CLAIM CONFIGURATION")
                        .OrderBy<ConfigSetting>(i => i.DisplayOrder);

                var execute = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ConfigSetting>.MapList(execute);

                result.ToList().ForEach((res) =>
                {
                    if (res.DefaultValues != null && res.DefaultValues != "")
                        res.DefaultValuesList = res.DefaultValues.Split(',').ToArray<string>();

                    if (res.SettingValue != null && res.SettingValue != "")
                        res.SaveSettingValue = res.SettingValue.Split(',').ToArray<string>();
                });

                return result;

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IConfigSetting>> GetClaimDefaultSetting(Guid? externalUID)
        {
            try
            {
                if (externalUID == null)
                {
                    return await this.Connection.SelectAsync<ConfigSetting>(i => i.SettingGroupCD.Contains("Claim"));
                }

                var query = this.Connection.From<ConfigSetting>()
                       .LeftJoin<ConfigSetting, AppSetting>((cs, aps) => cs.SettingCD == aps.SettingCD && aps.PracticeId == LoggedUser.PracticeId)
                       .SelectDistinct<ConfigSetting, AppSetting>((cs, aps) => new
                       {
                           cs,
                           SettingValue = aps.SettingValue
                       })
                       .Where<ConfigSetting, AppSetting>((i, aps) => (i.SettingGroupCD.Contains("Claim")) && aps.ExternalTableUId == externalUID)
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
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IConfigSetting entity)
        {
            try
            {
                ConfigSetting tEntity = entity as ConfigSetting;

                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                var updateOnlyFields = this.Connection
                                           .From<ConfigSetting>()
                                           .Update(x => new
                                           {
                                               x
                                           })
                                           .Where<ConfigSetting>(i => i.SettingCD == entity.SettingCD);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }
    }
}
