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
    public class ConfigInsuranceCompanyTypeRepository : ModuleBaseRepository<ConfigInsuranceCompanyType>, IConfigInsuranceCompanyTypeRepository
    {
        public ConfigInsuranceCompanyTypeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigInsuranceCompanyType> Get(Int16 id)
        {
            return await this.Connection.SingleAsync<ConfigInsuranceCompanyType>(i => i.Id == id);
        }

        public async Task<IEnumerable<IConfigInsuranceCompanyType>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigInsuranceCompanyType>(i => i.IsActive == true)).OrderBy(i => i.CompanyType);
        }

        public async Task<IEnumerable<IConfigInsuranceCompanyType>> GetAll(string companyTypeName)
        {
            companyTypeName = companyTypeName == null ? "" : companyTypeName;

            var query = this.Connection.From<ConfigInsuranceCompanyType>()
                        .Select<ConfigInsuranceCompanyType>(cict => new
                        {
                            cict
                        })
                        .Where(x => ((companyTypeName == "") || x.CompanyType.Contains(companyTypeName)) && x.IsActive == true);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ConfigInsuranceCompanyType>.MapList(queryResult);
            return result;
        }

        public async Task<IEnumerable<IConfigInsuranceCompanyType>> GetByIds(IEnumerable<Int16> ids)
        {
            try
            {
                return await this.Connection.SelectAsync<ConfigInsuranceCompanyType>(i => ids.Contains(i.Id));
            }
            catch
            {
                throw;
            }
        }
    }
}
