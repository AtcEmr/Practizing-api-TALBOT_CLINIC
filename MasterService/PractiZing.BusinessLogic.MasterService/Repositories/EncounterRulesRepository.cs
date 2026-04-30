using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
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
    public class EncounterRulesRepository : ModuleBaseRepository<IEncounterRules>, IEncounterRulesRepository
    {
        public EncounterRulesRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser)
                                    : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IEncounterRules>> GetAll()
        {
            return (await this.Connection.SelectAsync<EncounterRules>(i => i.IsActive == true));
        }

        public async Task<IEncounterRules> GetById(int id)
        {
            //return await this.Connection.SingleAsync<EncounterRules>(i => i.Id == id);
            var query = this.Connection.From<EncounterRules>()
                           .Join<EncounterRules, EncounterTypes>((r, t) => r.EncounterTypeId == t.Id)
                           .SelectDistinct<EncounterRules, EncounterTypes>((r,t) => new
                           {
                               r,
                               t.Name
                           })
                           .Where<EncounterRules>(i => i.Id==id);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            return Mapper< EncounterRules>.MapList(queryResult.FirstOrDefault());
        }

        public async Task<IEncounterRules> GetByCode(string code)
        {
            //return await this.Connection.SingleAsync<EncounterRules>(i => i.Id == id);
            var query = this.Connection.From<EncounterRules>()
                           .Join<EncounterRules, EncounterTypes>((r, t) => r.EncounterTypeId == t.Id)
                           .SelectDistinct<EncounterRules, EncounterTypes>((r, t) => new
                           {
                               r,
                               t.Name
                           })
                           .Where<EncounterTypes>(i => i.Code == code);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            return Mapper<EncounterRules>.MapList(queryResult.FirstOrDefault());
        }
    }
}
