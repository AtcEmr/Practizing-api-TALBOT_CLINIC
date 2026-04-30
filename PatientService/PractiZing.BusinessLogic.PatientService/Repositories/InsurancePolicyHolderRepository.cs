using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class InsurancePolicyHolderRepository : ModuleBaseRepository<InsurancePolicyHolder>, IInsurancePolicyHolderRepository
    {
        private readonly IPatientRepository _patientRepository;
        public InsurancePolicyHolderRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser, IPatientRepository patientRepository) : base(errorCodes, dbContext, loggedUser)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IInsurancePolicyHolder> GetById(int id)
        {
            return await this.Connection.SingleAsync<InsurancePolicyHolder>(i => i.Id == id);
        }

        public async Task<IInsurancePolicyHolder> GetByUId(Guid uid)
        { 
            try
            {
                var query = this.Connection.From<InsurancePolicyHolder>()
                           .LeftJoin<InsurancePolicyHolder, Patient>((h, p) => h.PatientId == p.Id)
                           .Select<InsurancePolicyHolder, Patient>((h, p) => new
                           {
                               h,
                               PatientUId = p.UId
                           })
                           .Where(i => i.UId == uid);
                var dynamics = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<InsurancePolicyHolder>.Map(dynamics);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IInsurancePolicyHolder> GetByIdAndRel(int patientId, string relName)
        {
            return await this.Connection.SingleAsync<InsurancePolicyHolder>(i => i.PatientId == patientId && i.PHRel == relName);
        }

        public async Task<IInsurancePolicyHolder> AddNew(IInsurancePolicyHolder entity)
        {
            try
            {
                InsurancePolicyHolder tEntity = entity as InsurancePolicyHolder;

                if (tEntity.PatientId == 0)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientIdMandatory]));

                if(tEntity.DOB == null)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyHolderRequired]));


                var patient = await this._patientRepository.GetByUId(entity.PatientUId);
                entity.PatientId = patient.Id;

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

        public async Task<IInsurancePolicyHolder> Update(IInsurancePolicyHolder entity)
        {
            try
            {
                InsurancePolicyHolder tEntity = entity as InsurancePolicyHolder;

                var patient = await this._patientRepository.GetByUId(entity.PatientUId);
                entity.PatientId = patient.Id;

                if(entity.Id == 0)
                {
                    var addEntity = await this.AddNew(entity);
                    return addEntity as InsurancePolicyHolder;
                }

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<InsurancePolicyHolder>()
                                           .Update(x => new
                                           {
                                               x.PatientId,
                                               x.FirstName,
                                               x.LastName,
                                               x.Address1,
                                               x.Address2,
                                               x.City,
                                               x.State,
                                               x.Zip,
                                               x.HomePhone,
                                               x.BusPhone,
                                               x.DOB,
                                               x.Sex,
                                               x.PHRel,
                                               x.EmployerAddress1,
                                               x.EmployerAddress2,
                                               x.EmployerCity,
                                               x.EmployerState,
                                               x.EmployerZip,
                                               x.EmployerPhone,
                                               x.EmploymentStatus,
                                               x.OrganizationName,
                                               x.MaritalStatusId,
                                               x.Student
                                           })
                                           .Where(i => i.UId == entity.UId);

                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid phUId)
        {
            try
            {
                return await this.Connection.DeleteAsync<InsurancePolicyHolder>(i => i.UId == phUId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByPatientId(int patientId)
        {
            try
            {
                return await this.Connection.DeleteAsync<InsurancePolicyHolder>(i => i.PatientId == patientId);
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyHolderRequired]));
        }

        public async Task ValidateInsPolicyHolderAddress(string insLevel, string polHolderStreet, string polHolderState, string polHolderCity, string polHolderZip)
        {
            try
            {
                IList<ValidationResult> validations = new List<ValidationResult>();

                if (string.IsNullOrEmpty(polHolderStreet))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SubscriberStreetRequired, insLevel]));
                }

                if (string.IsNullOrEmpty(polHolderCity))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SubscriberCityRequired, insLevel]));
                }

                if (string.IsNullOrEmpty(polHolderState))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SubscriberStateRequired, insLevel]));
                }

                if (string.IsNullOrEmpty(polHolderZip))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SubscriberZipRequired, insLevel]));
                }

                var errors = (from x in validations
                              select new ValidationCodeResult(x.ErrorMessage)).ToList<IValidationResult>();

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);
            }
            catch
            {
                throw;
            }
        }
    }
}
