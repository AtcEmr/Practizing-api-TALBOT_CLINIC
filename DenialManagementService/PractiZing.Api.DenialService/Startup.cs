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
using PractiZing.Base.Repositories;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService;

namespace PractiZing.Api.DenailManagementService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            services.AddDenialServiceRepositories();
            services.AddDenialServices();
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

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
