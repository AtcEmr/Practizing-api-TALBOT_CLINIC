using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IEncounterRulesAllowedPOSRepository
    {
        Task<IEnumerable<IEncounterRulesAllowedPOS>> GetAll();
        Task<IEncounterRulesAllowedPOS> GetById(int id);
        Task<IEnumerable<IEncounterRulesAllowedPOS>> GetByEncounterRuleId(int encounterRuleId);

    }
}
