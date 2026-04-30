using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigServiceTypeRepository : ModuleBaseRepository<ConfigServiceType>, IConfigServiceTypeRepository
    {
        public ConfigServiceTypeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }

       
        public async Task<IEnumerable<IConfigServiceType>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigServiceType>()).OrderBy(i => i.Code);
        }
    }
}
