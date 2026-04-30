using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IMasterICD10Repository
    {
        // Task<IEnumerable<IMasterICD10>> SearchICD(string entity);
        Task<IPaginationQuery<IMasterICD10>> SearchICD(SearchQuery<IMasterICD10Filter> entity);
    }
}
