using System.Linq;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using PractiZing.DataAccess.SecurityService.Tables;
using PractiZing.BusinessLogic.Common;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class RoleModuleRepository : ModuleBaseRepository<IRoleModule>, IRoleModuleRepository
    {
        public RoleModuleRepository(ValidationErrorCodes validationErrorCodes,
                                   DataBaseContext dataBaseContext,
                                   ILoginUser loginUser)
                                  : base(validationErrorCodes, dataBaseContext, loginUser)
        {
        }

        public async Task<IEnumerable<IRoleModule>> Get()
        {
            return await this.Connection.SelectAsync<RoleModule>();
        }

        public async Task<IRoleModule> Get(int id)
        {
            return await this.Connection.SingleAsync<RoleModule>(i => i.Id == id);
        }

        public async Task<IEnumerable<IPZModule>> GetModuleByRoleIds(IEnumerable<int> roleIds)
        {
            var query = this.Connection
                           .From<RoleModule>()
                           .Join<RoleModule, PZModule>((rm, m) => rm.ModuleId == m.Id)
                           .SelectDistinct<RoleModule, PZModule>((rm, m) => new
                           {
                               ModuleName = m.ModuleName,
                               m.Id
                           })
                           .Where<RoleModule>(i => roleIds.Contains(i.RoleId));

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var modules = Mapper<PZModule>.MapList(dynamics);
            return modules;
        }

        public async Task<IRoleModule> AddNew(IRoleModule entity)
        {
            try
            {
                RoleModule tEntity = entity as RoleModule;
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

        public async Task<int> Update(IRoleModule entity)
        {
            try
            {
                RoleModule tEntity = entity as RoleModule;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<RoleModule>()
                                           .Update(x => new
                                           {
                                               x.ModuleId,
                                               x.RoleId
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await this.Connection.UpdateOnlyAsync(tEntity, updateOnlyFields);
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
                return await this.Connection.DeleteAsync<RoleModule>(i => i.Id == id);
            }
            catch
            {
                throw;
            }
        }
    }
}
