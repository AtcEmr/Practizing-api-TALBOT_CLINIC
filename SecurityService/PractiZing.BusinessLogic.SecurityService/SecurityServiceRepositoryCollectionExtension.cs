using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.SecurityService;
using PractiZing.BusinessLogic.SecurityService.Repositories;
using PractiZing.BusinessLogic.SecurityService.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SecurityServiceRepositoryCollectionExtension
    {
        public static IServiceCollection AddSecurityServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPZModuleRepository, PZModuleRepository>();
            services.AddScoped<IModulePermissionRepository, ModulePermissionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleModuleRepository, RoleModuleRepository>();
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IPracticeCentralPracticeRepository, PracticeCentralPracticeRepository>();
            return services;
        }

        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
