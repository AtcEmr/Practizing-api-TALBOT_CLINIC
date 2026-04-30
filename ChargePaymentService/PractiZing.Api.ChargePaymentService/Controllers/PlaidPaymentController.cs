using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class PlaidPaymentController : SecuredRepositoryController<IPlaidPaymentRepository>
    {        
        public PlaidPaymentController(IPlaidPaymentRepository scrubErrorRepository) : base(scrubErrorRepository)
        {
            
        }

        [HttpGet("test")]
        public async Task Test()
        {
            await this.Repository.Test();

        }

        [HttpPost("PlaidPayments")]
        public async Task<IActionResult> GetBankTransaction(PlaidPaymentSearch plaidPaymentSearch)
        {
            var result=await this.Repository.GetBankTransactionSync(plaidPaymentSearch);
            if(!string.IsNullOrWhiteSpace(result))
            {
                return StatusCode(500, result);
            }
            return Ok(result);
        }

        [HttpGet("getPlaidPayments")]
        public async Task<IActionResult> GetPlaidPayments([FromQuery] PlaidPaymentSearch plaidPaymentSearch)
        {
            var result =await this.Repository.GetPaymentsOnFilterDates(plaidPaymentSearch);
            return Ok(result);
        }

        [HttpPost("GeneratePlaidPaymentsFromExcelImport/{monthId}/{yearId}")]
        public async Task<IActionResult> GeneratePatientForAutoStatement(int monthId, int yearId)
        {
            try
            {
                
                var files = Request.Form.Files;
                if(files.Count==0)
                {
                    throw new Exception("Please select the file.");
                }
                
               var result = await this.Repository.GeneratePlaidPaymentsFromExcelImport(monthId, yearId, files.FirstOrDefault());
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
