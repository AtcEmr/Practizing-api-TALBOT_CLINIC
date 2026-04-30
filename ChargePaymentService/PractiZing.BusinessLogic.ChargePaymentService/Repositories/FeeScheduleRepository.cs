using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class FeeScheduleRepository : ModuleBaseRepository<FeeSchedule>, IFeeScheduleRepository
    {
        public FeeScheduleRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        /// <summary>
        /// Get FeeSchedule for given date
        /// </summary>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        public async Task<IFeeSchedule> GetFeeSchedules(DateTime fromDate)
        {
            var result = await this.Connection.SelectAsync<FeeSchedule>(i => i.IsActive == true && i.PracticeId == LoggedUser.PracticeId);
            var currentFeeSchedule = result.FirstOrDefault(i => (i.EffectiveDate.Date <= fromDate.Date && i.ExpiryDate.Date >= fromDate.Date));
            return currentFeeSchedule;
        }

        public async Task<IEnumerable<IFeeSchedule>> GetAll()
        {
            return (await this.Connection.SelectAsync<FeeSchedule>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.EffectiveDate.Date);
        }

        public async Task<IFeeSchedule> GetById(short id)
        {
            return await this.Connection.SingleAsync<FeeSchedule>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IFeeSchedule> GetLatestUid()
        {
            var list= await this.Connection.SelectAsync<FeeSchedule>();
            var lastReocrd = list.LastOrDefault();
            if(lastReocrd!=null)
            {
                return lastReocrd;
            }
            return null;
        }

        public async Task<IFeeSchedule> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<FeeSchedule>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
        }


        /// <summary>
        /// Get FeeSchedule for given CPTCode,
        /// will return CPTCharges and it's Discounts
        /// </summary>
        /// <param name="cptCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IFeeSchedule>> GetFeeSchedule(string cptCode)
        {
            var query = this.Connection.From<FeeSchedule>()
                         .Join<FeeSchedule, FSCharge>((f, c) => f.Id == c.FeeScheduleId)
                         .LeftJoin<FSCharge, FSDiscount>((fc, fd) => fc.FeeScheduleId == fd.FSChargeID)
                          .Select<FeeSchedule, FSCharge, FSDiscount>((f, c, d) => new
                          {
                              FSDiscount = d,
                              FSCharge = c,
                              f
                          }).Where<FSCharge>(i => i.CPTCode == cptCode);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            var results = Mapper<FeeSchedule>.MapList(dynamicResult);
            return results;
        }

        public async Task FeeScheduleNotExist()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FeeScheduleNotExist]));
            await this.ThrowEntityException(errors);

        }

        /// <summary>
        /// save new feeSchedule
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IFeeSchedule> AddNew(IFeeSchedule entity)
        {
            try
            {
                FeeSchedule tEntity = entity as FeeSchedule;

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
        /// Update FeeSchedule
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Update(IFeeSchedule entity)
        {
            try
            {
                FeeSchedule tEntity = entity as FeeSchedule;
                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<FeeSchedule>()
                                           .Update(x => new
                                           {
                                               x.Name,
                                               x.FSLocalityCarrierId,
                                               x.EffectiveDate,
                                               x.ExpiryDate,
                                               x.IsActive
                                           })
                                           .Where<FeeSchedule>(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
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
                return await this.Connection.DeleteAsync<FeeSchedule>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(FeeSchedule tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Effective date should be less than it's expiry date otherwise it will give an exception*/
            if (tEntity.ExpiryDate.Date < tEntity.EffectiveDate.Date)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ExpiryDateLessThanEffectiveDate]));

            else
            {
                var result = await this.Connection.SingleAsync<FeeSchedule>(i => i.PracticeId == LoggedUser.PracticeId);
                if (result != null)
                {
                    var res = await this.Connection.SelectAsync<FeeSchedule>(i =>
                      i.IsActive == true && i.PracticeId == LoggedUser.PracticeId);

                    /*Check while save new feeSchedule, feeSchedule does not exist for given daterange otherwise it will give an exception*/
                    var fs = res.FirstOrDefault(i => (i.EffectiveDate.Date <= tEntity.EffectiveDate.Date && i.ExpiryDate.Date >= tEntity.EffectiveDate.Date)
                                            || (i.EffectiveDate.Date <= tEntity.ExpiryDate.Date && i.ExpiryDate.Date >= tEntity.ExpiryDate.Date)
                                            || (i.EffectiveDate.Date >= tEntity.EffectiveDate.Date && i.ExpiryDate.Date <= tEntity.ExpiryDate.Date)
                                            || (i.EffectiveDate.Date >= tEntity.EffectiveDate.Date && i.ExpiryDate.Date <= tEntity.ExpiryDate.Date));
                    if (fs != null)
                        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectiveAndExpiryDate], fs.Name));

                    var feeSchedule = await this.Connection.SingleAsync<FeeSchedule>(i => i.Name == tEntity.Name
                                                                                  && i.FSLocalityCarrierId == tEntity.FSLocalityCarrierId
                                                                                  && i.PracticeId == LoggedUser.PracticeId
                                                                                  );
                    if (feeSchedule != null)
                        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateFeeSchedule]));
                }
            }

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(FeeSchedule tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            if (tEntity.ExpiryDate.Date < tEntity.EffectiveDate.Date)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ExpiryDateLessThanEffectiveDate]));

            else
            {
                var res = await this.Connection.SelectAsync<FeeSchedule>(i => i.IsActive == true && i.PracticeId == LoggedUser.PracticeId
                                                                           && i.Id != tEntity.Id);

                /*Check while save new feeSchedule, feeSchedule does not exist for given daterange otherwise it will give an exception*/
                var fs = res.FirstOrDefault(i => (i.EffectiveDate.Date <= tEntity.EffectiveDate.Date && i.ExpiryDate.Date >= tEntity.EffectiveDate.Date)
                                              || (i.EffectiveDate.Date <= tEntity.ExpiryDate.Date && i.ExpiryDate.Date >= tEntity.ExpiryDate.Date)
                                              || (i.EffectiveDate.Date >= tEntity.EffectiveDate.Date && i.ExpiryDate.Date <= tEntity.ExpiryDate.Date)
                                              || (i.EffectiveDate.Date >= tEntity.EffectiveDate.Date && i.ExpiryDate.Date <= tEntity.ExpiryDate.Date));
                if (fs != null)
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectiveAndExpiryDate], fs.Name));

                var feeSchedules = await this.Connection.SelectAsync<FeeSchedule>(i => (i.Name == tEntity.Name)
                                                                                      && i.Id != tEntity.Id
                                                                                      && i.PracticeId == LoggedUser.PracticeId
                                                                                     );
                if (feeSchedules.Count() > 0)
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateFeeSchedule]));
            }

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }
    }
}
