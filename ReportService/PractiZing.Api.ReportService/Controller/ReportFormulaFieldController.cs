using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ReportService.Controller
{
    [Route("api/[controller]")]
    public class ReportFormulaFieldController : SecuredRepositoryController<IReportFormulaFieldRepository>
    {
        public ReportFormulaFieldController(IReportFormulaFieldRepository reportService) : base(reportService)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetFormulaFieldData([FromQuery]int reportId, [FromBody]object parameterObject)
        {
            try
            {
                var result = await this.Repository.GetFieldData(reportId, parameterObject);
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
