using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Api.Common.Middlewares
{

    public static class JwtSecurityKey
    {
        public readonly static string SecretKey = "JWT!Secret Key secret key JWT Secret Key";

        public static SymmetricSecurityKey Create()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
            
        }

        public static SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(Create(), SecurityAlgorithms.HmacSha384);
            
        }

    }
}
