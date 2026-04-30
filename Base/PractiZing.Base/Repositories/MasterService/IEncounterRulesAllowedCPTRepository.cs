using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IEncounterRulesAllowedCPTRepository
    {
        Task<IEnumerable<IEncounterRulesAllowedCPT>> GetAll();
        Task<IEncounterRulesAllowedCPT> GetById(int id);
        Task<IEnumerable<IEncounterRulesAllowedCPT>> GetByEncounterRuleId(int encounterRuleId);

    }
}
