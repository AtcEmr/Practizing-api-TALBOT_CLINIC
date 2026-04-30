using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface INDCRepository : IBaseRepository
    {
        Task<IPaginationQuery<INDC>> GetAll(SearchQuery<INDCFilter> entity);
        Task<IEnumerable<INDC>> GetNDCCodes();
        Task<INDC> GetByCode(string code);
        Task<INDC> GetByUId(Guid uid);
        Task<INDC> AddNew(INDC entity);
        Task<int> Update(INDC entity);
        Task<int> Delete(short code);
        Task<INDC> GetByCptCode(string code);
    }
}
