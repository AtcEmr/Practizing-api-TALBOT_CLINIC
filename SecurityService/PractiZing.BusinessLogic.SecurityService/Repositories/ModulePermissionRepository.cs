using System.Linq;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using PractiZing.DataAccess.SecurityService.Tables;
using PractiZing.BusinessLogic.Common;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class ModulePermissionRepository
        : ModuleBaseRepository<IModulePermission>, IModulePermissionRepository
    {
        public ModulePermissionRepository(ValidationErrorCodes validationErrorCodes,
                                          DataBaseContext dataBaseContext,
                                          ILoginUser loginUser)
                                          : base(validationErrorCodes, dataBaseContext, loginUser)
        {
        }

        private SqlExpression<ModulePermission> Query()
        {
            var query = this.Connection
                          .From<ModulePermission>()
                          .Join<ModulePermission, PZModule>((mp, m) => mp.ModuleId == m.Id);

            return query;
        }

        public async Task<IEnumerable<IModulePermission>> Get(IEnumerable<int> roleIds)
        {
            var query = this.Query()
                            .Join<PZModule, RoleModule>((m, rm) => m.Id == rm.RoleId)
                            .Select<ModulePermission, PZModule>((mp, m) => new
                            {
                                mp,
                                mp.PermissionName,
                                m.ModuleName
                            })
                            .Where<RoleModule>(i => roleIds.Contains(i.RoleId));
            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var permissions = Mapper<ModulePermission>.MapList(dynamics);
            return permissions;
        }

        /// <summary>
        /// return all the modules that are present on the modulePermissionId
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPZModule>> GetModulesByIds(IEnumerable<int> ids)
        {
            var query = this.Query()
                            .SelectDistinct<ModulePermission, PZModule>((mp, m) => new
                            {
                                m
                            })
                            .Where<ModulePermission>(i => ids.Contains(i.Id));

            var dynamic = await this.Connection.SelectAsync<dynamic>(query);
            var modules = Mapper<PZModule>.MapList(dynamic);
            return modules;
        }

        public async Task<IEnumerable<IUserPermission>> GetByModuleIds(List<int> moduleIds)
        {

            var query = this.Query()
                            .SelectDistinct<ModulePermission, PZModule>((mp, m) => new
                            {
                                ModulePermissionId = mp.Id,
                                PermissionName = mp.PermissionName,
                                ModuleName = m.ModuleName,
                                ModuleId = m.Id
                            })
                            .Where<ModulePermission>(i => moduleIds.Contains(i.ModuleId));

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var permissions = Mapper<UserPermission>.MapList(dynamics);

            foreach (var item in permissions)
                item.HasPermission = true;

            return permissions;
        }

        public async Task<IModulePermission> Get(int id)
        {
            return await this.Connection.SingleAsync<ModulePermission>(i => i.Id == id);
        }

        public async Task<IEnumerable<IModulePermission>> GetByModuleId(int moduleId)
        {
            return await this.Connection.SelectAsync<ModulePermission>(i => i.ModuleId == moduleId);
        }

        public async Task<IModulePermission> AddNew(IModulePermission entity)
        {
            try
            {
                ModulePermission tEntity = entity as ModulePermission;
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

        public async Task<int> Update(IModulePermission entity)
        {
            try
            {
                ModulePermission tEntity = entity as ModulePermission;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ModulePermission>()
                                           .Update(x => new
                                           {
                                               x.ModuleId,
                                               x.PermissionName
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
                return await this.Connection.DeleteAsync<ModulePermission>(i => i.Id == id);
            }
            catch
            {
                throw;
            }
        }
    }
}
