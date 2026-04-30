using PractiZing.Base.Object.PracticeCentral;
using System.Collections.Generic;
using System.Data;

namespace PractiZing.Base.Repositories
{
    public interface IPracticeCentralDataRepository
    {
        IPracticePracticeCentralDTO GetPractice(string headerOrigin = "");

        IEnumerable<IPracticePracticeCentralDTO> GetPractices();

        IPracticePracticeCentralDTO GetPracticeByPracticeCode(string practiceCode);

        IPracticePracticeCentralDTO GetPracticeByCustomerKey(string customerKey);
    }
}
