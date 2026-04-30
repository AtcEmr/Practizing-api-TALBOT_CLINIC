using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigSettingGroupRepository
    {
        Task<IEnumerable<IConfigSettingGroup>> GetAll(bool isAppSetting);
        Task<IEnumerable<IConfigSettingGroup>> GetClaimDefaultSetting(Guid? externalUID);
    }
}
