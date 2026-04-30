using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IRemarkCodeSolutionRepository
    {
        Task<IEnumerable<IRemarkCodeSolution>> GetAll();
        Task<IEnumerable<IRemarkCodeSolution>> Get(string remarkCode);
    }
}
