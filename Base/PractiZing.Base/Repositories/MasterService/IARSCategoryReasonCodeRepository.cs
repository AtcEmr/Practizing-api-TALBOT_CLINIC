using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IARSCategoryReasonCodeRepository : IBaseRepository
    {
        Task<IEnumerable<IARSCategoryReasonCode>> GetAll(string reasonCode);
        Task<IARSCategoryReasonCode> GetById(long id);
        Task<IARSCategoryReasonCode> AddNew(IARSCategoryReasonCode entity);
        Task<int> Update(IARSCategoryReasonCode entity);
        Task<int> Delete(long id);
        Task AddEntities(IEnumerable<IARSCategoryReasonCode> entities, int noteCategoryId);
        Task UpdateEntities(IEnumerable<IARSCategoryReasonCode> entities, int noteCategoryId);
        Task<IEnumerable<IARSCategoryReasonCode>> GetByUId(IEnumerable<long> Ids);
    }
}
