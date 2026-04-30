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
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigSystemCDRepository : ModuleBaseRepository<ConfigSystemCD>, IConfigSystemCDRepository
    {
        public ConfigSystemCDRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }
        public async Task<IConfigSystemCD> AddNew(IConfigSystemCD entity)
        {
            try
            {
                ConfigSystemCD tEntity = entity as ConfigSystemCD;

                return await base.AddNewEntity(tEntity);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> Delete(string CD)
        {
            try
            {
                return await this.Connection.DeleteAsync<ConfigSystemCD>(i => i.CD == CD);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IConfigSystemCD> GetByCD(string CD)
        {
            return await this.Connection.SingleAsync<ConfigSystemCD>(i => i.CD == CD);

        }



        public async Task<IEnumerable<IConfigSystemCD>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigSystemCD>()).OrderBy(i => i.CD);

        }
        
        public async Task<IEnumerable<IConfigSystemCD>> GetAllFollowUp()
        {
            return (await this.Connection.SelectAsync<ConfigSystemCD>()).Where(i => i.GroupCD.Trim().ToLower() == "defaultfollowupperiod");
        }

        public async Task<IEnumerable<IConfigSystemCD>> GetAllActionResponse()
        {
            return (await this.Connection.SelectAsync<ConfigSystemCD>()).Where(i => i.GroupCD.Trim().ToLower() == "actionresponseby");
        }

        public async Task<int> Update(IConfigSystemCD entity)
        {
            try
            {
                ConfigSystemCD tEntity = entity as ConfigSystemCD;

                var updateOnlyFields = this.Connection
                                           .From<ConfigSystemCD>()
                                           .Update(x => new
                                           {
                                               x.GroupCD,
                                               x.Description

                                           })
                                           .Where<ConfigSystemCD>(i => i.CD == entity.CD);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }
    }
}
