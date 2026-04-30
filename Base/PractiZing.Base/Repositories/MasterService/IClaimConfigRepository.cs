using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IClaimConfigRepository : IBaseRepository
    {
        Task<IClaimConfig> AddNew(IClaimConfig entity);
        Task<int> Update(IClaimConfig entity);
        Task<int> Delete(Guid Id);
        Task<IClaimConfig> GetById(int Id);

        Task<IConfigHCFAFormField> Get(int? insuranceCompanyTypeId, string insuranceCompanyUId, int? insuranceCompanyId);
        Task<IClaimConfig> GetDefaultClaim();
        Task<IClaimConfig> GetClaimConfigForCompanyType(int insuranceCompanyTypeId);
        Task<IClaimConfig> GetClaimConfigForCompany(int insuranceCompanyId);
        Task<IClaimConfig> Get(Guid guid);
        Task<IClaimConfig> Get(int insuranceCompanyTypeId);
        Task<IClaimConfig> GetCompany(int insuranceCompanyId);
        Task<IEnumerable<IClaimConfig>> Get(IEnumerable<int> insuranceCompanyTypeId);
    }
}
