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
    public class ConfigProviderSpecialtyRepository : ModuleBaseRepository<IConfigProviderSpecialty>, IConfigProviderSpecialtyRepository
    {
        public ConfigProviderSpecialtyRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IConfigProviderSpecialty> Get(Int16 id)
        {
            return await this.Connection.SingleAsync<ConfigProviderSpecialty>(i => i.Id == id);
        }

        public async Task<IEnumerable<IConfigProviderSpecialty>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigProviderSpecialty>(i => i.Active == true)).OrderBy(i => i.Description);
        }
    }
}
