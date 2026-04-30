using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class UserPermissionRepository : ModuleBaseRepository<UserPermission>, IUserPermissionRepository
    {
        public UserPermissionRepository(ValidationErrorCodes validationErrorCodes,
                                        DataBaseContext dataBaseContext,
                                        ILoginUser loginUser)
                                        : base(validationErrorCodes, dataBaseContext, loginUser)
        {

        }

        public async Task<IEnumerable<IUserPermission>> Get(int userId)
        {
            var query = this.Query();
            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var permissions = Mapper<UserPermission>.MapList(dynamics);

            var userPermissions = permissions.Where(i => i.UserId == userId);

            //if  userpermisions exist on user, then return those permissions
            if (userPermissions.Count() > 0)
                return userPermissions;

            //other make hasPermission true
            foreach (var item in permissions)
                item.HasPermission = true;

            return permissions;
        }

        public async Task<IEnumerable<IUserPermission>> GetByModuleIds(List<int> moduleIds)
        {
            var query = this.Connection
                             .From<ModulePermission>()
                             .Join<ModulePermission, PZModule>((mp, m) => mp.ModuleId == m.Id)
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

        public async Task<IEnumerable<IUserPermission>> GetSavedByModuleIds(List<int> moduleIds, int userId)
        {
            var query = this.Connection
                             .From<UserPermission>()
                             .LeftJoin<UserPermission, ModulePermission>((up, mp) => up.ModulePermissionId == mp.Id)
                             .Join<ModulePermission, PZModule>((mp, m) => mp.ModuleId == m.Id)
                             .SelectDistinct<UserPermission, ModulePermission, PZModule>((up, mp, m) => new
                             {
                                 up,
                                 ModulePermissionId = mp.Id,
                                 PermissionName = mp.PermissionName,
                                 ModuleName = m.ModuleName,
                                 ModuleId = m.Id
                             })
                            .Where<ModulePermission, UserPermission>((i, j) => moduleIds.Contains(i.ModuleId) && j.UserId == userId);
            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var permissions = Mapper<UserPermission>.MapList(dynamics);

            return permissions;
        }

        /// <summary>
        /// return list of permissions for a particular user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IUserPermission>> GetByUserId(int userId)
        {
            var query = this.Connection
                            .From<UserPermission>()
                            .Join<UserPermission, ModulePermission>((up, mp) => up.ModulePermissionId == mp.Id)
                            .Join<ModulePermission, PZModule>((mp, m) => mp.ModuleId == m.Id)
                            .Join<ModulePermission, RoleModule>((mp, rm) => mp.ModuleId == rm.ModuleId)
                            .SelectDistinct<UserPermission, ModulePermission, PZModule, RoleModule>((up, mp, m, rm) => new
                            {
                                up,
                                mp.PermissionName,
                                ModuleId = m.Id,
                                rm.RoleId,
                                m.ModuleName
                            })
                            .Where<UserPermission, RoleModule>((i, j) => i.UserId == userId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var permissions = Mapper<UserPermission>.MapList(dynamics);
            return permissions;
        }

        public async Task<bool> SaveList(IEnumerable<IUserPermission> entities)
        {
            try
            {
                var userPermissions = entities.ToList().ConvertAll(i => (UserPermission)i);
                var userPermissionId = userPermissions.Select(i => i.Id).FirstOrDefault();

                //if userPermissions already exist on user, then update those permissions
                if (userPermissionId > 0)
                {

                    foreach (var item in userPermissions)
                        await this.Update(item);
                    return true;
                }

                /*if user toggles between inherited and overridden permissions, then userPermissionId becomes 0 inspite the fact that userpermissions 
                 * already exist on user. So first delete the userPermissions already present on user and then add the new ones.              
                 */
                var userId = userPermissions.Select(i => i.UserId).FirstOrDefault();
                if (userId > 0)
                    await this.DeleteByUserId(userId);

                var errors = await this.ValidateEntity(userPermissions);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                //if userPermission does not exist on user, then add permissions
                await base.AddAllAsync(userPermissions);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IUserPermission entity)
        {
            try
            {
                UserPermission tEntity = entity as UserPermission;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<UserPermission>()
                                           .Update(x => new
                                           {
                                               x.UserId,
                                               x.HasPermission,
                                               x.ModulePermissionId,
                                               x.ModifiedBy,
                                               x.ModifiedDate
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await this.Connection.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByUserId(int userId)
        {
            return await this.Connection.DeleteAsync<UserPermission>(i => i.UserId == userId);
        }

        private SqlExpression<UserPermission> Query()
        {
            var query = this.Connection
                            .From<UserPermission>()
                            .RightJoin<UserPermission, ModulePermission>((up, mp) => up.ModulePermissionId == mp.Id)
                            .Join<ModulePermission, PZModule>((mp, m) => mp.ModuleId == m.Id)
                            .SelectDistinct<UserPermission, ModulePermission, PZModule>((up, mp, m) => new
                            {
                                up,
                                ModulePermissionId = mp.Id,
                                mp.PermissionName,
                                m.ModuleName,
                                ModuleId = m.Id
                            });
            return query;
        }

        //public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(UserPermission tEntity)
        //{
        //    List<IValidationResult> errors = new List<IValidationResult>();

        //    var result = await this.Connection.SelectAsync<UserPermission>(i => i.UserId == tEntity.UserId
        //                                                                             && i.ModulePermissionId == tEntity.ModulePermissionId);
        //    if (result.Count() > 0)
        //        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserPermissionAlreadyExist]));

        //    var entityErrors = await base.ValidateEntity(tEntity);
        //    errors.AddRange(entityErrors);

        //    return errors;
        //}

        //public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(UserPermission tEntity)
        //{
        //    List<IValidationResult> errors = new List<IValidationResult>();
        //    var result = await this.Connection.SelectAsync<UserPermission>(i => i.UserId == tEntity.UserId
        //                                                                     && i.ModulePermissionId == tEntity.ModulePermissionId
        //                                                                     && i.Id != tEntity.Id);
        //    if (result.Count() > 0)
        //        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserPermissionAlreadyExist]));

        //    var entityErrors = await base.ValidateEntity(tEntity);
        //    errors.AddRange(entityErrors);

        //    return errors;
        //}

        //private async Task<IEnumerable<IValidationResult>> ValidateEntity(IEnumerable<IUserPermission> entities)
        //{
        //    List<IValidationResult> errorList = new List<IValidationResult>();
        //    foreach (var item in entities)
        //    {
        //        UserPermission permission = item as UserPermission;
        //        var errors = await this.ValidateEntityToAdd(permission);
        //        errorList.AddRange(errors);
        //    }
        //    return errorList;
        //}
    }
}
