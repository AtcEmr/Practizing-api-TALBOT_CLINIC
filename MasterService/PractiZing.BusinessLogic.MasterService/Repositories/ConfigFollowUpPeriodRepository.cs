using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigFollowUpPeriodRepository : ModuleBaseRepository<ConfigFollowUpPeriod>, IConfigFollowUpPeriodRepository
    {
        public ConfigFollowUpPeriodRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loginUser)
        : base(errorCodes, dbContext, loginUser)
        {

        }
        public async Task<IConfigFollowUpPeriod> GetById(int id)
        {
            return await this.Connection.SingleAsync<ConfigFollowUpPeriod>(i => i.ID == id);

        }

        public async Task<IEnumerable<IConfigFollowUpPeriod>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigFollowUpPeriod>(i => i.IsActive == true)).OrderBy(i => i.FollowUpValue);

        }

        public async Task<IConfigFollowUpPeriod> AddNew(IConfigFollowUpPeriod entity)
        {
            try
            {
                ConfigFollowUpPeriod tEntity = entity as ConfigFollowUpPeriod;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }

                return await base.AddNewAsync(tEntity);

            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IConfigFollowUpPeriod entity)
        {
            try
            {
                ConfigFollowUpPeriod tEntity = entity as ConfigFollowUpPeriod;

                var updateOnlyFields = this.Connection
                                           .From<ConfigFollowUpPeriod>()
                                           .Update(x => new
                                           {
                                               x.FollowUpDays,
                                               x.FollowUpValue,
                                               x.FollowUpMonths
                                           })
                                           .Where<ConfigFollowUpPeriod>(i => i.ID == entity.ID);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> Delete(Int16 id)
        {
            try
            {
                return await this.Connection.DeleteAsync<ConfigFollowUpPeriod>(i => i.ID == id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}