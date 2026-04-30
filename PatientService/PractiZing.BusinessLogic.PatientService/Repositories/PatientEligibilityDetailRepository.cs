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
    public class PatientEligibilityDetailRepository : ModuleBaseRepository<PatientEligibilityDetail>, IPatientEligibilityDetailRepository
    {

        public PatientEligibilityDetailRepository(ValidationErrorCodes errorCodes,
                                          DataBaseContext dbContext,
                                          ILoginUser loggedUser) : base(errorCodes, dbContext, loggedUser)
        {
        }        

        public async Task<IPatientEligibilityDetail> AddNew(IPatientEligibilityDetail entity)
        {
            try
            {
                PatientEligibilityDetail tEntity = entity as PatientEligibilityDetail;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);


                return await base.AddNewAsync(tEntity);

            }
            catch
            {
                throw;
            }
        }
    }
}
