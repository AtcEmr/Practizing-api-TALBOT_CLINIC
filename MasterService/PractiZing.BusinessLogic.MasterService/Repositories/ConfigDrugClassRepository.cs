using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigDrugClassRepository : ModuleBaseRepository<ConfigDrugClass>, IConfigDrugClassRepository
    {
        public ConfigDrugClassRepository(ValidationErrorCodes errorCodes,
                                  DataBaseContext dbContext,
                                  ILoginUser loggedUser)
                                  : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IConfigDrugClass> Get(int count)
        {
            return await this.Connection.SingleAsync<ConfigDrugClass>(i => i.RangeTo >= count && i.RangeFrom <= count);
        }

        public async Task<IConfigDrugClass> GetByCode(string cptcode)
        {
            return await this.Connection.SingleAsync<ConfigDrugClass>(i => i.CptCode== cptcode);
        }
    }
}
