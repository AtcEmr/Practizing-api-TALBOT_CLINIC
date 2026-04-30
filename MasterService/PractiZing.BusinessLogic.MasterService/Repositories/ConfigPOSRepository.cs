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
    public class ConfigPOSRepository : ModuleBaseRepository<ConfigPOS>, IConfigPOSRepository
    {
        public ConfigPOSRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IConfigPOS> Get(string code)
        {
            return await this.Connection.SingleAsync<ConfigPOS>(i => i.Code == code);
        }

        public async Task<IEnumerable<IConfigPOS>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigPOS>()).OrderBy(i => i.Code);
        }
    }
}
