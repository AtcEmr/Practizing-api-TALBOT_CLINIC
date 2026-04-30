using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
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
    public class ConfigCaseTypeRepository : ModuleBaseRepository<ConfigCaseType>, IConfigCaseTypeRepository
    {
        public ConfigCaseTypeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigCaseType> Get(Int16 id)
        {
            return await base.GetById(id);

        }

        public async Task<IEnumerable<IConfigCaseType>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigCaseType>()).OrderBy(i => i.Name);
        }
    }
}
