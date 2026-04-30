using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ProviderFacilityValidtionRepository : ModuleBaseRepository<IProviderFacilityValidtion>, IProviderFacilityValidtionRepository
    {
        public ProviderFacilityValidtionRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser)
                                    : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IProviderFacilityValidtion>> GetAll()
        {
            return (await this.Connection.SelectAsync<ProviderFacilityValidtion>());
        }
    }
}
