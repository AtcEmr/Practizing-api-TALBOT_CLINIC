using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Service.ReportService;
using PractiZing.DataAccess.Common;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ReportService.Controller
{
    [Route("api/[controller]")]
    public class CPAReportYearMonthWiseController : SecuredRepositoryController<ICPAReportMonthYearWiseRepository>
    {
        private ILogger _logger;
        ICPAReportService _cpaReportService;
        public CPAReportYearMonthWiseController(ICPAReportService cpaReportService, ICPAReportMonthYearWiseRepository reportService, ILogger<CPAReportYearMonthWiseController> logger) : base(reportService)
        {
            this._logger = logger;
            this._cpaReportService = cpaReportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._cpaReportService.GetAll();
            return Ok(result);
        }

        [HttpGet("ar90")]
        public async Task<IActionResult> GetAllAR90()
        {
            var result = await this._cpaReportService.GetAllAR90();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAllChild(int id)
        {
            var result = await this._cpaReportService.GetAllChild(id);
            return Ok(result);
        }
    }
}
