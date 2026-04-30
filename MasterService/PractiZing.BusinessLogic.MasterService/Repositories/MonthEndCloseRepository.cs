using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class MonthEndCloseRepository : ModuleBaseRepository<MonthEndClose>, IMonthEndCloseRepository
    {

        public MonthEndCloseRepository(ValidationErrorCodes errorCodes,
                                       DataBaseContext dbContext,
                                       ILoginUser loggedUser
                                       ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IMonthEndClose> AddNew(IMonthEndClose entity)
        {
            try
            {
                MonthEndClose tEntity = entity as MonthEndClose;
                tEntity.PracticeId = LoggedUser.PracticeId;
                tEntity.CreatedBy = LoggedUser.UserName;

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

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<MonthEndClose>(i => i.UId == uid);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IMonthEndClose> Get(Guid uid)
        {
            return await this.Connection.SingleAsync<MonthEndClose>(i => i.PracticeId == LoggedUser.PracticeId && i.UId == uid);
        }

        public async Task<IMonthEndClose> GetByDateId(int monthId, int yearId)
        {
            return await this.Connection.SingleAsync<MonthEndClose>(i => i.PracticeId == LoggedUser.PracticeId && i.YearId == yearId && i.MonthId == monthId);
        }

        public async Task<IEnumerable<IMonthEndClose>> Get()
        {
            return (await this.Connection.SelectAsync<MonthEndClose>(i => i.PracticeId == LoggedUser.PracticeId)).OrderByDescending(i => i.YearId).ThenByDescending(i => i.MonthId);
        }

        public async Task<int> Update(IMonthEndClose entity)
        {
            try
            {
                MonthEndClose tEntity = entity as MonthEndClose;
                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<MonthEndClose>()
                                           .Update(x => new
                                           {
                                               x
                                           })
                                           .Where(i => i.UId == entity.UId);

                return await this.Connection.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(MonthEndClose tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var getPreviousRecord = await this.GetByDateId(tEntity.MonthId, tEntity.YearId);
            if (getPreviousRecord != null)
            {
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.MonthClosedAlreadyExists]));
            }
            return errors;
        }
    }
}
