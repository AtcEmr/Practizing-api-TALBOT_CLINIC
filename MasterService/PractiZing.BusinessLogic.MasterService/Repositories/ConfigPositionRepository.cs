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
    public class ConfigPositionRepository : ModuleBaseRepository<ConfigPosition>, IConfigPositionRepository
    {
        public ConfigPositionRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IConfigPosition> Get(Int16 id)
        {
            return await this.Connection.SingleAsync<ConfigPosition>(i => i.Id == id);
        }

        public async Task<IEnumerable<IConfigPosition>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigPosition>(i => i.IsActive == true)).OrderBy(i => i.PositionName);
        }
    }
}
