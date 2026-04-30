using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Identity;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.IO;

namespace PractiZing.UnitTest.Common
{
    public class TestStartUp
    {
        public TestStartUp(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

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

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddOptions();

            var section = Configuration.GetSection("MySettings");

            services.Configure<MySettings>(section);
            services.AddSingleton<MyConfiguration>();

            var connectionString = "Data Source=198.211.100.149;Initial Catalog=PI2_Temp;User id=PI2.0;Password=Damodar@654;Trusted_Connection=False;";
            var sqlPracticeCentralDbFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
            sqlPracticeCentralDbFactory.RegisterConnection("localhost", connectionString, SqlServerDialect.Provider);


            services.AddSingleton<OrmLiteConnectionFactory>(sqlPracticeCentralDbFactory);

            services.AddSingleton<HttpContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //setupLogService.Log(_connectionString);
            services.AddAutoMapper();
            // _practiceCentralConnectionString = Configuration.GetConnectionString("PracticeCentralDBContext");
            //setupLogService.Log(_practiceCentralConnectionString);

            //_connectionString = Configuration.GetConnectionString("DefaultConnection");
            ////_connectionString = EncryptionProvider.Decrypt(_connectionString);

            //var sqlDbFactory = new OrmLiteConnectionFactory(_connectionString, SqlServer2017Dialect.Provider);
            //services.AddSingleton<OrmLiteConnectionFactory>(sqlDbFactory);

            services.AddScoped<DataBaseContext>();
            services.AddScoped<ITransactionProvider, TransactionProvider>();
            services.AddTransient<ILoginUser, IdentityUser>();
            services.AddScoped<IdentityResolver>();


            services.AddCors();
            services.AddJwtAuthentication();
            services.AddMvc();

            ConfigureRepositoriesAndService(services);
            services.AddMvc(options => options.MaxModelValidationErrors = 200)
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        private void ConfigureRepositoriesAndService(IServiceCollection services)
        {
            //services.AddChargePaymentServiceRepositories();
            //services.AddChargePaymentService();

            services.AddPatientServiceRepositories();
            services.AddPatientServices();

            //services.AddMasterServiceRepositories();
            //services.AddMasterServices();

            //services.AddSecurityServiceRepositories();
            //services.AddSecurityServices();

            //services.AddDenialServiceRepositories();
            //services.AddDenialServices();

            //services.AddERAServiceRepositories();

            //services.AddPractiZingReportRepositories();
            //services.AddReportServices();
        }

        private void ConfigureErrorCodes(IServiceCollection services)
        {
            services.AddSingleton<PractiZing.DataAccess.ChargePaymentService.ValidationErrorCodes>();
            services.AddSingleton<PractiZing.DataAccess.MasterService.ValidationErrorCodes>();
            //services.AddSingleton<PractiZing.DataAccess.PatientService.ValidationErrorCodes>();
            //services.AddSingleton<PractiZing.DataAccess.SecurityService.ValidationErrorCodes>();
            //services.AddSingleton<PractiZing.DataAccess.DenialService.ValidationErrorCodes>();
            //services.AddSingleton<PractiZing.DataAccess.ERAService.ValidationErrorCodes>();
            //services.AddSingleton<PractiZing.DataAccess.ReportService.ValidationErrorCodes>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            string date = DateTime.Now.ToLongDateString();
            //loggerFactory.AddFile($"Logs/{date}.txt");

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

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(path),
            //    RequestPath = new PathString($"/{relativePath}"),
            //    ContentTypeProvider = GetStaticFileConfiguration()
            //});


            app.UseStaticFiles();

            app.UseRequestLocalization();

            app.UseAuthentication();
            var scope = app.ApplicationServices.CreateScope();

            //var myConfiguration = scope.ServiceProvider.GetRequiredService<MyConfiguration>();
            //var identityResolver = scope.ServiceProvider.GetRequiredService<IdentityResolver>();


            //app.UseSimpleTokenProvider(new TokenProviderOptions
            //{
            //    Path = "/token",
            //    Audience = Configuration["ValidAudience"],
            //    Issuer = Configuration["ValidIssuer"],
            //    SigningCredentials = JwtSecurityKey.GetSigningCredentials(),
            //    IdentityResolver = identityResolver.CheckUserLogin,
            //    Expiration = DateTime.Now.AddDays(7).TimeOfDay
            //});

            app.UseMvc();
        }
    }
}
