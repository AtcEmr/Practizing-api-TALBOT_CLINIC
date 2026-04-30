using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class UserRoleRepository : ModuleBaseRepository<UserRole>, IUserRoleRepository
    {
        private readonly IUserRepository _userRepository;
        public UserRoleRepository(ValidationErrorCodes validationErrorCodes,
                                   DataBaseContext dataBaseContext,
                                   ILoginUser loginUser,
                                   IUserRepository userRepository)
                                  : base(validationErrorCodes, dataBaseContext, loginUser)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<IUserRole>> GetAll()
        {
            return await this.Connection.SelectAsync<UserRole>();
        }

        public async Task<IEnumerable<IUserRole>> GetByUser(int userId)
        {
            return await this.Connection.SelectAsync<UserRole>(i => i.UserId == userId);
        }

        /// <summary>
        /// this method will return list of roles
        /// with IsAssigned = true for roles that are assigned to the user
        /// and IsAssigned = false for roles that are not assigned to the user
        /// </summary>
        /// <param name="userUIdS"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IUserRole>> GetAllByUser(string userUId)
        {
            var user = await this._userRepository.GetByUId(Guid.Parse(userUId));
            var userId = user == null ? 0 : user.Id;
            var query = this.Connection
                            .From<UserRole>()
                            .RightJoin<UserRole, Role>((ur, r) => ur.RoleId == r.Id && ur.UserId == userId)
                            .SelectDistinct<UserRole, Role>((ur, r) => new
                            {
                                ur,
                                r.RoleName,
                                RoleId = r.Id
                            });

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var roles = Mapper<UserRole>.MapList(dynamics);

            /*if role is assigned to the user, then id will be greater than 0 so IsAssigned will become true, otherwise false
            if role is not assigned to the user, then IsAssigned will be false*/
            foreach (var item in roles)
                item.IsAssigned = item.Id == 0 ? false : true;

            return roles;
        }

        public async Task<bool> ModifyList(IEnumerable<IUserRole> entities)
        {
            try
            {
                var userId = entities.FirstOrDefault()?.UserId;
                var roleIds = entities.Select(i => i.RoleId);

                var userRoles = await this.GetByUser(userId.Value);
                if (userRoles.Count() == 0)
                {    //since no role is present on the user, so it will save all the user roles
                    await this.AddAll(entities);
                    return true;
                }

                //this method will delete that data from userRole that is not present in entities
                var rolesToDelete = userRoles.Where(i => !roleIds.Contains(i.RoleId));
                if (rolesToDelete.Count() > 0)
                {
                    var userRoleIds = rolesToDelete.Select(i => i.Id);
                    ///it will delete all the userRoles on the basis of id and will return the count(number) of rows deleted
                    await this.Connection.DeleteByIdsAsync<UserRole>(userRoleIds);
                }

                //this method will add that data in userRole that is present in entities but not in database
                var rolesToAdd = entities.Where(i => !(userRoles.Select(j => j.RoleId)).Contains(i.RoleId));
                await this.AddAll(rolesToAdd);

                return true;
            }
            catch
            {
                throw;
            }
        }

        private async Task<IEnumerable<IUserRole>> AddAll(IEnumerable<IUserRole> entities)
        {
            try
            {
                List<IUserRole> userRoles = new List<IUserRole>();

                var errors = await this.ValidateEntity(entities);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                foreach (var item in entities)
                {
                    UserRole tEntity = item as UserRole;
                    //it will add userRole 
                    var userRole = await base.AddNewAsync(tEntity);
                    //saved userRole will be added in the list
                    userRoles.Add(userRole);
                }
                //the list of userRoles will be returned as the final output
                return userRoles;
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(UserRole tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var result = await this.Connection.SelectAsync<UserRole>(i => i.UserId == tEntity.UserId
                                                                               && i.RoleId == tEntity.RoleId);
            if (result.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserRoleAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(UserRole tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            var result = await this.Connection.SelectAsync<UserRole>(i => i.UserId == tEntity.UserId
                                                                               && i.RoleId == tEntity.RoleId
                                                                               && i.UId != tEntity.UId);
            if (result.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserRoleAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntity(IEnumerable<IUserRole> entities)
        {
            List<IValidationResult> errorList = new List<IValidationResult>();
            foreach (var item in entities)
            {
                UserRole userRole = item as UserRole;
                //validating errors for each userRole
                var errors = await this.ValidateEntityToAdd(userRole);
                if (errors.Count() > 0)
                    errorList.AddRange(errors);
            }
            return errorList;
        }
    }
}
