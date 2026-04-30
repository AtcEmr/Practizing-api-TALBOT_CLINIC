using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.ReportService;
using PractiZing.Base.Model;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Object.ReportService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ReportService
{
    public interface ICPAReportService
    {
        Task<IEnumerable<ICPAReportMonthYearWise>> GetAll();
        Task<IEnumerable<IChargeBalanceAR90>> GetAllAR90();
        Task<IEnumerable<ICPAReportMonthYearWiseChild>> GetAllChild(int id);
    }
}
