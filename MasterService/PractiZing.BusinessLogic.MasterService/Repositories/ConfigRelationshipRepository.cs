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
    public class ConfigRelationshipRepository : ModuleBaseRepository<ConfigRelationship>, IConfigRelationshipRepository
    {
        public ConfigRelationshipRepository(ValidationErrorCodes errorCodes,
                                         DataBaseContext dbContext,
                                         ILoginUser loggedUser
                                         ) : base(errorCodes, dbContext, loggedUser)
        {

        }
        public async Task<IEnumerable<IConfigRelationship>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigRelationship>()).OrderBy(i => i.Description);

        }

        public async Task<IConfigRelationship> GetById(int ID)
        {
            return await this.Connection.SingleAsync<ConfigRelationship>(i => i.ID == ID);


        }
    }
}
