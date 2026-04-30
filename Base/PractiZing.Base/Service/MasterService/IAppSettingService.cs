using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface IAppSettingService
    {
        Task AddUpdate(IEnumerable<IConfigSettingGroup> entities, bool isAppSetting);
        Task<IEnumerable<IConfigSettingGroup>> GetDefault();
        Task<IEnumerable<IConfigSettingGroup>> GetClaimConfigForInsuranceType(int companyTypeId);
        Task<IEnumerable<IConfigSettingGroup>> GetClaimConfigForInsuranceCompany(string companyUId);
        Task<int> Delete(Guid? insuranceCompanyId);
        Task<int> DeleteBatch(int? insuranceTypeId, string insuranceCompanyId);
        Task<IEnumerable<IConfigSettingGroup>> Get(bool isAppSetting);
    }
}
