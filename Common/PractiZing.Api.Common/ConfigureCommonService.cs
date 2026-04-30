using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using PractiZing.Base.Common;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Authorization;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Api.Common.Identity;
using PractiZing.Api.Common.Authorize;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureCommonService
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceCollection AddCommonService(this IServiceCollection services,
            IConfiguration configuration)
        {
            Configuration = configuration;
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddOptions();

            var section = Configuration.GetSection("MySettings");

            services.Configure<MySettings>(section);
            services.AddSingleton<MyConfiguration>();


            services.AddSingleton<HttpContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<DataBaseContext>();
            //services.AddScoped<DataBaseContext>();
            services.AddScoped<ITransactionProvider, TransactionProvider>();
            services.AddTransient<ILoginUser, IdentityUser>();
            services.AddScoped<MemoryCache>();
            services.AddScoped<IdentityResolver>();

            services.AddTransient<IdentityUser>();

            services.AddCors();
            services.AddJwtAuthentication();
            services.AddMvc();

            return services;
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Practice Insight",
                    Version = "v1",
                    Description = "Practice Insight",
                    TermsOfService = "None"
                });
                options.DescribeAllEnumsAsStrings();
            });
        }

        public static void AddCustomMvc(this IServiceCollection services)
        {
            //UserStampFilterAttribute


            services.AddMvc(config =>
            {
                /* right now injected IdentityUser globally and using in BaseRepository and handling there
                *config.Filters.Add(new UserStampFilterAttribute());
                */

            })

            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                var resolver = opt.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;
                }

            }).AddControllersAsServices();
        }

        public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
            {
                var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
                var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
                var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

                if (isAuthorized && !allowAnonymous)
                {
                    if (operation.Parameters == null)
                        operation.Parameters = new List<IParameter>();

                    operation.Parameters.Add(new NonBodyParameter
                    {
                        Name = "Authorization",
                        In = "header",
                        Description = "access token",
                        Required = true,
                        Type = "string"
                    });
                }
            }
        }

    }
}