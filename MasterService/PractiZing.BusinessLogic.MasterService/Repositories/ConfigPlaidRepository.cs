using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigPlaidRepository : ModuleBaseRepository<ConfigPlaid>, IConfigPlaidRepository
    {
        public ConfigPlaidRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigPlaid> Get()
        {
            return await this.Connection.SingleAsync<ConfigPlaid>(i => i.PracticeId == LoggedUser.PracticeId);
        }

        
    }
}
