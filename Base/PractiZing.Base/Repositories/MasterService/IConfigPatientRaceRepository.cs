using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigPatientRaceRepository
    {
        Task<IEnumerable<IConfigPatientRace>> Get();
        Task<IConfigPatientRace> Get(Int16 id);
    }
}
