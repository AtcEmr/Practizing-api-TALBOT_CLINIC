using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface INotesCategoryRepository : IBaseRepository
    {
        Task<IEnumerable<INotesCategory>> GetAll();
        Task<INotesCategory> GetByUId(Guid UId);
        Task<IPaginationQuery<INotesCategory>> GetNotesCategoryGrid(SearchQuery<INotesCategoryFilter> entity);
        Task<IEnumerable<INotesCategory>> GetNotesCategoryData(int categoryId);
        Task<INotesCategory> AddNew(INotesCategory entity);
        Task<int> Update(INotesCategory entity);
        Task<int> Delete(string uid);
    }
}
