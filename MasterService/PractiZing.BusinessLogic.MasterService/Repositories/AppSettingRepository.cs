using Microsoft.Extensions.Logging;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class AppSettingRepository : ModuleBaseRepository<AppSetting>, IAppSettingRepository
    {
        private ILogger _logger;
        public AppSettingRepository(ValidationErrorCodes errorCodes,
                                    DataBaseContext dbContext,
                                    ILoginUser loggedUser,
                                    ILoggerFactory loggerFactory)
                                    : base(errorCodes, dbContext, loggedUser)
        {
            _logger = loggerFactory.CreateLogger<AppSettingRepository>();
        }

        public async Task<IAppSetting> GetClaimFormType()
        {
            return await this.Connection.SingleAsync<AppSetting>(i => i.SettingCD == "ClaimFormType" && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IAppSetting> Get(string settingCD, Guid? externalUId)
        {
            return await this.Connection.SingleAsync<AppSetting>(i => i.PracticeId == LoggedUser.PracticeId && i.SettingCD.ToLower().Contains(settingCD) && i.ExternalTableUId == externalUId);
        }

        public async Task<IEnumerable<IAppSetting>> GetByExternalId(Guid externalTableId)
        {
            try
            {
                var query = this.Connection.From<AppSetting>()
                        .Join<AppSetting, ConfigSetting>((a, c) => a.SettingCD == c.SettingCD && c.SettingGroupCD.ToLower().Contains("claim"))
                        .Select<AppSetting, ConfigSetting>((i, j) => new
                        {
                            i,
                            FormControlCD = j.FormControlCD
                        })
                        .Where<AppSetting, ConfigSetting>((i, j) => i.PracticeId == LoggedUser.PracticeId
                                                && i.ExternalTableUId == externalTableId && j.SettingGroupCD.ToLower().Contains("claim"));


                var queryResult = await this.Connection.SelectAsync<dynamic>(query);

                return (Mapper<AppSetting>.MapList(queryResult).OrderBy(i => i.SettingCD));
            }
            catch
            {
                throw;
            }
        }

        public async Task<IHL7Config> GetHL7Config(int practiceCentralId)
        {
            try
            {
                _logger.LogInformation($"{this.Connection.ToString()} connection");
                _logger.LogInformation($"{this.Connection.ConnectionString} connection string");


                var query = this.Connection.From<AppSetting>()
                        .Join<AppSetting, ConfigSetting>((a, c) => a.SettingCD == c.SettingCD)
                        .Join<AppSetting, Practice>((k, l) => k.PracticeId == l.Id)
                        .Select<AppSetting>((i) => new
                        {
                            i
                        }).Where<AppSetting, ConfigSetting, Practice>((i, c, p) => i.IsActive == true &&
                        //(c.SettingGroupCD.Contains("HL7 Service Configuration") ||
                        //c.SettingGroupCD.Contains("Services Authentication")) && 
                        p.PracticeCentralId == practiceCentralId);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);

                _logger.LogInformation($"{queryResult.Count().ToString()} appsetting1");
                var result = (Mapper<AppSetting>.MapList(queryResult));
                _logger.LogInformation($"{result.Count().ToString()} appsetting2");
                HL7Config hL7Config = new HL7Config();
                if (result.Count() > 0)
                {
                    hL7Config.UserName = result.Where(i => i.SettingCD == "NativeServiceUserName").FirstOrDefault() == null ? string.Empty : result.Where(i => i.SettingCD == "NativeServiceUserName").FirstOrDefault().SettingValue;
                    _logger.LogInformation($"{result.Count().ToString()} appsetting3");
                    hL7Config.Password = result.Where(i => i.SettingCD == "NativeServicePassword").FirstOrDefault() == null ? string.Empty : result.Where(i => i.SettingCD == "NativeServicePassword").FirstOrDefault().SettingValue;
                    _logger.LogInformation($"{result.Count().ToString()} appsetting4");
                    hL7Config.PracticeId = result.FirstOrDefault() == null ? 0 : result.FirstOrDefault().PracticeId;
                    _logger.LogInformation($"{result.Count().ToString()} appsetting5");
                    hL7Config.InputFolder = result.Where(i => i.SettingCD == "HL7InputFolderPath").FirstOrDefault() == null ? string.Empty : result.Where(i => i.SettingCD == "HL7InputFolderPath").FirstOrDefault().SettingValue;
                    _logger.LogInformation($"{result.Count().ToString()} appsetting6");
                    hL7Config.ProcessedFolder = result.Where(i => i.SettingCD == "HL7ProcessedFolderPath").FirstOrDefault() == null ? string.Empty : result.Where(i => i.SettingCD == "HL7ProcessedFolderPath").FirstOrDefault().SettingValue;
                    _logger.LogInformation($"{result.Count().ToString()} appsetting7");
                    hL7Config.ErrorFolder = result.Where(i => i.SettingCD == "HL7ErrorFolderPath").FirstOrDefault() == null ? string.Empty : result.Where(i => i.SettingCD == "HL7ErrorFolderPath").FirstOrDefault().SettingValue;
                    _logger.LogInformation($"{result.Count().ToString()} appsetting8");
                }
                return hL7Config;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw;
            }
        }

        public async Task<IAppSetting> GetAppSettingClaimType()
        {
            try
            {
                var query = this.Connection.From<AppSetting>()
                        .Join<AppSetting, ConfigSetting>((a, c) => a.SettingCD == c.SettingCD)
                        .Select<AppSetting, ConfigSetting>((i, j) => new
                        {
                            i
                        })
                        .Where<AppSetting, ConfigSetting>((i, j) => i.PracticeId == LoggedUser.PracticeId &&
                                                 j.SettingGroupCD == "GLOBAL.CLAIMCONFIGURATION");

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<AppSetting>.Map(queryResult);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IAppSetting> GetAppSettingEMCodes()
        {
            try
            {
                var query = this.Connection.From<AppSetting>()
                        .Join<AppSetting, ConfigSetting>((a, c) => a.SettingCD == c.SettingCD)
                        .Select<AppSetting, ConfigSetting>((i, j) => new
                        {
                            i
                        })
                        .Where<AppSetting, ConfigSetting>((i, j) => i.PracticeId == LoggedUser.PracticeId &&
                                                 j.SettingCD == "EMCodes");

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<AppSetting>.Map(queryResult);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IAppSetting>> GetAppSettingPracticeConfig()
        {
            try
            {
                var query = this.Connection.From<AppSetting>()
                        .Join<AppSetting, ConfigSetting>((a, c) => a.SettingCD == c.SettingCD)
                        .Select<AppSetting, ConfigSetting>((i, j) => new
                        {
                            i
                        })
                        .Where<AppSetting, ConfigSetting>((i, j) => i.PracticeId == LoggedUser.PracticeId &&
                                                 j.SettingGroupCD == "PRACTICE GENERAL CONFIGURATION");

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<AppSetting>.MapList(queryResult);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IAppSetting> AddNew(IAppSetting entity)
        {
            try
            {
                AppSetting tEntity = entity as AppSetting;
                tEntity.PracticeId = LoggedUser.PracticeId;
                tEntity.IsActive = true;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> AddUpdate(IEnumerable<IAppSetting> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    var getAppSetting = await this.Connection.SingleAsync<AppSetting>(i => i.PracticeId == LoggedUser.PracticeId && i.SettingCD == entity.SettingCD);
                    if (getAppSetting != null)
                    {
                        getAppSetting.SettingValue = entity.SettingValue;
                        await this.Update(getAppSetting);
                    }
                    else
                        await this.AddNew(entity);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddAllNewForClaimConfigSetting(IEnumerable<IAppSetting> entities)
        {
            try
            {

                foreach (var entity in entities)
                {
                    var getAppSetting = await this.Connection.SingleAsync<AppSetting>(i => i.PracticeId == LoggedUser.PracticeId && i.SettingCD == entity.SettingCD && i.IsActive == true && i.ExternalTableUId == entity.ExternalTableUId);
                    if (getAppSetting != null)
                    {
                        getAppSetting.SettingValue = entity.SettingValue;
                        await this.Update(getAppSetting);
                    }
                    else
                        await this.AddNew(entity);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddNewForClaimConfigSetting(IEnumerable<IAppSetting> entities)
        {
            try
            {
                var AddNewrow = entities.Where(i => i.Id == 0);
                foreach (var item in AddNewrow)
                    await this.AddNew(item);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IAppSetting entity)
        {
            try
            {
                AppSetting tEntity = entity as AppSetting;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<AppSetting>()
                                           .Update(x => new
                                           {
                                               x
                                           })
                                           .Where(i => i.PracticeId == LoggedUser.PracticeId && i.Id == entity.Id);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid Id)
        {
            try
            {
                return await this.Connection.DeleteAsync<AppSetting>(i => i.ExternalTableUId == Id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IAppSetting>> GetAppERAConfig()
        {
            try
            {
                var query = this.Connection
                                .From<AppSetting>()
                                .Join<AppSetting, ConfigSetting>((a, p) => a.SettingCD == p.SettingCD)
                                .Select<AppSetting, ConfigSetting>((a, p) => new
                                {
                                    a
                                })
                                .Where<AppSetting, ConfigSetting>
                                ((a, p) => a.IsActive && a.PracticeId == LoggedUser.PracticeId &&
                                                 p.SettingGroupCD == "ERA_Service_Configuration");

                var dynamics = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<AppSetting>.MapList(dynamics);
                return result;

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IAppSetting>> GetAppSettingServicesAuthenticationConfig()
        {
            try
            {
                var query = this.Connection.From<AppSetting>()
                        .Join<AppSetting, ConfigSetting>((a, c) => a.SettingCD == c.SettingCD)
                        .Select<AppSetting, ConfigSetting>((i, j) => new
                        {
                            i
                        })
                        .Where<AppSetting, ConfigSetting>((i, j) => i.PracticeId == LoggedUser.PracticeId &&
                                                 j.SettingGroupCD == "Services Authentication");

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<AppSetting>.MapList(queryResult);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IAppSetting> Get277FilePath()
        {
            return await this.Connection.SingleAsync<AppSetting>(i => i.SettingCD == "277FolderLocation" && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IAppSetting> Get824FilePath()
        {
            return await this.Connection.SingleAsync<AppSetting>(i => i.SettingCD == "824Configuration" && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IAppSetting> Get270FilePath()
        {
            return await this.Connection.SingleAsync<AppSetting>(i => i.SettingCD == "270Configuration" && i.PracticeId == LoggedUser.PracticeId);
        }
    }
}
