using AutoMapper;
using Microsoft.Extensions.Configuration;
using PractiZing.Base.Entities.ReportService;
using PractiZing.Base.Object.ReportService;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Service.PatientService;
using PractiZing.Base.Service.ReportService;
using PractiZing.BusinessLogic.ReportService.Factories;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.ReportService.DTO;
using PractiZing.DataAccess.ReportService.DTO.Statement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PractiZing.BusinessLogic.ReportService.Services
{
	public sealed class CPAReportService : ICPAReportService
    {
        private readonly ICPAReportMonthYearWiseChildRepository _iCPAReportMonthYearWiseChildRepository;
        private readonly ICPAReportMonthYearWiseRepository _cPAReportMonthYearWiseRepository;
        private readonly IChargeBalanceAR90Repository _chargeBalanceAR90Repository;

        private readonly IStatementDTOFactory _statementDTOFactory;
		private readonly string _statementXMLFolder;

		public CPAReportService(ICPAReportMonthYearWiseChildRepository iCPAReportMonthYearWiseChildRepository, ICPAReportMonthYearWiseRepository cPAReportMonthYearWiseRepository,
            IChargeBalanceAR90Repository chargeBalanceAR90Repository)
		{
            this._iCPAReportMonthYearWiseChildRepository = iCPAReportMonthYearWiseChildRepository;
            this._cPAReportMonthYearWiseRepository = cPAReportMonthYearWiseRepository;
            this._chargeBalanceAR90Repository = chargeBalanceAR90Repository;
        }

        public async Task<IEnumerable<ICPAReportMonthYearWise>> GetAll()
        {
            return await this._cPAReportMonthYearWiseRepository.GetAll();
        }

        public async Task<IEnumerable<IChargeBalanceAR90>> GetAllAR90()
        {
            return await this._chargeBalanceAR90Repository.GetAll();
        }

        public async Task<IEnumerable<ICPAReportMonthYearWiseChild>> GetAllChild(int id)
        {
            return await this._iCPAReportMonthYearWiseChildRepository.GetAll(id);
        }

    }
}
