using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Service.ReportService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.ReportService.DTO;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.ReportService.Controller
{
    [Route("api/[controller]")]
    public class ReportARChargesMonthWiseController : SecuredRepositoryController<IReportARChargesMonthWiseRepository>
    {
        private ILogger _logger;
        ICPAReportService _cpaReportService;
        IReportARChargesMonthWiseRepository _reportARChargesMonthWiseRepository;
        public ReportARChargesMonthWiseController(IReportARChargesMonthWiseRepository reportARChargesMonthWiseRepository, ILogger<ReportARChargesMonthWiseController> logger) : base(reportARChargesMonthWiseRepository)
        {
            this._logger = logger;
            //this._cpaReportService = cpaReportService;
            this._reportARChargesMonthWiseRepository = reportARChargesMonthWiseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(ReportARChargesMonthWiseDTO reportARChargesMonthWiseDTO)
        {
            var result = await this._reportARChargesMonthWiseRepository.GetAll(reportARChargesMonthWiseDTO);
            return Ok(result);
        }
    }
}
