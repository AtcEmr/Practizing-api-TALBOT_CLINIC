using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigInsuranceCompanyTypeRepository
    {
        Task<IEnumerable<IConfigInsuranceCompanyType>> GetAll();
        Task<IConfigInsuranceCompanyType> Get(Int16 id);
        Task<IEnumerable<IConfigInsuranceCompanyType>> GetByIds(IEnumerable<Int16> id);


        Task<IEnumerable<IConfigInsuranceCompanyType>> GetAll(string companyTypeName);
    }
}
