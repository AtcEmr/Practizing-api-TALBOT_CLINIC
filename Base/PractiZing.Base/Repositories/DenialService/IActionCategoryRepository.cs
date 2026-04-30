using Microsoft.AspNetCore.Http;
using PractiZing.Base.Entities.DenialService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.DenialService
{
    public interface IActionCategoryRepository
    {
        Task<IEnumerable<IActionCategory>> Get(bool forGrid);
        Task<IEnumerable<IActionCategory>> GetSubCategoryByCategoryUId(Guid categoryUId);
        Task<IActionCategory> Get(int id);
        Task<IActionCategory> Get(Guid UId);
        Task<IEnumerable<int>> GetByUIds(string uids);
        Task<IActionCategory> AddNew(IActionCategory entity, IEnumerable<IFormFile> formFiles);
        Task<int> Update(IActionCategory entity, IEnumerable<IFormFile> formFiles);
        Task<int> Delete(Guid uid);
        Task ParentCategoryExist(Guid uid);
        Task<IActionCategory> GetById(int id);
    }
}
