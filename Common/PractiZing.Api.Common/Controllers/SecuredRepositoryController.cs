using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Api.Common.Controllers
{
    public interface ISecuredIdentityController
    {
        PractiZingIdentity Identity { get; }

        PractiZingPrincipal User { get; }
    }

    [Authorize]
    public abstract class SecuredRepositoryController<TRepo> : BaseRepositoryController<TRepo>, ISecuredIdentityController
         where TRepo : class
    {
        public SecuredRepositoryController(TRepo repository) : base(repository)
        {

        }

        public PractiZingIdentity Identity
        {
            get
            {
                return (PractiZingIdentity)this.Request.HttpContext.User.Identity;
            }
        }

        public new PractiZingPrincipal User
        {
            get
            {
                return this.Identity.Principal;
            }
        }
    }

    [Authorize]
    public abstract class SecuredServiceController : Controller, ISecuredIdentityController
    {

        public PractiZingIdentity Identity
        {
            get
            {
                return (PractiZingIdentity)this.Request.HttpContext.User.Identity;
            }
        }

        public new PractiZingPrincipal User
        {
            get
            {
                return this.Identity.Principal;
            }
        }
    }
}
