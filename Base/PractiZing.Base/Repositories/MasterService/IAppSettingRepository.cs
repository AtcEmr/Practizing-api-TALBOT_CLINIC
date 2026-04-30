using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IAppSettingRepository : IBaseRepository
    {
        Task<IAppSetting> GetClaimFormType();
        Task<IAppSetting> AddNew(IAppSetting entity);
        Task<int> Update(IAppSetting entity);
        Task<int> AddUpdate(IEnumerable<IAppSetting> entities);
        Task<IAppSetting> Get(string settingCD, Guid? externalUId);
        Task<IEnumerable<IAppSetting>> GetByExternalId(Guid externalTableId);
        Task<int> AddAllNewForClaimConfigSetting(IEnumerable<IAppSetting> entities);
        Task<int> AddNewForClaimConfigSetting(IEnumerable<IAppSetting> entities);
        Task<int> Delete(Guid Id);
        Task<IAppSetting> GetAppSettingClaimType();
        Task<IEnumerable<IAppSetting>> GetAppSettingPracticeConfig();

        Task<IHL7Config> GetHL7Config(int practiceCentralId);
        Task<IEnumerable<IAppSetting>> GetAppERAConfig();
        Task<IAppSetting> GetAppSettingEMCodes();
        Task<IEnumerable<IAppSetting>> GetAppSettingServicesAuthenticationConfig();
        Task<IAppSetting> Get277FilePath();
        Task<IAppSetting> Get824FilePath();
        Task<IAppSetting> Get270FilePath();
    }
}
