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
    public class DepositTypeRepository : ModuleBaseRepository<DepositType>, IDepositTypeRepository
    {

        public DepositTypeRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser
                                     ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IDepositType>> GetAll()
        {
            return (await this.Connection.SelectAsync<DepositType>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.Description);
        }

        public async Task<IEnumerable<IDepositType>> GetByUId(IEnumerable<Guid> uids)
        {
            return await this.Connection.SelectAsync<DepositType>(i => uids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IDepositType> GetByUId(Guid uid)
        {
            return await this.Connection.SingleAsync<DepositType>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
        }
    }
}
