using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Common;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class PatientAuthorizationNumberRepository : ModuleBaseRepository<PatientAuthorizationNumber>, IPatientAuthorizationNumberRepository
    {
        public PatientAuthorizationNumberRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IPatientAuthorizationNumber>> GetAuthorization(long insurancePolicyId)
        {
            return await this.Connection.SelectAsync<PatientAuthorizationNumber>(i => i.InsurancePolicyId == insurancePolicyId);

        }

        public async Task<IPatientAuthorizationNumber> Get(int Id)
        {
            return await this.Connection.SingleAsync<PatientAuthorizationNumber>(i => i.Id == Id);
        }

        public async Task<IEnumerable<IPatientAuthorizationNumber>> GetAuthorizationNos(long insurancePolicyId, DateTime fromDate)
        {
            var result = await this.Connection.SelectAsync<PatientAuthorizationNumber>(i => i.InsurancePolicyId == insurancePolicyId
            && i.EffectiveDate <= fromDate && i.ExpirationDate >= fromDate);
            return result;
        }

        public async Task<IPatientAuthorizationNumber> GetByInsurancePolicyId(long insurancePolicyId)
        {
            return await this.Connection.SingleAsync<PatientAuthorizationNumber>(i => i.InsurancePolicyId == insurancePolicyId);
        }

        public async Task<IPatientAuthorizationNumber> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<PatientAuthorizationNumber>(i => i.UId == UId);
        }

        public async Task<IEnumerable<IPatientAuthorizationNumber>> GetAll()
        {
            return await this.Connection.SelectAsync<PatientAuthorizationNumber>();
        }

        public async Task<IPatientAuthorizationNumber> AddNew(IPatientAuthorizationNumber entity)
        {
            try
            {
                PatientAuthorizationNumber tEntity = entity as PatientAuthorizationNumber;

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

        public async Task<IPatientAuthorizationNumber> AddNewFromIntegration(IPatientAuthorizationNumber entity)
        {
            try
            {
                PatientAuthorizationNumber tEntity = entity as PatientAuthorizationNumber;

                var existRecord = await this.GetByAuthNumber(tEntity.AuthorizationNumber, tEntity.InsurancePolicyId);
                if (existRecord != null)
                {
                    existRecord.ExpirationDate = entity.ExpirationDate;
                    existRecord.EffectiveDate = entity.EffectiveDate;
                    await this.Update(existRecord);
                    return existRecord;
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

        private async Task<IPatientAuthorizationNumber> GetByAuthNumber(string authNumber, long policyId)
        {
            return await this.Connection.SingleAsync<PatientAuthorizationNumber>(i => i.AuthorizationNumber == authNumber && i.InsurancePolicyId == policyId);
        }

        public async Task<bool> AddNewEntities(IEnumerable<IPatientAuthorizationNumber> entities)
        {
            try
            {
                foreach (var item in entities)
                    await this.AddNew(item);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateEntities(IEnumerable<IPatientAuthorizationNumber> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    if (item.Id > 0 && !item.isDeleted)
                        await this.Update(item);
                    else if (item.Id == 0 && !item.isDeleted)
                        await this.AddNew(item);
                    else
                        await this.Delete(item.UId.ToString());
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IPatientAuthorizationNumber entity)
        {
            try
            {
                PatientAuthorizationNumber tEntity = entity as PatientAuthorizationNumber;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<PatientAuthorizationNumber>()
                                           .Update(x => new
                                           {
                                               x.AuthorizationNumber,
                                               x.EffectiveDate,
                                               x.ExpirationDate
                                           })
                                           .Where(i => i.UId == entity.UId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(string uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<PatientAuthorizationNumber>(i => i.UId == Guid.Parse(uid));
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteInsurancePolicy(long insurancePolicyId)
        {
            var result = await this.Connection.DeleteAsync<PatientAuthorizationNumber>(i => i.InsurancePolicyId == insurancePolicyId);
            return result;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(PatientAuthorizationNumber tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            CheckIfAuthorizationNumberIsNullOrEmpty(tEntity, ref errors);

            errors = await ExpiryDateAndAuthorizationDuplicacyValidation(tEntity, errors);

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(PatientAuthorizationNumber tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            CheckIfAuthorizationNumberIsNullOrEmpty(tEntity, ref errors);

            errors = await ExpiryDateAndAuthorizationDuplicacyValidation(tEntity, errors);

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private void CheckIfAuthorizationNumberIsNullOrEmpty(PatientAuthorizationNumber tEntity, ref List<IValidationResult> errors)
        {
            if (string.IsNullOrEmpty(tEntity.AuthorizationNumber))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AuthorizationNumberNullOrEmpty]));
        }

        private async Task<List<IValidationResult>> ExpiryDateAndAuthorizationDuplicacyValidation(PatientAuthorizationNumber tEntity, List<IValidationResult> errors)
        {
            List<PatientAuthorizationNumber> patientAuthorizationNumbers = null;
            List<PatientAuthorizationNumber> _oldAuthNum = new List<PatientAuthorizationNumber>();
            List<PatientAuthorizationNumber> _newAuthNum = new List<PatientAuthorizationNumber>();
            patientAuthorizationNumbers = await this.Connection.SelectAsync<PatientAuthorizationNumber>(i => i.InsurancePolicyId == tEntity.InsurancePolicyId);

            if (tEntity.Id > 0 && patientAuthorizationNumbers != null)
            {
                _oldAuthNum = patientAuthorizationNumbers.Where(i => i.Id < tEntity.Id).ToList();
                _newAuthNum = patientAuthorizationNumbers.Where(i => i.Id > tEntity.Id).ToList();
            }

            if (_oldAuthNum.Count() > 0)
            {
                var _maxAuthorizationExpiryDate = _oldAuthNum.Max(i => i.ExpirationDate);
                //if (tEntity.EffectiveDate < _maxAuthorizationExpiryDate)
                //    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AuthorizationEffectiveDateValidation]));
            }

            if (_newAuthNum.Count() > 0)
            {
                var _maxAuthorizationEffectiveDate = _newAuthNum.Max(i => i.EffectiveDate);
                //if (tEntity.ExpirationDate > _maxAuthorizationEffectiveDate)
                //    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AuthorizationEffectiveDateValidation]));
            }

            var result = patientAuthorizationNumbers.Where<PatientAuthorizationNumber>(i => i.AuthorizationNumber.ToLower().Trim() == tEntity.AuthorizationNumber.ToLower().Trim());

            if (tEntity.Id > 0 && result.Count() > 0)
                result = result.Where<PatientAuthorizationNumber>(i => i.Id != tEntity.Id);

            if (result.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AuthorizationNumberAlreadyExists]));

            return errors;
        }
    }
}

