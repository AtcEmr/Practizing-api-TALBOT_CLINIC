using PractiZing.Api.Common.Identity;
using PractiZing.Api.Common.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureJWTAuthServices
    {
        private readonly static string secretKey = "JWT!Secret#As#perMYChoiCE!123";
        public readonly static SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {            
            var sp = services.BuildServiceProvider();
            IConfiguration Configuration = sp.GetService<IConfiguration>();
            PractiZingJwtTokenHandler jwtHandler = new PractiZingJwtTokenHandler();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = Configuration["ValidIssuer"],
                            ValidAudience = Configuration["ValidAudience"],
                            IssuerSigningKey = JwtSecurityKey.Create()
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };

                        options.SecurityTokenValidators.RemoveAt(0);
                        options.SecurityTokenValidators.Add(jwtHandler);
                    });

            return services;
        }
    }
}
