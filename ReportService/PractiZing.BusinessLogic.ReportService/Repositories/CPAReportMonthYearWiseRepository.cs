using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractiZing.DataAccess.ReportService;
using PractiZing.Base.Entities.ReportService;
using PractiZing.DataAccess.ReportService.Tables;
using PractiZing.Base.Repositories.ReportService;

namespace PractiZing.BusinessLogic.ReportService.Repositories
{
    public class CPAReportMonthYearWiseRepository : ModuleBaseRepository<ICPAReportMonthYearWise>, ICPAReportMonthYearWiseRepository
    {
        public CPAReportMonthYearWiseRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }       

        public async Task<IEnumerable<ICPAReportMonthYearWise>> GetAll()
        {
            var maxDate = (await this.Connection.SelectAsync<CPAReportMonthYearWise>()).Max(i => i.CreatedDate);

            return (await this.Connection.SelectAsync<CPAReportMonthYearWise>(i=>i.CreatedDate.Day==maxDate.Day && i.CreatedDate.Month==maxDate.Month && i.CreatedDate.Year==maxDate.Year));
        }
    }
}
