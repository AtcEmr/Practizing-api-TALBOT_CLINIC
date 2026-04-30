using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ClaimConfigRepository : ModuleBaseRepository<ClaimConfig>, IClaimConfigRepository
    {
        private IAppSettingRepository _appSettingRepository;
        private IConfigSettingRepository _configSettingRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;

        public ClaimConfigRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser,
                                     IAppSettingRepository appSettingRepository,
                                     IConfigSettingRepository configSettingRepository,
                                     IInsuranceCompanyRepository insuranceCompanyRepository
                                     )
                                : base(errorCodes, dbContext, loggedUser)
        {
            this._appSettingRepository = appSettingRepository;
            this._configSettingRepository = configSettingRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
        }

        public async Task<IClaimConfig> GetById(int Id)
        {
            try
            {
                return await base.GetById(Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IConfigHCFAFormField> Get(int? insuranceCompanyTypeId, string insuranceCompanyUId, int? insuranceCompanyId)
        {
            try
            {
                var claimRecord = await this.Connection.SelectAsync<ClaimConfig>(i => i.PracticeId == LoggedUser.PracticeId);
                IClaimConfig result;

                insuranceCompanyId = insuranceCompanyId != null ? insuranceCompanyId : (insuranceCompanyUId == null ? 0 : (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyUId))).Id);

                result = (claimRecord.Where(i => i.InsuranceCompanyId == insuranceCompanyId)).FirstOrDefault();

                if (result == null)
                {
                    if(insuranceCompanyTypeId==0)
                    {
                        insuranceCompanyTypeId = 4;
                    }
                    result = (claimRecord.Where(i => i.InsuranceCompanyTypeId == insuranceCompanyTypeId)).FirstOrDefault();
                    if (result == null)
                        result = (claimRecord.Where(i => i.IsDefault == true)).FirstOrDefault();
                }

                if (result == null)
                    await HCFAConfigDoesnotExit();

                ConfigHCFAFormField configHCFAFormField = new ConfigHCFAFormField();

                var appSetting = await this._appSettingRepository.GetByExternalId(result.UId);
                int count = 0;
                foreach (var value in appSetting)
                {

                    PropertyInfo prop = configHCFAFormField.GetType().GetProperty(value.SettingCD, BindingFlags.Public | BindingFlags.Instance);
                    Type tProp = prop.PropertyType;


                    //Nullable properties have to be treated differently, since we 
                    //  use their underlying property to set the value in the object
                    if (tProp.IsGenericType
                        && tProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        //if it's null, just set the value from the reserved word null, and return
                        if (value.SettingValue == null)
                        {
                            prop.SetValue(configHCFAFormField, null, null);
                        }

                        //Get the underlying type property instead of the nullable generic
                        tProp = new NullableConverter(prop.PropertyType).UnderlyingType;
                    }

                    //use the converter to get the correct value


                    prop.SetValue(configHCFAFormField, Convert.ChangeType(value.SettingValue, tProp), null);
                    count++;
                }

                return configHCFAFormField;
            }
            catch
            {
                throw;
            }

        }

        public async Task<IClaimConfig> AddNew(IClaimConfig entity)
        {
            try
            {
                ClaimConfig tEntity = entity as ClaimConfig;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> Update(IClaimConfig entity)
        {
            try
            {
                ClaimConfig tEntity = entity as ClaimConfig;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection.From<ClaimConfig>()
                                           .Update(x => new
                                           {
                                               x.InsuranceCompanyId,
                                               x.InsuranceCompanyTypeId
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<ClaimConfig>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task HCFAConfigDoesnotExit()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.HCFAConfigDoesNotExist]));
            await this.ThrowEntityException(errors);

        }

        private T? Unbox<T>(object x) where T : struct, IConvertible
        {
            if (x == null) return null;
            return (T)Convert.ChangeType(x, typeof(T));
        }

        public async Task<IClaimConfig> GetDefaultClaim()
        {
            var defaultSetting = await this.Connection.SingleAsync<ClaimConfig>(i => i.IsDefault == true && i.InsuranceCompanyId == null && i.InsuranceCompanyTypeId == null && i.PracticeId == LoggedUser.PracticeId);
            if (defaultSetting == null)
            {
                var defaultClaimConfig = await this.AddNew(await this.CreateObject());
                var configSetting = await this._configSettingRepository.GetClaimDefaultSetting(null);

                var appSettingList = await this.CreateAppList(defaultClaimConfig.UId, configSetting);
                await this._appSettingRepository.AddNewForClaimConfigSetting(appSettingList);

                defaultSetting = defaultClaimConfig as ClaimConfig;
            }

            return defaultSetting;
        }

        public async Task<IClaimConfig> GetClaimConfigForCompanyType(int insuranceCompanyTypeId)
        {
            var result = await this.Connection.SingleAsync<ClaimConfig>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDefault == false && i.InsuranceCompanyTypeId == insuranceCompanyTypeId && i.InsuranceCompanyId == null);

            if (result == null)
            {
                var getNewArray = await this.CreateObject();
                getNewArray.InsuranceCompanyTypeId = Convert.ToInt16(insuranceCompanyTypeId);
                getNewArray.InsuranceCompanyId = null;
                getNewArray.IsDefault = false;
                getNewArray.PracticeId = LoggedUser.PracticeId;

                var defaultClaimConfig = await this.AddNew(getNewArray) as ClaimConfig;

                var isDefaultData = await this.Connection.SingleAsync<ClaimConfig>(i => i.IsDefault == true && i.InsuranceCompanyId == null && i.InsuranceCompanyTypeId == null && i.PracticeId == LoggedUser.PracticeId);
                var appSettingData = await this._appSettingRepository.GetByExternalId(isDefaultData.UId);

                appSettingData.ToList().ForEach((res) =>
                {
                    res.Id = 0;
                    res.ExternalTableUId = defaultClaimConfig.UId;
                    res.IsActive = true;
                });

                await this._appSettingRepository.AddAllNewForClaimConfigSetting(appSettingData);
                result = defaultClaimConfig;
            }

            return result;
        }

        public async Task<IClaimConfig> GetClaimConfigForCompany(int insuranceCompanyId)
        {
            var result = await this.Connection.SingleAsync<ClaimConfig>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDefault == false && i.InsuranceCompanyTypeId == null && i.InsuranceCompanyId == insuranceCompanyId);

            if (result == null)
            {
                var getNewArray = await this.CreateObject();
                getNewArray.InsuranceCompanyId = Convert.ToInt16(insuranceCompanyId);
                getNewArray.InsuranceCompanyTypeId = null;
                getNewArray.IsDefault = false;
                var defaultClaimConfig = await this.AddNew(getNewArray) as ClaimConfig;

                Guid externalUId = new Guid();
                var insuranceCompany = await this.Connection.SingleAsync<InsuranceCompany>(i => i.Id == insuranceCompanyId);
                var insuranceCompanyTypeID = await this.Connection.SingleAsync<ClaimConfig>(i => i.InsuranceCompanyTypeId == insuranceCompany.CompanyTypeId && i.PracticeId == LoggedUser.PracticeId);

                if (insuranceCompanyTypeID == null)
                {
                    var defaultClaimData = await this.Connection.SingleAsync<ClaimConfig>(i => i.IsDefault == true && i.InsuranceCompanyId == null && i.InsuranceCompanyTypeId == null && i.PracticeId == LoggedUser.PracticeId);
                    externalUId = defaultClaimData.UId;
                }
                else
                {
                    externalUId = insuranceCompanyTypeID.UId;
                }

                var appSettingData = await this._appSettingRepository.GetByExternalId(externalUId);

                appSettingData.ToList().ForEach((res) =>
                {
                    res.Id = 0;
                    res.ExternalTableUId = defaultClaimConfig.UId;
                    res.PracticeId = LoggedUser.PracticeId;
                });

                await this._appSettingRepository.AddAllNewForClaimConfigSetting(appSettingData);
                result = defaultClaimConfig;
            }

            return result;
        }

        private async Task<IClaimConfig> CreateObject()
        {
            ClaimConfig claimConfig = new ClaimConfig();
            claimConfig.Id = 0;
            claimConfig.InsuranceCompanyId = null;
            claimConfig.InsuranceCompanyTypeId = null;
            claimConfig.IsDefault = true;
            claimConfig.PracticeId = LoggedUser.PracticeId;

            return claimConfig;
        }

        private async Task<IEnumerable<IAppSetting>> CreateAppList(Guid externalUID, IEnumerable<IConfigSetting> configSettings)
        {
            List<AppSetting> appSettings = new List<AppSetting>();

            foreach (var item in configSettings)
            {
                AppSetting appSetting = new AppSetting();
                appSetting.Id = 0;
                appSetting.ExternalTableUId = externalUID;
                appSetting.SettingCD = item.SettingCD;
                appSetting.SettingValue = item.DefaultValues == null ? "" : item.DefaultValues;

                appSettings.Add(appSetting);
            }

            return appSettings;
        }

        public async Task<IClaimConfig> Get(Guid guid)
        {
            return await this.Connection.SingleAsync<ClaimConfig>(i => i.UId == guid && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IClaimConfig> Get(int insuranceCompanyTypeId)
        {
            return await this.Connection.SingleAsync<ClaimConfig>(i => i.InsuranceCompanyTypeId == insuranceCompanyTypeId && i.PracticeId == LoggedUser.PracticeId && i.IsDefault == false);
        }

        public async Task<IEnumerable<IClaimConfig>> Get(IEnumerable<int> insuranceCompanyTypeId)
        {
            List<IClaimConfig> List = new List<IClaimConfig>();
            foreach (var item in insuranceCompanyTypeId)
            {
                var company = await this.Connection.SingleAsync<ClaimConfig>(i => i.InsuranceCompanyId == item && i.PracticeId == LoggedUser.PracticeId && i.IsDefault == false);
                if (company != null)
                    List.Add(company);
            }

            return List;
        }

        public async Task<IClaimConfig> GetCompany(int insuranceCompanyId)
        {
            return await this.Connection.SingleAsync<ClaimConfig>(i => i.InsuranceCompanyId == insuranceCompanyId && i.PracticeId == LoggedUser.PracticeId && i.IsDefault == false);
        }

    }
}
