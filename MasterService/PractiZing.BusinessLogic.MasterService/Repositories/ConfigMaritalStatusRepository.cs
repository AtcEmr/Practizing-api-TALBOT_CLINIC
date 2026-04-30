using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigMaritalStatusRepository : ModuleBaseRepository<ConfigMaritalStatus>, IConfigMaritalStatusRepository
    {
        public ConfigMaritalStatusRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigMaritalStatus> Get(byte id)
        {
            return await this.Connection.SingleAsync<ConfigMaritalStatus>(i => i.Id == id);
        }

        public async Task<IEnumerable<IConfigMaritalStatus>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigMaritalStatus>(i => i.IsActive == true)).OrderBy(i => i.Description);
        }
    }
}
