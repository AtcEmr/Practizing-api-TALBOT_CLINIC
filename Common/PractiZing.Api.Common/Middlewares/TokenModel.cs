using PractiZing.Base.Entities.SecurityService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Api.Common.Middlewares
{
    public class TokenModel
    {
       
            public string AccessToken { get; set; }

            public string UserName { get; set; }

            public int ExpiresIn { get; set; }

            public ILoginUser User { get; set; }
       
    }
}
