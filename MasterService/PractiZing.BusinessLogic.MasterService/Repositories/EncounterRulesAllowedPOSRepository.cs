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
    public class EncounterRulesAllowedPOSRepository : ModuleBaseRepository<IEncounterRulesAllowedPOS>, IEncounterRulesAllowedPOSRepository
    {
        public EncounterRulesAllowedPOSRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser)
                                    : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IEncounterRulesAllowedPOS>> GetAll()
        {
            return (await this.Connection.SelectAsync<EncounterRulesAllowedPOS>(i => i.Active == true));
        }

        public async Task<IEncounterRulesAllowedPOS> GetById(int id)
        {
            return await this.Connection.SingleAsync<EncounterRulesAllowedPOS>(i => i.Id == id);
        }

        public async Task<IEnumerable<IEncounterRulesAllowedPOS>> GetByEncounterRuleId(int encounterRuleId)
        {
            return await this.Connection.SelectAsync<EncounterRulesAllowedPOS>(i => i.EncounterRuleId == encounterRuleId);
        }
    }
}
