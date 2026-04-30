using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ScrubErrorController : SecuredRepositoryController<IScrubErrorRepository>
    {        
        public ScrubErrorController(IScrubErrorRepository scrubErrorRepository) : base(scrubErrorRepository)
        {
            
        }

        [HttpGet("downloadScrubErrors")]
        public async Task<IActionResult> DownloadScrubErrors()
        {
            try
            {
                var result = await this.Repository.GetAll();                
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "Claim Scrub Error Data");
                return File(fileBytes, ExcelExportHelper.ExcelContentType);                
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
