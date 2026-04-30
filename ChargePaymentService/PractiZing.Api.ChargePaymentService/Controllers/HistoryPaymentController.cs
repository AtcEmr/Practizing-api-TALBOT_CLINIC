using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class HistoryPaymentController : SecuredRepositoryController<IHistoryPaymentRepository>
    {
        public HistoryPaymentController(IHistoryPaymentRepository historyPaymentRepository) : base(historyPaymentRepository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this.Repository.Find();
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