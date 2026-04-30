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
    public class PatientAlertRepository : ModuleBaseRepository<PatientAlert>, IPatientAlertRepository
    {
        private IPatientRepository _patientRepository;
        public PatientAlertRepository(ValidationErrorCodes validationErrorCodes,
                                     DataBaseContext dataBaseContext,
                                     ILoginUser loginUser,
                                     IPatientRepository patientRepository) :
                                     base(validationErrorCodes, dataBaseContext, loginUser)
        {
            this._patientRepository = patientRepository;
        }

        public async Task<IPatientAlert> AddNew(IPatientAlert entity)
        {
            try
            {
                PatientAlert tEntity = entity as PatientAlert;
                var patientObj = await _patientRepository.GetByUId(tEntity.PatientUId);
                tEntity.PatientId = patientObj.Id;
                var error = await base.ValidateEntityToAdd(tEntity);
                if (error.Count() > 0)
                    await this.ThrowEntityException(error);
                if (entity.IsActive)
                    await DeActivateAll(entity.PatientId);
                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeActivateAll(int patientId)
        {
            var items= await this.Connection.SelectAsync<PatientAlert>(i=>i.PatientId==patientId);
            foreach (var item in items)
            {
                item.IsActive = false;
                await UpdateActive(item);
            }
        }

        public async Task<int> Delete(Guid UId)
        {
            try
            {
                return await this.Connection.DeleteAsync<PatientAlert>(i => i.UId == UId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPatientAlert> Get(Guid UId)
        {
            return await this.Connection.SingleAsync<PatientAlert>(i => i.UId == UId);
        }

        public async Task<IEnumerable<IPatientAlert>> Get()
        {
            return await this.Connection.SelectAsync<PatientAlert>();
        }

        public async Task<IPatientAlert> GetActiveAlert(Guid patientUId)
        {
            var patientData = await this._patientRepository.Get(patientUId);
            return await this.Connection.SingleAsync<PatientAlert>(i=>i.IsActive==true && i.PatientId== patientData.Id);
        }

        public async Task<IEnumerable<IPatientAlert>> GetByPatientUId(Guid patientUId)
        {
            var patientData = await this._patientRepository.Get(patientUId);
            return (await this.Connection.SelectAsync<PatientAlert>(i => i.PatientId == patientData.Id)).OrderByDescending(i=>i.CreatedDate);
        }

        public async Task<int> Update(IPatientAlert entity)
        {
            try
            {
                PatientAlert tEntity = entity as PatientAlert;

                var error = await base.ValidateEntityToUpdate(tEntity);
                if (error.Count() > 0)
                    await this.ThrowEntityException(error);

                var updateOnlyFields = this.Connection.From<PatientAlert>()
                                      .Update(i => new
                                      {
                                          i.AlertText,
                                          i.IsActive,
                                          i.ModifiedBy,
                                          i.ModifiedDate
                                      })
                                      .Where(i => i.UId == tEntity.UId);
                if(entity.IsActive)
                await DeActivateAll(entity.PatientId);

                var result = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateActive(IPatientAlert entity)
        {
            try
            {
                PatientAlert tEntity = entity as PatientAlert;

                var error = await base.ValidateEntityToUpdate(tEntity);
                if (error.Count() > 0)
                    await this.ThrowEntityException(error);

                var updateOnlyFields = this.Connection.From<PatientAlert>()
                                      .Update(i => new
                                      {                                          
                                          i.IsActive,
                                          i.ModifiedBy,
                                          i.ModifiedDate
                                      })
                                      .Where(i => i.UId == tEntity.UId);

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
