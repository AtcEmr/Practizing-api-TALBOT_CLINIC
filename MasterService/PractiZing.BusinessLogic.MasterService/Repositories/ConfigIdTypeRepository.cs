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
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigIdTypeRepository : ModuleBaseRepository<IConfigIdType>, IConfigIdTypeRepository
    {
        public ConfigIdTypeRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser)
                                    : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IConfigIdType>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigIdType>(i => i.Active == true)).OrderBy(i => i.Name);
        }

        public async Task<IConfigIdType> GetById(short id)
        {
            return await this.Connection.SingleAsync<ConfigIdType>(i => i.Id == id);
        }
    }
}
