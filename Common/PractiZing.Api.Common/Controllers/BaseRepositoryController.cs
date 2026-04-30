using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Authorize;
using PractiZing.Api.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Api.Common.Controllers
{
    public abstract class BaseRepositoryController<TRepo> : ControllerBase where TRepo : class
    {
        public TRepo Repository { get; set; }
        public BaseRepositoryController(TRepo repository)
        {
            this.Repository = repository;
        }

        //public async Task ValidateRequest()
        //{
        //    var fingerprinter = new FingerPrinter();
        //    var fingerprint = await fingerprinter.GenerateAndValidateFingerPrint(Request);
        //    if (string.IsNullOrEmpty(fingerprint))
        //    {
               
        //    }
        //}
    }
}
