using Microsoft.IdentityModel.Tokens;
using PractiZing.Api.Common.Authorize;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PractiZing.Api.Common.Identity
{

    public class PractiZingJwtTokenHandler : JwtSecurityTokenHandler
    {
        public override ClaimsPrincipal ValidateToken(string token, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {            
            //token comming in request is small token using this method we will get real token from memory cache
            token = this.GetToken(token);
            ClaimsPrincipal principal = base.ValidateToken(token, validationParameters, out validatedToken);
            //var parsedToken = base.ReadJwtToken(token);
            PractiZingIdentity identity = PractiZingIdentity.ToIdentity(principal.Identity as ClaimsIdentity);
            PractiZingPrincipal practiZincPrinciple = new PractiZingPrincipal(identity);
            return practiZincPrinciple;
        }
        /// <summary>
        /// get real token from memory cache by small token
        /// </summary>
        /// <param name="smallToken"></param>
        /// <returns></returns>
        private string GetToken(string smallToken)
        {
            var tokenData = MemoryCache.Get(smallToken);
            return tokenData?.Token;
        }
    }

}
