using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;

namespace PractiZing.Api.ChargesPaymentService.Controllers
{
    [Route("api/[controller]")]
    public class PaymentReportDataController : SecuredRepositoryController<IPaymentReportDataRepository>
    {        
        public PaymentReportDataController(IPaymentReportDataRepository paymentReportDataRepository) : base(paymentReportDataRepository)
        {
            
        }

        /// <summary>
        /// get method's for claim  batches
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get(PaymentReportDataFilterDTO filter)
        {
            try
            {
                var result = await this.Repository.Get(filter);
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
