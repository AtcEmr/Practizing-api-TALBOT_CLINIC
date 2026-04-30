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
    public class ConfigProviderPositionRepository : ModuleBaseRepository<ConfigProviderPosition>, IConfigProviderPositionRepository
    {
        public ConfigProviderPositionRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IConfigProviderPosition> Get(Int16 id)
        {
            return await this.Connection.SingleAsync<ConfigProviderPosition>(i => i.Id == id);
        }

        public async Task<IEnumerable<IConfigProviderPosition>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigProviderPosition>()).OrderBy(i => i.PositionName);
        }
    }
}
