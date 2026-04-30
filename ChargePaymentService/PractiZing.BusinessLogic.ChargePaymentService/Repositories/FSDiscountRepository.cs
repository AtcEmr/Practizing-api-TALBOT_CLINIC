using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Repositories.MasterService;
using Microsoft.Extensions.Logging;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class FSDiscountRepository : ModuleBaseRepository<FSDiscount>, IFSDiscountRepository
    {
        private IProviderRepository _providerRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private ILogger _logger;
        public FSDiscountRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IProviderRepository providerRepository,
                                            IInsuranceCompanyRepository insuranceCompanyRepository,
                                            ILogger<FSDiscountRepository> logger
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _providerRepository = providerRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _logger = logger;
        }

        /// <summary>
        /// add CPT Discount
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<IFSDiscount> AddNew(IFSDiscount entity)
        {
            try
            {
                FSDiscount tEntity = entity as FSDiscount;

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

        /// <summary>
        /// add multiple CPT Discounts by given fschargeId
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="fsChargeId"></param>
        /// <returns></returns>
        public async Task<bool> AddNewEntities(IEnumerable<IFSDiscount> entities, short fsChargeId)
        {
            try
            {
                foreach (var item in entities)
                {

                    item.FSChargeID = fsChargeId;
                    await this.AddNew(item);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(short id)
        {
            try
            {
                return await this.Connection.DeleteAsync<FSDiscount>(i => i.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IFSDiscount>> GetAll()
        {
            return await this.Connection.SelectAsync<FSDiscount>();
        }

        public async Task<IFSDiscount> GetById(short id)
        {
            return await this.Connection.SingleAsync<FSDiscount>(i => i.Id == id);
        }

        public async Task<IEnumerable<IFSDiscount>> GetByChargeId(int chargeId)
        {
            return await this.Connection.SelectAsync<FSDiscount>(i => i.FSChargeID == chargeId);
        }

        public async Task<IEnumerable<IFSDiscount>> GetCPTDiscount(short fsChargeId, DateTime fromDate, string providerUId, string insuranceCompanyUId)
        {
            try
            {
                Guid newGuid;
                int insuranceCompanyId = 0;
                int providerId = 0;
                int practitionerServiceId = 0;
                _logger.LogInformation("GetCPTDiscount -- " + "fsChargeId -- " + fsChargeId + "fromDate -- " + fromDate + "providerUId -- " + providerUId + "insuranceCompanyUId -- " + insuranceCompanyUId);
                insuranceCompanyUId = (insuranceCompanyUId == null || insuranceCompanyUId == "null") ? string.Empty : insuranceCompanyUId;
                _logger.LogInformation("insuranceCompanyUId -- " + insuranceCompanyUId);
                providerUId = (providerUId == null || providerUId == "null") ? string.Empty : providerUId;
                _logger.LogInformation("providerUId -- " + providerUId);
                var isValidInsuranceCompanyUId = Guid.TryParse(insuranceCompanyUId, out newGuid);
                _logger.LogInformation("isValidInsuranceCompanyUId -- " + isValidInsuranceCompanyUId);
                var isValidProviderUId = Guid.TryParse(providerUId, out newGuid);
                _logger.LogInformation("isValidProviderUId -- " + isValidProviderUId);
                if (isValidInsuranceCompanyUId)
                {
                    insuranceCompanyId = (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyUId))).Id;
                }
                //var insuranceCompanyId = (insuranceCompanyUId == null || insuranceCompanyUId.Contains("null") || insuranceCompanyUId.Contains("00000")) ? 0 : (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyUId))).Id;
                if (isValidProviderUId)
                {
                    var provider = await this._providerRepository.GetByUId(Guid.Parse(providerUId));
                    providerId = provider.Id;
                    if (provider.PractitionerServiceId.HasValue)
                        practitionerServiceId = provider.PractitionerServiceId.Value;
                }   

                /*from date should be valid. otherwise it will pick current date*/
                fromDate = (fromDate == DateTime.MinValue) ? DateTime.Now : fromDate;

                /*get Discount by given providerId and insuranceCompanyId*/
                var fsDiscount = await this.Connection.SelectAsync<FSDiscount>(i => i.FSChargeID == fsChargeId && i.IsActive);

                List<FSDiscount> response = new List<FSDiscount>();

                if (practitionerServiceId>0 && insuranceCompanyId > 0 && providerId > 0)
                {
                    response = fsDiscount.Where(i => i.PractitionerServiceId  == practitionerServiceId && i.InsuranceCompanyId == insuranceCompanyId && i.ProviderId == providerId).ToList();
                    if (response.Count() > 0)
                        return response.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                }

                if (practitionerServiceId > 0 && providerId > 0 && response.Count() == 0)
                {
                    response = fsDiscount.Where(i => i.PractitionerServiceId == practitionerServiceId && i.ProviderId == providerId).ToList();
                    if (response.Count() > 0)
                        return response.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                }

                if (practitionerServiceId > 0 && insuranceCompanyId  > 0 && response.Count() == 0)
                {
                    response = fsDiscount.Where(i => i.PractitionerServiceId == practitionerServiceId && i.InsuranceCompanyId == insuranceCompanyId).ToList();
                    if (response.Count() > 0)
                        return response.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                }

                if (practitionerServiceId > 0 && response.Count() == 0)
                {
                    response = fsDiscount.Where(i => i.PractitionerServiceId == practitionerServiceId).ToList();
                    if (response.Count() > 0)
                        return response.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                }

                if (insuranceCompanyId > 0 && providerId > 0)
                {
                    response = fsDiscount.Where(i => i.InsuranceCompanyId == insuranceCompanyId && i.ProviderId == providerId).ToList();
                    if (response.Count() > 0)
                        return response.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                }

                if (providerId > 0 && response.Count() == 0)
                {
                    response = fsDiscount.Where(i => i.ProviderId == providerId && i.InsuranceCompanyId == null).ToList();
                    if (response.Count() > 0)
                        return response.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                }

                if (insuranceCompanyId > 0 && response.Count() == 0)
                {
                    response = fsDiscount.Where(i => i.InsuranceCompanyId == insuranceCompanyId && i.ProviderId == null).ToList();
                    if (response.Count() > 0)
                        return response.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                }


                return response;
                /*filter for discount's effective date is greater than given date. so that which one discount is available for given date */
                //result = result.Where(i => i.EffectiveDate.Date <= fromDate.Date).ToList();
                //return result;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("GetCPTDiscount  Exception -- " + ex.StackTrace);
                throw;
            }
        }

        public async Task<int> Update(IFSDiscount entity)
        {
            try
            {
                FSDiscount tEntity = entity as FSDiscount;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<FSDiscount>()
                                           .Update(x => new
                                           {
                                               x.FSChargeID,
                                               x.ProviderId,
                                               x.InsuranceCompanyId,
                                               x.EffectiveDate,
                                               x.FacilityDiscount,
                                               x.NonFacilityDiscount,
                                               x.IsActive
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Implement multiple DML queries,
        /// Discount can be delete, update or add
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="fsChargeId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateEntities(IEnumerable<IFSDiscount> entities, short fsChargeId)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.FSChargeID = fsChargeId;

                    if (item.Id != 0 && !item.IsFSDiscountDeleted)
                        await this.Update(item);
                    else if (item.Id == 0 && !item.IsFSDiscountDeleted)
                        await this.AddNew(item);
                    else
                        await this.DeleteDiscount(item.FSChargeID, item.Id);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> DeleteDiscount(short fsChargeId, int id)
        {
            try
            {
                return await this.Connection.DeleteAsync<FSDiscount>(i => i.Id == id && i.FSChargeID == fsChargeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteDiscountByCharge(short fsChargeId)
        {
            try
            {
                return await this.Connection.DeleteAsync<FSDiscount>(i => i.FSChargeID == fsChargeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(FSDiscount tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Check Discounts by given effectivedate, insurancecompanyId, providerId and fsChargeId.
             if Discount exist it will throw an exception, Duplicate Discount not allowed for same params*/
            var fSDiscounts = await this.Connection.SelectAsync<FSDiscount>(i => (i.EffectiveDate == tEntity.EffectiveDate) && i.InsuranceCompanyId == tEntity.InsuranceCompanyId && i.ProviderId == tEntity.ProviderId && i.FSChargeID == tEntity.FSChargeID);
            if (fSDiscounts.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateFSDiscount]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(FSDiscount tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Check Discounts by given effectivedate, insurancecompanyId, providerId and fsChargeId.
            if Discount exist it will throw an exception, Duplicate Discount not allowed for same params*/
            var fSDiscounts = await this.Connection.SelectAsync<FSDiscount>(i => (i.EffectiveDate == tEntity.EffectiveDate) && i.Id != tEntity.Id && i.InsuranceCompanyId == tEntity.InsuranceCompanyId && i.ProviderId == tEntity.ProviderId && i.FSChargeID == tEntity.FSChargeID);
            if (fSDiscounts.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateFSDiscount]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<IFSDiscount> GetByInsuranceCompanyId(int companyId)
        {
            try
            {
                return await this.Connection.SingleAsync<FSDiscount>(i => i.InsuranceCompanyId == companyId);
            }
            catch
            {
                throw;
            }
        }

        public async Task FeeDiscountEffectiveDate()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FeeDiscountEffectiveDate]));
            await this.ThrowEntityException(errors);
        }

        public async Task ValidateFsDisocunt()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FsDisocuntExists]));
        }

        public async Task FeeDiscountValidation()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FeeDiscountAmountValidation]));
            await this.ThrowEntityException(errors);
        }
    }
}
