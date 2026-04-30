using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ReportService.Controller
{
    [Route("api/[controller]")]
    public class ReportDataController : SecuredRepositoryController<IReportRepository>
    {
        private ILogger _logger;
        public ReportDataController(IReportRepository reportService, ILogger<ReportDataController> logger) : base(reportService)
        {
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetReportData([FromQuery]int reportId, [FromBody]object parameterObject)
        {
            try
            {
                this._logger.LogInformation(" parameterObject --" + parameterObject);
                
                var result = await this.Repository.GenerateReportData(reportId, parameterObject);
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

        [HttpPost("GeneratePatientStatement")]
        [AllowAnonymous]
        public async Task<IActionResult> GeneratePatientStatement([FromQuery]int reportId, [FromBody]object parameterObject)
        {
            try
            {
                this._logger.LogInformation(" parameterObject --" + parameterObject);

                var result = await this.Repository.GeneratePatientStatement(reportId, parameterObject);
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

        [HttpPost("GeneratePatientStatementXML")]
        [AllowAnonymous]
        public async Task<IActionResult> GeneratePatientStatementXML([FromQuery] int reportId, [FromQuery] string xmlFilePath, [FromBody] object parameterObject)
        {
            try
            {
                this._logger.LogInformation(" parameterObject --" + parameterObject);

                var result = await this.Repository.GeneratePatientStatementXML(reportId, parameterObject, xmlFilePath);
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
