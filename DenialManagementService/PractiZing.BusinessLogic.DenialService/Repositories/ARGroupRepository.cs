using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService;
using PractiZing.DataAccess.DenialService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.DenialService.Repositories
{
    public class ARGroupRepository : ModuleBaseRepository<ARGroup>, IARGroupRepository
    {
        public ARGroupRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IARGroup> AddNew(IARGroup entity)
        {
            try
            {
                ARGroup tEntity = entity as ARGroup;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }
                var result = await base.AddNewEntity(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ARGroup>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IARGroup>> Get()
        {

            var result = (await this.Connection.SelectAsync<ARGroup>(i => i.PracticeId == LoggedUser.PracticeId))
                        .OrderBy(i => i.GroupName);
            return result;
        }

        public async Task<IARGroup> Get(int id)
        {
            var result = await this.Connection.SingleAsync<ARGroup>(i => i.Id == id
                                                                     && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        public async Task<IARGroup> Get(Guid UId)
        {
            var result = await this.Connection.SingleAsync<ARGroup>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        public async Task<int> Update(IARGroup entity)
        {
            try
            {
                ARGroup tEntity = entity as ARGroup;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<ARGroup>()
                                       .Update(x => new
                                       {
                                           x.GroupName
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

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
