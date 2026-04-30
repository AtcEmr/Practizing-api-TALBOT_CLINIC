using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class PatientCaseRepository : ModuleBaseRepository<PatientCase>, IPatientCaseRepository
    {
        IPatientRepository _patientRepository;
        public PatientCaseRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser, IPatientRepository patientRepository)
            : base(errorCodes, dbContext, loggedUser)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IPatientCase> GetById(int caseId)
        {
            return await this.Connection.SingleAsync<PatientCase>(i => i.Id == caseId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IPatientCase>> GetByUIds(IEnumerable<Guid> caseIds)
        {
            return await this.Connection.SelectAsync<PatientCase>(i => caseIds.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IPatientCase> GetByCaseNo(string caseNo)
        {
            return await this.Connection.SingleAsync<PatientCase>(i => i.CaseIdNumber == caseNo && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IPatientCase>> GetPatientCases(Guid uniqueId)
        {
            var query = this.Connection
                                  .From<PatientCase>()
                                  .Join<PatientCase, Patient>((c, p) => c.PatientId == p.Id && p.UId == uniqueId)
                                  .Select<PatientCase>(c => new
                                  {
                                      c
                                  }).Where(i => i.PracticeId == LoggedUser.PracticeId);

            return await this.Connection.QueryAsync<PatientCase, PatientCase>(query, LoggedUser.PracticeId);
        }

        public async Task<IPatientCase> GetByUId(Guid caseUId)
        {
            return await this.Connection.SingleAsync<PatientCase>(i => i.UId == caseUId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IPatientCase> GetPatientCase(int patientCaseId)
        {
            return await this.Connection.SingleAsync<PatientCase>(i => i.Id == patientCaseId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IPatientCase>> GetPatient(List<int> patientId)
        {
            List<long> longs = patientId.ConvertAll(i => (long)i);
            return await this.Connection.SelectAsync<PatientCase>(i => longs.Contains(i.PatientId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IPatientCase>> GetPatient(string patientUIds)
        {
            var patientIds = await this._patientRepository.GetByUId(patientUIds);
            IEnumerable<long> Ids = patientIds.Select(i => (long)i);
            return await this.Connection.SelectAsync<PatientCase>(i => Ids.Contains(i.PatientId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IPatientCase> Get(int patientId)
        {
            return await this.Connection.SingleAsync<PatientCase>(i => i.PatientId == patientId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IPatientCase>> GetPatients(int patientId)
        {
            return await this.Connection.SelectAsync<PatientCase>(i => i.PatientId == patientId && i.PracticeId == LoggedUser.PracticeId);
        }


        /// <summary>
        /// add new case for patient
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IPatientCase> AddNew(IPatientCase entity)
        {
            try
            {
                PatientCase tEntity = entity as PatientCase;

                var patientCase = await this.CheckPatientCaseExist(tEntity.CaseIdNumber);
                if (patientCase != null)
                {
                    tEntity.Id = patientCase.Id;
                    tEntity.UId = patientCase.UId;
                    await this.UpdateEntity(tEntity);
                    return tEntity;
                }
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

        public async Task<IEnumerable<IPatientCase>> AddNew(IEnumerable<IPatientCase> entities, long patientId)
        {
            try
            {
                int count = 1;
                List<IPatientCase> patientCases = new List<IPatientCase>();

                foreach (var item in entities)
                {
                    item.PatientId = patientId;
                    item.CaseIdNumber = Convert.ToString(patientId * 100 + count);

                    IPatientCase patientCase = await this.AddNew(item);
                    patientCases.Add(patientCase);
                    count++;
                }
                return patientCases;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateEntity(IEnumerable<IPatientCase> entities, long patientId)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.PatientId = patientId;
                    await this.UpdateEntity(item);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateEntity(IPatientCase entity)
        {
            try
            {
                PatientCase tEntity = entity as PatientCase;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                         .From<PatientCase>()
                                         .Update(x => new
                                         {
                                             x.CaseIdNumber,
                                             x.PatientId,
                                             x.CaseTypeId,
                                             x.ProviderId,
                                             x.FacilityId
                                         })
                                         .Where(i => i.UId == tEntity.UId && i.PatientId == tEntity.PatientId
                                                               && i.PracticeId == LoggedUser.PracticeId);
                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCase(int patientId)
        {
            try
            {
                await this.Connection.DeleteAsync<PatientCase>(i => i.PatientId == patientId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        private async Task<IPatientCase> CheckPatientCaseExist(string caseIdNumber)
        {
            return await this.Connection.SingleAsync<PatientCase>(i => i.CaseIdNumber == caseIdNumber && i.PracticeId == LoggedUser.PracticeId);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(PatientCase tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var result = await this.Connection.SelectAsync<PatientCase>(i => (i.CaseIdNumber.ToLower().Trim() == tEntity.CaseIdNumber.ToLower().Trim()
                                                                           && i.PracticeId == LoggedUser.PracticeId));

            if (result.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CaseIdNumberAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(PatientCase tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var result = await this.Connection.SelectAsync<PatientCase>(i => (i.CaseIdNumber.ToLower().Trim() == tEntity.CaseIdNumber.ToLower().Trim()
                                                                           && i.Id != tEntity.Id
                                                                           && i.PracticeId == LoggedUser.PracticeId));

            if (result.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CaseIdNumberAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }
    }
}
