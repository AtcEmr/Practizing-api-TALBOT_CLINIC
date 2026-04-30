using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class AppSettingService : IAppSettingService
    {
        private IAppSettingRepository _appSettingRepository;
        private IConfigSettingRepository _configSettingRepository;
        private IClaimConfigRepository _claimConfigRepository;
        private IConfigSettingGroupRepository _configSettingGroupRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;

        public AppSettingService(IAppSettingRepository appSettingRepository,
                                 IConfigSettingRepository configSettingRepository,
                                 IClaimConfigRepository claimConfigRepository,
                                 IConfigSettingGroupRepository configSettingGroupRepository,
                                 IInsuranceCompanyRepository insuranceCompanyRepository)
        {
            this._appSettingRepository = appSettingRepository;
            this._configSettingRepository = configSettingRepository;
            this._claimConfigRepository = claimConfigRepository;
            this._configSettingGroupRepository = configSettingGroupRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
        }

        public async Task AddUpdate(IEnumerable<IConfigSettingGroup> entities, bool isAppSetting)
        {
            try
            {
                List<IConfigSetting> listConfig = new List<IConfigSetting>();
                foreach (var entity in entities)
                {
                    listConfig.AddRange(entity.ConfigSettings);
                }

                await this.AddUpdateConfigSetting(listConfig, isAppSetting);
            }
            catch
            {
                throw;
            }
        }

        private async Task AddUpdateConfigSetting(IEnumerable<IConfigSetting> configSettings, bool isAppSetting)
        {
            foreach (var entity in configSettings)
            {
                Guid? externalUID = isAppSetting ? (Guid?)null : entity.ExternalGUID;

                var getAppSetting = await this._appSettingRepository.Get(entity.SettingCD, externalUID);
                if (getAppSetting != null)
                {
                    getAppSetting.SettingValue = this.CreateSettingValues(getAppSetting.SettingValue, entity.SettingValue);
                    await this._appSettingRepository.Update(getAppSetting);
                }
                else
                {
                    var appSetting = await this.CreateObject(entity);
                    await this._appSettingRepository.AddNew(appSetting);
                }
            }
        }

        private string CreateSettingValues(string settingValues, string entitySettingValues)
        {

            settingValues = entitySettingValues == null ? settingValues.Trim() :
                                         entitySettingValues.Split('-').Count() == 0 ? entitySettingValues.Trim() : entitySettingValues.Split('-')[0].Trim();

            return settingValues;
        }

        //private async Task AddClaimUpdate(IEnumerable<IConfigSetting> entities)
        //{
        //    try
        //    {
        //        foreach (var entity in entities)
        //        {
        //            var getAppSetting = await this._appSettingRepository.Get(entity.SettingCD, entity.ExternalGUID);
        //            if (getAppSetting != null)
        //            {
        //                getAppSetting.SettingValue = entity.SettingValue == null ? getAppSetting.SettingValue.Trim() :
        //                                             entity.SettingValue.Split('-').Count() == 0 ? entity.SettingValue.Trim() : entity.SettingValue.Split('-')[0].Trim();

        //                await this._appSettingRepository.Update(getAppSetting);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task<IEnumerable<IConfigSettingGroup>> GetDefault()
        {
            var externalId = await this._claimConfigRepository.GetDefaultClaim();
            return await this._configSettingGroupRepository.GetClaimDefaultSetting(externalId.UId);
        }

        public async Task<IEnumerable<IConfigSettingGroup>> GetClaimConfigForInsuranceType(int companyTypeId)
        {
            var externalId = await this._claimConfigRepository.GetClaimConfigForCompanyType(companyTypeId);

            return await this._configSettingGroupRepository.GetClaimDefaultSetting(externalId.UId);
        }

        public async Task<IEnumerable<IConfigSettingGroup>> GetClaimConfigForInsuranceCompany(string companyUId)
        {
            var company = await this._insuranceCompanyRepository.GetByUId(Guid.Parse(companyUId));
            var companyId = company == null ? 0 : company.Id;

            var externalId = await this._claimConfigRepository.GetClaimConfigForCompany(companyId);

            return await this._configSettingGroupRepository.GetClaimDefaultSetting(externalId.UId);
        }

        public async Task<int> Delete(Guid? insuranceCompanyId)
        {
            var insuranceCompany = await this._insuranceCompanyRepository.GetByUId(insuranceCompanyId);
            var claimConfig = await this._claimConfigRepository.GetCompany(insuranceCompany.Id);

            await this._appSettingRepository.Delete(claimConfig.UId);

            await this._claimConfigRepository.Delete(claimConfig.UId);


            return 1;
        }

        public async Task<int> DeleteBatch(int? insuranceTypeId, string insuranceCompanyIds)
        {
            if (insuranceCompanyIds != null && insuranceCompanyIds != "null")
            {
                var companyIds = Array.ConvertAll<string, int>(insuranceCompanyIds.Split(','), Convert.ToInt32);
                var company = await this._claimConfigRepository.Get(companyIds);

                foreach (var item in company)
                {
                    await this._appSettingRepository.Delete(item.UId);
                    await this._claimConfigRepository.Delete(item.UId);

                }
            }


            return 1;
        }

        public async Task<IEnumerable<IConfigSettingGroup>> Get(bool isAppSetting)
        {
            var getGroups = await this._configSettingGroupRepository.GetAll(isAppSetting);
            foreach (var item in getGroups)
            {
                item.ConfigSettings = await this._configSettingRepository.Get(item.SettingGroupCD);
            }

            return getGroups;
        }

        private async Task<IAppSetting> CreateObject(IConfigSetting entity)
        {
            AppSetting appSetting = new AppSetting();
            appSetting.SettingCD = entity.SettingCD;
            appSetting.SettingValue = entity.SettingValue;
            appSetting.ExternalTableUId = null;

            return appSetting;
        }
    }
}
