using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Service.ERAService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ERAService.Controllers
{
    [Route("api/[controller]")]
    public class ERAClaimController : SecuredRepositoryController<IERAClaimRepository>
    {
        private readonly IERARootService _iERARootService;

        public ERAClaimController(IERAClaimRepository repository, IERARootService iERARootService) : base(repository)
        {
            this._iERARootService = iERARootService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repository.Get();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int eraClaimId)
        {
            try
            {
                await this.Repository.Update(eraClaimId);
                return Ok(1);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


