using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.ReportService.Objects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.Api.ReportService.Controller
{
    [Route("api/[controller]")]
    public class ChargeStatController : SecuredRepositoryController<IChargeStatRepository>
    {
        private ILogger _logger;
        public ChargeStatController(IChargeStatRepository chargeStatRepository, ILogger<ChargeStatController> logger) : base(chargeStatRepository)
        {
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetDenialDashboardData([FromQuery]bool? hasDenial, [FromQuery] bool isBaseStatsRequired = true)
        {
            try
            {
                var result = await this.Repository.GetDenialDashboardData(hasDenial, isBaseStatsRequired);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getDenialData")]
        public async Task<IActionResult> GetDenialData([FromQuery]ChargeStatFilter chargeStatFilter)
        {
            try
            {
                var result = await this.Repository.GetDenialData(chargeStatFilter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("refreshDenialDashboard")]
        public async Task<IActionResult> RefreshDenialDashboard()
        {
            try
            {
                var result = await this.Repository.RefreshDenialDashboard();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("downloaddenialfile")]
        public async Task<IActionResult> downloaddenialfile()
        {
            try
            {
                var result = await this.Repository.GetDenailFileData();
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "DenialFile");
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

        [HttpPost("downloadAgingFile")]
        public async Task<IActionResult> DownloadAgingFile()
        {
            try
            {
                var result = await this.Repository.GetAgingFileData();
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "AgingFile");
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

        [HttpPost("downloadDenialReasonsFile")]
        public async Task<IActionResult> DownloadDenialReasonsFile()
        {
            try
            {
                var result = await this.Repository.GetDenialReasonsFile();
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "DenialReasonsFile");
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

        [HttpPost("downloadInsuranceCompaniesFile")]
        public async Task<IActionResult> DownloadInsuranceCompaniesFile()
        {
            try
            {
                var result = await this.Repository.GetInsuranceCompaniesFile();
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "InsuranceCompaniesFile");
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

        [HttpPost("downloadCarrierTypesFile")]
        public async Task<IActionResult> DownloadCarrierTypesFile()
        {
            try
            {
                var result = await this.Repository.GetInsuranceTypesFile();
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "CarrierTypesFile");
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
