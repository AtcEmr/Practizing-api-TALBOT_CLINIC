using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PractiZing.Api.Common.Authorize;
using PractiZing.Api.Common.Middlewares;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.SecurityService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PractiZing.Api.Common.Identity;

namespace PractiZing.Api.SecurityService.TokenProvider
{
    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _serializerSettings;
        readonly HttpContextAccessor _httpContextAccessor;
        private IUserAuthenticationRepository _userAuthRepository;
        //private static string _fingerprint;
        public TokenProviderMiddleware(
            RequestDelegate next,
            IOptions<TokenProviderOptions> options,
            ILoggerFactory loggerFactory,
            HttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<TokenProviderMiddleware>();

            _options = options.Value;
            ThrowIfInvalidOptions(_options);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
            _httpContextAccessor = httpContextAccessor;
        }

        public Task Invoke(HttpContext context)
        {
            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                return _next(context);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST")
               || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync(JsonConvert.SerializeObject("Bad request.", _serializerSettings));
            }

            _logger.LogInformation("Handling request: " + context.Request.Path);

            return ValidateLogin(context);
        }

        private async Task ValidateLogin(HttpContext context)
        {
            try
            {
                string username = context.Request.Form["UserName"];
                string password = context.Request.Form["UserPwd"];
                string fingerPrint = context.Request.Form["FingerPrint"];
                this._userAuthRepository = (IUserAuthenticationRepository)context.RequestServices.GetService(typeof(IUserAuthenticationRepository));
                var userService = (IUserService)context.RequestServices.GetService(typeof(IUserService));

                _logger.LogInformation("user name -" + username);
                _logger.LogInformation("password -" + password);
                ClaimsIdentity identity = null;
                ILoginUser user = null;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    //await userRepository.IncreaseAttempts(username);
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("username and password required");
                    return;
                }
                try
                {
                    identity = await this._options.IdentityResolver(username, password);
                }
                catch(Exception ex)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(ex.Message);
                    return;
                }
               
                _logger.LogInformation("Identity -");

                if (identity == null)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("incorrect username or password");
                    return;
                }
                user = ((PractiZingIdentity)identity).User;
                if (!user.Active)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("This user is deactivated, Please contact to admin.");
                    return;
                }

                var response = await this.GenerateToken(username, identity, user, fingerPrint);
                // Serialize and return the response
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<TokenModel> GenerateToken(string username, ClaimsIdentity identity, ILoginUser user, string fingerprint)
        {
            var now = DateTime.Now;

            /* Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims. */
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, await _options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64),
            };

            /* You can add other claims here, if you want: */
            if (identity != null && identity.Claims.Count() > 0)
            {
                claims.AddRange(identity.Claims);
            }

            /* Create the JWT and write it to a string */
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddDays(30),
                signingCredentials: _options.SigningCredentials
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            //below codes are for generating small token which will send to front-end
            // and will be used for intration between front-end and back-end            
            var newClaims = claims.Where(i => i.Type == "Id" || i.Type == "PracticeId" || i.Type == "PracticeName" || i.Type == "UserName" || i.Type == "LogoName" || i.Type == "IsMentalACT" || i.Type == "FavIcon" || i.Type == "OnlinePaymentURL" || i.Type == "IsAdmin" || i.Type== "Position" || i.Type == "IsRequiredInsuranceAddEdit");           
            //create new small jwt which will finally send to front-end
            var smallJwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: newClaims,
                notBefore: now,
                expires: now.AddDays(30),
                signingCredentials: _options.SigningCredentials
                );
            var smallEncodedJwt = new JwtSecurityTokenHandler().WriteToken(smallJwt);
            //send logged user details to insert in database as well as local cache 
            var userAuth = await this._userAuthRepository.AddNew(user.Id, encodedJwt, now.AddDays(7), fingerprint, smallEncodedJwt);
            var response = new TokenModel
            {
                AccessToken = userAuth.SmallToken,
                ExpiresIn = (int)_options.Expiration.TotalSeconds
            };

            return response;
        }

        private static void ThrowIfInvalidOptions(TokenProviderOptions options)
        {
            if (string.IsNullOrEmpty(options.Path))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Path));
            }

            if (string.IsNullOrEmpty(options.Issuer))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Issuer));
            }

            if (string.IsNullOrEmpty(options.Audience))
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.Audience));
            }

            if (options.Expiration == TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(TokenProviderOptions.Expiration));
            }

            if (options.IdentityResolver == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.IdentityResolver));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.SigningCredentials));
            }

            if (options.NonceGenerator == null)
            {
                throw new ArgumentNullException(nameof(TokenProviderOptions.NonceGenerator));
            }
        }

        /// <summary>
        /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        public static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }

    public static class TokenProviderAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="TokenProviderMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables token generation capabilities.
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A  <see cref="TokenProviderOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseSimpleTokenProvider(this IApplicationBuilder app, TokenProviderOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
        }
    }
}
