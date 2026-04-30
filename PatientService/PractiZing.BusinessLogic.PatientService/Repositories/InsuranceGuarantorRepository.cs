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
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class InsuranceGuarantorRepository : ModuleBaseRepository<InsuranceGuarantor>, IInsuranceGuarantorRepository
    {
        private readonly ITransactionProvider _transactionProvider;

        public InsuranceGuarantorRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            ITransactionProvider transactionProvider) : base(errorCodes, dbContext, loggedUser)
        {
            this._transactionProvider = transactionProvider;
        }

        public async Task<IInsuranceGuarantor> GetByPatientId(int patientId)
        {
            return await this.Connection.SingleAsync<InsuranceGuarantor>(i => i.PatientID == patientId);
        }

        public async Task<IInsuranceGuarantor> AddNew(IInsuranceGuarantor entity)
        {
            try
            {
                InsuranceGuarantor tEntity = entity as InsuranceGuarantor;
                tEntity.ModifiedDate = DateTime.Now;
                if (string.IsNullOrEmpty(tEntity.GuarantorNumber))
                    tEntity.GuarantorNumber = "0";
                CultureInfo culture = new CultureInfo("en-US");
                //tEntity.DOB = (Convert.ToDateTime(tEntity.DOB, culture)).ToString("dd-mm-yyyy");
                if (tEntity.DOB != null)
                {
                    var errors = await this.ValidateEntityToAddOrUpdate(tEntity);
                    if (errors.Count() > 0)
                        await this.ThrowEntityException(errors);
                }
                var gurantorPatient = await this.GetByPatientId(tEntity.PatientID);
                if(gurantorPatient != null)
                {
                    entity.ID = gurantorPatient.ID;
                }

                if (entity.ID != 0)
                {
                    var returnResult = await this.Update(entity);
                    return returnResult;
                }

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IInsuranceGuarantor> Update(IInsuranceGuarantor entity)
        {
            try
            {
                InsuranceGuarantor tEntity = entity as InsuranceGuarantor;
                if (entity.DOB != null)
                {
                    var errors = await this.ValidateEntityToAddOrUpdate(tEntity);

                    if (errors.Count() > 0)
                        await this.ThrowEntityException(errors);
                }
                var updateOnlyFields = this.Connection
                                           .From<InsuranceGuarantor>()
                                           .Update(x => new
                                           {
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
                                               x.AdminSex,
                                               x.GuarantorRel,
                                               x.EmployerAddress1,
                                               x.EmployerAddress2,
                                               x.EmployerCity,
                                               x.EmployerState,
                                               x.EmployerZip,
                                               x.EmployerPhone,
                                               x.EmploymentStatus,
                                               x.OrganizationName,
                                               x.MaritalStatus,
                                               x.Student,
                                               x.PreferedContact,
                                               x.MobilePhone
                                           })
                                           .Where(i => i.ID == entity.ID);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int patientId)
        {
            try
            {
                return await this.Connection.DeleteAsync<InsuranceGuarantor>(i => i.PatientID == patientId);
            }
            catch
            {
                throw;
            }
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToAddOrUpdate(InsuranceGuarantor tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            if (!string.IsNullOrEmpty(tEntity.GuarantorRel))
            {
                if (string.IsNullOrEmpty(tEntity.DOB))
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.GuarantorDOBRequired]));
            }

            CultureInfo culture = new CultureInfo("en-US");
            DateTime dobdate = Convert.ToDateTime(tEntity.DOB, culture);

            if (dobdate > DateTime.Now)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDOBValidation]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }
    }
}
