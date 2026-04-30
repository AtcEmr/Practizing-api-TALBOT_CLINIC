using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface IInsuranceCompanyService
    {
        Task<int> AddOrUpdate(IEnumerable<IInsuranceCompany> entities);
        Task<IEnumerable<IConfigInsuranceCompanyType>> Get(string typeName);
        Task<int> Delete(Guid uid);
    }
}
