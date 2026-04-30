using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PractiZing.Api.Common.Authorize;
using PractiZing.Api.Common.Identity;
using PractiZing.Api.Common.Middlewares;
using PractiZing.Api.SecurityService.TokenProvider;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.ClaimCreator.Prof;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.Common;

using ServiceStack.OrmLite;

namespace HostService.Api
{
    public class Startup
    {
        bool isDev;
        private readonly static string secretKey = "JWT!Secret#As#perMYChoiCE!123";
        public readonly static SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        private static IEnumerable<IPracticeCentralPractice> _practices;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            isDev = env.IsDevelopment();

        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureErrorCodes(services);
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });

            services.AddScoped<IPracticeCentralDataRepository, PracticeCentralDataRepository>();
            services.AddSingleton<ISetupLogService, SetupLogService>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddCommonService(Configuration);
            //services.AddScoped<ITransactionProvider, TransactionProvider>();
            //services.AddSingleton<ITransactionProvider, TransactionProvider>();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var sqlPracticeCentralDbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
            sqlPracticeCentralDbFactory.RegisterConnection("PracticeCentral", connectionString, SqlServerDialect.Provider);

            services.AddAutoMapper();
            // AddJwtAuthentication(services);

            //if (isDev) services.AddSwaggerService();
            if (Convert.ToBoolean(Configuration["UseSwagger"]))
                services.AddSwaggerService();

            ConfigureRepositoriesAndService(services);
            services.AddSingleton<OrmLiteConnectionFactory>(sqlPracticeCentralDbFactory);

            var sp = services.BuildServiceProvider();
            var service = sp.GetService<IPracticeCentralPracticeRepository>();
            _practices = service.GetAllPractices().Result;
            foreach (var practice in _practices)
            {
                sqlPracticeCentralDbFactory.RegisterConnection(practice.PracticeCode, practice.DBConnectionString, SqlServerDialect.Provider);
            }

            services.AddResponseCompression(options=>
            {
                options.EnableForHttps = true;
                //options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                //            {
                //                "text/plain",
                //                "text/html",
                //                "application/xml",
                //                "text/xml",
                //                "application/json",
                //                "text/json"
                //            }); ;
                //options.Providers.Add<GzipCompressionProvider>();
            });

            //services.Configure<GzipCompressionProvider>(options =>
            //{
            //    options.SupportsFlush = CompressionLevel.Fastest;
            //});

            //  services.AddSingleton<OrmLiteConnectionFactory>(sqlPracticeCentralDbFactory);
            services.AddMvc(options => options.MaxModelValidationErrors = 200)
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddMvc();
        }


        private void ConfigureRepositoriesAndService(IServiceCollection services)
        {
            services.AddChargePaymentServiceRepositories();
            services.AddChargePaymentService();

            services.AddPatientServiceRepositories();
            services.AddPatientServices();

            services.AddMasterServiceRepositories();
            services.AddMasterServices();

            services.AddSecurityServiceRepositories();
            services.AddSecurityServices();

            services.AddDenialServiceRepositories();
            services.AddDenialServices();

            services.AddERAServiceRepositories();

            services.AddPractiZingReportRepositories();
            services.AddReportServices();

            //var modules = new List<IModule>
            //{
            //    new Module()
            //};
            //foreach (var module in modules)
            //{
            //    module.ConfigureServices(services);
            //}

            InitializeBuilders.Intialize();
            services.AddERAServices();
        }

        private void ConfigureErrorCodes(IServiceCollection services)
        {
            services.AddSingleton<PractiZing.DataAccess.ChargePaymentService.ValidationErrorCodes>();
            services.AddSingleton<PractiZing.DataAccess.MasterService.ValidationErrorCodes>();
            services.AddSingleton<PractiZing.DataAccess.PatientService.ValidationErrorCodes>();
            services.AddSingleton<PractiZing.DataAccess.SecurityService.ValidationErrorCodes>();
            services.AddSingleton<PractiZing.DataAccess.DenialService.ValidationErrorCodes>();
            services.AddSingleton<PractiZing.DataAccess.ERAService.ValidationErrorCodes>();
            services.AddSingleton<PractiZing.DataAccess.ReportService.ValidationErrorCodes>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            string date = DateTime.Now.ToLongDateString();
            loggerFactory.AddFile($"Logs/{date}.txt");

            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
               builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod()
               );

            ServiceStack.Licensing.RegisterLicense(@"6058-e1JlZjo2MDU4LE5hbWU6Q29uUXN5cyBJVCBQdnQuIEx0ZC4sVHlwZTpPcm1MaXRlQnVzaW5lc3MsSGFzaDpsbHVmU3cxaGtHZ1ZhY2xMTnZkTWxRR0w3Rm5TY3Q2U1oydVhQR3VCQkF1SVZHL1k3TXozZllWZ0Jod25pMlU1VnVDYXBXRUdXOXA2akNGbjE2QXNYMVIyMExyV1FSSHNXdTYxK0dDU2MxU0tzVzNMZzBYK3E5WGFqZzAyL0RwTzJnRzJQSCtxbDE5aytieERVbEd0MTlqRDdtdUFlYjNOcm4wckUxMEhpWU09LEV4cGlyeToyMDE5LTA0LTI1fQ==");

            string relativePath = this.Configuration["AttachmentFolder"];
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Add("index.html");
            options.DefaultFileNames.Add("Index.html");
            app.UseDefaultFiles(options);

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = new PathString($"/{relativePath}"),
                ContentTypeProvider = GetStaticFileConfiguration()
            });

            SetupLog.Log(path);

            app.UseStaticFiles();
            
            if (Convert.ToBoolean(Configuration["UseSwagger"]))
            {
                app.UseSwagger();
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice Insight V1");
            });
            }
            app.UseRequestLocalization();
             
            var scope = app.ApplicationServices.CreateScope();

            //below written code is for loading constructor of MemoryCache class
            //where Imemorycache will be intilized
            scope.ServiceProvider.GetRequiredService<MemoryCache>();
            //create instance of UserAuthenticationRepository
            var userAuthRepository = scope.ServiceProvider.GetRequiredService<IUserAuthenticationRepository>();
            //remove all logeed user token from database which are expired
           // userAuthRepository.RemoveAllExpiredTokenFromCache(_practices);
            //get all logged user from database and set those user in memory cache
            userAuthRepository.SetAllInCache(_practices);

            var myConfiguration = scope.ServiceProvider.GetRequiredService<MyConfiguration>();

            app.UseResponseCompression();

            app.UseSimpleTokenProvider(new TokenProviderOptions
            {
                Path = "/token",
                Audience = Configuration["ValidAudience"],
                Issuer = Configuration["ValidIssuer"],
                SigningCredentials = JwtSecurityKey.GetSigningCredentials(),
                IdentityResolver = (username, password) =>
                   {
                       var resolver = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityResolver>();                       
                       var identity = resolver.CheckUserLogin(username, password);
                       return identity;
                   },
                Expiration = DateTime.Now.AddDays(30).TimeOfDay
            });

            app.UseSimpleTokenProvider(new TokenProviderOptions
            {
                Path = "/tokenAzure",
                Audience = Configuration["ValidAudience"],
                Issuer = Configuration["ValidIssuer"],
                SigningCredentials = JwtSecurityKey.GetSigningCredentials(),
                IdentityResolver = (username, password) =>
                {
                    var resolver = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityResolver>();
                    var identity = resolver.CheckUserLoginAzure(username, "");
                    return identity;
                },
                Expiration = DateTime.Now.AddDays(30).TimeOfDay
            });

            app.Use((a, e) =>
            {
                a.Response.Headers.Add("_rid", a.Request.Headers["_rid"]);
                a.Response.Headers.Add("Access-Control-Expose-Headers", "*");
                a.Response.Headers.Add("Access-Control-Allow-Headers", "*");

                return e.Invoke();
            });

            //use FingerPrinterMiddleWare here
            //app.UseMiddleware<FingerPrinterMiddleWare>();

            app.UseAuthentication();
            app.UseMvc();
        }

        private IContentTypeProvider GetStaticFileConfiguration()
        {
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".clm"] = "application/octect-stream";
            return provider;
        }
    }
}
