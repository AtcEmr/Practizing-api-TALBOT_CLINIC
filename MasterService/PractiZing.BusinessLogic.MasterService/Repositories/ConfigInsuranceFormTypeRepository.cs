using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
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
    public class ConfigInsuranceFormTypeRepository : ModuleBaseRepository<ConfigInsuranceFormType>, IConfigInsuranceFormTypeRepository
    {
        public ConfigInsuranceFormTypeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigInsuranceFormType> Get(Int16 id)
        {
            return await this.Connection.SingleAsync<ConfigInsuranceFormType>(i => i.Id == id);

        }

        public async Task<IEnumerable<IConfigInsuranceFormType>> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigInsuranceFormType>(i => i.IsActive == true)).OrderBy(i => i.FTName);

        }
    }
}
