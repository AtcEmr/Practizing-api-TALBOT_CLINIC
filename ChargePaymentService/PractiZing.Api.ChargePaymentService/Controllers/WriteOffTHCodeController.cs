using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class WriteOffTHCodeController : SecuredRepositoryController<IWriteOffTHCodeRepository>
    {        
        public WriteOffTHCodeController(IWriteOffTHCodeRepository writeOffTHCodeRepository) : base(writeOffTHCodeRepository)
        {
            
        }

        [HttpGet("getData")]
        public async Task<IActionResult> GetDataFormEMR()
        {
            try
            {
                var result = await this.Repository.GetDataFormEMR();

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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]List<WriteOffEMRObjectDTO> list)
        {
            try
            {
                var result = await this.Repository.UpdateWriteOffEMRAcknowledgement(list);
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
