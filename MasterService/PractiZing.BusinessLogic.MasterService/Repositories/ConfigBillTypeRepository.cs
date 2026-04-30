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
    public class ConfigBillTypeRepository : ModuleBaseRepository<ConfigBillType>, IConfigBillTypeRepository
    {
        public ConfigBillTypeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
          : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IConfigBillType> Get(Int16 id)
        {
            return await base.GetById(id);
        }

        public async Task<IEnumerable<IConfigBillType>> Get()
        {
            return (await this.Connection.SelectAsync<ConfigBillType>()).OrderBy(i => i.Value);
        }
    }
}
