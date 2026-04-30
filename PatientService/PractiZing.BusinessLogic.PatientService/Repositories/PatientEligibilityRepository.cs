using PractiZing.Base.Common;
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
    public class PatientEligibilityRepository : ModuleBaseRepository<PatientEligibility>, IPatientEligibilityRepository
    {

        public PatientEligibilityRepository(ValidationErrorCodes errorCodes,
                                          DataBaseContext dbContext,
                                          ILoginUser loggedUser) : base(errorCodes, dbContext, loggedUser)
        {
        }      

        public async Task<IPatientEligibility> AddNew(IPatientEligibility entity)
        {
            try
            {
                PatientEligibility tEntity = entity as PatientEligibility;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var patientEligibility = this.Connection.SingleAsync<PatientEligibility>(i => i.UId == tEntity.UId);
                if(patientEligibility != null)
                {
                    if(!string.IsNullOrEmpty(tEntity.ErrorMessage) && tEntity.ErrorMessage != "Success")
                    {
                        tEntity.Id = await this.Update(tEntity, true);
                    }
                    else
                    {
                        tEntity.Id = await this.Update(tEntity, false);
                    }
                    return tEntity;
                }
                else
                {
                    return await base.AddNewAsync(tEntity);
                }               
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> Update(IPatientEligibility entity, bool isErrorMessageUpdate)
        {
            try
            {
                PatientEligibility tEntity = entity as PatientEligibility;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                SqlExpression<PatientEligibility> updateOnlyFields = null;
                int patientEligibilityId = 0;

                if (isErrorMessageUpdate)
                {
                    updateOnlyFields = this.Connection
                                               .From<PatientEligibility>()
                                               .Update(x => new
                                               {
                                                   x.ErrorMessage,
                                                   x.ModifiedBy,
                                                   x.ModifiedDate
                                               })
                                               .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                }
                else
                {
                    updateOnlyFields = this.Connection
                                               .From<PatientEligibility>()
                                               .Update(x => new
                                               {
                                                   x.EntryDate,
                                                   x.TRN,
                                                   x.EligibilityDate,
                                                   x.ErrorMessage,
                                                   x.ModifiedBy,
                                                   x.ModifiedDate
                                               })
                                               .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);
                }

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                if (value > 0)
                {
                    var patientEligibility = await this.Connection.SingleAsync<PatientEligibility>(i => i.PatientId == tEntity.PatientId);
                    if(patientEligibility != null)
                    {
                        patientEligibilityId = patientEligibility.Id;
                    }                    
                }
                return patientEligibilityId;
            }
            catch
            {
                throw;
            }
        }

    }
}
