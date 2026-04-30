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
    public class DailyQueueRepository : ModuleBaseRepository<DailyQueue>, IDailyQueueRepository
    {
        private IDailyQueueRepository _dailyQueueRepository;
        public DailyQueueRepository(ValidationErrorCodes validationErrorCodes,
                                     DataBaseContext dataBaseContext,
                                     ILoginUser loginUser,
                                     IDailyQueueRepository dailyQueueRepository) :
                                     base(validationErrorCodes, dataBaseContext, loginUser)
        {
            this._dailyQueueRepository = dailyQueueRepository;
        }

        public async Task<IDailyQueue> AddNew(IDailyQueue entity)
        {
            try
            {
                DailyQueue tEntity = entity as DailyQueue;

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
