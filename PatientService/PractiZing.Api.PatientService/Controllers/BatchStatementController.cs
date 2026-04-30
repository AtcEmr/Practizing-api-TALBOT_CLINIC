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
    public class BatchStatementController : SecuredRepositoryController<IBatchStatementRepository>
    {
        IBatchStatementRepository _batchStatementRepository;
        public BatchStatementController(IBatchStatementRepository repository) : base(repository)
        {
            _batchStatementRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this._batchStatementRepository.GetAll();
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
