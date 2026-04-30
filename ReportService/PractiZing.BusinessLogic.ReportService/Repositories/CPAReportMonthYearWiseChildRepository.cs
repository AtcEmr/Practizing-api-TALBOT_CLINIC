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
    public class CPAReportMonthYearWiseChildRepository : ModuleBaseRepository<ICPAReportMonthYearWiseChild>, ICPAReportMonthYearWiseChildRepository
    {
        public CPAReportMonthYearWiseChildRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }       

        public async Task<IEnumerable<ICPAReportMonthYearWiseChild>> GetAll(int id)
        {
            return (await this.Connection.SelectAsync<CPAReportMonthYearWiseChild>(i=>i.CPAReportMonthYearWiseId==id));
        }
    }
}
