using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IEncounterRulesRepository
    {
        Task<IEnumerable<IEncounterRules>> GetAll();
        Task<IEncounterRules> GetById(int id);
        Task<IEncounterRules> GetByCode(string code);
    }
}
