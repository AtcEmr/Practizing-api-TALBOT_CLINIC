using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterServcie.Objects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : SecuredRepositoryController<IReportService>
    {
        private ILogger _logger;
        public ReportController(IReportService reportService, ILogger<ReportController> logger) : base(reportService)
        {
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> GenrateReport([FromBody]ReportParameterDTO parameterObject)
        {
            try
            {
                var fileByte = await this.Repository.GenerateReport(parameterObject);
                return File(fileByte.Item1, fileByte.Item2);
            }
            catch (EntityException ex)
            {
                this._logger.LogInformation("GenrateReport EntityException Trace - " + ex.StackTrace);
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("GenrateReport Exception Trace - " + ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetPatientStatement")]
        public async Task<IActionResult> GenratePatientStatement([FromBody]PatientStatementParameterDTO patientUIds)
        {
            try
            {
                var fileByte = await this.Repository.GeneratePatientStatementTest(patientUIds);
                return File(fileByte.Item1, fileByte.Item2);
            }
            catch (EntityException ex)
            {
                this._logger.LogInformation("GenratePatientStatement EntityException Trace - " + ex.StackTrace);
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("GenratePatientStatement Exception Trace - " + ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetPatientStatementEMR")]
        public async Task<IActionResult> GenratePatientStatementEMR([FromBody]PatientStatementParameterDTO patientUIds)
        {
            try
            {
                var fileByte = await this.Repository.GeneratePatientStatement(patientUIds);
                return Ok(Convert.ToBase64String(fileByte.Item1));
            }
            catch (EntityException ex)
            {
                this._logger.LogInformation("GenratePatientStatement EntityException Trace - " + ex.StackTrace);
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("GenratePatientStatement Exception Trace - " + ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetLABPatientStatement")]
        public async Task<IActionResult> GetLABPatientStatement([FromBody]PatientStatementParameterDTO patientUIds)
        {
            try
            {
                var fileByte= await this.Repository.GetLabPatientBalancesStatments(patientUIds);
                return File(fileByte.Item1, fileByte.Item2);
            }
            catch (EntityException ex)
            {
                this._logger.LogInformation("GenratePatientStatement EntityException Trace - " + ex.StackTrace);
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("GenratePatientStatement Exception Trace - " + ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GeneratePatientForAutoStatement")]        
        public async Task<IActionResult> GeneratePatientForAutoStatement()
        {
            try
            {
                 await this.Repository.GeneratePatientForAutoStatement(5);
                var files = Request.Form.Files;
                string obj = Request.Form["BatchPatientStatementDTO"].FirstOrDefault();
                var dto = Newtonsoft.Json.JsonConvert.DeserializeObject<BatchPatientStatementDTO>(obj);
                if (files.Count == 0)
                {
                    var result = await this.Repository.GeneratePatientForAutoStatement(dto.Days);
                    result = ServiceStack.JSON.stringify(result);
                    return Ok(result);
                }
                else
                {
                    var result = await this.Repository.GeneratePatientFromExcelImport(files.FirstOrDefault());
                    result = ServiceStack.JSON.stringify(result);
                    return Ok(result);
                }
            }
            catch (EntityException ex)
            {
                this._logger.LogInformation("GenratePatientStatementXML EntityException Trace - " + ex.StackTrace);
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("GenratePatientStatementXML Exception Trace - " + ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetPatientStatementXML")]
        public async Task<IActionResult> GenratePatientStatementXML([FromBody] PatientStatementParameterDTO patientUIds)
        {
            try
            {
                var fileByte = await this.Repository.GeneratePatientStatementXML(patientUIds);
                return File(fileByte.Item1, fileByte.Item2);
            }
            catch (EntityException ex)
            {
                this._logger.LogInformation("GenratePatientStatementXML EntityException Trace - " + ex.StackTrace);
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("GenratePatientStatementXML Exception Trace - " + ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPatientAgingBalancesBatchStatement")]
        public async Task<IActionResult> GetPatientAgingBalances_BatchStatement(string uid)
        {
            try
            {
                var result = await this.Repository.GetPatientAgingBalances_BatchStatement(uid);
                //result = ServiceStack.JSON.stringify(result);
                return Ok(result);

            }
            catch (EntityException ex)
            {
                this._logger.LogInformation("GenratePatientStatementXML EntityException Trace - " + ex.StackTrace);
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("GenratePatientStatementXML Exception Trace - " + ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AutoGeneratePatientStatements")]        
        public async Task<IActionResult> AutoGeneratePatientStatements()
        {
            try
            {
                var result = await this.Repository.GenerateBatchStatements();
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

        [HttpGet("GetPatientForStatementWithOurMedicaid")]
        public async Task<IActionResult> GetPatientForStatementWithOurMedicaid(string patientUId)
        {
            try
            {
                var result = await this.Repository.GetPatientForStatementWithOurMedicaid(patientUId);
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
