using PractiZing.Base.Entities.DenialService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.DenialService
{
    public interface IActionCategoryService
    {
        //Task<IActionCategory> GetActionCategory();
        //Task<IEnumerable<IActionNote>> GetByActionCategory(Guid actionCategoryUId);
        Task<int> Delete(Guid uid);
    }
}
