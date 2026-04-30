using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Service.SecurityService;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Api.Common.Identity
{
    public class IdentityResolver
    {
        private IUserService _userService;
        public IdentityResolver(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<ClaimsIdentity> CheckUserLogin(string userName, string password)
        {
            try
            {
                var user = await this._userService.Login(userName, password);
                if (user == null)
                {
                    return null;
                }

                if (!string.IsNullOrEmpty(user.UserName))
                {
                    PractiZingIdentity myIdentity = new PractiZingIdentity(new GenericIdentity(user.UserName), new List<Claim>(), "Standard", "name", "role", user);
                    return myIdentity;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ClaimsIdentity> CheckUserLoginAzure(string userName, string password)
        {
            try
            {
                var user = await this._userService.LoginAzure(userName, password);
                if (user == null)
                {
                    return null;
                }

                if (!string.IsNullOrEmpty(user.UserName))
                {
                    PractiZingIdentity myIdentity = new PractiZingIdentity(new GenericIdentity(user.UserName), new List<Claim>(), "Standard", "name", "role", user);
                    return myIdentity;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
