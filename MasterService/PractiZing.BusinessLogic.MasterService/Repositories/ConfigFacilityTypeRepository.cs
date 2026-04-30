using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigFacilityTypeRepository : ModuleBaseRepository<ConfigFacilityType>, IConfigFacilityTypeRepository
    {
        public ConfigFacilityTypeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigFacilityType> Get(int id)
        {
             return await this.Connection.SingleAsync<ConfigFacilityType>(i => i.Id == id);
            
        }

        public async Task<IEnumerable<IConfigFacilityType>> GetAll()
        {
             return (await this.Connection.SelectAsync<ConfigFacilityType>()).OrderBy(i => i.TypeName);
            
        }
    }
}
