using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class FSChargeRepository : ModuleBaseRepository<FSCharge>, IFSChargeRepository
    {
        private ILogger _logger;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        public FSChargeRepository(IInsuranceCompanyRepository insuranceCompanyRepository,ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            ILogger<FSChargeRepository> logger
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _logger = logger;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
        }

        /// <summary>
        /// Get all CPT Charges
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IFSCharge>> GetAll()
        {
            return await this.Connection.SelectAsync<FSCharge>();
        }

        /// <summary>
        /// Get CPT Charges by feeScheduleId
        /// </summary>
        /// <param name="feeScheduleId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IFSCharge>> GetByFeeSchedule(short feeScheduleId)
        {
            return (await this.Connection.SelectAsync<FSCharge>(i => i.FeeScheduleId == feeScheduleId)).OrderBy(i => i.CPTCode);
        }

        public async Task<IFSCharge> GetByCPT(string cptCode)
        {
            return await this.Connection.SingleAsync<FSCharge>(i => i.CPTCode == cptCode);
        }

        public async Task<IFSCharge> GetByCPT(string cptCode, short feeScheduleId)
        {
            return await this.Connection.SingleAsync<FSCharge>(i => i.CPTCode == cptCode && i.FeeScheduleId == feeScheduleId);
        }

        /// <summary>
        /// Get CPT Charges by given params
        /// </summary>
        /// <param name="cptCode"></param>
        /// <param name="modifier"></param>
        /// <param name="feeScheduleId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IFSCharge>> GetByCPTCharge(string cptCode, string modifier, short feeScheduleId,string insuranceCompanyId="",int providerId=0)
        {
            try
            {
                int insId = 0;
                if(!string.IsNullOrWhiteSpace(insuranceCompanyId) && insuranceCompanyId!="null")
                insId = (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyId))).Id;



                cptCode = cptCode == null ? string.Empty : cptCode;
                modifier = modifier == null ? string.Empty : modifier;
                IEnumerable<FSCharge> fscharge=new List<FSCharge>();

                if (insId > 0 && providerId>0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == insId && i.ProviderId==providerId);
                }
                if (fscharge.Count() == 0 && providerId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.ProviderId == providerId && i.InsuranceCompayId==null);
                }
                if (fscharge.Count() == 0 && insId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId==insId && i.ProviderId==null);
                }

                if(fscharge.Count()==0)
                fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId==null && i.ProviderId==null);

                //return await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId);
                return fscharge;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("GetByCPTCharge -- Exception -- " + ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Get CPT Charges by given params
        /// </summary>
        /// <param name="cptCode"></param>
        /// <param name="modifier"></param>
        /// <param name="feeScheduleId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IFSCharge>> GetByCPTChargeByQualification(string cptCode, string modifier, short feeScheduleId, string insuranceCompanyId = "", int qualificationId = 0)
        {
            try
            {
                int insId = 0;
                if (!string.IsNullOrWhiteSpace(insuranceCompanyId) && insuranceCompanyId != "null")
                    insId = (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyId))).Id;



                cptCode = cptCode == null ? string.Empty : cptCode;
                modifier = modifier == null ? string.Empty : modifier;
                IEnumerable<FSCharge> fscharge = new List<FSCharge>();

                if (insId > 0 && qualificationId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == insId && i.QualificationId == qualificationId);
                }
                if (fscharge.Count() == 0 && qualificationId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.FeeScheduleId == feeScheduleId && i.QualificationId == qualificationId && i.InsuranceCompayId == null);
                }
                if (fscharge.Count() == 0 && insId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == insId && i.QualificationId == null);
                }

                if (fscharge.Count() == 0)
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == null && i.QualificationId == null);

                //return await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId);
                return fscharge;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("GetByCPTCharge -- Exception -- " + ex.StackTrace);
                throw;
            }
        }

        public async Task<IFSCharge> GetDefaultFeeRates(string cptCode, short feeScheduleId)
        {
            var item= await this.Connection.SingleAsync<FSCharge>(i => i.CPTCode == cptCode && i.Modifier == "" && i.Modifier2 == null && i.Modifier3 == null
            && i.Modifier4 == null
            && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId==null && i.QualificationId==null);

            if(item==null)
            {
                item = await this.Connection.SingleAsync<FSCharge>(i => i.CPTCode == cptCode && i.Modifier == "" && i.Modifier2 == "" && i.Modifier3 == ""
            && i.Modifier4 == ""
            && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == null && i.QualificationId == null);
            }

            return item;
        }

        /// <summary>
        /// Get CPT Charges by given params
        /// </summary>
        /// <param name="cptCode"></param>
        /// <param name="modifier"></param>
        /// <param name="feeScheduleId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IFSCharge>> GetByCPTChargeByQualificationOLD(string cptCode, string modifier, short feeScheduleId, string insuranceCompanyId = "", int qualificationId = 0)
        {
            try
            {
                int insId = 0;
                if (!string.IsNullOrWhiteSpace(insuranceCompanyId) && insuranceCompanyId != "null")
                    insId = (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(insuranceCompanyId))).Id;



                cptCode = cptCode == null ? string.Empty : cptCode;
                modifier = modifier == null ? string.Empty : modifier;
                IEnumerable<FSCharge> fscharge = new List<FSCharge>();

                if (insId > 0 && qualificationId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == insId && i.QualificationId == qualificationId);
                }
                if (fscharge.Count() == 0 && qualificationId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.QualificationId == qualificationId && i.InsuranceCompayId == null);
                }
                if (fscharge.Count() == 0 && insId > 0)
                {
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == insId && i.QualificationId == null);
                }

                if (fscharge.Count() == 0)
                    fscharge = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId && i.InsuranceCompayId == null && i.QualificationId == null);

                //return await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == cptCode) && i.Modifier == modifier && i.FeeScheduleId == feeScheduleId);
                return fscharge;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("GetByCPTCharge -- Exception -- " + ex.StackTrace);
                throw;
            }
        }



        /// <summary>
        /// Save new Charge of CPT
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IFSCharge> AddNew(IFSCharge entity)
        {
            try
            {
                FSCharge tEntity = entity as FSCharge;
                tEntity.Modifier = tEntity.Modifier ?? string.Empty;
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
        /// Update CPT Charges
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Update(IFSCharge entity)
        {
            try
            {
                FSCharge tEntity = entity as FSCharge;
                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                tEntity.Modifier = tEntity.Modifier ?? string.Empty;
                var updateOnlyFields = this.Connection
                                           .From<FSCharge>()
                                           .Update(x => new
                                           {
                                               x.CPTCode,
                                               x.FacilityCharge,
                                               x.Modifier,
                                               x.Modifier2,
                                               x.Modifier3,
                                               x.Modifier4,
                                               x.NonFacilityCharge,
                                               x.FeeScheduleId,
                                               x.CommunityCharge,
                                               x.QualificationId,
                                               x.ModifiedBy,x.ModifiedDate
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
        /// multiple DML applied for
        /// CPTCharge, that can be delete, save or update
        /// for given feeScheduleId
        /// update multiple CPT Charges for Single FeeSchedule
        /// that can be delete, add new CPT Charge or update as well
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="feeScheduleId"></param>
        /// <returns></returns>
        public async Task<bool> UpdateEntities(IEnumerable<IFSCharge> entities, short feeScheduleId)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.FeeScheduleId = feeScheduleId;

                    if (item.Id != 0 && !item.IsFSChargeDeleted)
                        await this.Update(item);
                    else if (item.Id == 0 && !item.IsFSChargeDeleted)
                        await this.AddNew(item);
                    else
                        await this.DeleteCharge(item.FeeScheduleId, item.Id);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete FSCharge by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(short id)
        {
            try
            {
                return await this.Connection.DeleteAsync<FSCharge>(i => i.Id == id);
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> DeleteCharge(short feeScheduleId, int id)
        {
            try
            {
                return await this.Connection.DeleteAsync<FSCharge>(i => i.Id == id && i.FeeScheduleId == feeScheduleId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(FSCharge tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Get CPTCharge for feeScheduleId if cpt charge exist for given modifier than it will give an exception
             of Duplicate CPT Charge*/
            /*Check FSCharge already exist for given cptCode, modifier. if it already exist then
             throw an exception 'DuplicateFSCharge'*/
            //var fSCharges = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == tEntity.CPTCode)
            //                                                         && i.Modifier == tEntity.Modifier
            //                                                         && i.FeeScheduleId == tEntity.FeeScheduleId && i.InsuranceCompayId==tEntity.InsuranceCompayId && i.QualificationId==tEntity.QualificationId);
            //if (fSCharges.Count() > 0)
            //    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateFSCharge]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(FSCharge tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Get CPTCharge for feeScheduleId if cpt charge exist for given modifier than it will give an exception
           of Duplicate CPT Charge*/

            /*Check FSCharge already exist for given cptCode, modifier. if it already exist then
             throw an exception 'DuplicateFSCharge'*/

            var fSCharges = await this.Connection.SelectAsync<FSCharge>(i => (i.CPTCode == tEntity.CPTCode)
            && i.Modifier == tEntity.Modifier && i.Id != tEntity.Id && i.FeeScheduleId == tEntity.FeeScheduleId && i.InsuranceCompayId==tEntity.InsuranceCompayId && i.QualificationId==tEntity.QualificationId);
            if (fSCharges.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateFSCharge]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

    }
}
