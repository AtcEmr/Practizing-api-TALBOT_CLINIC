using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.SecurityService;
using PractiZing.BusinessLogic.SecurityService.Repositories;
using PractiZing.DataAccess.SecurityService.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService.Services
{
    public class UserService : IUserService
    {
        private readonly ITransactionProvider _transactionProvider;
        private readonly IUserRepository _userRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleModuleRepository _roleModuleRepository;
        private readonly IModulePermissionRepository _modulePermissionRepository;
        private readonly IPZModuleRepository _pZModuleRepository;
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        public UserService(ITransactionProvider transactionProvider,
                           IUserRepository userRepository,
                           IUserPermissionRepository userPermissionRepository,
                           IUserRoleRepository userRoleRepository,
                           IRoleRepository roleRepository,
                           IRoleModuleRepository roleModuleRepository,
                           IModulePermissionRepository modulePermissionRepository,
                           IPZModuleRepository pZModuleRepository,
                           IUserAuthenticationRepository userAuthenticationRepository)
        {
            _transactionProvider = transactionProvider;
            _userRepository = userRepository;
            _userPermissionRepository = userPermissionRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _roleModuleRepository = roleModuleRepository;
            _modulePermissionRepository = modulePermissionRepository;
            _pZModuleRepository = pZModuleRepository;
            this._userAuthenticationRepository = userAuthenticationRepository;
        }

        public async Task<ILoginUser> Login(string userName, string password)
        {
            var user = await this._userRepository.Login(userName, password);
            if (user != null)
                user.UserPermissions = await this._userPermissionRepository.Get(user.Id);

            return user;
        }

        public async Task<ILoginUser> LoginAzure(string userName, string password)
        {
            var user = await this._userRepository.LoginAzure(userName, password);
            if (user != null)
                user.UserPermissions = await this._userPermissionRepository.Get(user.Id);

            return user;
        }

        /// <summary>
        /// Get user permissions by userId and roleIds
        /// If there is data in userPermission on the user, then return that data.
        /// If there is no data on that user id, then find data from modulepermission by roleids and convert those
        /// into userpermission model type list.
        /// This method will be called when admin wants to change roles and permissions of any user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task<IModuleDTO> GetAllByUser(string userUId, List<int> roleIds)
        {
            var moduleDTO = new ModuleDTO();

            var user = await this._userRepository.GetByUId(Guid.Parse(userUId));
            var userId = user == null ? 0 : user.Id;

            //it will return list of permissions for a particular user on the basis of userId
            var userPermissions = await this._userPermissionRepository.GetByUserId(userId);

            if (userPermissions.Count() > 0)
            {
                //return modules of the roles choosen by the user
                var pzModule = (await this._roleModuleRepository.GetModuleByRoleIds(roleIds)).ToList();
                //module ids of the choosen roles
                var moduleIds = pzModule.Select(i => i.Id);
                //modules ids of saved userPermissions i.e on which userPermissions exist
                var moduleIdsbyPermission = userPermissions.Select(i => i.ModuleId).Distinct();
                //module ids on which userPermission doesnt exist
                moduleIds = moduleIds.Except(moduleIdsbyPermission);
                if (moduleIds.Count() > 0)
                {
                    //modulePermissions of the moduleIds on which userPermission doesnt exist
                    //will return all modulePermissions as userPermissions of that moduleId with hasPermission = true 
                    var permissionsOfUser = await this._modulePermissionRepository.GetByModuleIds(moduleIds.ToList());

                    // add those permissions(userPermissions) in the userpeermission list of module which initially had no userPermissions
                    foreach (var item in pzModule)
                        item.UserPermissions = permissionsOfUser.Where(i => i.ModuleId == item.Id);
                }

                pzModule = pzModule.Where(i => i.UserPermissions.Count() > 0).ToList();

                //it will return list of ModulePermissionIds of the user on the basis of roleId
                var modulePermissionIds = userPermissions.Where(i => roleIds.Contains(i.RoleId)).Select(i => i.ModulePermissionId).ToList();
                //the permissions are overridden, not inherited
                moduleDTO.OverriddenInheritedPermission = true;

                //if userPermissions already exist on user, it will return modules and  permissions of that user
                var modules = await this._modulePermissionRepository.GetModulesByIds(modulePermissionIds);

                moduleDTO.Modules = await this.GetModules(modules, userId);
                pzModule.AddRange(moduleDTO.Modules);
                moduleDTO.Modules = pzModule;

                return moduleDTO;
            }

            return await this.GetAllByRoleIds(roleIds);
        }

        public async Task<IEnumerable<IPZModule>> GetModules(IEnumerable<IPZModule> modules, int userId)
        {
            var moduleIds = modules.Select(i => i.Id).ToList();
            //return saved permissions of user on the basis of userId and moduleIds
            var permissions = await this._userPermissionRepository.GetSavedByModuleIds(moduleIds, userId);

            foreach (var item in modules)
                item.UserPermissions = permissions.Where(i => i.ModuleId == item.Id);
            return modules;
        }

        public async Task<IModuleDTO> GetAllByRoleIds(List<int> roleIds)
        {
            var moduleDTO = new ModuleDTO();

            //return modules from rolemodule on the basis of roleIDs
            var modulesByRoleIds = await this._roleModuleRepository.GetModuleByRoleIds(roleIds);

            //if modules exist on those roleIds, then modify those modules and store in moduleDTO
            if (modulesByRoleIds.Count() > 0)
                moduleDTO.Modules = await this.ModifyModules(modulesByRoleIds);

            //for those  saved modules in moduleDTO, make their modulePermissions active
            foreach (var item in moduleDTO.Modules)
                item.HasPermission = true;

            return moduleDTO;
        }

        private async Task<IEnumerable<IPZModule>> ModifyModules(IEnumerable<IPZModule> modules)
        {
            //return list of moduleIds
            modules = modules.Distinct();
            var moduleIds = modules.Select(i => i.Id).ToList();

            //fetch data from userPermission for the list of moduleId
            var permissions = await this._userPermissionRepository.GetByModuleIds(moduleIds);

            ///store fetched userPermissions in the userPermission List of the Module whose Id matches with moduleId of the userPermission
            ///permissions whose moduleId matches with Id of the module are stored in the userPermission List of that Module
            foreach (var item in modules)
                item.UserPermissions = permissions.Where(i => i.ModuleId == item.Id);

            return modules;
        }

        public async Task<bool> SaveRolesAndPermissions(IUserRolePermissionDTO entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                UserRolePermissionDTO tEntity = entity as UserRolePermissionDTO;

                /*it will add all the userRoles*/
                //var userRoles = await this._userRoleRepository.AddNew(tEntity.UserRoles);
                await this._userRoleRepository.ModifyList(tEntity.UserRoles);

                /*if the user has over ridden the inherited permissions, then new userPermissions will be saved*/
                if (entity.OverriddenInheritedPermission)
                {
                    await this._userPermissionRepository.SaveList(entity.UserPermissions);
                }
                /*if user has switched to inherited permissions, then delete all the overridden permissions for that user*/
                else
                {

                    var userId = entity.UserRoles.Select(i => i.UserId).FirstOrDefault();
                    /*delete all the userPermissions for the user*/
                    if (userId > 0)
                        await this._userPermissionRepository.DeleteByUserId(userId);
                }
                await this._userAuthenticationRepository.Delete(entity.UserId);
                this._transactionProvider.CommitTransaction(transactionId);
                return true;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }
    }
}
