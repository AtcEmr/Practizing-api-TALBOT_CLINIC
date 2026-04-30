using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface ICPTCodeRepository : IBaseRepository
    {
        Task<IPaginationQuery<ICPTCode>> Get(SearchQuery<ICPTCodeFilter> entity);
        Task<ICPTCode> GetById(int id);
        Task<ICPTCode> GetByUId(Guid uid);

        Task<ICPTCode> AddNew(ICPTCode entity);
        Task<int> Update(ICPTCode entity);
        Task<int> Delete(Guid uId);

        Task<IEnumerable<ICPTCode>> GetCPTCodeByDrugClassId(int drugClassId);
        Task<ICPTCode> GetCPTCode(string code);
        Task<IEnumerable<ICPTCode>> GetCPTCodes();
        Task<IEnumerable<ICPTCode>> GetByUId(IEnumerable<Guid> Ids);
    }
}
