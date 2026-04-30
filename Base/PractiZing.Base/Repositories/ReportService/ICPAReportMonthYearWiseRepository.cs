using PractiZing.Base.Entities.ReportService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.ReportService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ReportService
{
    public interface ICPAReportMonthYearWiseRepository
    {
        Task<IEnumerable<ICPAReportMonthYearWise>> GetAll();
    }
}
