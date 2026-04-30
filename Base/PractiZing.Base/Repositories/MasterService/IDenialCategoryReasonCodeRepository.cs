using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IDenialCategoryReasonCodeRepository
    {
        Task<bool> AddEntities(IEnumerable<IDenialCategoryReasonCode> entities);
        
        Task<bool> UpdateEntities(IEnumerable<IDenialCategoryReasonCode> entities);

        Task<int> DeleteAllByActionCategory(int denialCategoryId);
    }
}
