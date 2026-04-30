using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PractiZing.DataAccess.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using System.Linq;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigTOSRepository : ModuleBaseRepository<ConfigTOS>, IConfigTOSRepository
    {
        public ConfigTOSRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
          : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigTOS> GetByCode(string code)
        {
            return await this.Connection.SingleAsync<ConfigTOS>(i => i.Code == code);

        }

        public async Task<IEnumerable<IConfigTOS>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigTOS>()).OrderBy(i => i.Code);

        }
    }
}

