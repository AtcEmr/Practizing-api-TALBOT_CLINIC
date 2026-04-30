using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PractiZing.Api.Common.Identity;
using PractiZing.Api.Common.Middlewares;
using PractiZing.Api.SecurityService.TokenProvider;
using PractiZing.Base.Common;
using PractiZing.Base.Repositories;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;

namespace PractiZing.Api.SecurityService
{
    public class Startup
    {
        public IConfiguration Configuration
        { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPracticeCentralDataRepository, PracticeCentralDataRepository>();
            //services.AddScoped<ITransactionProvider, TransactionProvider>();
            //services.AddSingleton<ITransactionProvider, TransactionProvider>();
            services.AddCommonService(Configuration);            
            ConfigureErrorCodes(services);


            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });

            services.AddSecurityServiceRepositories();
            services.AddSecurityServices();
            services.AddSwaggerService();
        }

        private void ConfigureErrorCodes(IServiceCollection services)
        {
            ValidationErrorCodes errorCodes = new ValidationErrorCodes();

            services.AddSingleton<ValidationErrorCodes>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                //loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
               builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod()
               );

            ServiceStack.Licensing.RegisterLicense(@"6058-e1JlZjo2MDU4LE5hbWU6Q29uUXN5cyBJVCBQdnQuIEx0ZC4sVHlwZTpPcm1MaXRlQnVzaW5lc3MsSGFzaDpsbHVmU3cxaGtHZ1ZhY2xMTnZkTWxRR0w3Rm5TY3Q2U1oydVhQR3VCQkF1SVZHL1k3TXozZllWZ0Jod25pMlU1VnVDYXBXRUdXOXA2akNGbjE2QXNYMVIyMExyV1FSSHNXdTYxK0dDU2MxU0tzVzNMZzBYK3E5WGFqZzAyL0RwTzJnRzJQSCtxbDE5aytieERVbEd0MTlqRDdtdUFlYjNOcm4wckUxMEhpWU09LEV4cGlyeToyMDE5LTA0LTI1fQ==");

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Add("index.html");

            app.UseDefaultFiles(options);

            app.UseStaticFiles();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice Insight");
            });


            //app.UseSimpleTokenProvider(new TokenProviderOptions
            //{
            //    Path = "/token",
            //    Audience = Configuration["ValidAudience"],
            //    Issuer = Configuration["ValidIssuer"],
            //    SigningCredentials = JwtSecurityKey.GetSigningCredentials(),
            //    IdentityResolver = (username, password) => 
            //    {
            //        var resolver = app.ApplicationServices.GetService<IdentityResolver>();
            //        var identity= resolver.CheckUserLogin(username, password);
            //        return identity;
            //    },
                
            //    Expiration = DateTime.Now.AddDays(7).TimeOfDay
            //});

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
