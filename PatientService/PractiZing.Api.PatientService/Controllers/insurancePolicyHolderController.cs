using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class InsurancePolicyHolderController : SecuredRepositoryController<IInsurancePolicyHolderRepository>
    {
        public InsurancePolicyHolderController(IInsurancePolicyHolderRepository insurancePolicyHolderRepository) : base(insurancePolicyHolderRepository)
        {
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePolicyHolder([FromBody]InsurancePolicyHolder entity)
        {
            try
            {
                var result = await this.Repository.Update(entity);
                return Ok(result);
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
