using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.PatientService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class PatientStatementController : SecuredRepositoryController<IPatientStatementRepository>
    {
        IPatientService _patientService;
        public PatientStatementController(IPatientStatementRepository repository, IPatientService patientService) : base(repository)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string patientUId)
        {
            try
            {
                var result = await this._patientService.GetPatientStatement(patientUId);
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
