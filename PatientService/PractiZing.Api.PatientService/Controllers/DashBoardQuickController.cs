using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Common;
using PractiZing.Base.Model;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.PatientService;
using PractiZing.BusinessLogic.PatientService.Services;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using System;
using System.Threading.Tasks;

namespace PractiZing.Api.PatientService.Controllers
{
    [Route("api/[controller]")]
    public class DashBoardQuickController : SecuredRepositoryController<IDataIntegrationRepository>
    {
        private readonly IDataIntegrationService _dataIntegrationService;
        IDashboardQuickStartService _dashboardQuickStartService;

        public DashBoardQuickController(IDashboardQuickStartService dashboardQuickStartService,IDataIntegrationService dataIntegrationService, IDataIntegrationRepository dataIntegrationRepository) : base(dataIntegrationRepository)
        {
            this._dataIntegrationService = dataIntegrationService;
            this._dashboardQuickStartService = dashboardQuickStartService;
        }

        [Route("GetDashboardURL")]
        [HttpGet]
        public async Task<QuicksightModel> GetDashboardURL()
        {
            string objUrl = await this._dashboardQuickStartService.GetUrl();

            return new QuicksightModel
            {
                URL = objUrl
            };
        }


    }

    public class QuicksightModel
    {
        public string URL { get; set; }
    }
}
