using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class EDIEligibilityLogRepository : ModuleBaseRepository<EDIEligibilityLog>, IEDIEligibilityLogRepository
    {

        public EDIEligibilityLogRepository(ValidationErrorCodes errorCodes,
                                          DataBaseContext dbContext,
                                          ILoginUser loggedUser) : base(errorCodes, dbContext, loggedUser)
        {
        }
        

        public async Task<IEDIEligibilityLog> AddNew(IEDIEligibilityLog entity)
        {
            try
            {
                EDIEligibilityLog tEntity = entity as EDIEligibilityLog;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                await this.Delete(tEntity.PatientEligibilityId);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int patientEligibilityId)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<EDIEligibilityLog>(i => i.PatientEligibilityId == patientEligibilityId);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
