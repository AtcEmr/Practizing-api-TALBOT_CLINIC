using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class AttFileTableRepository: ModuleBaseRepository<AttFileTable>, IAttFileTableRepository
    {

        public AttFileTableRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser)
                                      : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IAttFileTable>> GetAll()
        {
            return await this.Connection.SelectAsync<AttFileTable>();
        }

        public async Task<IAttFileTable> GetByName(string name)
        {
            return await this.Connection.SingleAsync<AttFileTable>(i=>i.TableName.ToLower() == name.ToLower());
        }
    }
}

