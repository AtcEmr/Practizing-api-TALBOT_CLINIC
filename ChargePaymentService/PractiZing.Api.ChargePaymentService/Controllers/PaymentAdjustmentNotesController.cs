using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class PaymentAdjustmentNotesController : SecuredRepositoryController<IPaymentAdjustmentNotesRepository>
    {
        IPaymentAdjustmentNotesRepository _paymentAdjustmentNotesRepository;
        public PaymentAdjustmentNotesController(IPaymentAdjustmentNotesRepository paymentAdjustmentNotesRepository) : base(paymentAdjustmentNotesRepository)
        {
            this._paymentAdjustmentNotesRepository = paymentAdjustmentNotesRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> SendNotesToEMR()
        {
            try
            {
                var result = await this.Repository.SendNotesToEMR();
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
