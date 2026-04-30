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
    public class ChargeBalanceAR90Repository : ModuleBaseRepository<IChargeBalanceAR90>, IChargeBalanceAR90Repository
    {
        public ChargeBalanceAR90Repository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }       

        public async Task<IEnumerable<IChargeBalanceAR90>> GetAll()
        {
            var maxDate = (await this.Connection.SelectAsync<ChargeBalanceAR90>()).Max(i => i.CreatedDate);

            return (await this.Connection.SelectAsync<IChargeBalanceAR90>(i=>i.CreatedDate.Day==maxDate.Day && i.CreatedDate.Month==maxDate.Month && i.CreatedDate.Year==maxDate.Year));
        }
    }
}
