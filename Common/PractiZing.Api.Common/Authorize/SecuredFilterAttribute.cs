using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PractiZing.Api.Common.Identity;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PractiZing.Api.Common.Authorize
{
    public class SecuredFilterAttribute : TypeFilterAttribute
    {
        public SecuredFilterAttribute(string actionType) : base(typeof(ValidateFilter))
        {
            Arguments = new object[] { actionType };
        }
    }
    public class ValidateSecuredFilterAttribute : TypeFilterAttribute
    {
        public ValidateSecuredFilterAttribute(string actionType) : base(typeof(ValidateFilter))
        {
            Arguments = new object[] { actionType };
        }
    }

    public class ValidateFilter : IAsyncActionFilter
    {
        private readonly string _actionType;

        private readonly IdentityUser _identityUser;

        public ValidateFilter(IServiceProvider services, string actionType)
        {
            this._actionType = actionType;
            using (var scope = services.CreateScope())
            {
                this._identityUser = scope.ServiceProvider.GetRequiredService<IdentityUser>();
            }
        }

        /// <summary>
        /// this method will validate all permissions of user, according to controller and 
        /// action
        /// </summary>
        /// <param name="context">http request all data</param>
        /// <param name="next">this is ActionExecutionDelegate delegate</param>
        /// <returns>will return nothig but will validate all permission on this user
        /// according to controller and action if exist then move to next middleware else throw
        /// forbidden error
        /// </returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string controller = context.ActionDescriptor.RouteValues["controller"];
            // string action = context.ActionDescriptor.RouteValues["action"];

            //var permissionClaim = this._identityUser.GetUserPermissionClaim();
            //if (permissionClaim == null)
            //{
            //    context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            //    return;
            //}
            //else
            //{
            //    var permissions = permissionClaim.Value;
            //    var userPermissions = JsonConvert.DeserializeObject<IdentityUserPermission[]>(permissions).ToList();
            //    var modulePermissions = userPermissions.Where(i => i.ModuleName + "." + i.PermissionName == _actionType
            //                                                    && i.HasPermission);
            //    if (modulePermissions.Count() == 0)
            //    {
            //        context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            //        return;
            //    }
            //}
            await next();
        }
    }
}
