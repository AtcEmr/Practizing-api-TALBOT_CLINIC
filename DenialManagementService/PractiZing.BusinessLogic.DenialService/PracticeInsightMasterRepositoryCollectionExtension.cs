using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Service.DenialService;
using PractiZing.BusinessLogic.DenialService.Repositories;
using PractiZing.BusinessLogic.DenialService.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PractiZingDenialServiceCollectionExtension
    {
        public static IServiceCollection AddDenialServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDenialQueueRepository, DenialQueueRepository>();

            services.AddScoped<IARGroupRepository, ARGroupRepository>();
            services.AddScoped<IARGroupReasonCodeRepository, ARGroupReasonCodeRepository>();
            services.AddScoped<IActionNoteRepository, ActionNoteRepository>();
            services.AddScoped<IActionCategoryRepository, ActionCategoryRepository>();

            return services;
        }

        public static IServiceCollection AddDenialServices(this IServiceCollection services)
        {
            services.AddScoped<IActionCategoryService, ActionCategoryService>();
            return services;
        }
    }
}
