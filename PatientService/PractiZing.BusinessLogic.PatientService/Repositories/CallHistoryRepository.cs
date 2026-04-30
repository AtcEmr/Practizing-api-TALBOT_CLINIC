using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class CallHistoryRepository : ModuleBaseRepository<CallHistory>, ICallHistoryRepository
    {
        private ICallHistoryRepository _callHistoryRepository;
        public CallHistoryRepository(ValidationErrorCodes validationErrorCodes,
                                     DataBaseContext dataBaseContext,
                                     ILoginUser loginUser,
                                     ICallHistoryRepository callHistoryRepository) :
                                     base(validationErrorCodes, dataBaseContext, loginUser)
        {
            this._callHistoryRepository = callHistoryRepository;
        }

        public async Task<ICallHistory> AddNew(ICallHistory entity)
        {
            try
            {
                CallHistory tEntity = entity as CallHistory;

                var error = await base.ValidateEntityToAdd(tEntity);
                if (error.Count() > 0)
                    await this.ThrowEntityException(error);

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

      
    }
}
