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
    public class PatientNoteRepository : ModuleBaseRepository<PatientNote>, IPatientNoteRepository
    {
        private IPatientRepository _patientRepository;
        public PatientNoteRepository(ValidationErrorCodes validationErrorCodes,
                                     DataBaseContext dataBaseContext,
                                     ILoginUser loginUser,
                                     IPatientRepository patientRepository) :
                                     base(validationErrorCodes, dataBaseContext, loginUser)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<IPatientNote> AddNew(IPatientNote entity)
        {
            try
            {
                PatientNote tEntity = entity as PatientNote;

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

        public async Task<int> Delete(Guid UId)
        {
            try
            {
                return await this.Connection.DeleteAsync<PatientNote>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPatientNote> Get(Guid UId)
        {
            return await this.Connection.SingleAsync<PatientNote>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IPatientNote>> Get()
        {
            return await this.Connection.SelectAsync<PatientNote>(i => i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IPatientNote>> GetByPatientUId(Guid patientUId)
        {
            var patientData = await this._patientRepository.Get(patientUId);
            return (await this.Connection.SelectAsync<PatientNote>(i => i.PracticeId == LoggedUser.PracticeId && i.PatientId == patientData.Id)).OrderByDescending(i=>i.CreatedDate);
        }

        public async Task<int> Update(IPatientNote entity)
        {
            try
            {
                PatientNote tEntity = entity as PatientNote;

                var error = await base.ValidateEntityToUpdate(tEntity);
                if (error.Count() > 0)
                    await this.ThrowEntityException(error);

                var updateOnlyFields = this.Connection.From<PatientNote>()
                                      .Update(i => new
                                      {
                                          i.Note,
                                          i.ModifiedBy,
                                          i.ModifiedDate
                                      })
                                      .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                var result = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
