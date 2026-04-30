using System.Linq;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using PractiZing.BusinessLogic.Common;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class PZModuleRepository : ModuleBaseRepository<IPZModule>, IPZModuleRepository
    {
        public PZModuleRepository(ValidationErrorCodes validationErrorCodes,
                                   DataBaseContext dataBaseContext,
                                   ILoginUser loginUser)
                                  : base(validationErrorCodes, dataBaseContext, loginUser)
        {
        }

        public async Task<IEnumerable<IPZModule>> Get()
        {
            return await this.Connection.SelectAsync<PZModule>();
        }

        public async Task<IEnumerable<IModulePermission>> GetModulePermissions(IEnumerable<int> ids)
        {
            var query = this.Connection
                            .From<PZModule>()
                            .Join<PZModule, ModulePermission>((m, mp) => m.Id == mp.ModuleId)
                            .Select<PZModule, ModulePermission>((m, mp) => new
                            {                                
                                 mp
                            }
                            );
            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var modulePermissions = Mapper<ModulePermission>.MapList(dynamics);
            return modulePermissions;
        }

        public async Task<IPZModule> Get(int id)
        {
            return await this.Connection.SingleAsync<PZModule>(i => i.Id == id);
        }

        public async Task<IPZModule> AddNew(IPZModule entity)
        {
            try
            {
                PZModule tEntity = entity as PZModule;
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

        public async Task<int> Update(IPZModule entity)
        {
            PZModule tEntity = entity as PZModule;

            var errors = await this.ValidateEntityToUpdate(tEntity);
            if (errors.Count() > 0)
                await this.ThrowEntityException(errors);

            var updateOnlyFields = this.Connection
                                       .From<PZModule>()
                                       .Update(x => new
                                       {
                                           x.ModuleName
                                       })
                                       .Where(i => i.Id == entity.Id);

            return await this.Connection.UpdateOnlyAsync(tEntity, updateOnlyFields);
        }

        public async Task<int> Delete(int id)
        {
            return await this.Connection.DeleteAsync<PZModule>(i => i.Id == id);
        }
    }
}
