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
    public class PracticeRepository : ModuleBaseRepository<Practice>, IPracticeRepository
    {
        public PracticeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IPractice> Get(int id)
        {
            return await this.Connection.SingleAsync<Practice>(i => i.Id == id);

        }

        public async Task<IPractice> Get()
        {
            return await this.Connection.SingleAsync<Practice>(i => i.Id == LoggedUser.PracticeId);

        }

        public string GetLoggedUser()
        {
            return LoggedUser.PracticeCode;
        }

        public async Task ThrowPermissionDeniedError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PermissionDenied]));
        }
    }
}
