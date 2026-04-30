using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.PracticeCentral;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.SecurityService
{
    public interface IPracticeCentralPracticeRepository
    {
        Task<IEnumerable<IPracticeCentralPractice>> GetAllPractices();
        Task<IPracticePracticeCentralDTO> GetPracticeByPracticeCode(string practiceCode);
    }
}
