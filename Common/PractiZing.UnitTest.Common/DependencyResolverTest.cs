using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PractiZing.Api.Common.Identity;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System;
using System.IO;

namespace PractiZing.UnitTest.Common
{
    public static class DependencyResolverTest
    {
        
        public static DataBaseContext DBConnection()
        {
            var _connectionString = "Data Source=DESKTOP-PBHUBDF\\SA;Initial Catalog=PI2Temp;User id=sa;Password=sa$123;Trusted_Connection=False;";
            ServiceStack.Licensing.RegisterLicense(@"6058-e1JlZjo2MDU4LE5hbWU6Q29uUXN5cyBJVCBQdnQuIEx0ZC4sVHlwZTpPcm1MaXRlQnVzaW5lc3MsSGFzaDpsbHVmU3cxaGtHZ1ZhY2xMTnZkTWxRR0w3Rm5TY3Q2U1oydVhQR3VCQkF1SVZHL1k3TXozZllWZ0Jod25pMlU1VnVDYXBXRUdXOXA2akNGbjE2QXNYMVIyMExyV1FSSHNXdTYxK0dDU2MxU0tzVzNMZzBYK3E5WGFqZzAyL0RwTzJnRzJQSCtxbDE5aytieERVbEd0MTlqRDdtdUFlYjNOcm4wckUxMEhpWU09LEV4cGlyeToyMDE5LTA0LTI1fQ==");
            var sqlDbFactory = new OrmLiteConnectionFactory(_connectionString, SqlServerOrmLiteDialectProvider.Instance);
            sqlDbFactory.RegisterConnection("localhost", _connectionString, SqlServerDialect.Provider);

            return null;

        }

        public static ILoginUser User()
        {
            IdentityUser user = new IdentityUser(null);
            user.Id = 5;
            user.PracticeId = 1;
            user.UserName = "admin";
            return user;
        }
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            var enviornment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            enviornment = enviornment == null ? "Development" : enviornment;

            string filePath = Directory.GetCurrentDirectory() + $"/appsettings.{enviornment}.json";

            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile(filePath, optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            var configuration = builder.Build();
            return configuration;
        }

        public static IHttpContextAccessor ContextAccessor()
        {
            var context = new Mock<IHttpContextAccessor>();
            return context.Object;
        }

        public static MyConfiguration GetMyConfiguration()
        {
            var mySetting = new Mock<IOptions<MySettings>>();
            MyConfiguration myConfiguration = new MyConfiguration(mySetting.Object);
            myConfiguration.settings = new MySettings();
            return myConfiguration;
        }


        public static ITransactionProvider TransactionProvider()
        {
            var transactionProvider = new Mock<ITransactionProvider>();

            return transactionProvider.Object;
        }


    }
}
